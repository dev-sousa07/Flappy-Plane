using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importando para reiniciar o jogo

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float velocidade = 5f;
    // Start is called before the first frame update

    //Puff
    [SerializeField] private GameObject puff;
    void Start()
    {
        //Pegando o rb  
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Chamando m�todo subir
        Subir();

        // Chamando m�todo limitando
        Limitando();

        //Chamando m�todo morrendo ao sair
        MorrendoAoSair();

        
    }

    // Criando M�todo Subir
    public void Subir()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocidade;

            // Instanciando o puff
            // Salvando a inst�ncia do puff em um vari�vel
            GameObject puf = Instantiate(puff, transform.position, Quaternion.identity);

            // Destruindo o puff ap�s 0.5 segundos
            Destroy(puf, 0.5f);
        }
    }

    private void Limitando()
    {
        //Limitando a velocidade de queda
        if (rb.velocity.y < -velocidade)
        {
            // Travando a velocidade
            rb.velocity = Vector2.down * velocidade;
        }

   

    }

    private void MorrendoAoSair()
    {
        // Verificando se o jogador saiu da tela
        if (transform.position.y > 5f || transform.position.y < -5f)
        {
            // Reiniciando o jogo
            SceneManager.LoadScene("Inicio");
        }
    }


    //Colis�o
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificando se colidiu com obst�culo
        if (collision.gameObject.CompareTag("Obst�culo"))
        {
            // Reiniciando o jogo
            SceneManager.LoadScene("Inicio");
           

        }
       
    }
}

