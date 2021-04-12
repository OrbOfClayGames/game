using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Village
{
    public class Plot : MonoBehaviour
    {
        private VillageHandler villageHandler;
        private VillageData villageData;

        [SerializeField] private Dropdown dropDown;
        private Building allocatedBuilding;
        private Building nextUpgrade;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPlotButtonClick(Button button)
        {
            if (!villageHandler)
            {
                villageHandler = FindObjectOfType<VillageHandler>();
                villageData = villageHandler.VillageData;
            }

            if (IsPlotEmpty())
            {
                dropDown.ClearOptions();
                dropDown.AddOptions(new List<string>() { "pls pick a building:" });
                dropDown.AddOptions(villageData.GetUnplacedBuildings());
                dropDown.gameObject.SetActive(true);
                dropDown.Show();
                villageHandler.CurrentButton = button;

            }
            else if (CheckUpgradeRequirements())
            {
                UpgradeBuilding(button);
            }
            else
            {
                villageData.GetBuildingOnPlot(button);
            }
        }

        private bool IsPlotEmpty()
        {
            //struct can't be null, so we have to check if resourcesToBuild was never assigned
            return allocatedBuilding.ResourcesToBuild is null;
        }
        //TODO:umbenennen
        public void AllocateBuildingToPlot(Button button)
        {
            dropDown.gameObject.SetActive(false);
            allocatedBuilding =
                villageData.GetBuilding(building => building.Description == dropDown.options[dropDown.value].text);
            //TODO: bei höchstem tier läuft nextUpgrade ins Leere, fix it
            nextUpgrade = villageData.GetBuilding(building =>
                building.Typ == allocatedBuilding.Typ && building.Tier == allocatedBuilding.Tier + 1);
            villageData.PlotAllocation.Add(button, allocatedBuilding);
            var image = Resources.Load<Sprite>("village/" + allocatedBuilding.Name);
            button.image.sprite = image;
            print(dropDown.options[dropDown.value].text);
        }

        private void UpgradeBuilding(Button button)
        {
            allocatedBuilding = nextUpgrade;
            nextUpgrade = villageData.GetBuilding(building =>
                building.Typ == allocatedBuilding.Typ && building.Tier == allocatedBuilding.Tier + 1);
            var image = Resources.Load<Sprite>("village/" + allocatedBuilding.Name);
            button.image.sprite = image;
        }

        private bool CheckUpgradeRequirements()
        {
            //TODO: Prompt player that there are no more upgrades for this building
            if (nextUpgrade.ResourcesToBuild is null)
            {
                print("Highest Upgrade reached");
                return false;
            }

            foreach (BuildingRequirement requirement in nextUpgrade.Requirements)
            {
                if (!villageData.BuildingItems.Contains(requirement))
                {
                    print("Missing Requirement Item: " +requirement);
                    return false;
                }
            }

            foreach (var resource in nextUpgrade.ResourcesToBuild)
            {
                if (villageData.GetResourceCount(resource.Key) < resource.Value)
                {
                    print("Not enough "+resource.Key +". You need "+(resource.Value-villageData.GetResourceCount(resource.Key))+" more "+resource.Key);
                    return false;
                }
            }
            return true;
        }
    }
}