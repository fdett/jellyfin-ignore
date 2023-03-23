using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DotNet.Globbing;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Resolvers;
using MediaBrowser.Model.IO;

namespace Jellyfin.Plugin.Ignore;

/// <summary>
/// Ignore rules for the Jellyfin Ignore plugin.
/// </summary>
public class IgnoreRule : IResolverIgnoreRule
{
    private static readonly GlobOptions _globOptions = new GlobOptions
    {
        Evaluation =
            {
                CaseInsensitive = true
            }
    };

    private static Glob[]? _globs;

    /// <summary>
    /// Update the patterns to ignore.
    /// </summary>
    public static void UpdateGlobs()
    {
        if (Plugin.Instance == null)
        {
            return;
        }

        var patternsString = Plugin.Instance.Configuration.IgnoreString;
        var patterns = patternsString.Split("\n").Select(p => Regex.Unescape(p).Trim()).Where(p => p.Length > 0);

        _globs = patterns.Select(p => Glob.Parse(p, _globOptions)).ToArray();
    }

    /// <summary>
    /// The logic for whether we should ignore a path.
    /// </summary>
    /// <param name="fileInfo">The file we are looking at to decide if we should ignore it.</param>
    /// <param name="parent">The BaseItem.</param>
    /// <returns>Whether the file should be ignored.</returns>
    public bool ShouldIgnore(FileSystemMetadata fileInfo, BaseItem parent)
    {
        if (_globs == null)
        {
            UpdateGlobs();
        }

        if (_globs == null)
        {
            return false;
        }

        var path = Path.Join(parent.Path, fileInfo.Name);

        int len = _globs.Length;
        for (int i = 0; i < len; i++)
        {
            if (_globs[i].IsMatch(path))
            {
                return true;
            }
        }

        return false;
    }
}
