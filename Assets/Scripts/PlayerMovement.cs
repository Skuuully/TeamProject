using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public float jumpHeight;
    float horizontalMove;
    float verticalMove;
    bool jump;
    Vector2 velocity;
    public Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        horizontalMove = 0;
        verticalMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetButton("Jump"))
        {
            verticalMove = 0;
        }
        else
        {
            verticalMove = jumpHeight;
        }
        horizontalMove = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        velocity.Set(horizontalMove * playerSpeed * Time.deltaTime, verticalMove * Time.deltaTime);
        rb2d.velocity = (velocity);
    }
}
