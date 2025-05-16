using System.Data;
using System.Diagnostics.CodeAnalysis;
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
            RepositorioBanda repositorio = new RepositorioBanda();
            Avaliador avaliador = new Avaliador(repositorio);

            Menu.ExibirMenu(repositorio, avaliador);

        }

    }
}
