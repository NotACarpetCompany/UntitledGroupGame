using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + new Vector;
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}