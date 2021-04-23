using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Loading Game...");
    }

    // Exit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit...");
    }
}
