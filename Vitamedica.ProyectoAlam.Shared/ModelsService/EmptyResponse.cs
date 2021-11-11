using System.Collections.Generic;
using System.Runtime.Serialization;
using Vitamedica.ProyectoAlam.Shared.Models;

namespace Vitamedica.ProyectoAlam.Shared.ModelsService
{
    [DataContract]
    public class EmptyResponse
    {
        [DataMember]
        public List<ErrorMessage> ErrorList { get; set; }

        [DataMember]
        public bool ValidExecution { get; set; }

        [DataMember]
        public object Result { get; set; }

        [DataMember]
        public TipoParametro TipoDato { get; set; }
    }
}