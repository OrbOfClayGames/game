using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public bool isDead = false;

    public void TakeDamage(float damage)
    {
        health = Mathf.Max (health - damage, 0);
        Debug.Log(health);
        if(health == 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        if (isDead) return;
        isDead = true;
    }
}
