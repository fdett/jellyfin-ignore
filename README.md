# Jellyfin Ignore Plugin
This Jellyfin plugin allows you to specify filepath patterns to ignore when performing a library scan. It can for example ignore specific file extensions (like .m3u). The patterns can be specified on the plugin configuration page.

## Setup for development
Follow instructions in jellyfin plugin template repository
https://github.com/jellyfin/jellyfin-plugin-template


## Install plugin
Add repository
```
https://raw.githubusercontent.com/fdett/jellyfin-ignore/master/manifest.json
```


## Publish a new version
Install GNU grep (used in build script with ggrep)
```
brew install grep
```

Install jprm
https://github.com/oddstr13/jellyfin-plugin-repository-manager
```
pip install --user jprm
```

Run the build script (after allowing for execution: chmod +x build_plugin.sh)
```
./build_plugin.ch
```

Commit and push changes




