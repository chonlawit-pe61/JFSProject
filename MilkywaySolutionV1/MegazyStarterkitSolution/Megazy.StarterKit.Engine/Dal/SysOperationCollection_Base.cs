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
	public partial class SysOperationCollection_Base : MarshalByRefObject
	{
		public const string OperationIDColumnName = "OperationID";
		public const string OperationNameColumnName = "OperationName";
		public const string IsCreateColumnName = "IsCreate";
		public const string IsReadColumnName = "IsRead";
		public const string IsUpdateColumnName = "IsUpdate";
		public const string IsDeleteColumnName = "IsDelete";
		public const string IsLockColumnName = "IsLock";
		private int _processID;
		public SqlCommand cmd = null;
		public SysOperationCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SysOperationRow[] GetAll()
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
			"[OperationID],"+
			"[OperationName],"+
			"[IsCreate],"+
			"[IsRead],"+
			"[IsUpdate],"+
			"[IsDelete],"+
			"[IsLock]"+
			" FROM [dbo].[SysOperation]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[SysOperation]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "SysOperation"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("OperationID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OperationName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsCreate",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsRead",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsUpdate",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsDelete",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsLock",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public SysOperationRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SysOperationRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SysOperationRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SysOperationRow"/> objects.</returns>
		public virtual SysOperationRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[SysOperation]", top);
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
		public SysOperationRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SysOperationRow[] rows = null;
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
		public DataTable GetSysOperationPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "OperationID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "OperationID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(OperationID) AS TotalRow FROM [dbo].[SysOperation] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,OperationID,OperationName,IsCreate,IsRead,IsUpdate,IsDelete,IsLock," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[SysOperation] " + whereSql +
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
		public SysOperationItemsPaging GetSysOperationPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "OperationID")
		{
		SysOperationItemsPaging obj = new SysOperationItemsPaging();
		DataTable dt = GetSysOperationPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SysOperationItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SysOperationItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.OperationID = Convert.ToInt32(dt.Rows[i]["OperationID"]);
			record.OperationName = dt.Rows[i]["OperationName"].ToString();
			if (dt.Rows[i]["IsCreate"] != DBNull.Value)
			record.IsCreate = Convert.ToBoolean(dt.Rows[i]["IsCreate"]);
			if (dt.Rows[i]["IsRead"] != DBNull.Value)
			record.IsRead = Convert.ToBoolean(dt.Rows[i]["IsRead"]);
			if (dt.Rows[i]["IsUpdate"] != DBNull.Value)
			record.IsUpdate = Convert.ToBoolean(dt.Rows[i]["IsUpdate"]);
			if (dt.Rows[i]["IsDelete"] != DBNull.Value)
			record.IsDelete = Convert.ToBoolean(dt.Rows[i]["IsDelete"]);
			if (dt.Rows[i]["IsLock"] != DBNull.Value)
			record.IsLock = Convert.ToBoolean(dt.Rows[i]["IsLock"]);
			recordList.Add(record);
		}
		obj.sysOperationItems = (SysOperationItems[])(recordList.ToArray(typeof(SysOperationItems)));
		return obj;
		}
		public SysOperationRow GetByPrimaryKey(int operationID)
		{
			string whereSql = "[OperationID]=" + CreateSqlParameterName("OperationID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "OperationID", operationID);
			SysOperationRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(SysOperationRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SysOperation] (" +
			"[OperationID], " + 
			"[OperationName], " + 
			"[IsCreate], " + 
			"[IsRead], " + 
			"[IsUpdate], " + 
			"[IsDelete], " + 
			"[IsLock]			" + 
			") VALUES (" +
			CreateSqlParameterName("OperationID") + ", " +
			CreateSqlParameterName("OperationName") + ", " +
			CreateSqlParameterName("IsCreate") + ", " +
			CreateSqlParameterName("IsRead") + ", " +
			CreateSqlParameterName("IsUpdate") + ", " +
			CreateSqlParameterName("IsDelete") + ", " +
			CreateSqlParameterName("IsLock") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "OperationID", value.OperationID);
			AddParameter(cmd, "OperationName", value.OperationName);
			AddParameter(cmd, "IsCreate", value.IsIsCreateNull ? DBNull.Value : (object)value.IsCreate);
			AddParameter(cmd, "IsRead", value.IsIsReadNull ? DBNull.Value : (object)value.IsRead);
			AddParameter(cmd, "IsUpdate", value.IsIsUpdateNull ? DBNull.Value : (object)value.IsUpdate);
			AddParameter(cmd, "IsDelete", value.IsIsDeleteNull ? DBNull.Value : (object)value.IsDelete);
			AddParameter(cmd, "IsLock", value.IsIsLockNull ? DBNull.Value : (object)value.IsLock);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(SysOperationRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SysOperation] (" +
			"[OperationID], " + 
			"[OperationName], " + 
			"[IsCreate], " + 
			"[IsRead], " + 
			"[IsUpdate], " + 
			"[IsDelete], " + 
			"[IsLock]			" + 
			") VALUES (" +
			CreateSqlParameterName("OperationID") + ", " +
			CreateSqlParameterName("OperationName") + ", " +
			CreateSqlParameterName("IsCreate") + ", " +
			CreateSqlParameterName("IsRead") + ", " +
			CreateSqlParameterName("IsUpdate") + ", " +
			CreateSqlParameterName("IsDelete") + ", " +
			CreateSqlParameterName("IsLock") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "OperationID", value.OperationID);
			AddParameter(cmd, "OperationName", Sanitizer.GetSafeHtmlFragment(value.OperationName));
			AddParameter(cmd, "IsCreate", value.IsIsCreateNull ? DBNull.Value : (object)value.IsCreate);
			AddParameter(cmd, "IsRead", value.IsIsReadNull ? DBNull.Value : (object)value.IsRead);
			AddParameter(cmd, "IsUpdate", value.IsIsUpdateNull ? DBNull.Value : (object)value.IsUpdate);
			AddParameter(cmd, "IsDelete", value.IsIsDeleteNull ? DBNull.Value : (object)value.IsDelete);
			AddParameter(cmd, "IsLock", value.IsIsLockNull ? DBNull.Value : (object)value.IsLock);
			cmd.ExecuteNonQuery();
		}
		public bool Update(SysOperationRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetOperationID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetOperationName)
				{
					strUpdate += "[OperationName]=" + CreateSqlParameterName("OperationName") + ",";
				}
				if (value._IsSetIsCreate)
				{
					strUpdate += "[IsCreate]=" + CreateSqlParameterName("IsCreate") + ",";
				}
				if (value._IsSetIsRead)
				{
					strUpdate += "[IsRead]=" + CreateSqlParameterName("IsRead") + ",";
				}
				if (value._IsSetIsUpdate)
				{
					strUpdate += "[IsUpdate]=" + CreateSqlParameterName("IsUpdate") + ",";
				}
				if (value._IsSetIsDelete)
				{
					strUpdate += "[IsDelete]=" + CreateSqlParameterName("IsDelete") + ",";
				}
				if (value._IsSetIsLock)
				{
					strUpdate += "[IsLock]=" + CreateSqlParameterName("IsLock") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SysOperation] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[OperationID]=" + CreateSqlParameterName("OperationID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "OperationID", value.OperationID);
					AddParameter(cmd, "OperationName", value.OperationName);
					AddParameter(cmd, "IsCreate", value.IsIsCreateNull ? DBNull.Value : (object)value.IsCreate);
					AddParameter(cmd, "IsRead", value.IsIsReadNull ? DBNull.Value : (object)value.IsRead);
					AddParameter(cmd, "IsUpdate", value.IsIsUpdateNull ? DBNull.Value : (object)value.IsUpdate);
					AddParameter(cmd, "IsDelete", value.IsIsDeleteNull ? DBNull.Value : (object)value.IsDelete);
					AddParameter(cmd, "IsLock", value.IsIsLockNull ? DBNull.Value : (object)value.IsLock);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(OperationID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SysOperationRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetOperationID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetOperationName)
				{
					strUpdate += "[OperationName]=" + CreateSqlParameterName("OperationName") + ",";
				}
				if (value._IsSetIsCreate)
				{
					strUpdate += "[IsCreate]=" + CreateSqlParameterName("IsCreate") + ",";
				}
				if (value._IsSetIsRead)
				{
					strUpdate += "[IsRead]=" + CreateSqlParameterName("IsRead") + ",";
				}
				if (value._IsSetIsUpdate)
				{
					strUpdate += "[IsUpdate]=" + CreateSqlParameterName("IsUpdate") + ",";
				}
				if (value._IsSetIsDelete)
				{
					strUpdate += "[IsDelete]=" + CreateSqlParameterName("IsDelete") + ",";
				}
				if (value._IsSetIsLock)
				{
					strUpdate += "[IsLock]=" + CreateSqlParameterName("IsLock") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SysOperation] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[OperationID]=" + CreateSqlParameterName("OperationID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "OperationID", value.OperationID);
					AddParameter(cmd, "OperationName", Sanitizer.GetSafeHtmlFragment(value.OperationName));
					AddParameter(cmd, "IsCreate", value.IsIsCreateNull ? DBNull.Value : (object)value.IsCreate);
					AddParameter(cmd, "IsRead", value.IsIsReadNull ? DBNull.Value : (object)value.IsRead);
					AddParameter(cmd, "IsUpdate", value.IsIsUpdateNull ? DBNull.Value : (object)value.IsUpdate);
					AddParameter(cmd, "IsDelete", value.IsIsDeleteNull ? DBNull.Value : (object)value.IsDelete);
					AddParameter(cmd, "IsLock", value.IsIsLockNull ? DBNull.Value : (object)value.IsLock);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(OperationID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int operationID)
		{
			string whereSql = "[OperationID]=" + CreateSqlParameterName("OperationID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "OperationID", operationID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected SysOperationRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SysOperationRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SysOperationRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int operationIDColumnIndex = reader.GetOrdinal("OperationID");
			int operationNameColumnIndex = reader.GetOrdinal("OperationName");
			int isCreateColumnIndex = reader.GetOrdinal("IsCreate");
			int isReadColumnIndex = reader.GetOrdinal("IsRead");
			int isUpdateColumnIndex = reader.GetOrdinal("IsUpdate");
			int isDeleteColumnIndex = reader.GetOrdinal("IsDelete");
			int isLockColumnIndex = reader.GetOrdinal("IsLock");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					SysOperationRow record = new SysOperationRow();
					recordList.Add(record);
					record.OperationID =  Convert.ToInt32(reader.GetValue(operationIDColumnIndex));
					if (!reader.IsDBNull(operationNameColumnIndex)) record.OperationName =  Convert.ToString(reader.GetValue(operationNameColumnIndex));

					if (!reader.IsDBNull(isCreateColumnIndex)) record.IsCreate =  Convert.ToBoolean(reader.GetValue(isCreateColumnIndex));

					if (!reader.IsDBNull(isReadColumnIndex)) record.IsRead =  Convert.ToBoolean(reader.GetValue(isReadColumnIndex));

					if (!reader.IsDBNull(isUpdateColumnIndex)) record.IsUpdate =  Convert.ToBoolean(reader.GetValue(isUpdateColumnIndex));

					if (!reader.IsDBNull(isDeleteColumnIndex)) record.IsDelete =  Convert.ToBoolean(reader.GetValue(isDeleteColumnIndex));

					if (!reader.IsDBNull(isLockColumnIndex)) record.IsLock =  Convert.ToBoolean(reader.GetValue(isLockColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SysOperationRow[])(recordList.ToArray(typeof(SysOperationRow)));
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
				case "OperationID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OperationName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsCreate":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsRead":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsUpdate":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsDelete":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsLock":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

