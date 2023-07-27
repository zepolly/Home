using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firfly : MonoBehaviour
{
    public int pointValue;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
