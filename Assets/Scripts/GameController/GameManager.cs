using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private const string High_Score = "High Score";
    public int score = 0;
    private void Awake()
    {
        MakeInstance();
        IsGameStartedForTheFirstTime();
    }
    public void IsGameStartedForTheFirstTime()
    {
        //cho chạy ứng dụng lần đầu
        if (PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(High_Score, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
    public void MakeInstance()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void setHightScore(int score)
    {
        PlayerPrefs.SetInt(High_Score, score);
    }
    public int getHightScore()
    {
        return PlayerPrefs.GetInt(High_Score);
    }

}
