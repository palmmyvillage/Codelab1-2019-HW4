using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundCHeckHW1 : MonoBehaviour
{
    public int playerNumber;
    public PlayerControllerHW1 Controller;
    
    private void OnCollisionStay2D(Collision2D other) //check collisionEnter to enable jump in PlayerController
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Controller.Player[playerNumber].jumpEnable = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other) //check collisionExit to disable jump in PlayerController
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Controller.Player[playerNumber].jumpEnable = false;
        }
    }
}
