using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMotionHW1 : MonoBehaviour
{
    private float timeControl;

    private float xOrigin;
    private float yOrigin;
    private float zOrigin;

    public float circlingSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        xOrigin = transform.position.x;
        yOrigin = transform.position.y;
        zOrigin = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        timeControl += Time.deltaTime * circlingSpeed;

        float x = xOrigin + Mathf.Cos(timeControl);
        float y = yOrigin + Mathf.Sin(timeControl);
        float z = zOrigin;
        
        transform.position = new Vector3(x,y,z);
    }
}
