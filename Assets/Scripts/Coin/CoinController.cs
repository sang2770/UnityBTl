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

    //check finish
    private bool isFish=false;
    public Text txtReport;
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
        if (collision.gameObject.tag == "Key")
        {
            isFish = true;
            Destroy(collision.gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            
            if (isFish)
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
            else
            {
                txtReport.gameObject.SetActive(true);
                StartCoroutine(PrintfAfter(1.0f));
            }

        }
    }
    IEnumerator PrintfAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        txtReport.gameObject.SetActive(false);

    }
}
