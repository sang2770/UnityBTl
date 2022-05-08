using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playcontroller : MonoBehaviour
{
   

    public float MovementSpeed = 1f;
    public float JumpForce = 1f;

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

    private bool checkvk=true;

    //âm thanh
    private AudioSource MainSound;
    public AudioClip OverSound;
    public AudioClip JumpSound;
    public AudioClip RunSound;
    public AudioClip HurtSound;
    public AudioClip ShotSound;
    public AudioClip CutSound;


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
        // Move nhân vật
        float movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0)*Time.deltaTime *MovementSpeed;//toc dộ di chuyển 

        if(!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement < 0 ? Quaternion.Euler(0,180, 0) : Quaternion.identity;
            anim.SetBool("run", true);
        }
        if(Input.GetKey(KeyCode.Space) && Mathf.Abs(myBody.velocity.y) < 0.001f)
        {
            if (isGround)
            {
                myBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);//tạo xung lực
                isGround = false;
                MainSound.PlayOneShot(JumpSound);
                anim.SetBool("jump", true);
            }
        }
        if (movement == 0)
        {
           
            if (isGround)
            {
                anim.SetBool("run", false);
                myBody.velocity = new Vector2(0, myBody.velocity.y);
            }
        }
        
        //dùng kiếm
        if (Input.GetKey(KeyCode.W) && checkvk)
        {
            anim.SetBool("sword", true);
            sword.SetActive(true);
            hand_sword.SetActive(true);
            checkvk = false;
            trangthai = "sword";
            StartCoroutine(PrintfAfter(0.4f));
            MainSound.PlayOneShot(CutSound);
        }
        //dùng súng
        if (Input.GetKey(KeyCode.E) && checkvk)
        {
            anim.SetBool("gun", true);
            gun.SetActive(true);
            hand_gun.SetActive(true);
            shot.SetActive(true);
            MainSound.PlayOneShot(ShotSound);

            if ( Time.time > NextFire)
            {
                NextFire = Time.time+fireRate;
                if (transform.rotation.y ==0)
                {
                    Instantiate(Bullet, shot.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else
                {
                    Instantiate(Bullet, shot.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
            }
            checkvk = false;
            trangthai = "gun";
            StartCoroutine(PrintfAfter(0.5f));
        }
        //dùng lưỡi hái 
        
        if (Input.GetKey(KeyCode.R) && checkvk)
        {
            anim.SetBool("sycthe", true);
            sycthe.SetActive(true);
            hand_sycthe.SetActive(true);
            checkvk=false;
            trangthai = "sycthe";
            StartCoroutine(PrintfAfter(0.6f));
            MainSound.PlayOneShot(CutSound);

        }



    }
    IEnumerator PrintfAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(trangthai == "sword")
        {
            checkvk = true;
            anim.SetBool("sword", false);
            sword.SetActive(false);
            hand_sword.SetActive(false);
        }
        if(trangthai == "gun")
        {
            checkvk = true;
            anim.SetBool("gun", false);
            gun.SetActive(false);
            hand_gun.SetActive(false);
            shot.SetActive(false);

        }
        if (trangthai == "sycthe")
        {
            checkvk = true;
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
