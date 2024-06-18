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

    }
}