using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public int timeoutDestructor;
    public bool willDestroy;

    void Start() {
        if (willDestroy) {
            Destroy(gameObject, timeoutDestructor);
        }
    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate () {
        Move();
    }

    void Move() {
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }
}
