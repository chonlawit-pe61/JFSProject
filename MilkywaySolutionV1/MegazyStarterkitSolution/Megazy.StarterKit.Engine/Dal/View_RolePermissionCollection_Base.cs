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
    public partial class View_RolePermissionCollection_Base : MarshalByRefObject
    {
        public const string ModuleIDColumnName = "ModuleID";
        public const string ModuleNameColumnName = "ModuleName";
        public const string ModuleTitleColumnName = "ModuleTitle";
        public const string IsActiveColumnName = "IsActive";
        public const string SortOrderColumnName = "SortOrder";
        public const string ModuleIconColumnName = "ModuleIcon";
        public const string PermissionColumnName = "Permission";
        private int _processID;
        public SqlCommand cmd = null;
        public View_RolePermissionCollection_Base(int intProcessID)
        {
            _processID = intProcessID;
        }
        public void Dispose()
        {
            Close();
        }
        public virtual View_RolePermissionRow[] GetAll()
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
            "[ModuleID]," +
            "[ModuleName]," +
            "[ModuleTitle]," +
            "[IsActive]," +
            "[SortOrder]," +
            "[ModuleIcon]," +
            "[Permission]" +
            " FROM [dbo].[View_RolePermission]";
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
                TableName = "View_RolePermission"
            };
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("ModuleID", Type.GetType("System.Int32"));
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("ModuleName", Type.GetType("System.String"));
            dataColumn.MaxLength = 50;
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("ModuleTitle", Type.GetType("System.String"));
            dataColumn.MaxLength = 100;
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("IsActive", Type.GetType("System.Boolean"));
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("SortOrder", Type.GetType("System.Int32"));
            dataColumn.AllowDBNull = false;
            dataColumn = dataTable.Columns.Add("ModuleIcon", Type.GetType("System.String"));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("Permission", Type.GetType("System.String"));
            dataColumn.MaxLength = 2147483647;
            return dataTable;
        }
        public View_RolePermissionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }
        public virtual View_RolePermissionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
        {
            SqlCommand command = CreateGetCommand(whereSql, orderBySql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }
        /// <summary>
        /// Gets an array of <see cref="View_RolePermissionRow"/> objects that
        /// match the search condition, in the the specified sort order.
        /// </summary>
        /// <param name="top">The Number of select top condition. For example: 
        /// <c>"10"</c>.</param>
        /// <param name="whereSql">The SQL search condition. For example: 
        /// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
        /// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
        /// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
        /// <returns>An array of <see cref="View_RolePermissionRow"/> objects.</returns>
        public virtual View_RolePermissionRow[] GetTopAsArray(int top, List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            int totalRecordCount = -1;
            if (top <= 0)
                top = 1;
            string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_RolePermission]", top);
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
        public View_RolePermissionRow GetRow(List<SqlParameter> sqlParameter, string whereSql)
        {
            AntiSqlInjection.CheckInput(whereSql);
            int totalRecordCount = -1;
            View_RolePermissionRow[] rows = null;
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
        public DataTable GetView_RolePermissionPagingAsDataTable(List<SqlParameter> sqlParameter, string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ModuleID")
        {
            AntiSqlInjection.CheckInput(whereSql);
            if (startRowIndex < 0)
                startRowIndex = 0;
            if (rowPerPage < 0)
                rowPerPage = 1;
            if (string.IsNullOrWhiteSpace(orderBySql))
                orderBySql = "ModuleID";
            string whereCount = string.Empty;
            string wherePaging = string.Empty;
            if (null != whereSql && 0 < whereSql.Length)
            {
                whereCount = " WHERE " + whereSql;
                wherePaging = " AND " + whereSql;
                whereSql = " WHERE   " + whereSql;
            }
            string sql = "SELECT COUNT(ModuleID) AS TotalRow FROM [dbo].[View_RolePermission] " + whereCount;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            DataTable dt = CreateDataTable(command);
            command.Parameters.Clear();
            var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
            var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
            sql = " SELECT RowRank,ModuleID,ModuleName,ModuleTitle,IsActive,SortOrder,ModuleIcon,Permission," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
            " FROM (SELECT [View_RolePermission].*, " +
            " ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
            " FROM [dbo].[View_RolePermission] " + whereSql +
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
        public View_RolePermissionItemsPaging GetView_RolePermissionPagingAsArray(List<SqlParameter> sqlParameter, string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ModuleID")
        {
            View_RolePermissionItemsPaging obj = new View_RolePermissionItemsPaging();
            DataTable dt = GetView_RolePermissionPagingAsDataTable(sqlParameter, whereSql, startRowIndex, rowPerPage, orderBySql);
            if (dt.Rows.Count != 0)
            {
                obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
                obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
            }
            View_RolePermissionItems record;
            ArrayList recordList = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                record = new View_RolePermissionItems();
                record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
                record.ModuleID = Convert.ToInt32(dt.Rows[i]["ModuleID"]);
                record.ModuleName = dt.Rows[i]["ModuleName"].ToString();
                record.ModuleTitle = dt.Rows[i]["ModuleTitle"].ToString();
                record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
                record.ModuleIcon = dt.Rows[i]["ModuleIcon"].ToString();
                record.Permission = dt.Rows[i]["Permission"].ToString();
                recordList.Add(record);
            }
            obj.view_RolePermissionItems = (View_RolePermissionItems[])(recordList.ToArray(typeof(View_RolePermissionItems)));
            return obj;
        }
        public View_RolePermissionRow[] GetIsActive(bool isActive)
        {
            string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
            IDbCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "IsActive", isActive);
            View_RolePermissionRow[] tempArray = MapRecords(cmd);
            return 0 == tempArray.Length ? null : tempArray;
        }
        protected View_RolePermissionRow[] MapRecords(IDbCommand command)
        {
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecords(reader);
            }
        }
        protected View_RolePermissionRow[] MapRecords(IDataReader reader)
        {
            int totalRecordCount = -1;
            return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
        }
        protected View_RolePermissionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int moduleIDColumnIndex = reader.GetOrdinal("ModuleID");
            int moduleNameColumnIndex = reader.GetOrdinal("ModuleName");
            int moduleTitleColumnIndex = reader.GetOrdinal("ModuleTitle");
            int isActiveColumnIndex = reader.GetOrdinal("IsActive");
            int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
            int moduleIconColumnIndex = reader.GetOrdinal("ModuleIcon");
            int permissionColumnIndex = reader.GetOrdinal("Permission");
            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            int countRecordRow = 0;
            while (reader.Read())
            {
                countRecordRow++;
                ri++;
                if (ri > 0 && ri <= length)
                {
                    View_RolePermissionRow record = new View_RolePermissionRow();
                    recordList.Add(record);
                    record.ModuleID = Convert.ToInt32(reader.GetValue(moduleIDColumnIndex));
                    record.ModuleName = Convert.ToString(reader.GetValue(moduleNameColumnIndex));
                    record.ModuleTitle = Convert.ToString(reader.GetValue(moduleTitleColumnIndex));
                    record.IsActive = Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
                    record.SortOrder = Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));
                    if (!reader.IsDBNull(moduleIconColumnIndex)) record.ModuleIcon = Convert.ToString(reader.GetValue(moduleIconColumnIndex));

                    if (!reader.IsDBNull(permissionColumnIndex)) record.Permission = Convert.ToString(reader.GetValue(permissionColumnIndex));

                    if (ri == length && 0 != totalRecordCount)
                        break;
                }
            }
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (View_RolePermissionRow[])(recordList.ToArray(typeof(View_RolePermissionRow)));
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
                case "ModuleID":
                    parameter = AddParameter(cmd, paramName, DbType.Int32, value);
                    break;
                case "ModuleName":
                    parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
                    break;
                case "ModuleTitle":
                    parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
                    break;
                case "IsActive":
                    parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
                    break;
                case "SortOrder":
                    parameter = AddParameter(cmd, paramName, DbType.Int32, value);
                    break;
                case "ModuleIcon":
                    parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
                    break;
                case "Permission":
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

