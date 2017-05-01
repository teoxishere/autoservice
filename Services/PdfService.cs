using AutoService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Services
{
    public class PdfService
    {
        public static void GeneratePdf(Cart cart)
        {
            if (!Directory.Exists("./facturi"))
            {
                Directory.CreateDirectory("./facturi");
            }
            // pedefe
            var html = GetHtmlFromTemplateAndReplace(cart);
            var pdfBytes = HtmlToByteArray(html);
            File.WriteAllBytes("./facturi/" + cart.Id + ".pdf", pdfBytes);
        }

        private static string GetHtmlFromTemplateAndReplace(Cart cart)
        {
            var templatePath = "./invoice_template.html";
            var templateAsString = File.ReadAllText(templatePath);
            // Replace what we need
            templateAsString = templateAsString
                .Replace("{{cart_id}}", cart.Id + "")
                .Replace("{{cart_username}}", cart.Username)
                .Replace("{{cart_date}}", cart.CreatedDate.ToShortDateString());

            var listOfItems = "";
            double total = 0;
            foreach (var detail in cart.CartDetails)
            {
                total += detail.Quantity * detail.PriceOfPart;
                listOfItems += "<tr><td>"+ detail.Part.Name +"</td><td>"+detail.Quantity+"</td><td>"+detail.PriceOfPart+" RON</td></tr>";
            }
            templateAsString = templateAsString.Replace("{{cart_items}}", listOfItems)
                .Replace("{{cart_total}}", total + " RON");

            return templateAsString;
        }

        private static byte[] HtmlToByteArray(string html)
        {
            byte[] res = null;
            using (var ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
    }
}
