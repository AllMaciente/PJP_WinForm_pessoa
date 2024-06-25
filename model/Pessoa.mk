using System.Collections.Generic;
using Repo;

namespace Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public static void CriarPessoa(string nome, int idade, string cpf)
        {
            Pessoa pessoa = new Pessoa
            {
                Nome = nome,
                Idade = idade,
                Cpf = cpf
            };
            RepoPessoa.Add(pessoa);
        }

        public static void AlterarPessoa(int indice, string nome, int idade, string cpf)
        {
            RepoPessoa.AlterarPessoa(indice, nome, idade, cpf);
        }

        public static void DeletarPessoa(int indice)
        {
            RepoPessoa.Delete(indice);
        }

        public static List<Pessoa> ListarPessoa()
        {
            return RepoPessoa.Sincronizar();
        }
    }
}
