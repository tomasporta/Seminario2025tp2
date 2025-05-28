using Practico.Entidades;
using Practico.Servicios;

namespace Practico.Windows
{
    public partial class frmFormasDePagoAE : Form
    {
        private FormaDePagoServicio? _servicio;
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
                string nombre = TxtFormaDePago.Text.Trim();

                if (_servicio != null)
                {
                    // Si es nuevo
                    if (formaDePago == null && _servicio.Existe(formaDePago))
                    {
                        errorProvider1.SetError(TxtFormaDePago, "Ya existe una forma de pago con ese nombre.");
                        return;
                    }

                    
                  
                }
                if (formaDePago is null)
                {
                    formaDePago = new FormaDePago();
                }

                formaDePago.Descripcion = nombre;
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
