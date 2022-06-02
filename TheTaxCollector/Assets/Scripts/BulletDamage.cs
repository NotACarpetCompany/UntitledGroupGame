using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage = 10;
    public bool friendly;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(friendly != collision.gameObject.GetComponent<CharacterHealth>().friendly){
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
