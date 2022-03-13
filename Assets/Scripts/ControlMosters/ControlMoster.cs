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
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Direction = transform.localScale.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.position.x >= maxX)
        {
            Direction = -transform.localScale.y;
        }
        else if(transform.position.x <= minX) 
            {
                Direction = transform.localScale.y;
            } 
        rigidbody.velocity = new Vector2(Direction*speed,rigidbody.velocity.y);
    }
}
