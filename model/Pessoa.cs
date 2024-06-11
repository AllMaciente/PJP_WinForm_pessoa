using Repo;
namespace Model
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;

            RepoPessoa.pessoas.Add(this);
        }
        public static List<Pessoa> ListarPessoa()
        {
            return RepoPessoa.pessoas;
        }
        public static void DeletarPessoa(int indice)
        {
            RepoPessoa.pessoas.RemoveAt(indice);
        }

        public static void EditarPessoa(int indice, string nome, int idade)
        {
            RepoPessoa.pessoas[indice].Nome = nome;
            RepoPessoa.pessoas[indice].Idade = idade;
        }


        public void Falar()
        {
            Console.WriteLine($"Olá, meu nome é {Nome}");
        }
    }
}