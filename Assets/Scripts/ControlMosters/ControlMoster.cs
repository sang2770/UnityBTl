using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMoster : MonoBehaviour
{
    public float maxX;
    public float minX;
    public float speed = 2f;
    Rigidbody2D rigidbody;
    private float Direction;
    Animator enemyAnimator;

    //Bien check di chuyen
    bool CheckPlayer;
    bool CheckRangeExit;
    private AudioSource MainSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Direction = transform.localScale.y;
        enemyAnimator = GetComponent<Animator>();
        CheckPlayer = false;
        CheckRangeExit = false;
        maxX = transform.position.x + maxX;
        minX = transform.position.x + minX;
        MainSound=GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            enemyAnimator.SetBool("enemy_Attack", true);
            MainSound.Play();
            CheckPlayer = true;
            if(Direction>0 && collision.transform.position.x<transform.position.x 
                || Direction < 0 && collision.transform.position.x > transform.position.x)
            {
                
                Flip();

            }
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CheckPlayer = false;
            Flip();
            enemyAnimator.SetBool("enemy_Attack", false);
            MainSound.Stop();
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (CheckPlayer == false)
        {
            if(!CheckRangeExit)
            {
                if (transform.position.x > maxX || transform.position.x < minX)
                {
                    Flip();
                }
            }
            else
            {
                if(transform.position.x >= minX && transform.position.x <= maxX)
                {
                    CheckRangeExit = false;

                }
            }
        }
        else
        {
            if (transform.position.x < minX || transform.position.x > maxX)
            {
                CheckRangeExit = true;


            }

        }
        rigidbody.velocity = new Vector2(Direction * speed, rigidbody.velocity.y);


    }
    private void Flip()
    {
        Vector3 scale = transform.localScale;
        Direction *=-transform.localScale.y;
        scale.x*=-1;
        transform.localScale = scale;

    }
}
