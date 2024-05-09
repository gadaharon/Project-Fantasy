using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    // THis will be replaced with an SO of the selected projectile
    [SerializeField] float damage;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Camera fpsCam;

    public void ShootProjectile()
    {
        Instantiate(projectile, spawnPoint.position, fpsCam.transform.rotation);
    }
}
