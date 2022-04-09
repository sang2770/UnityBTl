using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlaycontrol : MonoBehaviour
{
    public Button PauseBTN;

    public GameObject GamePausePanel;
    public void PauseButton()
    {

        Time.timeScale = 0;
        PauseBTN.gameObject.SetActive(false);
        GamePausePanel.SetActive(true);
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        PauseBTN.gameObject.SetActive(true);
        GamePausePanel.SetActive(false);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("mainmenu");
        Time.timeScale = 1;
        GameManager.Instance.score = 0;
    }
    public void ReStartButton()
    {
        SceneManager.LoadScene("How to play");
        Time.timeScale = 1;
        GameManager.Instance.score = 0;
    }
}
