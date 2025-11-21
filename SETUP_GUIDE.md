# FPS Shooting Game - Quick Setup Guide

## For Developers (Setting up in Unity)

### Step 1: Open Project
1. Open Unity Hub
2. Click "Add" → Select this project folder
3. Open with Unity 2022.3.62f1

### Step 2: Create Main Game Scene
```
File → New Scene → Basic (Built-in)
Save as: Assets/Scenes/MainGame.unity
```

### Step 3: Setup Player (5 minutes)
1. **Create Player GameObject:**
   - GameObject → Create Empty → Name: "Player"
   - Add Component → Character Controller
   - Add Component → Player Controller (script)
   - Add Component → Health System (script) ✓ Check "Is Player"
   - Add Component → Weapon Switcher (script)
   - Tag: "Player"
   - Layer: "Player"

2. **Setup Camera:**
   - Right-click Player → 3D Object → Camera
   - Name: "Main Camera"
   - Position: (0, 0.6, 0)
   - Tag: "MainCamera"

3. **Configure Player Controller:**
   - Assign Camera Transform field → Drag Main Camera

### Step 4: Setup Weapon (5 minutes)
1. **Create Weapon Holder:**
   - Right-click Player → Create Empty → Name: "WeaponHolder"
   - Position: Same as camera (0, 0.6, 0)

2. **Create Pistol:**
   - Right-click WeaponHolder → 3D Object → Cube (scale 0.1, 0.1, 0.3)
   - Name: "Pistol"
   - Position: (0.3, -0.2, 0.5) for right-hand position
   - Add Component → Weapon (script)
   - Add Component → Audio Source

3. **Create Shoot Point:**
   - Right-click Pistol → Create Empty → Name: "ShootPoint"
   - Position: (0, 0, 0.5) for muzzle tip

4. **Configure Weapon:**
   - Weapon Name: "Pistol"
   - Damage: 25
   - Fire Rate: 0.5
   - Max Ammo: 12
   - Reserve Ammo: 60
   - Range: 100
   - Shoot Point: Drag ShootPoint

5. **Assign to Switcher:**
   - Select Player
   - Weapon Switcher → Weapons → Size: 1
   - Element 0: Drag Pistol

### Step 5: Setup Environment (5 minutes)
1. **Create Ground:**
   - GameObject → 3D Object → Plane
   - Scale: (20, 1, 20)
   - Position: (0, 0, 0)
   - Tag: "Ground"

2. **Add Lighting:**
   - GameObject → Light → Directional Light
   - Rotation: (50, -30, 0)

3. **Create Walls (Optional):**
   - GameObject → 3D Object → Cube
   - Scale for walls
   - Duplicate and position

4. **Bake NavMesh:**
   - Window → AI → Navigation
   - Select Ground plane
   - Navigation window → Object tab → ✓ Navigation Static
   - Navigation window → Bake tab → Bake

### Step 6: Setup Enemy (5 minutes)
1. **Create Enemy:**
   - GameObject → 3D Object → Capsule
   - Name: "Enemy"
   - Position: (5, 1, 5)
   - Tag: "Enemy"
   - Layer: "Enemy"

2. **Configure Enemy:**
   - Add Component → Nav Mesh Agent
   - Add Component → Enemy AI (script)
   - Add Component → Health System (script)
   - Health System: Max Health: 50

3. **Save as Prefab:**
   - Drag Enemy to Assets/Prefabs folder
   - Delete from scene

### Step 7: Setup Enemy Spawner (3 minutes)
1. **Create Spawner:**
   - GameObject → Create Empty → Name: "EnemySpawner"
   - Add Component → Enemy Spawner (script)

2. **Create Spawn Points:**
   - Right-click EnemySpawner → Create Empty → Name: "SpawnPoint1"
   - Position: (10, 0, 10)
   - Repeat for more points (SpawnPoint2, SpawnPoint3...)

3. **Configure Spawner:**
   - Enemy Prefab: Drag Enemy prefab from Prefabs folder
   - Spawn Points → Size: (number of spawn points)
   - Assign each spawn point

### Step 8: Setup UI (10 minutes)
1. **Create Canvas:**
   - GameObject → UI → Canvas
   - Add Component → UI Manager (script)

2. **Create Health Bar:**
   - Right-click Canvas → UI → Panel → Name: "HealthBar"
   - Position: Anchor bottom-left
   - Add child: UI → Image → Name: "HealthFill"
   - Health Fill: Image Type: Filled, Fill Method: Horizontal
   - Color: Red

3. **Create Ammo Text:**
   - Right-click Canvas → UI → Text - TextMeshPro
   - Name: "AmmoText"
   - Position: Anchor bottom-right
   - Text: "30 / 90"
   - Font Size: 36

4. **Create Crosshair:**
   - Right-click Canvas → UI → Image
   - Name: "Crosshair"
   - Anchor: Center
   - Width: 20, Height: 20
   - Color: White with alpha

5. **Create Game Over Panel:**
   - Right-click Canvas → UI → Panel → Name: "GameOverPanel"
   - Color: Black with 50% alpha
   - Add child: UI → Text - TextMeshPro → Name: "GameOverText"
   - Text: "Game Over"
   - Disable GameOverPanel

6. **Assign UI Manager Fields:**
   - Select Canvas
   - Health Bar: Drag HealthFill
   - Health Text: Drag AmmoText parent (if using)
   - Ammo Text: Drag AmmoText
   - Crosshair: Drag Crosshair
   - Game Over Panel: Drag GameOverPanel
   - Game Over Text: Drag GameOverText

### Step 9: Connect Health Events (2 minutes)
1. Select Player
2. Health System component → On Health Changed
3. Click + to add event
4. Drag Canvas (UIManager)
5. Function: UIManager → UpdateHealth

### Step 10: Setup Game Manager (2 minutes)
1. **Create Manager:**
   - GameObject → Create Empty → Name: "GameManager"
   - Add Component → Game Manager (script)

### Step 11: Test and Play! ✓
1. Press Play in Unity
2. Test movement (WASD)
3. Test look (Mouse)
4. Test shooting (Left Click)
5. Test reload (R)

## Common Issues & Fixes

### Player falls through ground
- Add Collider to ground plane
- Ensure ground is solid

### Can't shoot
- Check weapon ammo
- Verify Camera.main exists
- Check InputManager Fire1 binding

### Enemies don't move
- Ensure NavMesh is baked
- Check enemy is on NavMesh (blue area)
- Player must have "Player" tag

### UI doesn't show
- Check Canvas Render Mode: Screen Space - Overlay
- Verify UI elements are children of Canvas

### Cursor visible in game
- PlayerController automatically locks cursor
- Check if script is attached and enabled

## Quick Controls Reference
- WASD - Move
- Mouse - Look
- Left Click - Shoot
- R - Reload
- Space - Jump
- Left Shift - Sprint
- 1/2/3 - Weapon Switch
- ESC - Pause

## Next Steps
1. Add more enemies
2. Create health/ammo pickups
3. Add sound effects
4. Design multiple levels
5. Create main menu scene
6. Build and test standalone

## Build Instructions
1. File → Build Settings
2. Add Open Scenes (MainGame)
3. Platform: Windows
4. Click Build
5. Choose output folder
6. Run .exe

---
Total Setup Time: ~40 minutes
Ready to enhance and expand!
