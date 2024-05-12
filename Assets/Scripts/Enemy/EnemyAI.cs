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

    float distanceCheckInterval = 0.5f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        InvokeRepeating(nameof(DistanceCheck), 0, distanceCheckInterval);
        startPosition = transform.position;
    }

    void Update()
    {
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

        if (distance < range)
        {
            StartFollow();
        }
        else if (distance > tetherDistance)
        {
            StopFollow();
        }
    }

    public void StartFollow()
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

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, range);
    // }
}
