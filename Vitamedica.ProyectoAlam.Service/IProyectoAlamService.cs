using System.ServiceModel;

namespace Vitamedica.ProyectoAlam.Service
{
    [ServiceContract]
    public interface IProyectoAlamService
    {
        [OperationContract]
        string MuestraPalabara(string palabra);
    }
}
