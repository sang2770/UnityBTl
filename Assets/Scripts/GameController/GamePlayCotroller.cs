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
    public Text endScore, bestScore,nameplayer1;
   
    public GameObject GamePausePanel;

    public GameObject GameWinnerPanel;
    public Text WinScore, BestWinScore,nameplayer2;

    
    AudioSource Main;
    public AudioClip buttonSound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Main = GetComponent<AudioSource>();
        }
    }
    public void PauseButton()
    {
        Main.PlayOneShot(buttonSound);
        Time.timeScale = 0;
        PauseBTN.gameObject.SetActive(false);
        GamePausePanel.SetActive(true);
    }
    public void ContinueButton()
    {
        Main.PlayOneShot(buttonSound);

        Time.timeScale = 1;
        PauseBTN.gameObject.SetActive(true);
        GamePausePanel.SetActive(false);
    }
    public void EditButton()
    {
        Main.PlayOneShot(buttonSound);

        SceneManager.LoadScene("mainmenu");
        Time.timeScale = 1;
        GameManager.Instance.score = 0;
    }
    public void ReStartButton()
    {
        Main.PlayOneShot(buttonSound);

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
        nameplayer1.text="Player : "+GameManager.Instance.getNamePlayer();

    }
    public void showGameWinner()
    {
        GameWinnerPanel.SetActive(true);
        WinScore.text = "Score : " + GameManager.Instance.score;
        BestWinScore.text = "Best Score : " + GameManager.Instance.getHightScore();
        nameplayer2.text = "Player : " + GameManager.Instance.getNamePlayer();
    }
    
}
