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
	public partial class AbscondingReleasedOnBailCollection_Base : MarshalByRefObject
	{
		public const string EscapeSupportIDColumnName = "EscapeSupportID";
		public const string EscapeStatusColumnName = "EscapeStatus";
		public const string DetailColumnName = "Detail";
		public const string ModifiedColumnName = "Modified";
		private int _processID;
		public SqlCommand cmd = null;
		public AbscondingReleasedOnBailCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual AbscondingReleasedOnBailRow[] GetAll()
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
			"[EscapeSupportID],"+
			"[EscapeStatus],"+
			"[Detail],"+
			"[Modified]"+
			" FROM [dbo].[AbscondingReleasedOnBail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[AbscondingReleasedOnBail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "AbscondingReleasedOnBail"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("EscapeSupportID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EscapeStatus",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Detail",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Modified",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual AbscondingReleasedOnBailRow[] GetByEscapeSupportID(int escapeSupportID)
		{
			return MapRecords(CreateGetByEscapeSupportIDCommand(escapeSupportID));
		}
		public virtual DataTable GetByEscapeSupportIDAsDataTable(int escapeSupportID)
		{
			return MapRecordsToDataTable(CreateGetByEscapeSupportIDCommand(escapeSupportID));
		}
		protected virtual IDbCommand CreateGetByEscapeSupportIDCommand(int escapeSupportID)
		{
			string whereSql = "";
			whereSql += "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "EscapeSupportID", escapeSupportID);
			return cmd;
		}
		public AbscondingReleasedOnBailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual AbscondingReleasedOnBailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="AbscondingReleasedOnBailRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="AbscondingReleasedOnBailRow"/> objects.</returns>
		public virtual AbscondingReleasedOnBailRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[AbscondingReleasedOnBail]", top);
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
		public AbscondingReleasedOnBailRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			AbscondingReleasedOnBailRow[] rows = null;
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
		public DataTable GetAbscondingReleasedOnBailPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "EscapeSupportID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "EscapeSupportID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(EscapeSupportID) AS TotalRow FROM [dbo].[AbscondingReleasedOnBail] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,EscapeSupportID,EscapeStatus,Detail,Modified," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [AbscondingReleasedOnBail].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[AbscondingReleasedOnBail] " + whereSql +
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
		public AbscondingReleasedOnBailItemsPaging GetAbscondingReleasedOnBailPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "EscapeSupportID")
		{
		AbscondingReleasedOnBailItemsPaging obj = new AbscondingReleasedOnBailItemsPaging();
		DataTable dt = GetAbscondingReleasedOnBailPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		AbscondingReleasedOnBailItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new AbscondingReleasedOnBailItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.EscapeSupportID = Convert.ToInt32(dt.Rows[i]["EscapeSupportID"]);
			if (dt.Rows[i]["EscapeStatus"] != DBNull.Value)
			record.EscapeStatus = Convert.ToBoolean(dt.Rows[i]["EscapeStatus"]);
			record.Detail = dt.Rows[i]["Detail"].ToString();
			record.Modified = Convert.ToDateTime(dt.Rows[i]["Modified"]);
			recordList.Add(record);
		}
		obj.abscondingReleasedOnBailItems = (AbscondingReleasedOnBailItems[])(recordList.ToArray(typeof(AbscondingReleasedOnBailItems)));
		return obj;
		}
		public AbscondingReleasedOnBailRow GetByPrimaryKey(int escapeSupportID)
		{
			string whereSql = "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "EscapeSupportID", escapeSupportID);
			AbscondingReleasedOnBailRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(AbscondingReleasedOnBailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[AbscondingReleasedOnBail] (" +
			"[EscapeSupportID], " + 
			"[EscapeStatus], " + 
			"[Detail], " + 
			"[Modified]			" + 
			") VALUES (" +
			CreateSqlParameterName("EscapeSupportID") + ", " +
			CreateSqlParameterName("EscapeStatus") + ", " +
			CreateSqlParameterName("Detail") + ", " +
			CreateSqlParameterName("Modified") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "EscapeSupportID", value.EscapeSupportID);
			AddParameter(cmd, "EscapeStatus", value.IsEscapeStatusNull ? DBNull.Value : (object)value.EscapeStatus);
			AddParameter(cmd, "Detail", value.Detail);
			AddParameter(cmd, "Modified", value.IsModifiedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.Modified);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(AbscondingReleasedOnBailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[AbscondingReleasedOnBail] (" +
			"[EscapeSupportID], " + 
			"[EscapeStatus], " + 
			"[Detail], " + 
			"[Modified]			" + 
			") VALUES (" +
			CreateSqlParameterName("EscapeSupportID") + ", " +
			CreateSqlParameterName("EscapeStatus") + ", " +
			CreateSqlParameterName("Detail") + ", " +
			CreateSqlParameterName("Modified") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "EscapeSupportID", value.EscapeSupportID);
			AddParameter(cmd, "EscapeStatus", value.IsEscapeStatusNull ? DBNull.Value : (object)value.EscapeStatus);
			AddParameter(cmd, "Detail", Sanitizer.GetSafeHtmlFragment(value.Detail));
			AddParameter(cmd, "Modified", value.IsModifiedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.Modified);
			cmd.ExecuteNonQuery();
		}
		public bool Update(AbscondingReleasedOnBailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetEscapeSupportID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetEscapeStatus)
				{
					strUpdate += "[EscapeStatus]=" + CreateSqlParameterName("EscapeStatus") + ",";
				}
				if (value._IsSetDetail)
				{
					strUpdate += "[Detail]=" + CreateSqlParameterName("Detail") + ",";
				}
				if (value._IsSetModified)
				{
					strUpdate += "[Modified]=" + CreateSqlParameterName("Modified") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[AbscondingReleasedOnBail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "EscapeSupportID", value.EscapeSupportID);
					AddParameter(cmd, "EscapeStatus", value.IsEscapeStatusNull ? DBNull.Value : (object)value.EscapeStatus);
					AddParameter(cmd, "Detail", value.Detail);
					AddParameter(cmd, "Modified", value.IsModifiedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.Modified);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(EscapeSupportID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(AbscondingReleasedOnBailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetEscapeSupportID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetEscapeStatus)
				{
					strUpdate += "[EscapeStatus]=" + CreateSqlParameterName("EscapeStatus") + ",";
				}
				if (value._IsSetDetail)
				{
					strUpdate += "[Detail]=" + CreateSqlParameterName("Detail") + ",";
				}
				if (value._IsSetModified)
				{
					strUpdate += "[Modified]=" + CreateSqlParameterName("Modified") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[AbscondingReleasedOnBail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "EscapeSupportID", value.EscapeSupportID);
					AddParameter(cmd, "EscapeStatus", value.IsEscapeStatusNull ? DBNull.Value : (object)value.EscapeStatus);
					AddParameter(cmd, "Detail", Sanitizer.GetSafeHtmlFragment(value.Detail));
					AddParameter(cmd, "Modified", value.IsModifiedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.Modified);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(EscapeSupportID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int escapeSupportID)
		{
			string whereSql = "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "EscapeSupportID", escapeSupportID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByEscapeSupportID(int escapeSupportID)
		{
			return CreateDeleteByEscapeSupportIDCommand(escapeSupportID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByEscapeSupportIDCommand(int escapeSupportID)
		{
			string whereSql = "";
			whereSql += "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "EscapeSupportID", escapeSupportID);
			return cmd;
		}
		protected AbscondingReleasedOnBailRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected AbscondingReleasedOnBailRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected AbscondingReleasedOnBailRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int escapeSupportIDColumnIndex = reader.GetOrdinal("EscapeSupportID");
			int escapeStatusColumnIndex = reader.GetOrdinal("EscapeStatus");
			int detailColumnIndex = reader.GetOrdinal("Detail");
			int modifiedColumnIndex = reader.GetOrdinal("Modified");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					AbscondingReleasedOnBailRow record = new AbscondingReleasedOnBailRow();
					recordList.Add(record);
					record.EscapeSupportID =  Convert.ToInt32(reader.GetValue(escapeSupportIDColumnIndex));
					if (!reader.IsDBNull(escapeStatusColumnIndex)) record.EscapeStatus =  Convert.ToBoolean(reader.GetValue(escapeStatusColumnIndex));

					if (!reader.IsDBNull(detailColumnIndex)) record.Detail =  Convert.ToString(reader.GetValue(detailColumnIndex));

					record.Modified =  Convert.ToDateTime(reader.GetValue(modifiedColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (AbscondingReleasedOnBailRow[])(recordList.ToArray(typeof(AbscondingReleasedOnBailRow)));
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
				case "EscapeSupportID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "EscapeStatus":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Detail":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Modified":
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

