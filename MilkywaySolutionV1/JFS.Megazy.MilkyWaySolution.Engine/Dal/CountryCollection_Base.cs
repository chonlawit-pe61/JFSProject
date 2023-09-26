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
	public partial class CountryCollection_Base : MarshalByRefObject
	{
		public const string CountryCodeColumnName = "CountryCode";
		public const string CountryNameColumnName = "CountryName";
		public const string HasSubCountriesColumnName = "HasSubCountries";
		public const string IsActiveColumnName = "IsActive";
		public const string IsBlockColumnName = "IsBlock";
		private int _processID;
		public SqlCommand cmd = null;
		public CountryCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CountryRow[] GetAll()
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
			"[CountryCode],"+
			"[CountryName],"+
			"[HasSubCountries],"+
			"[IsActive],"+
			"[IsBlock]"+
			" FROM [dbo].[Country]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Country]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Country"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CountryCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CountryName",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("HasSubCountries",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsBlock",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public CountryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CountryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CountryRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CountryRow"/> objects.</returns>
		public virtual CountryRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Country]", top);
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
		public CountryRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CountryRow[] rows = null;
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
		public DataTable GetCountryPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CountryCode")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CountryCode";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(CountryCode) AS TotalRow FROM [dbo].[Country] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CountryCode,CountryName,HasSubCountries,IsActive,IsBlock," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Country] " + whereSql +
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
		public CountryItemsPaging GetCountryPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CountryCode")
		{
		CountryItemsPaging obj = new CountryItemsPaging();
		DataTable dt = GetCountryPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CountryItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CountryItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CountryCode = dt.Rows[i]["CountryCode"].ToString();
			record.CountryName = dt.Rows[i]["CountryName"].ToString();
			if (dt.Rows[i]["HasSubCountries"] != DBNull.Value)
			record.HasSubCountries = Convert.ToBoolean(dt.Rows[i]["HasSubCountries"]);
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["IsBlock"] != DBNull.Value)
			record.IsBlock = Convert.ToBoolean(dt.Rows[i]["IsBlock"]);
			recordList.Add(record);
		}
		obj.countryItems = (CountryItems[])(recordList.ToArray(typeof(CountryItems)));
		return obj;
		}
		public CountryRow GetByPrimaryKey(string countrycode)
		{
			string whereSql = "[CountryCode]=" + CreateSqlParameterName("CountryCode");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CountryCode", countrycode);
			CountryRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CountryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Country] (" +
			"[CountryCode], " + 
			"[CountryName], " + 
			"[HasSubCountries], " + 
			"[IsActive], " + 
			"[IsBlock]			" + 
			") VALUES (" +
			CreateSqlParameterName("CountryCode") + ", " +
			CreateSqlParameterName("CountryName") + ", " +
			CreateSqlParameterName("HasSubCountries") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("IsBlock") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CountryCode",value.CountryCode);
			AddParameter(cmd, "CountryName", value.CountryName);
			AddParameter(cmd, "HasSubCountries", value.IsHasSubCountriesNull ? DBNull.Value : (object)value.HasSubCountries);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "IsBlock", value.IsIsBlockNull ? DBNull.Value : (object)value.IsBlock);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CountryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Country] (" +
			"[CountryCode], " + 
			"[CountryName], " + 
			"[HasSubCountries], " + 
			"[IsActive], " + 
			"[IsBlock]			" + 
			") VALUES (" +
			CreateSqlParameterName("CountryCode") + ", " +
			CreateSqlParameterName("CountryName") + ", " +
			CreateSqlParameterName("HasSubCountries") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("IsBlock") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CountryCode", Sanitizer.GetSafeHtmlFragment(value.CountryCode));
			AddParameter(cmd, "CountryName", Sanitizer.GetSafeHtmlFragment(value.CountryName));
			AddParameter(cmd, "HasSubCountries", value.IsHasSubCountriesNull ? DBNull.Value : (object)value.HasSubCountries);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "IsBlock", value.IsIsBlockNull ? DBNull.Value : (object)value.IsBlock);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CountryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCountryCode == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCountryName)
				{
					strUpdate += "[CountryName]=" + CreateSqlParameterName("CountryName") + ",";
				}
				if (value._IsSetHasSubCountries)
				{
					strUpdate += "[HasSubCountries]=" + CreateSqlParameterName("HasSubCountries") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetIsBlock)
				{
					strUpdate += "[IsBlock]=" + CreateSqlParameterName("IsBlock") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Country] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CountryCode]=" + CreateSqlParameterName("CountryCode");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CountryCode",value.CountryCode);
					AddParameter(cmd, "CountryName", value.CountryName);
					AddParameter(cmd, "HasSubCountries", value.IsHasSubCountriesNull ? DBNull.Value : (object)value.HasSubCountries);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
					AddParameter(cmd, "IsBlock", value.IsIsBlockNull ? DBNull.Value : (object)value.IsBlock);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CountryCode)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CountryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCountryCode == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCountryName)
				{
					strUpdate += "[CountryName]=" + CreateSqlParameterName("CountryName") + ",";
				}
				if (value._IsSetHasSubCountries)
				{
					strUpdate += "[HasSubCountries]=" + CreateSqlParameterName("HasSubCountries") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetIsBlock)
				{
					strUpdate += "[IsBlock]=" + CreateSqlParameterName("IsBlock") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Country] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CountryCode]=" + CreateSqlParameterName("CountryCode");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CountryCode", Sanitizer.GetSafeHtmlFragment(value.CountryCode));
					AddParameter(cmd, "CountryName", Sanitizer.GetSafeHtmlFragment(value.CountryName));
					AddParameter(cmd, "HasSubCountries", value.IsHasSubCountriesNull ? DBNull.Value : (object)value.HasSubCountries);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
					AddParameter(cmd, "IsBlock", value.IsIsBlockNull ? DBNull.Value : (object)value.IsBlock);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CountryCode)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(string countrycode)
		{
			string whereSql = "[CountryCode]=" + CreateSqlParameterName("CountryCode");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CountryCode", countrycode);
			return 0 < cmd.ExecuteNonQuery();
		}
		public CountryRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			CountryRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected CountryRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CountryRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CountryRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int countrycodeColumnIndex = reader.GetOrdinal("CountryCode");
			int countryNameColumnIndex = reader.GetOrdinal("CountryName");
			int hasSubCountriesColumnIndex = reader.GetOrdinal("HasSubCountries");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int isBlockColumnIndex = reader.GetOrdinal("IsBlock");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					CountryRow record = new CountryRow();
					recordList.Add(record);
					record.CountryCode =  Convert.ToString(reader.GetValue(countrycodeColumnIndex));
					if (!reader.IsDBNull(countryNameColumnIndex)) record.CountryName =  Convert.ToString(reader.GetValue(countryNameColumnIndex));

					if (!reader.IsDBNull(hasSubCountriesColumnIndex)) record.HasSubCountries =  Convert.ToBoolean(reader.GetValue(hasSubCountriesColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(isBlockColumnIndex)) record.IsBlock =  Convert.ToBoolean(reader.GetValue(isBlockColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CountryRow[])(recordList.ToArray(typeof(CountryRow)));
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
				case "CountryCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CountryName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "HasSubCountries":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsBlock":
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
