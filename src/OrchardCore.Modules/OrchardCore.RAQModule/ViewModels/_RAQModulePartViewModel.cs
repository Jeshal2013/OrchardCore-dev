using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using OrchardCore.RAQModule.Models;

namespace OrchardCore.RAQModule.ViewModels
{
    public class RAQModulePartViewModel { 
        public string EmailAddress { get; set; }
        public string IternaryName { get; set; }
        public string Price { get; set; }
        public string ButtonTitle { get; set; } = "Request Quote";

        [BindNever]
        public RAQModulePart RAQModulePart { get; set; }

        [BindNever]
        public RAQModulePartSettings Settings { get; set; }
    }
}
