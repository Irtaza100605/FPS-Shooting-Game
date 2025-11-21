using UnityEngine;

/// <summary>
/// Handles switching between multiple weapons
/// </summary>
public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    private int currentWeaponIndex = 0;

    void Start()
    {
        // Initialize weapons
        if (weapons.Length > 0)
        {
            SelectWeapon(0);
        }
    }

    void Update()
    {
        // Weapon switching with number keys
        if (Input.GetKeyDown(KeyCode.Alpha1) && weapons.Length >= 1)
        {
            SelectWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length >= 2)
        {
            SelectWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Length >= 3)
        {
            SelectWeapon(2);
        }

        // Mouse wheel switching
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            SelectNextWeapon();
        }
        else if (scroll < 0f)
        {
            SelectPreviousWeapon();
        }
    }

    private void SelectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length) return;

        // Deactivate all weapons
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == index);
        }

        currentWeaponIndex = index;

        // Update UI with current weapon info
        if (weapons[index] != null)
        {
            UIManager.Instance?.UpdateAmmo(weapons[index].GetCurrentAmmo(), weapons[index].GetReserveAmmo());
        }
    }

    private void SelectNextWeapon()
    {
        int nextIndex = (currentWeaponIndex + 1) % weapons.Length;
        SelectWeapon(nextIndex);
    }

    private void SelectPreviousWeapon()
    {
        int prevIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
        SelectWeapon(prevIndex);
    }

    public Weapon GetCurrentWeapon()
    {
        if (currentWeaponIndex >= 0 && currentWeaponIndex < weapons.Length)
        {
            return weapons[currentWeaponIndex];
        }
        return null;
    }
}
