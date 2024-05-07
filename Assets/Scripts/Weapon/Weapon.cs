using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && PlayerCombat.Instance.IsAttacking)
        {
            Debug.Log("Hit enemy");
        }
    }
}
