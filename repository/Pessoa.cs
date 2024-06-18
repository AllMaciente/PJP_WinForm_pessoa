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
        public static List<Pessoa> Sincronizar()
        {
            InitConexao();
            string query = "SELECT * FROM pessoas";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataAdapter bdAdapter = new MySqlDataAdapter(command);

            DataSet dbDataSet = new DataSet();
            bdAdapter.Fill(dbDataSet, "pessoas");
            DataTable table = dbDataSet.Tables["pessoas"];

            foreach (DataRow row in table.Rows)
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = Convert.ToInt32(row["id"].ToString());
                pessoa.Nome = row["nome"].ToString();
                pessoa.Idade = Convert.ToInt32(row["idade"].ToString());
                pessoa.Cpf = row["cpf"].ToString();
                pessoas.Add(pessoa);
            }

            CloseConexao();
            return pessoas;

        }
    }
}