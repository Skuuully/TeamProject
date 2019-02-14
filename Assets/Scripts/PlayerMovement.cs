using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed;
    public float jumpHeight;
    public BoxCollider2D playerCollider;
    public BoxCollider2D rightWallCollider;
    public BoxCollider2D leftWallCollider;
    float horizontalMove;
    public float steadyRise;
    private bool jump;
    private bool facingRight;
    Vector2 velocity;
    public Rigidbody2D rb2d;
    private List<Vector2> velocities;

    // Use this for initialization
    void Start()
    {
        velocities = new List<Vector2>();
        horizontalMove = 0;
        jump = false;
        facingRight = true;

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        rightWallCollider = GameObject.FindGameObjectWithTag("Right Wall").GetComponent<BoxCollider2D>();
        leftWallCollider = GameObject.FindGameObjectWithTag("Left Wall").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if left shift or rmb is pressed level will restart
        if (Input.GetButtonDown("Fire3"))
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
        CalculatePlayerRise();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        CalculateFinalVelocity();
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

    // Makes the player jump to the opposite wall 
    void Jump()
    {
        if (jump == false)
        {
            if (playerCollider.IsTouching(rightWallCollider))
            {
                jump = true;
                for (int i = 0; i < 9; i++)
                {
                   // GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.left) * 250);
                    //transform.Translate(-1f, 0, 1f * Time.deltaTime, Space.World);
                    // CalculateVelocity(-9f * Time.deltaTime, 0f);
                    Vector2 v = new Vector2(-1, 0);
                    velocities.Add(v);

                }
                jump = false;
                FlipPlayer();
            }
            else if (playerCollider.IsTouching(leftWallCollider))
            {
                jump = true;
                for (int i = 0; i < 9; i++)
                {
                    //CalculateVelocity(1f *Time.deltaTime, 0);
                    Vector2 v = new Vector2(1, 0);
                    velocities.Add(v);
                    //transform.Translate(1f, 0, 1f * Time.deltaTime, Space.World);
                }
                jump = false;
                FlipPlayer();
            }
        }
    }

    // Flips the player sprite
    void FlipPlayer()
    {
        if (facingRight == true)
        {
            transform.localScale += new Vector3(-1, 0, 0);
            facingRight = false;
        }
        else if (facingRight == false)
        {
            transform.localScale += new Vector3(1, 0, 0);
            facingRight = true;
        }
    }

    //calculates the rise of the player
    void CalculatePlayerRise()
    {
        float y = steadyRise * Time.deltaTime;
        Vector2 upwards = new Vector2(0, y);
        velocities.Add(upwards);
    }

    // call anytime the velocity wants to be changed
    void CalculateFinalVelocity()
    {
        Vector2 v = new Vector2();
        for (int i = 0; i < velocities.Count; i++)
        {
            v += velocities[i];
        }
        rb2d.velocity = v;
        transform.Translate(v);
        velocities.Clear();
    }
}

