using Repo;

namespace Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Cpf { get; set; } = string.Empty;

        public Pessoa() { }

        public Pessoa(string nome, int idade, string cpf)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = cpf;

            RepoPessoa.Add(this);
        }

        public static void Sincronizar()
        {
            RepoPessoa.Sincronizar();
        }

        public static List<Pessoa> ListarPessoa()
        {
            return RepoPessoa.pessoas;
        }

        public static void AlterarPessoa(int indice, string nome, int idade, string cpf)
        {
            RepoPessoa.AlterarPessoa(indice, nome, idade, cpf);
        }

        public static void DeletarPessoa(int indice)
        {
            RepoPessoa.Delete(indice);
        }

        public void Falar()
        {
            Console.WriteLine($"Olá, meu nome é {Nome}");
        }
    }
}
