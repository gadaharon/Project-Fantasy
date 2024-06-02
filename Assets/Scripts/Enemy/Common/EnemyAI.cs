using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float detectionRange = 10f;
    [SerializeField] float tetherDistance = 20f;


    NavMeshAgent agent;
    EnemyAnimationHandler enemyAnimationHandler;
    Transform currentTarget;
    Vector3 startPosition;

    bool isTriggered = false;
    float resetTriggerTime = 5f;

    float distanceCheckInterval = 0.5f;
    bool aiEnabled;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnimationHandler = GetComponentInChildren<EnemyAnimationHandler>();
        aiEnabled = true;
    }

    void Start()
    {
        InvokeRepeating(nameof(DistanceCheck), 0, distanceCheckInterval);
        startPosition = transform.position;
    }

    void Update()
    {
        if (!aiEnabled) { return; }

        SyncAnimationAndAgent();

        if (currentTarget != null)
        {
            agent.destination = currentTarget.position;
            FaceTarget();
        }
        else if (agent.destination != startPosition)
        {
            agent.destination = startPosition;
        }
    }

    void SyncAnimationAndAgent()
    {
        enemyAnimationHandler.PlayEnemyMoveAnimation(agent.velocity.magnitude > 0.01);
    }


    void DistanceCheck()
    {
        if (target == null)
        {
            target = PlayerSettings.Instance.PlayerBody;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < detectionRange || isTriggered)
        {
            StartFollow();
        }
        else if (distance > tetherDistance)
        {
            StopFollow();
        }
    }

    void FaceTarget()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 direction = (currentTarget.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    public void TriggerEnemy()
    {
        if (!isTriggered)
        {
            StartCoroutine(TriggerEnemyRoutine());
        }
    }

    IEnumerator TriggerEnemyRoutine()
    {
        isTriggered = true;

        yield return new WaitForSeconds(resetTriggerTime);
        isTriggered = false; // reset trigger flag
    }


    void StartFollow()
    {
        if (target != null && currentTarget == null)
        {
            currentTarget = target;
        }
    }

    public void StopFollow()
    {
        currentTarget = null;
    }

    public void StopEnemyAI()
    {
        StopFollow();
        aiEnabled = false;
        agent.destination = transform.position;
        CancelInvoke(nameof(DistanceCheck));
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, detectionRange);
    // }
}
