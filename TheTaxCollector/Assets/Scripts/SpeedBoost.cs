using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private GameObject playerObj = null;
    private PlayerMove playerMoveScript;
    public float newSpeed;
 
    private void Start () {

        //Initiate Player Object
        playerObj = GameObject.Find("Player");
        playerMoveScript = playerObj.GetComponent<PlayerMove>();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   

        if(collision.gameObject.tag == "Player") {

            playerMoveScript.speed = newSpeed;
            Destroy(gameObject);
        }
    }
}
