# Jellyfin Ignore Plugin
This [Jellyfin](https://github.com/jellyfin) plugin allows you to specify filepath patterns to ignore when performing a library scan. It can for example ignore specific file extensions (like .m3u). The patterns can be specified on the plugin configuration page.

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

1) Install latest dotnet version
2) In the same directory, pull this plugin, jellyfin, and jellyfin-web
3) Copy jellyfin-web dist files to jellyfin bin
4) Run jellyfin-web project to test it works
5) Run this plugin project

If you need to create a new account, force the wizard: http://localhost:8096/web/index.html#!/wizardstart.html

## Publish a new version

### Setup
Install GNU grep (used in build script with ggrep)
```
brew install grep
```

Install [jprm](https://github.com/oddstr13/jellyfin-plugin-repository-manager)
```
pip install --user jprm
```

### Process
Update the version numbers (build.yaml, Directory.Build.props).
Run the build script (after allowing for execution: chmod +x build_plugin.sh)
```
./build_plugin.sh
```
Manually update the sourceUrl in the manifest to ensure we can download the zip file in its raw format (this should be updated eventually).

Commit and push changes.

Create a release on github and attach/upload the zip file.

### Good to know

* The image/logo is not included in the plugin archive but as a link in the meta.json and in the manifest.json files. The image is hosted in this repository.
* Make sure the build instructions (.vscode files) are still valid





