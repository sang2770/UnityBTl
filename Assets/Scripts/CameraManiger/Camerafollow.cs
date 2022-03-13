using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    private Transform player;
    public float Xmax;
    public float Xmin;
    public float Ymax;
    public float Ymin;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            temp.y = player.position.y;
            if(temp.x < Xmin)
            {
                temp.x = Xmin;
            }
            if(temp.x > Xmax)
            {
                temp.x=Xmax;
            }
            if (temp.y < Ymin)
            {
                temp.y = Ymin;
            }
            if (temp.y > Ymax)
            {
                temp.y = Ymax;
            }
            transform.position = temp;

        }
    }
}
