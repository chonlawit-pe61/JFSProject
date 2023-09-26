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
	public partial class BailOutCollection_Base : MarshalByRefObject
	{
		public const string BailIDColumnName = "BailID";
		public const string BailOutLevelIDColumnName = "BailOutLevelID";
		public const string BailAtColumnName = "BailAt";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public BailOutCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual BailOutRow[] GetAll()
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
			"[BailID],"+
			"[BailOutLevelID],"+
			"[BailAt],"+
			"[ModifiedDate]"+
			" FROM [dbo].[BailOut]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[BailOut]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "BailOut"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("BailID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BailOutLevelID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("BailAt",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual BailOutRow[] GetByBailOutLevelID(int bailOutLevelID)
		{
			return MapRecords(CreateGetByBailOutLevelIDCommand(bailOutLevelID));
		}
		public virtual DataTable GetByBailOutLevelIDAsDataTable(int bailOutLevelID)
		{
			return MapRecordsToDataTable(CreateGetByBailOutLevelIDCommand(bailOutLevelID));
		}
		protected virtual IDbCommand CreateGetByBailOutLevelIDCommand(int bailOutLevelID)
		{
			string whereSql = "";
			whereSql += "[BailOutLevelID]=" + CreateSqlParameterName("BailOutLevelID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "BailOutLevelID", bailOutLevelID);
			return cmd;
		}
		public BailOutRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual BailOutRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="BailOutRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="BailOutRow"/> objects.</returns>
		public virtual BailOutRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[BailOut]", top);
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
		public BailOutRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			BailOutRow[] rows = null;
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
		public DataTable GetBailOutPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "BailID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "BailID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(BailID) AS TotalRow FROM [dbo].[BailOut] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,BailID,BailOutLevelID,BailAt,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[BailOut] " + whereSql +
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
		public BailOutItemsPaging GetBailOutPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "BailID")
		{
		BailOutItemsPaging obj = new BailOutItemsPaging();
		DataTable dt = GetBailOutPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		BailOutItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new BailOutItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.BailID = Convert.ToInt32(dt.Rows[i]["BailID"]);
			if (dt.Rows[i]["BailOutLevelID"] != DBNull.Value)
			record.BailOutLevelID = Convert.ToInt32(dt.Rows[i]["BailOutLevelID"]);
			record.BailAt = dt.Rows[i]["BailAt"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.bailOutItems = (BailOutItems[])(recordList.ToArray(typeof(BailOutItems)));
		return obj;
		}
		public BailOutRow GetByPrimaryKey(int bailID)
		{
			string whereSql = "[BailID]=" + CreateSqlParameterName("BailID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "BailID", bailID);
			BailOutRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(BailOutRow value)		{
			string sqlStr = "INSERT INTO [dbo].[BailOut] (" +
			"[BailID], " + 
			"[BailOutLevelID], " + 
			"[BailAt], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("BailID") + ", " +
			CreateSqlParameterName("BailOutLevelID") + ", " +
			CreateSqlParameterName("BailAt") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "BailID", value.BailID);
			AddParameter(cmd, "BailOutLevelID", value.IsBailOutLevelIDNull ? DBNull.Value : (object)value.BailOutLevelID);
			AddParameter(cmd, "BailAt", value.BailAt);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(BailOutRow value)		{
			string sqlStr = "INSERT INTO [dbo].[BailOut] (" +
			"[BailID], " + 
			"[BailOutLevelID], " + 
			"[BailAt], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("BailID") + ", " +
			CreateSqlParameterName("BailOutLevelID") + ", " +
			CreateSqlParameterName("BailAt") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "BailID", value.BailID);
			AddParameter(cmd, "BailOutLevelID", value.IsBailOutLevelIDNull ? DBNull.Value : (object)value.BailOutLevelID);
			AddParameter(cmd, "BailAt", Sanitizer.GetSafeHtmlFragment(value.BailAt));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(BailOutRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetBailID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetBailOutLevelID)
				{
					strUpdate += "[BailOutLevelID]=" + CreateSqlParameterName("BailOutLevelID") + ",";
				}
				if (value._IsSetBailAt)
				{
					strUpdate += "[BailAt]=" + CreateSqlParameterName("BailAt") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[BailOut] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[BailID]=" + CreateSqlParameterName("BailID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "BailID", value.BailID);
					AddParameter(cmd, "BailOutLevelID", value.IsBailOutLevelIDNull ? DBNull.Value : (object)value.BailOutLevelID);
					AddParameter(cmd, "BailAt", value.BailAt);
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
				Exception ex = new Exception("Set incorrect primarykey PK(BailID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(BailOutRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetBailID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetBailOutLevelID)
				{
					strUpdate += "[BailOutLevelID]=" + CreateSqlParameterName("BailOutLevelID") + ",";
				}
				if (value._IsSetBailAt)
				{
					strUpdate += "[BailAt]=" + CreateSqlParameterName("BailAt") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[BailOut] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[BailID]=" + CreateSqlParameterName("BailID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "BailID", value.BailID);
					AddParameter(cmd, "BailOutLevelID", value.IsBailOutLevelIDNull ? DBNull.Value : (object)value.BailOutLevelID);
					AddParameter(cmd, "BailAt", Sanitizer.GetSafeHtmlFragment(value.BailAt));
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
				Exception ex = new Exception("Set incorrect primarykey PK(BailID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int bailID)
		{
			string whereSql = "[BailID]=" + CreateSqlParameterName("BailID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "BailID", bailID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByBailOutLevelID(int bailOutLevelID)
		{
			return DeleteByBailOutLevelID(bailOutLevelID, false);
		}
		public int DeleteByBailOutLevelID(int bailOutLevelID, bool bailOutLevelIDNull)
		{
			return CreateDeleteByBailOutLevelIDCommand(bailOutLevelID, bailOutLevelIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByBailOutLevelIDCommand(int bailOutLevelID, bool bailOutLevelIDNull)
		{
			string whereSql = "";
			if (bailOutLevelIDNull)
				whereSql += "[BailOutLevelID] IS NULL";
			else
				whereSql += "[BailOutLevelID]=" + CreateSqlParameterName("BailOutLevelID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!bailOutLevelIDNull)
				AddParameter(cmd, "BailOutLevelID", bailOutLevelID);
			return cmd;
		}
		protected BailOutRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected BailOutRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected BailOutRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int bailIDColumnIndex = reader.GetOrdinal("BailID");
			int bailOutLevelIDColumnIndex = reader.GetOrdinal("BailOutLevelID");
			int bailAtColumnIndex = reader.GetOrdinal("BailAt");
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
					BailOutRow record = new BailOutRow();
					recordList.Add(record);
					record.BailID =  Convert.ToInt32(reader.GetValue(bailIDColumnIndex));
					if (!reader.IsDBNull(bailOutLevelIDColumnIndex)) record.BailOutLevelID =  Convert.ToInt32(reader.GetValue(bailOutLevelIDColumnIndex));

					if (!reader.IsDBNull(bailAtColumnIndex)) record.BailAt =  Convert.ToString(reader.GetValue(bailAtColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (BailOutRow[])(recordList.ToArray(typeof(BailOutRow)));
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
				case "BailID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "BailOutLevelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "BailAt":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

