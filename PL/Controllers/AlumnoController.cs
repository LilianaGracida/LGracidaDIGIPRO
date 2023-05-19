using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        //[HttpGet] //Action VERB
        //public ActionResult GetAll() //Action Method
        //{
        //    ML.Alumno alumno = new ML.Alumno();
        //    ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();
        //    var result = servicioAlumno.GetAll();

        //    if (result.Correct)
        //    {
        //        alumno.Alumnos = result.Objects.ToList();
        //    }
        //    else
        //    {
        //        ViewBag.Mensaje = "Ocurrio un error al consultar";
        //        return View();
        //    }
        //    return View(alumno);//Mandar a llamar a la vista, mostrar la vista(HTML)
        //}
        //public ActionResult Delete(int idAlumno)
        //{
        //    ML.Alumno alumno = new ML.Alumno();
        //    alumno.IdAlumno = idAlumno;
        //    ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();

        //    var result = servicioAlumno.Delete(alumno);
        //    if (result.Correct)
        //    {

        //        ViewBag.Message = "El Alumno se elimino corectamente";
        //        return View("Modal");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "El Alumno no se pudo eliminar " + result.ErrorMessage;
        //        return View("Modal");
        //    }

        //}

        //[HttpGet]
        //public ActionResult Form(int? idAlumno)
        //{
        //    ML.Alumno alumno = new ML.Alumno();


        //    //add o update
        //    if (idAlumno == null)
        //    {
        //        return View(alumno);
        //    }

        //    else
        //    {
        //        //update
        //        //muestra el formulario con la informacion del alumno
        //        ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();
        //        var result = servicioAlumno.GetById(idAlumno.Value);
        //        if (result.Correct)
        //        {
        //            alumno = (ML.Alumno)result.Object;
        //            return View(alumno);
        //        }

        //        return View(alumno);
        //    }


        //}

        //[HttpPost]
        //public ActionResult Form(ML.Alumno alumno)
        //{
        //    //add o update
        //    if (alumno.IdAlumno == 0)
        //    {
        //        ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();
        //        var result = servicioAlumno.Add(alumno);
        //        //add
        //        if (result.Correct)
        //        {

        //            ViewBag.Message = "El Alumno se inserto con exito";
        //            return View("Modal");
        //        }
        //        else
        //        {

        //            ViewBag.Message = "Error al insertar el Alumno" + result.ErrorMessage;
        //            return View("Modal");
        //        }
        //    }
        //    else
        //    {
        //        ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();
        //        var result = servicioAlumno.Update(alumno);
        //        if (result.Correct)
        //        {
        //            ViewBag.Message = "Los datos del Alumno se actualizaron con exito";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Error al actualizar los datos del Alumno" + result.ErrorMessage;
        //        }

        //    }

        //    return View("Modal");
        //}
    }
}