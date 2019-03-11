using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPunk_Rotating : MonoBehaviour
{
    //set Moving limit from SteamPunkMoving
    public SteamPunk_Moving movingLimit;
    
    //set original rotation value
    private float xRotation;
    private float yRotation;
    private float zRotation;
    
    //set rotation speed
    public float Rspeed;
    //set bool to indicate which side, tick to go right first
    public bool rotateRight;
    
    // Start is called before the first frame update
    void Start()
    {
        xRotation = transform.rotation.x;
        yRotation = transform.rotation.y;
        zRotation = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        LevelRotating();
    }

    public void LevelRotating()
    {
        //set how to rotate
        if (movingLimit.moveRight == true)
        {
            zRotation -= Rspeed;
        }
        else
        {
            zRotation += Rspeed;
        }
        
        //rotate
        transform.rotation = Quaternion.Euler(xRotation,yRotation,zRotation);
    }
}
