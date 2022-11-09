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
        GameObject myCarPrefab = GameObject.FindGameObjectWithTag("Car");
        if (myCarPrefab != null)
        {
            Debug.Log("Destroying old: " + myCarPrefab.GetComponent<Transform>().name);
            Destroy(myCarPrefab.gameObject);
            myCarPrefab = null;
        }

        // Create an instance of the Buggy
        myCarInstance = ScriptableObject.CreateInstance<Car>();
        myCarInstance.SetDefaultConfig(carType);

        // Show it in the world
        myCarPrefab = (GameObject) Instantiate(myCarInstance.getPrefab(), spawnPoint.transform.position, spawnPoint.transform.rotation);
        //myCarPrefab.name = "CurrentCarSelection";

        // Set base prices in instance object
        myCarInstance.SetCarBasePriceTotal(carType);
        myCarInstance.SetTiresetPriceTotal(TiresetType.Standard);
        ShowTiresetPrefab(TiresetType.Standard);

        // TODO: Add car base price (cost) to user's shopping list
        // TODO: Add standard tires (free) to user's shopping list

        // TODO: Add to a shopping list here at some point...
        currentPriceText.text = "Running total: £" + myCarInstance.GetTotalSpend().ToString();
    }

    public void ShowTiresetPrefab(TiresetType tiresetToShow)
    {
        GameObject newCarPrefab = GameObject.FindGameObjectWithTag("Car");
        Transform[] transforms = newCarPrefab.GetComponentsInChildren<Transform>();

        Debug.Log(tiresetToShow);

        foreach (Transform transform in transforms)
        {
            if (transform.name == "Tiresets")
            {
                foreach (Transform tireSet in transform)
                {
                    if (tireSet.gameObject.name == "Standard" && tiresetToShow == TiresetType.Standard)
                    {
                        tireSet.gameObject.SetActive(true);
                    }
                    else
                    {
                        tireSet.gameObject.SetActive(false);
                    }
                }
                return;
            }
        }


    }
}
