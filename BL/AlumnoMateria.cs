using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LGracidaDIGIPROEntities1 context = new DL.LGracidaDIGIPROEntities1())
                {
                    var alumnos = context.AlumnoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (alumnos != null)
                    {
                        foreach (var obj in alumnos)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(alumno);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetMateriaAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LGracidaDIGIPROEntities1 context = new DL.LGracidaDIGIPROEntities1())
                {
                    var query = context.AlumnoGetMateriaAsignada(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                            alumnomateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnomateria.materia = new ML.Materia();
                            alumnomateria.materia.Nombre = obj.Nombre;

                            alumnomateria.alumno = new ML.Alumno();
                            alumnomateria.alumno.IdAlumno = obj.IdAlumno;

                            result.Objects.Add(alumnomateria);
                            result.Correct = true;
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LGracidaDIGIPROEntities1 context = new DL.LGracidaDIGIPROEntities1())
                {
                    var query = context.AlumnoMateriaDelete(alumnomateria.IdAlumnoMateria);

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el delete";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LGracidaDIGIPROEntities1 context = new DL.LGracidaDIGIPROEntities1())
                {
                    var query = context.AlumnoMateriaAdd(alumnomateria.alumno.IdAlumno, alumnomateria.materia.IdMateria);
                    {
                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ha podido realizar el insert";
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetMateriaNoAsiganda(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LGracidaDIGIPROEntities1 context = new DL.LGracidaDIGIPROEntities1())
                {
                    var query = context.AlumnoGetMateriaNoAsignada(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

                            alumnomateria.materia = new ML.Materia();
                            alumnomateria.materia.IdMateria = obj.IdMateria;
                            alumnomateria.materia.Nombre = obj.Nombre;
                            alumnomateria.materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnomateria);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}