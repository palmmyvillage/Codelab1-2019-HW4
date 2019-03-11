using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {   
        InvokeRepeating("spawn", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        GameObject newPrize = Instantiate(Resources.Load<GameObject>("Prefab/InClass_Prefab/Prize_Prefab"));

        newPrize.GetComponent<Transform>().position = new Vector2(Random.Range(-7, 7), Random.Range(-7, 7));
    }
}
