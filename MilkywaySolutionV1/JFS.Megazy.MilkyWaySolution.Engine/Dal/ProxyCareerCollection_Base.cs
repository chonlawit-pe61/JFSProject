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
	public partial class ProxyCareerCollection_Base : MarshalByRefObject
	{
		public const string ProxyIDColumnName = "ProxyID";
		public const string CareerColumnName = "Career";
		public const string IncomeColumnName = "Income";
		public const string IncomeUnitColumnName = "IncomeUnit";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ProxyCareerCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ProxyCareerRow[] GetAll()
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
			"[ProxyID],"+
			"[Career],"+
			"[Income],"+
			"[IncomeUnit],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ProxyCareer]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ProxyCareer]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ProxyCareer"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ProxyID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Career",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Income",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("IncomeUnit",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public ProxyCareerRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ProxyCareerRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ProxyCareerRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ProxyCareerRow"/> objects.</returns>
		public virtual ProxyCareerRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ProxyCareer]", top);
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
		public ProxyCareerRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ProxyCareerRow[] rows = null;
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
		public DataTable GetProxyCareerPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProxyID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ProxyID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ProxyID) AS TotalRow FROM [dbo].[ProxyCareer] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ProxyID,Career,Income,IncomeUnit,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ProxyCareer] " + whereSql +
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
		public ProxyCareerItemsPaging GetProxyCareerPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProxyID")
		{
		ProxyCareerItemsPaging obj = new ProxyCareerItemsPaging();
		DataTable dt = GetProxyCareerPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ProxyCareerItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ProxyCareerItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ProxyID = Convert.ToInt32(dt.Rows[i]["ProxyID"]);
			record.Career = dt.Rows[i]["Career"].ToString();
			if (dt.Rows[i]["Income"] != DBNull.Value)
			record.Income = Convert.ToDouble(dt.Rows[i]["Income"]);
			record.IncomeUnit = dt.Rows[i]["IncomeUnit"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.proxyCareerItems = (ProxyCareerItems[])(recordList.ToArray(typeof(ProxyCareerItems)));
		return obj;
		}
		public ProxyCareerRow GetByPrimaryKey(int proxyID)
		{
			string whereSql = "[ProxyID]=" + CreateSqlParameterName("ProxyID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProxyID", proxyID);
			ProxyCareerRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ProxyCareerRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProxyCareer] (" +
			"[ProxyID], " + 
			"[Career], " + 
			"[Income], " + 
			"[IncomeUnit], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProxyID") + ", " +
			CreateSqlParameterName("Career") + ", " +
			CreateSqlParameterName("Income") + ", " +
			CreateSqlParameterName("IncomeUnit") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProxyID", value.ProxyID);
			AddParameter(cmd, "Career", value.Career);
			AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
			AddParameter(cmd, "IncomeUnit", value.IncomeUnit);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ProxyCareerRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProxyCareer] (" +
			"[ProxyID], " + 
			"[Career], " + 
			"[Income], " + 
			"[IncomeUnit], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProxyID") + ", " +
			CreateSqlParameterName("Career") + ", " +
			CreateSqlParameterName("Income") + ", " +
			CreateSqlParameterName("IncomeUnit") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProxyID", value.ProxyID);
			AddParameter(cmd, "Career", Sanitizer.GetSafeHtmlFragment(value.Career));
			AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
			AddParameter(cmd, "IncomeUnit", Sanitizer.GetSafeHtmlFragment(value.IncomeUnit));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ProxyCareerRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProxyID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCareer)
				{
					strUpdate += "[Career]=" + CreateSqlParameterName("Career") + ",";
				}
				if (value._IsSetIncome)
				{
					strUpdate += "[Income]=" + CreateSqlParameterName("Income") + ",";
				}
				if (value._IsSetIncomeUnit)
				{
					strUpdate += "[IncomeUnit]=" + CreateSqlParameterName("IncomeUnit") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProxyCareer] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProxyID]=" + CreateSqlParameterName("ProxyID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProxyID", value.ProxyID);
					AddParameter(cmd, "Career", value.Career);
					AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
					AddParameter(cmd, "IncomeUnit", value.IncomeUnit);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ProxyID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ProxyCareerRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProxyID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCareer)
				{
					strUpdate += "[Career]=" + CreateSqlParameterName("Career") + ",";
				}
				if (value._IsSetIncome)
				{
					strUpdate += "[Income]=" + CreateSqlParameterName("Income") + ",";
				}
				if (value._IsSetIncomeUnit)
				{
					strUpdate += "[IncomeUnit]=" + CreateSqlParameterName("IncomeUnit") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProxyCareer] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProxyID]=" + CreateSqlParameterName("ProxyID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProxyID", value.ProxyID);
					AddParameter(cmd, "Career", Sanitizer.GetSafeHtmlFragment(value.Career));
					AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
					AddParameter(cmd, "IncomeUnit", Sanitizer.GetSafeHtmlFragment(value.IncomeUnit));
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
				Exception ex = new Exception("Set incorrect primarykey PK(ProxyID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int proxyID)
		{
			string whereSql = "[ProxyID]=" + CreateSqlParameterName("ProxyID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProxyID", proxyID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected ProxyCareerRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ProxyCareerRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ProxyCareerRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int proxyIDColumnIndex = reader.GetOrdinal("ProxyID");
			int careerColumnIndex = reader.GetOrdinal("Career");
			int incomeColumnIndex = reader.GetOrdinal("Income");
			int incomeUnitColumnIndex = reader.GetOrdinal("IncomeUnit");
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
					ProxyCareerRow record = new ProxyCareerRow();
					recordList.Add(record);
					record.ProxyID =  Convert.ToInt32(reader.GetValue(proxyIDColumnIndex));
					if (!reader.IsDBNull(careerColumnIndex)) record.Career =  Convert.ToString(reader.GetValue(careerColumnIndex));

					if (!reader.IsDBNull(incomeColumnIndex)) record.Income =  Convert.ToDouble(reader.GetValue(incomeColumnIndex));

					if (!reader.IsDBNull(incomeUnitColumnIndex)) record.IncomeUnit =  Convert.ToString(reader.GetValue(incomeUnitColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ProxyCareerRow[])(recordList.ToArray(typeof(ProxyCareerRow)));
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
				case "ProxyID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Career":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Income":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "IncomeUnit":
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

