using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string levelTransitionname;

    // state    

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
    }

    // Update is called once per frame
    void Update()
    {
        InteractWithMovement();
        //InteractWithCombat();
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
            CombatTarget target = collision.gameObject.GetComponent<CombatTarget>();
            GetComponent<Fighter>().Attack(target);
            GetComponent<Mover>().StopWalking();
        }
            
    }

    /*private void InteractWithCombat()
    {
        
    }*/       

    private void StartWalking()
    {
        GetComponent<Mover>().Walk();
    }
}
