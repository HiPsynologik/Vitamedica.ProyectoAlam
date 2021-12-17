using System;
using System.Collections.Generic;
using Vitamedica.ProyectoAlam.Model.ViewModels;

namespace Vitamedica.ProyectoAlam.IDomain
{
    public interface IPersonasDomain : IDisposable
    {
        List<PersonaViewModel> ObtenerPersonas();
    }
}
