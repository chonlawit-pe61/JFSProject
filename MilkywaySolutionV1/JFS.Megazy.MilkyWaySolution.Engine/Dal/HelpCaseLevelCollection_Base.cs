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
	public partial class HelpCaseLevelCollection_Base : MarshalByRefObject
	{
		public const string HelpCaseLevelIDColumnName = "HelpCaseLevelID";
		public const string HelpCaseLevelNameColumnName = "HelpCaseLevelName";
		public const string IsOtherHelpCaseLevelColumnName = "IsOtherHelpCaseLevel";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public HelpCaseLevelCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual HelpCaseLevelRow[] GetAll()
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
			"[HelpCaseLevelID],"+
			"[HelpCaseLevelName],"+
			"[IsOtherHelpCaseLevel],"+
			"[ModifiedDate]"+
			" FROM [dbo].[HelpCaseLevel]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[HelpCaseLevel]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "HelpCaseLevel"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("HelpCaseLevelID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("HelpCaseLevelName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsOtherHelpCaseLevel",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public HelpCaseLevelRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual HelpCaseLevelRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="HelpCaseLevelRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="HelpCaseLevelRow"/> objects.</returns>
		public virtual HelpCaseLevelRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[HelpCaseLevel]", top);
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
		public HelpCaseLevelRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			HelpCaseLevelRow[] rows = null;
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
		public DataTable GetHelpCaseLevelPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "HelpCaseLevelID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "HelpCaseLevelID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(HelpCaseLevelID) AS TotalRow FROM [dbo].[HelpCaseLevel] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,HelpCaseLevelID,HelpCaseLevelName,IsOtherHelpCaseLevel,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[HelpCaseLevel] " + whereSql +
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
		public HelpCaseLevelItemsPaging GetHelpCaseLevelPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "HelpCaseLevelID")
		{
		HelpCaseLevelItemsPaging obj = new HelpCaseLevelItemsPaging();
		DataTable dt = GetHelpCaseLevelPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		HelpCaseLevelItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new HelpCaseLevelItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.HelpCaseLevelID = Convert.ToInt32(dt.Rows[i]["HelpCaseLevelID"]);
			record.HelpCaseLevelName = dt.Rows[i]["HelpCaseLevelName"].ToString();
			record.IsOtherHelpCaseLevel = Convert.ToBoolean(dt.Rows[i]["IsOtherHelpCaseLevel"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.helpCaseLevelItems = (HelpCaseLevelItems[])(recordList.ToArray(typeof(HelpCaseLevelItems)));
		return obj;
		}
		public HelpCaseLevelRow GetByPrimaryKey(int helpCaseLevelID)
		{
			string whereSql = "[HelpCaseLevelID]=" + CreateSqlParameterName("HelpCaseLevelID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "HelpCaseLevelID", helpCaseLevelID);
			HelpCaseLevelRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(HelpCaseLevelRow value)		{
			string sqlStr = "INSERT INTO [dbo].[HelpCaseLevel] (" +
			"[HelpCaseLevelID], " + 
			"[HelpCaseLevelName], " + 
			"[IsOtherHelpCaseLevel], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("HelpCaseLevelID") + ", " +
			CreateSqlParameterName("HelpCaseLevelName") + ", " +
			CreateSqlParameterName("IsOtherHelpCaseLevel") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "HelpCaseLevelID", value.HelpCaseLevelID);
			AddParameter(cmd, "HelpCaseLevelName",value.HelpCaseLevelName);
			AddParameter(cmd, "IsOtherHelpCaseLevel", value.IsOtherHelpCaseLevel);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(HelpCaseLevelRow value)		{
			string sqlStr = "INSERT INTO [dbo].[HelpCaseLevel] (" +
			"[HelpCaseLevelID], " + 
			"[HelpCaseLevelName], " + 
			"[IsOtherHelpCaseLevel], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("HelpCaseLevelID") + ", " +
			CreateSqlParameterName("HelpCaseLevelName") + ", " +
			CreateSqlParameterName("IsOtherHelpCaseLevel") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "HelpCaseLevelID", value.HelpCaseLevelID);
			AddParameter(cmd, "HelpCaseLevelName", Sanitizer.GetSafeHtmlFragment(value.HelpCaseLevelName));
			AddParameter(cmd, "IsOtherHelpCaseLevel", value.IsOtherHelpCaseLevel);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(HelpCaseLevelRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetHelpCaseLevelID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetHelpCaseLevelName)
				{
					strUpdate += "[HelpCaseLevelName]=" + CreateSqlParameterName("HelpCaseLevelName") + ",";
				}
				if (value._IsSetIsOtherHelpCaseLevel)
				{
					strUpdate += "[IsOtherHelpCaseLevel]=" + CreateSqlParameterName("IsOtherHelpCaseLevel") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[HelpCaseLevel] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[HelpCaseLevelID]=" + CreateSqlParameterName("HelpCaseLevelID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "HelpCaseLevelID", value.HelpCaseLevelID);
					AddParameter(cmd, "HelpCaseLevelName",value.HelpCaseLevelName);
					AddParameter(cmd, "IsOtherHelpCaseLevel", value.IsOtherHelpCaseLevel);
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
				Exception ex = new Exception("Set incorrect primarykey PK(HelpCaseLevelID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(HelpCaseLevelRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetHelpCaseLevelID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetHelpCaseLevelName)
				{
					strUpdate += "[HelpCaseLevelName]=" + CreateSqlParameterName("HelpCaseLevelName") + ",";
				}
				if (value._IsSetIsOtherHelpCaseLevel)
				{
					strUpdate += "[IsOtherHelpCaseLevel]=" + CreateSqlParameterName("IsOtherHelpCaseLevel") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[HelpCaseLevel] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[HelpCaseLevelID]=" + CreateSqlParameterName("HelpCaseLevelID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "HelpCaseLevelID", value.HelpCaseLevelID);
					AddParameter(cmd, "HelpCaseLevelName", Sanitizer.GetSafeHtmlFragment(value.HelpCaseLevelName));
					AddParameter(cmd, "IsOtherHelpCaseLevel", value.IsOtherHelpCaseLevel);
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
				Exception ex = new Exception("Set incorrect primarykey PK(HelpCaseLevelID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int helpCaseLevelID)
		{
			string whereSql = "[HelpCaseLevelID]=" + CreateSqlParameterName("HelpCaseLevelID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "HelpCaseLevelID", helpCaseLevelID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected HelpCaseLevelRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected HelpCaseLevelRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected HelpCaseLevelRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int helpCaseLevelIDColumnIndex = reader.GetOrdinal("HelpCaseLevelID");
			int helpCaseLevelNameColumnIndex = reader.GetOrdinal("HelpCaseLevelName");
			int isOtherHelpCaseLevelColumnIndex = reader.GetOrdinal("IsOtherHelpCaseLevel");
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
					HelpCaseLevelRow record = new HelpCaseLevelRow();
					recordList.Add(record);
					record.HelpCaseLevelID =  Convert.ToInt32(reader.GetValue(helpCaseLevelIDColumnIndex));
					record.HelpCaseLevelName =  Convert.ToString(reader.GetValue(helpCaseLevelNameColumnIndex));
					record.IsOtherHelpCaseLevel =  Convert.ToBoolean(reader.GetValue(isOtherHelpCaseLevelColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (HelpCaseLevelRow[])(recordList.ToArray(typeof(HelpCaseLevelRow)));
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
				case "HelpCaseLevelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "HelpCaseLevelName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsOtherHelpCaseLevel":
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

