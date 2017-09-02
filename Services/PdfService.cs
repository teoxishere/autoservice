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
        
        public static void GeneratePdf(Cart cart,ClientOfPark client)
        {
            
            if (!Directory.Exists("./facturi"))
            {
                Directory.CreateDirectory("./facturi");
            }
            // pedefe
            var html = GetHtmlFromTemplateAndReplace(cart,client);
           
            var pdfBytes = HtmlToByteArray(html);
            File.WriteAllBytes("./facturi/" + cart.Id +" "+client.Name+" "+DateTime.Now.ToShortDateString()+ ".pdf", pdfBytes);
        }

        private static string GetHtmlFromTemplateAndReplace(Cart cart,ClientOfPark client)
        {
            var templatePath = "./invoice_template.html";
            var templateAsString = File.ReadAllText(templatePath);
            // Replace what we need
            templateAsString = templateAsString
                .Replace("{{cart_id}}", cart.Id + "")
                .Replace("{{cart_username}}", cart.Username)
                .Replace("{{cart_date}}", cart.CreatedDate.ToShortDateString())
                .Replace("{{client_name}}", client.Name)
                .Replace("{{client_address}}", client.Address)
                .Replace("{{client_regno}}", client.RegNo)
                .Replace("{{client_phone}}", client.PhoneNumber);

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
