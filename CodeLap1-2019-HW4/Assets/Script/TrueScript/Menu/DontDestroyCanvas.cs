using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour
{
    public static DontDestroyCanvas dontDestroyCanvas;

    void Awake()
    {
        if (dontDestroyCanvas == null)
        {
            DontDestroyOnLoad(gameObject);
            dontDestroyCanvas = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
