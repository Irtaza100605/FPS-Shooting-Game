# FPS Game - Implementation Checklist

Use this checklist to track your progress as you build the game.

## 📋 Phase 1: Project Setup (Day 1)

### Initial Setup
- [ ] Clone/download repository
- [ ] Install Unity 2022.3.62f1
- [ ] Open project in Unity Hub
- [ ] Verify no console errors
- [ ] Read SETUP_GUIDE.md

**Time Estimate:** 30 minutes

---

## 🎮 Phase 2: Player Setup (Day 1-2)

### Player GameObject
- [ ] Create empty GameObject named "Player"
- [ ] Add CharacterController component
- [ ] Add PlayerController script
- [ ] Add HealthSystem script (check "Is Player")
- [ ] Add WeaponSwitcher script
- [ ] Set Tag to "Player"
- [ ] Set Layer to "Player"
- [ ] Position at (0, 1, 0)

### Camera Setup
- [ ] Create Camera as child of Player
- [ ] Name it "Main Camera"
- [ ] Tag as "MainCamera"
- [ ] Position at (0, 0.6, 0)
- [ ] Assign to PlayerController's Camera Transform field

### Player Testing
- [ ] Press Play
- [ ] Test WASD movement
- [ ] Test mouse look (up/down/left/right)
- [ ] Test jumping (Space)
- [ ] Test sprinting (Left Shift)
- [ ] Verify cursor locks in play mode

**Time Estimate:** 1 hour

---

## 🔫 Phase 3: Weapon Setup (Day 2)

### Weapon Holder
- [ ] Create empty GameObject under Player
- [ ] Name "WeaponHolder"
- [ ] Position at (0, 0.6, 0) - same as camera

### First Weapon (Pistol)
- [ ] Create Cube under WeaponHolder (scale: 0.1, 0.1, 0.3)
- [ ] Name "Pistol"
- [ ] Position at (0.3, -0.2, 0.5)
- [ ] Add Weapon script
- [ ] Add AudioSource component
- [ ] Create child empty GameObject "ShootPoint"
- [ ] Position ShootPoint at (0, 0, 0.5)

### Weapon Configuration
- [ ] Weapon Name: "Pistol"
- [ ] Damage: 25
- [ ] Fire Rate: 0.5
- [ ] Max Ammo: 12
- [ ] Reserve Ammo: 60
- [ ] Range: 100
- [ ] Assign ShootPoint to Shoot Point field

### Weapon Switcher Setup
- [ ] Select Player
- [ ] WeaponSwitcher → Weapons → Size: 1
- [ ] Assign Pistol to Element 0

### Weapon Testing
- [ ] Press Play
- [ ] Test left mouse click (should shoot)
- [ ] Watch ammo counter decrease
- [ ] Test reload (R key)
- [ ] Check console for "Hit: ..." messages
- [ ] Test weapon switching (1 key)

**Time Estimate:** 1 hour

---

## 🌍 Phase 4: Environment Setup (Day 2-3)

### Ground
- [ ] Create 3D Object → Plane
- [ ] Name "Ground"
- [ ] Scale: (20, 1, 20)
- [ ] Position: (0, 0, 0)
- [ ] Tag: "Ground"
- [ ] Add material (optional)

### Lighting
- [ ] Create Light → Directional Light
- [ ] Name "Sun"
- [ ] Rotation: (50, -30, 0)
- [ ] Intensity: 1

### Walls/Obstacles (Optional)
- [ ] Create 3D Object → Cube for walls
- [ ] Scale and position as needed
- [ ] Add materials
- [ ] Ensure all have colliders

### NavMesh Baking
- [ ] Select Ground plane
- [ ] Window → AI → Navigation
- [ ] Object tab → Check "Navigation Static"
- [ ] Select all walls/obstacles
- [ ] Check "Navigation Static" for each
- [ ] Bake tab → Click "Bake"
- [ ] Verify blue NavMesh appears in Scene view

**Time Estimate:** 1 hour

---

## 👾 Phase 5: Enemy Setup (Day 3)

### Enemy GameObject
- [ ] Create 3D Object → Capsule
- [ ] Name "Enemy"
- [ ] Position: (5, 1, 5) - on NavMesh
- [ ] Tag: "Enemy"
- [ ] Layer: "Enemy"

