using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar o jogo

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float velocidade = 5f;
    public GameObject puff;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Apenas captura o Input no Update
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pular();
        }

        Limitando();
        MorrendoAoSair();
    }

    // Método público para pular, pode ser chamado nos testes
    public void Pular()
    {
        if (rb == null) return;

        rb.velocity = Vector2.up * velocidade;

        if (puff != null)
        {
            GameObject puf = Instantiate(puff, transform.position, Quaternion.identity);
            Destroy(puf, 0.5f);
        }
    }

    public void Limitando()
    {
        if (rb.velocity.y < -velocidade)
        {
            rb.velocity = new Vector2(rb.velocity.x, -velocidade);
        }
    }

    public void MorrendoAoSair()
    {
        if (transform.position.y > 5f || transform.position.y < -5f)
        {
            SceneManager.LoadScene("Inicio");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstáculo"))
        {
            SceneManager.LoadScene("Inicio");
        }
    }
}
