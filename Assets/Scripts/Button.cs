using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string sceneToLoad = "Game"; 

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
