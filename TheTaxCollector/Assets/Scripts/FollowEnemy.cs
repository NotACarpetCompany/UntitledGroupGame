using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    private GameObject playerObj = null;
 
    private void Start () {

        //Initiate Player Object
        playerObj = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Get the Screen positions of the enemy
        Vector2 enemyPosition = Camera.main.WorldToViewportPoint (transform.position);

        //Get the Screen positions of the player
        Vector2 playerPosition = (Vector2)Camera.main.WorldToViewportPoint(playerObj.transform.position);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(playerPosition, enemyPosition);

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
