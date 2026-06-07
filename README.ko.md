<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Builder

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

## 프로젝트 개요

Game Frame X Builder는 Unity 자동 빌드 도구로, 게임 프로젝트의 빌드 파이프라인 자동화를 간소화합니다.

자세한 사용 방법은 문서의 Unity/자동 빌드 섹션을 참조하세요.

## 빠른 시작

### 시스템 요구 사항

- Unity 2019.4 이상

### 설치

Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:

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

`dependencies`에 패키지를 추가:

```json
{
  "dependencies": {
    "com.gameframex.unity.builder": "2.0.3"
  }
}
```

`scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

다음 방법으로도 설치할 수 있습니다:

1. Unity의 Package Manager에서 `Git URL`을 사용하여 추가:
   ```
   https://github.com/GameFrameX/com.gameframex.unity.builder.git
   ```

2. 저장소를 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치하면 자동으로 로드됩니다.

## 명령줄 매개변수

매개변수는 Unity 명령줄 인수로 전달됩니다 (예: `-flag value`).

### 필수

| 매개변수 | 설명 |
|---------|------|
| `-executeMethod` | 실행할 메서드 (예: `GameFrameX.Builder.Editor.Builder.BuildApk`) |
| `-BUILD_NUMBER` | 빌드 번호 |

### 일반

| 매개변수 | 유형 | 기본값 | 설명 |
|---------|------|-------|------|
| `-logFile` | string | 자동 생성 | 로그 파일 경로 |
| `-JOB_NAME` | string | | 작업 이름 |
| `-BundleId` | string | 프로젝트 설정 | 애플리케이션 번들 ID |
| `-AppVersion` | string | 프로젝트 설정 | 애플리케이션 버전 |
| `-ChannelName` | string | `default` | 채널 이름 |
| `-Language` | string | `default` | 언어 |

### 에셋 빌드 (BuildAsset)

| 매개변수 | 유형 | 기본값 | 설명 |
|---------|------|-------|------|
| `-PackageName` | string | `DefaultPackage` | 에셋 번들 패키지 이름 |
| `-PackageVersion` | string | 타임스탬프 | 패키지 버전 (비어 있으면 타임스탬프 자동 생성) |
| `-BuildPipeline` | enum | `BuiltinBuildPipeline` | 빌드 파이프라인: `BuiltinBuildPipeline` / `ScriptableBuildPipeline` / `RawFileBuildPipeline` |
| `-BuildinFileCopyOption` | enum | `ClearAndCopyAll` | 내장 파일 복사 옵션: `None` / `ClearAndCopyAll` / `ClearAndCopyByTags` / `OnlyCopyNew` |
| `-IsIncrementalBuildPackage` | flag | `false` | 증분 빌드 사용 |

### 업로드 및 알림

| 매개변수 | 유형 | 기본값 | 설명 |
|---------|------|-------|------|
| `-IsUploadLogFile` | flag | `false` | 로그 파일 업로드 |
| `-IsUploadAsset` | flag | `false` | 에셋 번들 업로드 |
| `-IsUploadApk` | flag | `false` | APK/IPA 업로드 (BuildApk만 해당) |
| `-IsUpdateAssetPackageVersion` | flag | `false` | 에셋 패키지 버전 업데이트 |
| `-UpdateAssetPackageVersionUrl` | string | | 버전 업데이트 URL |
| `-UpdateAssetPackageVersionAuthorization` | string | | 버전 업데이트 인증 정보 |
| `-WeChatBotKey` | string | | WeChat Work 봇 Webhook Key |

### 오브젝트 스토리지

| 매개변수 | 유형 | 기본값 | 설명 |
|---------|------|-------|------|
| `-ObjectStorageKey` | string | | 액세스 키 |
| `-ObjectStorageSecret` | string | | 시크릿 키 |
| `-ObjectStorageBucketName` | string | | 버킷 이름 |
| `-ObjectStorageEndPoint` | string | | 엔드포인트 URL |

## 문서 및 자료

- 문서: https://gameframex.doc.alianblank.com
- 저장소: https://github.com/GameFrameX/com.gameframex.unity.builder
- 이슈: https://github.com/GameFrameX/com.gameframex.unity.builder/issues


## 의존성

| 패키지 | 설명 |
|--------|------|
| (无) | - |


## 커뮤니티 및 지원

- QQ 그룹: 467608841 / 233840761

## 변경 로그

[Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.builder/releases)에서 변경 로그를 확인하세요.
## 라이선스

자세한 내용은 [LICENSE](LICENSE.md)를 참조하세요.
