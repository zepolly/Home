using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] firefly;
    private int index;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnFirefly", 2, 10f);
    }

    // Update is called once per frame
    void SpawnFirefly()
    {
        if (gameManager.isGameActive)
        {
            index = Random.Range(0, firefly.Length);
            Vector3 position = new Vector3(Random.Range(-220,110), Random.Range(3, 15), Random.Range(-53, 218));
            Instantiate(firefly[index], position, firefly[index].transform.rotation);
        }
    }
}
