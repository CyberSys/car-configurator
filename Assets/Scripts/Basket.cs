using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    Dictionary<string, int> basketItems = new Dictionary<string, int>();

    void Awake()
    {
        Basket[] existingBaskets = FindObjectsOfType<Basket>();

        if (existingBaskets.Length > 0)
        {
            Destroy(existingBaskets[0]);
        }

        DontDestroyOnLoad(gameObject);
    }

    /*********************************************************************
     * Class property getters
     *********************************************************************/
    public void LogBasketItems()
    {
        Debug.Log("basketItems contains " + basketItems.Count + " items:");
        foreach (KeyValuePair<string, int> item in basketItems)
        {
            Debug.Log(item.Key + ": " + item.Value);
        }
    }

    /*********************************************************************
     * Class property setters
     *********************************************************************/
    public void SetBasketDefaults()
    {
        SetBasketNewItem("CarType", 0);        // buggy
        SetBasketNewItem("TiresetType", 0);    // standard tireset (free)
        SetBasketNewItem("FrontType", 0);      // none
        SetBasketNewItem("WeaponType", 0);     // none
    }

    public void ResetBasket()
    {
        SetBasketChangeItem("CarType", 0);        // buggy
        SetBasketChangeItem("TiresetType", 0);    // standard tireset (free)
        SetBasketChangeItem("FrontType", 0);      // none
        SetBasketChangeItem("WeaponType", 0);     // none
    }

    public void SetBasketChangeItem(string configurableType, int configurableValue)
    {
        if (basketItems.ContainsKey(configurableType))
        {
            basketItems[configurableType] = configurableValue;
        }
    }
  
    void SetBasketNewItem(string configurableType, int configurableValue)
    {
        basketItems.Add(configurableType, configurableValue);
    }
}
