using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Modules.Manifest;
//"OrchardCore.ContentFields", "OrchardCore.Widgets", 
//[assembly: Module(
//    Name = "RAQModule",
//    Author = "Dwayne Pearson",
//    Website = "http://www.amawaterways.com",
//    Version = "1.0.0",
//    Description = "Custom module for RAQ form model",
//    Dependencies = new[] { "OrchardCore.Contents" },
//    Category = "Content Management"
//)]


[assembly: Module(
    Name = "Request Quote",
    Author = "The Satva Team",
    Website = "https://Satvasolutions.com",
    Version = "1.0.0"
)]

[assembly: Feature(
    Id = "OrchardCore.RAQModule",
    Name = "Request Quote",
    Description = "Provides a part allowing content items to add Rquest Quote Button as Widgets in theme zones.",
    Dependencies = new[] { "OrchardCore.ContentTypes", "OrchardCore.Widgets", "OrchardCore.Flows" },
    Category = "Content"
)]

//[assembly: Module(
//    Name = "Orchard RAQModule",
//    Author = "The satva Team",
//    Website = "https://orchardproject.net",
//    Version = "2.0.0",
//    Description = "OrchardCore.Contents",
//    Category = "Content Management"
//)]

//[assembly: Feature(
//    Id = "OrchardCore.RAQModule",
//    Name = "RAQModule",
//    Description = "Custom module for RAQ form model",
//    Dependencies = new[] { "OrchardCore.Contents" },
//    Category = "Content Management"
//)]

