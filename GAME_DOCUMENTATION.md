# Unity FPS Shooting Game

A complete 3D First-Person Shooter game built in Unity 2022.3.62f1 for Windows PC.

## Project Overview

This is a 2-week semester project featuring a fully functional FPS game with modern game mechanics.

## Features

### Core Gameplay
- **First-Person Controller**: Smooth WASD movement with mouse look
- **Multiple Weapons**: Switch between different weapons with distinct properties
- **Shooting Mechanics**: Raycast-based shooting with muzzle flash effects
- **Ammo System**: Magazine-based ammo with reserve ammunition
- **Reloading**: Press R to reload weapons

### Enemy AI
- **NavMesh-Based Movement**: Enemies chase and attack the player
- **Detection System**: Enemies detect player within range
- **Attack Behavior**: Melee attacks with cooldown system
- **Health System**: Enemies can be damaged and killed

### UI System
- **Health Bar**: Visual representation of player health
- **Ammo Counter**: Displays current/reserve ammunition
- **Crosshair**: Center screen targeting indicator
- **Game Over Screen**: Displayed when player dies
- **Pause Menu**: Press ESC to pause the game

### Additional Systems
- **Health Pickups**: Restore player health
- **Ammo Pickups**: Replenish ammunition
- **Enemy Spawner**: Dynamically spawn enemies
- **Game Manager**: Handles game states and scene management

## Project Structure

```
FPS-Shooting-Game/
├── Assets/
│   ├── Scripts/          # All C# gameplay scripts
│   ├── Scenes/           # Game scenes (place .unity files here)
│   ├── Prefabs/          # Reusable game objects
│   ├── Materials/        # Visual materials and textures
│   ├── Animations/       # Animation clips and controllers
│   ├── Audio/            # Sound effects and music
│   └── UI/               # UI sprites and assets
├── ProjectSettings/      # Unity project configuration
└── Packages/             # Package dependencies
```

## Scripts Overview

### Player Scripts
- **PlayerController.cs**: First-person movement and mouse look
- **HealthSystem.cs**: Health management for player and enemies
- **Weapon.cs**: Base weapon class with shooting mechanics
- **WeaponSwitcher.cs**: Switch between multiple weapons

### Enemy Scripts
- **EnemyAI.cs**: AI behavior (chase, attack, idle states)

### UI Scripts
- **UIManager.cs**: Manages all UI elements
- **MainMenu.cs**: Main menu navigation

### Manager Scripts
- **GameManager.cs**: Game state management and scene control

### Pickup Scripts
- **AmmoPickup.cs**: Collectible ammo
- **HealthPickup.cs**: Collectible health pack

### Utility Scripts
- **EnemySpawner.cs**: Spawns enemies at designated points

## Setup Instructions

### Prerequisites
- Unity 2022.3.62f1 or compatible version
- Windows PC for building

### Opening the Project
1. Clone this repository
2. Open Unity Hub
3. Click "Add" and select the project folder
4. Open the project with Unity 2022.3.62f1

### Creating the Game Scene

#### 1. Create Main Scene
1. Create a new scene: `File > New Scene > Basic (Built-in)`
2. Save as `Assets/Scenes/MainGame.unity`

#### 2. Setup Player
1. Create Empty GameObject, name it "Player"
2. Add `CharacterController` component
3. Add `PlayerController` script
4. Add `HealthSystem` script (check "Is Player")
5. Add `WeaponSwitcher` script
6. Create child "Main Camera" and position at (0, 0.6, 0)
7. Tag player as "Player"
8. Set layer to "Player"

#### 3. Setup Weapons
1. Create child empty GameObject under Player: "WeaponHolder"
2. Position at camera position
3. For each weapon:
   - Create child GameObject (e.g., "Pistol")
   - Add `Weapon` script
   - Configure weapon properties
   - Create "ShootPoint" child for muzzle position

#### 4. Setup Environment
1. Create plane for ground (scale 20, 1, 20)
2. Tag as "Ground"
3. Add materials and lighting
4. Build NavMesh: `Window > AI > Navigation > Bake`

