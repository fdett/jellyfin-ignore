using System;
using System.Collections.Generic;
using System.Globalization;
using Jellyfin.Plugin.Ignore.Configuration;
using MediaBrowser.Common.Configuration;

using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.Ignore;

/// <summary>
/// The main plugin.
/// </summary>
public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Plugin"/> class.
    /// </summary>
    /// <param name="applicationPaths">Instance of the <see cref="IApplicationPaths"/> interface.</param>
    /// <param name="xmlSerializer">Instance of the <see cref="IXmlSerializer"/> interface.</param>
    public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
        this.ConfigurationChanged = this.ConfigurationChangedEventHandler;
        IgnoreRule.UpdateGlobs();
    }

    /// <inheritdoc />
    public override string Name => "Jellyfin Ignore";

    /// <inheritdoc />
    public override Guid Id => Guid.Parse("277cd84e-44c3-45a1-8f3c-2537ddac0ccf");

    /// <summary>
    /// Gets the current plugin instance.
    /// </summary>
    public static Plugin? Instance { get; private set; }

    /// <summary>
    /// When the configuration is updated by the user, we also update the ignore patterns.
    /// </summary>
    /// <param name="sender">The object triggering the configuration change.</param>
    /// <param name="c">The configuration object.</param>
    public void ConfigurationChangedEventHandler(object? sender, BasePluginConfiguration c)
    {
        IgnoreRule.UpdateGlobs();
    }

    /// <inheritdoc />
    public IEnumerable<PluginPageInfo> GetPages()
    {
        return new[]
        {
            new PluginPageInfo
            {
                Name = this.Name,
                EmbeddedResourcePath = string.Format(CultureInfo.InvariantCulture, "{0}.Configuration.configPage.html", GetType().Namespace)
            }
        };
    }
}
