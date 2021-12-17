using System;
using System.Collections.Generic;
using Vitamedica.Base.Factory;
using Vitamedica.ProyectoAlam.IDomain;
using Vitamedica.ProyectoAlam.IRepository;
using Vitamedica.ProyectoAlam.Model.ViewModels;

namespace Vitamedica.ProyectoAlam.Domain
{
    public class PersonasDomain : IPersonasDomain
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<PersonaViewModel> ObtenerPersonas()
        {
            List<PersonaViewModel> model = new List<PersonaViewModel>();

            using (IPersonasRepository repository = FactoryEngine<IPersonasRepository>.GetInstance("IPersonasRepository"))
            {
                model = repository.ObtenerPersonas();
            }

            return model;
        }
    }
}
