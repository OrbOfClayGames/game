using UnityEngine;
using UnityEngine.EventSystems;

namespace Village
{
    public class Plot : MonoBehaviour
    {
        private VillageHandler villageHandler;

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
                villageHandler = GameObject.FindObjectOfType<VillageHandler>();
            }
            string currentButton = EventSystem.current.currentSelectedGameObject.name;
            villageHandler.VillageData.GetBuildingOnPlot(currentButton);

            if (IsPlotEmpty())
            {
                Debug.Log("Empty");
            }
        }

        private bool IsPlotEmpty()
        {
            //struct can't be null, so we have to check if resourcesToBuild was never assigned
            return allocatedBuilding.ResourcesToBuild is null;
        }
    }
}

