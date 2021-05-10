using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaVendas.Classes;
using SistemaVendas.Classes.Dados;

namespace SistemaVendas.Forms
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(255,255,255);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        userBLL user = new userBLL();
        userDados dados = new userDados();

        private void btnCadastrar_Click(object sender, EventArgs e)
        {         
            user.primeiro_nome = txtPrimeiroNome.Text;
            user.sobrenome = txtSobrenome.Text;
            user.email = txtEmail.Text;
            user.user = txtUser.Text;
            user.senha = txtSenha.Text;
            user.contato = txtContato.Text;
            user.endereco = txtEndereco.Text;
            user.genero = cmbGenero.Text;
            user.tipo_usuario = cmbTipoUsuario.Text;
            user.cadastro_data = DateTime.Now;
            user.cadastrado_por = 1;          

            bool success = dados.Insert(user);

            if (success == true)
            {
                MessageBox.Show("Usuário cadastrado com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar");
            }

            DataTable dt = dados.Select();
            dgvUser.DataSource = dt;
            Limpar();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            txtIdUsuario.BackColor = Color.Gray;

            DataTable dt = dados.Select();
            dgvUser.DataSource = dt;
            dgvUser.Columns[0].HeaderText = "ID Usuário";
            dgvUser.Columns[1].HeaderText = "Nome";
            dgvUser.Columns[2].HeaderText = "Sobrenome";
            dgvUser.Columns[3].HeaderText = "Email";
            dgvUser.Columns[4].HeaderText = "Username";
            dgvUser.Columns[5].HeaderText = "Senha";
            dgvUser.Columns[6].HeaderText = "Contato";
            dgvUser.Columns[7].HeaderText = "Endereço";
            dgvUser.Columns[8].HeaderText = "Gênero";
            dgvUser.Columns[9].HeaderText = "Tipo Cadastro";
            dgvUser.Columns[10].HeaderText = "Data";
            dgvUser.Columns[11].HeaderText = "Cadastrado por";       
        }

        private void Limpar()
        {
            txtIdUsuario.Text = "";
            txtPrimeiroNome.Text = "";
            txtSobrenome.Text = "";
            txtEmail.Text = "";
            txtUser.Text = "";
            txtSenha.Text = "";
            txtContato.Text = "";
            txtEndereco.Text = "";
            cmbGenero.Text = "";
            cmbTipoUsuario.Text = ""; 
        }

        private void dgvUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtIdUsuario.Text = dgvUser.Rows[rowIndex].Cells[0].Value.ToString();
            txtPrimeiroNome.Text = dgvUser.Rows[rowIndex].Cells[1].Value.ToString();
            txtSobrenome.Text = dgvUser.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUser.Rows[rowIndex].Cells[3].Value.ToString();
            txtUser.Text = dgvUser.Rows[rowIndex].Cells[4].Value.ToString();
            txtSenha.Text = dgvUser.Rows[rowIndex].Cells[5].Value.ToString();
            txtContato.Text = dgvUser.Rows[rowIndex].Cells[6].Value.ToString();
            txtEndereco.Text = dgvUser.Rows[rowIndex].Cells[7].Value.ToString();
            cmbGenero.Text = dgvUser.Rows[rowIndex].Cells[8].Value.ToString();
            cmbTipoUsuario.Text = dgvUser.Rows[rowIndex].Cells[9].Value.ToString();      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user.id_user = Convert.ToInt32(txtIdUsuario.Text);
            user.primeiro_nome = txtPrimeiroNome.Text;
            user.sobrenome = txtSobrenome.Text;
            user.email = txtEmail.Text;
            user.user = txtUser.Text;
            user.senha = txtSenha.Text;
            user.contato = txtContato.Text;
            user.endereco = txtEndereco.Text;
            user.genero = cmbGenero.Text;
            user.tipo_usuario = cmbTipoUsuario.Text;
            user.cadastro_data = DateTime.Now;
            user.cadastrado_por = 1;

            bool success = dados.Update(user);

            if(success == true)
            {
                MessageBox.Show("Atualizado com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao atualizar");
            }

            DataTable dt = dados.Select();
            dgvUser.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnCadastrar.Enabled = false;

            user.id_user = Convert.ToInt32(txtIdUsuario.Text);
            

            bool success = dados.Delete(user);
            if (success == true)
            {
                MessageBox.Show("Usuário deletado");
            }
            else
            {
                MessageBox.Show("Erro ao deletar");
            }

            DataTable dt = dados.Select();
            dgvUser.DataSource = dt;
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string key = txtPesquisar.Text;
            if(key != null)
            {
                DataTable dt = dados.Search(key);
                dgvUser.DataSource = dt;
            }
            else
            {
                DataTable dt = dados.Search();
                dgvUser.DataSource = dt;
            }
        }
    }
}
