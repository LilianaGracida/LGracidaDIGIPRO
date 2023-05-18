using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumno" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumno.svc or Alumno.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        public SLWCF1.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alunmo.Add(alumno);
            return new SLWCF1.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWCF1.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alunmo.Delete(alumno);
            return new SLWCF1.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWCF1.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alunmo.Update(alumno);
            return new SLWCF1.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWCF1.Result GetAll()
        {

            ML.Result result = new ML.Result();
            result = BL.Alunmo.GetAll();
            return new SLWCF1.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }



        public SLWCF1.Result GetById(int idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();


            ML.Result result = new ML.Result();
            result = BL.Alunmo.GetById(idAlumno);

            return new SLWCF1.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
