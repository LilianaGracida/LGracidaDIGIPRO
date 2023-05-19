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
                            ML.Alumno alumno= new ML.Alumno();
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

        public static ML.Result GetMateriaAsignada(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LGracidaDIGIPROEntities1 context = new DL.LGracidaDIGIPROEntities1())
                {
                    var obj = context.AlumnoGetMateriaAsignada(idAlumno).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                        alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                        ML.Materia materia = new ML.Materia();
                        alumnoMateria.materia.IdMateria = obj.IdMateria;
                        alumnoMateria.materia.Nombre = obj.Nombre;
                        
                        result.Object = alumnoMateria;
                        result.Correct = true;

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
