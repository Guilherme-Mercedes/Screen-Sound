using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//O nome pode confundir, mas nao é aqui onde fica o repositorio de musicas dos artistas kkkk

namespace PrimeiroProjeto
{
    internal class RepositorioBanda
    {
        List<Banda> listaDeBandas = new List<Banda>();

        public void RegistrarBanda()
        {
            string nomeBanda;

            while (true)
            {
                Console.Clear();
                Utils.GerarLayoutTitulo("Registros de bandas");
                Console.Write("Digite o nome da banda: ");
                nomeBanda = Console.ReadLine();
                //filtro para nao deixar a banda ser null e o registro duplicado
                if (string.IsNullOrWhiteSpace(nomeBanda))
                {
                    Console.WriteLine("\nO nome da banda nao pode estar em branco...");
                    Thread.Sleep(2000);
                    continue;
                }
                if (listaDeBandas.Any(b => b.Nome.Equals(nomeBanda, StringComparison.OrdinalIgnoreCase))) //Compara se ja existe a banda independente se for letra maiuscula ou minuscula
                {
                    Console.WriteLine("\nA banda {0} ja foi registrada, tente novamente", nomeBanda);
                    Thread.Sleep(2000);
                    continue;
                }

                listaDeBandas.Add(new Banda (nomeBanda));
                Console.Clear();
                Console.WriteLine("A banda {0} foi adicionada com sucesso", nomeBanda);
                Console.WriteLine("retornando ao menu...");
                Thread.Sleep(2000);
                Console.Clear();
                break;
            }

        }

        public void MostrarBandas()
        {
            Console.Clear();

            if (listaDeBandas.Count == 0)
            {
                Utils.GerarLayoutTitulo("Nenhuma banda registrada! \nretornando ao menu...");
                Thread.Sleep(2500);
                Console.Clear();
            }
            else
            {
                Utils.GerarLayoutTitulo("Bandas registradas:\n");

                foreach (Banda banda in listaDeBandas)
                {
                    Console.WriteLine("Banda: {0}", banda);
                }
                Console.WriteLine("\n Digite qualquer tecla para sair!");
                Console.ReadKey();
                Console.Clear();

            }

        }
    }
}
