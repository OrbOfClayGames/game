using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float timeBetweenAttacks = 2f;
    [SerializeField] float damage = 5f;

    Transform target;

    float timeSinceLastAttack = 0;
    int attackNumber;

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

    }

    public void Attack(CombatTarget combatTarget)
    {
        if (combatTarget == null) return;

        if (timeSinceLastAttack > timeBetweenAttacks && attackNumber < 3)
        //if (timeSinceLastAttack > timeBetweenAttacks && attackNumber<3)
        {
            //this triggers the Hit() event
            GetComponent<Animator>().SetTrigger("attack");
            Debug.Log(GetComponent<Fighter>().gameObject.name + " attacks " + combatTarget);
            timeSinceLastAttack = 0;
            target = combatTarget.transform;            
            //attackNumber++;
        }
        /*if (timeSinceLastAttack > timeBetweenAttacks && attackNumber >= 3)
        {
            GetComponent<Mover>().Walk();
        }*/
    }

    //  Animation event
    void Hit()
    {
        Health healthComponent = target.GetComponent<Health>();
        healthComponent.TakeDamage(damage);
    }
}
