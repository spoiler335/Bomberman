using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;


    private Animator anim;
    private Rigidbody rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(y==1) //up
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,speed);
            transform.rotation = Quaternion.Euler(0,0,0);
            anim.SetBool("isWalking",true);
        } 

        if(y==-1)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,-speed);
            transform.rotation = Quaternion.Euler(0,180,0);
            anim.SetBool("isWalking",true);
        }

        if(x==-1)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y,rb.velocity.z);
            transform.rotation = Quaternion.Euler(0,270,0);
            anim.SetBool("isWalking",true);
        }

        if(x==1) //right
        {
            rb.velocity = new Vector3(speed, rb.velocity.y,rb.velocity.z);
            transform.rotation = Quaternion.Euler(0,90,0);
            anim.SetBool("isWalking",true);
        }
    }
}
