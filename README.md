<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Builder

[![License](https://img.shields.io/badge/license-blue.svg)](LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

[![Discord](https://img.shields.io/badge/-5865F2?logo=discord&logoColor=white)](https://discord.gg/VDWUjWMDw9)
[![GitHub](https://img.shields.io/badge/-181717?logo=github&logoColor=white)](https://github.com/GameFrameX/gameframex)
[![Bilibili](https://img.shields.io/badge/-00A1D6?logo=bilibili&logoColor=white)](https://www.bilibili.com/video/BV1yrpeepEn7)
[![Gitee](https://img.shields.io/badge/-C71D23?logo=gitee&logoColor=white)](https://gitee.com/GameFrameX/gameframex)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

Game Frame X Builder is an automated build tool for Unity, providing streamlined build pipeline automation for game projects.

For detailed usage, refer to Unity/Automated Build section in the documentation.

### Features

- Automated Unity build pipeline via `-executeMethod` for Android / iOS / WebGL / standalone and other platforms
- Configurable via Unity command line arguments (build number, channel, language, package version, etc.)
- Asset bundle build with multiple pipelines: Builtin / Scriptable / RawFile
- Optional HybridCLR integration (when `com.code-philosophy.hybridclr` is installed)
- Optional object storage upload (QiNiu / Tencent / ALiYun via GameFrameX object storage packages)
- Built-in enterprise WeChat bot notification after build

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
           "com.gameframex.unity"
         ]
       }
     ],
     "dependencies": {
       "com.gameframex.unity.builder": "2.2.1"
     }
   }
   ```

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex.unity` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.builder": "https://github.com/gameframex/com.gameframex.unity.builder.git"
   }
   ```
3. Use **Package Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.builder.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.

## Usage Examples

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

## Dependencies

| Package | Description |
|---------|-------------|
| `com.gameframex.unity` | GameFrameX core runtime and editor foundation |
| `com.gameframex.unity.litjson` | LitJSON-based JSON serialization |
| `com.gameframex.unity.tuyoogame.yooasset` | YooAsset asset bundle build pipeline |

Optional (resolved via `versionDefines`):

| Package | Description |
|---------|-------------|
| `com.code-philosophy.hybridclr` | HybridCLR hot-update support |
| `com.gameframex.unity.objectstorage` | Object storage upload (QiNiu / Tencent / ALiYun) |

## Documentation & Resources

- Documentation: https://gameframex.doc.alianblank.com
- Repository: https://github.com/GameFrameX/com.gameframex.unity.builder
- Issues: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## Community & Support

[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/GameFrameX/gameframex)
[![Discord](https://img.shields.io/badge/Discord-5865F2?style=for-the-badge&logo=discord&logoColor=white)](https://discord.gg/VDWUjWMDw9)
[<img src="https://cdn.jsdelivr.net/npm/devicon@2/icons/linkedin/linkedin-original.svg" height="28" alt="LinkedIn" />](https://www.linkedin.com/in/alianblank)
[![Reddit](https://img.shields.io/badge/Reddit-FF4500?style=for-the-badge&logo=reddit&logoColor=white)](https://www.reddit.com/r/GameFrameX/)
[![X](https://img.shields.io/badge/X-000000?style=for-the-badge&logo=x&logoColor=white)](https://x.com/alian_blank)
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCD9QhSFJ5xZkn5NTSV-DVAw)
[![Bluesky](https://img.shields.io/badge/Bluesky-0285FF?style=for-the-badge&logo=bluesky&logoColor=white)](https://bsky.app/profile/alianblank.bsky.social)
[![Bilibili](https://img.shields.io/badge/Bilibili-00A1D6?style=for-the-badge&logo=bilibili&logoColor=white)](https://www.bilibili.com/video/BV1yrpeepEn7)
[![Gitee](https://img.shields.io/badge/Gitee-C71D23?style=for-the-badge&logo=gitee&logoColor=white)](https://gitee.com/GameFrameX/gameframex)
![QQ](https://img.shields.io/badge/QQ-467608841%2F233840761-EB1923?style=for-the-badge&logo=qq&logoColor=white)

## Changelog

See [Releases](https://github.com/GameFrameX/com.gameframex.unity.builder/releases) for changelog.

## License

See [LICENSE.md](LICENSE.md) for license information.
