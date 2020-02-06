using System.ComponentModel.DataAnnotations;
using OrchardCore.ContentManagement;

namespace OrchardCore.RAQModule.ViewModels
{
    public class RAQModulePartEditViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string IternaryName { get; set; }
        [Required]
        public string Price { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        [Required]
        public string ButtonTitle { get; set; } = "Request Quote";
        public ContentItem contentitem;
    }
}
