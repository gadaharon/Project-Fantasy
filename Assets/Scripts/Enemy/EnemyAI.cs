using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float range = 10f;
    [SerializeField] float tetherDistance = 20f;


    NavMeshAgent agent;
    Transform currentTarget;
    Vector3 startPosition;

    bool isTriggered = false;
    float resetTriggerTime = 5f;

    float distanceCheckInterval = 0.5f;
    bool aiEnabled;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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

        if (currentTarget != null)
        {
            agent.destination = currentTarget.position;
        }
        else if (agent.destination != startPosition)
        {
            agent.destination = startPosition;
        }
    }


    void DistanceCheck()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < range || isTriggered)
        {
            StartFollow();
        }
        else if (distance > tetherDistance)
        {
            StopFollow();
        }
    }

    public void TriggerEnemy()
    {
        if (!isTriggered)
        {
            StartCoroutine(TriggerENemyRoutine());
        }
    }

    IEnumerator TriggerENemyRoutine()
    {
        isTriggered = true;

        yield return new WaitForSeconds(resetTriggerTime);
        isTriggered = false;
    }


    void StartFollow()
    {
        if (target != null && currentTarget == null)
        {
            currentTarget = target;
        }
    }

    void StopFollow()
    {
        currentTarget = null;
    }

    public void StopEnemyAI()
    {
        aiEnabled = false;
        CancelInvoke(nameof(DistanceCheck));
        StopFollow();
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, range);
    // }
}
