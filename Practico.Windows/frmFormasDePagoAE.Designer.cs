namespace Practico.Windows
{
    partial class frmFormasDePagoAE
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
            label1 = new Label();
            TxtFormaDePago = new TextBox();
            BtnOK = new Button();
            BtnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 47);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Forma de Pago";
            // 
            // TxtFormaDePago
            // 
            TxtFormaDePago.Location = new Point(168, 44);
            TxtFormaDePago.Name = "TxtFormaDePago";
            TxtFormaDePago.Size = new Size(228, 23);
            TxtFormaDePago.TabIndex = 1;
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(66, 102);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(110, 57);
            BtnOK.TabIndex = 2;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(286, 102);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(110, 57);
            BtnCancelar.TabIndex = 2;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click_1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmFormasDePagoAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 218);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
            Controls.Add(TxtFormaDePago);
            Controls.Add(label1);
            Name = "frmFormasDePagoAE";
            Text = "frmFormasDePagoAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtFormaDePago;
        private Button BtnOK;
        private Button BtnCancelar;
        private ErrorProvider errorProvider1;
    }
}