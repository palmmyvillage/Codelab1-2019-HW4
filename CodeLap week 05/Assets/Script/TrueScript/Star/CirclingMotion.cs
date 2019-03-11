using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CirclingMotion : MonoBehaviour
{
    //set up var to store Number
    public int starNumber;
    private CirclingMotion_Info circlingInfo;
    
    private float timeControl; //set time to use as multiplier for circle movement

    // set variable for storing center co-ordinates
    private float xOrigin;
    private float yOrigin;
    private float zOrigin;

    private float x_scaler;
    private float y_scaler;
    private float z_scaler;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //initiate the center of circling
        xOrigin = transform.position.x;
        yOrigin = transform.position.y;
        zOrigin = transform.position.z;
        
        //set up starInfo
        circlingInfo = StarDatabase.starDatabase.starsInfo[starNumber - 1].cirClingMotion_Info;
        
        //random scaler
        x_scaler = Random.Range(circlingInfo.x_scaler_min, circlingInfo.x_scaler_max);
        y_scaler = Random.Range(circlingInfo.y_scaler_min, circlingInfo.y_scaler_max);
        z_scaler = Random.Range(circlingInfo.z_scaler_min, circlingInfo.z_scaler_max);
    }

    // Update is called once per frame
    void Update()
    {
        //calculate speed for circling
        timeControl += Time.deltaTime * circlingInfo.circlingSpeed;

        //calculate circling movement
        float x = xOrigin + Mathf.Cos(timeControl) * x_scaler;
        float y = yOrigin + Mathf.Sin(timeControl) * y_scaler;
        float z = zOrigin + Mathf.Cos(timeControl) * z_scaler;
        
        //make the position move in circle
        transform.position = new Vector3(x,y,z);
    }
}
