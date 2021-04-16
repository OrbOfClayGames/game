using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    Fighter fighter;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        fighter = GetComponent<Fighter>();
        player = GameObject.FindWithTag("Player");
        Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().battle)
        {
            fighter.Attacking(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //battle = true;
            GetComponent<Fighter>().combatTarget = collision.gameObject;
            //GetComponent<Mover>().StopWalking();
        }
    }
}
