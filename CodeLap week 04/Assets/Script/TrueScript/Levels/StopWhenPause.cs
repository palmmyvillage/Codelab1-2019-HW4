using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWhenPause : MonoBehaviour
{
    //set SystemController
    
    //set DynamicScript Action
    public SteamPunk_Moving moving;
    public SteamPunk_Rotating rotating;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        stopDynamic();
        resumeDynamic();
    }

    public void stopDynamic()
    {
        if (SystemController.systemController.pauseGame == true || SystemController.systemController.endGame == true)
        {
            moving.enabled = false;
            rotating.enabled = false;
        }
    }

    public void resumeDynamic()
    {
        if (SystemController.systemController.pauseGame == false && SystemController.systemController.endGame == false)
        {
            moving.enabled = true;
            rotating.enabled = true;   
        }
    }
}
