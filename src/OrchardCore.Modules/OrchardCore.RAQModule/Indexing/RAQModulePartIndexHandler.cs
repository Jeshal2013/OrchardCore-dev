using System.Threading.Tasks;
using OrchardCore.Indexing;
using OrchardCore.RAQModule.Models;

namespace OrchardCore.RAQModule.Indexing
{
    public class RAQModulePartIndexHandler : ContentPartIndexHandler<RAQModulePart>
    {
        public override Task BuildIndexAsync(RAQModulePart part, BuildPartIndexContext context)
        {
            var options = context.Settings.ToOptions() 
                | DocumentIndexOptions.Analyze
                ;

            foreach (var key in context.Keys)
            {
                context.DocumentIndex.Set(key, part.ButtonTitle, options);
            }

            return Task.CompletedTask;
        }
    }
}
