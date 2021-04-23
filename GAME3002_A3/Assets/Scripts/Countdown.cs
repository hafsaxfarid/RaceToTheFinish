using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private float startTime = 150f; // in seconds -> 2mins = 120s

    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private GameObject gameOverUI;

    private float timer = 0f;

    private void Start()
    {
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;
            
            if(timer <= 1)
            {
                gameOverUI.SetActive(true);
            }
            
            FormatTimeText();

            yield return null;

        } while (timer > 0);
    }

    private void FormatTimeText()
    {
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);

        timerText.text = "";

        if(minutes > 0)
        {
            timerText.text +=  minutes + "m ";
        }

        if (seconds > 0)
        {
            timerText.text += seconds + "s";
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Trying Again");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit...");
    }
}