### Enemy Components
- [ ] Add NavMeshAgent component
- [ ] Add EnemyAI script
- [ ] Add HealthSystem script
- [ ] Configure NavMeshAgent Speed: 3.5

### Enemy Configuration
- [ ] EnemyAI:
  - [ ] Detection Range: 15
  - [ ] Attack Range: 2
  - [ ] Attack Damage: 10
  - [ ] Move Speed: 3.5
- [ ] HealthSystem:
  - [ ] Max Health: 50
  - [ ] Is Player: unchecked

### Create Enemy Prefab
- [ ] Drag Enemy to Assets/Prefabs folder
- [ ] Delete Enemy from scene (spawner will create them)

### Enemy Testing
- [ ] Temporarily place enemy in scene
- [ ] Press Play
- [ ] Verify enemy chases player
- [ ] Verify enemy attacks when close
- [ ] Verify enemy takes damage when shot
- [ ] Verify enemy dies at 0 health
- [ ] Remove test enemy

**Time Estimate:** 1 hour

---

## 📦 Phase 6: Enemy Spawner (Day 3)

### Spawner GameObject
- [ ] Create empty GameObject
- [ ] Name "EnemySpawner"
- [ ] Add EnemySpawner script

### Spawn Points
- [ ] Create empty GameObject under EnemySpawner
- [ ] Name "SpawnPoint1"
- [ ] Position: (10, 0, 10)
- [ ] Repeat for SpawnPoint2, SpawnPoint3, etc.
- [ ] Place at various locations (on NavMesh)

### Spawner Configuration
- [ ] Assign Enemy prefab to Enemy Prefab field
- [ ] Set Spawn Points → Size: (number of spawn points)
- [ ] Assign each SpawnPoint to array
- [ ] Max Enemies: 5
- [ ] Spawn Interval: 5
- [ ] Auto Spawn: checked

### Spawner Testing
- [ ] Press Play
- [ ] Verify enemies spawn at spawn points
- [ ] Verify max enemies limit works
- [ ] Verify new enemies spawn after kills
- [ ] Check enemy behavior after spawning

**Time Estimate:** 30 minutes

---

## 🎨 Phase 7: UI Setup (Day 3-4)

### Canvas Setup
- [ ] Create UI → Canvas
- [ ] Name "Canvas"
- [ ] Canvas → Render Mode: Screen Space - Overlay
- [ ] Add UIManager script to Canvas
- [ ] Verify EventSystem exists

### Health Bar
- [ ] Create UI → Panel under Canvas
- [ ] Name "HealthBarBackground"
- [ ] Anchor: Bottom-left
- [ ] Position: (50, 50) from corner
- [ ] Size: (200, 30)
- [ ] Create child: UI → Image
- [ ] Name "HealthBarFill"
- [ ] Color: Red
- [ ] Image Type: Filled
- [ ] Fill Method: Horizontal

### Ammo Display
- [ ] Create UI → Text - TextMeshPro
- [ ] Name "AmmoText"
- [ ] Anchor: Bottom-right
- [ ] Position: (-50, 50) from corner
- [ ] Text: "30 / 90"
- [ ] Font Size: 36
- [ ] Alignment: Right

### Crosshair
- [ ] Create UI → Image
- [ ] Name "Crosshair"
- [ ] Anchor: Center
- [ ] Position: (0, 0)
- [ ] Size: (20, 20)
- [ ] Color: White (with transparency if desired)
- [ ] Import crosshair sprite (or use + symbol)

### Game Over Panel
- [ ] Create UI → Panel
- [ ] Name "GameOverPanel"
- [ ] Anchor: Full screen
- [ ] Color: Black with 50% alpha
- [ ] Create child: UI → Text - TextMeshPro
- [ ] Name "GameOverText"
- [ ] Text: "Game Over"
- [ ] Font Size: 72
- [ ] Alignment: Center
- [ ] Position at screen center
- [ ] Disable GameOverPanel GameObject

### UI Manager Configuration
- [ ] Select Canvas
- [ ] Assign HealthBarFill to Health Bar field
- [ ] Assign AmmoText to Ammo Text field
- [ ] Assign Crosshair to Crosshair field
- [ ] Assign GameOverPanel to Game Over Panel field
- [ ] Assign GameOverText to Game Over Text field

