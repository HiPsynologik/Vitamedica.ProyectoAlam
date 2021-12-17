using System;
using System.Collections.Generic;
using Vitamedica.Base.DataBase.DbServer;
using Vitamedica.ProyectoAlam.IRepository;
using Vitamedica.ProyectoAlam.Model.ViewModels;
using Vitamedica.ProyectoAlam.Repository.StoredProcedure;

namespace Vitamedica.ProyectoAlam.Repository
{
    public class PersonasRepository : IPersonasRepository
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<PersonaViewModel> ObtenerPersonas()
        {
            List<PersonaViewModel> model = new List<PersonaViewModel>();
            //List<DbParameterItem> parameters = new List<DbParameterItem>();

            using (SqlDbHelper helper = new SqlDbHelper(ConnectionUtil.CnnStringSql))
            {
                var reader = helper.ExecuteReader(SP.SP_CONSULTA_PERSONAS);
                while(reader.Read())
                {
                    model.Add(new PersonaViewModel()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("Id")),
                        nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        apellidoPaterno = reader.GetString(reader.GetOrdinal("ApellidoPaterno")),
                        apellidoMaterno = reader.GetString(reader.GetOrdinal("ApellidoMaterno")),
                        telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                    });
                }
                reader.Close();
            }

            return model;
        }
    }
}
