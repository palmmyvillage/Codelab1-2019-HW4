using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerCon: MonoBehaviour
{
    public KeyCode upKey, downKey, rightKey, leftKey;

    public int score = 0;
    
    public float forceAmount = 1;
    
    private Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newForce = new Vector2(); //the force we will add to our player
        
        if (Input.GetKey(upKey)) //when someone presses "w"
        {
            Debug.Log("Pressed up");
            newForce.y += forceAmount;
        }
        
        if (Input.GetKey(downKey)) //when someone presses "s"
        {
            Debug.Log("Pressed down");
            newForce.y -= forceAmount;
        }
        
        if (Input.GetKey(rightKey)) //when someone presses "d"
        {
            Debug.Log("Pressed right");
            newForce.x += forceAmount;
        }

        if (Input.GetKey(leftKey)) //when someone presses "a"
        {
            Debug.Log("Pressed left");
            newForce.x -= forceAmount;             
        }

        rb.AddForce(newForce);
    }
}
