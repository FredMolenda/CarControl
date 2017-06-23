namespace prjControlCar
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tipoVagaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgvVaga = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnOcupar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnDesocupar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvVaga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(71)))));
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoVagaToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.veiculosToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.registrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(713, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tipoVagaToolStripMenuItem
            // 
            this.tipoVagaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.tipoVagaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tipoVagaToolStripMenuItem.Name = "tipoVagaToolStripMenuItem";
            this.tipoVagaToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.tipoVagaToolStripMenuItem.Text = "Tipos Vaga";
            this.tipoVagaToolStripMenuItem.Click += new System.EventHandler(this.tipoVagaToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.clienteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.clienteToolStripMenuItem.Text = "Clientes";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // veiculosToolStripMenuItem
            // 
            this.veiculosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.veiculosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.veiculosToolStripMenuItem.Name = "veiculosToolStripMenuItem";
            this.veiculosToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.veiculosToolStripMenuItem.Text = "Veículos";
            this.veiculosToolStripMenuItem.Click += new System.EventHandler(this.veiculosToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.usuariosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.usuariosToolStripMenuItem.Text = "Usuários";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.registrosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.registrosToolStripMenuItem.Text = "Registros";
            this.registrosToolStripMenuItem.Click += new System.EventHandler(this.registrosToolStripMenuItem_Click);
            // 
            // dtgvVaga
            // 
            this.dtgvVaga.AllowUserToAddRows = false;
            this.dtgvVaga.AllowUserToDeleteRows = false;
            this.dtgvVaga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvVaga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvVaga.Location = new System.Drawing.Point(12, 30);
            this.dtgvVaga.Name = "dtgvVaga";
            this.dtgvVaga.ReadOnly = true;
            this.dtgvVaga.Size = new System.Drawing.Size(525, 362);
            this.dtgvVaga.TabIndex = 1;
            this.dtgvVaga.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvVaga_CellClick);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(71)))));
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(543, 110);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(158, 33);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnOcupar
            // 
            this.btnOcupar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOcupar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(71)))));
            this.btnOcupar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcupar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnOcupar.ForeColor = System.Drawing.Color.White;
            this.btnOcupar.Location = new System.Drawing.Point(543, 44);
            this.btnOcupar.Name = "btnOcupar";
            this.btnOcupar.Size = new System.Drawing.Size(158, 34);
            this.btnOcupar.TabIndex = 1;
            this.btnOcupar.Text = "Ocupar";
            this.btnOcupar.UseVisualStyleBackColor = false;
            this.btnOcupar.Click += new System.EventHandler(this.btnOcupar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(71)))));
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(543, 241);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(158, 34);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnDesocupar
            // 
            this.btnDesocupar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDesocupar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(71)))));
            this.btnDesocupar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesocupar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnDesocupar.ForeColor = System.Drawing.Color.White;
            this.btnDesocupar.Location = new System.Drawing.Point(543, 175);
            this.btnDesocupar.Name = "btnDesocupar";
            this.btnDesocupar.Size = new System.Drawing.Size(158, 34);
            this.btnDesocupar.TabIndex = 3;
            this.btnDesocupar.Text = "Desocupar";
            this.btnDesocupar.UseVisualStyleBackColor = false;
            this.btnDesocupar.Click += new System.EventHandler(this.btnDesocupar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::prjControlCar.Properties.Resources.CarControl_icon;
            this.pictureBox1.Location = new System.Drawing.Point(595, 306);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(83)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(713, 413);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDesocupar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnOcupar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dtgvVaga);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Click += new System.EventHandler(this.Principal_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvVaga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tipoVagaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgvVaga;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnOcupar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnDesocupar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
    }
}