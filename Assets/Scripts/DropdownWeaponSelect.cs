using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownWeaponSelect : MonoBehaviour
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
        dropdown.value = (int) gameManager.myCarInstance.GetWeaponType();
    }

    public void ShowNextWeapon()
    {
        // Pass the dropdown selection value as a WeaponType to gameManager
        gameManager.SetWeapon((WeaponType) dropdown.value);
        userSelectionsLabel.text = basket.GetBasketItemsAsString();
    }
}
