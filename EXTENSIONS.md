# Feature Extension Guide

Want to expand your FPS game beyond the basics? This guide shows you how to add new features step-by-step.

## 🎯 Easy Extensions (1-2 hours each)

### 1. Add a Shotgun Weapon

**New Script:** `Shotgun.cs` (inherits from Weapon)

```csharp
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private int pelletsPerShot = 8;
    [SerializeField] private float spreadAngle = 10f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 20f;
    
    public void ShootShotgun(Transform shootPoint, Camera playerCamera)
    {
        for (int i = 0; i < pelletsPerShot; i++)
        {
            // Calculate spread
            float spreadX = Random.Range(-spreadAngle, spreadAngle);
            float spreadY = Random.Range(-spreadAngle, spreadAngle);
            
            Vector3 direction = playerCamera.transform.forward;
            direction = Quaternion.Euler(spreadY, spreadX, 0) * direction;
            
            // Raycast for each pellet
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, direction, out hit, range))
            {
                HealthSystem health = hit.transform.GetComponent<HealthSystem>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
        }
    }
}
```

**Setup:**
1. Create new weapon object under WeaponHolder
2. Add this script instead of Weapon.cs
3. Configure pellet count and spread
4. Add to WeaponSwitcher array

---

### 2. Add Grenade Throwing

**New Script:** `Grenade.cs`

```csharp
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 3f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionDamage = 75f;
    [SerializeField] private GameObject explosionEffect;
    
    private float countdown;
    
    void Start()
    {
        countdown = explosionDelay;
    }
    
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Explode();
        }
    }
    
    void Explode()
    {
        // Show explosion effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        
        // Damage all objects in radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in colliders)
        {
            HealthSystem health = col.GetComponent<HealthSystem>();
            if (health != null)
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                float damageMultiplier = 1f - (distance / explosionRadius);
                health.TakeDamage(explosionDamage * damageMultiplier);
            }
        }
        
        Destroy(gameObject);
    }
}
```

**New Script:** `GrenadeThrow.cs` (attach to Player)

```csharp
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float throwForce = 20f;
    [SerializeField] private int grenadeCount = 3;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && grenadeCount > 0)
        {
            ThrowGrenade();
        }
    }
    
    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
        }
        grenadeCount--;
    }
}
```

---

### 3. Add a Sniper Scope (Zoom)

**Add to PlayerController.cs:**

```csharp
[Header("Zoom Settings")]
[SerializeField] private float normalFOV = 60f;
[SerializeField] private float zoomFOV = 20f;
[SerializeField] private float zoomSpeed = 10f;

private Camera playerCamera;
private bool isZooming = false;

void Start()
{
    playerCamera = Camera.main;
    // ... existing code
}

void Update()
{
    // ... existing code
    
    // Handle zoom
    if (Input.GetButton("Fire2")) // Right mouse button
    {
        isZooming = true;
    }
    else
    {
        isZooming = false;
    }
    
    // Smooth zoom
    float targetFOV = isZooming ? zoomFOV : normalFOV;
    playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
}
```

---

### 4. Add Footstep Sounds

**New Script:** `FootstepSound.cs`

```csharp
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController))]
public class FootstepSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepSounds;
    [SerializeField] private float footstepInterval = 0.5f;
    
    private AudioSource audioSource;
    private CharacterController controller;
    private float nextFootstep = 0f;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        // Play footstep if moving and grounded
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            if (Time.time >= nextFootstep)
            {
                PlayFootstep();
                nextFootstep = Time.time + footstepInterval;
            }
        }
    }
    
    void PlayFootstep()
    {
        if (footstepSounds.Length > 0)
        {
            AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
```

---

## 🎮 Medium Extensions (2-4 hours each)

### 5. Add Weapon Recoil

**Add to Weapon.cs in Shoot():**

```csharp
[Header("Recoil Settings")]
[SerializeField] private float recoilAmount = 2f;
[SerializeField] private float recoilSpeed = 10f;
[SerializeField] private float recoilRecoverySpeed = 5f;

private Vector3 currentRecoil;

private void Shoot()
{
    // ... existing shoot code
    
    // Apply recoil
    ApplyRecoil();
}

private void ApplyRecoil()
{
    currentRecoil += new Vector3(-recoilAmount, Random.Range(-recoilAmount, recoilAmount) * 0.3f, 0);
}

void LateUpdate()
{
    // Apply recoil to camera
    if (playerCamera != null)
    {
        playerCamera.transform.localRotation = Quaternion.Euler(currentRecoil);
        
        // Recover from recoil
        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, Time.deltaTime * recoilRecoverySpeed);
    }
}
```

---

### 6. Add Score System

**New Script:** `ScoreManager.cs`

```csharp
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    private int score = 0;
    private int kills = 0;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void AddScore(int points)
    {
        score += points;
        UIManager.Instance?.UpdateScore(score);
    }
    
    public void AddKill()
    {
        kills++;
        AddScore(100); // 100 points per kill
    }
    
    public int GetScore() => score;
    public int GetKills() => kills;
    
    public void ResetScore()
    {
        score = 0;
        kills = 0;
    }
}
```

**Modify EnemyAI.cs OnDeath():**

```csharp
private void OnDeath()
{
    // Add to existing code
    ScoreManager.Instance?.AddKill();
    
    // ... rest of OnDeath code
}
```

