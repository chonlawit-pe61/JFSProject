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
	public partial class WorkStepCollection_Base : MarshalByRefObject
	{
		public const string WorkStepIDColumnName = "WorkStepID";
		public const string WorkStepNameColumnName = "WorkStepName";
		public const string AllowPermissionSettingColumnName = "AllowPermissionSetting";
		public const string GroupNameColumnName = "GroupName";
		public const string IsStopCountKIPColumnName = "IsStopCountKIP";
		public const string IsActiveColumnName = "IsActive";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public WorkStepCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual WorkStepRow[] GetAll()
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
			string sql = "SELECT "+
			"[WorkStepID],"+
			"[WorkStepName],"+
			"[AllowPermissionSetting],"+
			"[GroupName],"+
			"[IsStopCountKIP],"+
			"[IsActive],"+
			"[ModifiedDate]"+
			" FROM [dbo].[WorkStep]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[WorkStep]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "WorkStep"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("WorkStepID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("WorkStepName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AllowPermissionSetting",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("GroupName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsStopCountKIP",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public WorkStepRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual WorkStepRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="WorkStepRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="WorkStepRow"/> objects.</returns>
		public virtual WorkStepRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[WorkStep]", top);
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
		public WorkStepRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			WorkStepRow[] rows = null;
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
		public DataTable GetWorkStepPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "WorkStepID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "WorkStepID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[WorkStep] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,WorkStepID,WorkStepName,AllowPermissionSetting,GroupName,IsStopCountKIP,IsActive,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [WorkStep].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[WorkStep] " + whereSql +
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
		public WorkStepItemsPaging GetWorkStepPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "WorkStepID")
		{
		WorkStepItemsPaging obj = new WorkStepItemsPaging();
		DataTable dt = GetWorkStepPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		WorkStepItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new WorkStepItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.WorkStepID = Convert.ToInt32(dt.Rows[i]["WorkStepID"]);
			record.WorkStepName = dt.Rows[i]["WorkStepName"].ToString();
			record.AllowPermissionSetting = dt.Rows[i]["AllowPermissionSetting"].ToString();
			record.GroupName = dt.Rows[i]["GroupName"].ToString();
			if (dt.Rows[i]["IsStopCountKIP"] != DBNull.Value)
			record.IsStopCountKIP = Convert.ToBoolean(dt.Rows[i]["IsStopCountKIP"]);
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.workStepItems = (WorkStepItems[])(recordList.ToArray(typeof(WorkStepItems)));
		return obj;
		}
		public WorkStepRow GetByPrimaryKey(int workStepID)
		{
			string whereSql = "[WorkStepID]=" + CreateSqlParameterName("WorkStepID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "WorkStepID", workStepID);
			WorkStepRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(WorkStepRow value)		{
			string sqlStr = "INSERT INTO [dbo].[WorkStep] (" +
			"[WorkStepID], " + 
			"[WorkStepName], " + 
			"[AllowPermissionSetting], " + 
			"[GroupName], " + 
			"[IsStopCountKIP], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("WorkStepID") + ", " +
			CreateSqlParameterName("WorkStepName") + ", " +
			CreateSqlParameterName("AllowPermissionSetting") + ", " +
			CreateSqlParameterName("GroupName") + ", " +
			CreateSqlParameterName("IsStopCountKIP") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "WorkStepID", value.WorkStepID);
			AddParameter(cmd, "WorkStepName",value.WorkStepName);
			AddParameter(cmd, "AllowPermissionSetting", value.AllowPermissionSetting);
			AddParameter(cmd, "GroupName", value.GroupName);
			AddParameter(cmd, "IsStopCountKIP", value.IsIsStopCountKIPNull ? DBNull.Value : (object)value.IsStopCountKIP);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(WorkStepRow value)		{
			string sqlStr = "INSERT INTO [dbo].[WorkStep] (" +
			"[WorkStepID], " + 
			"[WorkStepName], " + 
			"[AllowPermissionSetting], " + 
			"[GroupName], " + 
			"[IsStopCountKIP], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("WorkStepID") + ", " +
			CreateSqlParameterName("WorkStepName") + ", " +
			CreateSqlParameterName("AllowPermissionSetting") + ", " +
			CreateSqlParameterName("GroupName") + ", " +
			CreateSqlParameterName("IsStopCountKIP") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "WorkStepID", value.WorkStepID);
			AddParameter(cmd, "WorkStepName", Sanitizer.GetSafeHtmlFragment(value.WorkStepName));
			AddParameter(cmd, "AllowPermissionSetting", Sanitizer.GetSafeHtmlFragment(value.AllowPermissionSetting));
			AddParameter(cmd, "GroupName", Sanitizer.GetSafeHtmlFragment(value.GroupName));
			AddParameter(cmd, "IsStopCountKIP", value.IsIsStopCountKIPNull ? DBNull.Value : (object)value.IsStopCountKIP);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(WorkStepRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetWorkStepID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetWorkStepName)
				{
					strUpdate += "[WorkStepName]=" + CreateSqlParameterName("WorkStepName") + ",";
				}
				if (value._IsSetAllowPermissionSetting)
				{
					strUpdate += "[AllowPermissionSetting]=" + CreateSqlParameterName("AllowPermissionSetting") + ",";
				}
				if (value._IsSetGroupName)
				{
					strUpdate += "[GroupName]=" + CreateSqlParameterName("GroupName") + ",";
				}
				if (value._IsSetIsStopCountKIP)
				{
					strUpdate += "[IsStopCountKIP]=" + CreateSqlParameterName("IsStopCountKIP") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[WorkStep] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[WorkStepID]=" + CreateSqlParameterName("WorkStepID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "WorkStepID", value.WorkStepID);
					AddParameter(cmd, "WorkStepName",value.WorkStepName);
					AddParameter(cmd, "AllowPermissionSetting", value.AllowPermissionSetting);
					AddParameter(cmd, "GroupName", value.GroupName);
					AddParameter(cmd, "IsStopCountKIP", value.IsIsStopCountKIPNull ? DBNull.Value : (object)value.IsStopCountKIP);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(WorkStepID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(WorkStepRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetWorkStepID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetWorkStepName)
				{
					strUpdate += "[WorkStepName]=" + CreateSqlParameterName("WorkStepName") + ",";
				}
				if (value._IsSetAllowPermissionSetting)
				{
					strUpdate += "[AllowPermissionSetting]=" + CreateSqlParameterName("AllowPermissionSetting") + ",";
				}
				if (value._IsSetGroupName)
				{
					strUpdate += "[GroupName]=" + CreateSqlParameterName("GroupName") + ",";
				}
				if (value._IsSetIsStopCountKIP)
				{
					strUpdate += "[IsStopCountKIP]=" + CreateSqlParameterName("IsStopCountKIP") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[WorkStep] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[WorkStepID]=" + CreateSqlParameterName("WorkStepID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "WorkStepID", value.WorkStepID);
					AddParameter(cmd, "WorkStepName", Sanitizer.GetSafeHtmlFragment(value.WorkStepName));
					AddParameter(cmd, "AllowPermissionSetting", Sanitizer.GetSafeHtmlFragment(value.AllowPermissionSetting));
					AddParameter(cmd, "GroupName", Sanitizer.GetSafeHtmlFragment(value.GroupName));
					AddParameter(cmd, "IsStopCountKIP", value.IsIsStopCountKIPNull ? DBNull.Value : (object)value.IsStopCountKIP);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(WorkStepID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int workStepID)
		{
			string whereSql = "[WorkStepID]=" + CreateSqlParameterName("WorkStepID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "WorkStepID", workStepID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public WorkStepRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			WorkStepRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected WorkStepRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected WorkStepRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected WorkStepRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int workStepIDColumnIndex = reader.GetOrdinal("WorkStepID");
			int workStepNameColumnIndex = reader.GetOrdinal("WorkStepName");
			int allowPermissionSettingColumnIndex = reader.GetOrdinal("AllowPermissionSetting");
			int groupNameColumnIndex = reader.GetOrdinal("GroupName");
			int isStopCountKiPColumnIndex = reader.GetOrdinal("IsStopCountKIP");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					WorkStepRow record = new WorkStepRow();
					recordList.Add(record);
					record.WorkStepID =  Convert.ToInt32(reader.GetValue(workStepIDColumnIndex));
					record.WorkStepName =  Convert.ToString(reader.GetValue(workStepNameColumnIndex));
					if (!reader.IsDBNull(allowPermissionSettingColumnIndex)) record.AllowPermissionSetting =  Convert.ToString(reader.GetValue(allowPermissionSettingColumnIndex));

					if (!reader.IsDBNull(groupNameColumnIndex)) record.GroupName =  Convert.ToString(reader.GetValue(groupNameColumnIndex));

					if (!reader.IsDBNull(isStopCountKiPColumnIndex)) record.IsStopCountKIP =  Convert.ToBoolean(reader.GetValue(isStopCountKiPColumnIndex));

					record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (WorkStepRow[])(recordList.ToArray(typeof(WorkStepRow)));
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
				case "WorkStepID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "WorkStepName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "AllowPermissionSetting":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "GroupName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsStopCountKIP":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
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

