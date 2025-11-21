using UnityEngine;

/// <summary>
/// Ammo pickup that can be collected by the player
/// </summary>
public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 30;
    [SerializeField] private float rotationSpeed = 50f;

    void Update()
    {
        // Rotate the pickup for visual effect
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find weapon and add ammo
            WeaponSwitcher weaponSwitcher = other.GetComponent<WeaponSwitcher>();
            if (weaponSwitcher != null)
            {
                Weapon currentWeapon = weaponSwitcher.GetCurrentWeapon();
                if (currentWeapon != null)
                {
                    currentWeapon.AddAmmo(ammoAmount);
                    Debug.Log("Picked up " + ammoAmount + " ammo");
                    Destroy(gameObject);
                }
            }
        }
    }
}
