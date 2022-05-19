using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightEnemy : MonoBehaviour
{

    public float speed;

    /* Direction of Player Movement
    * 1: right
    * 2: down
    * 3: left
    * 4: up
    */
    public float moveDirection;

    // FixedUpdate is called at a fixed interval
    void FixedUpdate () {

        float horDist = 0;
        float vertDist = 0;

        // Move character
        switch (moveDirection) {
            case 1:
                horDist = 1;
                break;
            case 2:
                vertDist = 1;
                break;
            case 3:
                horDist = -1;
                break;
            case 4:
                vertDist = -1;
                break;
            default:
                break;
        }

        horDist = horDist * speed * Time.fixedDeltaTime;
        vertDist = vertDist * speed * Time.fixedDeltaTime;
        Move(horDist, vertDist);
    }

    void Move (float horizontalDist, float verticalDist) {

        Vector3 totalMove  = new Vector3 (horizontalDist, verticalDist, 0);
        transform.position = transform.position + totalMove;
    }
}
