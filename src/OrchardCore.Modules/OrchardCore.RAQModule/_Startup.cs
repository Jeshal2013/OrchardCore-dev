using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using OrchardCore.Indexing;
using OrchardCore.Modules;
using OrchardCore.RAQModule;
namespace OrchardCore.RAQModule
{
    public class Startup : StartupBase
    {
        static Startup()
        {
            //TemplateContext.GlobalMemberAccessStrategy.Register<RAQModulePartViewModel>();
            //TemplateContext.GlobalMemberAccessStrategy.Register<RAQModulePartSettingsViewModel>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IContentPartDisplayDriver, RAQModulePartDisplay>();
            //services.AddContentPart<RAQModulePart>();
            //services.AddScoped<IContentPartIndexHandler, RAQModulePartIndexHandler>();
            //services.AddScoped<IContentPartHandler, RAQModulePartHandler>();
            //services.AddScoped<IContentTypePartDefinitionDisplayDriver, RAQModulePartSettingsDisplayDriver>();
            //services.AddScoped<IDataMigration, Migrations>();
        }

    }
}
