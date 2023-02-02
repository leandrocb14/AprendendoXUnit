using System;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

/*
    Padrão AAA é composto pelo arrange, act e assert
    - Arrange é onde é preparado o ambiente
    - Act é onde executado o método que vai ser testado
    - Assert é onde é verificado se o resultado obtido é o resultado esperado
 */

namespace Alura.Estacionamento.Teste
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo("Pedrinho");
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            //Act
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Assert
            Assert.Equal(2, estacionamento.TotalFaturado());
        }

        //Cria uma lista de parâmetros para serem testados
        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
        [InlineData("Josa Silva", "POL-1498", "Cinza", "Fusca")]
        [InlineData("Maria Silva", "GRD-1498", "Azul", "Opala")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo(proprietario);
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            //Act
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            //Assert
            Assert.Equal(2, estacionamento.TotalFaturado());
        }
    }
}

