using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoost : MonoBehaviour
{
    private GameObject playerObj = null;
    private PlayerShoot playerShootScript;
    public float newCooldown;
 
    private void Start () {

        //Initiate Player Object
        playerObj = GameObject.Find("Player");
        playerShootScript = playerObj.GetComponent<PlayerShoot>();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   

        if(collision.gameObject.tag == "Player") {

            playerShootScript.max_cooldown = newCooldown;
            Destroy(gameObject);
        }
    }
}
