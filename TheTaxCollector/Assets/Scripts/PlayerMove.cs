using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public float speed = 5;
    public Animator animator;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        // Looks for right / left input
        horizontalMove = Input.GetAxisRaw("Horizontal");

        // Looks for up / down input
        verticalMove = Input.GetAxisRaw("Vertical");

        // Check if moving for animator
        animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(horizontalMove), Mathf.Abs(verticalMove)));


    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate () {

        // Move character
        float horDist = horizontalMove * speed * Time.fixedDeltaTime;
        float vertDist = verticalMove * speed * Time.fixedDeltaTime;
        Move(horDist, vertDist);
    }

    void Move (float horizontalDist, float verticalDist) {

        Vector3 totalMove  = new Vector3 (horizontalDist, verticalDist, 0);
        transform.position = transform.position + totalMove;
    }
}
