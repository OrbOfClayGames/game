using System;
using System.Collections.Generic;
using UnityEngine;

namespace Village
{
    public class VillageData : ScriptableObject
    {
        private Dictionary<ResourceName, int> resourceCount = new Dictionary<ResourceName, int>();
        private List<Building> buildings = new List<Building>();
        private Dictionary<string, Building> plotAllocation = new Dictionary<string, Building>();

        public VillageData()
        {
            PopulateDictionaries();
        }

        public void PopulateDictionaries()
        {
            CreateBuildings();
            System.Random multi = new System.Random();
            foreach (ResourceName resource in Enum.GetValues(typeof(ResourceName)))
            {
                resourceCount.Add(resource, multi.Next(600, 2000));
            }
            plotAllocation.Add("1stPlot", buildings.Find(building => building.Name == "woodworker shack"));
        }

        public Building GetBuildingOnPlot(string button)
        {
            Debug.Log(resourceCount[ResourceName.Wood]);
            Debug.Log(plotAllocation[button].Name);
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

        //Data for all Buildings
        private void CreateBuildings()
        {
            //T1 basic buildings
            buildings.Add(new Building("woodworker shack", ResourceName.Wood, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 100 }}));
            buildings.Add(new Building("stoneworker shack", ResourceName.Stone, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 250}}));
            buildings.Add(new Building("leatherworker shack", ResourceName.Leather, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 150}}));
            buildings.Add(new Building("clayworker shack", ResourceName.Clay, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 100},
                { ResourceName.Stone,50}}));
            buildings.Add(new Building("blacksmith shack", ResourceName.Metal, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 250},
                {ResourceName.Leather, 100},
                {ResourceName.Stone, 125}}));
            //T1 advanced buildings
            /*TODO: kommt noch */
            //T2 basic buildings
            buildings.Add(new Building("woodworker shop", ResourceName.Wood, 2, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 350 },
                {ResourceName.Leather, 250},
                {ResourceName.Stone, 250}, {ResourceName.Metal,150}}));
        }


    }

}

