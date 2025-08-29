using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    //time
    [SerializeField] private float timer = 1f;

    //obstáculo
    [SerializeField] private GameObject obstaculo;

    //Posição do obstáculo para criar
    [SerializeField] private Vector3 posicao;

    //Pos min e max para o obstáculo
    [SerializeField] private float posmin = -0.25f;
    [SerializeField] private float posmax = 3.5f;

    //Tempo mim e max
    [SerializeField] private float tempoMin = 1f;
    [SerializeField] private float tempoMax = 3f;

    //Velocidade do obstáculo
    [SerializeField] private float velocidade = 4f;

    //GameObject para destruir
    [SerializeField] private GameObject eu;


    //Criando a variavel de GameController
    [SerializeField] private GameController game;

    //Level
    public int level = 1;
    void Start()
    {
        Destroy(eu, 5f);

        // Pegando o GameController da cena
        game = FindObjectOfType<GameController>();

        level = game.RetorneLevel();

        timer = Random.Range(tempoMin / Mathf.Max(level, 1), tempoMax);

    }

    // Update is called once per frame
    void Update()
    {
        CriandoObstaculo();
        MovendoObstaculo();
    }

    public void CriandoObstaculo()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(obstaculo, posicao, Quaternion.identity);

            //Resetando o Timer
            timer = Random.Range(tempoMin / Mathf.Max(level, 1), tempoMax);

            posicao.y = UnityEngine.Random.Range(posmin, posmax);
        }
    }
    public void MovendoObstaculo()
    {
        // indo para a esquerda
        transform.position += Vector3.left * Time.deltaTime * velocidade;

        velocidade = 4f + game.RetorneLevel();
    }
}
