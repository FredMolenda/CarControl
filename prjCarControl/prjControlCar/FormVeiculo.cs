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

namespace prjControlCar
{
    public partial class FormVeiculo : Form
    {
        Bll bll = new Bll();
        private string status = String.Empty;

        public FormVeiculo()
        {
            InitializeComponent();
            dtgvVeiculo.DataSource = bll.SelectVeiculo();
            if (this.dtgvVeiculo.Columns.Count != 0)
            {
                this.dtgvVeiculo.Columns[0].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
                this.dtgvVeiculo.Columns[4].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
            }
            bloquearBtnExcluirEditar();
            bloquearCampos();
        }

        #region eventos
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnNovo.Text.Equals("Novo"))
            {
                btnNovo.Text = "Salvar";
                status = "editar";
                bloquearBtnExcluirEditar();
                desbloquearBtnNovo();
                desbloquearCampos();
                CarregarComboBox();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnNovo.Text.Equals("Salvar") || btnNovo.Enabled.Equals(false))
            {
                btnNovo.Text = "Novo";
                limparCampos();
                bloquearBtnExcluirEditar();
                desbloquearBtnNovo();
                bloquearCampos();
            }
            else
            {
                this.Dispose();
            }
            status = String.Empty;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.bll.DeleteVeiculo(int.Parse(dtgvVeiculo[0, pegarLinha()].Value.ToString()));

                BindData(this.GetData());

                limparCampos();
                bloquearBtnExcluirEditar();
                desbloquearBtnNovo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            bloquearBtnExcluirEditar();

            if (btnNovo.Text.Equals("Novo"))
            {
                btnNovo.Text = "Salvar";
                status = "novo";
                desbloquearCampos();
                CarregarComboBox();
            }
            else
            {
                if (status.Equals("editar"))
                {
                    if (ConferirCamposVazios())
                    {
                        bll.EditVeiculo(new DtoVeiculo(int.Parse(dtgvVeiculo[0, pegarLinha()].Value.ToString()), txtMarca.Text.ToString(), txtModelo.Text.ToString(), txtPlaca.Text.ToString(), int.Parse(cbCliente.SelectedValue.ToString())));
                    }
                }
                else if (status.Equals("novo"))
                {
                    if (ConferirCamposVazios())
                    {
                        var veiculo = new DtoVeiculo(1,
                        txtMarca.Text.ToString(),
                        txtModelo.Text.ToString(),
                        txtPlaca.Text.ToString(),
                        int.Parse(cbCliente.SelectedValue.ToString()));

                        bll.InsertVeiculo(veiculo);
                    }
                }

                BindData(this.GetData());

                btnNovo.Text = "Novo";
                bloquearCampos();
                limparCampos();
                status = String.Empty;
            }
        }

        private void dtgvVeiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!status.Equals("novo") && !status.Equals("editar"))
            {
                carregarCampos();
                desbloquearBtnExcluirEditar();
                bloquearBtnNovo();
            }
        }
        
        #endregion eventos

        #region Metodos
        private List<DtoVeiculo> GetData()
        {
            try
            {
                return this.bll.SelectVeiculo();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void BindData(List<DtoVeiculo> p_List)
        {
            try
            {
                dtgvVeiculo.DataSource = p_List;

                dtgvVeiculo.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int pegarLinha()
        {
            try
            {
                return dtgvVeiculo.CurrentRow.Index;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void carregarCampos()
        {
            try
            {
                int linhaAtual = pegarLinha();

                txtMarca.Text = dtgvVeiculo[1, linhaAtual].Value.ToString();
                txtModelo.Text = dtgvVeiculo[2, linhaAtual].Value.ToString();
                txtPlaca.Text = dtgvVeiculo[3, linhaAtual].Value.ToString();
                cbCliente.Text = dtgvVeiculo[4, linhaAtual].Value.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void bloquearBtnExcluirEditar()
        {
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void bloquearBtnNovo()
        {
            btnNovo.Enabled = false;
        }

        private void bloquearCampos()
        {
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtPlaca.Enabled = false;
            cbCliente.Enabled = false;
        }

        private void desbloquearBtnExcluirEditar()
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void desbloquearBtnNovo()
        {
            btnNovo.Enabled = true;
        }

        private void desbloquearCampos()
        {
            txtMarca.Enabled = true;
            txtModelo.Enabled = true;
            txtPlaca.Enabled = true;
            cbCliente.Enabled = true;
        }

        private void limparCampos()
        {
            txtMarca.Text = String.Empty;
            txtModelo.Text = String.Empty;
            txtPlaca.Text = String.Empty;
            cbCliente.Text = String.Empty;
        }

        private void CarregarComboBox()
        {
            cbCliente.DisplayMember = "NomeCliente";
            cbCliente.ValueMember = "IdCliente";
            cbCliente.DataSource = bll.SelectCliente();
        }

        private bool ConferirCamposVazios()
        {
            if (txtMarca.Text.Trim().ToString() == "" || txtModelo.Text.Trim().ToString() == "" || txtPlaca.Text.Trim().ToString() == "" || cbCliente.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Campo(s) vazio(s)");
                return false;
            }
            return true;
        }
        #endregion Metodos
    }
}
