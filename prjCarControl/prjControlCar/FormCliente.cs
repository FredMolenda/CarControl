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
    public partial class FormCliente : Form
    {
        Bll bll = new Bll();

        private string status = String.Empty;

        public FormCliente()
        {
            InitializeComponent();
            dtgvCliente.DataSource = bll.SelectCliente();
            if (this.dtgvCliente.Columns.Count != 0)
            {
                this.dtgvCliente.Columns[0].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
            }
            bloquearBtnExcluirEditar();
            bloquearCampos();
        }

        #region eventos
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.bll.DeleteCliente(int.Parse(dtgvCliente[0, pegarLinha()].Value.ToString()));

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnNovo.Text.Equals("Novo"))
            {
                btnNovo.Text = "Salvar";
                status = "editar";
                bloquearBtnExcluirEditar();
                desbloquearBtnNovo();
                desbloquearCampos();
                CarregarCb();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            bloquearBtnExcluirEditar();
            string CPF;
            string Telefone;

            if (validarCPF(txtCPF.Text.ToString()))
            {

                CPF = txtCPF.Text.Trim();
                CPF = txtCPF.Text.Replace(",", "").Replace("-", "");

                Telefone = txtTelefone.Text.Trim();
                Telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                if (btnNovo.Text.Equals("Novo"))
                {
                    btnNovo.Text = "Salvar";
                    status = "novo";
                    desbloquearCampos();
                    CarregarCb();
                }
                else
                {
                    if (status.Equals("editar"))
                    {
                        if (ConferirCamposVazios())
                        bll.EditCliente(new DtoCliente(int.Parse(dtgvCliente[0, pegarLinha()].Value.ToString()), txtNome.Text.ToString(), CPF.ToString(), Telefone.ToString(), Convert.ToChar(cbEspecificacao.Text[0])));
                    }
                    else if (status.Equals("novo"))
                    {
                        if (ConferirCamposVazios())
                        {
                            var cliente = new DtoCliente(1,
                            txtNome.Text.ToString(),
                            CPF.ToString(),
                            Telefone.ToString(),
                            Convert.ToChar(cbEspecificacao.Text[0]));

                            bll.InsertCliente(cliente);
                        }
                    }

                    BindData(this.GetData());

                    btnNovo.Text = "Novo";
                    bloquearCampos();
                    limparCampos();
                    status = String.Empty;
                    EsvaziarCb();
                }
            }
            else
            {
                MessageBox.Show("CPF Incorreto");
                status = string.Empty;
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

        private void dtgvCliente_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
        private List<DtoCliente> GetData()
        {
            try
            {
                return this.bll.SelectCliente();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void BindData(List<DtoCliente> p_List)
        {
            try
            {
                dtgvCliente.DataSource = p_List;

                dtgvCliente.Refresh();
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
                return dtgvCliente.CurrentRow.Index;
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

                txtNome.Text = dtgvCliente[1, linhaAtual].Value.ToString();
                txtCPF.Text = dtgvCliente[2, linhaAtual].Value.ToString();
                txtTelefone.Text = dtgvCliente[3, linhaAtual].Value.ToString();
                cbEspecificacao.Text = dtgvCliente[4, linhaAtual].Value.ToString();
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
            txtCPF.Enabled = false;
            txtTelefone.Enabled = false;
            cbEspecificacao.Enabled = false;
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
            txtCPF.Enabled = true;
            txtTelefone.Enabled = true;
            cbEspecificacao.Enabled = true;
        }

        private void limparCampos()
        {
            txtNome.Text = String.Empty;
            txtCPF.Text = String.Empty;
            txtTelefone.Text = String.Empty;
            cbEspecificacao.Text = String.Empty;
        }

        private void CarregarCb()
        {
            cbEspecificacao.Items.Add("Mensalista");
            cbEspecificacao.Items.Add("Horista");
            cbEspecificacao.SelectedIndex = 0;
        }

        private void EsvaziarCb()
        {
            cbEspecificacao.Items.Clear();
        }
        private bool ConferirCamposVazios()
        {
            if (txtNome.Text.Trim().ToString() == "" || txtTelefone.Text.Trim().ToString() == "" || txtCPF.Text.Trim().ToString() == "" || cbEspecificacao.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Campo(s) vazio(s)");
                return false;
            }
            return true;
        }
        //Postado por Fabio C.R.Teixeira às 10:30 
        //Marcadores: c#, cpf, validação, validadores, validar
        //Site:http://fabiocabral.gabx.com.br/2013/03/c-funcao-para-validar-um-cpf.html
        public bool validarCPF(string CPF)
        {
            if (status != string.Empty)
            {
                int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string TempCPF;
                string Digito;
                int soma;
                int resto;

                CPF = CPF.Trim();
                CPF = CPF.Replace(",", "").Replace("-", "");

                if (CPF.Length != 11)
                    return false;

                TempCPF = CPF.Substring(0, 9);
                soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                Digito = resto.ToString();
                TempCPF = TempCPF + Digito;
                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                Digito = Digito + resto.ToString();

                return CPF.EndsWith(Digito);
            }
            else
            {
                return true;
            }
        }
        #endregion Métodos
    }
}

