﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public float jumpHeight;
    float horizontalMove;
    public float steadyRise;
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
            Restart();
        }

        //allows horizontal movement
        horizontalMove = Input.GetAxis("Horizontal");

        // Pritters to do:
        // Add much better movement controls
    }

    void FixedUpdate()
    {
        // steady rise is what causes player to move upwards with camera
        velocity.Set(horizontalMove * playerSpeed * Time.deltaTime, steadyRise * Time.deltaTime);
        rb2d.velocity = (velocity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedUp"))
        {
            other.gameObject.SetActive(false);
        }
    }

    public void IncreaseSpeed(float increase)
    {
        //used so powerup blocks can increase the players speed
        steadyRise += increase;
    }

    public void Restart()
    {
        // restarts the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
