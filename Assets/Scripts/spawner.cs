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
        if(gameObject.name == "left spawner")
        {
            Instantiate(leftWall);
        }
        
    }
}
