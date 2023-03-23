# Jellyfin Ignore Plugin
This Jellyfin plugin allows you to specify filepath patterns to ignore when performing a library scan. It can for example ignore specific file extensions (like .m3u). The patterns can be specified on the plugin configuration page.

## Install plugin
Go the the Jellyfin plugin page (in the admin section).
Add a new repository (in the repository section).
```
https://raw.githubusercontent.com/fdett/jellyfin-ignore/master/manifest.json
```
Select "Jellyfin Ignore" and install (in the Catalog section).
Go to the plugin configuration page and add patterns to ignore on library scans.

## Setup for development
Follow instructions in jellyfin plugin template [repository](https://github.com/jellyfin/jellyfin-plugin-template)

## Publish a new version
Install GNU grep (used in build script with ggrep)
```
brew install grep
```

Install [jprm](https://github.com/oddstr13/jellyfin-plugin-repository-manager)
```
pip install --user jprm
```

Run the build script (after allowing for execution: chmod +x build_plugin.sh)
```
./build_plugin.sh
```
Manually update the sourceUrl in the manifest to ensure we can download the zip file in its raw format (this should be updated eventually).

Commit and push changes.




