using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPoint : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == ball)
        {
            button.SetActive(true);
            ball.SetActive(false);
        }
    }
}
