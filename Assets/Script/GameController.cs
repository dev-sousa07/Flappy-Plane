using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    //time
    [SerializeField] private float Timer = 1f;

    //obstáculo
    [SerializeField] private GameObject obstaculo;

    //Posição do obstáculo para criar
    [SerializeField] private Vector3 posicao;

    //Pos min e max para o obstáculo
    [SerializeField] private float posmin = -0.25f;
    [SerializeField] private float posmax = 3.5f;

 

    //Tempo mim e max
    [SerializeField] private float tempoMin = 1f;
    [SerializeField] private float tempoMax = 2f;

    //Score
    private float score = 0f;

    //Variavel dos pontos do canvas
    [SerializeField] private Text CanvasScore;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        CriandoObstaculo();
        Score();
        
    }

    private void CriandoObstaculo()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Instantiate(obstaculo, posicao, Quaternion.identity);

            //Resetando o Timer
            Timer = Random.Range(tempoMin, tempoMax);

            posicao.y = Random.Range(posmin, posmax);
        }
    }

    private void Score()
    {
        //Pontos
        

        //Passando o score para o canvas
        

    }
}
