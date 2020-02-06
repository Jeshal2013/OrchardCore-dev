using System;
using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using OrchardCore.Indexing;
using OrchardCore.Modules;
using OrchardCore.RAQModule.Controllers;
using OrchardCore.RAQModule.Drivers;
using OrchardCore.RAQModule.Handlers;
using OrchardCore.RAQModule.Indexing;
using OrchardCore.RAQModule.Models;
using OrchardCore.RAQModule.Settings;
using OrchardCore.RAQModule.ViewModels;

namespace OrchardCore.RAQModule
{
    public class Startup : StartupBase
    {
       
        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<RAQModulePart>();
            TemplateContext.GlobalMemberAccessStrategy.Register<RAQModulePartEditViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<RAQModulePartSettingsViewModel>();
        }
        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {

            routes.MapAreaControllerRoute(
         name: "RAQAdmin",
         areaName: "OrchardCore.RAQModule",
         pattern: "{controller}/{action}/{id}",
         defaults: new { controller = "RAQAdmin", action = "BindRequestModal" }
     );
            routes.MapAreaControllerRoute(
         name: "SendRequest",
         areaName: "OrchardCore.RAQModule",
         pattern: "{controller}/{action}/{id}",
         defaults: new { controller = "SendRequest", action = "Index" }
     );

        }


        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContentPartDisplayDriver, RAQModulePartDisplay>();
            services.AddScoped<IContentPartIndexHandler, RAQModulePartIndexHandler>();
            services.AddScoped<IContentPartHandler, RAQModulePartHandler>();
            services.AddScoped<IContentTypePartDefinitionDisplayDriver, RAQModulePartSettingsDisplayDriver>();
            services.AddScoped<IDataMigration, Migrations>();

            services
                .AddContentPart<RAQModulePart>();

            services.AddScoped<IDataMigration, Migrations>();
            services.AddMvc();
        }

    }
}
