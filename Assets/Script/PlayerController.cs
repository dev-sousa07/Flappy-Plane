using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importando para reiniciar o jogo

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float velocidade = 5f;
    // Start is called before the first frame update
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
    }

    // Criando Método Subir
    public void Subir()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocidade;
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

    //Colisão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificando se colidiu com obstáculo
        if (collision.gameObject.CompareTag("Obstáculo"))
        {
            // Reiniciando o jogo
            SceneManager.LoadScene("");
            Debug.Log("Colidiu com obstáculo, reiniciando o jogo");

        }
    }
}

