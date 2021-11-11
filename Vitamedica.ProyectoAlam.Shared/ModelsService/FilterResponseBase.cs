using System.Collections.Generic;
using Vitamedica.ProyectoAlam.Shared.Models;

namespace Vitamedica.ProyectoAlam.Shared.ModelsService
{
    public class FilterResponseBase<T>
    {
        public List<ErrorMessage> ErrorList { get; set; }

        public List<T> List { get; set; }

        public bool ValidExecution { get; set; }

        public Pagination pagination { get; set; }
    }
}