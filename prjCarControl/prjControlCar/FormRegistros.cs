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

namespace prjControlCar
{
    public partial class FormRegistros : Form
    {
        Bll bll = new Bll();

        public FormRegistros()
        {
            InitializeComponent();
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            dtgvRegistro.DataSource = bll.SelectRegistro();
            if (this.dtgvRegistro.Columns.Count != 0)
            {
                this.dtgvRegistro.Columns[0].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
                this.dtgvRegistro.Columns[6].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
                this.dtgvRegistro.Columns[11].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
                this.dtgvRegistro.Columns[13].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
                this.dtgvRegistro.Columns[14].Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showId"].ToString());
            }
        }

        private void FormRegistros_Load(object sender, EventArgs e)
        {

        }
    }
}
