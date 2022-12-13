using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownTiresetSelect : MonoBehaviour
{
    private GameManager gameManager;
    private Basket basket;
    private Dropdown dropdown;
    private TMP_Text userSelectionsLabel;

    void Awake()
    {
        basket = GameObject.FindObjectOfType<Basket>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dropdown = transform.GetComponent<Dropdown>();
        userSelectionsLabel = GameObject.Find("LabelCurrentSelection").GetComponent<TMP_Text>();
    }

    void Start()
    {
        // Set correct default dropdown selecton
        dropdown.value = (int) gameManager.myCarInstance.GetTiresetType();
    }

    public void ShowNextTireset()
    {
        // Pass the dropdown selection value as a TiresetType to gameManager
        gameManager.SetTireset((TiresetType) dropdown.value);
        userSelectionsLabel.text = basket.GetBasketItemsAsString();
    }
}
