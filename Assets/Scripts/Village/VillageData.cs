using System.Collections.Generic;
using UnityEngine;

public class VillageData : ScriptableObject
{
    private Dictionary<string, int> resourceCount = new Dictionary<string, int>();
    private Dictionary<string, string> plotAllocation = new Dictionary<string, string>();

    public void PopulateDictionaries(string[] resources)
    {
        int multi = 1;
        foreach (var resource in resources)
        {
            resourceCount.Add(resource, 500 * multi++);
        }
        plotAllocation.Add("1stPlot", "woodworker");

    }
    
    public string GetBuildingOnPlot(string button)
    {
        Debug.Log(resourceCount["wood"]);
        Debug.Log(plotAllocation[button]);
        return plotAllocation[button];
    }

    public int GetResourceCount(string resource)
    {
        return resourceCount[resource];
    }

    //modifies the resource with name key by the value given 
    public void SetResourceCount(string key, int value)
    {
        if (resourceCount.ContainsKey(key))
        {
            resourceCount[key] = resourceCount[key] + value;
        }
        else
        {
            Debug.Log("key \"" + key + "\" does not exist in resourceCount: " + string.Join(", ", resourceCount.Keys));
        }
    }
}
