using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumno" in both code and config file together.
    [ServiceContract]
    public interface IAlumno
    {

        [OperationContract]
        SLWCF1.Result Add(ML.Alumno alumno);

        [OperationContract]
        SLWCF1.Result Delete(ML.Alumno alumno);

        [OperationContract]
        SLWCF1.Result Update(ML.Alumno alumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SLWCF1.Result GetById(int IdAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SLWCF1.Result GetAll();
    }
}
