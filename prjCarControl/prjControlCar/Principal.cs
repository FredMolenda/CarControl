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
    public partial class Principal : Form
    {
        Bll bll = new Bll();
        public Principal()
        {
            InitializeComponent();
            btnExcluir.Enabled = false;
            btnOcupar.Enabled = false;
            CarregarGrid();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormCliente().Show();
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormVeiculo().Show();
        }

        private void tipoVagaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormTipoVaga().Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormUsuario().Show();
        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormRegistros().Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            new FormAdicionarVaga().Show();
        }

        private void btnOcupar_Click(object sender, EventArgs e)
        {
            var linha = pegarLinha();

            new FormOcupar(int.Parse(dtgvVaga[0, linha].Value.ToString()), int.Parse(dtgvVaga[1, linha].Value.ToString()), dtgvVaga[3, linha].Value.ToString(), dtgvVaga[4, linha].Value.ToString()).Show();
        }

        private void btnDesocupar_Click(object sender, EventArgs e)
        {
            var linha = pegarLinha();

            DateTime Agora = DateTime.Now;

            this.bll.InsertRegistro(new DtoRegistro(DateTime.Parse(dtgvVaga[14, pegarLinha()].Value.ToString()),
                 Agora,
                 int.Parse(dtgvVaga[9, pegarLinha()].Value.ToString()),
                 int.Parse(dtgvVaga[5, pegarLinha()].Value.ToString()),
                 int.Parse(dtgvVaga[12, pegarLinha()].Value.ToString()),
                 int.Parse(dtgvVaga[0, pegarLinha()].Value.ToString()),
                 PrecoTotal(DateTime.Parse(dtgvVaga[14, pegarLinha()].Value.ToString()),
                 Agora, pegarLinha())));

            this.bll.DesocuparVaga(new DtoVaga(int.Parse(dtgvVaga[0, linha].Value.ToString()),
                int.Parse(dtgvVaga[1, linha].Value.ToString()),
                Convert.ToChar("N"),
                dtgvVaga[3, linha].Value.ToString(),
                dtgvVaga[4, linha].Value.ToString(),
                int.Parse("1"), 
                int.Parse("1"), 
                int.Parse("1")));


            BindData(this.GetData());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.bll.DeleteVaga(int.Parse(dtgvVaga[0, pegarLinha()].Value.ToString()));
                BindData(this.GetData());
                btnExcluir.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtgvVaga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToChar(dtgvVaga[2, pegarLinha()].Value.ToString()) == ("N"[0]))
            {
                btnExcluir.Enabled = true;
                btnOcupar.Enabled = true;
                btnDesocupar.Enabled = false;
            }
            if (Convert.ToChar(dtgvVaga[2, pegarLinha()].Value.ToString()) == ("S"[0]))
            {
                btnExcluir.Enabled = false;
                btnOcupar.Enabled = false;
                btnDesocupar.Enabled = true;
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Principal_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            dtgvVaga.DataSource = bll.SelectVaga();
            if (this.dtgvVaga.Columns.Count != 0)
            {
                this.dtgvVaga.Columns[0].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
                this.dtgvVaga.Columns[5].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
                this.dtgvVaga.Columns[9].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
                this.dtgvVaga.Columns[12].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
            }
        }

        private int pegarLinha()
        {
            try
            {
                return dtgvVaga.CurrentRow.Index;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<DtoVaga> GetData()
        {
            try
            {
                return this.bll.SelectVaga();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void BindData(List<DtoVaga> p_List)
        {
            try
            {
                dtgvVaga.DataSource = p_List;

                dtgvVaga.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal PrecoTotal(DateTime inicio, DateTime final, int linha)
        {
            try
            {
                decimal valor = 0;
                TimeSpan tempoPercorrido;

                tempoPercorrido = final.Subtract(inicio);
                

                decimal total = Convert.ToDecimal(tempoPercorrido.Minutes/60.0);

                if (total == 0)
                    total = 1;

                if (Convert.ToChar(dtgvVaga[11, linha].Value.ToString()) == ("H"[0]))
                {
                    List<DtoTipoVaga> lista = new List<DtoTipoVaga>();
                    lista = bll.SelectHorista(Convert.ToInt32(dtgvVaga[12, linha].Value.ToString()));
                    valor = Convert.ToDecimal(lista[0].PrecoHorista);
                }
                if (Convert.ToChar(dtgvVaga[11, linha].Value.ToString()) == ("M"[0]))
                {
                    List<DtoTipoVaga> lista = new List<DtoTipoVaga>();
                    lista = bll.SelectMensalista(Convert.ToInt32(dtgvVaga[12, linha].Value.ToString()));
                    valor = Convert.ToDecimal(lista[0].PrecoMensalista);
                }
                valor = valor * total;
                MessageBox.Show("O total a pagar é :" + valor.ToString());
                return valor;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
