using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using Megazy.StarterKit.Engine.Structure;
namespace Megazy.StarterKit.Engine.Dal
{
	[Serializable]
	public partial class SysScreenCollection_Base : MarshalByRefObject
	{
		public const string ScreenIDColumnName = "ScreenID";
		public const string ModuleIDColumnName = "ModuleID";
		public const string ParentScreenIDColumnName = "ParentScreenID";
		public const string ScreenNameColumnName = "ScreenName";
		public const string ScreenTitleColumnName = "ScreenTitle";
		public const string SortOrderColumnName = "SortOrder";
		public const string IsActiveColumnName = "IsActive";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public SysScreenCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SysScreenRow[] GetAll()
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
			"[ScreenID],"+
			"[ModuleID],"+
			"[ParentScreenID],"+
			"[ScreenName],"+
			"[ScreenTitle],"+
			"[SortOrder],"+
			"[IsActive],"+
			"[ModifiedDate]"+
			" FROM [dbo].[SysScreen]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[SysScreen]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "SysScreen"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ScreenID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModuleID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ParentScreenID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ScreenName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ScreenTitle",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual SysScreenRow[] GetByModuleID(int moduleID)
		{
			return MapRecords(CreateGetByModuleIDCommand(moduleID));
		}
		public virtual DataTable GetByModuleIDAsDataTable(int moduleID)
		{
			return MapRecordsToDataTable(CreateGetByModuleIDCommand(moduleID));
		}
		protected virtual IDbCommand CreateGetByModuleIDCommand(int moduleID)
		{
			string whereSql = "";
			whereSql += "[ModuleID]=" + CreateSqlParameterName("ModuleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ModuleID", moduleID);
			return cmd;
		}
		public SysScreenRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SysScreenRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SysScreenRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SysScreenRow"/> objects.</returns>
		public virtual SysScreenRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[SysScreen]", top);
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
		public SysScreenRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SysScreenRow[] rows = null;
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
		public DataTable GetSysScreenPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ScreenID")
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
		string sql = "SELECT COUNT(ScreenID) AS TotalRow FROM [dbo].[SysScreen] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ScreenID,ModuleID,ParentScreenID,ScreenName,ScreenTitle,SortOrder,IsActive,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[SysScreen] " + whereSql +
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
		public SysScreenItemsPaging GetSysScreenPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ScreenID")
		{
		SysScreenItemsPaging obj = new SysScreenItemsPaging();
		DataTable dt = GetSysScreenPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SysScreenItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SysScreenItems();
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
			recordList.Add(record);
		}
		obj.sysscreenItems = (SysScreenItems[])(recordList.ToArray(typeof(SysScreenItems)));
		return obj;
		}
		public SysScreenRow GetByPrimaryKey(int screenID)
		{
			string whereSql = "[ScreenID]=" + CreateSqlParameterName("ScreenID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ScreenID", screenID);
			SysScreenRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(SysScreenRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SysScreen] (" +
			"[ScreenID], " + 
			"[ModuleID], " + 
			"[ParentScreenID], " + 
			"[ScreenName], " + 
			"[ScreenTitle], " + 
			"[SortOrder], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ScreenID") + ", " +
			CreateSqlParameterName("ModuleID") + ", " +
			CreateSqlParameterName("ParentScreenID") + ", " +
			CreateSqlParameterName("ScreenName") + ", " +
			CreateSqlParameterName("ScreenTitle") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ScreenID", value.ScreenID);
			AddParameter(cmd, "ModuleID", value.ModuleID);
			AddParameter(cmd, "ParentScreenID", value.IsParentScreenIDNull ? DBNull.Value : (object)value.ParentScreenID);
			AddParameter(cmd, "ScreenName",value.ScreenName);
			AddParameter(cmd, "ScreenTitle", value.ScreenTitle);
			AddParameter(cmd, "SortOrder", value.SortOrder);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(SysScreenRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SysScreen] (" +
			"[ScreenID], " + 
			"[ModuleID], " + 
			"[ParentScreenID], " + 
			"[ScreenName], " + 
			"[ScreenTitle], " + 
			"[SortOrder], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ScreenID") + ", " +
			CreateSqlParameterName("ModuleID") + ", " +
			CreateSqlParameterName("ParentScreenID") + ", " +
			CreateSqlParameterName("ScreenName") + ", " +
			CreateSqlParameterName("ScreenTitle") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ScreenID", value.ScreenID);
			AddParameter(cmd, "ModuleID", value.ModuleID);
			AddParameter(cmd, "ParentScreenID", value.IsParentScreenIDNull ? DBNull.Value : (object)value.ParentScreenID);
			AddParameter(cmd, "ScreenName", Sanitizer.GetSafeHtmlFragment(value.ScreenName));
			AddParameter(cmd, "ScreenTitle", Sanitizer.GetSafeHtmlFragment(value.ScreenTitle));
			AddParameter(cmd, "SortOrder", value.SortOrder);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(SysScreenRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetScreenID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModuleID)
				{
					strUpdate += "[ModuleID]=" + CreateSqlParameterName("ModuleID") + ",";
				}
				if (value._IsSetParentScreenID)
				{
					strUpdate += "[ParentScreenID]=" + CreateSqlParameterName("ParentScreenID") + ",";
				}
				if (value._IsSetScreenName)
				{
					strUpdate += "[ScreenName]=" + CreateSqlParameterName("ScreenName") + ",";
				}
				if (value._IsSetScreenTitle)
				{
					strUpdate += "[ScreenTitle]=" + CreateSqlParameterName("ScreenTitle") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
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
					strUpdate = "UPDATE [dbo].[SysScreen] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ScreenID]=" + CreateSqlParameterName("ScreenID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ScreenID", value.ScreenID);
					AddParameter(cmd, "ModuleID", value.ModuleID);
					AddParameter(cmd, "ParentScreenID", value.IsParentScreenIDNull ? DBNull.Value : (object)value.ParentScreenID);
					AddParameter(cmd, "ScreenName",value.ScreenName);
					AddParameter(cmd, "ScreenTitle", value.ScreenTitle);
					AddParameter(cmd, "SortOrder", value.SortOrder);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ScreenID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SysScreenRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetScreenID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModuleID)
				{
					strUpdate += "[ModuleID]=" + CreateSqlParameterName("ModuleID") + ",";
				}
				if (value._IsSetParentScreenID)
				{
					strUpdate += "[ParentScreenID]=" + CreateSqlParameterName("ParentScreenID") + ",";
				}
				if (value._IsSetScreenName)
				{
					strUpdate += "[ScreenName]=" + CreateSqlParameterName("ScreenName") + ",";
				}
				if (value._IsSetScreenTitle)
				{
					strUpdate += "[ScreenTitle]=" + CreateSqlParameterName("ScreenTitle") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
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
					strUpdate = "UPDATE [dbo].[SysScreen] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ScreenID]=" + CreateSqlParameterName("ScreenID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ScreenID", value.ScreenID);
					AddParameter(cmd, "ModuleID", value.ModuleID);
					AddParameter(cmd, "ParentScreenID", value.IsParentScreenIDNull ? DBNull.Value : (object)value.ParentScreenID);
					AddParameter(cmd, "ScreenName", Sanitizer.GetSafeHtmlFragment(value.ScreenName));
					AddParameter(cmd, "ScreenTitle", Sanitizer.GetSafeHtmlFragment(value.ScreenTitle));
					AddParameter(cmd, "SortOrder", value.SortOrder);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ScreenID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int screenID)
		{
			string whereSql = "[ScreenID]=" + CreateSqlParameterName("ScreenID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ScreenID", screenID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public SysScreenRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			SysScreenRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByModuleID(int moduleID)
		{
			return CreateDeleteByModuleIDCommand(moduleID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByModuleIDCommand(int moduleID)
		{
			string whereSql = "";
			whereSql += "[ModuleID]=" + CreateSqlParameterName("ModuleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ModuleID", moduleID);
			return cmd;
		}
		protected SysScreenRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SysScreenRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SysScreenRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
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
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					SysScreenRow record = new SysScreenRow();
					recordList.Add(record);
					record.ScreenID =  Convert.ToInt32(reader.GetValue(screenIDColumnIndex));
					record.ModuleID =  Convert.ToInt32(reader.GetValue(moduleIDColumnIndex));
					if (!reader.IsDBNull(parentScreenIDColumnIndex)) record.ParentScreenID =  Convert.ToInt32(reader.GetValue(parentScreenIDColumnIndex));

					record.ScreenName =  Convert.ToString(reader.GetValue(screenNameColumnIndex));
					if (!reader.IsDBNull(screenTitleColumnIndex)) record.ScreenTitle =  Convert.ToString(reader.GetValue(screenTitleColumnIndex));

					record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));
					record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SysScreenRow[])(recordList.ToArray(typeof(SysScreenRow)));
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

