using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Bullet projectile;
    private const float BULLET_SPEED = 5;
    private const int BULLET_LIFETIME = 5;
    public float max_cooldown;
    private float cooldown = 0;

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetAxisRaw("Fire1") == 1) {
            if (cooldown <= 0) {
                Shoot();
                cooldown = max_cooldown;
            }
        }
    }

    void Shoot()
    {
        Vector3 mouseOnWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 bulletDirection = mouseOnWorld - transform.position;
        bulletDirection.z = 0;
        float rotation_z = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, rotation_z);
        
        Bullet clone = Instantiate(projectile, transform.position, bulletRotation);
        clone.speed = BULLET_SPEED;
        clone.direction = bulletDirection.normalized;
        clone.timeoutDestructor = BULLET_LIFETIME;
        clone.willDestroy = true;
    }
}
