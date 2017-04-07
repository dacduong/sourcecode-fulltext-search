using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using NPOI.HSSF.Extractor;
using NPOI.HSSF.UserModel;
using NPOI.HWPF;
using NPOI.HWPF.Extractor;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Presentation;

namespace FTSearch
{
    public class ReaderFactory
    {
        public static string GetText(string path)
        {
                string fileExtension = Path.GetExtension(path).ToLower();
                if (fileExtension.Contains("doc"))
                    return GetWordContent(path);
                if (fileExtension.Contains("xls"))
                    return GetExcelContent(path);
                if (fileExtension.Contains("pdf"))
                    return GetPDFContent(path);
                if (fileExtension.Contains("ppt"))
                    return GetPPTContent(path);
                if (fileExtension.Contains("htm"))
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(path);
                        return doc.InnerText;
                    }
                    catch { }
                }
            return File.ReadAllText(path);
        }

        private static string GetPPTContent(string path)
        {
            string fileExtension = Path.GetExtension(path).ToLower();
            if (fileExtension.Contains("pptx"))
            {
                StringBuilder sb = new StringBuilder();
                PresentationDocument pptx = PresentationDocument.Open(path, false);
                foreach (SlidePart slide in pptx.PresentationPart.SlideParts)
                    sb.Append(slide.Slide.InnerText).Append(Environment.NewLine);
                return sb.ToString();
            }
            else
            {
                Microsoft.Office.Interop.PowerPoint.Application PowerPoint_App = new Microsoft.Office.Interop.PowerPoint.Application();
                Microsoft.Office.Interop.PowerPoint.Presentations multi_presentations = PowerPoint_App.Presentations;
                Microsoft.Office.Interop.PowerPoint.Presentation presentation = multi_presentations.Open(path, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoFalse);
                string presentation_text = "";
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    foreach (var item in presentation.Slides[i + 1].Shapes)
                    {
                        var shape = (Microsoft.Office.Interop.PowerPoint.Shape)item;
                        if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                        {
                            if (shape.TextFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
                            {
                                var textRange = shape.TextFrame.TextRange;
                                var text = textRange.Text;
                                presentation_text += text + " ";
                            }
                        }
                    }
                }
                PowerPoint_App.Quit();
                return presentation_text;
            }
        }

        private static string GetPDFContent(string path)
        {
            StringBuilder sb = new StringBuilder();
            PdfReader pdfReader = new PdfReader(path);
            for (int i = 1; i < pdfReader.NumberOfPages; i++)
                sb.Append(PdfTextExtractor.GetTextFromPage(pdfReader, i)).Append(Environment.NewLine);
            return sb.ToString();
        }

        private static string GetExcelContent(string path)
        {
            string fileExtension = Path.GetExtension(path).ToLower();
            if (fileExtension.Contains("xlsx"))
            {
                StringBuilder sb = new StringBuilder();
                SpreadsheetDocument xlsx = SpreadsheetDocument.Open(path, false);
                foreach (OpenXmlElement item in xlsx.WorkbookPart.SharedStringTablePart.SharedStringTable.Elements<OpenXmlElement>())
                    sb.Append(item.InnerText).Append(" ");
                return sb.ToString();
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                HSSFWorkbook wb = new HSSFWorkbook(fs);
                ExcelExtractor extractor = new ExcelExtractor(wb);
                fs.Close();
                return extractor.Text;
            }
        }

        private static string GetWordContent(string path)
        {
            string fileExtension = Path.GetExtension(path).ToLower();
            if (fileExtension.Contains("docx"))
            {
                WordprocessingDocument docx = WordprocessingDocument.Open(path, false);
                return docx.MainDocumentPart.Document.InnerText;
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                HWPFDocument doc = new HWPFDocument(fs);
                WordExtractor extractor = new WordExtractor(doc);
                fs.Close();
                return extractor.Text;
            }
        }
    }
}
