using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float fallSpeed;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        float y = -fallSpeed * Time.deltaTime;
        Vector2 downwards = new Vector2(0, y);
        rb2d.AddForce(downwards);
    }
}
