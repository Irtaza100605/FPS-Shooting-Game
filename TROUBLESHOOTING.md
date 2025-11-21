# Troubleshooting Guide - FPS Shooting Game

## 🚨 Common Issues & Solutions

### Project Setup Issues

#### ❌ Unity Version Mismatch
**Symptom:** Warning about Unity version when opening project

**Solution:**
- This project is built for Unity 2022.3.62f1
- Compatible with Unity 2022.3.x versions
- Download correct version from Unity Hub
- Upgrade may require asset reimport (5-10 minutes)

#### ❌ Missing Packages
**Symptom:** Console errors about missing namespaces (TextMeshPro, etc.)

**Solution:**
```
1. Window → Package Manager
2. Install: TextMeshPro (if missing)
3. Install: Input System (optional, using old system)
4. Wait for compilation
```

---

### Player Movement Issues

#### ❌ Player Falls Through Ground
**Symptom:** Player drops infinitely at game start

**Solution:**
1. Select ground plane/object
2. Add Component → Box Collider (or Mesh Collider)
3. Ensure ground is NOT on "Ignore Raycast" layer
4. Character Controller height should be > 1.0

#### ❌ Player Can't Move
**Symptom:** WASD keys don't move player

**Solution:**
1. Check PlayerController script is attached
2. Verify CharacterController component exists
3. Check Input settings:
   - Edit → Project Settings → Input Manager
   - Verify "Horizontal" and "Vertical" axes exist
4. Make sure game is not paused (Time.timeScale = 1)

#### ❌ Player Moves Too Fast/Slow
**Symptom:** Movement speed feels wrong

**Solution:**
- Select Player object
- PlayerController component:
  - Walk Speed: 5 (default)
  - Sprint Speed: 8 (default)
- Adjust to preference

#### ❌ Player Gets Stuck on Small Objects
**Symptom:** Character stops on tiny colliders

**Solution:**
- Character Controller → Step Offset: 0.3
- Remove colliders from decorative objects
- Use smoother collision geometry

---

### Camera & Mouse Issues

#### ❌ Camera Not Moving with Mouse
**Symptom:** Mouse movement doesn't rotate camera

**Solution:**
1. Check PlayerController script:
   - Camera Transform field assigned
2. Verify Camera is child of Player
3. Check Input Manager:
   - "Mouse X" and "Mouse Y" axes exist
   - Sensitivity: 0.1 (default)

#### ❌ Camera Rotation Inverted
**Symptom:** Mouse Y feels backwards

**Solution:**
- PlayerController.cs line ~77
- Change: `currentRotationX -= mouseY;`
- To: `currentRotationX += mouseY;`

#### ❌ Cursor Visible in Game
**Symptom:** Cursor shows during gameplay

**Solution:**
- PlayerController automatically locks cursor
- If not working, add to Start():
```csharp
Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;
```

#### ❌ Can't Exit Game (Cursor Locked)
**Symptom:** Can't click menu buttons

**Solution:**
- Press ESC for pause menu (auto-unlocks cursor)
- Or in code:
```csharp
Cursor.lockState = CursorLockMode.None;
Cursor.visible = true;
```

---

### Weapon & Shooting Issues

#### ❌ Weapon Doesn't Shoot
**Symptom:** Click but nothing happens

**Solution:**
1. Check Current Ammo > 0
2. Verify Camera.main exists (tag Main Camera)
3. Check Input Manager: "Fire1" button configured
4. Ensure Weapon script is attached and enabled
5. Check console for errors

#### ❌ Shooting But No Hit Detection
**Symptom:** Bullets don't damage enemies

**Solution:**
1. Enemy must have HealthSystem component
2. Enemy collider must be enabled
3. Check raycast range (default: 100)
4. Add Debug.DrawRay in Weapon.cs to visualize:
```csharp
Debug.DrawRay(playerCamera.transform.position, 
              shootDirection * range, 
              Color.red, 1f);
```

#### ❌ Weapon Not Visible
**Symptom:** Can't see gun in first person

**Solution:**
1. Weapon should be child of WeaponHolder
2. Position relative to camera:
   - X: 0.3 (right side)
   - Y: -0.2 (lower)
   - Z: 0.5 (forward)
3. Camera Clipping Planes → Near: 0.01

