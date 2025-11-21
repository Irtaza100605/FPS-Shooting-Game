using UnityEngine;

/// <summary>
/// Base weapon class handling shooting, ammo, and weapon properties
/// </summary>
public class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private string weaponName = "Pistol";
    [SerializeField] private float damage = 25f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int reserveAmmo = 90;

    [Header("Weapon Components")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject impactEffect;

    [Header("Audio")]
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip reloadSound;

    private float nextFireTime = 0f;
    private AudioSource audioSource;
    private Camera playerCamera;

    void Start()
    {
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Shoot()
    {
        if (currentAmmo <= 0)
        {
            // Play empty clip sound
            return;
        }

        currentAmmo--;

        // Play muzzle flash
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // Play shoot sound
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // Perform raycast
        RaycastHit hit;
        Vector3 shootDirection = playerCamera.transform.forward;

        if (Physics.Raycast(playerCamera.transform.position, shootDirection, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // Check if hit enemy or damageable object
            HealthSystem healthSystem = hit.transform.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(damage);
            }

            // Spawn impact effect
            if (impactEffect != null)
            {
                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2f);
            }
        }

        // Update UI
        UIManager.Instance?.UpdateAmmo(currentAmmo, reserveAmmo);
    }

    public void Reload()
    {
        if (currentAmmo >= maxAmmo || reserveAmmo <= 0)
        {
            return;
        }

        // Play reload sound
        if (reloadSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(reloadSound);
        }

        int ammoNeeded = maxAmmo - currentAmmo;
        int ammoToReload = Mathf.Min(ammoNeeded, reserveAmmo);

        currentAmmo += ammoToReload;
        reserveAmmo -= ammoToReload;

        // Update UI
        UIManager.Instance?.UpdateAmmo(currentAmmo, reserveAmmo);
    }

    public void AddAmmo(int amount)
    {
        reserveAmmo += amount;
        UIManager.Instance?.UpdateAmmo(currentAmmo, reserveAmmo);
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public int GetReserveAmmo()
    {
        return reserveAmmo;
    }

    public string GetWeaponName()
    {
        return weaponName;
    }
}
