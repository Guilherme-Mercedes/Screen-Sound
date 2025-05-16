using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroProjeto
{
    internal class Avaliador
    {
        private RepositorioBanda repositorio;

        public Avaliador(RepositorioBanda repositorio)
        {
            this.repositorio = repositorio;
        }

        public void AvaliarBanda()
        {
            Console.Clear();
            //verificar se existe banda registrada
            if (repositorio.listaDeBandas.Count > 0)
            {
                string nomeBanda;
                int nota;
                //mostrar as bandas registradas, reaproveitei a linha de codigo da funcao MostrarBandas
                //futuramente posso criar uma funcao somente com o foreach para reaproveitar de forma mais limpa
                Utils.GerarLayoutTitulo("Bandas registradas:");
                foreach (Banda banda in repositorio.listaDeBandas)
                {
                    Console.WriteLine("Banda: {0}", banda);
                }
                Console.WriteLine("");//para dar um espacamento, o \n acaba atrapalhando a funcao GerarLayoutTitulo
                Utils.GerarLayoutTitulo("Avaliar banda");
                Console.Write("Digite o nome da banda: ");
                nomeBanda = Console.ReadLine()!;

                //Procura na lista de bandas a banda digitada com uma comparacao lambda
                var bandaSelecionada = repositorio.listaDeBandas.FirstOrDefault(b => b.Nome.Equals(nomeBanda, StringComparison.OrdinalIgnoreCase));

                //Verifica se a banda digitada existe
                if (bandaSelecionada != null)
                {
                    Console.Clear();
                    //verifica se o usuario digitou uma nota valida
                    while (true)
                    {
                        Console.Write("Digite a nota de 0 a 10 para a banda {0}:", nomeBanda);
                        if (int.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 10)
                            break;
                        Console.WriteLine("Nota inválida. Tente novamente.");
                    }
                    bandaSelecionada.Notas.Add(nota);
                    Console.WriteLine("A nota {0} da banda {1} foi registrada com sucesso", nota, nomeBanda);
                    Thread.Sleep(2000);


                }
                else
                {
                    Console.WriteLine("\nA banda {0} nao foi encontrada", nomeBanda);
                    Console.WriteLine("Digite 1 para voltar na avaliacao de banda ou 0 para voltar ao menu");

                    if (Console.ReadLine() == "1")
                    {
                        AvaliarBanda();
                    }

                }
            }
            else
            {
                Console.Clear();
                Utils.GerarLayoutTitulo("Nenhuma banda registrada para avaliacao \nretornando ao menu...");
                Thread.Sleep(2500);
            }
        }

        public void ExibirMediaBanda()
        {
            Console.Clear();

            if (repositorio.listaDeBandas.Count != 0)
            {
                Utils.GerarLayoutTitulo("Nota média das Bandas:\n");

                foreach (Banda banda in repositorio.listaDeBandas)
                {
                    if (banda.Notas.Count == 0)
                    {
                        Console.WriteLine("A banda {0} ainda não possui notas registradas", banda.Nome);
                    }
                    else
                    {
                        Console.WriteLine("Banda: {0} | Nota média: {1:F2}", banda.Nome, banda.Media);
                    }
                }

                Console.WriteLine("\nDigite qualquer tecla para sair!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Utils.GerarLayoutTitulo("Nenhuma banda registrada!");
                Thread.Sleep(2500);
            }
        }


    }
}
