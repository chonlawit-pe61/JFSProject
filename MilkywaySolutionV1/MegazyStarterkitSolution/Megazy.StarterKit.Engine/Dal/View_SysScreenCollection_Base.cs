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
    public partial class View_SysScreenCollection_Base : MarshalByRefObject
    {
        public const string ScreenIDColumnName = "ScreenID";
        public const string ModuleIDColumnName = "ModuleID";
        public const string ParentScreenIDColumnName = "ParentScreenID";
        public const string ScreenNameColumnName = "ScreenName";
        public const string ScreenTitleColumnName = "ScreenTitle";
        public const string SortOrderColumnName = "SortOrder";
        public const string IsActiveColumnName = "IsActive";
        public const string ModifiedDateColumnName = "ModifiedDate";
        public const string SubScreenColumnName = "SubScreen";
        private int _processID;
        public SqlCommand cmd = null;
        public View_SysScreenCollection_Base(int intProcessID)
        {
            _processID = intProcessID;
        }
        public void Dispose()
        {
            Close();
        }
        public virtual View_SysScreenRow[] GetAll()
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
        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            string sql = "SELECT " +
            "[ScreenID]," +
            "[ModuleID]," +
            "[ParentScreenID]," +
            "[ScreenName]," +
            "[ScreenTitle]," +
            "[SortOrder]," +
            "[IsActive]," +
            "[ModifiedDate]," +
            "[SubScreen]" +
            " FROM [dbo].[View_SysScreen]";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return CreateCommand(sql);
        }
        public DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable
            {
                TableName = "View_SysScreen"
            };
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("ScreenID", Type.GetType("System.Int32"));
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("ModuleID", Type.GetType("System.Int32"));
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("ParentScreenID", Type.GetType("System.Int32"));
            dataColumn = dataTable.Columns.Add("ScreenName", Type.GetType("System.String"));
            dataColumn.MaxLength = 50;
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("ScreenTitle", Type.GetType("System.String"));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("SortOrder", Type.GetType("System.Int32"));
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("IsActive", Type.GetType("System.Boolean"));
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("ModifiedDate", Type.GetType("System.DateTime"));
            dataColumn = dataTable.Columns.Add("SubScreen", Type.GetType("System.String"));
            dataColumn.MaxLength = 2147483647;
            return dataTable;
        }
        public View_SysScreenRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }
        public virtual View_SysScreenRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
        {
            SqlCommand command = CreateGetCommand(whereSql, orderBySql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }
        /// <summary>
        /// Gets an array of <see cref="View_SysScreenRow"/> objects that
        /// match the search condition, in the the specified sort order.
        /// </summary>
        /// <param name="top">The Number of select top condition. For example: 
        /// <c>"10"</c>.</param>
        /// <param name="whereSql">The SQL search condition. For example: 
        /// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
        /// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
        /// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
        /// <returns>An array of <see cref="View_SysScreenRow"/> objects.</returns>
        public virtual View_SysScreenRow[] GetTopAsArray(int top, List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            int totalRecordCount = -1;
            if (top <= 0)
                top = 1;
            string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_SysScreen]", top);
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
        public View_SysScreenRow GetRow(List<SqlParameter> sqlParameter, string whereSql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            int totalRecordCount = -1;
            View_SysScreenRow[] rows = null;
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
        public DataTable GetView_SysScreenPagingAsDataTable(List<SqlParameter> sqlParameter, string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ScreenID")
        {
            AntiSqlInjection.CheckInput(whereSql);
            if (startRowIndex < 0)
                startRowIndex = 0;
            if (rowPerPage < 0)
                rowPerPage = 1;
            if (string.IsNullOrWhiteSpace(orderBySql))
                orderBySql = "ScreenID";
            string whereCount = string.Empty;
            string wherePaging = string.Empty;
            if (null != whereSql && 0 < whereSql.Length)
            {
                whereCount = " WHERE " + whereSql;
                wherePaging = " AND " + whereSql;
                whereSql = " WHERE   " + whereSql;
            }
            string sql = "SELECT COUNT(ScreenID) AS TotalRow FROM [dbo].[View_SysScreen] " + whereCount;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            command.Parameters.Clear();
            var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
            var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
            sql = " SELECT RowRank,ScreenID,ModuleID,ParentScreenID,ScreenName,ScreenTitle,SortOrder,IsActive,ModifiedDate,SubScreen," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
            " FROM (SELECT [View_SysScreen].*, " +
            " ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
            " FROM [dbo].[View_SysScreen] " + whereSql +
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
        public View_SysScreenItemsPaging GetView_SysScreenPagingAsArray(List<SqlParameter> sqlParameter, string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ScreenID")
        {
            View_SysScreenItemsPaging obj = new View_SysScreenItemsPaging();
            DataTable dt = GetView_SysScreenPagingAsDataTable(sqlParameter, whereSql, startRowIndex, rowPerPage, orderBySql);
            if (dt.Rows.Count != 0)
            {
                obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
                obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
            }
            View_SysScreenItems record;
            ArrayList recordList = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                record = new View_SysScreenItems();
                record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
                record.ScreenID = Convert.ToInt32(dt.Rows[i]["ScreenID"]);
                record.ModuleID = Convert.ToInt32(dt.Rows[i]["ModuleID"]);
                if (dt.Rows[i]["ParentScreenID"] != DBNull.Value)
                    record.ParentScreenID = Convert.ToInt32(dt.Rows[i]["ParentScreenID"]);
                record.ScreenName = dt.Rows[i]["ScreenName"].ToString();
                record.ScreenTitle = dt.Rows[i]["ScreenTitle"].ToString();
                record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
                record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
                    record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
                record.SubScreen = dt.Rows[i]["SubScreen"].ToString();
                recordList.Add(record);
            }
            obj.view_SysScreenItems = (View_SysScreenItems[])(recordList.ToArray(typeof(View_SysScreenItems)));
            return obj;
        }
        public View_SysScreenRow[] GetIsActive(bool isActive)
        {
            string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "IsActive", isActive);
            View_SysScreenRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray;
        }
        protected View_SysScreenRow[] MapRecords(IDbCommand command)
        {
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecords(reader);
            }
        }
        protected View_SysScreenRow[] MapRecords(IDataReader reader)
        {
            int totalRecordCount = -1;
            return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
        }
        protected View_SysScreenRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int screenIDColumnIndex = reader.GetOrdinal("ScreenID");
            int moduleIDColumnIndex = reader.GetOrdinal("ModuleID");
            int parentScreenIDColumnIndex = reader.GetOrdinal("ParentScreenID");
            int screenNameColumnIndex = reader.GetOrdinal("ScreenName");
            int screenTitleColumnIndex = reader.GetOrdinal("ScreenTitle");
            int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
            int isActiveColumnIndex = reader.GetOrdinal("IsActive");
            int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
            int subscreenColumnIndex = reader.GetOrdinal("SubScreen");
            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            int countRecordRow = 0;
            while (reader.Read())
            {
                countRecordRow++;
                ri++;
                if (ri > 0 && ri <= length)
                {
                    View_SysScreenRow record = new View_SysScreenRow();
                    recordList.Add(record);
                    record.ScreenID = Convert.ToInt32(reader.GetValue(screenIDColumnIndex));
                    record.ModuleID = Convert.ToInt32(reader.GetValue(moduleIDColumnIndex));
                    if (!reader.IsDBNull(parentScreenIDColumnIndex)) record.ParentScreenID = Convert.ToInt32(reader.GetValue(parentScreenIDColumnIndex));

                    record.ScreenName = Convert.ToString(reader.GetValue(screenNameColumnIndex));
                    if (!reader.IsDBNull(screenTitleColumnIndex)) record.ScreenTitle = Convert.ToString(reader.GetValue(screenTitleColumnIndex));

                    record.SortOrder = Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));
                    record.IsActive = Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
                    if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate = Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

                    if (!reader.IsDBNull(subscreenColumnIndex)) record.SubScreen = Convert.ToString(reader.GetValue(subscreenColumnIndex));

                    if (ri == length && 0 != totalRecordCount)
                        break;
                }
            }
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (View_SysScreenRow[])(recordList.ToArray(typeof(View_SysScreenRow)));
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
                case "ScreenID":
                    parameter = AddParameter(cmd, paramName, DbType.Int32, value);
                    break;
                case "ModuleID":
                    parameter = AddParameter(cmd, paramName, DbType.Int32, value);
                    break;
                case "ParentScreenID":
                    parameter = AddParameter(cmd, paramName, DbType.Int32, value);
                    break;
                case "ScreenName":
                    parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
                    break;
                case "ScreenTitle":
                    parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
                    break;
                case "SortOrder":
                    parameter = AddParameter(cmd, paramName, DbType.Int32, value);
                    break;
                case "IsActive":
                    parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
                    break;
                case "ModifiedDate":
                    parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
                    break;
                case "SubScreen":
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

