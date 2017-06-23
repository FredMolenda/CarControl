using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjBLL;
using System.Configuration;
using prjDTO;

namespace prjControlCar
{
    public partial class FormOcupar : Form
    {
        Bll bll = new Bll();
        int Linha;
        int NVaga;
        string Andar;
        string Bloco;

        public FormOcupar(int IdLinha, int Numvaga, string IdAndar, string IdBloco)
        {
            InitializeComponent();
            CarregarComboBoxCliente();
            Linha = IdLinha;
            Andar = IdAndar;
            Bloco = IdBloco;
            NVaga = Numvaga;
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ConferirCamposVazios())
            {
                bll.OcuparVaga(new DtoVaga(Linha,
                    NVaga,
                    Convert.ToChar("S"),
                    Andar,
                    Bloco,
                    int.Parse(cbVeiculo.SelectedValue.ToString()),
                    int.Parse(cbCliente.SelectedValue.ToString()),
                    int.Parse(cbTipoVaga.SelectedValue.ToString())));
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarComboBoxCliente()
        {
            cbCliente.DisplayMember = "NomeCliente";
            cbCliente.ValueMember = "IdCliente";
            cbCliente.DataSource = bll.SelectCliente();
        }
        private void CarregarComboBoxVeiculo()
        {
            cbVeiculo.DisplayMember = "PlacaVeiculo";
            cbVeiculo.ValueMember = "IdVeiculos";
            cbVeiculo.DataSource = bll.SelectVeiculoById(int.Parse(cbCliente.SelectedValue.ToString()));
        }
        private void CarregarComboBoxTipoVaga()
        {
            cbTipoVaga.DisplayMember = "NomeTipoVaga";
            cbTipoVaga.ValueMember = "IdTipoVaga";
            cbTipoVaga.DataSource = bll.SelectTipoVaga2();
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarComboBoxVeiculo();
            CarregarComboBoxTipoVaga();
        }

        private bool ConferirCamposVazios()
        {
            if (cbCliente.Text.Trim().ToString() == "" || cbTipoVaga.Text.Trim().ToString() == "" || cbVeiculo.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Campo(s) vazio(s)");
                return false;
            }
            return true;
        }
    }
}
