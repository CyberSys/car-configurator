using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Start()
    {
        GameObject[] oldShoppingBasket = GameObject.FindGameObjectsWithTag("ShoppingBasket");

        if (oldShoppingBasket.Length > 0)
        {
            Destroy(oldShoppingBasket[0]);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}
