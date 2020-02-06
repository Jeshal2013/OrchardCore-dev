using GraphQL.Types;
using OrchardCore.RAQModule.Models;

namespace OrchardCore.RAQModule.GraphQL
{
    public class RAQModulePartQueryObjectType : ObjectGraphType<RAQModulePart>
    {
        public RAQModulePartQueryObjectType()
        {
            Name = "RAQModulePart";

            Field(x => x.ButtonTitle, nullable: true);
            Field(x => x.EmailAddress, nullable: true);
        }
    }
}