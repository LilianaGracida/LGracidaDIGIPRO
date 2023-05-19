using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        
        public ActionResult GetAll() //Action Method
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alunmo.GetAll();

            alumno.Alumnos = result.Objects;

            return View(alumno);
        }
        public ActionResult GetMateriaAsignada(int idAlumno)
        {

            ML.Result result = BL.AlumnoMateria.GetMateriaAsignada(idAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alunmo.GetById(idAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }
    }
}