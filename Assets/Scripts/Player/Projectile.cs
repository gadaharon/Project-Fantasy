using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float speed = 20f;
    [SerializeField] float duration = 3f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, duration);
    }

    void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        other.GetComponent<IDamageable>()?.TakeDamage(damage);
        Destroy(gameObject);
    }

}
