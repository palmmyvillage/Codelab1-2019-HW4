using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOrder : MonoBehaviour
{
    //setup scene order
    public static SceneOrder sceneOrder;
    public SceneList sceneList;
    
    //use awake to set this as static
    void Awake()
    {
        if (sceneOrder == null)
        {
            DontDestroyOnLoad(gameObject);
            sceneOrder = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //use this to changeScene
    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
        MenuDisable.menuDisable.DisablingFunction();
    }
}

[System.Serializable]
//setUpScene
public class SceneList
{
    public string Menu;
    public string level1;
    public string level2;
}
