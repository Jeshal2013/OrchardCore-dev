using System.IO;
using System.Linq;
using System.Net;
using System.Web;

using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.DisplayManagement;
using OrchardCore.Email;
using OrchardCore.Workflows.Http.Activities;
using System.Net.Http;

namespace OrchardCore.RAQModule.Controllers
{
    internal static class ControllerExtensions
    {
        internal static async Task<bool> SendEmailAsync(this Controller controller, string email, string useremail, string subject, IShape model,string CC="", string BCC = "" )
        {
            var smtpService = controller.ControllerContext.HttpContext.RequestServices.GetRequiredService<ISmtpService>();
            var displayHelper = controller.ControllerContext.HttpContext.RequestServices.GetRequiredService<IDisplayHelper>();
            var htmlEncoder = controller.ControllerContext.HttpContext.RequestServices.GetRequiredService<HtmlEncoder>();
            var body = string.Empty;

            using (var sw = new StringWriter())
            {
                var htmlContent = await displayHelper.ShapeExecuteAsync(model);
                htmlContent.WriteTo(sw, htmlEncoder);
                body = sw.ToString();
            }

            var message = new MailMessage()
            {
                To = email,
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                Cc = CC,
                Bcc = BCC,
                ReplyTo = useremail
            };

            var result = await smtpService.SendAsync(message);

            return result.Succeeded;
        }

       
    }

    public static class HttpContextExtensions
    {
        ///// <summary>
        ///// Get remote ip address, optionally allowing for x-forwarded-for header check
        ///// </summary>
        ///// <param name="context">Http context</param>
        ///// <param name="allowForwarded">Whether to allow x-forwarded-for header check</param>
        ///// <returns>IPAddress</returns>
        //public static IPAddress GetRemoteIPAddress(this Microsoft.AspNetCore.Http.HttpContext context, bool allowForwarded = true)
        //{
        //    if (allowForwarded)
        //    {
        //        string header = (context.Request.Headers["CF-Connecting-IP"].FirstOrDefault() ?? context.Request.Headers["X-Forwarded-For"].FirstOrDefault());
        //        if (IPAddress.TryParse(header, out IPAddress ip))
        //        {
        //            return ip;
        //        }
        //    }
        //    return context.Connection.RemoteIpAddress;
        //}

        //public static string GetIpAddress(this HttpRequestMessage request)
        //{
        //    //if (request.Headers["CF-CONNECTING-IP"] != null)
        //    //    return request.Headers["CF-CONNECTING-IP"];

        //    //var ipAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //    //if (!string.IsNullOrEmpty(ipAddress))
        //    //{
        //    //    var addresses = ipAddress.Split(',');
        //    //    if (addresses.Length != 0)
        //    //        return addresses[0];
        //    //}

        //    //return request.UserHostAddress;
        //}
    }
    //public static class RequestExtensions
    //{
    //    public static string GetIpAddress(this HttpRequestBase request)
    //    {
    //        if (request.Headers["CF-CONNECTING-IP"] != null)
    //            return request.Headers["CF-CONNECTING-IP"];

    //        var ipAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

    //        if (!string.IsNullOrEmpty(ipAddress))
    //        {
    //            var addresses = ipAddress.Split(',');
    //            if (addresses.Length != 0)
    //                return addresses[0];
    //        }

    //        return request.UserHostAddress;
    //    }
    //}
}
