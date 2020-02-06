using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.RAQModule.Models;

namespace OrchardCore.RAQModule.ViewModels
{
    public class RAQModulePartSettingsViewModel
    {
        public RAQModuleOptions Options { get; set; }
        public string Pattern { get; set; }

        [BindNever]
        public RAQModulePartSettings RAQModulePartSettings { get; set; }
    }
}
