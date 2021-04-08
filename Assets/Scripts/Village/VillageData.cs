using System;
using System.Collections.Generic;
using UnityEngine;

namespace Village
{
    public class VillageData : ScriptableObject
    {
        private Dictionary<ResourceName, int> resourceCount = new Dictionary<ResourceName, int>();
        private Dictionary<string, string> plotAllocation = new Dictionary<string, string>();

        public VillageData()
        {
            PopulateDictionaries();
        }

        public void PopulateDictionaries()
        {
            System.Random multi = new System.Random();
            foreach (ResourceName resource in Enum.GetValues(typeof(ResourceName)))
            {
                resourceCount.Add(resource, multi.Next(600, 2000));
            }
            plotAllocation.Add("1stPlot", "woodworker");

        }

        public string GetBuildingOnPlot(string button)
        {
            Debug.Log(resourceCount[ResourceName.Wood]);
            Debug.Log(plotAllocation[button]);
            return plotAllocation[button];
        }

        public int GetResourceCount(ResourceName resource)
        {
            return resourceCount[resource];
        }

        //modifies the resource with name key by the value given 
        public void SetResourceCount(ResourceName key, int value)
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

}

