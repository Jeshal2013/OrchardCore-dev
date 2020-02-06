using System;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Records;
using OrchardCore.Data.Migration;
using Newtonsoft.Json.Linq;
using YesSql;
using Microsoft.Extensions.Logging;

namespace OrchardCore.RAQModule
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;
        private readonly ISession _session;
        private readonly ILogger<Migrations> _logger;

        public Migrations(
            IContentDefinitionManager contentDefinitionManager,
            ISession session,
            ILogger<Migrations> logger)
        {
            _contentDefinitionManager = contentDefinitionManager;
            _session = session;
            _logger = logger;
        }

        public int Create()
        {
            // Request Quote
            _contentDefinitionManager.AlterPartDefinition("RAQModulePart", part => part
                .Attachable()
                .WithDescription("Provides a Button to request Quote for your content item.")
               );
             //.WithField("ImageAltText", fieldBuilder => fieldBuilder.OfType("TextField").WithDisplayName("Itinerary Name"))
             //   .WithField("ButtonTitle", fieldBuilder1 => fieldBuilder1.OfType("TextField").WithDisplayName("Request Quote Button Name"))
             //   .WithField("Email Address", fieldBuilder2 => fieldBuilder2.OfType("TextField").WithDisplayName("Email Address"))
             //   .WithField("Price", fieldBuilder2 => fieldBuilder2.OfType("TextField").WithDisplayName("Price"))

            _contentDefinitionManager.AlterTypeDefinition("RAQModule", type => type
                .WithPart("FormInputElementPart")
                .WithPart("FormElementPart")
                .WithPart("RAQModulePart")
                .Stereotype("Widget"));


            return 2;
        }
        
    }
}