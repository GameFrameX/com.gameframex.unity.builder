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

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

## 프로젝트 개요

Game Frame X Builder는 Unity 자동 빌드 도구로, 게임 프로젝트의 빌드 파이프라인 자동화를 간소화합니다.

자세한 사용 방법은 문서의 Unity/자동 빌드 섹션을 참조하세요.

### 기능

- `-executeMethod`를 통한 Android / iOS / WebGL / 독립 플랫폼 등 Unity 프로젝트 자동 빌드
- Unity 명령줄 인수로 빌드 번호, 채널, 언어, 패키지 버전 등을 설정
- 다중 에셋 번들 파이프라인 지원: Builtin / Scriptable / RawFile
- HybridCLR 통합은 옵션 (`com.code-philosophy.hybridclr` 설치 필요)
- 오브젝트 스토리지 업로드는 옵션 (QiNiu / Tencent / ALiYun, 대응하는 GameFrameX 패키지 필요)
- 빌드 완료 후 기업 WeChat 봇 알림 내장

## 빠른 시작

### 시스템 요구 사항

- Unity 2019.4 이상

### 설치

다음 방법 중 하나를 선택하세요:

1. Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:
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

   `scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex.unity`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

2. `manifest.json`의 `dependencies`에 직접 추가:
   ```json
   {
      "com.gameframex.unity.builder": "https://github.com/gameframex/com.gameframex.unity.builder.git"
   }
   ```
3. Unity의 **Package Manager**에서 **Git URL**을 사용하여 추가: `https://github.com/gameframex/com.gameframex.unity.builder.git`
4. 리포지토리를 Unity 프로젝트의 `Packages` 디렉토리에 클론하세요. 자동으로 로드됩니다.

## 사용 예시

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

## 의존성

| 패키지 | 설명 |
|--------|------|
| `com.gameframex.unity` | GameFrameX 코어 런타임 및 에디터 기반 |
| `com.gameframex.unity.litjson` | LitJSON 기반 JSON 직렬화 |
| `com.gameframex.unity.tuyoogame.yooasset` | YooAsset 에셋 번들 빌드 파이프라인 |

옵션 (`versionDefines`로 활성화):

| 패키지 | 설명 |
|--------|------|
| `com.code-philosophy.hybridclr` | HybridCLR 핫 업데이트 지원 |
| `com.gameframex.unity.objectstorage` | 오브젝트 스토리지 업로드 (QiNiu / Tencent / ALiYun) |

## 문서 및 자료

- 문서: https://gameframex.doc.alianblank.com
- 저장소: https://github.com/GameFrameX/com.gameframex.unity.builder
- 이슈: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## 커뮤니티 및 지원

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

## 변경 로그

[Releases](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)에서 변경 로그를 확인하세요.

## 라이선스

자세한 내용은 [LICENSE.md](LICENSE.md)를 참조하세요.
