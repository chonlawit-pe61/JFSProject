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
	public partial class ProvinceMSCCollection_Base : MarshalByRefObject
	{
		public const string provIdColumnName = "provId";
		public const string provNameColumnName = "provName";
		public const string regnIdColumnName = "regnId";
		public const string flagColumnName = "flag";
		public const string BelongJFSProvinceIDColumnName = "BelongJFSProvinceID";
		private int _processID;
		public SqlCommand cmd = null;
		public ProvinceMSCCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ProvinceMSCRow[] GetAll()
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
			"[provId],"+
			"[provName],"+
			"[regnId],"+
			"[flag],"+
			"[BelongJFSProvinceID]"+
			" FROM [dbo].[ProvinceMSC]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ProvinceMSC]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ProvinceMSC"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("provId",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("provName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("regnId",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("flag",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BelongJFSProvinceID",Type.GetType("System.Int32"));
			return dataTable;
		}
		public virtual ProvinceMSCRow[] GetByBelongJFSProvinceID(int belongJFSProvinceID)
		{
			return MapRecords(CreateGetByBelongJFSProvinceIDCommand(belongJFSProvinceID));
		}
		public virtual DataTable GetByBelongJFSProvinceIDAsDataTable(int belongJFSProvinceID)
		{
			return MapRecordsToDataTable(CreateGetByBelongJFSProvinceIDCommand(belongJFSProvinceID));
		}
		protected virtual IDbCommand CreateGetByBelongJFSProvinceIDCommand(int belongJFSProvinceID)
		{
			string whereSql = "";
			whereSql += "[BelongJFSProvinceID]=" + CreateSqlParameterName("BelongJFSProvinceID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "BelongJFSProvinceID", belongJFSProvinceID);
			return cmd;
		}
		public ProvinceMSCRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ProvinceMSCRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ProvinceMSCRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ProvinceMSCRow"/> objects.</returns>
		public virtual ProvinceMSCRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ProvinceMSC]", top);
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
		public ProvinceMSCRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ProvinceMSCRow[] rows = null;
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
		public DataTable GetProvinceMSCPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "provId")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "provId";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[ProvinceMSC] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,provId,provName,regnId,flag,BelongJFSProvinceID," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [ProvinceMSC].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ProvinceMSC] " + whereSql +
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
		public ProvinceMSCItemsPaging GetProvinceMSCPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "provId")
		{
		ProvinceMSCItemsPaging obj = new ProvinceMSCItemsPaging();
		DataTable dt = GetProvinceMSCPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ProvinceMSCItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ProvinceMSCItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.provId = Convert.ToInt32(dt.Rows[i]["provId"]);
			record.provName = dt.Rows[i]["provName"].ToString();
			record.regnId = Convert.ToInt32(dt.Rows[i]["regnId"]);
			record.flag = Convert.ToBoolean(dt.Rows[i]["flag"]);
			if (dt.Rows[i]["BelongJFSProvinceID"] != DBNull.Value)
			record.BelongJFSProvinceID = Convert.ToInt32(dt.Rows[i]["BelongJFSProvinceID"]);
			recordList.Add(record);
		}
		obj.provinceMSCItems = (ProvinceMSCItems[])(recordList.ToArray(typeof(ProvinceMSCItems)));
		return obj;
		}
		public ProvinceMSCRow GetByPrimaryKey(int provId)
		{
			string whereSql = "[provId]=" + CreateSqlParameterName("provId");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "provId", provId);
			ProvinceMSCRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ProvinceMSCRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProvinceMSC] (" +
			"[provId], " + 
			"[provName], " + 
			"[regnId], " + 
			"[flag], " + 
			"[BelongJFSProvinceID]			" + 
			") VALUES (" +
			CreateSqlParameterName("provId") + ", " +
			CreateSqlParameterName("provName") + ", " +
			CreateSqlParameterName("regnId") + ", " +
			CreateSqlParameterName("flag") + ", " +
			CreateSqlParameterName("BelongJFSProvinceID") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "provId", value.provId);
			AddParameter(cmd, "provName",value.provName);
			AddParameter(cmd, "regnId", value.regnId);
			AddParameter(cmd, "flag", value.flag);
			AddParameter(cmd, "BelongJFSProvinceID", value.IsBelongJFSProvinceIDNull ? DBNull.Value : (object)value.BelongJFSProvinceID);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ProvinceMSCRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProvinceMSC] (" +
			"[provId], " + 
			"[provName], " + 
			"[regnId], " + 
			"[flag], " + 
			"[BelongJFSProvinceID]			" + 
			") VALUES (" +
			CreateSqlParameterName("provId") + ", " +
			CreateSqlParameterName("provName") + ", " +
			CreateSqlParameterName("regnId") + ", " +
			CreateSqlParameterName("flag") + ", " +
			CreateSqlParameterName("BelongJFSProvinceID") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "provId", value.provId);
			AddParameter(cmd, "provName", Sanitizer.GetSafeHtmlFragment(value.provName));
			AddParameter(cmd, "regnId", value.regnId);
			AddParameter(cmd, "flag", value.flag);
			AddParameter(cmd, "BelongJFSProvinceID", value.IsBelongJFSProvinceIDNull ? DBNull.Value : (object)value.BelongJFSProvinceID);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ProvinceMSCRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetprovId == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetprovName)
				{
					strUpdate += "[provName]=" + CreateSqlParameterName("provName") + ",";
				}
				if (value._IsSetregnId)
				{
					strUpdate += "[regnId]=" + CreateSqlParameterName("regnId") + ",";
				}
				if (value._IsSetflag)
				{
					strUpdate += "[flag]=" + CreateSqlParameterName("flag") + ",";
				}
				if (value._IsSetBelongJFSProvinceID)
				{
					strUpdate += "[BelongJFSProvinceID]=" + CreateSqlParameterName("BelongJFSProvinceID") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProvinceMSC] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[provId]=" + CreateSqlParameterName("provId");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "provId", value.provId);
					AddParameter(cmd, "provName",value.provName);
					AddParameter(cmd, "regnId", value.regnId);
					AddParameter(cmd, "flag", value.flag);
					AddParameter(cmd, "BelongJFSProvinceID", value.IsBelongJFSProvinceIDNull ? DBNull.Value : (object)value.BelongJFSProvinceID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(provId)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ProvinceMSCRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetprovId == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetprovName)
				{
					strUpdate += "[provName]=" + CreateSqlParameterName("provName") + ",";
				}
				if (value._IsSetregnId)
				{
					strUpdate += "[regnId]=" + CreateSqlParameterName("regnId") + ",";
				}
				if (value._IsSetflag)
				{
					strUpdate += "[flag]=" + CreateSqlParameterName("flag") + ",";
				}
				if (value._IsSetBelongJFSProvinceID)
				{
					strUpdate += "[BelongJFSProvinceID]=" + CreateSqlParameterName("BelongJFSProvinceID") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProvinceMSC] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[provId]=" + CreateSqlParameterName("provId");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "provId", value.provId);
					AddParameter(cmd, "provName", Sanitizer.GetSafeHtmlFragment(value.provName));
					AddParameter(cmd, "regnId", value.regnId);
					AddParameter(cmd, "flag", value.flag);
					AddParameter(cmd, "BelongJFSProvinceID", value.IsBelongJFSProvinceIDNull ? DBNull.Value : (object)value.BelongJFSProvinceID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(provId)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int provId)
		{
			string whereSql = "[provId]=" + CreateSqlParameterName("provId");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "provId", provId);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByBelongJFSProvinceID(int belongJFSProvinceID)
		{
			return DeleteByBelongJFSProvinceID(belongJFSProvinceID, false);
		}
		public int DeleteByBelongJFSProvinceID(int belongJFSProvinceID, bool belongJFSProvinceIDNull)
		{
			return CreateDeleteByBelongJFSProvinceIDCommand(belongJFSProvinceID, belongJFSProvinceIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByBelongJFSProvinceIDCommand(int belongJFSProvinceID, bool belongJFSProvinceIDNull)
		{
			string whereSql = "";
			if (belongJFSProvinceIDNull)
				whereSql += "[BelongJFSProvinceID] IS NULL";
			else
				whereSql += "[BelongJFSProvinceID]=" + CreateSqlParameterName("BelongJFSProvinceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!belongJFSProvinceIDNull)
				AddParameter(cmd, "BelongJFSProvinceID", belongJFSProvinceID);
			return cmd;
		}
		protected ProvinceMSCRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ProvinceMSCRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ProvinceMSCRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int provIdColumnIndex = reader.GetOrdinal("provId");
			int provNameColumnIndex = reader.GetOrdinal("provName");
			int regnIdColumnIndex = reader.GetOrdinal("regnId");
			int flagColumnIndex = reader.GetOrdinal("flag");
			int belongJFSProvinceIDColumnIndex = reader.GetOrdinal("BelongJFSProvinceID");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ProvinceMSCRow record = new ProvinceMSCRow();
					recordList.Add(record);
					record.provId =  Convert.ToInt32(reader.GetValue(provIdColumnIndex));
					record.provName =  Convert.ToString(reader.GetValue(provNameColumnIndex));
					record.regnId =  Convert.ToInt32(reader.GetValue(regnIdColumnIndex));
					record.flag =  Convert.ToBoolean(reader.GetValue(flagColumnIndex));
					if (!reader.IsDBNull(belongJFSProvinceIDColumnIndex)) record.BelongJFSProvinceID =  Convert.ToInt32(reader.GetValue(belongJFSProvinceIDColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ProvinceMSCRow[])(recordList.ToArray(typeof(ProvinceMSCRow)));
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
				case "provId":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "provName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "regnId":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "flag":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "BelongJFSProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

