using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using prjBLL;
using prjDTO;
using prjControlCar;


namespace prjControlCar
{
    public partial class FormAdicionarVaga : Form
    {
        Bll bll = new Bll();
        public FormAdicionarVaga()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ConferirCamposVazios())
            {
                var vaga = new DtoVaga(int.Parse(txtNumeroVaga.Text.ToString()),
                           Convert.ToChar("N"),
                           txtAndarVaga.Text.ToString(),
                           txtBlocoVaga.Text.ToString(),
                           int.Parse("1"),
                           int.Parse("1"),
                           int.Parse("1"));

                bll.InsertVaga(vaga);
                limparCampos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtNumeroVaga.Text = String.Empty;
            txtAndarVaga.Text = String.Empty;
            txtBlocoVaga.Text = String.Empty;
        }

        private bool ConferirCamposVazios()
        {
            if (txtAndarVaga.Text.Trim().ToString() == "" || txtBlocoVaga.Text.Trim().ToString() == "" || txtNumeroVaga.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Campo(s) vazio(s)");
                return false;
            }
            return true;
        }
    }
}
