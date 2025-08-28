using NUnit.Framework;

public class GameServiceTests
{
    private GameService game;

    [SetUp]
    public void SetUp()
    {
        // Cria uma nova inst�ncia antes de cada teste
        game = new GameService();
    }

    [Test]
    public void TesteScoreInicial()
    {
        // Score deve come�ar em 0
        Assert.AreEqual(0f, game.RetorneScore());
    }

    [Test]
    public void TesteLevelInicial()
    {
        // Level inicial deve ser 1
        Assert.AreEqual(1, game.RetorneLevel());
    }

    [Test]
    public void TesteAdicionarScore()
    {
        // Adiciona score
        game.AdicionarScore(5f);

        // Verifica se o score aumentou
        Assert.AreEqual(5f, game.RetorneScore());
    }

    [Test]
    public void TesteAtualizarLevel()
    {
        // Score menor que proximoLevel n�o deve aumentar level
        game.AdicionarScore(5f);
        game.AtualizarLevel();
        Assert.AreEqual(1, game.RetorneLevel());

        // Score maior que proximoLevel deve aumentar level
        game.AdicionarScore(10f); // total 15f
        game.AtualizarLevel();
        Assert.Greater(game.RetorneLevel(), 1);
    }

}
