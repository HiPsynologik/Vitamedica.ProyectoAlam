using System.Runtime.Serialization;

namespace Vitamedica.ProyectoAlam.Model.ViewModels
{
    [DataContract]
    public class PersonaViewModel
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string apellidoPaterno { get; set; }

        [DataMember]
        public string apellidoMaterno { get; set; }

        [DataMember]
        public string telefono { get; set; }
    }
}
