using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireInterval = 1f;
    public float bulletSpeed = 10f;
    private float time = 0f;
    void Update()
    {
        time+= Time.deltaTime;
        if (time >= fireInterval)
        {
            Shoot();
            time = 0f;
        }
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.transform.rotation = transform.rotation;
    }
}