### Health Event Connection
- [ ] Select Player
- [ ] HealthSystem component → On Health Changed
- [ ] Click + button
- [ ] Drag Canvas to object field
- [ ] Select: UIManager → UpdateHealth

### UI Testing
- [ ] Press Play
- [ ] Shoot to verify ammo decreases
- [ ] Reload to verify ammo updates
- [ ] Take damage to verify health bar decreases
- [ ] Die to verify game over screen appears
- [ ] Verify crosshair is visible

**Time Estimate:** 2 hours

---

## 🎯 Phase 8: Game Manager (Day 4)

### Manager Setup
- [ ] Create empty GameObject
- [ ] Name "GameManager"
- [ ] Add GameManager script

### Pause Menu (Optional)
- [ ] Create UI → Panel under Canvas
- [ ] Name "PauseMenuPanel"
- [ ] Add pause menu buttons
- [ ] Disable by default
- [ ] Assign to GameManager

### Manager Testing
- [ ] Press Play
- [ ] Press ESC to pause
- [ ] Verify game stops (Time.timeScale = 0)
- [ ] Verify cursor unlocks
- [ ] Press ESC again to unpause
- [ ] Die to verify game over handling

**Time Estimate:** 30 minutes

---

## 🎁 Phase 9: Pickups (Day 4)

### Health Pickup
- [ ] Create 3D Object → Cube
- [ ] Name "HealthPickup"
- [ ] Scale: (0.5, 0.5, 0.5)
- [ ] Add HealthPickup script
- [ ] Add Sphere Collider
- [ ] Set collider to Trigger: checked
- [ ] Set Heal Amount: 25
- [ ] Add material (green color)
- [ ] Position in level
- [ ] Save as prefab

### Ammo Pickup
- [ ] Create 3D Object → Cube
- [ ] Name "AmmoPickup"
- [ ] Scale: (0.5, 0.3, 0.3)
- [ ] Add AmmoPickup script
- [ ] Add Box Collider
- [ ] Set collider to Trigger: checked
- [ ] Set Ammo Amount: 30
- [ ] Add material (yellow color)
- [ ] Position in level
- [ ] Save as prefab

### Pickup Testing
- [ ] Press Play
- [ ] Walk over health pickup
- [ ] Verify health increases
- [ ] Walk over ammo pickup
- [ ] Verify ammo increases
- [ ] Verify pickups disappear after collection

**Time Estimate:** 30 minutes

---

## 🎵 Phase 10: Audio (Day 5) - Optional

### Weapon Sounds
- [ ] Import weapon sound effects
- [ ] Select Weapon
- [ ] Assign shoot sound to Shoot Sound field
- [ ] Assign reload sound to Reload Sound field

### Enemy Sounds
- [ ] Import enemy sounds (optional)
- [ ] Add AudioSource to enemy prefab
- [ ] Configure sounds in EnemyAI

### Background Music
- [ ] Import music file
- [ ] Create empty GameObject "MusicManager"
- [ ] Add AudioSource
- [ ] Assign music clip
- [ ] Set Loop: checked
- [ ] Set Play On Awake: checked

**Time Estimate:** 1 hour

---

## 🎨 Phase 11: Visual Polish (Day 5-6) - Optional

### Particle Effects
- [ ] Create muzzle flash particle system
- [ ] Assign to weapon Muzzle Flash field
- [ ] Create impact effect
- [ ] Assign to weapon Impact Effect field

### Materials
- [ ] Create materials for weapons
- [ ] Create materials for enemies
- [ ] Create materials for environment
- [ ] Apply to respective objects

### Lighting
- [ ] Adjust directional light
- [ ] Add point lights if needed
- [ ] Window → Rendering → Lighting → Generate Lighting
- [ ] Adjust skybox (optional)

**Time Estimate:** 2 hours

---

## 🏗️ Phase 12: Additional Weapons (Day 6) - Optional

### Second Weapon (Rifle)
- [ ] Duplicate Pistol
- [ ] Rename to "Rifle"
- [ ] Adjust visual (longer cube)
- [ ] Configure weapon:
  - [ ] Damage: 30
  - [ ] Fire Rate: 0.1
  - [ ] Max Ammo: 30
  - [ ] Reserve Ammo: 120
