using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.Ignore.Configuration;

/// <summary>
/// Plugin configuration.
/// </summary>
public class PluginConfiguration : BasePluginConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginConfiguration"/> class.
    /// </summary>
    public PluginConfiguration()
    {
        // set default options here
        IgnoreString = string.Empty;
    }

    /// <summary>
    /// Gets or sets a value of the patterns we want to ignore.
    /// </summary>
    public string IgnoreString { get; set; }
}
