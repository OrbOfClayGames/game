using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // config parameters
    [SerializeField] public float xVelocity = 1.5f;    

    public void Walk()
    {        
            Vector2 playerVelocity = new Vector2(xVelocity, 0f);
            GetComponent<Rigidbody2D>().velocity = playerVelocity;        
            GetComponent<Animator>().SetBool("walking", true);
    }
}
