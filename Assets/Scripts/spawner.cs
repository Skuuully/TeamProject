using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // how often to spawn block or damager
    public float delay;
    private float time;

    public Transform leftWall;
    public Transform rightWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > delay)
        {
            time = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        
        Quaternion quaternion = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, Quaternion.identity.z, Quaternion.identity.w);
        //quaternion = Quaternion.Inverse(quaternion);
        if(gameObject.name == "Left Spawner")
        {
            Instantiate(leftWall, new Vector3(-6.5f, 6.5f, 0.0f), leftWall.rotation);
        }
        if(gameObject.name == "Right Spawner")
        {
            Instantiate(rightWall, new Vector3(7.5f, 6.5f, 0.0f), rightWall.rotation);
        }
        
    }
}
