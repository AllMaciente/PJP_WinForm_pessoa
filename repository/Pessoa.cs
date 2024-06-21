using System.Data;
using Model;
using MySqlConnector;

namespace Repo
{
    public class RepoPessoa
    {
        public static List<Pessoa> pessoas = new List<Pessoa>();
        static private MySqlConnection conexao;
        public static void InitConexao()
        {
            string info = "server=localhost;database=projetointegrador;user id=root;password=''";
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
         public static List<Pessoa> Sincronizar(){
            InitConexao();
            string query = "SELECT * FROM pessoas";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // Aqui você pode acessar os dados retornados pela consulta SELECT
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
    }
}