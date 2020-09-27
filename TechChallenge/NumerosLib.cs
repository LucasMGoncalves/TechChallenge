using System;
using System.Collections.Generic;
using System.Linq;

namespace TechChallenge.Lib
{
    public class NumerosLib
    {
        /// <summary>
        /// Indica se um número é primo ou não.
        /// </summary>
        /// <param name="numero">Número a ser verificado</param>
        /// <returns></returns>
        public static bool EhPrimo(int numero)
        {
            try
            {
                //Números primos são os números naturais que têm apenas dois divisores diferentes: o 1 e ele mesmo.
                if (numero <= 1)
                    return false;

                int fator = numero / 2;

                for (int i = 2; i <= fator; i++)
                {
                    if ((numero % i) == 0)
                        return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Ocorreu um erro ao verificar se um número é primo. Erro: " + ex.Message);
            }
        }

        //Referência: https://www.youtube.com/watch?v=uA3cIqRFku0&t=75s

        /// <summary>
        /// Retorna uma lista com a decomposição em fatores primos do número informado
        /// </summary>
        /// <param name="numero">Número natural a ser decomposto</param>
        /// <param name="exibirTodasDivisoes">Caso não desejar exibir todas as divisões realizadas, retorna os valores sem os repetir</param>
        /// <returns></returns>
        public static List<int> DecomporEmFatoresPrimos(int numero, bool exibirTodasDivisoes = true)
        {
            try
            {
                if (numero <= 0)
                    return new List<int>();

                List<int> listaNumeroPrimos = new List<int>();
                for (int i = 2; i <= numero; i++)
                {
                    if (EhPrimo(i))
                        listaNumeroPrimos.Add(i);
                }

                List<int> listaFatoresPrimos = new List<int>();

                int quociente = numero;
                int divisor;
                int index = 0;

                while (quociente != 1)
                {
                    divisor = listaNumeroPrimos[index];

                    if (quociente % divisor == 0)
                    {
                        quociente = quociente / divisor;
                        listaFatoresPrimos.Add(divisor);

                        index = 0;
                    }
                    else
                        index++;

                }

                if (!exibirTodasDivisoes)
                    listaFatoresPrimos = listaFatoresPrimos.Distinct().ToList();

                return listaFatoresPrimos;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Ocorreu um erro ao decompor os fatores primos. Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna a lista dos divisores de um número atráves da decomposição de seus fatores primos
        /// </summary>
        /// <param name="listaFatoresPrimos"></param>
        /// <returns></returns>
        public static List<int> ObterDivisores(int numero)
        {
            try
            {
                List<int> listaFatoresPrimos = DecomporEmFatoresPrimos(numero);

                List<int> listaDivisores = new List<int>();
                //1 é um divisor de qualquer número natural
                listaDivisores.Add(1);

                List<int> listaLinhaDivisores = new List<int>();

                int divisor;
                for (int i = 0; i < listaFatoresPrimos.Count; i++)
                {
                    for (int j = 0; j < listaDivisores.Count; j++)
                    {
                        divisor = listaFatoresPrimos[i] * listaDivisores[j];
                        listaLinhaDivisores.Add(divisor);
                    }

                    foreach (int item in listaLinhaDivisores)
                        if (!listaDivisores.Contains(item))
                            listaDivisores.Add(item);
                }

                listaDivisores.Sort();

                return listaDivisores;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Ocorreu um erro ao obter os divisores. Erro: " + ex.Message);
            }
        }
    }
}