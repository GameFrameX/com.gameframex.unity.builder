<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Builder

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.builder?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.builder/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams**

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · [QQ Group](https://qm.qq.com/q/5s5e1e6e6e)

**Language**: **English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## Project Overview

Game Frame X Builder is an automated build tool for Unity, providing streamlined build pipeline automation for game projects.

For detailed usage, refer to Unity/Automated Build section in the documentation.

## Quick Start

### System Requirements

- Unity 2019.4 or higher

### Installation

Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:

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

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.builder": "2.0.3"
  }
}
```

`scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

Alternatively, you can also install via:

1. Use `Git URL` in Unity's Package Manager:
   ```
   https://github.com/GameFrameX/com.gameframex.unity.builder.git
   ```

2. Download the repository and place it in your Unity project's `Packages` directory. It will be loaded automatically.

## Documentation & Resources

- Documentation: https://gameframex.doc.alianblank.com
- Repository: https://github.com/GameFrameX/com.gameframex.unity.builder
- Issues: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## License

See [LICENSE](LICENSE.md) for details.
