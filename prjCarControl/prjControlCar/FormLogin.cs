using prjBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjControlCar
{
    public partial class FormLogin : Form
    {
        Bll bll = null;
        public FormLogin()
        {
            InitializeComponent();
            bll = new Bll();
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (Logar(txtLogin.Text, txtSenha.Text))
            {
                new Principal().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario ou senha incorretos");
            }
        }
        public bool Logar(string usuario, string senha)
        {
            return bll.Login(usuario, senha);
        }
    }
}
