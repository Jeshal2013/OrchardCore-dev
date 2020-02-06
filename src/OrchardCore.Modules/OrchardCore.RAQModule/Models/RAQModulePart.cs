using OrchardCore.ContentManagement;

namespace OrchardCore.RAQModule.Models
{
    public class RAQModulePart : ContentPart
    {
        public string EmailAddress { get; set; }
        public string IternaryName { get; set; }
        public string Price { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string ButtonTitle { get; set; } = "Request Quote";
    }

    public class RAQRequestPart : ContentPart
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IternaryName { get; set; }
        public string Price { get; set; }
        public string PageURL { get; set; }

    }
}
