using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour {
    // Cannot figure out why this public color system always sets it transparent 
    // using hard coded for now
    public Color32 defaultColor;
    public Color32 hoverColor;
    
	// Use this for initialization
	void Start () {
        defaultColor = Color.white;
        hoverColor = Color.red;
        GetComponent<Renderer>().material.color = defaultColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = hoverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = defaultColor;
    }
}
