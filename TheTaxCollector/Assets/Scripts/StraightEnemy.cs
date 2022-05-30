using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightEnemy : MonoBehaviour
{

    public float speed;
    private GameObject playerObj = null;
    public float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Initiate Player Object
        playerObj = GameObject.Find("Player");

        //Get the Screen positions of the enemy
        Vector2 enemyPosition = Camera.main.ScreenToWorldPoint (transform.position);

        //Get the Screen positions of the player
        Vector2 playerPosition = (Vector2)Camera.main.ScreenToWorldPoint(playerObj.transform.position);

        //Get the angle between the points
        angle = AngleBetweenTwoPoints(playerPosition, enemyPosition);

    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate () {

        float horDist = Mathf.Cos(angle) * speed * Time.fixedDeltaTime;
        float vertDist = Mathf.Sin(angle) * speed * Time.fixedDeltaTime;
        Move(horDist, vertDist);
    }

    void Move (float horizontalDist, float verticalDist) {

        Vector3 totalMove  = new Vector3 (horizontalDist, verticalDist, 0);
        transform.position = transform.position + totalMove;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x);
    }
}
