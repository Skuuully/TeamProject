using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public bool isQuit;
    public bool isLevels;
    public bool isInfinite;
    public bool isSettings;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUp()
    {
        if(isLevels)
        {
            SceneManager.LoadScene("Levels");
        }
        else if(isQuit)
        {
            Application.Quit();
        }
        else if(isSettings)
        {

        }
        else if(isInfinite)
        {

        }
    }
}
