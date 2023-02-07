using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Teste;

/*
    Padrão AAA é composto pelo arrange, act e assert
    - Arrange é onde é preparado o ambiente
    - Act é onde executado o método que vai ser testado
    - Assert é onde é verificado se o resultado obtido é o resultado esperado
 */

public class VeiculoTeste : IDisposable
{
    private Veiculo veiculo;
    private ITestOutputHelper testOutputHelper;

    public VeiculoTeste(ITestOutputHelper pTestOutputHelper)
    {
        veiculo = new Veiculo();
        testOutputHelper = pTestOutputHelper;
        testOutputHelper.WriteLine("Construtor invocado");
    }

    [Fact]
    public void TestaVeiculoAcelerarComParametro10()
    {
        //Arrange
        //var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestarVeiculoFreiarComParametro10()
    {
        //Arrange
        //var veiculo = new Veiculo();
        //Act
        veiculo.Frear(10);
        //Assert
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact(Skip = "Teste não implementado")]
    public void ValidaNomeProprietarioDoVeiculo()
    {

    }

    public void Dispose()
    {
        testOutputHelper.WriteLine("Dispose invocado");
    }
}
