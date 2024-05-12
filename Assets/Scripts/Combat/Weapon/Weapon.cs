using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] string tagToHit;

    [SerializeField] bool canDamage = false;

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
            Debug.Log($"Hit {tagToHit}");
            other.GetComponent<IDamageable>()?.TakeDamage(damage);
        }
    }
}
