using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDBARTO
{
    class Cadastro
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string data_nas { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string cidade { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\source\repos\CRUDBARTO\CRUDBARTO\Cad.mdf;Integrated Security=True");

        public List<Cadastro> listacadastro()
        {
            List<Cadastro> li = new List<Cadastro>();
            string sql = "SELECT * FROM Cad";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cadastro j = new Cadastro();
                j.Id = (int)dr["Id"];
                j.nome = dr["nome"].ToString();
                j.data_nas = dr["data_nas"].ToString();
                j.email = dr["email"].ToString();
                j.celular = dr["celular"].ToString();
                j.cidade = dr["cidade"].ToString();
                li.Add(j);
            }
            return li;
        }

        public void Inserir(string nome, DateTime data_nas, string email, string celular, string cidade)
        {
            
            string date_str = data_nas.ToString("dd/MM/yyyy");
            Console.WriteLine(date_str);

            string sql = "INSERT INTO Cad (nome, data_nas, email, celular, cidade) VALUES ('" + nome + "','" + date_str + "','" + email + "','" + celular + "','" + cidade + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localiza(int Id)
        {
            string sql = "SELECT * FROM Cad WHERE Id = '" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                data_nas = dr["data_nas"].ToString();
                email = dr["email"].ToString();
                celular = dr["celular"].ToString();
                cidade = dr["cidade"].ToString();

            }
        }

        public void Atualizar(int Id, string nome, DateTime data_nas, string email, string celular, string cidade)
        {
            string sql = "UPDATE Jogador SET nome='" + nome + "', data_nas='" + data_nas + "', email='" + email + "', celular='" + celular + "'cidade='" + cidade + "' WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Cad WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

