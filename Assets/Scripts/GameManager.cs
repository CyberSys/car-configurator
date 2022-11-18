using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Car myCarInstance;
    private GameObject spawnPoint;
    private GameObject myCarPrefab;
    private Dictionary<int, string> shoppingList = new Dictionary<int, string>();
    private TMP_Text currentSelectionText;
    private TMP_Text currentPriceText;

    private void Awake()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        currentSelectionText = GameObject.Find("LabelCurrentSelection").GetComponent<TMP_Text>();
        currentPriceText = GameObject.Find("LabelRunningTotal").GetComponent<TMP_Text>();
        NewCarInstance(CarType.Buggy); // Set Buggy first
    }

    // Handler for changing the car called by dropdown menu
    public void ChangeCar(CarType carToShow)
    {
        NewCarInstance(carToShow);
    }

    public void NewCarInstance(CarType carType)
    {
        myCarPrefab = GameObject.FindGameObjectWithTag("Car");
        if (myCarPrefab != null)
        {
            DestroyImmediate(myCarPrefab.gameObject);
            myCarPrefab = null;
        }

        // Create an instance of the vehicle
        myCarInstance = ScriptableObject.CreateInstance<Car>();
        myCarInstance.SetDefaultConfig(carType);

        // Create an instance of it's prefab
        Instantiate(myCarInstance.getPrefab(), spawnPoint.transform.position, spawnPoint.transform.rotation);

        // Set base prices in instance object
        myCarInstance.SetCarBasePriceTotal(carType);
        myCarInstance.SetTiresetPriceTotal(TiresetType.Standard);
        ShowTiresetPrefab(TiresetType.Standard);

        // TODO: Add car base price (cost) to user's shopping list
        // TODO: Add standard tires (free) to user's shopping list
        // TODO: Add to a shopping list here at some point...
        currentPriceText.text = "Running total: £" + myCarInstance.GetTotalSpend().ToString();
    }

    public void SetTireset(TiresetType tiresetToShow)
    {
        //Debug.Log(tiresetToShow);
        // TODO: Remove existing tireset from object
        // TODO: Remove from shopping list
        // TODO: Add new value to shopping list
        HideTiresetPrefabs();
        ShowTiresetPrefab(tiresetToShow);
    }

    public void HideTiresetPrefabs()
    {
        GameObject newCarPrefab = GameObject.FindGameObjectWithTag("Car"); // should be the new object at this point. it isn't
        Transform[] transforms = newCarPrefab.GetComponentsInChildren<Transform>();

        foreach (Transform transform in transforms)
        {
            if (transform.name == "Tiresets")
            {
                foreach (Transform tireSet in transform)
                {
                    tireSet.gameObject.SetActive(false);
                }
            }
        }
    }

    public void ShowTiresetPrefab(TiresetType tiresetToShow)
    {
        GameObject newCarPrefab = GameObject.FindGameObjectWithTag("Car"); // should be the new object at this point. it isn't
        Transform[] transforms = newCarPrefab.GetComponentsInChildren<Transform>();

        foreach (Transform transform in transforms)
        {
            if (transform.name == "Tiresets")
            {
                foreach (Transform tireSet in transform)
                {
                    if (tireSet.gameObject.name == "Standard" && tiresetToShow == TiresetType.Standard)
                    {
                        tireSet.gameObject.SetActive(true);
                        break;
                    }
                    else if (tireSet.gameObject.name == "Spiked" && tiresetToShow == TiresetType.Spiked)
                    {
                        tireSet.gameObject.SetActive(true);
                        break;
                    }
                    else
                    {
                        tireSet.gameObject.SetActive(false);
                    }
                }
                break;
            }
        }
    }
}
