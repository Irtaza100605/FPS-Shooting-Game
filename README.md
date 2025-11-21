# FPS Shooting Game 🎮

A complete 3D First-Person Shooter game built with Unity 2022.3.62f1 for Windows PC.

## 🎯 Project Overview

This is a comprehensive FPS game developed as a 2-week semester project, featuring:
- ✅ First-person camera and movement (WASD + mouse look)
- ✅ Gun shooting mechanics with raycast
- ✅ Enemy AI with NavMesh pathfinding
- ✅ Health system for player and enemies
- ✅ Ammo system with magazine and reserve ammunition
- ✅ Multiple weapons with switching
- ✅ UI system (health bar, ammo counter, crosshair)
- ✅ Game management and state handling

## 🚀 Quick Start

### For Unity Developers
1. Clone this repository
2. Open Unity Hub and add this project
3. Open with Unity 2022.3.62f1
4. Follow [SETUP_GUIDE.md](SETUP_GUIDE.md) to create your first scene
5. Press Play and start developing!

### For Players
Download the latest build from Releases (when available) and run the .exe file.

## 📁 Project Structure

```
FPS-Shooting-Game/
├── Assets/
│   ├── Scripts/          # All C# gameplay scripts ✓
│   ├── Scenes/           # Game scenes (create MainGame.unity)
│   ├── Prefabs/          # Reusable game objects
│   ├── Materials/        # Visual materials
│   ├── Animations/       # Animation files
│   ├── Audio/            # Sound effects
│   └── UI/               # UI assets
├── ProjectSettings/      # Unity configuration ✓
├── Packages/             # Package dependencies ✓
├── GAME_DOCUMENTATION.md # Complete game documentation
├── SETUP_GUIDE.md        # Step-by-step setup instructions
└── PROJECT_PLAN.md       # 2-week development plan
```

## 🎮 Features Implemented

### Player Systems
- **PlayerController**: Smooth first-person movement with WASD, mouse look, jumping, and sprinting
- **HealthSystem**: Damage and healing with event system
- **WeaponSwitcher**: Switch between multiple weapons

### Weapon Systems
- **Weapon**: Base weapon class with shooting, ammo, and reload mechanics
- **Raycast Shooting**: Precise hit detection
- **Ammo Management**: Magazine + reserve system
- **Multiple Weapons**: Support for different weapon types

### Enemy Systems
- **EnemyAI**: NavMesh-based enemy with chase and attack behavior
- **Enemy Health**: Enemies take damage and die
- **EnemySpawner**: Dynamic enemy spawning at designated points

### UI Systems
- **UIManager**: Centralized UI management
- **Health Bar**: Visual health indicator
- **Ammo Counter**: Shows current/reserve ammo
- **Crosshair**: Center screen targeting
- **Game Over Screen**: Death state handling

### Game Management
- **GameManager**: Game state and scene management
- **Pause System**: ESC to pause game
- **Pickups**: Health and ammo collectibles

## 🎯 Controls

| Action | Key/Button |
|--------|-----------|
| Move | WASD |
| Look | Mouse |
| Shoot | Left Mouse Button |
| Reload | R |
| Jump | Space |
| Sprint | Left Shift |
| Switch Weapon | 1/2/3 or Mouse Wheel |
| Pause | ESC |

## 📚 Documentation

- **[GAME_DOCUMENTATION.md](GAME_DOCUMENTATION.md)** - Complete game features and technical details
- **[SETUP_GUIDE.md](SETUP_GUIDE.md)** - Step-by-step Unity setup (40 minutes)
- **[PROJECT_PLAN.md](PROJECT_PLAN.md)** - 2-week development timeline

## 🛠️ Technical Details

- **Engine**: Unity 2022.3.62f1
- **Platform**: Windows PC
- **Rendering**: Built-in Render Pipeline
- **Physics**: Unity Physics with raycasting
- **AI**: NavMesh pathfinding
- **UI**: Unity UI with TextMeshPro

## 🎓 Educational Purpose

This project is designed as a learning resource for:
- Unity game development fundamentals
- FPS game mechanics
- AI pathfinding with NavMesh
- UI system implementation
- C# scripting in Unity
- Game state management

## 🔧 Development Setup

### Requirements
- Unity 2022.3.62f1 or compatible
- Windows 10/11
- 4GB RAM minimum
- DirectX 11 compatible GPU

### Installation
```bash
git clone https://github.com/Irtaza100605/FPS-Shooting-Game.git
cd FPS-Shooting-Game
# Open in Unity Hub
```

## 📝 Scripts Overview

### Core Scripts (All Implemented)
- `PlayerController.cs` - First-person movement and camera
- `HealthSystem.cs` - Health management with events
- `Weapon.cs` - Shooting and ammo system
- `WeaponSwitcher.cs` - Multiple weapon management
- `EnemyAI.cs` - Enemy behavior and attacks
- `UIManager.cs` - UI element management
- `GameManager.cs` - Game state handling
- `AmmoPickup.cs` - Ammo collectibles
- `HealthPickup.cs` - Health collectibles
- `EnemySpawner.cs` - Enemy spawning system
- `MainMenu.cs` - Menu navigation

## 🎨 Next Steps

To complete the game, you need to:
1. Create game scenes in Unity (follow SETUP_GUIDE.md)
2. Add 3D models or use Unity primitives
3. Add sound effects and music
4. Design levels with cover and obstacles
5. Bake NavMesh for AI
6. Build for Windows

## 🤝 Contributing

This is an educational project. Feel free to:
- Fork and experiment
- Submit improvements
- Use as learning reference
- Adapt for your own projects

## 📄 License

This project is open for educational use. Feel free to learn from and modify the code.

## 👨‍💻 Author

Created as a Unity semester project for learning game development.

## 🙏 Acknowledgments

- Unity Technologies for the game engine
- Game development community for tutorials and resources
- FPS game design principles from classic shooters

---

**Status**: ✅ All core scripts implemented | 🎯 Ready for scene setup | 📚 Fully documented

For detailed setup instructions, see [SETUP_GUIDE.md](SETUP_GUIDE.md)
