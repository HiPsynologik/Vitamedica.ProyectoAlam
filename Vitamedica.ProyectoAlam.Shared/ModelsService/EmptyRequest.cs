using System.Runtime.Serialization;
using Vitamedica.ProyectoAlam.Shared.Models;

namespace Vitamedica.ProyectoAlam.Shared.ModelsService
{
    [DataContract]
    public class EmptyRequest
    {
        [DataMember]
        public object Param { get; set; }

        [DataMember]
        public TipoParametro TipoDato { get; set; }
    }
}