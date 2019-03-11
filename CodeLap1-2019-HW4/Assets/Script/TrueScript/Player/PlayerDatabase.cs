using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerDatabase : MonoBehaviour
{
    public static PlayerDatabase playerDatabase; //set this as static
   
    //set up player Info
    public Player_Info[] playerInfo; //initiate the playerInfo class
    public enum Player
    {
        Player1,
        Player2
    }

    
    //set up class Info
    public Class_Info[] classInfo; // initiate classInfo class
    public enum Class //initiate class type for classInfo
    {
        Warrior,
    }
    public float getClassRunningForce(Class @class)
    {
        foreach (var classType in classInfo)
        {
            if (@class == classType.className)
            {
                return classType.runningForce;
            }
        }

        return 0.0f;
    }
    public float getClassJumpingForce(Class @class)
    {
        foreach (var classType in classInfo)
        {
            if (@class == classType.className)
            {
                return classType.jumpingForce;
            }
        }
        return 0.0f;
    }
    public float getClassGlidingInput(Class @class)
    {
        foreach (var classType in classInfo)
        {
            if (@class == classType.className)
            {
                return classType.glidingInput;
            }
        }
        return 0.0f;
    }

    public float getClassRunningLimit(Class @class)
    {
        foreach (var classType in classInfo)
        {
            if (@class == classType.className)
            {
                return classType.runningLimit;
            }
        }
        return 0.0f;
    }
    public float getClassGravityInput(Class @class)
    {
        foreach (var classType in classInfo)
        {
            if (@class == classType.className)
            {
                return classType.gravityInput;
            }
        }
        return 0.0f;
    }
    
    //initializing this class
    void Awake()
    {
       //make static or destroy
       if (playerDatabase == null)
          {
            DontDestroyOnLoad(gameObject);
            playerDatabase = this;
          }
       else
          {
            Destroy(gameObject);
          }
     }
}

//PlayerInfo
[System.Serializable]
public class Player_Info
{
    public string Name;
    public PlayerDatabase.Player playerNumber;
    public Rigidbody2D rigidBody;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    [FormerlySerializedAs("myType")] public PlayerDatabase.Class ChosenClass;
    public bool jumpEnable;
    public bool isJumping;
}

//ClassInfo
[System.Serializable]
public class Class_Info
{
    public string Name;
    public PlayerDatabase.Class className;
    public float runningForce;
    public float runningLimit;
    public float jumpingForce;
    public float glidingInput;
    public float gravityInput;
}
