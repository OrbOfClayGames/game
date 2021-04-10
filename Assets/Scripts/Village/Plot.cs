using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

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

        public void OnPlotButtonClick()
        {
            if (!villageHandler)
            {
                villageHandler = FindObjectOfType<VillageHandler>();
                villageData = villageHandler.VillageData;
            }
            //testing start
            // if (!dropDown.gameObject.activeSelf)
            // {
            //     dropDown.gameObject.SetActive(true);
            //
            // }
            // else
            // {
            //     dropDown.gameObject.SetActive(false);
            //
            // }
            if (IsPlotEmpty())
            {
                dropDown.AddOptions(villageData.GetUnplacedBuildings());
                dropDown.gameObject.SetActive(true);

            }

            
            //testing stop
            string currentButton = EventSystem.current.currentSelectedGameObject.name;
            villageData.GetBuildingOnPlot(currentButton);

            
        }

        private bool IsPlotEmpty()
        {
            //struct can't be null, so we have to check if resourcesToBuild was never assigned
            return allocatedBuilding.ResourcesToBuild is null;
        }
    }
}

