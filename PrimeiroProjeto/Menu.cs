using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimeiroProjeto
{
    internal class Menu
    {
        public static void ExibirMenu(RepositorioBanda repositorio, Avaliador avaliador)
        {

            while (true)
            {
                int opcao; ;
                Utils.ExibirLogo();
                Console.WriteLine("\n1 - para registrar uma banda");
                Console.WriteLine("2 - para mostrar todas as bandas");
                Console.WriteLine("3 - para avaliar uma banda");
                Console.WriteLine("4 - para exibir a média de uma banda");
                Console.WriteLine("0 - para sair");
                string a = Console.ReadLine();


                if (!int.TryParse(a, out opcao) || opcao < 0 || opcao > 4)
                {
                    Console.WriteLine("\nOpcao invalida...");
                    Console.WriteLine("Digite uma das opcoes acima!");
                    Thread.Sleep(2000);
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        repositorio.RegistrarBanda();
                        break;
                    case 2:
                        repositorio.MostrarBandas();
                        break;
                    case 3:
                        avaliador.AvaliarBanda();
                        break;
                    case 4:
                        avaliador.ExibirMediaBanda();
                        break;
                    case 0:

                        return;

                }

            }
        }
    }
}
