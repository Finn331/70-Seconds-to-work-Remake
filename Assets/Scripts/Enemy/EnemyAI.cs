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
    [SerializeField] bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextPatrolPoint();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            Debug.Log("AI SEHARUSNYA MENGEJAR PEMAIN!");
            if (!isChasing)
            {
                isChasing = true;
                Debug.Log("AI mulai mengejar pemain!");
            }

            agent.SetDestination(player.position);
        }
        else
        {
            if (isChasing)
            {
                isChasing = false;
                Debug.Log("AI kehilangan pemain, kembali patroli.");
                GoToNextPatrolPoint();
            }
            else
            {
                Patrol();
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
        Vector3 rayOrigin = transform.position + Vector3.up * 1.5f; // Mulai raycast dari posisi lebih tinggi (kepala AI)

        // Debug garis untuk melihat jalur raycast di Scene
        Debug.DrawRay(rayOrigin, directionToPlayer * raycastDistance, Color.red);

        // Cek apakah pemain berada dalam Field of View (FOV)
        if (angleToPlayer < fieldOfView / 2)
        {
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, directionToPlayer, out hit, raycastDistance, ~obstacleMask))
            {
                Debug.Log("Raycast terkena: " + hit.transform.name);

                // Cek apakah objek yang terkena raycast memiliki tag "Player"
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.DrawRay(rayOrigin, directionToPlayer * raycastDistance, Color.green); // Jika mendeteksi player, ubah warna ray ke hijau
                    Debug.Log("Pemain TERDETEKSI oleh AI!");
                    return true;
                }
                else
                {
                    Debug.Log("AI melihat sesuatu yang lain: " + hit.transform.name);
                }
            }
            else
            {
                Debug.Log("Raycast tidak mengenai apa pun.");
            }
        }
        else
        {
            Debug.Log("Pemain di luar jangkauan FOV.");
        }

        return false;
    }



}
