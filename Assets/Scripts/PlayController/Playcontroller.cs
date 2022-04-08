using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playcontroller : MonoBehaviour
{
    public float MoveForce = 40f;//tốc đọ di chuyển
    public float JumForce = 400f;//độ cao nhảy
    public float MaxVelocity = 4f;//tốc độ tối thiểu

    public int heath = 5;

    //trạng thái cầm vũ khý
    public string trangthai="";
    public GameObject sword;
    public GameObject hand_sword;

    public GameObject gun;
    public GameObject shot;
    public GameObject hand_gun;
    public GameObject Bullet;
    public float fireRate = 0.5f;
    public float NextFire = 0;

    public GameObject sycthe;
    public GameObject hand_sycthe;

    private Rigidbody2D myBody;
    private Animator anim;
    bool isGround;

    //âm thanh
    private AudioSource MainSound;
    public AudioClip OverSound;
    public AudioClip JumpSound;
    public AudioClip RunSound;
    public AudioClip HurtSound;

    
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        MainSound= GetComponent<AudioSource>();
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
        float hev= Mathf.Abs(myBody.velocity.y);

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
                myBody.velocity=new Vector2(0,myBody.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (hev==0)
            {
                if (isGround)
                {

                    forceY = JumForce;
                    MainSound.PlayOneShot(JumpSound);
                }
                
                isGround = false;
                anim.SetBool("jump", true);
            }
               
        }
        //dùng kiếm
        if (Input.GetKey(KeyCode.K))
        {
            anim.SetBool("sword", true);
            sword.SetActive(true);
            hand_sword.SetActive(true);
            
            trangthai = "sword";
            StartCoroutine(PrintfAfter(0.4f));
        }
        //dùng súng
        if (Input.GetKey(KeyCode.G))
        {
            anim.SetBool("gun", true);
            gun.SetActive(true);
            hand_gun.SetActive(true);
            shot.SetActive(true);
            if( Time.time > NextFire)
            {
                NextFire = Time.time+fireRate;
                if (transform.localScale.x < 0)
                {
                    Instantiate(Bullet, shot.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else
                {
                    Instantiate(Bullet, shot.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
            }
            
            trangthai = "gun";
            StartCoroutine(PrintfAfter(0.5f));
        }
        //dùng lưỡi hái 
        
        if (Input.GetKey(KeyCode.L))
        {
            anim.SetBool("sycthe", true);
            sycthe.SetActive(true);
            hand_sycthe.SetActive(true);

            trangthai = "sycthe";
            StartCoroutine(PrintfAfter(0.6f));
        }
        myBody.AddForce(new Vector2 (forceX, forceY));
        
    }
    IEnumerator PrintfAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(trangthai == "sword")
        {
            anim.SetBool("sword", false);
            sword.SetActive(false);
            hand_sword.SetActive(false);
        }
        if(trangthai == "gun")
        {
            anim.SetBool("gun", false);
            gun.SetActive(false);
            hand_gun.SetActive(false);
            shot.SetActive(false);

        }
        if (trangthai == "sycthe")
        {
            anim.SetBool("sycthe", false);
            sycthe.SetActive(false);
            hand_sycthe.SetActive(false);
        }
        if (trangthai == "Death")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            if (GamePlayCotroller.Instance != null)
            {
                GamePlayCotroller.Instance.showGameOverPanel();
            }
            Time.timeScale = 0;
        }
        trangthai = "";
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            anim.SetBool("jump", false);
           
        }
        if(collision.gameObject.tag == "Enemy")
        {
            heath--;
            MainSound.PlayOneShot(HurtSound);
            
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Death();
        }
    }
    public void Death()
    {
        MainSound.PlayOneShot(OverSound);
        anim.SetBool("Death", true);
        heath=0;
        trangthai = "Death";
        StartCoroutine(PrintfAfter(1.3f));
    }
    public void RunEffect()
    {
        MainSound.PlayOneShot(RunSound);
    }    
}
