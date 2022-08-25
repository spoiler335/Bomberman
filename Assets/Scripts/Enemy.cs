using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private NavMeshAgent nav;

    [SerializeField] float minTime =2f;
    [SerializeField] float maxTime =2f;

    private float wait;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb =  GetComponent<Rigidbody>();
        nav= GetComponent<NavMeshAgent>();    
    }

    
    void Update()
    {
        wait = Random.Range(minTime, maxTime);
        if(!nav.hasPath || nav.remainingDistance <1f)
        {
            StartCoroutine(Move());
        } 
        //StartCoroutine(Move());
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
        }    
    }

    IEnumerator Move()
    {
        //RaycastHit hit;
        int r= Random.Range(0,4);
        Vector3 newPos = Vector3.zero;
        if(r==0)
        {   
            // Physics.Raycast(transform.position + new Vector3(0,0.5f,0), Vector3.left, out hit);
            // if( !hit.collider.CompareTag("Wall") && !hit.collider.CompareTag("Destrcutable") && !hit.collider.CompareTag("Non-Destrcutable") )
            // {
                newPos = new Vector3(Mathf.RoundToInt(transform.position.x+1f),transform.position.y,Mathf.RoundToInt(transform.position.z));   
                nav.SetDestination(newPos);
            //}
        }

        else if(r==1)
        {
            // Physics.Raycast(transform.position , Vector3.right, out hit);
            // if( !hit.collider.CompareTag("Wall") && !hit.collider.CompareTag("Destrcutable") && !hit.collider.CompareTag("Non-Destrcutable") )
            // {
                newPos = new Vector3(Mathf.RoundToInt(transform.position.x-1f),transform.position.y,Mathf.RoundToInt(transform.position.z));   
                nav.SetDestination(newPos);
            //}
        }

        else if(r==2)
        {
            // Physics.Raycast(transform.position + new Vector3(0,0.5f,0), Vector3.forward, out hit);
            // if( !hit.collider.CompareTag("Wall") && !hit.collider.CompareTag("Destrcutable") && !hit.collider.CompareTag("Non-Destrcutable") )
            // {
                newPos = new Vector3(Mathf.RoundToInt(transform.position.x),transform.position.y,Mathf.RoundToInt(transform.position.z+1f));
                nav.SetDestination(newPos);   
            //}
        }

        else if(r==3)
        {
            // Physics.Raycast(transform.position + new Vector3(0,0.5f,0), Vector3.back, out hit);
            // if( !hit.collider.CompareTag("Wall") && !hit.collider.CompareTag("Destrcutable") && !hit.collider.CompareTag("Non-Destrcutable") )
            // {
                newPos = new Vector3(Mathf.RoundToInt(transform.position.x),transform.position.y,Mathf.RoundToInt(transform.position.z-1f));   
                nav.SetDestination(newPos);
            //}
        }

        yield return new WaitForSeconds(wait);
    }

    

    
}
