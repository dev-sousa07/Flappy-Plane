using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.Mathematics;
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
    [SerializeField] private float tempoMax = 3f;

    //Score
    private float score = 0f;

    //Variavel dos pontos do canvas
    [SerializeField] private TextMeshProUGUI CanvasScore;

    //Variável de Level
    private int level = 1;

    // Variável pra ganhar level
    [SerializeField] private float proximoLevel = 10f;

    //Variável para o canvas de level
    [SerializeField] private TextMeshProUGUI CanvasLevel;

    //musica
    [SerializeField] private AudioClip musica;

    //Camra pos
    private Vector3 camerapos;
    void Start()
    {
     camerapos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CriandoObstaculo();
        Score();
        Level();
    }

    private void CriandoObstaculo()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Instantiate(obstaculo, posicao, Quaternion.identity);

            //Resetando o Timer
            Timer = UnityEngine.Random.Range(tempoMin / level, tempoMax);

            posicao.y = UnityEngine.Random.Range(posmin, posmax);
        }
    }

    private void Score()
    {

        //Pontos
        score += Time.deltaTime;

        //Passando o score para o canvas
        CanvasScore.text = math.round(score).ToString();


    }

    private void Level()
    {
        if (score > proximoLevel)
        {
            level++;                    
            proximoLevel = proximoLevel * 2;
            Debug.Log(level);
            AudioSource.PlayClipAtPoint(musica, camerapos);

        }

        //Passando o level para o canvas
        CanvasLevel.text = math.round(level).ToString();
    }

    public int RetorneLevel()
    {
        return level;
    }
}
