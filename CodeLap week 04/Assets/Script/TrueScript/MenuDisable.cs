using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class MenuDisable : MonoBehaviour
{      
      //set this as Static
      public static MenuDisable menuDisable;
      
      //set up player
      public GameObject player1;
      private Vector3 P1_Origin;
      public GameObject player2;
      private Vector3 P2_Origin;

      void Awake()
      {
            if (menuDisable == null)
            {
                  DontDestroyOnLoad(gameObject);
                  menuDisable = this;
            }
            else
            {
                  Destroy(gameObject);
            }
      }

      //called at first frame
      private void Start()
      {
            P1_Origin = player1.GetComponent<Transform>().position;
            P2_Origin = player2.GetComponent<Transform>().position;
            DisablingFunction(); //do this when it called the first time
      }

      public void DisablingFunction()
      {
            StartCoroutine(Disabling());
      }

      public IEnumerator Disabling() //use this to disabling player's ability to move
      {
            yield return 0;
            if (SceneManager.GetActiveScene().name == SceneOrder.sceneOrder.sceneList.Menu)
            {
                  GetComponent<PlayerMovement>().enabled = false; //disable movement
                  
                  //disable players
                  player1.SetActive(false);
                  player1.GetComponent<Transform>().position = P1_Origin;
                  player2.SetActive(false);
                  player2.GetComponent<Transform>().position = P2_Origin;
            }
            else
            {
                  GetComponent<PlayerMovement>().enabled = true; //enable movement
                  
                  //enable players
                  player1.SetActive(true);
                  player1.GetComponent<Transform>().position = P1_Origin;
                        
                  player2.SetActive(true);
                  player2.GetComponent<Transform>().position = P2_Origin;
            }
      }
}
