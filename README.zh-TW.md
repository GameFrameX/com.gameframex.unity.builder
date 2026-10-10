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

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 項目簡介

Game Frame X Builder 是一個 Unity 自動化構建工具，為遊戲專案提供流線化的構建管線自動化功能。

詳細使用方式請參照文檔中的 Unity/自動化構建章節。

### 功能特性

- 透過 `-executeMethod` 自動化構建 Android / iOS / WebGL / 獨立平台等 Unity 專案
- 透過 Unity 命令列參數設定構建號、渠道、語言、資源包版本等資訊
- 支援多種資源包構建管線：Builtin / Scriptable / RawFile
- 可選整合 HybridCLR（需安裝 `com.code-philosophy.hybridclr`）
- 可選物件儲存上傳（七牛 / 騰訊 / 阿里雲，需安裝對應 GameFrameX 物件儲存套件）
- 內建企業微信機器人通知

## 快速開始

### 系統需求

- Unity 2019.4 或更高版本

### 安裝

選擇以下任一方式：

1. 編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：
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

   `scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex.unity` 開頭的套件才會從這個註冊表取得。

2. 直接在 `manifest.json` 的 `dependencies` 節點下添加以下內容：
   ```json
   {
      "com.gameframex.unity.builder": "https://github.com/gameframex/com.gameframex.unity.builder.git"
   }
   ```
3. 在 Unity 的 `Package Manager` 中使用 `Git URL` 的方式添加庫，地址為：
   `https://github.com/gameframex/com.gameframex.unity.builder.git`
4. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

## 使用範例

參數以 Unity 命令列參數形式傳入（如 `-flag value`）。

### 必填參數

| 參數 | 說明 |
|------|------|
| `-executeMethod` | 執行方法（如 `GameFrameX.Builder.Editor.Builder.BuildApk`） |
| `-BUILD_NUMBER` | 建置號 |

### 通用參數

| 參數 | 類型 | 預設值 | 說明 |
|------|------|--------|------|
| `-logFile` | string | 自動產生 | 日誌檔案路徑 |
| `-JOB_NAME` | string | | 任務名稱 |
| `-BundleId` | string | 專案設定 | 應用程式包名 |
| `-AppVersion` | string | 專案設定 | 應用程式版本號 |
| `-ChannelName` | string | `default` | 渠道名稱 |
| `-Language` | string | `default` | 語言 |

### 資源建置參數（BuildAsset）

| 參數 | 類型 | 預設值 | 說明 |
|------|------|--------|------|
| `-PackageName` | string | `DefaultPackage` | 資源包名稱 |
| `-PackageVersion` | string | 時間戳 | 資源包版本號（為空時自動使用時間戳） |
| `-BuildPipeline` | enum | `BuiltinBuildPipeline` | 建置管線類型：`BuiltinBuildPipeline` / `ScriptableBuildPipeline` / `RawFileBuildPipeline` |
| `-BuildinFileCopyOption` | enum | `ClearAndCopyAll` | 內建檔案複製選項：`None` / `ClearAndCopyAll` / `ClearAndCopyByTags` / `OnlyCopyNew` |
| `-IsIncrementalBuildPackage` | flag | `false` | 是否使用增量建置 |

### 上傳與通知參數

| 參數 | 類型 | 預設值 | 說明 |
|------|------|--------|------|
| `-IsUploadLogFile` | flag | `false` | 是否上傳日誌檔案 |
| `-IsUploadAsset` | flag | `false` | 是否上傳資源包 |
| `-IsUploadApk` | flag | `false` | 是否上傳 APK/IPA（僅 BuildApk 有效） |
| `-IsUpdateAssetPackageVersion` | flag | `false` | 是否更新資源包版本 |
| `-UpdateAssetPackageVersionUrl` | string | | 更新資源包版本的 URL |
| `-UpdateAssetPackageVersionAuthorization` | string | | 更新資源包版本的授權 |
| `-WeChatBotKey` | string | | 企業微信機器人 Webhook Key |

### 物件儲存參數

| 參數 | 類型 | 預設值 | 說明 |
|------|------|--------|------|
| `-ObjectStorageKey` | string | | 物件儲存存取 Key |
| `-ObjectStorageSecret` | string | | 物件儲存存取金鑰 |
| `-ObjectStorageBucketName` | string | | 物件儲存桶名稱 |
| `-ObjectStorageEndPoint` | string | | 物件儲存區域端點 |

## 依賴

| 套件 | 說明 |
|------|------|
| `com.gameframex.unity` | GameFrameX 核心執行階段與編輯器基礎模組 |
| `com.gameframex.unity.litjson` | 基於 LitJSON 的 JSON 序列化 |
| `com.gameframex.unity.tuyoogame.yooasset` | YooAsset 資源包構建管線 |

可選依賴（透過 `versionDefines` 按需啟用）：

| 套件 | 說明 |
|------|------|
| `com.code-philosophy.hybridclr` | HybridCLR 熱更新支援 |
| `com.gameframex.unity.objectstorage` | 物件儲存上傳（七牛 / 騰訊 / 阿里雲） |

## 文檔與資源

- 文檔地址: https://gameframex.doc.alianblank.com
- 倉庫地址: https://github.com/GameFrameX/com.gameframex.unity.builder
- 問題回報: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## 社區與支援

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

## 更新日誌

查看 [Releases](https://github.com/GameFrameX/com.gameframex.unity.builder/releases) 了解更新日誌。

## 開源協議

詳見 [LICENSE.md](LICENSE.md) 檔案。
