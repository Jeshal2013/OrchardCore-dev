using System;
using System.Collections.Generic;
using System.Text;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Users;

namespace OrchardCore.RAQModule.ViewModels
{
   public class RaqSendMessageModel : ShapeViewModel
    {
        public RaqSendMessageModel()
        {
            Metadata.Type = "TemplateRequestQuote";
        }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Email { get; set; }
        public string IternaryName { get; set; }
        public string Price { get; set; }
        public string PageURL { get; set; }
        public string IPAddress { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
    }
  
}
