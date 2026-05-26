<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Builder

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.builder?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.builder/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援**

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · [QQグループ](https://qm.qq.com/q/5s5e1e6e6e)

**言語**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

## プロジェクト概要

Game Frame X Builder は Unity の自動ビルドツールで、ゲームプロジェクトのビルドパイプライン自動化を効率化します。

詳細な使用方法については、ドキュメントの Unity/自動ビルドのセクションを参照してください。

## クイックスタート

### 動作環境

- Unity 2019.4 以上

### インストール

Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：

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

`dependencies` にパッケージを追加：

```json
{
  "dependencies": {
    "com.gameframex.unity.builder": "2.0.3"
  }
}
```

`scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

以下の方法でもインストール可能です：

1. Unity の Package Manager で `Git URL` を使用：
   ```
   https://github.com/GameFrameX/com.gameframex.unity.builder.git
   ```

2. リポジトリをダウンロードして Unity プロジェクトの `Packages` ディレクトリに配置。自動的にロードされます。

## コマンドラインパラメータ

パラメータは Unity コマンドライン引数として渡します（例: `-flag value`）。

### 必須

| パラメータ | 説明 |
|-----------|------|
| `-executeMethod` | 実行メソッド（例: `GameFrameX.Builder.Editor.Builder.BuildApk`） |
| `-BUILD_NUMBER` | ビルド番号 |

### 一般

| パラメータ | 型 | デフォルト | 説明 |
|-----------|------|---------|------|
| `-logFile` | string | 自動生成 | ログファイルパス |
| `-JOB_NAME` | string | | ジョブ名 |
| `-BundleId` | string | プロジェクト設定 | アプリケーションバンドルID |
| `-AppVersion` | string | プロジェクト設定 | アプリケーションバージョン |
| `-ChannelName` | string | `default` | チャンネル名 |
| `-Language` | string | `default` | 言語 |

### アセットビルド（BuildAsset）

| パラメータ | 型 | デフォルト | 説明 |
|-----------|------|---------|------|
| `-PackageName` | string | `DefaultPackage` | アセットバンドルパッケージ名 |
| `-PackageVersion` | string | タイムスタンプ | パッケージバージョン（空の場合はタイムスタンプ自動生成） |
| `-BuildPipeline` | enum | `BuiltinBuildPipeline` | ビルドパイプライン: `BuiltinBuildPipeline` / `ScriptableBuildPipeline` / `RawFileBuildPipeline` |
| `-BuildinFileCopyOption` | enum | `ClearAndCopyAll` | 内蔵ファイルコピーオプション: `None` / `ClearAndCopyAll` / `ClearAndCopyByTags` / `OnlyCopyNew` |
| `-IsIncrementalBuildPackage` | flag | `false` | インクリメンタルビルドを使用 |

### アップロード・通知

| パラメータ | 型 | デフォルト | 説明 |
|-----------|------|---------|------|
| `-IsUploadLogFile` | flag | `false` | ログファイルをアップロード |
| `-IsUploadAsset` | flag | `false` | アセットバンドルをアップロード |
| `-IsUploadApk` | flag | `false` | APK/IPA をアップロード（BuildApk のみ） |
| `-IsUpdateAssetPackageVersion` | flag | `false` | アセットパッケージバージョンを更新 |
| `-UpdateAssetPackageVersionUrl` | string | | バージョン更新URL |
| `-UpdateAssetPackageVersionAuthorization` | string | | バージョン更新の認証情報 |
| `-WeChatBotKey` | string | | WeChat Work ボット Webhook Key |

### オブジェクトストレージ

| パラメータ | 型 | デフォルト | 説明 |
|-----------|------|---------|------|
| `-ObjectStorageKey` | string | | アクセスキー |
| `-ObjectStorageSecret` | string | | シークレットキー |
| `-ObjectStorageBucketName` | string | | バケット名 |
| `-ObjectStorageEndPoint` | string | | エンドポイントURL |

## ドキュメントとリソース

- ドキュメント: https://gameframex.doc.alianblank.com
- リポジトリ: https://github.com/GameFrameX/com.gameframex.unity.builder
- イシュー: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## ライセンス

詳細は [LICENSE](LICENSE.md) をご覧ください。