#### 5. Setup Enemies
1. Create Capsule, name "Enemy"
2. Add `NavMeshAgent` component
3. Add `EnemyAI` script
4. Add `HealthSystem` script
5. Tag as "Enemy"
6. Set layer to "Enemy"
7. Save as Prefab

#### 6. Setup Enemy Spawner
1. Create Empty GameObject: "EnemySpawner"
2. Add `EnemySpawner` script
3. Assign enemy prefab
4. Create child empty GameObjects for spawn points
5. Assign spawn points to spawner

#### 7. Setup UI
1. Create Canvas (Screen Space - Overlay)
2. Add `UIManager` script to Canvas
3. Create UI elements:
   - Health Bar (Image with Fill)
   - Ammo Text (TextMeshProUGUI)
   - Crosshair (Image, center screen)
   - Game Over Panel (hidden by default)
4. Assign UI elements to UIManager

#### 8. Setup Game Manager
1. Create Empty GameObject: "GameManager"
2. Add `GameManager` script
3. Assign pause menu panel (optional)

#### 9. Configure Player Health Events
1. Select Player
2. In HealthSystem component, add event to OnHealthChanged
3. Drag UIManager and select `UpdateHealth(float)`

### Controls
- **WASD**: Movement
- **Mouse**: Look around
- **Left Mouse Button**: Shoot
- **R**: Reload
- **Space**: Jump
- **Left Shift**: Sprint
- **1/2/3**: Switch weapons
- **Mouse Wheel**: Cycle weapons
- **ESC**: Pause menu

### Building the Game
1. Go to `File > Build Settings`
2. Add MainGame scene to build
3. Select "Windows" platform
4. Click "Build" and choose output folder
5. Run the .exe file

## Gameplay Tips

### For Players
- Manage ammunition carefully
- Take cover when health is low
- Look for health and ammo pickups
- Use different weapons for different situations
- Keep moving to avoid enemy attacks

### For Developers
- Adjust enemy detection range in EnemyAI component
- Modify weapon damage and fire rate in Weapon component
- Change player speed and health in respective components
- Customize UI appearance in Canvas hierarchy
- Add more weapons by creating new Weapon GameObjects

## Extending the Game

### Adding New Weapons
1. Duplicate existing weapon GameObject
2. Rename and adjust properties
3. Add to WeaponSwitcher weapons array

### Adding New Enemy Types
1. Duplicate enemy prefab
2. Adjust EnemyAI parameters
3. Modify appearance and stats

### Adding Power-ups
1. Create new pickup script (similar to AmmoPickup)
2. Implement pickup logic
3. Add trigger collider

### Adding Levels
1. Create new scene
2. Setup environment and NavMesh
3. Add to Build Settings
4. Implement level progression in GameManager

## Technical Notes

### Performance Considerations
- Use object pooling for frequently spawned objects
- Optimize draw calls by batching materials
- Use LOD (Level of Detail) for distant objects
- Limit active enemy count

### Known Limitations
- Basic AI without advanced pathfinding
- Simple shooting mechanics (no bullet drop)
- No networked multiplayer
- Limited audio implementation

## Troubleshooting

### Common Issues

**Player can't move through level**
- Ensure NavMesh is properly baked
- Check for collider conflicts

**Weapons not shooting**
- Verify Camera.main is assigned
- Check if ammo is available
- Ensure Fire1 input is configured

**Enemies not chasing player**
- Player must be tagged as "Player"
- NavMesh must be baked
- Check detection range

**UI not updating**
- Verify UIManager singleton is in scene
- Check event connections in Inspector

## Credits

Created as a 2-week Unity semester project for learning game development fundamentals.

## License

This is an educational project. Feel free to use and modify for learning purposes.

## Future Enhancements

Potential additions for extended projects:
- Advanced weapon types (shotgun, sniper)
- Grenade throwing
- Enemy variety (ranged enemies)
- Boss battles
- Score system
- Save/load functionality
- Sound effects and music
- Particle effects
- More sophisticated AI
- Multiple levels
- Weapon upgrade system
