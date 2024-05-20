using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    EnemyCombat enemyCombat;

    void Awake()
    {
        enemyCombat = GetComponentInParent<EnemyCombat>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyCombat.SetCanAttack(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyCombat.SetCanAttack(false);
        }
    }
}
