using UnityEngine;

/// <summary>
/// Health pickup that can be collected by the player
/// </summary>
public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healAmount = 25f;
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
            HealthSystem healthSystem = other.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.Heal(healAmount);
                Debug.Log("Healed for " + healAmount + " health");
                Destroy(gameObject);
            }
        }
    }
}
