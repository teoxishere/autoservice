using AutoService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                .Replace("{{client_jno}}", client.J)
                .Replace("{{client_phone}}",client.Phone)
                .Replace("{{client_bankaccount}}", client.Phone)
                .Replace("{{client_bankname}}", client.Phone);

            var listOfItems = "";
            double total = 0;
            var nrCrt = 1;
            var tvaPercentage = double.Parse(ConfigurationManager.AppSettings["tva"]);
            var utMas = ConfigurationManager.AppSettings["utmas"];
            foreach (var detail in cart.CartDetails)
            {
                double p = detail.PriceOfPart * detail.Quantity;
                total += p;
                double x = 100 * p / (100 + tvaPercentage);
                var tva = Math.Round(p - x, 2);
                listOfItems += "<tr class='products-row'><td align='center' class='tg-yw4l'>" + ((nrCrt++).ToString()) + "</td><td class='tg-yw4l'>" + detail.Part.Name + "</td><td class='tg-yw4l'>" + utMas + "</td><td class='tg-yw4l'>" + detail.Quantity+ "</td><td class='tg-yw4l'>" + detail.PriceOfPart+ " RON</td><td class='tg-yw4l'>" + p + " RON</td><td class='tg-yw4l'>" + tva + " RON</td></tr>";
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
