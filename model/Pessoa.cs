using Repo;

namespace Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }

        public Pessoa(string nome, int idade, string cpf)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = cpf;


            RepoPessoa.pessoas.Add(this);
        }

        public static List<Pessoa> ListarPessoa()
        {
            return RepoPessoa.pessoas;
        }

        public static void AlterarPessoa(int indice, string nome, int idade)
        {
            Pessoa pessoa = RepoPessoa.pessoas[indice];

            pessoa.Nome = nome;
            pessoa.Idade = idade;

            RepoPessoa.pessoas[indice] = pessoa;
        }

        public static void DeletarPessoa(int indice)
        {
            RepoPessoa.pessoas.RemoveAt(indice);
        }

        public void Falar()
        {
            Console.WriteLine($"Olá, meu nome é {Nome}");
        }
    }
}