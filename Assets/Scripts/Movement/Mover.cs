using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // config parameters
    [SerializeField] public float xVelocity = 1.5f;

    //cached references    
    private Rigidbody2D cachedRigidBody2D;
    private Animator cachedAnimator;

    private void Awake()
    {
        cachedRigidBody2D = GetComponent<Rigidbody2D>();
        cachedAnimator = GetComponent<Animator>();
    }

    public void Walk()
    {        
        Vector2 playerVelocity = new Vector2(xVelocity, 0f);        
        cachedRigidBody2D.velocity = playerVelocity;        
        cachedAnimator.SetBool("walking", true);
    }
}
