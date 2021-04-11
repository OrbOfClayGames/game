using System;
using System.Collections.Generic;
using UnityEngine;

namespace Village
{
    public class VillageData : ScriptableObject
    {
        private Dictionary<ResourceName, int> resourceCount = new Dictionary<ResourceName, int>();
        private List<Building> buildings = new List<Building>();
        //TODO: has to be saved
        public Dictionary<string, Building> PlotAllocation { get; } = new Dictionary<string, Building>();

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
        }

        public Building GetBuildingOnPlot(string button)
        {
            Debug.Log(resourceCount[ResourceName.Wood]);
            Debug.Log(PlotAllocation[button].Name);
            return PlotAllocation[button];
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

        private List<ResourceName> GetUnplacedBuildingTypes()
        {
            List<ResourceName> unplacedResourceTyps = new List<ResourceName>();
            foreach (ResourceName resource in Enum.GetValues(typeof(ResourceName)))
            {
                unplacedResourceTyps.Add(resource);
            }

            foreach (var keyBuilding in PlotAllocation)
            {
                unplacedResourceTyps.Remove(keyBuilding.Value.Typ);
            }

            return unplacedResourceTyps;
        }

        public List<string> GetUnplacedBuildings()
        {
            List<string> unplacedBuildings = new List<string>();
            List<ResourceName> unplacedResourceTyps = GetUnplacedBuildingTypes();
            foreach (var resourceTyp in unplacedResourceTyps)
            {
               unplacedBuildings.Add(buildings.Find(building => building.Typ == resourceTyp && building.Tier == 1).Description);

            }
            return unplacedBuildings;
        }

        public Building GetBuilding(Predicate<Building> match)
        {
            return buildings.Find(match);
        }

        //Data for all Buildings
        private void CreateBuildings()
        {
            //T1 basic buildings
            buildings.Add(new Building("woodT1","woodworker shack", ResourceName.Wood, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 100 }}));
            buildings.Add(new Building("stoneT1", "stoneworker shack", ResourceName.Stone, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 250}}));
            buildings.Add(new Building("leatherT1", "leatherworker shack", ResourceName.Leather, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 150}}));
            buildings.Add(new Building("clayT1", "clayworker shack", ResourceName.Clay, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 100},
                { ResourceName.Stone,50}}));
            buildings.Add(new Building("metalT1", "blacksmith shack", ResourceName.Metal, 1, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 250},
                {ResourceName.Leather, 100},
                {ResourceName.Stone, 125}}));
            //T1 advanced buildings
            /*TODO: kommt noch */
            //T2 basic buildings
            buildings.Add(new Building("woodT2", "woodworker shop", ResourceName.Wood, 2, new Dictionary<ResourceName, int> {
                {ResourceName.Wood, 350 },
                {ResourceName.Leather, 250},
                {ResourceName.Stone, 250},
                { ResourceName.Metal,150}}));
        }
    }
}