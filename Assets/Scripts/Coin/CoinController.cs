using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    private int total;
    Text Coins;
    //bool CheckHigh;
    public int TotalPoint;
    // Start is called before the first frame update
    void Start()
    {
        total = 0;
        Coins = GameObject.Find("Points").GetComponent<Text>();
        Coins.text = "Coin: " + total.ToString()+"/"+TotalPoint.ToString();
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
            Coins.text = "Coin: " + total.ToString() + "/" + TotalPoint.ToString();
        }
    }
}
