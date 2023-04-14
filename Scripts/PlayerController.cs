using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput; // Vari�vel que armazena o valor atribuido na linha 46
    private Rigidbody playerRb; // Vari�vel que armazena o valor atribuido na linha 23
    private Vector3 middlePosition; // Vari�vel que armazena o valor atribuido na linha 72
    private Vector3 rightPosition; // Vari�vel que armazena o valor atribuido na linha 73
    private Vector3 leftPosition; // Vari�vel que armazena o valor atribuido na linha 74

    public bool isMoving;
    public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        DetectMoviment(); 
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collision) // Detecta colis�o, quando colide com o ch�o, � setado isJumping = false
    {
        Debug.Log("Tocou no ch�o");
        if (collision.gameObject.CompareTag("Floor"))
        {
            
            isJumping = false;
        }
    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving) // Move para direita
        {
            playerRb.AddForce(new Vector3(10, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving) // Move para esquerda
        {
            playerRb.AddForce(new Vector3(-10, 0, 0), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isMoving) // Pula e define que isJumping = true
        {
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            isJumping = true;
        }

        if (playerRb.velocity.y <= -1.0f) // Faz com que o jogador volte para o ch�o mais r�pido
        {
            playerRb.AddForce(Vector3.down * 5, ForceMode.Acceleration);
        }
    }

    void DetectMoviment() // Define se o jogador est� movendo ou n�o
    {

        middlePosition = new Vector3(0, 0.5f, transform.position.z);
        rightPosition = new Vector3(1.9f, 0.5f, transform.position.z);
        leftPosition = new Vector3(-1.9f, 0.5f, transform.position.z);

        if (transform.position == rightPosition || transform.position == middlePosition || transform.position == leftPosition) 
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
}

