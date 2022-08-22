using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float Delay = 3f;
    
    void Start ()
    {
        Destroy (gameObject, Delay);
    }
}
