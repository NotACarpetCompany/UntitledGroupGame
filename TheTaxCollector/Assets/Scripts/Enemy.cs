using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Bullet projectile;
    private float firingTimer = 0;
    private const float FIRING_INTERVAL = 1;
    private const float BULLET_SPEED = 5;
    private const int BULLET_LIFETIME = 5;
    
    // Shoot once right away
    void Start() {
        Shoot();
    }

    // Shoot every FIRING_INTERVAL seconds
    void Update()
    {
        firingTimer += Time.deltaTime;
        if (firingTimer >=  FIRING_INTERVAL) {
            Shoot();
            firingTimer = 0;
        }
    }

    void Shoot()
    {
        Bullet clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.speed = BULLET_SPEED;
        clone.direction = new Vector3(1, 0, 0).normalized;
        clone.timeoutDestructor = BULLET_LIFETIME;
        clone.willDestroy = true;
    }
}
