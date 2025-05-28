using Practico.Dtos;
using Practico.Entidades;
using Practico.Utilidades;

namespace Practico.Servicios
{
    public class FormaDePagoServicio
    {
        private readonly FormaDePagoRepositorio _formaDePagoRepositorio = null!;

        public FormaDePagoServicio()
        {
            try
            {
                _formaDePagoRepositorio = new FormaDePagoRepositorio(ConstantesDelSistema.umbralCache);
            }
            catch (Exception)

            {

                throw;
            }
        }
        public void Borrar(int FormaDePagoId)
        {

            _formaDePagoRepositorio.Borrar(FormaDePagoId);
        }
        public bool Existe(FormaDePago formaDePago)
        {

            return _formaDePagoRepositorio.Existe(formaDePago);
        }
        public List<FormaDePago> GetLista()
        {
            try
            {
                return _formaDePagoRepositorio.GetLista();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Guardar(FormaDePago formaDePago)
        {
            if (formaDePago.FormaDePagoId == 0)
            {
                _formaDePagoRepositorio.Agregar(formaDePago);
            }
            else
            {
                _formaDePagoRepositorio.Editar(formaDePago);
            }
        }
    }

}
