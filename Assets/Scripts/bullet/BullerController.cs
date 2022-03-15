using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerController : MonoBehaviour
{
    public float speedbullet;
    public float aliveTime;
    private Rigidbody2D mybody;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)//z=180 đi ngược
        {
            mybody.AddForce(new Vector2(-1, 0) * speedbullet, ForceMode2D.Impulse);//set vận tốc và cho lục đảy
        }
        else 
        {
            mybody.AddForce(new Vector2(1, 0) * speedbullet, ForceMode2D.Impulse);//set vận tốc và cho lục đảy
        }
        
    }
    private void Start()
    {
        Destroy(gameObject,aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
