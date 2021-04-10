using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string levelTransitionname;
    public Transform rayOriginPoint;
    private Vector2 rayDirection = new Vector2 (10, 0);

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
        InteractWithCombat();

    }    

    private void InteractWithMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartWalking();
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            CombatTarget target = collision.gameObject.GetComponent<CombatTarget>();
            GetComponent<Fighter>().Attack(target);
            GetComponent<Mover>().StopWalking();
            //Collider2D collisions = collision;
        }

    }*/

    private void InteractWithCombat()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOriginPoint.position, rayDirection, 0.5f);
        if (hit == true)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GetComponent<Mover>().StopWalking();
                CombatTarget target = hit.collider.gameObject.GetComponent<CombatTarget>();
                GetComponent<Fighter>().Attack(target);                                
            }
        }
    }

    private void StartWalking()
    {
        GetComponent<Mover>().Walk();        
    }
}
