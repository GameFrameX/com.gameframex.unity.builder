<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Builder

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 项目简介

Game Frame X Builder 是一个 Unity 自动化构建工具，为游戏项目提供流线化的构建管线自动化功能。

详细使用方式请参照文档中的 Unity/自动化构建章节。

## 快速开始

### 系统要求

- Unity 2019.4 或更高版本

### 安装

编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

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
  ]
}
```

然后在 `dependencies` 中添加包：

```json
{
  "dependencies": {
    "com.gameframex.unity.builder": "2.0.3"
  }
}
```

`scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex` 开头的包才会从这个注册表获取。

你也可以通过以下方式安装：

1. 在 Unity 的 `Package Manager` 中使用 `Git URL` 的方式添加库，地址为：
   ```
   https://github.com/GameFrameX/com.gameframex.unity.builder.git
   ```

2. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

## 命令行参数

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

## 文档与资源

- 文档地址: https://gameframex.doc.alianblank.com
- 仓库地址: https://github.com/GameFrameX/com.gameframex.unity.builder
- 问题反馈: https://github.com/GameFrameX/com.gameframex.unity.builder/issues


## 依赖

| 包 | 说明 |
|----|------|
| (无) | - |


## 社区与支持

- QQ群: 467608841 / 233840761

## 更新日志

查看 [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.builder/releases) 了解更新日志。
## 开源协议

详细信息请查看 [LICENSE](LICENSE.md) 文件。
