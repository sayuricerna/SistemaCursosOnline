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
                string query = "INSERT INTO Inscripcion (IdEstudiante, IdCurso) VALUES ('" +
                               inscripcion.IdEstudiante + "','" +
                               inscripcion.IdCurso + "')";
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

        public List<inscripcion_model> ObtenerTodos()
        {
            var listaInscripciones = new List<inscripcion_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM vistaInscripciones";

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
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                CedulaEstudiante = lector["CedulaEstudiante"].ToString(),
                                NombreCurso = lector["NombreCurso"].ToString(),
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
                string query = "SELECT * FROM vistaInscripciones WHERE IdInscripcion = @IdInscripcion";
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
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                CedulaEstudiante = lector["CedulaEstudiante"].ToString(),
                                NombreCurso = lector["NombreCurso"].ToString(),
                                FechaInscripcion = (DateTime)lector["FechaInscripcion"]
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

                string query = "UPDATE Inscripcion SET IdEstudiante = @IdEstudiante, IdCurso = @IdCurso" +
                                " WHERE IdInscripcion = @IdInscripcion";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", inscripcion.IdEstudiante);
                    comando.Parameters.AddWithValue("@IdCurso", inscripcion.IdCurso);
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
                string query = "SELECT I.IdInscripcion, I.IdEstudiante, I.IdCurso, I.FechaInscripcion, " +
               "E.Nombre AS NombreEstudiante, E.Cedula AS CedulaEstudiante, C.NombreCurso " +
               "FROM Inscripcion I " +
               "INNER JOIN Estudiante E ON I.IdEstudiante = E.IdEstudiante " +
               "INNER JOIN Curso C ON I.IdCurso = C.IdCurso " +
               "WHERE LOWER(E.Nombre) LIKE LOWER(@Texto) OR LOWER(E.Cedula) LIKE LOWER(@Texto)";

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
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                CedulaEstudiante = lector["CedulaEstudiante"].ToString(),
                                NombreCurso = lector["NombreCurso"].ToString(),
                                FechaInscripcion = (DateTime)lector["FechaInscripcion"]
                            });
                        }
                    }
                }
            }
            return listaInscripciones;
        }

        public bool verificarInscripcion(int idEstudiante, int idCurso)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM Inscripcion WHERE IdEstudiante = @IdEstudiante AND IdCurso = @IdCurso";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                    comando.Parameters.AddWithValue("@IdCurso", idCurso);

                    try
                    {
                        conexion.Open();
                        int count = (int)comando.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

    }
}
