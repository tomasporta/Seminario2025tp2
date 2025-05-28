using Practico.Entidades;
using Practico.Windows.helper;
// using Practico.Servicios;

namespace Practico.Windows
{
    public partial class frmFormasDePago : Form
    {
        private readonly FormaDePagoServicio _formaDePagoServicio;
        private bool filterOn = false;
        private List<FormaDePago> _formasDePago = new();
        public frmFormasDePago(FormaDePagoServicio formaDePagoServicio)
        {
            InitializeComponent();
            _formaDePagoServicio = formaDePagoServicio ?? throw new ArgumentNullException(nameof(formaDePagoServicio));
        }

        private void TbsNuevo_Click(object sender, EventArgs e)
        {
            frmFormasDePagoAE frm = new frmFormasDePagoAE { Text = "Nueva forma de pago" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;

            FormaDePago? formaDePago = frm.GetFormaDePago();
            if (formaDePago is null) return;

            try
            {
                if (!_formaDePagoServicio.Existe(formaDePago))
                {
                    _formaDePagoServicio.Guardar(formaDePago);

                    DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                    GridHelpers.SetearFila(r, formaDePago);
                    GridHelpers.AgregarFila(r, dgvDatos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TbsBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            FormaDePago FormaDePagoBorrar = (FormaDePago)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar la forma de pago {FormaDePagoBorrar}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _formaDePagoServicio.Borrar(FormaDePagoBorrar.FormaDePagoId);
                GridHelpers.QuitarFila(r, dgvDatos);
                MessageBox.Show("País eliminado");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TbsEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            FormaDePago? formaDePago = (FormaDePago)r.Tag!;
            if (formaDePago == null) return;
            FormaDePago? formaDePagoEditar = formaDePago.Clonar();
            frmFormasDePagoAE frm = new frmFormasDePagoAE() { Text = "Editar forma de pago" };
            frm.SetFormaDePago(formaDePagoEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            formaDePagoEditar = frm.GetFormaDePago();
            if (formaDePagoEditar == null) return;
            try
            {
                if (!_formaDePagoServicio.Existe(formaDePagoEditar))
                {
                    _formaDePagoServicio.Guardar(formaDePagoEditar);
                    GridHelpers.SetearFila(r, formaDePagoEditar);

                    MessageBox.Show("forma de pago editado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("forma de pago existente", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TbsActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                filterOn = false;

                _formasDePago = _formaDePagoServicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MostrarDatosEnGrilla()
        {
            GridHelpers.LimpiarGrilla(dgvDatos);
            foreach (FormaDePago formaDePago in _formasDePago)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, formaDePago);
                GridHelpers.AgregarFila(r, dgvDatos);
            }
        }

        private void TbsCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmFormasDePago_Load_1(object sender, EventArgs e)
        {
            try
            {
                _formasDePago = _formaDePagoServicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
