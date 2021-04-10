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
        if (target == null) return;

        if (timeSinceLastAttack > timeBetweenAttacks && attackNumber<3)
        {
            GetComponent<Animator>().SetTrigger("attack");
            Debug.Log(GetComponent<Fighter>().gameObject.name + " attacks " + target);
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
