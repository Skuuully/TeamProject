using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public float riseSpeed;          //speed for camera to rise
    public float extraRisePerSec;    // how much extra the camera should rise over the course of a second
    private float timer;             // tracks how long the level has been runinng
    public float trueRise;           // all camera rise components combined

    void Initialise()
    {
        // reset timer on initialise
        timer = 0;
    }

    void Update()
    {
        // adds the time of each frame to the timer keeping track of how long the level has been runinng
        timer += Time.deltaTime;
        CalculateTrueRise();
        Vector3 camMove = new Vector3(0, trueRise, 0);
        transform.position += camMove;
    }

    private void CalculateTrueRise()
    {
        trueRise = riseSpeed + (timer * extraRisePerSec);
    }
}
