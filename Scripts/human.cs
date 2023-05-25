using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Collider2D coll;
    public Transform left, right;
    public float Speed;
    private float LeftX, RightX;

    private bool isLeft = true;
    //private bool FaceLeft = true;

   // public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        LeftX = left.position.x;
        RightX = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }


    void Update()
    {
       Movemenet();
        
    }

    void Movemenet()
    {
        if(isLeft)
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if(transform.position.x < LeftX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isLeft = false;                
            }
            
        }
        else
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if(transform.position.x > RightX)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isLeft = true;
            }

        }


    }   


}