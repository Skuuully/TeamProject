using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    // use camera script to get its speed and then any modifiers to cameras speed will also apply to the killfloor
    public CameraFollow cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // if left shift or rmb is pressed level will restart
        if (Input.GetButtonDown("Fire3"))
        {
            RestartCurrentLevel();
        }
        // escape returns to title
        else if (Input.GetKey(KeyCode.Escape))
        {
            BackToTitle();
        }

        // only the kill floor object will rise or anything tagged as kill floor
        if(gameObject.tag == "Respawn")
        {
            Vector3 killMove = new Vector3(0, cam.trueRise, 0);
            transform.position += killMove;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            RestartCurrentLevel();
        }
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Main");
    }
}
