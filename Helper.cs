using System;
using SystemIO = System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

using Lucene.Net;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using Lucene.Net.Search;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;

namespace FTSearch
{
    public class Helper
    {
        public static TextBox TBFileIndexing
        {
            set;
            get;
        }

        //public static DataGridView GVResults
        //{
        //    get;
        //    set;
        //}

        private static string rootPath = string.Empty;

        public static void Index(string path, string dbName)
        {
            rootPath = path.TrimEnd('\\');
            Directory dir = FSDirectory.Open(SearchForm.INDEXDB_FOLDER + "\\" + dbName);
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            IndexWriter writer = new IndexWriter(dir, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED);
            IndexDocs(writer, path);
            analyzer.Close();
            writer.Optimize();
            writer.Dispose();

        }

        private static void IndexDocs2(IndexWriter writer, string path)
        {
            if (SystemIO.Directory.Exists(path))
            {
                TBFileIndexing.AppendText(Environment.NewLine + path);
                SystemIO.DirectoryInfo dirInfo = new SystemIO.DirectoryInfo(path);

                string folderExclude = System.Configuration.ConfigurationManager.AppSettings["FolderExclude"].ToLower();
                if (folderExclude.Contains(dirInfo.Name.ToLower()))
                    return;

                foreach (SystemIO.FileInfo file in dirInfo.GetFiles())
                    IndexDocs(writer, file.FullName);
                foreach (SystemIO.DirectoryInfo dir in dirInfo.GetDirectories())
                    IndexDocs(writer, dir.FullName);
            }
            else
            {
                bool ignoreIndex = false;
                //TBFileIndexing.AppendText(Environment.NewLine + path);
                if (TBFileIndexing.Text.Length > 5000)
                    TBFileIndexing.Text = "";
                string fileExt = SystemIO.Path.GetExtension(path);
                if (fileExt != null)
                    fileExt = fileExt.ToLower();

                string extInclude = System.Configuration.ConfigurationManager.AppSettings["ExtInclude"];
                if (!string.IsNullOrEmpty(extInclude))
                {
                    if (!extInclude.Contains(fileExt))
                    {
                        TBFileIndexing.AppendText("... not include file extension - ignored");
                        ignoreIndex = true;
                    }
                }
                else
                {
                    string extExclude = System.Configuration.ConfigurationManager.AppSettings["ExtExclude"];

                    if (extExclude.Contains(fileExt))
                    {
                        TBFileIndexing.AppendText("... exclude file extension - ignored");
                        ignoreIndex = true;
                    }
                }
                SystemIO.FileInfo fileInfo = new System.IO.FileInfo(path);
                if (fileInfo.Length > 5000000)//~5MB
                {
                    TBFileIndexing.AppendText("... big file - ignored");
                    ignoreIndex = true;
                }

                try
                {
                    Document doc = new Document();
                    Field pathField = new Field("path", path.Replace(rootPath + "\\", ""), Field.Store.YES, Field.Index.NO);
                    doc.Add(pathField);
                    //doc.Add(new Field("modified",
                    //    new SystemIO.FileInfo(path).LastWriteTime.ToString("yyyyMMddHHmmss"), Field.Store.YES, Field.Index.NO));
                    string textContent = string.Empty;
                    if (!ignoreIndex) //only read not ignore files
                        textContent = ReaderFactory.GetText(path);

                    textContent = SystemIO.Path.GetFileNameWithoutExtension(path) + Environment.NewLine + textContent;
                    textContent = PrepareForIndex(textContent, fileExt);
                    Field contentField = new Field("content", textContent, Field.Store.NO, Field.Index.ANALYZED, Field.TermVector.YES);
                    doc.Add(contentField);
                    writer.AddDocument(doc);
                }
                catch (Exception ex)
                {
                    TBFileIndexing.AppendText("...read failed: " + ex.Message);
                }

            }
        }

