using EC.CPLA.DELTA.CD.Model.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EC.CPLA.DELTA.CD.Repository.Utilities
{
    public class SqlUtilities
    {
        private SqlConnection connection;

        public SqlUtilities(SqlConnection sqlconnection)
        {
             connection = sqlconnection;           
        }

        public DataSet GetDataSet(string StoredProcedureName, List<CommandParameter> Parameters = null)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedureName, connection);               
            if (Parameters != null)
            {
                foreach (var parameter in Parameters)
                {
                    cmd.Parameters.Add(parameter.Name, parameter.Type).Value = parameter.Value;
                }
            }
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);               
            
            return ds;
        }

        public void ExecuteNonQuery(string StoredProcedureName, List<CommandParameter> Parameters = null)
        {
            try
            {
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand(StoredProcedureName, connection);
                if (Parameters != null)
                {
                    foreach (var parameter in Parameters)
                    {
                        cmd.Parameters.Add(parameter.Name, parameter.Type).Value = parameter.Value;
                    }
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }            
            finally
            {
                connection.Close();
            }
        }

        public void LogExceptionToDB(LogType LogTypeId, string Message, string StackTrace)
        {            
            List<CommandParameter> param = new List<CommandParameter>() {
                    new CommandParameter(){Name="LogTypeId", Type = SqlDbType.TinyInt, Value = (int)LogTypeId},
                    new CommandParameter(){Name="Message", Type = SqlDbType.VarChar, Value = Message},
                    new CommandParameter(){Name="StackTrace", Type = SqlDbType.VarChar, Value = StackTrace}
                };
            ExecuteNonQuery("LogException", param);
        }
    }
   
}
public class CommandParameter
{
    public String Name;
    public SqlDbType Type;
    public object Value;
}
