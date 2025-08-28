using UnityEngine;

public class GameService
{
    // Variáveis
    private float Timer = 1f;
    private GameObject obstaculo;
    private Vector3 posicao = new Vector3(10, 0, 0);

    private float posmin = -0.25f;
    private float posmax = 3.5f;
    private float tempoMin = 1f;
    private float tempoMax = 3f;
    private float score = 0f;

    private int level = 1;
    public float proximoLevel = 10f;

    public void AdicionarScore(float valor)
    {
        score += valor;
    }

    public void AtualizarLevel()
    {
        if (score > proximoLevel)
        {
            level++;
            proximoLevel *= 2;
        }
    }

    public int RetorneLevel()
    {
        return level;
    }

    public float RetorneScore()
    {
        return score;
    }

}
