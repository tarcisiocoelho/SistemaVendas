using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaVendas.Classes;
using System.Data;

namespace SistemaVendas.Dados
{
    class loginDados
    {
        #region fazendo conexão com o banco de dados
        public SqlConnection getConnection()
        {
            string connString = @"Data Source=DESKTOP-BIAULCP\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.Close();
            }

            return conn;
        }
        #endregion

        public bool loginCheck(loginBLL l)
        {
            bool isSuccess = false;
            SqlConnection conn = getConnection();
            try
            {
                string sql = "SELECT * FROM tabela_user WHERE username = @username AND pass LIKE @pass AND user_type = @tipousuario";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", l.usuario);
                cmd.Parameters.AddWithValue("@pass", l.senha);
                cmd.Parameters.AddWithValue("@tipousuario", l.tipo_usuario);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Open();

                if (dt.Rows.Count > 0)
                {
                    isSuccess = true;                 
                }
                else
                {
                    isSuccess = false;
                }

                
                //isSuccess = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }
    }
}
