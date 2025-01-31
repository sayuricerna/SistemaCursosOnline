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
    class estudiante_controller
    {
        private readonly conexion cn = new conexion();
        //estudiante_model IdEstudiante,Cedula,Nombre,Email,Telefono,FechaNacimiento,Direccion
        public string Insertar(estudiante_model estudiante)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "INSERT INTO Estudiante (Cedula, Nombre, Email, Telefono, FechaNacimiento, Direccion) " +
                               "VALUES (@Cedula, @Nombre, @Email, @Telefono, @FechaNacimiento, @Direccion)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Cedula", estudiante.Cedula);
                    comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                    comando.Parameters.AddWithValue("@Email", estudiante.Email);
                    comando.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
                    comando.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                    comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);

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

        public List<estudiante_model> ObtenerTodos()
        {
            var listaEstudiantes = new List<estudiante_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM Estudiante";
                using (var comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var estudiante = new estudiante_model
                            {
                                IdEstudiante = (int)lector["IdEstudiante"],
                                Cedula = lector["Cedula"].ToString(),
                                Nombre = lector["Nombre"].ToString(),
                                Email = lector["Email"].ToString(),
                                Telefono = lector["Telefono"].ToString(),
                                FechaNacimiento = (DateTime)lector["FechaNacimiento"],
                                Direccion = lector["Direccion"].ToString()
                            };
                            listaEstudiantes.Add(estudiante);
                        }
                    }
                }
            }
            return listaEstudiantes;
        }

        public estudiante_model ObtenerPorId(int id)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM Estudiante WHERE IdEstudiante = @IdEstudiante";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", id);
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new estudiante_model
                            {
                                IdEstudiante = (int)lector["IdEstudiante"],
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

        public string Actualizar(estudiante_model estudiante)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "UPDATE Estudiante SET Cedula = @Cedula, Nombre = @Nombre, Email = @Email, " +
                               "Telefono = @Telefono, FechaNacimiento = @FechaNacimiento, Direccion = @Direccion " +
                               "WHERE IdEstudiante = @IdEstudiante";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Cedula", estudiante.Cedula);
                    comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                    comando.Parameters.AddWithValue("@Email", estudiante.Email);
                    comando.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
                    comando.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                    comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                    comando.Parameters.AddWithValue("@IdEstudiante", estudiante.IdEstudiante);

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
                string query = "DELETE FROM Estudiante WHERE IdEstudiante = @IdEstudiante";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", id);
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
        public List<estudiante_model> Buscar(string texto)
        {
            var listaEstudiantes = new List<estudiante_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM Estudiante WHERE Nombre LIKE @Texto";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaEstudiantes.Add(new estudiante_model
                            {
                                IdEstudiante = (int)lector["IdEstudiante"],
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
            return listaEstudiantes;
        }
    }
}
