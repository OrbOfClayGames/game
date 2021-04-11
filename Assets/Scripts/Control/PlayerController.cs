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

    //CombatTarget combatTarget;

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
            battle = true;
            //CombatTarget combatTarget = collision.gameObject.GetComponent<CombatTarget>();
            GetComponent<Fighter>().combatTarget = collision.gameObject.GetComponent<CombatTarget>();
            //Debug.Log(combatTarget);
            //GetComponent<Fighter>().Attack(combatTarget);            
            //StartCoroutine(GetComponent<Fighter>().Attacking(combatTarget));
            GetComponent<Mover>().StopWalking();
            //Collider2D collisions = collision;
        }
    }

    private void StartWalking()
    {
        GetComponent<Mover>().Walk();
    }

    /*private void InteractWithCombat()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOriginPoint.position, rayDirection, 0.1f);
        if (hit == true)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GetComponent<Mover>().StopWalking();
                CombatTarget combatTarget = hit.collider.gameObject.GetComponent<CombatTarget>();                
                GetComponent<Fighter>().Attack(combatTarget);                                
            }
        }
    }*/
}
