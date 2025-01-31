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
    class inscripcion_controller
    {
        private readonly conexion cn = new conexion();
        public string Insertar(inscripcion_model inscripcion)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "INSERT INTO Inscripcion (IdEstudiante, IdCurso, FechaInscripcion) VALUES ('" +
                               inscripcion.IdEstudiante + "','" +
                               inscripcion.IdCurso + "','" +
                               inscripcion.FechaInscripcion.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                using (var comando = new SqlCommand(query, conexion))
                {
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

        /*
        public string Insertar(inscripcion_model inscripcion)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "INSERT INTO Inscripcion (IdEstudiante, IdCurso, FechaInscripcion) " +
                               "VALUES (@IdEstudiante, @IdCurso, @FechaInscripcion)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", inscripcion.IdEstudiante);
                    comando.Parameters.AddWithValue("@IdCurso", inscripcion.IdCurso);
                    comando.Parameters.AddWithValue("@FechaInscripcion", inscripcion.FechaInscripcion);

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
        */

        public List<inscripcion_model> ObtenerTodos()
        {
            var listaInscripciones = new List<inscripcion_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT IdInscripcion, IdEstudiante, IdCurso, FechaInscripcion FROM Inscripcion";
                using (var comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var inscripcion = new inscripcion_model
                            {
                                IdInscripcion = (int)lector["IdInscripcion"],
                                IdEstudiante = (int)lector["IdEstudiante"],
                                IdCurso = (int)lector["IdCurso"],
                                //FechaInscripcion = Convert.ToDateTime(lector["FechaInscripcion"])
                                
                                FechaInscripcion = (DateTime)lector["FechaInscripcion"]
                            };
                            listaInscripciones.Add(inscripcion);
                        }
                    }
                }
            }
            return listaInscripciones;
        }

        public inscripcion_model ObtenerPorId(int id)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM Inscripcion WHERE IdInscripcion = @IdInscripcion";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdInscripcion", id);
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new inscripcion_model
                            {
                                IdInscripcion = (int)lector["IdInscripcion"],
                                IdEstudiante = (int)lector["IdEstudiante"],
                                IdCurso = (int)lector["IdCurso"],
                                FechaInscripcion = Convert.ToDateTime(lector["FechaInscripcion"])
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public string Actualizar(inscripcion_model inscripcion)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "UPDATE Inscripcion SET IdEstudiante = @IdEstudiante, IdCurso = @IdCurso, " +
                                //"FechaInscripcion = @FechaInscripcion WHERE IdInscripcion = @IdInscripcion";
                                "WHERE IdInscripcion = @IdInscripcion";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", inscripcion.IdEstudiante);
                    comando.Parameters.AddWithValue("@IdCurso", inscripcion.IdCurso);
                    //comando.Parameters.AddWithValue("@FechaInscripcion", inscripcion.FechaInscripcion);
                    comando.Parameters.AddWithValue("@IdInscripcion", inscripcion.IdInscripcion);

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
                string query = "DELETE FROM Inscripcion WHERE IdInscripcion = @IdInscripcion";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdInscripcion", id);
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
        public List<inscripcion_model> Buscar(string texto)
        {
            var listaInscripciones = new List<inscripcion_model>();
            using (var conexion = cn.obtenerConexion())
            {
                // Ajustamos la consulta para que filtre por nombre o cédula sin cambiar el modelo
                string query = "SELECT I.IdInscripcion, I.IdEstudiante, I.IdCurso, I.FechaInscripcion " +
                               "FROM Inscripcion I " +
                               "INNER JOIN Estudiante E ON I.IdEstudiante = E.IdEstudiante " +
                               "WHERE E.Nombre LIKE @Texto OR E.Cedula LIKE @Texto";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaInscripciones.Add(new inscripcion_model
                            {
                                IdInscripcion = (int)lector["IdInscripcion"],
                                IdEstudiante = (int)lector["IdEstudiante"],
                                IdCurso = (int)lector["IdCurso"],
                                FechaInscripcion = Convert.ToDateTime(lector["FechaInscripcion"])
                            });
                        }
                    }
                }
            }
            return listaInscripciones;
        }

        /*
        public List<inscripcion_model> Buscar(int idEstudiante)
        {
            var listaInscripciones = new List<inscripcion_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM Inscripcion WHERE IdEstudiante = @IdEstudiante";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaInscripciones.Add(new inscripcion_model
                            {
                                IdInscripcion = (int)lector["IdInscripcion"],
                                IdEstudiante = (int)lector["IdEstudiante"],
                                IdCurso = (int)lector["IdCurso"],
                                FechaInscripcion = Convert.ToDateTime(lector["FechaInscripcion"])
                            });
                        }
                    }
                }
            }
            return listaInscripciones;
        }
        */
    }
}
