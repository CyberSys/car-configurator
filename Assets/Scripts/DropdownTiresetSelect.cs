using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownTiresetSelect : MonoBehaviour
{
    private GameManager gameManager;
    private Dropdown dropdown;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dropdown = transform.GetComponent<Dropdown>();
    }

    void Start()
    {
        // Set correct default dropdown selecton
        dropdown.value = (int) gameManager.myCarInstance.GetTireset();
    }

    public void ShowNextTireset()
    {
        // Pass the dropdown selection value as a TiresetType to gameManager
        gameManager.SetTireset((TiresetType) dropdown.value);
    }
}
