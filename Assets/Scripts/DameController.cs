using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameController : MonoBehaviour
{
    public int Dame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag=="Enemy")
        {
            EnemyHeath Hurt=collision.gameObject.GetComponent<EnemyHeath>();
            Hurt.addDame(Dame);
        }    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            Destroy(gameObject);

        }
    }
}
