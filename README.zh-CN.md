<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Builder

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.builder?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.builder/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.builder?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.builder/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使**

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**语言**: [English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

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

## 文档与资源

- 文档地址: https://gameframex.doc.alianblank.com
- 仓库地址: https://github.com/GameFrameX/com.gameframex.unity.builder
- 问题反馈: https://github.com/GameFrameX/com.gameframex.unity.builder/issues

## 开源协议

详细信息请查看 [LICENSE](LICENSE.md) 文件。
