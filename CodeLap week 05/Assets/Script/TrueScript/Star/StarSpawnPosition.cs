using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawnPosition : MonoBehaviour
{
    //set spawnInfo
    private SpawnPosition spawnPos;

    //set starNumber to indicate type of star
    public int starNumber;

    //set variable for starSpawnPosition
    private float xOrigin_min;
    private float xOrigin_max;
    private float yOrigin_min;
    private float yOrigin_max;
    private float zOrigin_min;
    private float zOrigin_max;

    //set variable for random
    private float xOrigin;
    private float yOrigin;
    private float zOrigin;

    // Start is called before the first frame update
    void Awake()
    {
        //set up ref to spawnPos
        spawnPos = StarDatabase.starDatabase.starsInfo[starNumber - 1].starSpawnPosition;

        //calculate random
        xOrigin = Random.Range(spawnPos.xOrigin_min, spawnPos.xOrigin_max);
        yOrigin = Random.Range(spawnPos.yOrigin_min, spawnPos.yOrigin_max);
        zOrigin = Random.Range(spawnPos.zOrigin_min, zOrigin_max);

        //set position of Star
        transform.position = new Vector3(xOrigin, yOrigin, zOrigin);
    }
}
