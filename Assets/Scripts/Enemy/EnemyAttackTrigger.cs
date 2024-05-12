using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public bool CanAttack { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanAttack = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanAttack = false;
        }
    }
}
