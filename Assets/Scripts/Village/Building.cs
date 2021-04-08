using System.Collections.Generic;

namespace Village
{
    public readonly struct Building
    {
        public string Name { get; }
        public string Description { get; }
        public ResourceName Typ { get; }
        public int Tier { get; }
        public Dictionary<ResourceName, int> ResourcesToBuild { get; }
        public List<BuildingRequirement> Requirements { get; }
        
        //no Description & no Requirement
        public Building(string name, ResourceName typ, int tier, Dictionary<ResourceName, int> resourcesToBuild)
        {
            Name = name;
            Description = name;
            Typ = typ;
            Tier = tier;
            ResourcesToBuild = resourcesToBuild;
            Requirements = new List<BuildingRequirement>();
        }
        //no Requirement
        public Building(string name, string description, ResourceName typ, int tier, Dictionary<ResourceName, int> resourcesToBuild)
        {
            Name = name;
            Description = description;
            Typ = typ;
            Tier = tier;
            ResourcesToBuild = resourcesToBuild;
            Requirements = new List<BuildingRequirement>();
        }
        //no Description
        public Building(string name, ResourceName typ, int tier, List<BuildingRequirement> requirements, Dictionary<ResourceName, int> resourcesToBuild)
        {
            Name = name;
            Description = name;
            Typ = typ;
            Tier = tier;
            ResourcesToBuild = resourcesToBuild;
            Requirements = requirements;
        }
        //all Fields
        public Building(string name, string description, ResourceName typ, int tier, List<BuildingRequirement> requirements, Dictionary<ResourceName, int> resourcesToBuild)
        {
            Name = name;
            Description = description;
            Typ = typ;
            Tier = tier;
            ResourcesToBuild = resourcesToBuild;
            Requirements = requirements;
        }
    }
}