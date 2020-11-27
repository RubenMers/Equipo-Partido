using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Saludar(string nombre);


        [OperationContract]
        Result GetAll();

        [OperationContract]
        Result Add(ML.Jugador jugador);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Result
    {

        [DataMember]
        public Exception Ex { get; set; }

        [DataMember]

        public bool Correct { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public object Object { get; set; }

        public List<object> Objects { get; set; }
    }
}
