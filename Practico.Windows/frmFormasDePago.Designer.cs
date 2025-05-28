namespace Practico.Windows
{
    partial class frmFormasDePago
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormasDePago));
            toolStrip1 = new ToolStrip();
            TbsNuevo = new ToolStripButton();
            TbsEditar = new ToolStripButton();
            TbsBorrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            TbsActualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            TbsCerrar = new ToolStripButton();
            panel1 = new Panel();
            dgvDatos = new DataGridView();
            ColId = new DataGridViewTextBoxColumn();
            ColFormasDePago = new DataGridViewTextBoxColumn();
            errorProvider1 = new ErrorProvider(components);
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { TbsNuevo, TbsEditar, TbsBorrar, toolStripSeparator1, TbsActualizar, toolStripSeparator2, TbsCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // TbsNuevo
            // 
            TbsNuevo.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TbsNuevo.Image = (Image)resources.GetObject("TbsNuevo.Image");
            TbsNuevo.ImageTransparentColor = Color.Magenta;
            TbsNuevo.Name = "TbsNuevo";
            TbsNuevo.Size = new Size(46, 22);
            TbsNuevo.Text = "Nuevo";
            TbsNuevo.Click += TbsNuevo_Click;
            // 
            // TbsEditar
            // 
            TbsEditar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TbsEditar.Image = (Image)resources.GetObject("TbsEditar.Image");
            TbsEditar.ImageTransparentColor = Color.Magenta;
            TbsEditar.Name = "TbsEditar";
            TbsEditar.Size = new Size(41, 22);
            TbsEditar.Text = "Editar";
            TbsEditar.Click += TbsEditar_Click;
            // 
            // TbsBorrar
            // 
            TbsBorrar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TbsBorrar.Image = (Image)resources.GetObject("TbsBorrar.Image");
            TbsBorrar.ImageTransparentColor = Color.Magenta;
            TbsBorrar.Name = "TbsBorrar";
            TbsBorrar.Size = new Size(43, 22);
            TbsBorrar.Text = "Borrar";
            TbsBorrar.Click += TbsBorrar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // TbsActualizar
            // 
            TbsActualizar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TbsActualizar.Image = (Image)resources.GetObject("TbsActualizar.Image");
            TbsActualizar.ImageTransparentColor = Color.Magenta;
            TbsActualizar.Name = "TbsActualizar";
            TbsActualizar.Size = new Size(63, 22);
            TbsActualizar.Text = "Actualizar";
            TbsActualizar.Click += TbsActualizar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // TbsCerrar
            // 
            TbsCerrar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TbsCerrar.Image = (Image)resources.GetObject("TbsCerrar.Image");
            TbsCerrar.ImageTransparentColor = Color.Magenta;
            TbsCerrar.Name = "TbsCerrar";
            TbsCerrar.Size = new Size(43, 22);
            TbsCerrar.Text = "Cerrar";
            TbsCerrar.Click += TbsCerrar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDatos);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 425);
            panel1.TabIndex = 1;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { ColId, ColFormasDePago });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(800, 425);
            dgvDatos.TabIndex = 0;
            // 
            // ColId
            // 
            ColId.HeaderText = "Id";
            ColId.Name = "ColId";
            ColId.ReadOnly = true;
            ColId.Visible = false;
            // 
            // ColFormasDePago
            // 
            ColFormasDePago.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColFormasDePago.HeaderText = "Formas de Pago";
            ColFormasDePago.Name = "ColFormasDePago";
            ColFormasDePago.ReadOnly = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmFormasDePago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "frmFormasDePago";
            Text = "frmFormasDePago";
            Load += frmFormasDePago_Load_1;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton TbsNuevo;
        private ToolStripButton TbsEditar;
        private ToolStripButton TbsBorrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton TbsActualizar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton TbsCerrar;
        private Panel panel1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColFormasDePago;
        private ErrorProvider errorProvider1;
    }
}