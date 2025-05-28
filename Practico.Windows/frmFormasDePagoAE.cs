using Practico.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practico.Windows
{
    public partial class frmFormasDePagoAE : Form
    {
        private FormaDePago? formaDePago;
        public frmFormasDePagoAE()
        {
            InitializeComponent();
        }
        public FormaDePago? GetFormaDePago()
        {
            return formaDePago;
        }
        public void SetFormaDePago(FormaDePago formaDePago)
        {
            this.formaDePago = formaDePago;
        }


        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (formaDePago is null)
                {
                    formaDePago = new FormaDePago();

                }
                formaDePago.Descripcion = TxtFormaDePago.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtFormaDePago.Text))
            {
                valido = false;
                errorProvider1.SetError(TxtFormaDePago, "El nombre es requerido");

            }
            return valido;
        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
