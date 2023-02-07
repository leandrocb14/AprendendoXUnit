using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit.Abstractions;
using Xunit.Sdk;

/*
    Padrão AAA é composto pelo arrange, act e assert
    - Arrange é onde é preparado o ambiente
    - Act é onde executado o método que vai ser testado
    - Assert é onde é verificado se o resultado obtido é o resultado esperado
 */

namespace Alura.Estacionamento.Teste
{
    public class PatioTeste : IDisposable
    {
        private Veiculo veiculo;
        private ITestOutputHelper testOutputHelper;

        public PatioTeste(ITestOutputHelper pTestOutputHelper)
        {
            veiculo = new Veiculo();
            testOutputHelper = pTestOutputHelper;
            testOutputHelper.WriteLine("Construtor invocado");
        }

        [Fact]
        public void ValidaFaturamentoComAutomovel()
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Leandro";
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
        public void ValidaFaturamentoDoEstacionamentoComVariosAutomoveis(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
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

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoPatioPorPlaca(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var veiculoConsultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, veiculoConsultado.Placa);
        }

        [Theory]
        [InlineData("ASD-1498")]
        public void TestaVeiculoNaoEstacioando(string placa)
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Leandro";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Uno";
            veiculo.Placa = "OTH-1951";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var veiculoConsultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Null(veiculoConsultado);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Leandro";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Uno";
            veiculo.Placa = "KJY-1234";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            Veiculo veiculoAlterado = new Veiculo();
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Azul";
            veiculoAlterado.Modelo = "Opala";
            veiculoAlterado.Placa  = "OLD-1234";

            //Act
            veiculo.AlterarDados(veiculoAlterado);
            var veiculoConsultado = estacionamento.PesquisaVeiculo(veiculoAlterado.Placa);

            //Assert
            Assert.Equal(veiculoAlterado.Placa, veiculoAlterado.Placa);
        }

        public void Dispose()
        {
            testOutputHelper.WriteLine("Dispose invocado");
        }
    }
}