#### ❌ Can't Reload
**Symptom:** R key doesn't reload weapon

**Solution:**
1. Check reserve ammo > 0
2. Current ammo must be < max ammo
3. Verify R key input in InputManager
4. Check console for reload messages

#### ❌ Weapon Switch Not Working
**Symptom:** Number keys don't change weapons

**Solution:**
1. WeaponSwitcher component attached to Player
2. Weapons array properly filled in Inspector
3. Each weapon is a child GameObject
4. Only one weapon should be active at start

---

### Enemy AI Issues

#### ❌ Enemies Don't Move
**Symptom:** Enemies stand still

**Solution:**
1. **Bake NavMesh first!**
   - Window → AI → Navigation
   - Select ground objects
   - Object tab → ✓ Navigation Static
   - Bake tab → Bake
2. Enemy has NavMeshAgent component
3. Player has "Player" tag
4. Enemy placed on NavMesh (appears blue in Scene view)

#### ❌ Enemies Walk Through Walls
**Symptom:** AI ignores obstacles

**Solution:**
1. Walls must be included in NavMesh bake:
   - Select walls
   - ✓ Navigation Static
   - Re-bake NavMesh
2. Check NavMeshAgent settings:
   - Radius: 0.5
   - Height: 2.0

#### ❌ Enemies Don't Attack
**Symptom:** Enemies chase but don't damage player

**Solution:**
1. Check Attack Range (default: 2)
2. Player must have HealthSystem component
3. Player must be tagged "Player"
4. Check Attack Cooldown (default: 1.5s)

#### ❌ Enemies Die Instantly
**Symptom:** One shot kills all enemies

**Solution:**
- Enemy HealthSystem → Max Health: 50 (or higher)
- Check weapon damage isn't too high
- Verify TakeDamage is being called correctly

#### ❌ Enemy Spawner Not Working
**Symptom:** No enemies appear

**Solution:**
1. Enemy Prefab assigned in Inspector
2. Spawn Points array filled
3. Max Enemies > 0
4. Enemy prefab has all required components
5. Check console for spawn errors

---

### UI Issues

#### ❌ UI Not Visible
**Symptom:** Can't see health bar, ammo, etc.

**Solution:**
1. Canvas → Render Mode: Screen Space - Overlay
2. Canvas Scaler attached
3. UI elements are children of Canvas
4. Check UI elements are Active (checkbox in Inspector)
5. Event System exists in scene

#### ❌ Health Bar Not Updating
**Symptom:** Health bar stays full when taking damage

**Solution:**
1. UIManager → Health Bar field assigned
2. Player HealthSystem → OnHealthChanged event:
   - Add event listener
   - Drag Canvas (UIManager)
   - Select: UIManager.UpdateHealth
3. Health Bar Image → Image Type: Filled

#### ❌ Ammo Counter Shows Wrong Numbers
**Symptom:** Ammo display incorrect

**Solution:**
1. UIManager → Ammo Text field assigned
2. Weapon calls UIManager.UpdateAmmo()
3. Check UIManager.Instance is not null

#### ❌ Crosshair Not Centered
**Symptom:** Crosshair offset from screen center

**Solution:**
1. Crosshair RectTransform:
   - Anchor: Center
   - Pivot: (0.5, 0.5)
   - Pos X: 0, Pos Y: 0

#### ❌ Game Over Screen Won't Show
**Symptom:** Player dies but no game over

**Solution:**
1. UIManager → Game Over Panel assigned
2. Player → Health System → Is Player: ✓
3. GameManager.Instance exists in scene
4. Check OnDeath event in HealthSystem

---

### Performance Issues

#### ❌ Low Frame Rate
**Symptom:** Game runs slowly (< 30 FPS)

**Solution:**
1. Reduce enemy count (Max Enemies: 5)
2. Simplify geometry (use primitives)
3. Bake lighting (Window → Rendering → Lighting)
4. Reduce shadow quality (Quality Settings)
5. Profile with: Window → Analysis → Profiler

#### ❌ Memory Leak
**Symptom:** Memory usage keeps growing

**Solution:**
1. Destroy spawned objects properly
2. Use object pooling for enemies
3. Unsubscribe from events:
```csharp
void OnDestroy()
{
    healthSystem.OnDeath.RemoveListener(OnDeath);
}
```

