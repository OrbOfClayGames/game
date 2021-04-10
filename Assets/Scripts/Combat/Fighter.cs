using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float timeBetweenAttacks = 2f;

    float timeSinceLastAttack = 0;

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

    }

    public void Attack(CombatTarget target)
    {
        if (timeSinceLastAttack > timeBetweenAttacks)
        {
            Debug.Log(GetComponent<Fighter>().gameObject.name + " attacks " + target);
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceLastAttack = 0;
        }
    }

    //  Animation event
    void Hit()
    {
        
    }
}
