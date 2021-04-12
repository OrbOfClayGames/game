using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Village
{
    public class VillageHandler : MonoBehaviour
    {
        [SerializeField] private Text[] resourcePanelValues;
        [SerializeField] private Image[] resourcePanelImages;
        [SerializeField] private Building[] buildingList;

        public Button CurrentButton { get; set; }
        public VillageData VillageData { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            VillageData = ScriptableObject.CreateInstance<VillageData>();
            LoadAllResources();
            //can't be disabled directly in Unity, because of reasons (bugs happen)
            FindObjectOfType<Dropdown>().gameObject.SetActive(false);
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
                resourcePanelValues[i].text = value.ToString();
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
            resourcePanelValues[(int)resource].text = value.ToString();
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
            CurrentButton.SendMessage("execute", CurrentButton);
        }
    }
}
