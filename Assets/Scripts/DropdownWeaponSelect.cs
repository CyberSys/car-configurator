using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownWeaponSelect : MonoBehaviour
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
        dropdown.value = (int) gameManager.myCarInstance.GetWeaponType();
    }

    public void ShowNextWeapon()
    {
        // Pass the dropdown selection value as a WeaponType to gameManager
        gameManager.SetWeapon((WeaponType) dropdown.value);
    }
}
