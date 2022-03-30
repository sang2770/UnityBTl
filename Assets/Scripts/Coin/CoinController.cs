using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    private int total;
    public Text Coins;
    public int Scene;
    //bool CheckHigh;
    public int TotalPoint;
    //âm thanh
    private AudioSource MainSound;
    public AudioClip CoinSound;
    // Start is called before the first frame update
    void Start()
    {
        TotalPoint = GameObject.FindGameObjectsWithTag("Coin").Length;
        total = 0;
        
        Coins.text = total.ToString()+"/"+ TotalPoint.ToString();
        //CheckHigh = false;
        MainSound=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            MainSound.PlayOneShot(CoinSound);
            total++;
            Destroy(collision.gameObject);
            if (GamePlayCotroller.Instance != null)
            {
                GamePlayCotroller.Instance.setScore(total);
            }
            if (GameManager.Instance != null)
            {
                GameManager.Instance.score++;
                if (GameManager.Instance.score > GameManager.Instance.getHightScore())
                {
                    GameManager.Instance.setHightScore(GameManager.Instance.score);
                }
            }
               
            Coins.text =  total.ToString() + "/" + TotalPoint.ToString();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            
            if (total == 0)
            {
                if (Scene == 1)
                {
                    SceneManager.LoadScene("Scenes 2");
                }
                if (Scene == 2)
                {
                    SceneManager.LoadScene("Sence3");
                }

            }

        }
    }
}
