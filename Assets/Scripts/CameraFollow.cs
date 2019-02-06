using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    //speed for camera to rise
    public float speed;

    void Update()
    {
        Vector3 camMove = new Vector3(0, speed, 0);
        transform.position += camMove;
    }
}
