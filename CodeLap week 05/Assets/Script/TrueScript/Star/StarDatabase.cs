using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDatabase : MonoBehaviour
{
    //set thisn as static
    public static StarDatabase starDatabase;
    
    //set Star info
    public Star_Info[] starsInfo;
    
    //set eNum for type
    public enum StarType
    {
        yellowStar,
        blueStar,
        purpleStar
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        //make static or destroy
        if (starDatabase == null)
        {
            DontDestroyOnLoad(gameObject);
            starDatabase = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}



//set up player class to assign button and statistic
[System.Serializable]
public class Star_Info
{
    public string name;
    public StarDatabase.StarType type;
    public int score;
    public CirclingMotion_Info cirClingMotion_Info;
    public SpawnPosition starSpawnPosition;

}

//set up collection of CirclingMotion Information
[System.Serializable]
public class CirclingMotion_Info
{
    public float circlingSpeed;
    public float x_scaler_min;
    public float x_scaler_max;
    public float y_scaler_min;
    public float y_scaler_max;
    public float z_scaler_min;
    public float z_scaler_max;
}

//set up collection of spawnPosition
[System.Serializable]
public class SpawnPosition
{
    public float xOrigin_min;
    public float xOrigin_max;
    public float yOrigin_min;
    public float yOrigin_max;
    public float zOrigin_min;
    public float zOrigin_max;
}