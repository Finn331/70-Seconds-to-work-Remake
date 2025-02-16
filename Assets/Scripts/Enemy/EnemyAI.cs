using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform player;
    public float chaseRange = 10f;
    public float fieldOfView = 60f; // Sudut penglihatan AI
    public float raycastDistance = 15f; // Jarak maksimal raycast
    public LayerMask obstacleMask; // Layer untuk mendeteksi penghalang

    private int currentPatrolIndex;
    private NavMeshAgent agent;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextPatrolPoint();
    }

    void Update()
    {
        if (isChasing)
        {
            if (CanSeePlayer())
            {
                agent.SetDestination(player.position);
            }
            else
            {
                isChasing = false;
                GoToNextPatrolPoint();
            }
        }
        else
        {
            Patrol();
            if (CanSeePlayer())
            {
                isChasing = true;
            }
        }
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPatrolPoint();
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer < fieldOfView / 2)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, raycastDistance, ~obstacleMask))
            {
                if (hit.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
