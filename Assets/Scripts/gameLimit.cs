using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLimit : MonoBehaviour
{

    private Rigidbody playerRb; // Variável que armazena o valor atribuido na linha 12
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GameBorder();
    }

    void GameBorder() // Define os limites para o jogador não ultrapassar a direita ou esquerda
    {
        if (transform.position.x > 1.9)
        {
            transform.position = new Vector3(1.9f, transform.position.y, 0);
            playerRb.Sleep();
        }
        if (transform.position.x < -1.9)
        {
            transform.position = new Vector3(-1.9f, transform.position.y, 0);
            playerRb.Sleep();
        }
    }
}
