using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Village
{
    public class VillageHandler : MonoBehaviour
    {
        [SerializeField] private Text[] resourceTexts;
        [SerializeField] private Image[] resourceImages;
        [SerializeField] private Building[] buildingList;
        //private readonly string[] resourceStrings = { "wood", "stone", "clay", "metal", "leather" };
        private VillageData villageData;
        // Start is called before the first frame update
        void Start()
        {
            villageData = ScriptableObject.CreateInstance<VillageData>();
            LoadAllResources();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LoadAllResources()
        {
            for (int i = 0; i < Enum.GetNames(typeof(ResourceName)).Length; i++)
            {
                int value = villageData.GetResourceCount((ResourceName)i);
                resourceTexts[i].text = value.ToString();
            }
        }

        private void LoadResourceCount(ResourceName resource)
        {
            // int index = Array.IndexOf(resourceStrings, resource);
            // if (index == -1)
            // {
            //     Debug.Log("The resource \"" + resource + "\" does not exist in resourceStrings: " + string.Join(", ", resourceStrings));
            // }
            // else
            // {
            int value = villageData.GetResourceCount(resource);
            resourceTexts[(int)resource].text = value.ToString();
            // }

        }

        private void UpdateResourceCount(ResourceName resource, int value)
        {
            villageData.SetResourceCount(resource, value);
            LoadResourceCount(resource);
        }

        public void OnPlotButtonClick()
        {
            string currentButton = EventSystem.current.currentSelectedGameObject.name;
            villageData.GetBuildingOnPlot(currentButton);
        }

        public void OnResourceButtonClick()
        {
            UpdateResourceCount(ResourceName.Wood, 333);
        }
    }
}
