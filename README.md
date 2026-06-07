<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Builder

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

Game Frame X Builder is an automated build tool for Unity, providing streamlined build pipeline automation for game projects.

For detailed usage, refer to Unity/Automated Build section in the documentation.

## Quick Start

### System Requirements

- Unity 2019.4 or higher

### Installation

Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:
   ```json
   {
     "scopedRegistries": [
       {
         "name": "GameFrameX",
         "url": "https://gameframex.upm.alianblank.uk",
         "scopes": [
           "com.gameframex"
         ]
       }
     ],
     "dependencies": {
       "com.gameframex.unity.builder": "2.2.0"
     }
   }
   ```

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.builder": "https://github.com/gameframex/com.gameframex.unity.builder.git"
   }
   ```
3. Use **Package Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.builder.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.
## Command Line Parameters

Parameters are passed as Unity command line arguments (e.g. `-flag value`).

### Required

| Parameter | Description |
|-----------|-------------|
| `-executeMethod` | Method to execute (e.g. `GameFrameX.Builder.Editor.Builder.BuildApk`) |
| `-BUILD_NUMBER` | Build number |

### General

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `-logFile` | string | auto-generated | Log file path |
| `-JOB_NAME` | string | | Job name |
| `-BundleId` | string | project setting | Application bundle identifier |
| `-AppVersion` | string | project setting | Application version |
| `-ChannelName` | string | `default` | Channel name |
| `-Language` | string | `default` | Language |

### Asset Build (BuildAsset)

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `-PackageName` | string | `DefaultPackage` | Asset bundle package name |
| `-PackageVersion` | string | timestamp | Package version (auto-generated timestamp if empty) |
| `-BuildPipeline` | enum | `BuiltinBuildPipeline` | Build pipeline: `BuiltinBuildPipeline` / `ScriptableBuildPipeline` / `RawFileBuildPipeline` |
| `-BuildinFileCopyOption` | enum | `ClearAndCopyAll` | Built-in file copy option: `None` / `ClearAndCopyAll` / `ClearAndCopyByTags` / `OnlyCopyNew` |
| `-IsIncrementalBuildPackage` | flag | `false` | Use incremental build |

### Upload & Notification

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `-IsUploadLogFile` | flag | `false` | Upload log file |
| `-IsUploadAsset` | flag | `false` | Upload asset bundle |
| `-IsUploadApk` | flag | `false` | Upload APK/IPA (BuildApk only) |
| `-IsUpdateAssetPackageVersion` | flag | `false` | Update asset package version |
| `-UpdateAssetPackageVersionUrl` | string | | URL for updating asset package version |
| `-UpdateAssetPackageVersionAuthorization` | string | | Authorization for version update |
| `-WeChatBotKey` | string | | WeChat Work bot webhook key |

### Object Storage

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `-ObjectStorageKey` | string | | Object storage access key |
| `-ObjectStorageSecret` | string | | Object storage secret key |
| `-ObjectStorageBucketName` | string | | Object storage bucket name |
| `-ObjectStorageEndPoint` | string | | Object storage endpoint URL |

## Documentation & Resources

- Documentation: https://gameframex.doc.alianblank.com
- Repository: https://github.com/GameFrameX/com.gameframex.unity.builder
- Issues: https://github.com/GameFrameX/com.gameframex.unity.builder/issues


## Dependencies

| Package | Description |
|---------|-------------|
| (无) | - |


## Community & Support

- QQ Group: 467608841 / 233840761

## Changelog

See [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.builder/releases) for changelog.
## License

See [LICENSE](LICENSE.md) for details.
