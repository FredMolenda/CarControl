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
    public partial class FormUsuario : Form
    {
        Bll bll = new Bll();
        private string status = String.Empty;

        public FormUsuario()
        {
            InitializeComponent();
            dtgvUsuario.DataSource = bll.SelectUsuario();
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
                        bll.EditUsuario(new DtoUsuario(
                        dtgvUsuario[0, pegarLinha()].Value.ToString(),
                        txtSenha.Text.ToString()));
                    }
                }
                else if (status.Equals("novo"))
                {
                    if (ConferirCamposVazios())
                    {
                        var usuario = new DtoUsuario(
                        txtLogin.Text.ToString(),
                        txtSenha.Text.ToString());

                        bll.InsertUsuario(usuario);
                    }
                }

                BindData(this.GetData());

                btnNovo.Text = "Novo";
                bloquearCampos();
                limparCampos();
                status = String.Empty;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnNovo.Text.Equals("Novo"))
            {
                btnNovo.Text = "Salvar";
                status = "editar";
                bloquearBtnExcluirEditar();
                desbloquearBtnNovo();
                desbloquearCampos();
                txtLogin.Enabled = false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.bll.DeleteUsuario(dtgvUsuario[0, pegarLinha()].Value.ToString());

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

        private void dtgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!status.Equals("novo") && !status.Equals("editar"))
            {
                carregarCampos();
                desbloquearBtnExcluirEditar();
                bloquearBtnNovo();
            }
        }
        #endregion eventos

        #region Métodos
        private List<DtoUsuario> GetData()
        {
            try
            {
                return this.bll.SelectUsuario();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void BindData(List<DtoUsuario> p_List)
        {
            try
            {
                dtgvUsuario.DataSource = p_List;

                dtgvUsuario.Refresh();
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
                return dtgvUsuario.CurrentRow.Index;
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

                txtLogin.Text = dtgvUsuario[0, linhaAtual].Value.ToString();
                txtSenha.Text = dtgvUsuario[1, linhaAtual].Value.ToString();
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
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
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
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
        }

        private void limparCampos()
        {
            txtLogin.Text = String.Empty;
            txtSenha.Text = String.Empty;
        }

        private bool ConferirCamposVazios()
        {
            if (txtLogin.Text.Trim().ToString() == "" || txtSenha.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Campo(s) vazio(s)");
                return false;
            }
            return true;
        }

        #endregion Métodos


    }
}
