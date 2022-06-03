using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public PlayerMeleeHitbox original;
    private const float MELEE_LIFETIME = 0.5f;
    private const float MAX_COOLDOWN = 1;
    private float cooldown = 0;

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetAxisRaw("Fire2") == 1) {
            if (cooldown <= 0) {
                Swing();
                cooldown = MAX_COOLDOWN;
            }
        }
    }

    void Swing()
    {
        Vector3 mouseOnWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 swingDirection = mouseOnWorld - transform.position;
        swingDirection.z = 0;
        float rotation_z = Mathf.Atan2(swingDirection.y, swingDirection.x) * Mathf.Rad2Deg;
        Quaternion swingRotation = Quaternion.Euler(0f, 0f, rotation_z);
        
        PlayerMeleeHitbox clone = Instantiate(original, transform.position, swingRotation);
        
        // offset the hitbox by half its width
        float width = original.GetComponent<BoxCollider2D>().bounds.size.x;
        Vector3 meleeOffset = swingRotation * new Vector3(width / 2, 0, 0);
        clone.transform.position += meleeOffset;

        // set destruction timer
        clone.willDestroy = true;
        clone.timeoutDestructor = MELEE_LIFETIME;
    }
}
