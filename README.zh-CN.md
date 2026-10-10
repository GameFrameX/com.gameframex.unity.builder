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

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 项目简介

Game Frame X Builder 是一个 Unity 自动化构建工具，为游戏项目提供流线化的构建管线自动化功能。

详细使用方式请参照文档中的 Unity/自动化构建章节。

### 功能特性

- 通过 `-executeMethod` 自动化构建 Android / iOS / WebGL / 独立平台等 Unity 工程
- 通过 Unity 命令行参数配置构建号、渠道、语言、资源包版本等信息
- 支持多种资源包构建管线：Builtin / Scriptable / RawFile
- 可选集成 HybridCLR（需安装 `com.code-philosophy.hybridclr`）
- 可选对象存储上传（七牛 / 腾讯 / 阿里云，需安装对应 GameFrameX 对象存储包）
- 内置企业微信机器人通知

## 快速开始

### 系统要求

- Unity 2019.4 或更高版本

### 安装

选择以下任一方式：

1. 编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：
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

   `scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex.unity` 开头的包才会从这个注册表获取。

2. 直接在 `manifest.json` 的 `dependencies` 节点下添加以下内容：
   ```json
   {
      "com.gameframex.unity.builder": "https://github.com/gameframex/com.gameframex.unity.builder.git"
   }
   ```
3. 在 Unity 的 `Package Manager` 中使用 `Git URL` 的方式添加库，地址为：
   `https://github.com/gameframex/com.gameframex.unity.builder.git`
4. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

## 使用示例

参数以 Unity 命令行参数形式传入（如 `-flag value`）。

### 必填参数

| 参数 | 说明 |
|------|------|
| `-executeMethod` | 执行方法（如 `GameFrameX.Builder.Editor.Builder.BuildApk`） |
| `-BUILD_NUMBER` | 构建号 |

### 通用参数

| 参数 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `-logFile` | string | 自动生成 | 日志文件路径 |
| `-JOB_NAME` | string | | 任务名称 |
| `-BundleId` | string | 项目设置 | 应用包名 |
| `-AppVersion` | string | 项目设置 | 应用版本号 |
| `-ChannelName` | string | `default` | 渠道名称 |
| `-Language` | string | `default` | 语言 |

### 资源构建参数（BuildAsset）

| 参数 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `-PackageName` | string | `DefaultPackage` | 资源包名称 |
| `-PackageVersion` | string | 时间戳 | 资源包版本号（为空时自动使用时间戳） |
| `-BuildPipeline` | enum | `BuiltinBuildPipeline` | 构建管线类型：`BuiltinBuildPipeline` / `ScriptableBuildPipeline` / `RawFileBuildPipeline` |
| `-BuildinFileCopyOption` | enum | `ClearAndCopyAll` | 内置文件拷贝选项：`None` / `ClearAndCopyAll` / `ClearAndCopyByTags` / `OnlyCopyNew` |
| `-IsIncrementalBuildPackage` | flag | `false` | 是否使用增量构建 |

### 上传与通知参数

| 参数 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `-IsUploadLogFile` | flag | `false` | 是否上传日志文件 |
| `-IsUploadAsset` | flag | `false` | 是否上传资源包 |
| `-IsUploadApk` | flag | `false` | 是否上传 APK/IPA（仅 BuildApk 有效） |
| `-IsUpdateAssetPackageVersion` | flag | `false` | 是否更新资源包版本 |
| `-UpdateAssetPackageVersionUrl` | string | | 更新资源包版本的 URL |
| `-UpdateAssetPackageVersionAuthorization` | string | | 更新资源包版本的授权 |
| `-WeChatBotKey` | string | | 企业微信机器人 Webhook Key |

### 对象存储参数

| 参数 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `-ObjectStorageKey` | string | | 对象存储访问 Key |
| `-ObjectStorageSecret` | string | | 对象存储访问秘钥 |
| `-ObjectStorageBucketName` | string | | 对象存储桶名称 |
| `-ObjectStorageEndPoint` | string | | 对象存储区域节点 |

## 依赖

| 包 | 说明 |
|----|------|
| `com.gameframex.unity` | GameFrameX 核心运行时与编辑器基础模块 |
| `com.gameframex.unity.litjson` | 基于 LitJSON 的 JSON 序列化 |
| `com.gameframex.unity.tuyoogame.yooasset` | YooAsset 资源包构建管线 |

可选依赖（通过 `versionDefines` 按需启用）：

| 包 | 说明 |
|----|------|
| `com.code-philosophy.hybridclr` | HybridCLR 热更新支持 |
| `com.gameframex.unity.objectstorage` | 对象存储上传（七牛 / 腾讯 / 阿里云） |

## 文档与资源

- 文档地址: https://gameframex.doc.alianblank.com
- 仓库地址: https://github.com/GameFrameX/com.gameframex.unity.builder
- 问题反馈: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## 社区与支持

![QQ](https://img.shields.io/badge/QQ-467608841%2F233840761-EB1923?style=for-the-badge&logo=qq&logoColor=white)
[![Bilibili](https://img.shields.io/badge/Bilibili-00A1D6?style=for-the-badge&logo=bilibili&logoColor=white)](https://www.bilibili.com/video/BV1yrpeepEn7)
[![Gitee](https://img.shields.io/badge/Gitee-C71D23?style=for-the-badge&logo=gitee&logoColor=white)](https://gitee.com/GameFrameX/gameframex)
[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/GameFrameX/gameframex)
[![Discord](https://img.shields.io/badge/Discord-5865F2?style=for-the-badge&logo=discord&logoColor=white)](https://discord.gg/VDWUjWMDw9)
[<img src="https://cdn.jsdelivr.net/npm/devicon@2/icons/linkedin/linkedin-original.svg" height="28" alt="LinkedIn" />](https://www.linkedin.com/in/alianblank)
[![Reddit](https://img.shields.io/badge/Reddit-FF4500?style=for-the-badge&logo=reddit&logoColor=white)](https://www.reddit.com/r/GameFrameX/)
[![X](https://img.shields.io/badge/X-000000?style=for-the-badge&logo=x&logoColor=white)](https://x.com/alian_blank)
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCD9QhSFJ5xZkn5NTSV-DVAw)
[![Bluesky](https://img.shields.io/badge/Bluesky-0285FF?style=for-the-badge&logo=bluesky&logoColor=white)](https://bsky.app/profile/alianblank.bsky.social)

## 更新日志

查看 [Releases](https://github.com/GameFrameX/com.gameframex.unity.builder/releases) 了解更新日志。

## 开源协议

详见 [LICENSE.md](LICENSE.md) 文件。
