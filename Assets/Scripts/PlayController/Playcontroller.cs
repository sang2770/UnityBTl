using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playcontroller : MonoBehaviour
{
    public float MoveForce = 40f;//tốc đọ di chuyển
    public float JumForce = 400f;//độ cao nhảy
    public float MaxVelocity = 4f;//tốc độ tối thiểu

    private Rigidbody2D myBody;
    private Animator anim;
    bool isGround;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Run();
    }
    void Run()
    {
        float forceX = 0.0f;//tốc độ di chuyển
        float forceY = 0.0f;//tốc độ nhảy
        float vel=Mathf.Abs(myBody.velocity.x);//tốc độ hiện tại

        float h = Input.GetAxisRaw("Horizontal");//xác định chiều di chuyển
                                                 //h>0:bấm phím sang phải, h<0: bấm phím sang trái, h=0:ko di chuyển

        if (h > 0)
        {
            if (vel < MaxVelocity)
            {
                if (isGround)
                {
                    forceX = MoveForce;
                }
                else
                {
                    forceX = MoveForce * 1.1f;
                }
                Vector3 scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale;
            }
            anim.SetBool("run", true);

        }
        else if (h < 0)
        {
            if(vel < MaxVelocity)
            {
                if (isGround)
                {
                    forceX = -MoveForce;
                }
                else
                {
                    forceX = -MoveForce * 1.1f;
                }
                Vector3 scale= transform.localScale;
                scale.x = 1;
                transform.localScale= scale;
            }
            anim.SetBool("run", true);
        }
        if (h==0)
        {
            if (isGround)
            {
                anim.SetBool("run", false);
                myBody.velocity = new Vector2(0, myBody.velocity.y);
                
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGround)
            {
                forceY = JumForce;
                isGround = false;
                anim.SetBool("jump", true);
            }
        }
        myBody.AddForce(new Vector2 (forceX, forceY));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            anim.SetBool("jump", false);
        }
    }
}
