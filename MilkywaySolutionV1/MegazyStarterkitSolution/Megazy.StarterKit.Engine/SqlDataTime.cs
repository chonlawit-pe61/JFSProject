using System.Data;
using System.Data.SqlClient;

namespace Megazy.StarterKit.Engine
{

    public class SqlDataTime
    {
        private int _processID;
        public SqlCommand cmd = null;
        private SqlCommand CreateCommand(string sqlText, bool procedure)
        {
            DalBase dal = new DalBase();
            cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlText;
            //Edit By Ae+ Update 051030 Multi Tier
            if (_processID != 0)
            {
                dal.InitCommand(_processID, cmd);
            }
            else
            {
                _processID = CSystems.ProcessID;
                dal.InitCommand(_processID, cmd);
            }
            if (procedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            return cmd;
        }
        public void ProcessID(int intProcessID)
        {
            _processID = intProcessID;
        }
        public SqlDataTime()
        {

        }
        public void Dispose()
        {
            Close();
        }
        private void Close()
        {
            DalBase dal = new DalBase();
            if (_processID != 0)
            {
                dal.Close(_processID, cmd);
            }
            else
            {
                dal.Close(cmd);
            }
        }
        public DataTable CreateDataTable(string sqlInput)
        {
            DataTable dataTable = new DataTable();
            new System.Data.SqlClient.SqlDataAdapter(CreateCommand(sqlInput,false)).Fill(dataTable);
            return dataTable;
        }
    }
}