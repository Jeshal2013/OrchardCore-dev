using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace RAQModule
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }
        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition("RAQModulePart", cfg => cfg
             .Attachable()
               .WithDescription("Container field for Itinerary name")
               .WithField("ImageAltText",
                    fieldBuilder => fieldBuilder
                        .OfType("TextField")
                        .WithDisplayName("Itinerary Name"))
           );
            _contentDefinitionManager.AlterTypeDefinition("RAQModule", type => type
                .WithPart("RAQModule")
                .Stereotype("Widget"));

            return 2;
        }
    }
}