**Add to UIManager.cs:**

```csharp
[Header("Score UI")]
[SerializeField] private TextMeshProUGUI scoreText;

public void UpdateScore(int score)
{
    if (scoreText != null)
    {
        scoreText.text = "Score: " + score;
    }
}
```

---

### 7. Add Different Enemy Types

**New Script:** `RangedEnemy.cs`

```csharp
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootRange = 20f;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float projectileSpeed = 20f;
    
    private Transform player;
    private float nextFireTime = 0f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
    
    void Update()
    {
        if (player == null) return;
        
        float distance = Vector3.Distance(transform.position, player.position);
        
        if (distance <= shootRange && Time.time >= nextFireTime)
        {
            ShootAtPlayer();
            nextFireTime = Time.time + fireRate;
        }
    }
    
    void ShootAtPlayer()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        
        Vector3 direction = (player.position - shootPoint.position).normalized;
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }
}
```

**New Script:** `Projectile.cs`

```csharp
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 15f;
    [SerializeField] private float lifetime = 5f;
    
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
```

---

## 🏆 Advanced Extensions (4+ hours each)

### 8. Add Save/Load System

**New Script:** `SaveSystem.cs`

```csharp
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int level;
    public int score;
    public float playerHealth;
    public int currentWeapon;
}

public class SaveSystem : MonoBehaviour
{
    private string savePath;
    
    void Awake()
    {
        savePath = Application.persistentDataPath + "/savegame.json";
    }
    
    public void SaveGame()
    {
        SaveData data = new SaveData();
        
        // Gather data
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            HealthSystem health = player.GetComponent<HealthSystem>();
            data.playerHealth = health.GetCurrentHealth();
        }
        
        data.score = ScoreManager.Instance?.GetScore() ?? 0;
        data.level = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        
        // Save to file
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        
        Debug.Log("Game Saved!");
    }
    
    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            // Apply loaded data
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                HealthSystem health = player.GetComponent<HealthSystem>();
                health.Heal(data.playerHealth - health.GetCurrentHealth());
            }
            
            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.Log("No save file found!");
        }
    }
}
```

---

### 9. Add Minimap

**New Script:** `Minimap.cs`

```csharp
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float height = 20f;
    
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position;
            newPosition.y = height;
            transform.position = newPosition;
            
            // Keep rotation flat but follow player rotation
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
    }
}
```

**Setup:**
1. Create new Camera "MinimapCamera"
2. Add Minimap script
3. Set Culling Mask to only see Player/Enemy layers
4. Create RenderTexture for minimap
5. Add Raw Image to UI for display

---

### 10. Add Weapon Upgrade System

**New Script:** `WeaponUpgrade.cs`

```csharp
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    private Weapon weapon;
    
    [Header("Upgrade Costs")]
    [SerializeField] private int damageCost = 100;
    [SerializeField] private int fireRateCost = 150;
    [SerializeField] private int magazineCost = 75;
    
    void Start()
    {
        weapon = GetComponent<Weapon>();
    }
    
    public bool UpgradeDamage()
    {
        int currentScore = ScoreManager.Instance?.GetScore() ?? 0;
        if (currentScore >= damageCost)
        {
            // Increase damage by 10%
            // Access through reflection or make fields public
            ScoreManager.Instance?.AddScore(-damageCost);
            Debug.Log("Damage upgraded!");
            return true;
        }
        return false;
    }
    
    // Similar methods for other upgrades
}
```

---

## 📊 Feature Complexity Matrix

| Feature | Time | Difficulty | New Scripts | Prerequisites |
|---------|------|------------|-------------|---------------|
| Shotgun | 1h | Easy | 1 | Weapon system |
| Grenades | 2h | Easy | 2 | Physics |
| Zoom | 30min | Easy | 0 | Camera |
| Footsteps | 1h | Easy | 1 | Audio |
| Recoil | 2h | Medium | 0 | Weapon system |
| Score | 2h | Medium | 1 | UI |
| Ranged Enemy | 3h | Medium | 2 | AI, Physics |
| Save/Load | 4h | Hard | 1 | Serialization |
| Minimap | 3h | Hard | 1 | Camera, UI |
| Upgrades | 4h | Hard | 1 | Score, UI |

---

## 💡 Tips for Extensions

### Before Starting
1. ✅ Backup your project (copy entire folder)
2. ✅ Test existing features work
3. ✅ Read related documentation
4. ✅ Plan your implementation

### During Development
1. 🔍 Test incrementally
2. 📝 Comment your code
3. 🐛 Use Debug.Log liberally
4. 💾 Save often (Ctrl+S)

### After Completion
1. ✔️ Test all features together
2. 📚 Document changes
3. 🎮 Playtest thoroughly
4. 🔧 Refactor if needed

---

## 🎯 Suggested Learning Path

### Week 3: Polish
- Add footsteps
- Add weapon recoil
- Improve visual effects

### Week 4: Content
- Create new weapons
- Add new enemy types
- Design more levels

### Week 5: Systems
- Implement score system
- Add save/load
- Create main menu

### Week 6: Advanced
- Add minimap
- Implement upgrades
- Add achievements

---

**Remember:** Start small, test often, and have fun creating! 🎮
