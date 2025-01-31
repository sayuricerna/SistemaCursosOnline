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
    class curso_controller
    {
        //curso_model IdCurso NombreCurso Descripcion FechaInicio FechaFin IdProfesor
        private readonly conexion cn = new conexion();

        public string Insertar(curso_model curso)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "INSERT INTO Curso (NombreCurso, Descripcion, FechaInicio, FechaFin, IdProfesor) " +
                               "VALUES (@NombreCurso, @Descripcion, @FechaInicio, @FechaFin, @IdProfesor)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@NombreCurso", curso.NombreCurso);
                    comando.Parameters.AddWithValue("@Descripcion", curso.Descripcion);
                    comando.Parameters.AddWithValue("@FechaInicio", curso.FechaInicio);
                    comando.Parameters.AddWithValue("@FechaFin", curso.FechaFin);
                    comando.Parameters.AddWithValue("@IdProfesor", curso.IdProfesor);

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

        public List<curso_model> ObtenerTodos()
        {
            var listaCursos = new List<curso_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM vistaCursoConProfesor";
                //string query = "SELECT * FROM Curso";
                using (var comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var curso = new curso_model
                            {
                                IdCurso = (int)lector["IdCurso"],
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Descripcion = lector["Descripcion"].ToString(),
                                FechaInicio = Convert.ToDateTime(lector["FechaInicio"]),
                                FechaFin = Convert.ToDateTime(lector["FechaFin"]),
                                IdProfesor = (int)lector["IdProfesor"],
                                //agg
                                NombreProfesor = lector["NombreProfesor"].ToString(),


                            };
                            listaCursos.Add(curso);
                        }
                    }
                }
            }
            return listaCursos;
        }
        

        public curso_model ObtenerPorId(int id)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM vistaCursoConProfesor WHERE IdCurso = @IdCurso";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdCurso", id);
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new curso_model
                            {
                                IdCurso = (int)lector["IdCurso"],
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Descripcion = lector["Descripcion"].ToString(),
                                FechaInicio = Convert.ToDateTime(lector["FechaInicio"]),
                                FechaFin = Convert.ToDateTime(lector["FechaFin"]),
                                IdProfesor = (int)lector["IdProfesor"],
                                NombreProfesor = lector["NombreProfesor"].ToString(),


                            };
                        }
                        return null;
                    }
                }
            }
        }

        public string Actualizar(curso_model curso)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string query = "UPDATE Curso SET NombreCurso = @NombreCurso, Descripcion = @Descripcion, " +
                               "FechaInicio = @FechaInicio, FechaFin = @FechaFin, IdProfesor = @IdProfesor " +
                               "WHERE IdCurso = @IdCurso";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@NombreCurso", curso.NombreCurso);
                    comando.Parameters.AddWithValue("@Descripcion", curso.Descripcion);
                    comando.Parameters.AddWithValue("@FechaInicio", curso.FechaInicio);
                    comando.Parameters.AddWithValue("@FechaFin", curso.FechaFin);
                    comando.Parameters.AddWithValue("@IdProfesor", curso.IdProfesor);
                    comando.Parameters.AddWithValue("@IdCurso", curso.IdCurso);

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
                string query = "DELETE FROM Curso WHERE IdCurso = @IdCurso";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdCurso", id);
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

        public List<curso_model> Buscar(string texto)
        {
            var listaCursos = new List<curso_model>();
            using (var conexion = cn.obtenerConexion())
            {
                string query = "SELECT * FROM vistaCursoConProfesor WHERE NombreCurso LIKE @Texto";
                //string query = "SELECT * FROM curso WHERE NombreCurso LIKE @Texto";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaCursos.Add(new curso_model
                            {
                                IdCurso = (int)lector["IdCurso"],
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Descripcion = lector["Descripcion"].ToString(),
                                FechaInicio = Convert.ToDateTime(lector["FechaInicio"]),
                                FechaFin = Convert.ToDateTime(lector["FechaFin"]),
                                IdProfesor = (int)lector["IdProfesor"],
                                NombreProfesor = lector["NombreProfesor"].ToString(),
                            });
                        }
                    }
                }
            }
            return listaCursos;
        }
    }
}
