using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownHandler : MonoBehaviour
{
    private GameManager gameManager;
    private Dropdown dropdown;
    private TMP_Text currentSelectionText;
    
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentSelectionText = GameObject.Find("LabelCurrentSelection").GetComponent<TMP_Text>();
        dropdown = transform.GetComponent<Dropdown>();

    }

    void Start()
    {
        
    }

    public void ShowNextCar()
    {
        // Pass the dropdown selection value as a CarType to gameManager
        gameManager.ChangeCar((CarType) dropdown.value);

        // Change selection label
        currentSelectionText.text = "Configuring: " + gameManager.myCarInstance.GetCarFullNameAsString((CarType)dropdown.value);
    }
}
