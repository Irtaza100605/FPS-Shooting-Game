using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Basic enemy AI that chases and attacks the player
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HealthSystem))]
public class EnemyAI : MonoBehaviour
{
    [Header("AI Settings")]
    [SerializeField] private float detectionRange = 15f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackCooldown = 1.5f;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float rotationSpeed = 5f;

    private NavMeshAgent agent;
    private Transform player;
    private HealthSystem healthSystem;
    private float nextAttackTime = 0f;
    private bool isDead = false;

    private enum EnemyState
    {
        Idle,
        Chasing,
        Attacking
    }

    private EnemyState currentState = EnemyState.Idle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        healthSystem = GetComponent<HealthSystem>();
        agent.speed = moveSpeed;

        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        // Subscribe to death event
        healthSystem.OnDeath.AddListener(OnDeath);
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Idle:
                if (distanceToPlayer <= detectionRange)
                {
                    currentState = EnemyState.Chasing;
                }
                break;

            case EnemyState.Chasing:
                ChasePlayer(distanceToPlayer);
                break;

            case EnemyState.Attacking:
                AttackPlayer(distanceToPlayer);
                break;
        }
    }

    private void ChasePlayer(float distance)
    {
        if (distance <= attackRange)
        {
            currentState = EnemyState.Attacking;
            agent.isStopped = true;
        }
        else if (distance <= detectionRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            currentState = EnemyState.Idle;
            agent.isStopped = true;
        }
    }

    private void AttackPlayer(float distance)
    {
        // Look at player
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        if (distance > attackRange)
        {
            currentState = EnemyState.Chasing;
            agent.isStopped = false;
            return;
        }

        // Attack player
        if (Time.time >= nextAttackTime)
        {
            PerformAttack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void PerformAttack()
    {
        if (player == null) return;

        HealthSystem playerHealth = player.GetComponent<HealthSystem>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Enemy attacked player for " + attackDamage + " damage");
        }
    }

    private void OnDeath()
    {
        isDead = true;
        agent.isStopped = true;
        
        // Disable collider
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        // Disable this script
        this.enabled = false;
    }

    void OnDrawGizmosSelected()
    {
        // Draw detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Draw attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
