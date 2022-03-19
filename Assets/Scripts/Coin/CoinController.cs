using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    private int total;
    public Text Coins;
    //bool CheckHigh;
    public int TotalPoint;
    // Start is called before the first frame update
    void Start()
    {
        TotalPoint = GameObject.FindGameObjectsWithTag("Coin").Length;
        total = 0;
        
        Coins.text = total.ToString()+"/"+ TotalPoint.ToString();
        //CheckHigh = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
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
}
