using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VillageHandler : MonoBehaviour
{
    [SerializeField] private Text[] resourceTexts;
    [SerializeField] private Image[] resourceImages;
    private readonly string[] resourceStrings = { "wood", "stone", "clay", "metal", "leather" };
    private VillageData villageData;
    // Start is called before the first frame update
    void Start()
    {
        villageData = ScriptableObject.CreateInstance<VillageData>();
        villageData.PopulateDictionaries(resourceStrings);
        updateResourceCount();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void updateResourceCount()
    {
        for (int i = 0; i < resourceStrings.Length; i++)
        {
            int value = villageData.GetResourceCount(resourceStrings[i]);
            Debug.Log(i+" "+resourceTexts.Length);
            resourceTexts[i].text = value.ToString();
        }
    }

    public void OnPlotButtonClick()
    {
        string currentButton = EventSystem.current.currentSelectedGameObject.name;
        villageData.GetBuildingOnPlot(currentButton);
    }


}
