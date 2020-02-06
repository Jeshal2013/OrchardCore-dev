using System;
using System.Collections.Generic;
using System.Text;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Users;

namespace OrchardCore.RAQModule.ViewModels
{
   public class CommonJsonresponse
    {
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public int status { get; set; } = 0;
    }
}
