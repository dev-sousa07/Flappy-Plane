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
        // Chamando método subir
        Subir();

        // Chamando método limitando
        Limitando();

        //Chamando método morrendo ao sair
        MorrendoAoSair();

        
    }

    // Criando Método Subir
    public void Subir()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocidade;

            // Instanciando o puff
            // Salvando a instância do puff em um variável
            GameObject puf = Instantiate(puff, transform.position, Quaternion.identity);

            // Destruindo o puff após 0.5 segundos
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


    //Colisão
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificando se colidiu com obstáculo
        if (collision.gameObject.CompareTag("Obstáculo"))
        {
            // Reiniciando o jogo
            SceneManager.LoadScene("Inicio");
           

        }
       
    }
}

