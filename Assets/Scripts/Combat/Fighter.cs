using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public void Attack()
    {
        Debug.Log(GetComponent<Fighter>().gameObject.name + "Attack!");
    }
}
