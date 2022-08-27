using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    private bool exploded = false;
    void Start()
    {
        exploded = false;
        Invoke("Explode",3f);
    }

    void Explode()
    {

        Instantiate(explosion,transform.position,Quaternion.identity);

        StartCoroutine(createExplosion(Vector3.forward));
        StartCoroutine(createExplosion(Vector3.left));
        StartCoroutine(createExplosion(Vector3.right));
        StartCoroutine(createExplosion(Vector3.back));
        exploded = true;
        Destroy(gameObject,0.3f);
        --LevelManager.Instance.BombCount;
    }
    


    IEnumerator createExplosion(Vector3 direction)
    {

        for(int i=0; i<3 ; ++i)
        {
            RaycastHit hit;

            Physics.Raycast(transform.position + new Vector3(0,0.5f,0), direction, out hit,3f);
            if(hit.collider.CompareTag("Destrcutable"))
            {
                Instantiate(explosion,transform.position + (i*direction), explosion.transform.rotation);
                Destroy(hit.collider.gameObject,0.1f);
                AudioManager.Instance.playSound("sound2");
            }
            else if (hit.collider.CompareTag("Enemy") )
            {
                Instantiate(explosion,transform.position + (i*direction), explosion.transform.rotation);
                hit.collider.GetComponent<BoxCollider>().enabled = false;
                hit.collider.GetComponent<Animator>().SetBool("isDead",true);
                AudioManager.Instance.playSound("sound2");
                LevelManager.Instance.enemyCount--;
                Destroy(hit.collider.gameObject,1f);
            }
            else if (hit.collider.CompareTag("Player") )
            {
                Instantiate(explosion,transform.position + (i*direction), explosion.transform.rotation);
                AudioManager.Instance.playSound("sound2");
                LevelManager.Instance.isPlayerDead = true;
                AudioManager.Instance.playSound("sound3");
                Destroy(hit.collider.gameObject,1f);
            }
            else
            {
                break;  
            }
        }

        yield return new WaitForSeconds(0.05f);
    }
}
