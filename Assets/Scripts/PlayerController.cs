using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // config parameters
    [SerializeField] float xVelocity = 3f;

    public string areaTransitionName;

    // state
    bool hasStarted = false;

    // chached component references
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }        

        DontDestroyOnLoad(gameObject);

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {            
            Walk();
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
