using System.ComponentModel;

namespace OrchardCore.RAQModule.Models
{
    public enum RAQModuleOptions
    {
        Editable,
        GeneratedDisabled,
        GeneratedHidden,
    }
    public class RAQModulePartSettings
    {
        /// <summary>
        /// Gets or sets whether a user can define a custom Button Title
        /// </summary>
        [DefaultValue(RAQModuleOptions.Editable)]
        public RAQModuleOptions Options { get; set; } = RAQModuleOptions.Editable;

        /// <summary>
        /// The pattern used to build the Button.
        /// </summary>
        public string Pattern { get; set; }
    }
}