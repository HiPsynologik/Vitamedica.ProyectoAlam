using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitamedica.ProyectoAlam.Shared.DbServer
{
    public sealed class OleDbHelper : IDisposable
    {
        public void Dispose()
        {
            oleDBConnection.Close();
            oleDBConnection.Dispose();
            GC.SuppressFinalize(this);
        }

        private OleDbConnection oleDBConnection;

        public OleDbHelper(string ConnectionStringOleDb)
        {
            oleDBConnection = new OleDbConnection(ConnectionStringOleDb);
            oleDBConnection.Open();
        }

        public OleDbDataReader ExecuteReader(string StoredProcedureName)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;

            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = oleDBConnection;
            reader = cmd.ExecuteReader();

            return reader;
        }

        public OleDbDataReader ExecuteReader(string StoredProcedureName, List<DbParameterItem> parameter)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;

            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = oleDBConnection;
            if (parameter.Count > 0)
            {
                foreach (var item in parameter)
                    cmd.Parameters.AddWithValue(item.ParameterNameSP, item.Value);
            }

            reader = cmd.ExecuteReader();

            return reader;
        }

        public object ExecuteNonQuery(string StoreProcedureName, List<DbParameterItem> parameter)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbParameter returnParameter = new OleDbParameter();
            cmd.CommandText = StoreProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = oleDBConnection;
            if (parameter.Count > 0)
            {
                foreach (var item in parameter)
                {
                    if (item.ParameterDirection.Equals(ParameterDirection.ReturnValue))
                    {
                        returnParameter = cmd.Parameters.AddWithValue(item.ParameterNameSP, item.Value);
                        returnParameter.Direction = item.ParameterDirection;
                    }
                    else
                        cmd.Parameters.AddWithValue(item.ParameterNameSP, item.Value);
                }
            }

            cmd.ExecuteNonQuery();

            return returnParameter.Value;
        }
    }
}