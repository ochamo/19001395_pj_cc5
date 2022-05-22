using System.IO;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using iText.Kernel.Pdf;
using iText.Html2pdf;
using iText.Kernel.Geom;

namespace BillingReport
{
    public class BillingService : IBillingService
    {
        public void SendBill(BillingArgs billingArgs)
        {
            var pdfAttachment = generateBill(billingArgs);
            using (var memoryStream = new MemoryStream(pdfAttachment))
            {
                MailMessage billingMail = new MailMessage("ventacelularesprojcc5@gmail.com", billingArgs.ClientEmail);
                billingMail.Subject = "Gracias por su compra";
                billingMail.Body = "Adjuntamos la factura de su compra";
                billingMail.Attachments.Add(new Attachment(memoryStream, $"{System.Guid.NewGuid()}.pdf"));
                billingMail.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = "ventacelularesprojcc5@gmail.com";
                networkCredential.Password = "pjzjwpkjgzgqghjn";
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.Send(billingMail);
            }
        }

        public byte[] generateBill(BillingArgs args)
        {
            var stringBuilder = new StringBuilder();
            var now = DateTime.UtcNow;
            var centralAmericaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");
            var today = TimeZoneInfo.ConvertTimeFromUtc(now, centralAmericaTimeZone);
            stringBuilder.AppendLine("<!DOCTYPE html>");
            stringBuilder.AppendLine("<html>");
            stringBuilder.AppendLine("<head>");
            stringBuilder.AppendLine("<style>");
            stringBuilder.AppendLine("table, th, td { border: 1px solid black; border-collapse: collapse;}");
            stringBuilder.AppendLine("</style>");
            stringBuilder.AppendLine("</head>");
            stringBuilder.AppendLine("<body>");
            stringBuilder.AppendLine("<table width='100%' cellspacing='0' cellpadding='2'>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<td align='center' style='background-color: #18B5F0' colspan='3'><h2>Factura Electrónica</h2></td>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine($"<td><b>Factura no:</b> {args.BillingId}</td>");
            stringBuilder.AppendLine($"<td><b>Fecha: {today.ToString("dd/MM/yyyy HH:mm")}</b></td>");
            stringBuilder.AppendLine("<td><b>Empresa: Venta Celulares</b></td>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine($"<td><b>Nombre Cliente: {args.ClientBillingName}</b></td>");
            stringBuilder.AppendLine($"<td colspan='3'><b>NIT: {args.ClientBillingId}</b></td>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine($"<td colspan='4'><b>Dirección Entrega: {args.DeliveryAddress}</b></td>");
            stringBuilder.AppendLine("<table width='100%' cellspacing='0' cellpadding='2'>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<td align='center' style='background-color: #18B5F0' colspan='3'><h2>Detalle compra</h2></td>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("</table>");
            stringBuilder.AppendLine("<table id='table' width='100%' border='1'>");
            stringBuilder.AppendLine("<thead>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<th><b>Producto</b></th>");
            stringBuilder.AppendLine("<th><b>Cantidad</b></th>");
            stringBuilder.AppendLine("<th><b>Precio U.</b></th>");
            stringBuilder.AppendLine("<th><b>Total</b></th>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("</thead>");
            stringBuilder.AppendLine("<tbody>");
            foreach(var item in args.BillingItemModels)
            {
                stringBuilder.AppendLine("<tr>");
                stringBuilder.AppendLine($"<td>{item.BillingItemName}</td>");
                stringBuilder.AppendLine($"<td  align='center'>{item.Quantity}</td>");
                stringBuilder.AppendLine($"<td  align='center'>{item.Price}</td>");
                var total = item.Quantity * item.Price;
                stringBuilder.AppendLine($"<td  align='center'>{decimal.Round(total, 2)}</td>");
                stringBuilder.AppendLine("</tr>");
            }
            stringBuilder.AppendLine("</tbody>");
            stringBuilder.AppendLine("<tfoot>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<td colspan='3'><b>Total Compra:</b></td>");
            stringBuilder.AppendLine($"<td  colspan='1' align='center'><b>Q {args.TotalPurchase}</b></td>");
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("</tfoot>");
            stringBuilder.AppendLine("</table>");
            stringBuilder.AppendLine("</body>");
            stringBuilder.AppendLine("</html>");
            var html = stringBuilder.ToString();

            using (var memoryStream = new MemoryStream())
            {
                using (PdfWriter pdfWriter = new PdfWriter(memoryStream))
                {
                    pdfWriter.SetCloseStream(true);
                    using (var document = new PdfDocument(pdfWriter))
                    {
                        var converterProps = new ConverterProperties();
                        document.SetDefaultPageSize(pageSize: PageSize.LETTER);
                        document.SetCloseWriter(true);
                        document.SetCloseReader(true);
                        document.SetFlushUnusedObjects(true);
                        HtmlConverter.ConvertToPdf(html, document, converterProps);
                        document.Close();
                    }
                }
                return memoryStream.ToArray();
            }
        }
    }
    
}