        private static void IndexDocs(IndexWriter writer, string path)
        {
            if (SystemIO.Directory.Exists(path))
            {
                SystemIO.DirectoryInfo dirInfo = new SystemIO.DirectoryInfo(path);

                string folderExclude = System.Configuration.ConfigurationManager.AppSettings["FolderExclude"].ToLower();
                if (folderExclude.Contains(dirInfo.Name.ToLower()))
                    return;

                foreach (SystemIO.FileInfo file in dirInfo.GetFiles())
                    IndexDocs(writer, file.FullName);
                foreach (SystemIO.DirectoryInfo dir in dirInfo.GetDirectories())
                    IndexDocs(writer, dir.FullName);
            }
            else
            {
                bool ignoreIndex = false;
                TBFileIndexing.AppendText(Environment.NewLine + path);
                if (TBFileIndexing.Text.Length > 5000)
                    TBFileIndexing.Text = "";
                string fileExt = SystemIO.Path.GetExtension(path);
                if (fileExt != null)
                    fileExt = fileExt.ToLower();

                string extInclude = System.Configuration.ConfigurationManager.AppSettings["ExtInclude"];
                if (!string.IsNullOrEmpty(extInclude))
                {
                    if (!extInclude.Contains(fileExt))
                    {
                        TBFileIndexing.AppendText("... not include file extension - ignored");
                        ignoreIndex = true;
                    }
                }
                else
                {
                    string extExclude = System.Configuration.ConfigurationManager.AppSettings["ExtExclude"];

                    if (extExclude.Contains(fileExt))
                    {
                        TBFileIndexing.AppendText("... exclude file extension - ignored");
                        ignoreIndex = true;
                    }
                }
                SystemIO.FileInfo fileInfo = new System.IO.FileInfo(path);
                if (fileInfo.Length>5000000)//~5MB
                {
                    TBFileIndexing.AppendText("... big file - ignored");
                    ignoreIndex = true;
                }

                var task = new TaskFactory().StartNew(() =>
                {
                    try
                    {
                        Document doc = new Document();
                        Field pathField = new Field("path", path.Replace(rootPath + "\\", ""), Field.Store.YES, Field.Index.NO);
                        doc.Add(pathField);
                        //doc.Add(new Field("modified",
                        //    new SystemIO.FileInfo(path).LastWriteTime.ToString("yyyyMMddHHmmss"), Field.Store.YES, Field.Index.NO));
                        string textContent = string.Empty;
                        if (!ignoreIndex) //only read not ignore files
                            textContent = ReaderFactory.GetText(path);

                        textContent = SystemIO.Path.GetFileNameWithoutExtension(path) + Environment.NewLine + textContent;
                        textContent = PrepareForIndex(textContent, fileExt);
                        Field contentField = new Field("content", textContent, Field.Store.NO, Field.Index.ANALYZED, Field.TermVector.YES);
                        doc.Add(contentField);
                        writer.AddDocument(doc);
                    }
                    catch (Exception ex)
                    {
                        TBFileIndexing.AppendText("...read failed: " + ex.Message);
                    }
                });
                task.Wait(5000);
            }
        }        

        private static string PrepareForIndex(string content, string ext)
        {
            string sourceCodeExt = System.Configuration.ConfigurationManager.AppSettings["SourceCode"];
            if (sourceCodeExt.Contains(ext))
            {
                content = content.Replace(".", ". ");
            }
            //special checksum handle
            var pattern = @"([a-f0-9]{32}),(.+)";
            content = System.Text.RegularExpressions.Regex.Replace(content, pattern, "$1, $2");
            var pattern1 = @"(.*),([a-f0-9]{32})";
            content = System.Text.RegularExpressions.Regex.Replace(content, pattern1, "$1, $2");
            return content;
        }

        //public static void Search(string term, string dbName, string rootFolder)
        //{
        //    IList<ResultItem> resultList = SearchInDB(term, dbName, rootFolder);
        //    GVResults.DataSource = resultList;
        //}

        public static IList<ResultItem> SearchInDB(string term, string dbName, string rootFolder)
        {
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

            QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "content", analyzer);
            Query query = parser.Parse(term);

            Directory dir = FSDirectory.Open(SearchForm.INDEXDB_FOLDER + "\\" + dbName);
            Searcher searcher = new IndexSearcher(IndexReader.Open(dir, true));
            TopScoreDocCollector results = TopScoreDocCollector.Create(1000, true);
            searcher.Search(query, results);
            ScoreDoc[] hits = results.TopDocs().ScoreDocs;

            IList<ResultItem> resultList = new List<ResultItem>();

            for (int i = 0; i < hits.Length; i++)
            {
                int docId = hits[i].Doc;
                float score = hits[i].Score;

                Document doc = searcher.Doc(docId);
                string path = doc.Get("path");
                ResultItem item = new ResultItem();
                item.Path = rootFolder + "\\" + path;
                item.Score = score.ToString();
                resultList.Add(item);
            }

            return resultList;
        }

    }
}
