using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScore : MonoBehaviour
{
    //set number to indicate color of star
    public int starNumber;
    
    //set int score refer from starManager
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
       score = StarDatabase.starDatabase.starsInfo[starNumber - 1].score; 
    }
}
