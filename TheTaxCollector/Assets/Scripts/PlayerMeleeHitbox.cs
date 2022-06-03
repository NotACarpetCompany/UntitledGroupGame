using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeHitbox : MonoBehaviour
{

    public float timeoutDestructor;
    public bool willDestroy;

    void Start() {
        if (willDestroy) {
            Destroy(gameObject, timeoutDestructor);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}
