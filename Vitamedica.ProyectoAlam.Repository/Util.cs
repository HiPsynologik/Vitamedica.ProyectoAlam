using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitamedica.ProyectoAlam.Repository
{
    public static class ConnectionUtil
    {
        public static readonly string CnnStringSql = ConfigurationManager.ConnectionStrings["CnnStringSql"].ConnectionString;
    }

    public static class SQLUtil
    {

    }
}
