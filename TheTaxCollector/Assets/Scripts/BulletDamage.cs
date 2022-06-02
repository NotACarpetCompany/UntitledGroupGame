using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(damage);

    }
}
