using System.Data;
using System.Runtime.Serialization;
using System.Xml;
//Projeto do curso de C# da Alura
//Um projeto de registro de banda
//Adendo para o futuro, alguns readline estao sem tratamento de null, utilizei o ! para forçar o compilador a aceitar, mas futuramente posso criar um tratamento de erro.

namespace PrimeiroProjeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> ListaDeBandas = new List<string>();
            //o "StringComparer.OrdinalIgnoreCase" Faz com que o dicionário ignore maiúsculas/minúsculas nas chaves evitando reutilizacoes de ToLower
            Dictionary<string, List<int>> listaDeBandas = new Dictionary<string, List<int>>(StringComparer.OrdinalIgnoreCase);
            ExibirOpcoesDoMenu();


            void ExibirLogo()
            {
                Console.Clear();
                Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
                Console.WriteLine("\nSeja bem vindo ao Screen Sound!");
            }

            void ExibirOpcoesDoMenu()
            {
                ExibirLogo();
                int opcao;
                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a média de uma banda");
                Console.WriteLine("Digite 0 para sair");
                opcao = int.Parse(Console.ReadLine()!);

                switch (opcao)
                {
                    case 1:
                        RegistrarBanda();
                        break;
                    case 2:
                        MostrarBandas();
                        break;
                    case 3:
                        AvaliarBanda();
                        break;
                    case 4:
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;

                }

            }

            //Registrar uma banda, o nome da banda
            //futuramente posso incluir um while
            //Deixar que o usuario no mesmo menu possa registrar mais de uma banda 
            void RegistrarBanda()
            {
                string nomeBanda;

                while (true)
                {
                    Console.Clear();
                    GerarLayoutTitulo("Registros de bandas");
                    Console.Write("Digite o nome da banda: ");
                    nomeBanda = Console.ReadLine();
                    //filtro para nao deixar a banda ser null e o registro duplicado
                    if (string.IsNullOrWhiteSpace(nomeBanda))
                    {
                        Console.WriteLine("\nO nome da banda nao pode estar em branco...");
                        Thread.Sleep(2000);
                        continue;
                    }
                    if (listaDeBandas.ContainsKey(nomeBanda))
                    {
                        Console.WriteLine("\nA banda {0} ja foi registrada, tente novamente", nomeBanda);
                        Thread.Sleep(2000);
                        continue;
                    }

                    listaDeBandas.Add(nomeBanda, new List<int>());
                    Console.Clear();
                    Console.WriteLine("A banda {0} foi adicionada com sucesso", nomeBanda);
                    Console.WriteLine("retornando ao menu...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                }
            }

            void MostrarBandas()
            {
                Console.Clear();

                if (listaDeBandas.Count == 0)
                {
                    GerarLayoutTitulo("Nenhuma banda registrada! \nretornando ao menu...");
                    Thread.Sleep(2500);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
                else
                {
                    GerarLayoutTitulo("Bandas registradas:\n");

                    /*for (int i = 0; i < ListaDeBandas.Count; i++)
                    {
                        Console.WriteLine("Banda: {0}", ListaDeBandas[i]);
                    }*/
                    foreach (string banda in listaDeBandas.Keys)
                    {
                        Console.WriteLine("Banda: {0}", banda);
                    }
                    Console.WriteLine("\n Digite qualquer tecla para sair!");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();

                }

            }

            void AvaliarBanda()
            {
                Console.Clear();
                //verificar se existe banda registrada
                if (listaDeBandas.Count != 0)
                {
                    string nomeBanda;
                    int nota;
                    //mostrar as bandas registradas, reaproveitei a linha de codigo da funcao MostrarBandas
                    //futuramente posso criar uma funcao somente com o foreach para reaproveitar de forma mais limpa
                    GerarLayoutTitulo("Bandas registradas:");
                    foreach (string banda in listaDeBandas.Keys)
                    {
                        Console.WriteLine("Banda: {0}", banda);
                    }

                    GerarLayoutTitulo("Avaliar banda");
                    Console.Write("Digite o nome da banda:");
                    nomeBanda = Console.ReadLine()!;
                    //Verifica se a banda digitada existe
                    if (listaDeBandas.ContainsKey(nomeBanda))
                    {
                        Console.Clear();
                        Console.Write("Digite a nota de 0 a 10 para a banda {0}:", nomeBanda);
                        nota = int.Parse(Console.ReadLine()!);
                        listaDeBandas[nomeBanda].Add(nota);
                        Console.WriteLine("A nota {0} da banda {1} foi registrada com sucesso", nota, nomeBanda);
                        Thread.Sleep(2000);
                        ExibirOpcoesDoMenu();

                    }
                    else
                    {
                        Console.WriteLine("\nA banda {0} nao foi encontrada", nomeBanda);
                        Console.WriteLine("Digite 1 para voltar na avaliacao de banda ou 0 para voltar ao menu");

                        if (Console.ReadLine() == "1")
                        {
                            AvaliarBanda();
                        }
                        else
                        {
                            ExibirOpcoesDoMenu();
                        }

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nenhuma banda registrada para avaliacao \nretornando ao menu...");
                    Thread.Sleep(2500);
                    ExibirOpcoesDoMenu();
                }
            }

            //Uma funcao para gerar um layout de "-----" nas palavras titulos das opcoes.
            void GerarLayoutTitulo(string titulo)
            {
                //eu poderia usar o for, mas usei um constructor da classe string que facilita e deixa o codigo mais limpo
                string linha = new string('-', titulo.Length);
                Console.WriteLine("{0}\n{1}\n{0}\n", linha, titulo);

            }
        }


    }
}
