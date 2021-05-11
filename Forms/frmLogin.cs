using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaVendas.Classes;
using SistemaVendas.Dados;

namespace SistemaVendas.Forms
{
    public partial class frmLogin : Form
    {
        Thread newThread;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void novaJanelaAdmin(object obj)
        {
            Application.Run(new frmAdminDashboard());
        }

        private void novaJanelaUser(object obj)
        {
            Application.Run(new frmUserDashboard());
        }

        private void btnEntrarLogin_Click(object sender, EventArgs e)
        {
            loginBLL l = new loginBLL();
            loginDados d = new loginDados();

            l.usuario = txtUsuarioLogin.Text.Trim();
            l.senha = txtSenhaLogin.Text.Trim();
            l.tipo_usuario = cmbTipoUsuarioLogin.Text;

            bool logado = d.loginCheck(l);
            if (logado)
            {
                MessageBox.Show("Logado com sucesso!");
                switch (l.tipo_usuario)
                {
                    case "Administrador":
                        {
                            this.Close();
                            newThread = new Thread(novaJanelaAdmin);
                            newThread.SetApartmentState(ApartmentState.STA);
                            newThread.Start();
                            /**frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            this.Hide();   
                            */
                            break;
                        }
                       
                    case "Usuário":
                        {
                            this.Close();
                            newThread = new Thread(novaJanelaUser);
                            newThread.SetApartmentState(ApartmentState.STA);
                            newThread.Start();
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Inválido");
                            break;
                        }                                         
                }
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
