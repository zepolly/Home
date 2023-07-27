using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    private float speed = 15f;
    private float force = 10f;
    private float rotationSpeed = 60f;
    private float vertical;
    private float horizontal;
    private Rigidbody playerRb;
    private GameManager gameManager;
    public GameObject gameOverText;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime);
            transform.Rotate(Vector3.up * rotationSpeed * horizontal * Time.deltaTime);

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("home") && gameManager.complited)
        {
            gameManager.isGameActive = false;
            gameManager.gameOver = true;
            gameOverText.SetActive(true);
        }
    }
}
