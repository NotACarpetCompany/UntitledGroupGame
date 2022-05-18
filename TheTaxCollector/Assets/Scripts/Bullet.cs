using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int timeoutDestructor;
    public bool willDestroy;

    void Start() {
        if (willDestroy) {
            Destroy(gameObject, timeoutDestructor);
        }
    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate () {

        // Move character
        float horDist = speed * Time.fixedDeltaTime;
        Move(horDist, 0);
    }

    void Move (float horizontalDist, float verticalDist) {

        Vector3 totalMove  = new Vector3 (horizontalDist, verticalDist, 0);
        transform.position = transform.position + totalMove;
    }
}
