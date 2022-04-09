using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayCotroller : MonoBehaviour
{
    public static GamePlayCotroller Instance;

    public Button PauseBTN;
   
    public GameObject GameOverPanel;
    public Text endScore, bestScore;
   
    public GameObject GamePausePanel;

    public GameObject GameWinnerPanel;
    public Text WinScore, BestWinScore;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
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
    public void EditButton()
    {
        SceneManager.LoadScene("mainmenu");
        Time.timeScale = 1;
        GameManager.Instance.score = 0;
    }
    public void ReStartButton()
    {
        SceneManager.LoadScene("Scenes 1");
        Time.timeScale = 1;
        GameManager.Instance.score = 0;
    }
    public void setScore(int score)
    {
        endScore.text = "Score : "+score;
    }
    public void showGameOverPanel()
    {
        GameOverPanel.SetActive(true);
        endScore.text="Score : "+GameManager.Instance.score;
        bestScore.text="Best Score : "+GameManager.Instance.getHightScore();

    }
    public void showGameWinner()
    {
        GameWinnerPanel.SetActive(true);
        WinScore.text = "Score : " + GameManager.Instance.score;
        BestWinScore.text = "Best Score : " + GameManager.Instance.getHightScore();
    }
    
}
