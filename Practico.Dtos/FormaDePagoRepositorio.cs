using Microsoft.Data.SqlClient;
using Practico.Entidades;
using System.Configuration;
using System.Xml.Linq;

namespace Practico.Dtos
{
    public class FormaDePagoRepositorio
    {
        private readonly bool _usarCache;
        private List<FormaDePago> FormasDePago = new();
        private readonly string? _connectionString;
        public FormaDePagoRepositorio(int umbralCache = 30)
        {
            _connectionString = ConfigurationManager
                    .ConnectionStrings["MiConexion"].ToString();
            var cantidadRegistros = ObtenerCantidadRegistros();
            _usarCache = cantidadRegistros <= umbralCache;
            if (_usarCache)
            {
                LeerDatos();

            }
        }
        /// <summary>
        /// Método privado por ahora para obtener la cantidad de registros
        /// de la tabla
        /// </summary>
        /// <returns>un int con la cantidad de registros</returns>
        private int ObtenerCantidadRegistros()
        {
            using (var cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = @"SELECT COUNT(*) FROM FormasDePago";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// Método privado para leer los registros de la tabla de FormaDePagoes
        /// y almacenarlos en la lista del repositorio
        /// </summary>
        private void LeerDatos()
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = "SELECT FormaDePagoId, Descripcion FROM FormasDePago";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FormaDePago FormaDePago = ConstruirFormaDePago(reader);
                                FormasDePago.Add(FormaDePago);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Método para devolver la lista de FormaDePagoes ordenada por nombre
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FormaDePago> GetLista()
        {
            if (_usarCache)
            {
                return FormasDePago.OrderBy(p => p.Descripcion).ToList();
            }
            List<FormaDePago> lista = new List<FormaDePago>();
            using (var cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                var query = "SELECT FormaDePagoId, Descripcion FROM FormasDePago ORDER BY Descripcion";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FormaDePago p = ConstruirFormaDePago(reader);
                            lista.Add(p);
                        }
                    }
                }
            }
            return lista;
        }
        /// <summary>
        /// Método privado para construir un objeto de tipo TipoDePago
        /// </summary>
        /// <param name="reader">Registro del SqlDataReader que contiene los datos</param>
        /// <returns>un nuevo país con los datos del reader</returns>
        private FormaDePago ConstruirFormaDePago(SqlDataReader reader)
        {
            return new FormaDePago
            {
                FormaDePagoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
        public void Agregar(FormaDePago formaDePago)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO FormasDePago (Descripcion)
                    VALUES(@Descripcion); SELECT SCOPE_IDENTITY();";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", formaDePago.Descripcion);
                        int FormaDePagoId = (int)(decimal)cmd.ExecuteScalar();
                        FormaDePago tipo = new FormaDePago();
                        Console.WriteLine(tipo.FormaDePagoId);

                    }
                }
                if (_usarCache)
                {
                    FormasDePago.Add(formaDePago);

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public bool Existe(FormaDePago FormaDePago)
        {
            if (_usarCache)
            {
                return FormaDePago.FormaDePagoId == 0
            ? FormasDePago.Any(p => p.Descripcion == FormaDePago.Descripcion)
            : FormasDePago.Any(p => p.Descripcion == FormaDePago.Descripcion
            && p.FormaDePagoId != FormaDePago.FormaDePagoId);
            }
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query;

                    if (FormaDePago.FormaDePagoId == 0)
                    {
                        query = @"
                    SELECT COUNT(*) FROM FormasDePago 
                    WHERE LOWER(Descripcion) = LOWER(@Descripcion)";
                    }
                    else
                    {
                        query = @"
                    SELECT COUNT(*) FROM FormasDePago 
                    WHERE LOWER(Descripcion) = LOWER(@Descripcion) 
                    AND FormaDePagoId <> @FormaDePagoId";
                    }

                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", FormaDePago.Descripcion);

                        if (FormaDePago.FormaDePagoId != 0)
                        {
                            cmd.Parameters.AddWithValue("@FormaDePagoId", FormaDePago.FormaDePagoId);
                        }

                        int cantidad = (int)cmd.ExecuteScalar();
                        return cantidad > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error en la consulta: {ex.Message}");
                return false;
            }
        }





        public void Borrar(int FormaDePagoId)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM FormasDePago WHERE FormaDePagoId=@FormaDePagoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@FormaDePagoId", FormaDePagoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                if (_usarCache)
                {
                    FormaDePago? FormaDePagoBorrar = FormasDePago.FirstOrDefault(p => p.FormaDePagoId == FormaDePagoId);

                    if (FormaDePagoBorrar == null) return;
                    FormasDePago.Remove(FormaDePagoBorrar);

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar el registro", ex);
            }
        }

        public void Editar(FormaDePago FormaDePago)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    var query = @"UPDATE FormasDePago SET Descripcion=@Descripcion
                               WHERE FormaDePagoId=@FormaDePagoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", FormaDePago.Descripcion);
                        cmd.Parameters.AddWithValue("@FormaDePagoId", FormaDePago.FormaDePagoId);
                        cmd.ExecuteNonQuery();
                    }
                    if (_usarCache)
                    {
                        FormaDePago? FormaDePagoEditar = FormasDePago.FirstOrDefault(p => p.FormaDePagoId == FormaDePago.FormaDePagoId);
                        if (FormaDePagoEditar == null) return;
                        FormaDePagoEditar.Descripcion = FormaDePago.Descripcion;

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar el registro", ex);
            }
        }


    }

}
