using Vitamedica.ProyectoAlam.Shared.Models;

namespace Vitamedica.ProyectoAlam.Shared.ModelsService
{
    public class FilterRequestBase<T>
    {
        public bool RequiredPagination { get; set; }

        public Pagination pagination { get; set; }

        public T Item { get; set; }
    }
}