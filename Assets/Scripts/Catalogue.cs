using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catalogue : MonoBehaviour
{
    private GameManager gameManager;
    private Button closeButton;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        closeButton = GameObject.Find("CatalogueCloseButton").GetComponent<Button>();
    }

    public void CloseCatalogue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void ShowCatalogue()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
