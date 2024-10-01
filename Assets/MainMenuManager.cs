using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Space");
    }

    public void QuitGame(){
        Application.Quit(); // nothing will happen in Unity Editor! only works when you build the game
    }
}
