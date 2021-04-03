using System.Collections;
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
            resourceCount.Add(resource, 500*multi++);
        }
        plotAllocation.Add("1stPlot","woodworker");

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

    public bool CheckIfBuildable()
    {
        bool buildable = true;
        foreach (var resource in resourceCount)
        {
            ;
        }

        return buildable;
    }
}
