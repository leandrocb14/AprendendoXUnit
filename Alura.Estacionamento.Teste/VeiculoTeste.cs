using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Teste;

/*
    Padrão AAA é composto pelo arrange, act e assert
    - Arrange é onde é preparado o ambiente
    - Act é onde executado o método que vai ser testado
    - Assert é onde é verificado se o resultado obtido é o resultado esperado
 */

public class VeiculoTeste
{
    [Fact(DisplayName = "Teste  nº1")]
    public void TestaVeiculoAcelerar()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste  nº2")]
    public void TestarVeiculoFreiar()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Frear(10);
        //Assert
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste nº3",  Skip = "Teste não implementado")]
    public void ValidaNomeProprietario()
    {

    }
}
