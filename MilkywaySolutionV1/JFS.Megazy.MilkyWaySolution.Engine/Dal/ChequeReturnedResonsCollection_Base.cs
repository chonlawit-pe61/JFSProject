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
	public partial class ChequeReturnedResonsCollection_Base : MarshalByRefObject
	{
		public const string ChequeReturnedResonsCodeColumnName = "ChequeReturnedResonsCode";
		public const string ChequeReturnedResonsNameColumnName = "ChequeReturnedResonsName";
		public const string RetureTypeColumnName = "RetureType";
		public const string IsActiveColumnName = "IsActive";
		private int _processID;
		public SqlCommand cmd = null;
		public ChequeReturnedResonsCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ChequeReturnedResonsRow[] GetAll()
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
			"[ChequeReturnedResonsCode],"+
			"[ChequeReturnedResonsName],"+
			"[RetureType],"+
			"[IsActive]"+
			" FROM [dbo].[ChequeReturnedResons]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ChequeReturnedResons]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ChequeReturnedResons"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ChequeReturnedResonsCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 2;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ChequeReturnedResonsName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("RetureType",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public ChequeReturnedResonsRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ChequeReturnedResonsRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ChequeReturnedResonsRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ChequeReturnedResonsRow"/> objects.</returns>
		public virtual ChequeReturnedResonsRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ChequeReturnedResons]", top);
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
		public ChequeReturnedResonsRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ChequeReturnedResonsRow[] rows = null;
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
		public DataTable GetChequeReturnedResonsPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ChequeReturnedResonsCode")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ChequeReturnedResonsCode";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[ChequeReturnedResons] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ChequeReturnedResonsCode,ChequeReturnedResonsName,RetureType,IsActive," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [ChequeReturnedResons].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ChequeReturnedResons] " + whereSql +
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
		public ChequeReturnedResonsItemsPaging GetChequeReturnedResonsPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ChequeReturnedResonsCode")
		{
		ChequeReturnedResonsItemsPaging obj = new ChequeReturnedResonsItemsPaging();
		DataTable dt = GetChequeReturnedResonsPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ChequeReturnedResonsItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ChequeReturnedResonsItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ChequeReturnedResonsCode = dt.Rows[i]["ChequeReturnedResonsCode"].ToString();
			record.ChequeReturnedResonsName = dt.Rows[i]["ChequeReturnedResonsName"].ToString();
			record.RetureType = dt.Rows[i]["RetureType"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			recordList.Add(record);
		}
		obj.chequeReturnedResonsItems = (ChequeReturnedResonsItems[])(recordList.ToArray(typeof(ChequeReturnedResonsItems)));
		return obj;
		}
		public ChequeReturnedResonsRow GetByPrimaryKey(string chequeReturnedResonscode)
		{
			string whereSql = "[ChequeReturnedResonsCode]=" + CreateSqlParameterName("ChequeReturnedResonsCode");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ChequeReturnedResonsCode", chequeReturnedResonscode);
			ChequeReturnedResonsRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ChequeReturnedResonsRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ChequeReturnedResons] (" +
			"[ChequeReturnedResonsCode], " + 
			"[ChequeReturnedResonsName], " + 
			"[RetureType], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("ChequeReturnedResonsCode") + ", " +
			CreateSqlParameterName("ChequeReturnedResonsName") + ", " +
			CreateSqlParameterName("RetureType") + ", " +
			CreateSqlParameterName("IsActive") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ChequeReturnedResonsCode",value.ChequeReturnedResonsCode);
			AddParameter(cmd, "ChequeReturnedResonsName", value.ChequeReturnedResonsName);
			AddParameter(cmd, "RetureType", value.RetureType);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ChequeReturnedResonsRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ChequeReturnedResons] (" +
			"[ChequeReturnedResonsCode], " + 
			"[ChequeReturnedResonsName], " + 
			"[RetureType], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("ChequeReturnedResonsCode") + ", " +
			CreateSqlParameterName("ChequeReturnedResonsName") + ", " +
			CreateSqlParameterName("RetureType") + ", " +
			CreateSqlParameterName("IsActive") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ChequeReturnedResonsCode", Sanitizer.GetSafeHtmlFragment(value.ChequeReturnedResonsCode));
			AddParameter(cmd, "ChequeReturnedResonsName", Sanitizer.GetSafeHtmlFragment(value.ChequeReturnedResonsName));
			AddParameter(cmd, "RetureType", Sanitizer.GetSafeHtmlFragment(value.RetureType));
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ChequeReturnedResonsRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetChequeReturnedResonsCode == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetChequeReturnedResonsName)
				{
					strUpdate += "[ChequeReturnedResonsName]=" + CreateSqlParameterName("ChequeReturnedResonsName") + ",";
				}
				if (value._IsSetRetureType)
				{
					strUpdate += "[RetureType]=" + CreateSqlParameterName("RetureType") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ChequeReturnedResons] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ChequeReturnedResonsCode]=" + CreateSqlParameterName("ChequeReturnedResonsCode");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ChequeReturnedResonsCode",value.ChequeReturnedResonsCode);
					AddParameter(cmd, "ChequeReturnedResonsName", value.ChequeReturnedResonsName);
					AddParameter(cmd, "RetureType", value.RetureType);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ChequeReturnedResonsCode)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ChequeReturnedResonsRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetChequeReturnedResonsCode == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetChequeReturnedResonsName)
				{
					strUpdate += "[ChequeReturnedResonsName]=" + CreateSqlParameterName("ChequeReturnedResonsName") + ",";
				}
				if (value._IsSetRetureType)
				{
					strUpdate += "[RetureType]=" + CreateSqlParameterName("RetureType") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ChequeReturnedResons] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ChequeReturnedResonsCode]=" + CreateSqlParameterName("ChequeReturnedResonsCode");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ChequeReturnedResonsCode", Sanitizer.GetSafeHtmlFragment(value.ChequeReturnedResonsCode));
					AddParameter(cmd, "ChequeReturnedResonsName", Sanitizer.GetSafeHtmlFragment(value.ChequeReturnedResonsName));
					AddParameter(cmd, "RetureType", Sanitizer.GetSafeHtmlFragment(value.RetureType));
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ChequeReturnedResonsCode)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(string chequeReturnedResonscode)
		{
			string whereSql = "[ChequeReturnedResonsCode]=" + CreateSqlParameterName("ChequeReturnedResonsCode");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ChequeReturnedResonsCode", chequeReturnedResonscode);
			return 0 < cmd.ExecuteNonQuery();
		}
		public ChequeReturnedResonsRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			ChequeReturnedResonsRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected ChequeReturnedResonsRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ChequeReturnedResonsRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ChequeReturnedResonsRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int chequeReturnedResonscodeColumnIndex = reader.GetOrdinal("ChequeReturnedResonsCode");
			int chequeReturnedResonsNameColumnIndex = reader.GetOrdinal("ChequeReturnedResonsName");
			int retureTypeColumnIndex = reader.GetOrdinal("RetureType");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ChequeReturnedResonsRow record = new ChequeReturnedResonsRow();
					recordList.Add(record);
					record.ChequeReturnedResonsCode =  Convert.ToString(reader.GetValue(chequeReturnedResonscodeColumnIndex));
					if (!reader.IsDBNull(chequeReturnedResonsNameColumnIndex)) record.ChequeReturnedResonsName =  Convert.ToString(reader.GetValue(chequeReturnedResonsNameColumnIndex));

					if (!reader.IsDBNull(retureTypeColumnIndex)) record.RetureType =  Convert.ToString(reader.GetValue(retureTypeColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ChequeReturnedResonsRow[])(recordList.ToArray(typeof(ChequeReturnedResonsRow)));
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
				case "ChequeReturnedResonsCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ChequeReturnedResonsName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RetureType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsActive":
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

