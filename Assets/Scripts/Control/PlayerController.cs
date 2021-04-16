using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string levelTransitionname;
    public Transform rayOriginPoint;
    private Vector2 rayDirection = new Vector2 (1, 0);

    public bool battle;

    // state
    public static PlayerController instance;
        
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
    }

    // Update is called once per frame
    void Update()
    {
        InteractWithMovement();       
    }    

    private void InteractWithMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartWalking();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            battle = true;            
            GetComponent<Fighter>().combatTarget = collision.gameObject;            
            GetComponent<Mover>().StopWalking();            
        }
    }

    private void StartWalking()
    {
        GetComponent<Mover>().Walk();
    }    
}
