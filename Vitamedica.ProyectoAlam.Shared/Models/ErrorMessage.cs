using System.Runtime.Serialization;

namespace Vitamedica.ProyectoAlam.Shared.Models
{
    [DataContract]
    public class ErrorMessage
    {
        [DataMember]
        public string Description { get; set; }
    }
}