using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	[Serializable]
	public partial class View_WorkStepChangeHistoryCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string WorkStepIDColumnName = "WorkStepID";
		public const string UserIDColumnName = "UserID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string ChangeDateColumnName = "ChangeDate";
		public const string CommentColumnName = "Comment";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string WorkStepNameColumnName = "WorkStepName";
		public const string UserNameColumnName = "UserName";
		public const string AliasNameColumnName = "AliasName";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string DepartmentNameAbbrColumnName = "DepartmentNameAbbr";
		private int _processID;
		public SqlCommand cmd = null;
		public View_WorkStepChangeHistoryCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_WorkStepChangeHistoryRow[] GetAll()
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
			string sql = "SELECT "+
			"[CaseID],"+
			"[WorkStepID],"+
			"[UserID],"+
			"[DepartmentID],"+
			"[ChangeDate],"+
			"[Comment],"+
			"[ModifiedDate],"+
			"[WorkStepName],"+
			"[UserName],"+
			"[AliasName],"+
			"[FirstName],"+
			"[LastName],"+
			"[DepartmentName],"+
			"[DepartmentNameAbbr]"+
			" FROM [dbo].[View_WorkStepChangeHistory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "View_WorkStepChangeHistory"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("WorkStepID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ChangeDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Comment",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("WorkStepName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AliasName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public View_WorkStepChangeHistoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_WorkStepChangeHistoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_WorkStepChangeHistoryRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_WorkStepChangeHistoryRow"/> objects.</returns>
		public virtual View_WorkStepChangeHistoryRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_WorkStepChangeHistory]", top);
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
		public View_WorkStepChangeHistoryRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_WorkStepChangeHistoryRow[] rows = null;
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
		public DataTable GetView_WorkStepChangeHistoryPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_WorkStepChangeHistory] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,WorkStepID,UserID,DepartmentID,ChangeDate,Comment,ModifiedDate,WorkStepName,UserName,AliasName,FirstName,LastName,DepartmentName,DepartmentNameAbbr," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_WorkStepChangeHistory].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_WorkStepChangeHistory] " + whereSql +
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
		public View_WorkStepChangeHistoryItemsPaging GetView_WorkStepChangeHistoryPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		View_WorkStepChangeHistoryItemsPaging obj = new View_WorkStepChangeHistoryItemsPaging();
		DataTable dt = GetView_WorkStepChangeHistoryPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_WorkStepChangeHistoryItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_WorkStepChangeHistoryItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.WorkStepID = Convert.ToInt32(dt.Rows[i]["WorkStepID"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.ChangeDate = Convert.ToDateTime(dt.Rows[i]["ChangeDate"]);
			record.Comment = dt.Rows[i]["Comment"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.WorkStepName = dt.Rows[i]["WorkStepName"].ToString();
			record.UserName = dt.Rows[i]["UserName"].ToString();
			record.AliasName = dt.Rows[i]["AliasName"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			record.DepartmentNameAbbr = dt.Rows[i]["DepartmentNameAbbr"].ToString();
			recordList.Add(record);
		}
		obj.view_WorkStepChangeHistoryItems = (View_WorkStepChangeHistoryItems[])(recordList.ToArray(typeof(View_WorkStepChangeHistoryItems)));
		return obj;
		}
		protected View_WorkStepChangeHistoryRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_WorkStepChangeHistoryRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_WorkStepChangeHistoryRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int workStepIDColumnIndex = reader.GetOrdinal("WorkStepID");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int changeDateColumnIndex = reader.GetOrdinal("ChangeDate");
			int commentColumnIndex = reader.GetOrdinal("Comment");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int workStepNameColumnIndex = reader.GetOrdinal("WorkStepName");
			int userNameColumnIndex = reader.GetOrdinal("UserName");
			int aliasNameColumnIndex = reader.GetOrdinal("AliasName");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int departmentNameColumnIndex = reader.GetOrdinal("DepartmentName");
			int departmentNameAbbrColumnIndex = reader.GetOrdinal("DepartmentNameAbbr");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_WorkStepChangeHistoryRow record = new View_WorkStepChangeHistoryRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.WorkStepID =  Convert.ToInt32(reader.GetValue(workStepIDColumnIndex));
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					record.ChangeDate =  Convert.ToDateTime(reader.GetValue(changeDateColumnIndex));
					if (!reader.IsDBNull(commentColumnIndex)) record.Comment =  Convert.ToString(reader.GetValue(commentColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					record.WorkStepName =  Convert.ToString(reader.GetValue(workStepNameColumnIndex));
					record.UserName =  Convert.ToString(reader.GetValue(userNameColumnIndex));
					record.AliasName =  Convert.ToString(reader.GetValue(aliasNameColumnIndex));
					record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));
					record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));
					record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));
					record.DepartmentNameAbbr =  Convert.ToString(reader.GetValue(departmentNameAbbrColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_WorkStepChangeHistoryRow[])(recordList.ToArray(typeof(View_WorkStepChangeHistoryRow)));
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
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "WorkStepID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ChangeDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Comment":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "WorkStepName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "UserName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AliasName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

