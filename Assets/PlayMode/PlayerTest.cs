using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerPlayModeTests 
{
    private GameObject player;
    private PlayerController controller;
    private Rigidbody2D rb;
    private GameObject obstaculo;
    private BoxCollider2D col;

    [SetUp]
    public void Setup()
    {
        // Cria um player tempor�rio
        player = new GameObject("Player");

        // Adiciona o PlayerController
        controller = player.AddComponent<PlayerController>();

        // Criar obsat�culo tempor�rio
        obstaculo = new GameObject("Obstaculo");

        // Colis�o
        col = obstaculo.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        // Adiciona Rigidbody2D 
        rb = player.AddComponent<Rigidbody2D>();


        // Atribui ao PlayerController (se ele usar rb p�blico)
        controller.rb = rb;
    }

    [TearDown]
    public void TearDown()
    {
        // Destr�i o player ap�s cada teste
        Object.Destroy(player);
    }

    [UnityTest]
    
    public IEnumerator CenaExiste()
    {
      // Carrega a cena
        SceneManager.LoadScene("Jogo");

        // Espera at� a cena ser a ativa
        while (SceneManager.GetActiveScene().name != "Jogo")
        {
            yield return null; // espera 1 frame
        }

    }

    [UnityTest]
    public IEnumerator PlayerExiste()
    {
        // Verifica se o Player e seus componentes existem
        Assert.IsNotNull(player, "O Player n�o foi criado.");
        Assert.IsNotNull(controller, "O PlayerController n�o foi adicionado.");
        Assert.IsNotNull(rb, "O Player n�o possui Rigidbody2D.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator ObstaculoExiste()
    {
       Assert.IsNotNull(obstaculo, "O Obst�culo n�o foi encontrado na cena.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator MovimentoDoObstaculo()
    {
        // Define a posi��o inicial do obst�culo
        obstaculo.transform.position = new Vector3(5, 0, 0);
        // Move o obst�culo para a esquerda
        float velocidade = 2f;
        float deltaTime = Time.deltaTime;
        obstaculo.transform.Translate(Vector3.left * velocidade * deltaTime);
        // Verifica se o obst�culo se moveu
        Assert.Less(obstaculo.transform.position.x, 5, "O obst�culo n�o se moveu para a esquerda.");
        yield return null;
    }
}
