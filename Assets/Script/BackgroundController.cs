using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update

    //Meu Material
    private Renderer meufundo;

    //Posi�ao do meu x offset
    private float xOffset = 0f;

    //posicao da minah textura
    private Vector2 texturaOffset;

    // Velocidade fundo
    [SerializeField] private float velocidadeFundo = 0.1f;

    void Start()
    {
        // Pegando o fundo
        meufundo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dimi uindo o x offset
        xOffset += Time.deltaTime * velocidadeFundo;

        //Passano o x offset para o x da textura
        texturaOffset.x = xOffset;

        //Movendo o offset x do Renderer
        meufundo.material.mainTextureOffset = texturaOffset;
    }
}
