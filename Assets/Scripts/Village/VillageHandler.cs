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

        public Button CurrentButton { get; set; }
        public VillageData VillageData { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            VillageData = ScriptableObject.CreateInstance<VillageData>();
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
                int value = VillageData.GetResourceCount((ResourceName)i);
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
            int value = VillageData.GetResourceCount(resource);
            resourceTexts[(int)resource].text = value.ToString();
            // }

        }

        private void UpdateResourceCount(ResourceName resource, int value)
        {
            VillageData.SetResourceCount(resource, value);
            LoadResourceCount(resource);
        }

        

        public void OnResourceButtonClick()
        {
            UpdateResourceCount(ResourceName.Wood, 333);
        }

        public void OnDropDownValueChange()
        {
            CurrentButton.SendMessage("execute");
        }
    }
}
