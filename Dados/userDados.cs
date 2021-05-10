using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using SistemaVendas.Forms;

namespace SistemaVendas.Classes.Dados
{
    class userDados
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region selecionar dados do database
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tabela_user";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region inserindo dados na tabela
        public bool Insert(userBLL u)
        {
            bool inserido = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "INSERT INTO tabela_user (first_name, last_name, email, username, pass, contact, endereco, gender, user_type, cadastro_data, cad_by) VALUES (@nome, @sobrenome, @email, @usuario, @senha, @contato, @endereco, @genero, @tipoUsuario, @cadData, @cadPor)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("nome", u.primeiro_nome);
                cmd.Parameters.AddWithValue("sobrenome", u.sobrenome);
                cmd.Parameters.AddWithValue("email", u.email);
                cmd.Parameters.AddWithValue("usuario", u.user);
                cmd.Parameters.AddWithValue("senha", u.senha);
                cmd.Parameters.AddWithValue("contato", u.contato);
                cmd.Parameters.AddWithValue("endereco", u.endereco);
                cmd.Parameters.AddWithValue("genero", u.genero);
                cmd.Parameters.AddWithValue("tipoUsuario", u.tipo_usuario);
                cmd.Parameters.AddWithValue("cadData", u.cadastro_data);
                cmd.Parameters.AddWithValue("cadPor", u.cadastrado_por);
                //cmd.CommandType = CommandType.Text;

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    inserido = true;
                }
                else
                {
                    inserido = false;                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return inserido;
        }
        #endregion

        #region atualizar os dados do banco
        public bool Update(userBLL u)
        {
            bool atualizado = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {

                string sql = "UPDATE tabela_user SET first_name = @nome, last_name = @sobrenome, email = @email, username = @usuario, pass = @senha, contact = @contato, endereco = @endereco, gender = @genero, user_type = @tipoUsuario, cadastro_data = @cadData, cad_by = @cadPor WHERE id_user = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("nome", u.primeiro_nome);
                cmd.Parameters.AddWithValue("sobrenome", u.sobrenome);
                cmd.Parameters.AddWithValue("email", u.email);
                cmd.Parameters.AddWithValue("usuario", u.user);
                cmd.Parameters.AddWithValue("senha", u.senha);
                cmd.Parameters.AddWithValue("contato", u.contato);
                cmd.Parameters.AddWithValue("endereco", u.endereco);
                cmd.Parameters.AddWithValue("genero", u.genero);
                cmd.Parameters.AddWithValue("tipoUsuario", u.tipo_usuario);
                cmd.Parameters.AddWithValue("cadData", u.cadastro_data);
                cmd.Parameters.AddWithValue("cadPor", u.cadastrado_por);
                cmd.Parameters.AddWithValue("id", u.id_user);
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    atualizado = true;
                    MessageBox.Show("Atualizado com sucesso");
                }
                else
                {
                    atualizado = false;
                    MessageBox.Show("Erro ao atualizar");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return atualizado;
        }
        #endregion

        #region deletando do banco
        public bool Delete(userBLL u)
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            bool deletado = false;

            try
            {  
                string sql = "DELETE FROM tabela_user WHERE id_user = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", u.id_user);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if(rows > 0)
                {
                    deletado = true;
                }
                else
                {
                    deletado = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return deletado;
        }

        internal DataTable Search()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region buscando dados 
        public DataTable Search(string key)
        {        
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tabela_user WHERE id_user LIKE'%" + key + "%' or first_name LIKE'%" + key + "%' or username LIKE'%" + key + "%'";               

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt); 
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion
    }
}

