using Megazy.StarterKit.Engine.Structure;
using Microsoft.Security.Application;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Megazy.StarterKit.Engine.Dal
{
    [Serializable]
    public partial class UserStatusCollection_Base : MarshalByRefObject
    {
        public const string UserStatusIDColumnName = "UserStatusID";
        public const string DescriptionColumnName = "Description";
        private int _processID;
        public SqlCommand cmd = null;
        public UserStatusCollection_Base(int intProcessID)
        {
            _processID = intProcessID;
        }
        public void Dispose()
        {
            Close();
        }
        public virtual UserStatusRow[] GetAll()
        {
            return MapRecords(CreateGetAllCommand());
        }
        public virtual DataTable GetAllAsDataTable()
        {
            return MapRecordsToDataTable(CreateGetAllCommand());
        }
        protected virtual IDbCommand CreateGetAllCommand()
        {
            return CreateGetCommand(null, null);
        }
        public int Delete(string whereSql)
        {
            return CreateDeleteCommand(whereSql).ExecuteNonQuery();
        }
        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "SELECT " +
            "[UserStatusID]," +
            "[Description]" +
            " FROM [dbo].[UserStatus]";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return CreateCommand(sql);
        }
        protected SqlCommand CreateDeleteCommand(string whereSql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "DELETE FROM [dbo].[UserStatus]";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            return CreateCommand(sql);
        }
        public DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable
            {
                TableName = "UserStatus"
            };
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("UserStatusID", Type.GetType("System.Int32"));
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("Description", Type.GetType("System.String"));
            dataColumn.MaxLength = 50;
            return dataTable;
        }
        public UserStatusRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }
        public virtual UserStatusRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
        {
            SqlCommand command = CreateGetCommand(whereSql, orderBySql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }
        /// <summary>
        /// Gets an array of <see cref="UserStatusRow"/> objects that
        /// match the search condition, in the the specified sort order.
        /// </summary>
        /// <param name="top">The Number of select top condition. For example: 
        /// <c>"10"</c>.</param>
        /// <param name="whereSql">The SQL search condition. For example: 
        /// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
        /// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
        /// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
        /// <returns>An array of <see cref="UserStatusRow"/> objects.</returns>
        public virtual UserStatusRow[] GetTopAsArray(int top, List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            int totalRecordCount = -1;
            if (top <= 0)
                top = 1;
            string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[UserStatus]", top);
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecords(reader, 0, top, ref totalRecordCount);
            }
        }
        public UserStatusRow GetRow(List<SqlParameter> sqlParameter, string whereSql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            int totalRecordCount = -1;
            UserStatusRow[] rows = null;
            SqlCommand command = CreateGetCommand(whereSql, "");
            command.Parameters.AddRange(sqlParameter.ToArray());
            using (IDataReader reader = ExecuteReader(command))
            {
                rows = MapRecords(reader, 0, 1, ref totalRecordCount);
            }
            return 0 == rows.Length ? null : rows[0];
        }
        public DataTable GetAsDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsDataTable(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }
        public DataTable GetAsDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
        {
            SqlCommand command = CreateGetCommand(whereSql, orderBySql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecordsToDataTable(reader, startIndex, length, ref totalRecordCount);
            }
        }
        /// <summary>
        /// เรียกข้อมูลในตารางมีคอลัมน์ทั้งหมดและเพิ่มเติมมี RowRank,totalRow,totalPage 
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="rowPerPage"></param>
        /// <param name="orderBySql"></param>
        /// <returns></returns>
        public DataTable GetUserStatusPagingAsDataTable(List<SqlParameter> sqlParameter, string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserStatusID")
        {
            AntiSqlInjection.CheckInput(whereSql);
            if (startRowIndex < 0)
                startRowIndex = 0;
            if (rowPerPage < 0)
                rowPerPage = 1;
            if (string.IsNullOrWhiteSpace(orderBySql))
                orderBySql = "UserStatusID";
            string whereCount = string.Empty;
            string wherePaging = string.Empty;
            if (null != whereSql && 0 < whereSql.Length)
            {
                whereCount = " WHERE " + whereSql;
                wherePaging = " AND " + whereSql;
                whereSql = " WHERE   " + whereSql;
            }
            string sql = "SELECT COUNT(UserStatusID) AS TotalRow FROM [dbo].[UserStatus] " + whereCount;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            command.Parameters.Clear();
            var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
            var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
            sql = " SELECT RowRank,UserStatusID,Description," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
            " FROM (SELECT [UserStatus].*, " +
            " ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
            " FROM [dbo].[UserStatus] " + whereSql +
            " ) AS AllWithRowRank " +
            "  WHERE RowRank >" + startRowIndex + "  AND RowRank  <= " + (startRowIndex + rowPerPage) + wherePaging;
            command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            dt = CreateDataTable(command);
            return dt;
        }
        /// <summary>
        /// เรียกข้อมูลในตารางมีคอลัมน์ทั้งหมดและเพิ่มเติมมี RowRank,totalRow,totalPage 
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="rowPerPage"></param>
        /// <param name="orderBySql"></param>
        /// <returns></returns>
        public UserStatusItemsPaging GetUserStatusPagingAsArray(List<SqlParameter> sqlParameter, string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserStatusID")
        {
            UserStatusItemsPaging obj = new UserStatusItemsPaging();
            DataTable dt = GetUserStatusPagingAsDataTable(sqlParameter, whereSql, startRowIndex, rowPerPage, orderBySql);
            if (dt.Rows.Count != 0)
            {
                obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
                obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
            }
            UserStatusItems record;
            ArrayList recordList = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                record = new UserStatusItems();
                record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
                record.UserStatusID = Convert.ToInt32(dt.Rows[i]["UserStatusID"]);
                record.Description = dt.Rows[i]["Description"].ToString();
                recordList.Add(record);
            }
            obj.userStatusItems = (UserStatusItems[])(recordList.ToArray(typeof(UserStatusItems)));
            return obj;
        }
        public UserStatusRow GetByPrimaryKey(int userStatusID)
        {
            string whereSql = "[UserStatusID]=" + CreateSqlParameterName("UserStatusID");
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "UserStatusID", userStatusID);
            UserStatusRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray[0];
        }
        public void Insert(UserStatusRow value)
        {
            string sqlStr = "INSERT INTO [dbo].[UserStatus] (" +
            "[UserStatusID], " +
            "[Description]			" +
            ") VALUES (" +
            CreateSqlParameterName("UserStatusID") + ", " +
            CreateSqlParameterName("Description") + ")";
            IDbCommand cmd = CreateCommand(sqlStr);
            AddParameter(cmd, "UserStatusID", value.UserStatusID);
            AddParameter(cmd, "Description", value.Description);
            cmd.ExecuteNonQuery();
        }
        public void InsertOnlyPlainText(UserStatusRow value)
        {
            string sqlStr = "INSERT INTO [dbo].[UserStatus] (" +
            "[UserStatusID], " +
            "[Description]			" +
            ") VALUES (" +
            CreateSqlParameterName("UserStatusID") + ", " +
            CreateSqlParameterName("Description") + ")";
            IDbCommand cmd = CreateCommand(sqlStr);
            AddParameter(cmd, "UserStatusID", value.UserStatusID);
            AddParameter(cmd, "Description", Sanitizer.GetSafeHtmlFragment(value.Description));
            cmd.ExecuteNonQuery();
        }
        public bool Update(UserStatusRow value)
        {
            IDbCommand cmd = null;
            if (value._IsSetUserStatusID == true)
            {
                string strUpdate = string.Empty;
                if (value._IsSetDescription)
                {
                    strUpdate += "[Description]=" + CreateSqlParameterName("Description") + ",";
                }
                if (strUpdate != string.Empty)
                {
                    strUpdate = strUpdate.Remove(strUpdate.Length - 1);
                    strUpdate = "UPDATE [dbo].[UserStatus] SET " + strUpdate;
                    strUpdate += " WHERE ";
                    strUpdate += "[UserStatusID]=" + CreateSqlParameterName("UserStatusID");

                    cmd = CreateCommand(strUpdate);
                    AddParameter(cmd, "UserStatusID", value.UserStatusID);
                    AddParameter(cmd, "Description", value.Description);
                }
                else
                {
                    Exception ex = new Exception("Set at least 1 value");
                    throw ex;
                }
            }
            else
            {
                Exception ex = new Exception("Set incorrect primarykey PK(UserStatusID)");
                throw ex;
            }
            int rt = cmd.ExecuteNonQuery();
            return 0 != rt;
        }
        public bool UpdateOnlyPlainText(UserStatusRow value)
        {
            IDbCommand cmd = null;
            if (value._IsSetUserStatusID == true)
            {
                string strUpdate = string.Empty;
                if (value._IsSetDescription)
                {
                    strUpdate += "[Description]=" + CreateSqlParameterName("Description") + ",";
                }
                if (strUpdate != string.Empty)
                {
                    strUpdate = strUpdate.Remove(strUpdate.Length - 1);
                    strUpdate = "UPDATE [dbo].[UserStatus] SET " + strUpdate;
                    strUpdate += " WHERE ";
                    strUpdate += "[UserStatusID]=" + CreateSqlParameterName("UserStatusID");

                    cmd = CreateCommand(strUpdate);
                    AddParameter(cmd, "UserStatusID", value.UserStatusID);
                    AddParameter(cmd, "Description", Sanitizer.GetSafeHtmlFragment(value.Description));
                }
                else
                {
                    Exception ex = new Exception("Set at least 1 value");
                    throw ex;
                }
            }
            else
            {
                Exception ex = new Exception("Set incorrect primarykey PK(UserStatusID)");
                throw ex;
            }
            int rt = cmd.ExecuteNonQuery();
            return 0 != rt;
        }
        public bool DeleteByPrimaryKey(int userStatusID)
        {
            string whereSql = "[UserStatusID]=" + CreateSqlParameterName("UserStatusID");
            IDbCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "UserStatusID", userStatusID);
            return 0 < cmd.ExecuteNonQuery();
        }
        protected UserStatusRow[] MapRecords(IDbCommand command)
        {
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecords(reader);
            }
        }
        protected UserStatusRow[] MapRecords(IDataReader reader)
        {
            int totalRecordCount = -1;
            return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
        }
        protected UserStatusRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int userStatusIDColumnIndex = reader.GetOrdinal("UserStatusID");
            int descriptionColumnIndex = reader.GetOrdinal("Description");
            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            int countRecordRow = 0;
            while (reader.Read())
            {
                countRecordRow++;
                ri++;
                if (ri > 0 && ri <= length)
                {
                    UserStatusRow record = new UserStatusRow();
                    recordList.Add(record);
                    record.UserStatusID = Convert.ToInt32(reader.GetValue(userStatusIDColumnIndex));
                    if (!reader.IsDBNull(descriptionColumnIndex)) record.Description = Convert.ToString(reader.GetValue(descriptionColumnIndex));

                    if (ri == length && 0 != totalRecordCount)
                        break;
                }
            }
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (UserStatusRow[])(recordList.ToArray(typeof(UserStatusRow)));
        }
        protected DataTable MapRecordsToDataTable(IDbCommand command)
        {
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecordsToDataTable(reader);
            }
        }
        protected DataTable MapRecordsToDataTable(IDataReader reader)
        {
            int totalRecordCount = 0;
            return MapRecordsToDataTable(reader, 0, int.MaxValue, ref totalRecordCount);
        }
        protected virtual DataTable MapRecordsToDataTable(IDataReader reader, int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int columnCount = reader.FieldCount;
            int ri = -startIndex;
            DataTable dataTable = CreateDataTable();
            dataTable.BeginLoadData();
            object[] values = new object[columnCount];
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    reader.GetValues(values);
                    dataTable.LoadDataRow(values, true);
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }
            }
            dataTable.EndLoadData();
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return dataTable;
        }
        protected virtual IDbDataParameter AddParameter(IDbCommand cmd, string paramName, object value)
        {
            IDbDataParameter parameter;
            switch (paramName)
            {
                case "UserStatusID":
                    parameter = AddParameter(cmd, paramName, DbType.Int32, value);
                    break;
                case "Description":
                    parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
                    break;
                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
        public IDataReader ExecuteReader(IDbCommand command)
        {
            return command.ExecuteReader();
        }
        public SqlCommand CreateCommand(string sqlText)
        {
            return CreateCommand(sqlText, false);
        }
        private SqlCommand CreateCommand(string sqlText, bool procedure)
        {
            DalBase dal = new DalBase();
            cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlText;
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
        public DataTable CreateDataTable(IDbCommand command)
        {
            DataTable dataTable = new DataTable();
            new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command).Fill(dataTable);
            return dataTable;
        }
        private string CreateSqlParameterName(string paramName)
        {
            return "@" + paramName;
        }
        private string CreateCollectionParameterName(string baseParamName)
        {
            return "@" + baseParamName;
        }
        private string CreateGEOMETRYSqlParameterName(string paramName, string gemetry = "geometry::STGeomFromText({0},4326)")
        {
            return string.Format(gemetry, "@" + paramName);
        }
        private IDbDataParameter AddParameter(IDbCommand cmd, string paramName, DbType dbType, object value)
        {
            IDbDataParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = CreateCollectionParameterName(paramName);
            parameter.DbType = dbType;
            parameter.Value = null == value ? DBNull.Value : value;
            cmd.Parameters.Add(parameter);
            return parameter;
        }
        private IDbDataParameter AddParameters(IDbCommand cmd, string paramName, SqlDbType dbType, object value)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = CreateCollectionParameterName(paramName);
            parameter.SqlDbType = dbType;
            parameter.Value = null == value ? DBNull.Value : value;
            cmd.Parameters.Add(parameter);
            return parameter;
        }
    }
}
