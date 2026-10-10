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

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>

## プロジェクト概要

Game Frame X Builder は Unity の自動ビルドツールで、ゲームプロジェクトのビルドパイプライン自動化を効率化します。

詳細な使用方法については、ドキュメントの Unity/自動ビルドのセクションを参照してください。

### 機能概要

- `-executeMethod` 経由で Android / iOS / WebGL / スタンドアロン等の Unity プロジェクトを自動ビルド
- Unity コマンドライン引数でビルド番号・チャネル・言語・パッケージバージョンなどを設定
- 複数のアセットバンドルパイプライン（Builtin / Scriptable / RawFile）に対応
- HybridCLR 連携はオプション（`com.code-philosophy.hybridclr` のインストールが必要）
- オブジェクトストレージへのアップロードはオプション（七牛 / 腾讯 / 阿里云、対応する GameFrameX パッケージが必要）
- ビルド完了時に企業微信ボットへ通知

## クイックスタート

### 動作環境

- Unity 2019.4 以上

### インストール

以下のいずれかの方法を選択してください：

1. Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：
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

   `scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex.unity` で始まるパッケージのみがこのレジストリから取得されます。

2. `manifest.json` の `dependencies` に直接追加：
   ```json
   {
      "com.gameframex.unity.builder": "https://github.com/gameframex/com.gameframex.unity.builder.git"
   }
   ```
3. Unity の **Package Manager** で **Git URL** を使用して追加：`https://github.com/gameframex/com.gameframex.unity.builder.git`
4. リポジトリを Unity プロジェクトの `Packages` ディレクトリにクローンしてください。自動的に読み込まれます。

## 使用例

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

## 依存関係

| パッケージ | 説明 |
|----------|------|
| `com.gameframex.unity` | GameFrameX コアランタイムおよびエディタ基盤 |
| `com.gameframex.unity.litjson` | LitJSON ベースの JSON シリアライズ |
| `com.gameframex.unity.tuyoogame.yooasset` | YooAsset アセットバンドルパイプライン |

オプション（`versionDefines` 経由で有効化）:

| パッケージ | 説明 |
|----------|------|
| `com.code-philosophy.hybridclr` | HybridCLR ホットアップデート対応 |
| `com.gameframex.unity.objectstorage` | オブジェクトストレージへのアップロード（七牛 / 腾讯 / 阿里云） |

## ドキュメントとリソース

- ドキュメント: https://gameframex.doc.alianblank.com
- リポジトリ: https://github.com/GameFrameX/com.gameframex.unity.builder
- イシュー: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## コミュニティとサポート

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

## 変更履歴

[Releases](https://github.com/GameFrameX/com.gameframex.unity.builder/releases) で変更履歴を確認してください。

## ライセンス

詳しくは [LICENSE.md](LICENSE.md) をご参照ください。
