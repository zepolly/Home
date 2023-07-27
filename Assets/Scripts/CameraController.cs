using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 positionCamera = new Vector3(82, 6, 42);
    // Start is called before the first frame update
    private float speedHorizontal = 2.0f;
    private float speedVertical = 2.0f;
    private float y = 0.0f;
    private float x = 0.0f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.position = player.transform.position + positionCamera;

            y += speedHorizontal * Input.GetAxis("Mouse X");
            x -= speedVertical * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(x, y, 0.0f);
        }
    }
}
