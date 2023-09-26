using Megazy.StarterKit.Engine.Dal;
//using Megazy.StarterKit.Engine.Dal.CommonProvide;
using System;
using System.Data;

namespace Megazy.StarterKit.Engine
{
    public class SkStepUpDB_Base
    {
        //Add By Ae+
        public IDbCommand cmd = null;
        public int processID = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkStepUpDB_Base"/> 
        /// class and opens the database connection.
        /// </summary>
        protected SkStepUpDB_Base() //: this(true)
        {
            // EMPTY
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkStepUpDB_Base"/> class.
        /// </summary>
        /// <param name="init">Specifies whether the constructor calls the
        /// <see cref="InitConnection"/> method to initialize the database connection.</param>
        /*
        protected SkStepUpDB_Base(bool init)
        {
            //Edit By Ae+
        }
        */

        /// <summary>
        /// Returns a SQL statement parameter name that is specific for the data provider.
        /// For example it returns ? for OleDb provider, or @paramName for MS SQL provider.
        /// </summary>
        /// <param name="paramName">The data provider neutral SQL parameter name.</param>
        /// <returns>The SQL statement parameter name.</returns>
        //public abstract  string CreateSqlParameterName(string paramName);

        /// <summary>
        /// Creates <see cref="System.Data.IDataReader"/> for the specified DB command.
        /// </summary>
        /// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
        /// <returns>A reference to the <see cref="System.Data.IDataReader"/> object.</returns>
        public IDataReader ExecuteReader(IDbCommand command)
        {
            return command.ExecuteReader();
        }


        /// <summary>
        /// Creates a .Net data provider specific name that is used by the 
        /// <see cref="AddParameter"/> method.
        /// </summary>
        /// <param name="baseParamName">The base name of the parameter.</param>
        /// <returns>The full data provider specific parameter name.</returns>
        //protected abstract string CreateCollectionParameterName(string baseParamName);


        /// <summary>
        /// Creates and returns a new <see cref="System.Data.IDbCommand"/> object.
        /// </summary>
        /// <param name="sqlText">The text of the query.</param>
        /// <returns>An <see cref="System.Data.IDbCommand"/> object.</returns>
        public IDbCommand CreateCommand(string sqlText)
        {
            return CreateCommand(sqlText, false);
        }

        /// <summary>
        /// Creates and returns a new <see cref="System.Data.IDbCommand"/> object.
        /// </summary>
        /// <param name="sqlText">The text of the query.</param>
        /// <param name="procedure">Specifies whether the sqlText parameter is 
        /// the name of a stored procedure.</param>
        /// <returns>An <see cref="System.Data.IDbCommand"/> object.</returns>
        public IDbCommand CreateCommand(string sqlText, bool procedure)
        {
            DalBase dal = new DalBase();
            //Edit By Ae+

            cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlText;


            //InitCommand(cmd);
            //Update 051030 ต้องการเป็น Multi Tier
            if (processID != 0)
            {
                dal.InitCommand(processID, cmd);

            }
            else
            {
                //Exception ex = new Exception("processid = 0 " + sqlText);
                //throw ex;

                //dal.InitCommand(cmd);
               
                processID = CSystems.ProcessID;
                dal.InitCommand(processID, cmd);
               
            }
            

            if (procedure)
                cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        /// <summary>
        /// Rolls back any pending transactions and closes the DB connection.
        /// An application can call the <c>Close</c> method more than
        /// one time without generating an exception.
        /// </summary>
        public virtual void Close()
        {

            //Update 051030 ต้องการเป็น Multi Tier
            DalBase dal = new DalBase();
            if (processID != 0)
            {
                //ไปเรียก Dalbase
                dal.Close(processID, cmd);
            }
            else
            {
                //ไปเรียก Dalbase
                dal.Close(cmd);
            }
        }

    } // End of SkStepUpDB_Base class
}