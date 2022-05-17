using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 5;

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
