using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour
{
    public Playcontroller player;
    public Image[] imgHP;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player =GameObject.Find("Player").GetComponent<Playcontroller>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (player.heath<=0)
        {
            player.Death();
            
           

        }
        for(int i = imgHP.Length - 1; i >= player.heath; i--)
        {
            Destroy(imgHP[i]);
        }
    }

}
