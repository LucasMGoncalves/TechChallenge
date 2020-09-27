using System;
using Xunit;
using TechChallenge.Lib;
using System.Collections.Generic;
using System.Linq;

namespace TechChallenge.Tests
{
    public class NumerosLibTests
    {
        // Valida o método que verifica se o número é ou não primo
        [Fact]
        public void TestaEhPrimoTrue()
        {
            bool ehPrimo = NumerosLib.EhPrimo(5);
            Assert.True(ehPrimo);
        }

        [Fact]
        public void TestaEhPrimoFalse()
        {
            bool ehPrimo = NumerosLib.EhPrimo(10);
            Assert.False(ehPrimo);
        }

        // Verifica se todos os números obtidos na decomposisão dos fatores primos são de fato primos
        [Theory]
        [InlineData(18)]
        [InlineData(60)]
        public void TestaDecomposicaoFatoresPrimosSeTodosSaoPrimos(int numero)
        {
            List<int> listaFatoresPrimos = NumerosLib.DecomporEmFatoresPrimos(numero);

            bool todosSaoPrimos = true;
            foreach (int valor in listaFatoresPrimos)
            {
                if (!NumerosLib.EhPrimo(valor))
                    todosSaoPrimos = false;
            }

            Assert.True(todosSaoPrimos);
        }

        // Valida o resultado da decomposisão dos fatores primos efetuando a multiplicacão de todos eles e verificando se o resultado é o próprio número
        [Theory]
        [InlineData(18)]
        [InlineData(60)]
        public void TestaDecomposicaoFatoresPrimosMultiplicacaoFatoresIgualNumero(int numero)
        {
            List<int> listaFatoresPrimos = NumerosLib.DecomporEmFatoresPrimos(numero);

            int resultado = 1;
            listaFatoresPrimos.ForEach(v => resultado *= v);

            Assert.Equal(resultado, numero);
        }

        // Verifica se os divisores obtidos são realmente divisores
        [Theory]
        [InlineData(17)]
        [InlineData(60)]
        public void TestaObtencaoDivisoresNumerosSaoDivisores(int numero)
        {
            List<int> listaDivisores = NumerosLib.ObterDivisores(numero);

            bool todosSaoDivisores = true;
            foreach (int valor in listaDivisores)
            {
                if (numero % valor != 0)
                    todosSaoDivisores = false;
            }

            Assert.True(todosSaoDivisores);
        }

        // Verifica se dos divisores obtidos atráves da multiplicação dos fatores, o últimos deles é o próprio número
        [Theory]
        [InlineData(36)]
        [InlineData(60)]
        public void TestaObtencaoDivisoresMaiorDivisorEhEleMesmo(int numero)
        {
            int maiorDivisor = NumerosLib.ObterDivisores(numero).Last();
            Assert.Equal(maiorDivisor, numero);
        }

        public static IEnumerable<object[]> ResultadosDivisoresTeste()
        {
            yield return new object[] { 36, new List<int> { 1, 2, 3, 4, 6, 9, 12, 18, 36 } };
            yield return new object[] { 60, new List<int> { 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60} };
        }

        // Compara o retorno dos divisores obtidos a resultados confiáveis
        [Theory]
        [MemberData(nameof(ResultadosDivisoresTeste))]
        public void TestaObtencaoDivisoresListaDivisores(int numero, List<int> listaDivisores)
        {
            List<int> listaFatoresPrimos = NumerosLib.ObterDivisores(numero);
            Assert.Equal(listaFatoresPrimos, listaDivisores);
        }

    }
}