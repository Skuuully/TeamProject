using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {

    public float speedIncrease;
    public int scoreIncrease;
    public PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

    }

    //when a collision happens
    public void OnCollisionEnter2D(Collision2D col)
    {
        // if collides with player
        if (col.gameObject.tag == "Player")
        {
            if(tag == "SpeedUp")
            {
                //increase the players speed by whatever the float is set to.
                playerMovement.IncreaseSpeed(speedIncrease);
            }
            else if(tag == "ScoreUp")
            {
                playerMovement.IncreaseScore(scoreIncrease);
            }
            Destroy(gameObject);
        }

    }
}
