using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll() //Action Method
        {
            ML.Result resultMateria = new ML.Result();
            resultMateria.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6803/api/");

                var responseTask = client.GetAsync("Materia/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        resultMateria.Objects.Add(resultItemList);
                    }

                }
            }
            ML.Materia materia = new ML.Materia();
            materia.Materias = resultMateria.Objects;
            return View(materia);//Mandar a llamar a la vista, mostrar la vista(HTML)
        }
        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            ML.Result resultmateria = BL.Materia.GetAll();

            if (IdMateria == null)
            {
                return View(materia);
            }
            else //esto es para el update
            {
                ML.Result result = new ML.Result();
                using (var client = new HttpClient())
                    try
                    {
                        client.BaseAddress = new Uri("http://localhost:6803/api/");
                        var responseTask = client.GetAsync("Materia/GetById/" + IdMateria);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Materia resultItemList = new ML.Materia();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            materia = ((ML.Materia)result.Object);
                            materia.Materias = resultmateria.Objects;
                            return View(materia);

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla ";
                            return View("Modal");
                        }
                    }

                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                    }

                return View();
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            if (ModelState.IsValid)
            {
                if (materia.IdMateria == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:6803/api/");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                        postTask.Wait();

                        var resultAseguradora = postTask.Result;
                        if (resultAseguradora.IsSuccessStatusCode)
                        {
                            ViewBag.Mensaje = "La materia se registro correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "La materia no se ha registrado correctamente" + result.ErrorMessage;
                          
                        }
                    }
                }
            }
            
            else
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:6803/api/");


                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Update/" + materia.IdMateria, materia);
                    postTask.Wait();

                    var resultmateria = postTask.Result;

                    if (resultmateria.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "La materia se ha actualizado correctamente";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "La materia no se ha actualizado correctamente" + result.ErrorMessage;
                        return PartialView("Modal");
                    }
                }


            }

            return PartialView("Modal");
        }
        public ActionResult Delete(ML.Materia materia)
        {

            ML.Result resultmateria = new ML.Result();
            int IdMateria = materia.IdMateria;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6803/api/");

                //HTTP POST
                var postTask = client.GetAsync("Materia/Delete/" + IdMateria);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "La materia ha sido eliminada";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "La materia no pudo ser eliminada" + resultmateria.ErrorMessage;
                    return View("Modal");
                }
            }

            return View();
        }
    }
}