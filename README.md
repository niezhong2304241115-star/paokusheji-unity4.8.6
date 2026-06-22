# 🔫 炮口设计 — PaoKou Runner

> 🎮 一款 Unity 3D 跑酷射击游戏 | 三车道 · 双段跳 · 机枪扫射 · 道具收集

![Unity](https://img.shields.io/badge/Unity-2022.3.62f3c1-blueviolet?logo=unity)
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20macOS%20%7C%20Linux-lightgrey)
![Status](https://img.shields.io/badge/Status-开发中-brightgreen)
![License](https://img.shields.io/badge/License-MIT-orange)

---

## 📖 游戏简介

**炮口设计** 是一款基于 Unity 2022 开发的 3D **跑酷射击**游戏。  
玩家在无限延伸的三车道跑道上高速奔跑，通过**切换车道、跳跃闪避**来躲避障碍物与火车，同时使用**机枪**射击前方目标，收集金币、磁铁、弹跳鞋、弹药和双倍火力道具，在极限速度中争取最高分数！

> **胜利条件：** 收集 30 枚金币 **或** 总得分（生存时间 + 摧毁得分）达到 60 分

---

## 🎯 核心玩法

| 操作 | 按键 | 说明 |
|------|------|------|
| 🏃 左右换道 | **A** / **D** | 在三条车道间切换，躲避前方障碍 |
| 🦘 跳跃 | **W** / **空格** | 跳过障碍物（支持**二段跳**） |
| ⬇️ 俯冲 | **S** | 空中快速下落，精准落地 |
| 🔫 单发射击 | **鼠标左键** | 点射障碍物 |
| 🔫🔫 连发射击 | **鼠标右键** | 按住不放连续开火 |
| 🎯 瞄准 | 自动向前 | 子弹沿跑道方向射出 |

---

## 🧩 游戏机制

### 🛤️ 三车道系统
- 三条固定车道（X 坐标：-3 / 0 / 3），玩家通过 A/D 切换
- 跑道上随机生成障碍物、道具和金币

### ⚡ 动态加速
- 跑道移动速度会随着时间**持续增加**
- 游戏时间越长，节奏越快，挑战性越大

### 💊 生命值系统
- 初始 **100 HP**
- 撞墙 / 障碍物：**-20 HP**
- 撞火车：**-40 HP**
- HP 归零即游戏结束

### 🎯 胜利条件（二选一）
| 条件 | 说明 |
|------|------|
| 🪙 收集金币 | 达到 **30 枚** |
| 🏆 累计得分 | 计时得分 + 摧毁得分 ≥ **60 分** |

---

## ✨ 道具系统

| 道具 | 图标 | 效果 |
|------|------|------|
| 🪙 **金币** | Coin | 收集计入胜利进度，受磁铁吸引 |
| 🧲 **磁铁** | Magnet | **5 秒内**自动吸附范围内金币 |
| 👟 **弹跳鞋** | Shoe | **5 秒内**跳跃力从 10 → **12**（可叠加延长时间） |
| 🔫 **弹药** | Bullet | 机枪弹药 **+1** |
| 🔥 **双倍火力** | X2 | **10 秒内**一次射两颗子弹 |
| 💥 **障碍物** | Obstacle | HP=2，可被击毁，摧毁 +1 得分 |
| 🚂 **火车** | Train | HP=3，可被击毁，摧毁 +1 得分 |

---

## 🏗️ 项目结构

```
PaokouRunner/
├── Assets/
│   ├── Book Assets/        # 第三方模型资源
│   ├── Materials/          # 材质资源
│   ├── Models/             # 模型文件
│   ├── Prafabs/            # 预制体
│   ├── Scenes/             # 场景文件
│   │   ├── menu.unity      # 主菜单场景
│   │   └── game.unity      # 游戏主场景
│   ├── Script/             # 核心脚本
│   │   ├── Player.cs       # 玩家控制（三车道、跳跃、HP）
│   │   ├── Menu.cs         # 菜单逻辑
│   │   ├── Plane.cs        # 跑道管理器（加速/停止）
│   │   ├── Factory.cs      # 随机生成器（障碍物+道具）
│   │   ├── MachineGun.cs   # 机枪系统（单发/连发/双倍）
│   │   ├── Bullet.cs       # 子弹逻辑
│   │   ├── Coin.cs         # 金币（旋转+磁铁吸引）
│   │   ├── Inventory.cs    # 背包系统（胜利判定）
│   │   ├── Magnet.cs       # 磁铁道具
│   │   ├── Shoe.cs         # 弹跳鞋道具
│   │   ├── Timer.cs        # 计时器（计分）
│   │   ├── Train.cs        # 火车障碍物
│   │   ├── Obstacle.cs     # 障碍物
│   │   ├── Wall.cs         # 墙壁障碍物
│   │   ├── BulletPickup.cs # 弹药拾取
│   │   ├── X2Pickup.cs     # 双倍火力拾取
│   │   └── ...             # HUD 相关组件
│   ├── Textures/           # 纹理贴图
│   └── Standard Assets/    # 标准资源包
├── Packages/               # Unity 包依赖
├── ProjectSettings/        # 项目设置
└── README.md               # 👈 你在这里
```

---

## 🚀 快速开始

### 环境要求

- **Unity Hub** + **Unity 2022.3.62f3c1** 或更高版本
- Git（可选，用于克隆仓库）

### 运行步骤

```bash
# 1. 克隆仓库
git clone https://github.com/niezhong2304241115-star/paokusheji-unity4.8.6.git

# 2. 在 Unity Hub 中打开项目文件夹
# 3. 等待 Unity 导入完成所有资源
# 4. 在 Scenes/ 目录中打开 menu.unity
# 5. 点击 ▶️ 运行游戏
```

> 💡 **提示：** 如果场景加载后找不到 GUI 文本，请检查场景中是否存在 `TextHint`、`hp`、`Timer`、`BulletHUD` 等 GameObject。

---

## 🖥️ 构建发布

在 Unity 中打开项目后：

1. **File → Build Settings**
2. 选择目标平台（Windows / macOS / Linux）
3. 添加 `menu.unity` 和 `game.unity` 到 Scenes In Build
4. 点击 **Build** 生成可执行文件

---

## 🧪 调试快捷键

| 按键 | 功能 |
|------|------|
| **Z** | 测试拾取磁铁（+5 秒） |
| **X** | 测试拾取弹跳鞋（+5 秒） |

---

## 📸 截图

> *（等你添加游戏截图进来！放几张酷炫的跑道、射击、道具收集画面）*

| 菜单界面 | 游戏运行 | 道具收集 |
|:-------:|:-------:|:-------:|
| [菜单截图] | [游戏截图] | [道具截图] |

---

## 🧑‍💻 作者

- **GitHub:** [@niezhong2304241115-star](https://github.com/niezhong2304241115-star)
- **学号：** 2304241115nz

---

## 📄 许可证

本项目采用 MIT 许可证 — 详见 [LICENSE](LICENSE) 文件。

---

> ⭐ 如果这个项目对你有帮助，欢迎点个 Star！  
> 💬 有任何问题或建议，欢迎提 Issue 或 Pull Request！
