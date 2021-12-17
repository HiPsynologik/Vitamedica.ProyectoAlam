using System;
using System.Collections.Generic;
using Vitamedica.ProyectoAlam.Model.ViewModels;

namespace Vitamedica.ProyectoAlam.IRepository
{
    public interface IPersonasRepository : IDisposable
    {
        List<PersonaViewModel> ObtenerPersonas();
    }
}
