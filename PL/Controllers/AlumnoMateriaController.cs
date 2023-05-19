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
            ML.Result result = BL.AlumnoMateria.GetAll();

            alumno.Alumnos = result.Objects;
            return View(alumno);
        }
        [HttpGet]
        public ActionResult GetMateriaAsignada(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriaAsignada(IdAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alunmo.GetById(IdAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }

        
        [HttpPost]
        public ActionResult GetMateriaAsignada(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            if (alumnomateria.AlumnoMaterias != null)
            {
                foreach (string IdAlumnoMateria in alumnomateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

                    alumnomateriaItem.IdAlumnoMateria = int.Parse(IdAlumnoMateria);

                    ML.Result resultDelete = BL.AlumnoMateria.Delete(alumnomateriaItem);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizado las materias del alumno";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnomateria.alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult GetMateriaSinAsignar(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriaNoAsiganda(IdAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alunmo.GetById(IdAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }
        [HttpPost]

        public ActionResult GetMateriaSinAsignar(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            if (alumnomateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnomateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

                    alumnomateriaItem.alumno = new ML.Alumno();
                    alumnomateriaItem.alumno.IdAlumno = alumnomateria.alumno.IdAlumno;

                    alumnomateriaItem.materia = new ML.Materia();
                    alumnomateriaItem.materia.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.Add(alumnomateriaItem);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizado al alumno";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnomateria.alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }
    }
    }