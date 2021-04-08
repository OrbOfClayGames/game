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
        public bool HasSpecialRequirement { get; }
        public List<BuildingRequirement> Requirements { get; }

        public Building(string name, ResourceName typ, int tier, bool hasSpecialRequirement, List<BuildingRequirement> requirements, Dictionary<ResourceName, int> resourcesToBuild)
        {
            Name = name;
            Description = name;
            Typ = typ;
            Tier = tier;
            ResourcesToBuild = resourcesToBuild;
            HasSpecialRequirement = hasSpecialRequirement;
            Requirements = requirements;
        }

        public Building(string name, string description, ResourceName typ, int tier, bool hasSpecialRequirement, List<BuildingRequirement> requirements, Dictionary<ResourceName, int> resourcesToBuild)
        {
            Name = name;
            Description = description;
            Typ = typ;
            Tier = tier;
            ResourcesToBuild = resourcesToBuild;
            HasSpecialRequirement = hasSpecialRequirement;
            Requirements = requirements;
        }
    }
}

