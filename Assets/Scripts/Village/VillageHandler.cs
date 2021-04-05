using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VillageHandler : MonoBehaviour
{
    [SerializeField] private Text[] resourceTexts;
    [SerializeField] private Image[] resourceImages;
    [SerializeField] private Building[] buildingList;
    private readonly string[] resourceStrings = { "wood", "stone", "clay", "metal", "leather" };
    private VillageData villageData;
    // Start is called before the first frame update
    void Start()
    {
        villageData = ScriptableObject.CreateInstance<VillageData>();
        villageData.PopulateDictionaries(resourceStrings);
        LoadAllResources();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadAllResources()
    {
        for (int i = 0; i < resourceStrings.Length; i++)
        {
            int value = villageData.GetResourceCount(resourceStrings[i]);
            resourceTexts[i].text = value.ToString();
        }
    }

    private void LoadResourceCount(string resource)
    {
        int index = Array.IndexOf(resourceStrings, resource);
        if (index == -1)
        {
            Debug.Log("The resource \"" + resource + "\" does not exist in resourceStrings: " + string.Join(", ", resourceStrings));
        }
        else
        {
            int value = villageData.GetResourceCount(resource);
            resourceTexts[index].text = value.ToString();
        }

    }

    private void UpdateResourceCount(string resource, int value)
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
        UpdateResourceCount("wood", 333);
    }
}
