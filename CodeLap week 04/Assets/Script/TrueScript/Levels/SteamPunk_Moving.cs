using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPunk_Moving : MonoBehaviour
{
    //set variable to store y coordinate
    private float xOrigin;
    private float yOrigin;
    private float zOrigin;
    
    //set speed to moving
    public float movingSpeed;
    //set limit of X [0] = min, [1] = max
    public float[] xLimit ;
    //set bool to indicate if moving right or left (tick to indicate move right first)
    public bool moveRight;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //set Origin to refer to Original coordinate
        xOrigin = transform.position.x;
        yOrigin = transform.position.y;
        zOrigin = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
           LevelMoving();
    }

    public void LevelMoving()
    {
        //set turning point
        if (xOrigin >= xLimit[1])
        {
            moveRight = false;
        }
        else if (xOrigin <= xLimit [0])
        {
            moveRight = true;
        }
        
        //set how to move
        if (moveRight == true)
        {
            xOrigin += movingSpeed;
        }
        else
        {
            xOrigin -= movingSpeed;
        }
        
        //move
        transform.position = new Vector3(xOrigin,yOrigin,zOrigin);
    }
}
