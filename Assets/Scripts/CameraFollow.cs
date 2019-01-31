using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // player = the player
    public Transform player;
    // offset is how much the camera should be set away from the player
    public Vector3 offset;
    // step should be between 0 and 10 as interpolates based on this step value
    public float step;

    //LateUpdate runs after update therefore is after any player movement has happened
    void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(player.position, player.position + offset, step * Time.deltaTime);
        transform.position = newPosition;

        transform.LookAt(player);
    }
}
