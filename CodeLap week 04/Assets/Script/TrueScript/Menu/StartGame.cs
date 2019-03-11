using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public static StartGame startMenu;
    
    //set button to start
    public KeyCode[] pressToStart;

    //set inGameElement to Load
    public GameObject inGameUI;

    //set MenuElement to disable
    public GameObject startMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        if (startMenu == null)
        {
            startMenu = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        startGame();
    }

    //set function for startGame
    public void startGame()
    {
        if (Input.GetKeyDown(pressToStart[0]) && !Input.GetKeyDown(pressToStart[1]))
        {
            SceneOrder.sceneOrder.GoToScene(SceneOrder.sceneOrder.sceneList.level1);
            exitMenu();
        }

        if (Input.GetKeyDown(pressToStart[1]) && !Input.GetKeyDown(pressToStart[0]))
        {
            SceneOrder.sceneOrder.GoToScene(SceneOrder.sceneOrder.sceneList.level2);
            exitMenu();
        }
    }

    public void exitMenu()
    {
        inGameUI.SetActive(true);
        SystemController.systemController.enabled = true;

        startMenuUI.SetActive(false);
    }

    public void enterMenu()
    {
        inGameUI.SetActive(false);
        SystemController.systemController.enabled = false;
        
        startMenuUI.SetActive(true);
    }
}
