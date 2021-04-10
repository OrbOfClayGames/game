using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Village
{
    public class Plot : MonoBehaviour
    {
        private VillageHandler villageHandler;

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
                villageHandler = GameObject.FindObjectOfType<VillageHandler>();
            }
            if (IsPlotEmpty())
            {
                Debug.Log("true");
                Debug.Log(dropDown.name);
                dropDown = FindObjectOfType<Dropdown>();
                dropDown.ClearOptions();
                dropDown.gameObject.SetActive(false);
            }
            string currentButton = EventSystem.current.currentSelectedGameObject.name;
            villageHandler.VillageData.GetBuildingOnPlot(currentButton);

            
        }

        private bool IsPlotEmpty()
        {
            //struct can't be null, so we have to check if resourcesToBuild was never assigned
            return allocatedBuilding.ResourcesToBuild is null;
        }
    }
}

