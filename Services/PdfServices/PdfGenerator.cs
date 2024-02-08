using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text;

namespace FinanceApp.Helpers
{
    public class PdfGenerator
    {
        public static byte[] GeneratePdfFromHtml(string htmlContent)
        {
            try
            {
                string fileName = $"example_{DateTime.Now:yyyyMMddHH}.pdf";
                StringReader sr = new StringReader(htmlContent); // Corrected: use the provided htmlContent parameter
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();

                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    byte[] bytes = memoryStream.ToArray();
                    SavePdfToFile(bytes, fileName);
                    return bytes; // Corrected: return the byte array
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating PDF: {ex.Message}");
                // Handle the exception or log it appropriately.
                return null;
            }
        }
        private static void SavePdfToFile(byte[] pdfBytes, string fileName)
        {
            // Set your desired directory
            string directory = "wwwroot";

            // Combine the directory and fileName to get the full path
            string filePath = Path.Combine(directory, fileName);

            File.WriteAllBytes(filePath, pdfBytes);
        }
    }
}

