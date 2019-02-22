using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed;
    public float jumpHeight;
    public BoxCollider2D playerCollider;
    public BoxCollider2D rightWallCollider;
    public BoxCollider2D leftWallCollider;
    public float steadyRise;
    private bool jump;
    private bool facingRight;
    Vector2 velocity;
    public Rigidbody2D rb2d;
    private List<Vector2> velocities;
    public Animator animator;

    public Text scoreTextBox;
    public int score;

    // Use this for initialization
    void Start()
    {
        velocities = new List<Vector2>();
        jump = false;
        facingRight = true;

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        rightWallCollider = GameObject.FindGameObjectWithTag("Right Wall").GetComponent<BoxCollider2D>();
        leftWallCollider = GameObject.FindGameObjectWithTag("Left Wall").GetComponent<BoxCollider2D>();

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("Jump started");
            StartJump();
        }
        ContinueJump();
        // steady rise is what causes player to move upwards with camera
        CalculatePlayerRise();
        // if left shift or rmb is pressed level will restart
        if (Input.GetButtonDown("Fire3"))
        {
            Restart();
        }

        scoreTextBox.GetComponent<Text>().text = "Score: " + score.ToString();


        CalculateFinalVelocity();
    }

    void FixedUpdate()
    {

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

    public void IncreaseScore(int increase)
    {
        score += increase;
    }

    public void Restart()
    {
        // restarts the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Makes the player jump to the opposite wall 
    void StartJump()
    {
        if (jump == false)
        {
            animator.SetBool("Jump", true);
            if (playerCollider.IsTouching(rightWallCollider))
            {
                jump = true;
                Vector2 v = new Vector2(-1, 0);
                velocities.Add(v);
            }
            else if (playerCollider.IsTouching(leftWallCollider))
            {
                jump = true;
                Vector2 v = new Vector2(1, 0);
                velocities.Add(v);
            }
        }
    }

    void ContinueJump()
    {
        if(jump == true)
        {
            if(!facingRight)
            {
                Vector2 v = new Vector2(0.5f, 0);
                velocities.Add(v);
                Debug.Log("move right");
                if (playerCollider.IsTouching(rightWallCollider))
                {
                    jump = false;
                    animator.SetBool("Jump", false);
                    FlipPlayer();
                }
            }
            else
            {
                Vector2 v = new Vector2(-0.5f, 0);
                velocities.Add(v);
                Debug.Log("move left");
                if (playerCollider.IsTouching(leftWallCollider))
                {
                    jump = false;
                    animator.SetBool("Jump", false);
                    FlipPlayer();
                }
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

