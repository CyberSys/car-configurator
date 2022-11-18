using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownCarSelect : MonoBehaviour
{
    private GameManager gameManager;
    private Dropdown dropdownCarSelect;
    private Dropdown dropdownTiresetSelect;
    private TMP_Text currentSelectionText;
    
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentSelectionText = GameObject.Find("LabelCurrentSelection").GetComponent<TMP_Text>();
        dropdownCarSelect = transform.GetComponent<Dropdown>();
    }

    void Start()
    {
        dropdownTiresetSelect = GameObject.Find("DropdownSelectTireset").GetComponent<Dropdown>();

        // Set correct default dropdown selecton
        dropdownCarSelect.value = (int) gameManager.myCarInstance.GetCarType();
        
        // Set selection label default
        currentSelectionText.text = "Configuring: " + gameManager.myCarInstance.GetCarFullNameAsString(
                                                        gameManager.myCarInstance.GetCarType());
    }

    private void ResetDropdowns()
    {
        dropdownTiresetSelect.value = 0;
    }

    public void ShowNextCar()
    {
        ResetDropdowns();

        // Pass the dropdown selection value as a CarType to gameManager
        gameManager.ChangeCar((CarType) dropdownCarSelect.value);

        // Change selection label
        currentSelectionText.text = "Configuring: " + gameManager.myCarInstance.GetCarFullNameAsString((CarType) dropdownCarSelect.value);
    }
}
