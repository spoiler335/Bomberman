using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bombPrefab;
    private bool canMove = true;

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
        UpdateMovement();

        if(Input.GetKeyDown(KeyCode.Space) )
        {
            if(LevelManager.Instance.BombCount <1 )
            {
                Instantiate(bombPrefab,new Vector3(Mathf.RoundToInt(transform.position.x),transform.position.y,Mathf.RoundToInt(transform.position.z)),bombPrefab.transform.rotation);
                ++LevelManager.Instance.BombCount ;
            }
        }
    }

    void UpdateMovement()
    {
        anim.SetBool("isWalking", false);

        if(!canMove)
        {
            return;
        }

        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(y==-1) //up
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,speed);
            transform.rotation = Quaternion.Euler(0,0,0);
            anim.SetBool("isWalking",true);
        } 

        if(y==1)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,-speed);
            transform.rotation = Quaternion.Euler(0,180,0);
            anim.SetBool("isWalking",true);
        }

        if(x==1)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y,rb.velocity.z);
            transform.rotation = Quaternion.Euler(0,270,0);
            anim.SetBool("isWalking",true);
        }

        if(x==-1) //right
        {
            rb.velocity = new Vector3(speed, rb.velocity.y,rb.velocity.z);
            transform.rotation = Quaternion.Euler(0,90,0);
            anim.SetBool("isWalking",true);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Explosion") )
        {
            LevelManager.Instance.isPlayerDead = true;
            Destroy(gameObject,0.5f);
        }     
    }
}
