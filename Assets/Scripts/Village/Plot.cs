using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
                dropDown.AddOptions(villageData.GetUnplacedBuildings());
                dropDown.gameObject.SetActive(true);
                villageHandler.CurrentButton = button;

            }
            var image = Resources.Load<Sprite>("village/placeholderT1");
            button.image.sprite = image;
           // villageData.GetBuildingOnPlot(button.name);

            
        }

        private bool IsPlotEmpty()
        {
            //struct can't be null, so we have to check if resourcesToBuild was never assigned
            return allocatedBuilding.ResourcesToBuild is null;
        }

        public void execute()
        {
            print("Message was sent.");
            print(dropDown.options[dropDown.value].text);
        }

    }
}

