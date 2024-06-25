using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Windows.Forms;
using Model;

namespace Repo
{
    public class RepoPessoa
    {
        public static List<Pessoa> pessoas = new List<Pessoa>();
        static private MySqlConnection conexao;

        public static void InitConexao()
        {
            //string info = "server=localhost;database=projetointegrador;user id=root;password=''";
            string info ="server=viaduct.proxy.rlwy.net;port=47021;database=railway;uid=root;password=RlmHuRQgcfMZjdGenKYTqseXdHpAjjjZ;";
            conexao = new MySqlConnection(info);
            try
            {
                conexao.Open();
            }
            catch
            {
                MessageBox.Show("Impossível estabelecer conexão");
            }
        }

        public static void CloseConexao()
        {
            conexao.Close();
        }

        public static List<Pessoa> Sincronizar()
        {
            InitConexao();
            string query = "SELECT * FROM pessoas";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"].ToString());
                Pessoa pessoa = new Pessoa();
                pessoa.Id = id;
                pessoa.Idade = Convert.ToInt32(reader["idade"].ToString());
                pessoa.Nome = reader["nome"].ToString();
                pessoa.Cpf = reader["cpf"].ToString();
                pessoas.Add(pessoa);
            }
            CloseConexao();
            return pessoas;
        }

        public static void Add(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }

        public static void AlterarPessoa(int index, string nome, int idade, string cpf)
        {
            Pessoa pessoaAtual = pessoas[index];

            if (string.IsNullOrEmpty(nome))
            {
                nome = pessoaAtual.Nome;
            }
            if (string.IsNullOrEmpty(cpf))
            {
                cpf = pessoaAtual.Cpf;
            }

            pessoaAtual.Nome = nome;
            pessoaAtual.Idade = idade;
            pessoaAtual.Cpf = cpf;
        }

        public static void Delete(int index)
        {
            pessoas.RemoveAt(index);
        }
    }
}
