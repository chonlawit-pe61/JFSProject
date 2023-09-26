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
	public partial class SubcommitteeCollection_Base : MarshalByRefObject
	{
		public const string SubcommitteeIDColumnName = "SubcommitteeID";
		public const string SubcommitteeGroupIDColumnName = "SubcommitteeGroupID";
		public const string SubcommitteeNameColumnName = "SubcommitteeName";
		public const string AppointmentNoColumnName = "AppointmentNo";
		public const string IsHeadquarterColumnName = "IsHeadquarter";
		public const string IsActiveColumnName = "IsActive";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public SubcommitteeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SubcommitteeRow[] GetAll()
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
			"[SubcommitteeID],"+
			"[SubcommitteeGroupID],"+
			"[SubcommitteeName],"+
			"[AppointmentNo],"+
			"[IsHeadquarter],"+
			"[IsActive],"+
			"[ModifiedDate]"+
			" FROM [dbo].[Subcommittee]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Subcommittee]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Subcommittee"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("SubcommitteeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SubcommitteeGroupID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SubcommitteeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("AppointmentNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("IsHeadquarter",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public SubcommitteeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SubcommitteeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SubcommitteeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SubcommitteeRow"/> objects.</returns>
		public virtual SubcommitteeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Subcommittee]", top);
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
		public SubcommitteeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SubcommitteeRow[] rows = null;
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
		public DataTable GetSubcommitteePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SubcommitteeID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "SubcommitteeID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(SubcommitteeID) AS TotalRow FROM [dbo].[Subcommittee] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,SubcommitteeID,SubcommitteeGroupID,SubcommitteeName,AppointmentNo,IsHeadquarter,IsActive,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Subcommittee] " + whereSql +
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
		public SubcommitteeItemsPaging GetSubcommitteePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SubcommitteeID")
		{
		SubcommitteeItemsPaging obj = new SubcommitteeItemsPaging();
		DataTable dt = GetSubcommitteePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SubcommitteeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SubcommitteeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.SubcommitteeID = Convert.ToInt32(dt.Rows[i]["SubcommitteeID"]);
			if (dt.Rows[i]["SubcommitteeGroupID"] != DBNull.Value)
			record.SubcommitteeGroupID = Convert.ToInt32(dt.Rows[i]["SubcommitteeGroupID"]);
			record.SubcommitteeName = dt.Rows[i]["SubcommitteeName"].ToString();
			record.AppointmentNo = dt.Rows[i]["AppointmentNo"].ToString();
			if (dt.Rows[i]["IsHeadquarter"] != DBNull.Value)
			record.IsHeadquarter = Convert.ToBoolean(dt.Rows[i]["IsHeadquarter"]);
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.subcommitteeItems = (SubcommitteeItems[])(recordList.ToArray(typeof(SubcommitteeItems)));
		return obj;
		}
		public SubcommitteeRow GetByPrimaryKey(int subcommitteeID)
		{
			string whereSql = "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SubcommitteeID", subcommitteeID);
			SubcommitteeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(SubcommitteeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Subcommittee] (" +
			"[SubcommitteeID], " + 
			"[SubcommitteeGroupID], " + 
			"[SubcommitteeName], " + 
			"[AppointmentNo], " + 
			"[IsHeadquarter], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("SubcommitteeID") + ", " +
			CreateSqlParameterName("SubcommitteeGroupID") + ", " +
			CreateSqlParameterName("SubcommitteeName") + ", " +
			CreateSqlParameterName("AppointmentNo") + ", " +
			CreateSqlParameterName("IsHeadquarter") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "SubcommitteeID", value.SubcommitteeID);
			AddParameter(cmd, "SubcommitteeGroupID", value.IsSubcommitteeGroupIDNull ? DBNull.Value : (object)value.SubcommitteeGroupID);
			AddParameter(cmd, "SubcommitteeName", value.SubcommitteeName);
			AddParameter(cmd, "AppointmentNo", value.AppointmentNo);
			AddParameter(cmd, "IsHeadquarter", value.IsIsHeadquarterNull ? DBNull.Value : (object)value.IsHeadquarter);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(SubcommitteeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Subcommittee] (" +
			"[SubcommitteeID], " + 
			"[SubcommitteeGroupID], " + 
			"[SubcommitteeName], " + 
			"[AppointmentNo], " + 
			"[IsHeadquarter], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("SubcommitteeID") + ", " +
			CreateSqlParameterName("SubcommitteeGroupID") + ", " +
			CreateSqlParameterName("SubcommitteeName") + ", " +
			CreateSqlParameterName("AppointmentNo") + ", " +
			CreateSqlParameterName("IsHeadquarter") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "SubcommitteeID", value.SubcommitteeID);
			AddParameter(cmd, "SubcommitteeGroupID", value.IsSubcommitteeGroupIDNull ? DBNull.Value : (object)value.SubcommitteeGroupID);
			AddParameter(cmd, "SubcommitteeName", Sanitizer.GetSafeHtmlFragment(value.SubcommitteeName));
			AddParameter(cmd, "AppointmentNo", Sanitizer.GetSafeHtmlFragment(value.AppointmentNo));
			AddParameter(cmd, "IsHeadquarter", value.IsIsHeadquarterNull ? DBNull.Value : (object)value.IsHeadquarter);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(SubcommitteeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSubcommitteeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSubcommitteeGroupID)
				{
					strUpdate += "[SubcommitteeGroupID]=" + CreateSqlParameterName("SubcommitteeGroupID") + ",";
				}
				if (value._IsSetSubcommitteeName)
				{
					strUpdate += "[SubcommitteeName]=" + CreateSqlParameterName("SubcommitteeName") + ",";
				}
				if (value._IsSetAppointmentNo)
				{
					strUpdate += "[AppointmentNo]=" + CreateSqlParameterName("AppointmentNo") + ",";
				}
				if (value._IsSetIsHeadquarter)
				{
					strUpdate += "[IsHeadquarter]=" + CreateSqlParameterName("IsHeadquarter") + ",";
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
					strUpdate = "UPDATE [dbo].[Subcommittee] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SubcommitteeID", value.SubcommitteeID);
					AddParameter(cmd, "SubcommitteeGroupID", value.IsSubcommitteeGroupIDNull ? DBNull.Value : (object)value.SubcommitteeGroupID);
					AddParameter(cmd, "SubcommitteeName", value.SubcommitteeName);
					AddParameter(cmd, "AppointmentNo", value.AppointmentNo);
					AddParameter(cmd, "IsHeadquarter", value.IsIsHeadquarterNull ? DBNull.Value : (object)value.IsHeadquarter);
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
				Exception ex = new Exception("Set incorrect primarykey PK(SubcommitteeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SubcommitteeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSubcommitteeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSubcommitteeGroupID)
				{
					strUpdate += "[SubcommitteeGroupID]=" + CreateSqlParameterName("SubcommitteeGroupID") + ",";
				}
				if (value._IsSetSubcommitteeName)
				{
					strUpdate += "[SubcommitteeName]=" + CreateSqlParameterName("SubcommitteeName") + ",";
				}
				if (value._IsSetAppointmentNo)
				{
					strUpdate += "[AppointmentNo]=" + CreateSqlParameterName("AppointmentNo") + ",";
				}
				if (value._IsSetIsHeadquarter)
				{
					strUpdate += "[IsHeadquarter]=" + CreateSqlParameterName("IsHeadquarter") + ",";
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
					strUpdate = "UPDATE [dbo].[Subcommittee] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SubcommitteeID", value.SubcommitteeID);
					AddParameter(cmd, "SubcommitteeGroupID", value.IsSubcommitteeGroupIDNull ? DBNull.Value : (object)value.SubcommitteeGroupID);
					AddParameter(cmd, "SubcommitteeName", Sanitizer.GetSafeHtmlFragment(value.SubcommitteeName));
					AddParameter(cmd, "AppointmentNo", Sanitizer.GetSafeHtmlFragment(value.AppointmentNo));
					AddParameter(cmd, "IsHeadquarter", value.IsIsHeadquarterNull ? DBNull.Value : (object)value.IsHeadquarter);
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
				Exception ex = new Exception("Set incorrect primarykey PK(SubcommitteeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int subcommitteeID)
		{
			string whereSql = "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SubcommitteeID", subcommitteeID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public SubcommitteeRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			SubcommitteeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected SubcommitteeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SubcommitteeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SubcommitteeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int subcommitteeIDColumnIndex = reader.GetOrdinal("SubcommitteeID");
			int subcommitteeGroupIDColumnIndex = reader.GetOrdinal("SubcommitteeGroupID");
			int subcommitteeNameColumnIndex = reader.GetOrdinal("SubcommitteeName");
			int appointmentNoColumnIndex = reader.GetOrdinal("AppointmentNo");
			int isHeadquarterColumnIndex = reader.GetOrdinal("IsHeadquarter");
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
					SubcommitteeRow record = new SubcommitteeRow();
					recordList.Add(record);
					record.SubcommitteeID =  Convert.ToInt32(reader.GetValue(subcommitteeIDColumnIndex));
					if (!reader.IsDBNull(subcommitteeGroupIDColumnIndex)) record.SubcommitteeGroupID =  Convert.ToInt32(reader.GetValue(subcommitteeGroupIDColumnIndex));

					if (!reader.IsDBNull(subcommitteeNameColumnIndex)) record.SubcommitteeName =  Convert.ToString(reader.GetValue(subcommitteeNameColumnIndex));

					if (!reader.IsDBNull(appointmentNoColumnIndex)) record.AppointmentNo =  Convert.ToString(reader.GetValue(appointmentNoColumnIndex));

					if (!reader.IsDBNull(isHeadquarterColumnIndex)) record.IsHeadquarter =  Convert.ToBoolean(reader.GetValue(isHeadquarterColumnIndex));

					record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SubcommitteeRow[])(recordList.ToArray(typeof(SubcommitteeRow)));
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
				case "SubcommitteeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubcommitteeGroupID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubcommitteeName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AppointmentNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsHeadquarter":
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

