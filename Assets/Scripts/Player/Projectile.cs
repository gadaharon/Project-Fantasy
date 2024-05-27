using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float baseDamage = 5f;
    [SerializeField] float speed = 20f;
    [SerializeField] float duration = 3f;

    Rigidbody rb;
    float damage;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damage = baseDamage;
        Destroy(gameObject, duration);
    }

    void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    public void SetProjectileDamage(float damageEnhancer)
    {
        damage = Mathf.RoundToInt(Random.Range(baseDamage, baseDamage + damageEnhancer + 1));
    }

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamageable>()?.TakeDamage(damage);
        Destroy(gameObject);
    }

}
