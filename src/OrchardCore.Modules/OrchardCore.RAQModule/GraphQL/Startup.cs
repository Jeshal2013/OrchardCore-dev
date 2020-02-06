using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Apis;
using OrchardCore.RAQModule.Models;
using OrchardCore.Modules;

namespace OrchardCore.RAQModule.GraphQL
{
    [RequireFeatures("OrchardCore.Apis.GraphQL")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddObjectGraphType<RAQModulePart, RAQModulePartQueryObjectType>();
            //services.AddObjectGraphType<FormElementPart, FormElementPartQueryObjectType>();
            //services.AddObjectGraphType<FormInputElementPart, FormInputElementPartQueryObjectType>();
            //services.AddObjectGraphType<ButtonPart, ButtonPartQueryObjectType>();
            //services.AddObjectGraphType<InputPart, InputPartQueryObjectType>();

            // Broken
            //services.AddGraphQLQueryType<ValidationSummaryPart, ValidationSummaryPartQueryObjectType>();
        }
    }
}