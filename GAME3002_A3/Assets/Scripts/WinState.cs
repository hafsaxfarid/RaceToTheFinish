using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    [SerializeField]
    private GameObject winUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            winUI.SetActive(true);
        }
        else
        {
            winUI.SetActive(false);
        }
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartScene");
        Debug.Log("Loading Start Menu...");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit...");
    }
}
