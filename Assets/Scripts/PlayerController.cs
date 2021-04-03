using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    // config parameters
    [SerializeField] float xVelocity = 3f;

    // state
    bool hasStarted = false;
    

    // chached component references
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    public bool canMove = true;
    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {            
            Walk();
        }

        if (!canMove)
        {
            Vector2 playerVelocity = new Vector2(0f, 0f);
            myRigidbody.velocity = playerVelocity;
        }

        

    }



    private void Walk()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            Vector2 playerVelocity = new Vector2(xVelocity, 0f);
            myRigidbody.velocity = playerVelocity;

            myAnimator.SetBool("walking", true);
        }
    }
}
