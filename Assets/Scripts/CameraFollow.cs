using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    //speed for camera to rise
    public float riseSpeed;

    void Update()
    {
        Vector3 camMove = new Vector3(0, riseSpeed, 0);
        transform.position += camMove;
    }
}
