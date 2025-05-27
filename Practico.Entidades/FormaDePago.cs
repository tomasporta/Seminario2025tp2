namespace Practico.Entidades
{
    public class FormaDePago
    {
        public int FormaDePagoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public override string ToString()
        {
            return $"{Descripcion}";
        }
        public void AsignarId(int nuevoId)
        {
            this.FormaDePagoId = nuevoId;
        }
        public FormaDePago Clonar()
        {
            return new FormaDePago
            {
                FormaDePagoId = FormaDePagoId,
                Descripcion = Descripcion
            };
        }
    }
}
