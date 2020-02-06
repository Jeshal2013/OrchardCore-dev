using System;
using System.Linq;
using System.Threading.Tasks;
using Fluid;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Liquid;
using OrchardCore.RAQModule.Models;
using OrchardCore.RAQModule.ViewModels;

namespace OrchardCore.RAQModule.Handlers
{
    public class RAQModulePartHandler : ContentPartHandler<RAQModulePart>
    {
        private readonly ILiquidTemplateManager _liquidTemplateManager;
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public RAQModulePartHandler(
            ILiquidTemplateManager liquidTemplateManager,
            IContentDefinitionManager contentDefinitionManager)
        {
            _liquidTemplateManager = liquidTemplateManager;
            _contentDefinitionManager = contentDefinitionManager;
        }


        public override async Task UpdatedAsync(UpdateContentContext context, RAQModulePart part)
        {
            var settings = GetSettings(part);
            // Do not compute the title if the user can modify it and the text is already set.
            if (settings.Options == RAQModuleOptions.Editable && !String.IsNullOrWhiteSpace(part.ContentItem.DisplayText))
            {
                return;
            }

            //if (!String.IsNullOrEmpty(settings.Pattern))
            //{
            var model = new RAQModulePartEditViewModel()
            {
                ButtonTitle = part.ButtonTitle,
                EmailAddress = part.EmailAddress,
                Price = part.Price,
                IternaryName = part.IternaryName,
                Cc = part.Cc,
                Bcc = part.Bcc,
                contentitem = part.ContentItem
            };

            var titleSettings = await _liquidTemplateManager.RenderAsync(settings.Pattern, NullEncoder.Default, model,
                scope => scope.SetValue("ContentItem", model.contentitem));

            //    titleSettings = titleSettings.Replace("\r", String.Empty).Replace("\n", String.Empty);

            //    part.ButtonTitle = titleSettings;
            //    part.EmailAddress = titleSettings;
            //    part.ContentItem.DisplayText = titleSettings;
            //    part.Apply();
            //}
        }

        private RAQModulePartSettings GetSettings(RAQModulePart part)
        {
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(part.ContentItem.ContentType);
            var contentTypePartDefinition = contentTypeDefinition.Parts.FirstOrDefault(x => String.Equals(x.PartDefinition.Name, nameof(RAQModulePart)));
            return contentTypePartDefinition.GetSettings<RAQModulePartSettings>();
        }
    }
}
