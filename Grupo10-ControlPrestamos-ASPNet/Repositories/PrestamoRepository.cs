using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Grupo10_ControlPrestamos_ASPNet.Models;

namespace Grupo10_ControlPrestamos_ASPNet.Repositories
{
    public class PrestamoRepository
    {
        public IReadOnlyList<Prestamo> GetPrestamos(string buscarCliente, string estado)
        {
            var prestamos = new List<Prestamo>();
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                SELECT IdPrestamo, NombreCliente, Articulo, FechaPrestamo, FechaDevolucionEsperada, Estado
                FROM Prestamos
                WHERE (@BuscarCliente = '' OR NombreCliente LIKE '%' + @BuscarCliente + '%')
                  AND (@Estado = '' OR @Estado = 'Todos' OR Estado = @Estado)
                ORDER BY FechaPrestamo DESC, IdPrestamo DESC", connection))
            {
                command.Parameters.AddWithValue("@BuscarCliente", buscarCliente ?? string.Empty);
                command.Parameters.AddWithValue("@Estado", estado ?? string.Empty);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prestamos.Add(new Prestamo
                        {
                            IdPrestamo = reader.GetInt32(0),
                            NombreCliente = reader.GetString(1),
                            Articulo = reader.GetString(2),
                            FechaPrestamo = reader.GetDateTime(3),
                            FechaDevolucionEsperada = reader.GetDateTime(4),
                            Estado = reader.GetString(5)
                        });
                    }
                }
            }

            return prestamos;
        }

        public IReadOnlyList<HistorialPrestamo> GetHistorialPrestamos(string buscarCliente)
        {
            var historial = new List<HistorialPrestamo>();
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD2"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                SELECT IdPrestamo, NombreCliente, Articulo, FechaPrestamo
                FROM HistorialPrestamos
                WHERE (@BuscarCliente = '' OR NombreCliente LIKE '%' + @BuscarCliente + '%')
                ORDER BY FechaPrestamo DESC, IdPrestamo DESC", connection))
            {
                command.Parameters.AddWithValue("@BuscarCliente", buscarCliente ?? string.Empty);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        historial.Add(new HistorialPrestamo
                        {
                            IdPrestamo = reader.GetInt32(0),
                            NombreCliente = reader.GetString(1),
                            Articulo = reader.GetString(2),
                            FechaPrestamo = reader.GetDateTime(3)
                        });
                    }
                }
            }

            return historial;
        }

        public void CreatePrestamo(PrestamoCreateViewModel model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                INSERT INTO Prestamos (NombreCliente, Articulo, FechaPrestamo, FechaDevolucionEsperada, Estado)
                VALUES (@NombreCliente, @Articulo, @FechaPrestamo, @FechaDevolucionEsperada, @Estado)", connection))
            {
                command.Parameters.AddWithValue("@NombreCliente", model.NombreCliente.Trim());
                command.Parameters.AddWithValue("@Articulo", model.Articulo);
                command.Parameters.AddWithValue("@FechaPrestamo", System.DateTime.Today);
                command.Parameters.AddWithValue("@FechaDevolucionEsperada", model.FechaDevolucionEsperada);
                command.Parameters.AddWithValue("@Estado", model.Estado);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