#### ❌ Long Load Times
**Symptom:** Scene takes forever to load

**Solution:**
1. Reduce asset count
2. Compress textures
3. Use asset bundles
4. Async scene loading

---

### Build Issues

#### ❌ Build Fails
**Symptom:** Error during build process

**Solution:**
1. Check all scripts compile (no errors in Console)
2. File → Build Settings → Add scenes
3. Remove missing scenes from build
4. Clear Player Prefs before build
5. Try: Assets → Reimport All

#### ❌ Built Game Crashes
**Symptom:** .exe crashes on startup

**Solution:**
1. Check build logs: %APPDATA%\Unity\Editor.log
2. Ensure all required scenes included
3. Check graphics API compatibility
4. Test in editor first (no errors)

#### ❌ Controls Don't Work in Build
**Symptom:** Input doesn't work in .exe

**Solution:**
1. Check Input Manager settings saved
2. Verify key codes (KeyCode.W vs "w")
3. Test with Input.GetButton vs GetKey
4. Check player logs for errors

---

### Scene Setup Issues

#### ❌ Player Spawns in Wrong Place
**Symptom:** Player appears at unexpected location

**Solution:**
- Player GameObject Position: (0, 1, 0)
- Ensure no conflicting spawn scripts
- Check scene save

#### ❌ Lighting Too Dark
**Symptom:** Can't see anything

**Solution:**
1. Add Directional Light
2. Increase intensity (1-2)
3. Window → Rendering → Lighting → Generate Lighting

#### ❌ Audio Not Playing
**Symptom:** No sound effects

**Solution:**
1. Weapon → Audio Source component attached
2. Audio Clip assigned
3. Check Audio Listener on Camera
4. Verify volume > 0
5. Check audio files imported correctly

---

## 🔍 Debug Checklist

### Before Reporting Issues

- [ ] Unity Console checked for errors
- [ ] All required components attached
- [ ] Tags assigned correctly
- [ ] NavMesh baked (for AI)
- [ ] Input Manager configured
- [ ] Scene saved
- [ ] Project restarted
- [ ] Script recompiled

### Debug Commands

Add to Update() for testing:

```csharp
// Toggle debug info
if (Input.GetKeyDown(KeyCode.F1))
{
    Debug.Log($"Player Health: {GetComponent<HealthSystem>().GetCurrentHealth()}");
    Debug.Log($"Player Position: {transform.position}");
    Debug.Log($"Enemy Count: {GameObject.FindGameObjectsWithTag("Enemy").Length}");
}

// Unlock cursor
if (Input.GetKeyDown(KeyCode.F2))
{
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}

// God mode (no damage)
if (Input.GetKeyDown(KeyCode.F3))
{
    GetComponent<HealthSystem>().Heal(1000);
}
```

---

## 📞 Getting Help

### If Issue Persists

1. **Check Documentation:**
   - GAME_DOCUMENTATION.md
   - SETUP_GUIDE.md
   - README.md

2. **Unity Console:**
   - Read error messages carefully
   - Google error codes
   - Check line numbers in scripts

3. **Scene Validation:**
   - Verify setup matches SETUP_GUIDE.md
   - Compare with working example

4. **Community Resources:**
   - Unity Forums
   - Unity Answers
   - Stack Overflow
   - YouTube tutorials

5. **Debug Strategies:**
   - Add Debug.Log() statements
   - Use Unity Profiler
   - Test components individually
   - Start with fresh scene

---

## 🛠️ Prevention Tips

### Best Practices

✅ **Save Often:** Ctrl+S after changes
✅ **Test Incrementally:** Test after each major change
✅ **Version Control:** Use Git for backups
✅ **Name Clearly:** Use descriptive object names
✅ **Comment Code:** Explain complex logic
✅ **Keep Organized:** Use folders for assets
✅ **Regular Backups:** Copy project folder weekly

### Common Mistakes to Avoid

❌ Forgetting to save scene
❌ Not baking NavMesh after changes
❌ Missing component assignments
❌ Wrong tags/layers
❌ Camera not tagged "MainCamera"
❌ Scripts not attached
❌ Prefabs not updated after changes

---

**Remember:** Most issues are configuration problems, not code bugs. Double-check the setup guide!
