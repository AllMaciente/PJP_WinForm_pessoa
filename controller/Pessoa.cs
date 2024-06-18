using Model;


namespace Controller
{
    public class ControllerPessoa
    {

        public static List<Pessoa> Sincronizar()
        {
            return Model.Sincronizar();
        }
        public static void CriarPessoa(string nome, int idade, string cpf)
        {
            new Pessoa(nome, idade, cpf);
        }

        public static List<Pessoa> ListarPessoa()
        {
            return Pessoa.ListarPessoa();
        }

        public static void AlterarPessoa(int indice, string nome, int idade)
        {
            List<Pessoa> pessoas = ListarPessoa();
            if (indice >= 0 && indice < pessoas.Count)
            {
                Pessoa.AlterarPessoa(indice, nome, idade);
                Console.WriteLine("Pessoa Alterada com sucesso;");
            }
            else
            {
                Console.WriteLine("Indice inválido");
            }
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

    }
}