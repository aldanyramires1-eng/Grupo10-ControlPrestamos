using Grupo10_ControlPrestamos_ASPNet.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

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

        public PrestamoCreateViewModel GetPrestamos(int IdPrestamo)
        {
            var registro = new PrestamoCreateViewModel();
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                SELECT NombreCliente, Articulo, FechaDevolucionEsperada, Estado
                FROM Prestamos
                WHERE IdPrestamo = @IdPrestamo", connection))
            {
                command.Parameters.AddWithValue("@IdPrestamo", IdPrestamo);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Usamos 'if' porque solo esperamos un resultado
                    {
                        registro = new PrestamoCreateViewModel
                        {
                            IdPrestamo = IdPrestamo,
                            NombreCliente = reader.GetString(0),
                            Articulo = reader.GetString(1),
                            FechaDevolucionEsperada = reader.GetDateTime(2),
                            // Agregamos los campos faltantes que incluiste en tu SELECT:
                            Estado = reader.GetString(3)
                        };
                    }
                }
            }

            return registro;
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


        public void EditPrestamos(PrestamoCreateViewModel model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1. LÓGICA DE ACTUALIZACIÓN
                string updateSql = @"UPDATE Prestamos 
                             SET NombreCliente = @Nombre, Articulo = @Articulo, FechaDevolucionEsperada = @FechaDevolucionEsperada, Estado = @Estado
                             WHERE IdPrestamo = @IdPrestamo";

                using (var updateCommand = new SqlCommand(updateSql, connection))
                {
                    updateCommand.Parameters.AddWithValue("@Nombre", model.NombreCliente);
                    updateCommand.Parameters.AddWithValue("@Articulo", model.Articulo);
                    updateCommand.Parameters.AddWithValue("@FechaDevolucionEsperada", model.FechaDevolucionEsperada);
                    updateCommand.Parameters.AddWithValue("@Estado", model.Estado);
                    updateCommand.Parameters.AddWithValue("@IdPrestamo", model.IdPrestamo);
                    updateCommand.ExecuteNonQuery();
                }

            }

        }


        public void DeletePrestamos(int IdPrestamo)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                // 1. LÓGICA DE ACTUALIZACIÓN
                string sql = "DELETE FROM Prestamos WHERE IdPrestamo = @IdPrestamo";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdPrestamo", IdPrestamo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }





        public IReadOnlyList<HistorialPrestamo> GetHistorialPrestamos(string buscarCliente)
        {
            var historial = new List<HistorialPrestamo>();
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                SELECT IdPrestamo, NombreCliente, Articulo, FechaPrestamo, IdHistorial
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
                            IdHistorial = reader.GetInt32(4),
                            FechaPrestamo = reader.GetDateTime(3)
                        });
                    }
                }
            }

            return historial;
        }

        public HistorialPrestamo GetHistorialPrestamos(int IdHistorial)
        {
            var registro = new HistorialPrestamo();
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                SELECT IdPrestamo, NombreCliente, Articulo, FechaDevolucionEsperada, FechaDevolucion, EstadoFinal
                FROM HistorialPrestamos
                WHERE IdHistorial = @IdHistorial", connection))
            {
                command.Parameters.AddWithValue("@IdHistorial", IdHistorial);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Usamos 'if' porque solo esperamos un resultado
                    {
                        registro = new HistorialPrestamo
                        {
                            IdPrestamo = reader.GetInt32(0),
                            NombreCliente = reader.GetString(1),
                            Articulo = reader.GetString(2),
                            // Agregamos los campos faltantes que incluiste en tu SELECT:
                            FechaDevolucionEsperada = reader.GetDateTime(3),
                            FechaDevolucion = reader.GetDateTime(4),
                            EstadoFinal = reader.GetString(5)
                        };
                    }
                }
            }

            return registro;
        }


        public void CreateHistorialPrestamo(HistorialPrestamo model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                INSERT INTO HistorialPrestamos (IdPrestamo, NombreCliente, Articulo, FechaPrestamo, FechaDevolucionEsperada, FechaDevolucion, EstadoFinal)
                VALUES (@IdPrestamo, @NombreCliente, @Articulo, @FechaPrestamo, @FechaDevolucionEsperada, @FechaDevolucion, @EstadoFinal)", connection))
            {
                command.Parameters.AddWithValue("@NombreCliente", model.NombreCliente.Trim());
                command.Parameters.AddWithValue("@IdPrestamo", model.IdPrestamo);
                command.Parameters.AddWithValue("@Articulo", model.Articulo);
                command.Parameters.AddWithValue("@FechaPrestamo", System.DateTime.Today);
                command.Parameters.AddWithValue("@FechaDevolucionEsperada", model.FechaDevolucionEsperada);
                command.Parameters.AddWithValue("@FechaDevolucion", model.FechaDevolucion);
                command.Parameters.AddWithValue("@EstadoFinal", model.EstadoFinal);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void EditHistorialPrestamos(HistorialPrestamo historialPrestamo)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1. LÓGICA DE ACTUALIZACIÓN
                string updateSql = @"UPDATE HistorialPrestamos 
                             SET NombreCliente = @Nombre, Articulo = @Articulo, FechaDevolucionEsperada = @FechaDevolucionEsperada, EstadoFinal = @EstadoFinal
                             WHERE IdHistorial = @IdHistorial";

                using (var updateCommand = new SqlCommand(updateSql, connection))
                {
                    updateCommand.Parameters.AddWithValue("@Nombre", historialPrestamo.NombreCliente);
                    updateCommand.Parameters.AddWithValue("@Articulo", historialPrestamo.Articulo);
                    updateCommand.Parameters.AddWithValue("@FechaDevolucionEsperada", historialPrestamo.FechaDevolucionEsperada);
                    updateCommand.Parameters.AddWithValue("@EstadoFinal", historialPrestamo.EstadoFinal);
                    updateCommand.Parameters.AddWithValue("@IdHistorial", historialPrestamo.IdHistorial);
                    updateCommand.ExecuteNonQuery();
                }

            }

        }


        public void DeleteHistorialPrestamos(int idHistorial)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionBD1"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                // 1. LÓGICA DE ACTUALIZACIÓN
                string sql = "DELETE FROM HistorialPrestamos WHERE IdHistorial = @idHistorial";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idHistorial", idHistorial);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }


    }
}
