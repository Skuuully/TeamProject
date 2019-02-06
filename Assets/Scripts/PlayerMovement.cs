using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public float jumpHeight;
    float horizontalMove;
    public float verticalSpeed;
    bool jump;
    Vector2 velocity;
    public Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        horizontalMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if left shift or rmb is pressed level will restart
        if(Input.GetButtonDown("Fire3"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        horizontalMove = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        velocity.Set(horizontalMove * playerSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime);
        rb2d.velocity = (velocity);
    }

}
