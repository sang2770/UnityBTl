using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMoster : MonoBehaviour
{
    public float maxX;
    public float minX;
    public float speed = 2f;
    public int HuongBanDau=0;
    Rigidbody2D rigidbody;
    private float Direction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Direction = transform.localScale.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 scale= transform.localScale;
        if (transform.position.x >= maxX)
        {
            Direction = -transform.localScale.y;
            scale.x = -1;
            if (HuongBanDau == 1)
            {
                scale.x = 1;
            }


        }
        else if(transform.position.x <= minX) 
            {
                Direction = transform.localScale.y;
            scale.x = 1;
            if (HuongBanDau == 1)
            {
                scale.x = -1;
            }
        } 
        rigidbody.velocity = new Vector2(Direction*speed,rigidbody.velocity.y);
        
        transform.localScale = scale;
    }
}
