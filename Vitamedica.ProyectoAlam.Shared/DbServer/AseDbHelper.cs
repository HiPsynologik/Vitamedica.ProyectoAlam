using Sybase.Data.AseClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Vitamedica.ProyectoAlam.Shared.DbServer
{
    public sealed class AseDbHelper : IDisposable
    {
        public void Dispose()
        {
            AseDBConnection.Close();
            AseDBConnection.Dispose();
            AseDBConnection.ClearPool();
            AseDBConnection = null;
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        private AseConnection AseDBConnection;

        public AseDbHelper(string ConnectionStringAseDb)
        {
            AseDBConnection = new AseConnection(ConnectionStringAseDb);
            AseDBConnection.Open();
        }

        public AseDataReader ExecuteReader(string StoredProcedureName)
        {
            AseCommand cmd = new AseCommand();
            AseDataReader reader;

            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = AseDBConnection;
            reader = cmd.ExecuteReader();

            return reader;
        }

        public AseDataReader ExecuteReader(string StoredProcedureName, List<DbParameterItem> parameter)
        {
            AseCommand cmd = new AseCommand();
            AseDataReader reader;

            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = AseDBConnection;
            if (parameter.Count > 0)
            {
                foreach (var item in parameter)
                    cmd.Parameters.AddWithValue(item.ParameterNameSP, item.Value);
            }
            cmd.CommandTimeout = 120;

            reader = cmd.ExecuteReader();

            return reader;
        }

        public object ExecuteNonQuery(string StoreProcedureName, List<DbParameterItem> parameter)
        {
            AseCommand cmd = new AseCommand();
            AseParameter returnParameter = new AseParameter();
            cmd.CommandText = StoreProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = AseDBConnection;
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

            cmd.CommandTimeout = 120;

            cmd.ExecuteNonQuery();

            return returnParameter.Value;
        }

        public void ExecuteNonQuery(string StoreProcedureName, ref List<DbParameterItem> parameter)
        {
            AseCommand cmd = new AseCommand();
            List<AseParameter> listParameter = new List<AseParameter>();
            List<DbParameterItem> returnParameters = new List<DbParameterItem>();
            cmd.CommandText = StoreProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = AseDBConnection;
            if (parameter.Count > 0)
            {
                foreach (var item in parameter)
                {
                    if (item.ParameterDirection.Equals(ParameterDirection.Output) && item.Size != 0)
                        listParameter.Add(new AseParameter()
                        {
                            ParameterName = item.ParameterNameSP,
                            Value = item.Value,
                            Direction = item.ParameterDirection,
                            Size = item.Size,
                            DbType = item.DbType
                        });
                    else if (item.ParameterDirection.Equals(ParameterDirection.ReturnValue))
                        listParameter.Add(new AseParameter()
                        {
                            ParameterName = item.ParameterNameSP,
                            Value = item.Value,
                            Direction = item.ParameterDirection,
                        });
                    else
                        listParameter.Add(new AseParameter()
                        {
                            ParameterName = item.ParameterNameSP,
                            Value = item.Value,
                        });
                }
                cmd.Parameters.AddRange(listParameter.ToArray());
            }

            cmd.CommandTimeout = 120;

            cmd.ExecuteNonQuery();

            foreach (var itemReturn in listParameter)
                returnParameters.Add(new DbParameterItem(
                    itemReturn.ParameterName
                    , itemReturn.Value
                    , itemReturn.Direction
                    , itemReturn.Size
                    , itemReturn.DbType));

            parameter = returnParameters;
        }
    }
}