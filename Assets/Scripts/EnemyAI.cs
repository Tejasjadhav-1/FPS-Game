using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float detectionRange = 15f;
    [SerializeField] float eyeHight = 1f;
    [SerializeField] LayerMask obsticleLayer;
    bool playerDetected;
    Transform player;
    Transform playerEyeTransform;


    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerEyeTransform = player.GetComponentInChildren<Camera>().transform;
        
    }

    private void Update()
    {
        CheckPlayerDetection();
        if (playerDetected)
        {
            agent.SetDestination(player.position);
        }
        
    }

    private void CheckPlayerDetection()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        Vector3 eyePosition = transform.position + transform.up * eyeHight;

        Vector3 directionToPlayer = playerEyeTransform.position - eyePosition;

        bool blocked = Physics.Raycast(eyePosition, directionToPlayer, distance, obsticleLayer);

        Debug.DrawRay(eyePosition, directionToPlayer,Color.red);
        
        if(!blocked && (distance < detectionRange))
        {
           playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
