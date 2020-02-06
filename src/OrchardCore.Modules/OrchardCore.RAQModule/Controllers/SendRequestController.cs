using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using OrchardCore.Email;
using OrchardCore.RAQModule.ViewModels;
using OrchardCore.Users.Services;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrchardCore.RAQModule.Controllers
{
    public class SendRequestController : Controller
    {
        // GET: /<controller>/
        private readonly ISmtpService _smtpService;
        private readonly IStringLocalizer<SendRequestController> S;
        private readonly IUserService _userService;
        private IHttpContextAccessor _accessor;

        public SendRequestController(
          ISmtpService smtpService, IStringLocalizer<SendRequestController> stringLocalizer, IUserService userService, IHttpContextAccessor accessor)
        {
            S = stringLocalizer;
            _smtpService = smtpService;
            _userService = userService;
            _accessor = accessor;
        }
        
        [HttpPost,HttpGet]
        public async Task<IActionResult> Index(RaqSendMessageModel model)
        {
            var isSent = false;
            var jsonResponse = new CommonJsonresponse();

            try
            {
                if (ModelState.IsValid)
                {
                    // send email with callback link
                    //var ipAddress = HttpContextExtensions.GetRemoteIPAddress(Request.HttpContext);
                    isSent = await this.SendEmailAsync(model.EmailAddress,model.Email, S["Request Quote"], model,model.Cc,model.Bcc);
                }
                if (isSent)
                {
                    jsonResponse.status = 1;
                    jsonResponse.Message = "Email successfully sent";
                }
            }
            catch (Exception ex)
            {
                jsonResponse.Message = ex.Message;
            }
            return Json(jsonResponse);
        }
        
    }
   
}
