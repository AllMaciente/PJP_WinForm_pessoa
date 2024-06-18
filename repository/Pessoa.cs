using Model;
using MySqlConnector

namespace Repo
{
    public class RepoPessoa
    {
        public static List<Pessoa> pessoas = new List<Pessoa>();
        static private MySqlConnaction conexao;
        public static void InitConexao()
        {
            string info = "server=localhost;database=projetointegrador;user id=root;password=''"
            conexao = new MySqlConnection(info);
            try
            {
                InitConexao.Open();
            }
            catch
            {
                MessageBox.show("Impossível estabelecer conexão")
            }
        }
        public static void CloseConexao()
        {
            conexao.Close()
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
                int id = Convert.ToInt32(row["idade"].ToString());
            }

        }
    }
}