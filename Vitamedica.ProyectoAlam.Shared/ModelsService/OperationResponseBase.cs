using System.Collections.Generic;
using Vitamedica.ProyectoAlam.Shared.Models;

namespace Vitamedica.ProyectoAlam.Shared.ModelsService
{
    public class OperationResponseBase<T>
    {
        public List<ErrorMessage> ErrorList { get; set; }

        public bool ValidExecution { get; set; }

        public T Item { get; set; }
    }
}