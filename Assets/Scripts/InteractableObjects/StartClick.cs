using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartClick : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    private bool screenActive = false;

    private void Update()
    {
        if (screenActive == false && Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            mainMenu.SetActive(true);
            screenActive = true;
        }
    }
}
