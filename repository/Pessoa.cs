using System.Data;
using Model;
using MySqlConnector;
using System.Windows.Forms;

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
        public static List<Pessoa> Sincronizar()
        {
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

        public static void Add(Pessoa pessoa)
        {
            InitConexao();
            string insert = "INSERT INTO pessoas (nome, idade, cpf) VALUES (@nome, @idade, @cpf)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try
            {
                if (pessoa.Nome == null || pessoa.Idade < 0 || pessoa.Cpf == null)
                {
                    MessageBox.Show("Nome não pode ser nulo");
                }
                else
                {
                    command.Parameters.AddWithValue("@nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@idade", pessoa.Idade);
                    command.Parameters.AddWithValue("@cpf", pessoa.Cpf);

                    int rowsAffected = command.ExecuteNonQuery();

                    pessoa.Id = Convert.ToInt32(command.LastInsertedId);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pessoa adicionada com sucesso");
                        pessoas.Add(pessoa);
                    }
                    else
                    {
                        MessageBox.Show("Impossível adicionar pessoa");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Impossível estabelecer conexão com o banco: " + e.Message);
            }
            CloseConexao();
        }

        public static void Delete(int index)
        {
            InitConexao();
            string delete = "DELETE FROM pessoas where id = @id";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@id", pessoas[index].Id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                pessoas.RemoveAt(index);
                MessageBox.Show("Pessoa deletada com sucesso");
            }

            CloseConexao();
        }
    }
}
