using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Village/Building")]
public class Building : ScriptableObject
{
    private Dictionary<string, int> resourcesToBuild = new Dictionary<string, int>();
    [SerializeField] private ResourceName[] resources;
    [SerializeField] private int[] costs;
}
