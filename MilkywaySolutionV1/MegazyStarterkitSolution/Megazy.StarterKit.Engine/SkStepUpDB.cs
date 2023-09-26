using System;
using System.Data;

namespace Megazy.StarterKit.Engine
{

    public class SkStepUpDB : SkStepUpDB_Base
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkStepUpDB"/> class.
        /// </summary>
        public SkStepUpDB()
        {
            // EMPTY
        }
        /// <summary>
        /// Creates a DataTable object for the specified command.
        /// </summary>
        /// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        public DataTable CreateDataTable(IDbCommand command)
        {
            DataTable dataTable = new DataTable();
            //Update by AE+
            new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command).Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Returns a SQL statement parameter name that is specific for the data provider.
        /// For example it returns ? for OleDb provider, or @paramName for MS SQL provider.
        /// </summary>
        /// <param name="paramName">The data provider neutral SQL parameter name.</param>
        /// <returns>The SQL statement parameter name.</returns>
        public string CreateSqlParameterName(string paramName)
        {
            return "@" + paramName;
        }

        /// <summary>
        /// Creates a .Net data provider specific parameter name that is used to
        /// create a parameter object and add it to the parameter collection of
        /// <see cref="System.Data.IDbCommand"/>.
        /// </summary>
        /// <param name="baseParamName">The base name of the parameter.</param>
        /// <returns>The full data provider specific parameter name.</returns>
        protected string CreateCollectionParameterName(string baseParamName)
        {
            return "@" + baseParamName;
        }
        /// <summary>
        /// Adds a new parameter to the specified command. It is not recommended that 
        /// you use this method directly from your custom code. Instead use the 
        /// <c>AddParameter</c> method of the &lt;TableCodeName&gt;Collection_Base classes.
        /// </summary>
        /// <param name="cmd">The <see cref="System.Data.IDbCommand"/> object to add the parameter to.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="dbType">One of the <see cref="System.Data.DbType"/> values. </param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to the added parameter.</returns>
        public IDbDataParameter AddParameter(IDbCommand cmd, string paramName,
            DbType dbType, object value)
        {
            IDbDataParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = CreateCollectionParameterName(paramName);
            parameter.DbType = dbType;
            parameter.Value = null == value ? DBNull.Value : value;
            cmd.Parameters.Add(parameter);
            return parameter;
        }
    }
}