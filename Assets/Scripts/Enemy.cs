using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    enum State
    {
        idel,
        moving
    }
    private Animator anim;
    private Rigidbody rb;
    private NavMeshAgent nav;

    [SerializeField] float minTime =2f;
    [SerializeField] float maxTime =2f;
    [SerializeField] LayerMask floorMask = 0;

    private float waitTime;
    private State currentState;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb =  GetComponent<Rigidbody>();
        nav= GetComponent<NavMeshAgent>();    
        currentState = State.idel; 
        waitTime = 0;
    }

    
    void Update()
    {
        switch(currentState)
        {
            case State.idel:
            {
                Wander();
                break;
            }

            case State.moving:
            {
                Wait();
                break;
            }
        }
    }

    void Wander()
    {
        if(waitTime >0)
        {
            waitTime -= Time.deltaTime;
            return;
        }
        nav.SetDestination(RandomNavSphere(transform.position, 1f, floorMask));
        currentState = State.moving;
        anim.SetBool("isMoving",true);
    }

    void Wait()
    {
        if(nav.pathStatus != NavMeshPathStatus.PathComplete)
        {
            return;
        }
        waitTime = Random.Range(minTime, maxTime);
        currentState = State.idel;
        anim.SetBool("isMoving",false);
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance,LayerMask layerMask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layerMask);
        return navHit.position;
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
        }    

        if(other.gameObject.CompareTag("Explosion"))
        {
            anim.SetBool("isDead", true);
            --LevelManager.Instance.enemyCount;
        }
    }

    
}
