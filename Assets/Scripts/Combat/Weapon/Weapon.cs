using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] string tagToHit;

    [SerializeField] bool canDamage = false;

    public Action<Collider, float> OnTargetHit;

    public void SetCanDamage(bool canDamage)
    {
        this.canDamage = canDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (tagToHit == null || tagToHit == "")
        {
            Debug.LogError($"tag: {tagToHit} is not a valid tag");
            return;
        }

        if (other.CompareTag(tagToHit) && canDamage)
        {
            AudioManager.Instance.PlaySwordHitSFX();
            Debug.Log($"Hit {tagToHit}");
            // other.GetComponent<IDamageable>()?.TakeDamage(damage);
            OnTargetHit?.Invoke(other, damage);
        }
    }
}
