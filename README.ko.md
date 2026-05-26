<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Builder

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.builder?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.builder/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현**

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · [QQ 그룹](https://qm.qq.com/q/5s5e1e6e6e)

**언어**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

---

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

## 문서 및 자료

- 문서: https://gameframex.doc.alianblank.com
- 저장소: https://github.com/GameFrameX/com.gameframex.unity.builder
- 이슈: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## 라이선스

자세한 내용은 [LICENSE](LICENSE.md)를 참조하세요.
