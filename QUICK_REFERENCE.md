# FPS Game - Quick Reference Card

## 🎮 Player Controls
```
Movement:
  W/↑     - Move Forward
  S/↓     - Move Backward
  A/←     - Move Left
  D/→     - Move Right
  Shift   - Sprint
  Space   - Jump
  Mouse   - Look Around

Combat:
  LMB     - Shoot
  R       - Reload
  1/2/3   - Select Weapon
  Scroll  - Cycle Weapons

System:
  ESC     - Pause Menu
```

## 🔧 Component Quick Setup

### Player Setup Checklist
```
GameObject: Player
├─ Character Controller
├─ Player Controller Script
│  └─ Camera Transform: [Assign Camera]
├─ Health System Script
│  ├─ Max Health: 100
│  └─ Is Player: ✓
├─ Weapon Switcher Script
│  └─ Weapons: [Assign Weapon Objects]
└─ Tag: "Player"
```

### Weapon Setup Checklist
```
GameObject: Pistol (under WeaponHolder)
├─ Weapon Script
│  ├─ Weapon Name: "Pistol"
│  ├─ Damage: 25
│  ├─ Fire Rate: 0.5
│  ├─ Max Ammo: 12
│  ├─ Reserve Ammo: 60
│  ├─ Range: 100
│  └─ Shoot Point: [Assign ShootPoint]
└─ Audio Source
```

### Enemy Setup Checklist
```
GameObject: Enemy
├─ NavMesh Agent
├─ Enemy AI Script
│  ├─ Detection Range: 15
│  ├─ Attack Range: 2
│  ├─ Attack Damage: 10
│  └─ Move Speed: 3.5
├─ Health System Script
│  └─ Max Health: 50
├─ Capsule Collider
└─ Tag: "Enemy"
```

### UI Setup Checklist
```
GameObject: Canvas
├─ UI Manager Script
│  ├─ Health Bar: [Assign Fill Image]
│  ├─ Ammo Text: [Assign TextMeshPro]
│  ├─ Crosshair: [Assign Image]
│  ├─ Game Over Panel: [Assign Panel]
│  └─ Game Over Text: [Assign TextMeshPro]
└─ Canvas Scaler
```

## 🎯 Common Values Reference

### Player Settings
```
Walk Speed:    5.0
Sprint Speed:  8.0
Jump Height:   2.0
Gravity:      -9.81
Mouse Sens:    2.0
Max Look:      80°
Health:        100
```

### Weapon Types
```
Pistol:
  Damage: 25  | Fire Rate: 0.5s  | Ammo: 12/60

Rifle:
  Damage: 30  | Fire Rate: 0.1s  | Ammo: 30/120

Shotgun:
  Damage: 70  | Fire Rate: 1.0s  | Ammo: 8/32
```

### Enemy Settings
```
Detection Range:  15
Attack Range:     2
Attack Damage:    10
Move Speed:       3.5
Health:           50
Attack Cooldown:  1.5s
```

## 📋 Required Tags & Layers

### Tags (Edit → Project Settings → Tags)
- Player
- Enemy
- Weapon
- Pickup
- Ground

### Layers
- Default (0)
- Player (8)
- Enemy (9)
- Weapon (10)
- Ground (12)

## 🔍 Debug Commands

### In Unity Console
```csharp
// Test damage player
GameObject.FindWithTag("Player").GetComponent<HealthSystem>().TakeDamage(10);

// Test heal player
GameObject.FindWithTag("Player").GetComponent<HealthSystem>().Heal(25);

// Find all enemies
GameObject.FindGameObjectsWithTag("Enemy");

// Unlock cursor (if stuck)
Cursor.lockState = CursorLockMode.None;
Cursor.visible = true;
```

## 🎨 NavMesh Baking Settings

### Recommended Settings
```
Agent Radius:       0.5
Agent Height:       2.0
Max Slope:          45°
Step Height:        0.4
Generated Links:    Drop/Jump
```

### Bake Process
1. Select all floor/ground objects
2. Navigation window → Object → ✓ Navigation Static
3. Navigation window → Bake → Bake

## 🚀 Build Settings Quick Reference

### Windows Standalone
```
Target Platform:    Windows
Architecture:       x86_64
Scripting Backend:  IL2CPP or Mono
API Level:          .NET Standard 2.1
Compression:        LZ4 (faster) or LZ4HC (smaller)
```

## 📊 Performance Targets

### Frame Rate
- Target: 60 FPS
- Minimum: 30 FPS

### Memory
- Player objects: < 10 MB
- Enemies: < 5 MB each
- Total: < 500 MB

### Optimization Tips
```
✓ Use object pooling for enemies
✓ Limit active enemies (< 10)
✓ Bake lighting
✓ Use LOD on models
✓ Optimize draw calls (< 100)
```

## 🐛 Quick Fixes

### Player falls through floor
→ Add Collider to ground

### Can't shoot
→ Check Camera.main exists
→ Verify ammo > 0

### Enemies don't move
→ Bake NavMesh
→ Check "Player" tag

### UI doesn't show
→ Canvas Render Mode: Screen Space - Overlay
→ Check UI elements are active

### Cursor visible in game
→ PlayerController locks cursor on Start

## 💾 Save/Load Locations

### Unity Files
```
Scenes:      Assets/Scenes/
Scripts:     Assets/Scripts/
Prefabs:     Assets/Prefabs/
Materials:   Assets/Materials/
```

### Build Output
```
Default:     Builds/
Windows:     .exe + _Data folder
```

## 📞 Quick Help

### Getting Started
1. Open Unity 2022.3.62f1
2. Open project folder
3. Follow SETUP_GUIDE.md
4. Time: ~40 minutes

### Full Documentation
- README.md - Overview
- SETUP_GUIDE.md - Step-by-step
- GAME_DOCUMENTATION.md - Complete reference
- PROJECT_PLAN.md - Development timeline

---
**Print this for quick reference while developing!**
