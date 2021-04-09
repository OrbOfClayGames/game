using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public void Attack(CombatTarget target)
    {
        Debug.Log(GetComponent<Fighter>().gameObject.name + " attacks " + target);
    }
}
