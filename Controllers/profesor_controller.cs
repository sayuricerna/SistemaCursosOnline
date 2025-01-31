using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaCursosOnline.Config;
using SistemaCursosOnline.Models;

namespace SistemaCursosOnline.Controllers
{
    class profesor_controller
    {
        private readonly conexion cn = new conexion();

        public string Insertar(profesor_model profesor)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "INSERT INTO Profesor (Cedula, Nombre, Email, Telefono, FechaNacimiento, Direccion) " +
                               "VALUES (@Cedula, @Nombre, @Email, @Telefono, @FechaNacimiento, @Direccion)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Cedula", profesor.Cedula);
                    comando.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                    comando.Parameters.AddWithValue("@Email", profesor.Email);
                    comando.Parameters.AddWithValue("@Telefono", profesor.Telefono);
                    comando.Parameters.AddWithValue("@FechaNacimiento", profesor.FechaNacimiento);
                    comando.Parameters.AddWithValue("@Direccion", profesor.Direccion);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
        }

        public List<profesor_model> ObtenerTodos()
        {
            var listaProfesores = new List<profesor_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM Profesor";
                using (var comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var profesor = new profesor_model
                            {
                                IdProfesor = (int)lector["IdProfesor"],
                                Cedula = lector["Cedula"].ToString(),
                                Nombre = lector["Nombre"].ToString(),
                                Email = lector["Email"].ToString(),
                                Telefono = lector["Telefono"].ToString(),
                                FechaNacimiento = (DateTime)lector["FechaNacimiento"],
                                Direccion = lector["Direccion"].ToString()
                            };
                            listaProfesores.Add(profesor);
                        }
                    }
                }
            }
            return listaProfesores;
        }

        public profesor_model ObtenerPorId(int id)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM Profesor WHERE IdProfesor = @IdProfesor";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdProfesor", id);
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new profesor_model
                            {
                                IdProfesor = (int)lector["IdProfesor"],
                                Cedula = lector["Cedula"].ToString(),
                                Nombre = lector["Nombre"].ToString(),
                                Email = lector["Email"].ToString(),
                                Telefono = lector["Telefono"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(lector["FechaNacimiento"]),
                                Direccion = lector["Direccion"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public string Actualizar(profesor_model profesor)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "UPDATE Profesor SET Cedula = @Cedula, Nombre = @Nombre, Email = @Email, " +
                               "Telefono = @Telefono, FechaNacimiento = @FechaNacimiento, Direccion = @Direccion " +
                               "WHERE IdProfesor = @IdProfesor";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Cedula", profesor.Cedula);
                    comando.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                    comando.Parameters.AddWithValue("@Email", profesor.Email);
                    comando.Parameters.AddWithValue("@Telefono", profesor.Telefono);
                    comando.Parameters.AddWithValue("@FechaNacimiento", profesor.FechaNacimiento);
                    comando.Parameters.AddWithValue("@Direccion", profesor.Direccion);
                    comando.Parameters.AddWithValue("@IdProfesor", profesor.IdProfesor);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "DELETE FROM Profesor WHERE IdProfesor = @IdProfesor";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdProfesor", id);
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        public List<profesor_model> Buscar(string texto)
        {
            var listaProfesores = new List<profesor_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM Profesor WHERE Nombre LIKE @Texto";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaProfesores.Add(new profesor_model
                            {
                                IdProfesor = (int)lector["IdProfesor"],
                                Cedula = lector["Cedula"].ToString(),
                                Nombre = lector["Nombre"].ToString(),
                                Email = lector["Email"].ToString(),
                                Telefono = lector["Telefono"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(lector["FechaNacimiento"]),
                                Direccion = lector["Direccion"].ToString()
                            });
                        }
                    }
                }
            }
            return listaProfesores;
        }
    }
}
