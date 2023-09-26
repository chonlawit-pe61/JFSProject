namespace Megazy.StarterKit.Mvc
{
    public class SqlDataTime
    {
        private int _processID;
        public System.Data.SqlClient.SqlCommand cmd = null;
        private System.Data.SqlClient.SqlCommand CreateCommand(string sqlText, bool procedure)
        {
            DalBase dal = new DalBase();
            cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
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
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
        public System.Data.DataTable CreateDataTable(string sqlInput)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            new System.Data.SqlClient.SqlDataAdapter(CreateCommand(sqlInput, false)).Fill(dataTable);
            return dataTable;
        }
    }
}