using System.ComponentModel;
using Model;
namespace Controller
{
    public class ControllerPessoa
    {
        public static void CriarPessoa(string nome, int idade)
        {
            new Pessoa(nome, idade);
        }

        public static List<Pessoa> ListarPessoa()
        {
            return Pessoa.ListarPessoa();
        }

        public static void DeletarPessoa(int indice)
        {
            List<Pessoa> pessoas = ListarPessoa();
            if (indice >= 0 && indice < pessoas.Count)
            {
                Pessoa.DeletarPessoa(indice);
                Console.WriteLine("Pessoa deletada com sucesso;");
            }
            else
            {
                Console.WriteLine("Indice inválido");

            }
        }
        public static void EditarPessoa(int indice, string nome, int idade)
        {
            List<Pessoa> pessoas = ListarPessoa();
            if (indice >= 0 && indice < pessoas.Count)
            {
                Pessoa.EditarPessoa(indice, nome, idade);
                Console.WriteLine("Pessoa deletada com sucesso;");
            }
            else
            {
                Console.WriteLine("Indice inválido");

            }

        }
    }
}