- [ ] Increase WeaponSwitcher array size to 2
- [ ] Assign Rifle to Element 1
- [ ] Test weapon switching (1 and 2 keys)

### Third Weapon (Optional)
- [ ] Create or duplicate weapon
- [ ] Configure unique properties
- [ ] Add to WeaponSwitcher
- [ ] Test switching

**Time Estimate:** 1 hour per weapon

---

## 🧪 Phase 13: Testing & Debugging (Day 7)

### Functional Testing
- [ ] All player movements work
- [ ] All weapons fire correctly
- [ ] Enemies spawn and behave properly
- [ ] UI updates correctly
- [ ] Pickups work
- [ ] Game over triggers properly
- [ ] Pause menu works

### Balance Testing
- [ ] Player health feels right
- [ ] Enemy damage appropriate
- [ ] Weapon damage balanced
- [ ] Enemy spawn rate reasonable
- [ ] Ammo availability adequate

### Bug Checking
- [ ] No console errors
- [ ] No null reference exceptions
- [ ] No missing component warnings
- [ ] All scripts compile
- [ ] Scene saves properly

### Performance Testing
- [ ] Frame rate acceptable (>30 FPS)
- [ ] No lag with multiple enemies
- [ ] Memory usage stable
- [ ] No memory leaks

**Time Estimate:** 2 hours

---

## 📦 Phase 14: Build (Day 7)

### Build Preparation
- [ ] Save all scenes
- [ ] File → Build Settings
- [ ] Add MainGame scene
- [ ] Verify scene order
- [ ] Select Platform: Windows
- [ ] Architecture: x86_64

### Build Settings
- [ ] Development Build: unchecked (for release)
- [ ] Compression Method: LZ4 or Default
- [ ] Player Settings:
  - [ ] Company Name
  - [ ] Product Name
  - [ ] Icon (optional)
  - [ ] Resolution settings

### Build Process
- [ ] Click "Build"
- [ ] Choose output folder
- [ ] Wait for build to complete
- [ ] Test the .exe file
- [ ] Verify all features work in build

### Distribution
- [ ] Zip build folder
- [ ] Include README
- [ ] Test on different PC (if possible)

**Time Estimate:** 1 hour

---

## 📚 Phase 15: Documentation (Day 7)

### Code Comments
- [ ] Add comments to complex functions
- [ ] Document public variables
- [ ] Explain algorithms

### Project Documentation
- [ ] Update README with your changes
- [ ] Document custom features
- [ ] List known issues
- [ ] Add screenshots (optional)

### User Guide
- [ ] Write control instructions
- [ ] Explain game objectives
- [ ] List requirements

**Time Estimate:** 1 hour

---

## ✅ Final Checklist

### Must-Have Features
- [ ] Player movement (WASD)
- [ ] Mouse look
- [ ] Weapon shooting
- [ ] Enemy AI
- [ ] Health system
- [ ] Ammo system
- [ ] Basic UI
- [ ] Game over screen

### Nice-to-Have Features
- [ ] Multiple weapons
- [ ] Enemy spawning
- [ ] Pickups
- [ ] Sound effects
- [ ] Pause menu
- [ ] Visual effects
- [ ] Main menu

### Quality Checks
- [ ] No critical bugs
- [ ] Acceptable performance
- [ ] Clear UI
- [ ] Responsive controls
- [ ] Balanced gameplay
- [ ] Complete documentation

---

## 📊 Progress Tracking

**Total Phases:** 15
**Completed:** _____
**Remaining:** _____

**Estimated Total Time:** 20-30 hours
**Your Time Spent:** _____ hours

---

## 🎉 Completion Certificate

Once all must-have features are checked:

```
I, __________________, have successfully completed
the Unity FPS Shooting Game project.

Date: __________
Features Completed: _____/8
Additional Features: _____
Total Time: _____ hours

Signature: __________________
```

---

**Tips:**
- Check off items as you complete them
- Take breaks every 2 hours
- Save often (Ctrl+S)
- Test frequently
- Ask for help when stuck
- Document your progress

Good luck with your project! 🎮
