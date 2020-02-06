using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.RAQModule.ViewModels;
using OrchardCore.Users.Models;

namespace OrchardCore.RAQModule.Controllers
{
    public class RAQAdminController : Controller
    {

        public RAQAdminController(
            ILogger<RAQAdminController> logger
            )
        {
            Logger = logger;
        }
        public ILogger Logger { get; set; }
        [HttpGet]
        [Route("RAQAdmin/BindRequestModal")]
        public IActionResult BindRequestModal(string emailAddress = "", string productPrice = "", string iternaryName = "", string Cc= "", string Bcc = "")
        {
            var objmodel = new RaqSendMessageModel();
            try
            {
                objmodel.EmailAddress = emailAddress;
                objmodel.Price = productPrice;
                objmodel.IternaryName = iternaryName;
                objmodel.Bcc = Bcc;
                objmodel.Cc = Cc;
                objmodel.PageURL = Request.Headers["referer"];
            }
            catch (Exception ex)
            {
                Logger.LogError("RequestModalError", ex);
            }
            return PartialView("/Areas/OrchardCore.RAQModule/Views/Shared/_RequestModalWindow.cshtml", objmodel);
        }

    }
}
