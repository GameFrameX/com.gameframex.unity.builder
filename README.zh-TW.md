<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Builder

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 項目簡介

Game Frame X Builder 是一個 Unity 自動化構建工具，為遊戲專案提供流線化的構建管線自動化功能。

詳細使用方式請參照文檔中的 Unity/自動化構建章節。

## 快速開始

### 系統需求

- Unity 2019.4 或更高版本

### 安裝

編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

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

然後在 `dependencies` 中添加套件：

```json
{
  "dependencies": {
    "com.gameframex.unity.builder": "2.0.3"
  }
}
```

`scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

你也可以透過以下方式安裝：

1. 在 Unity 的 `Package Manager` 中使用 `Git URL` 的方式添加庫，地址為：
   ```
   https://github.com/GameFrameX/com.gameframex.unity.builder.git
   ```

2. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

## 命令列參數

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

## 文檔與資源

- 文檔地址: https://gameframex.doc.alianblank.com
- 倉庫地址: https://github.com/GameFrameX/com.gameframex.unity.builder
- 問題回報: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## 開源協議

詳細資訊請查看 [LICENSE](LICENSE.md) 檔案。
