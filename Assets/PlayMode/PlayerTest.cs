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

        // Adiciona Rigidbody2D player
        rb = player.AddComponent<Rigidbody2D>();

        // Atribui ao PlayerController (se ele usar rb p�blico)
        controller.rb = rb;

        // Criar obsat�culo tempor�rio
        obstaculo = new GameObject("Obstaculo");

        // Colis�o
        col = obstaculo.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        // Rigidbody2D Obst�culo
        Rigidbody2D rbObstaculo = obstaculo.AddComponent<Rigidbody2D>();
        rbObstaculo.isKinematic = true;

    }

    [TearDown]
    public void TearDown()
    {
        // Destr�i o player ap�s cada teste
        Object.Destroy(player);
        Object.Destroy(obstaculo);
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
    public IEnumerator PlayerPula()
    {
        // Reseta a velocidade
        rb.velocity = Vector2.zero;

        // Chama o m�todo direto, sem depender do Input
        controller.Pular();

        // Espera a f�sica atualizar
        yield return new WaitForFixedUpdate();

        // Verifica se a velocidade Y aumentou
        Assert.Greater(rb.velocity.y, 0, "O Player n�o pulou.");
    }


    [UnityTest]
    public IEnumerator PlayerMorre()
    {
        // Simula a morte do player
        controller.MorrendoAoSair();
        // Espera um frame
        yield return null;
        // Verifica se o jogo reiniciou (a cena foi recarregada)
        Assert.AreEqual("Jogo", SceneManager.GetActiveScene().name, "A cena n�o foi reiniciada ap�s a morte do Player.");
    }

   
    [UnityTest]
    public IEnumerator ObstaculoExiste()
    {
       Assert.IsNotNull(obstaculo, "O Obst�culo n�o foi encontrado na cena.");
        yield return null;
    }


    [UnityTest]
    public IEnumerator ColisaoComObstaculo()
    {
        // Adiciona colisor ao Player
        var playerCollider = player.AddComponent<BoxCollider2D>();
        playerCollider.isTrigger = true;


        // Posiciona os dois para colidirem
        player.transform.position = Vector3.zero;
        obstaculo.transform.position = Vector3.zero;

        // Espera a f�sica rodar
        yield return new WaitForFixedUpdate();

        // Trocar de cena
        Assert.AreEqual("Jogo", SceneManager.GetActiveScene().name);
    }

}
