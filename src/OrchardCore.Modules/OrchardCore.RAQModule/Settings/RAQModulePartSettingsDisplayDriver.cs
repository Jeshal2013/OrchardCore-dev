using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Liquid;
using OrchardCore.RAQModule.Models;
using OrchardCore.RAQModule.ViewModels;

namespace OrchardCore.RAQModule.Settings
{
    public class RAQModulePartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver
    {
        private readonly ILiquidTemplateManager _templateManager;
        private readonly IStringLocalizer<RAQModulePartSettingsDisplayDriver> S;

        public RAQModulePartSettingsDisplayDriver(ILiquidTemplateManager templateManager, IStringLocalizer<RAQModulePartSettingsDisplayDriver> localizer)
        {
            _templateManager = templateManager;
            S = localizer;
        }

        public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, IUpdateModel updater)
        {
            if (!String.Equals(nameof(RAQModulePart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            return Initialize<RAQModulePartSettingsViewModel>("RAQModulePartSettings_Edit", model =>
            {
                var settings = contentTypePartDefinition.GetSettings<RAQModulePartSettings>();

                model.Options = settings.Options;
                model.Pattern = settings.Pattern;
                model.RAQModulePartSettings = settings;
            }).Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
        {
            if (!String.Equals(nameof(RAQModulePart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            var model = new RAQModulePartSettingsViewModel();

            await context.Updater.TryUpdateModelAsync(model, Prefix,
                m => m.Pattern,
                m => m.Options);

            if (!string.IsNullOrEmpty(model.Pattern) && !_templateManager.Validate(model.Pattern, out var errors))
            {
                context.Updater.ModelState.AddModelError(nameof(model.Pattern), S["Pattern doesn't contain a valid Liquid expression. Details: {0}", string.Join(" ", errors)]);
            }
            else
            {
                context.Builder.WithSettings(new RAQModulePartSettings { Pattern = model.Pattern, Options = model.Options });
            }

            return Edit(contentTypePartDefinition, context.Updater);
        }
    }
}
