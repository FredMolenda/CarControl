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
    public partial class FormTipoVaga : Form
    {
        Bll bll = new Bll();
        private string status = String.Empty;

        public FormTipoVaga()
        {
            InitializeComponent();
            dtgvTipoVaga.DataSource = bll.SelectTipoVaga();
            if (this.dtgvTipoVaga.Columns.Count != 0)
            {
                this.dtgvTipoVaga.Columns[0].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
            }
            bloquearBtnExcluirEditar();
            bloquearCampos();
        }

        #region eventos
        private void btnNovo_Click(object sender, EventArgs e)
        {
            bloquearBtnExcluirEditar();

            if (btnNovo.Text.Equals("Novo"))
            {
                btnNovo.Text = "Salvar";
                status = "novo";
                desbloquearCampos();
            }
            else
            {
                if (status.Equals("editar"))
                {
                    if (ConferirCamposVazios())
                    {
                        bll.EditTipoVaga(new DtoTipoVaga(int.Parse(dtgvTipoVaga[0, pegarLinha()].Value.ToString()), txtNome.Text.ToString(), Decimal.Parse(txtHorista.Text.ToString()), Decimal.Parse(txtMensalista.Text.ToString())));
                    }
                }
                else if (status.Equals("novo"))
                {
                    if (ConferirCamposVazios())
                    {
                        var tipovaga = new DtoTipoVaga(1,
                            txtNome.Text.ToString(),
                            Decimal.Parse(txtMensalista.Text.ToString()),
                            Decimal.Parse(txtHorista.Text.ToString()));

                        bll.InsertTipoVaga(tipovaga);
                    }
                }

                BindData(this.GetData());

                btnNovo.Text = "Novo";
                bloquearCampos();
                limparCampos();
                status = String.Empty;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnNovo.Text.Equals("Novo"))
            {
                btnNovo.Text = "Salvar";
                status = "editar";
                bloquearBtnExcluirEditar();
                desbloquearBtnNovo();
                desbloquearCampos();
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
                this.bll.DeleteTipoVaga(int.Parse(dtgvTipoVaga[0, pegarLinha()].Value.ToString()));

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

        private void dtgvTipoVaga_CellClick(object sender, DataGridViewCellEventArgs e)
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
        private List<DtoTipoVaga> GetData()
        {
            try
            {
                return this.bll.SelectTipoVaga();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void BindData(List<DtoTipoVaga> p_List)
        {
            try
            {
                dtgvTipoVaga.DataSource = p_List;

                dtgvTipoVaga.Refresh();
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
                return dtgvTipoVaga.CurrentRow.Index;
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

                txtNome.Text = dtgvTipoVaga[1, linhaAtual].Value.ToString();
                txtHorista.Text = dtgvTipoVaga[2, linhaAtual].Value.ToString();
                txtMensalista.Text = dtgvTipoVaga[3, linhaAtual].Value.ToString();
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
            txtNome.Enabled = false;
            txtHorista.Enabled = false;
            txtMensalista.Enabled = false;
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
            txtNome.Enabled = true;
            txtHorista.Enabled = true;
            txtMensalista.Enabled = true;
        }

        private void limparCampos()
        {
            txtNome.Text = String.Empty;
            txtHorista.Text = String.Empty;
            txtMensalista.Text = String.Empty;
        }

        private bool ConferirCamposVazios()
        {
            if (txtNome.Text.Trim().ToString() == "" || txtHorista.Text.Trim().ToString() == "" || txtMensalista.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Campo(s) vazio(s)");
                return false;
            }
            return true;
        }
        #endregion Metodos


    }
}
