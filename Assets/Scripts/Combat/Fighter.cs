using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float timeBetweenAttacks = 2f;

    float timeSinceLastAttack = 0;
    int attackNumber;

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

    }

    public void Attack(CombatTarget target)
    {
        if (timeSinceLastAttack > timeBetweenAttacks && attackNumber<3)
        {
            Debug.Log(GetComponent<Fighter>().gameObject.name + " attacks " + target);
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceLastAttack = 0;
            attackNumber++;
        }
        if (timeSinceLastAttack > timeBetweenAttacks && attackNumber >= 3)
        {
            GetComponent<Mover>().Walk();
        }
    }

    //  Animation event
    void Hit()
    {
        
    }
}
