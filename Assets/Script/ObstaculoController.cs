using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidade = 4f;

    //GameObject para destruir
    [SerializeField] private GameObject eu;


    //Criando a variavel de GameController
    [SerializeField] private GameController game;
    void Start()
    {
        Destroy(eu, 5f);

        // Pegando o GameController da cena
        game = FindObjectOfType<GameController>();

       
    }

    // Update is called once per frame
    void Update()
    {
        // indo para a esquerda
        transform.position += Vector3.left * Time.deltaTime * velocidade;


        velocidade = 4f + game.RetorneLevel();
    }
}
