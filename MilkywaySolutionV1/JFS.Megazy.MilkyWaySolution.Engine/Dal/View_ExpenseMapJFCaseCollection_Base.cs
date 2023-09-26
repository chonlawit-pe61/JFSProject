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
	public partial class View_ExpenseMapJFCaseCollection_Base : MarshalByRefObject
	{
		public const string ExpenseIDColumnName = "ExpenseID";
		public const string JFCaseTypeIDColumnName = "JFCaseTypeID";
		public const string IsOtherColumnName = "IsOther";
		public const string SortOrderColumnName = "SortOrder";
		public const string ExpenseNameColumnName = "ExpenseName";
		public const string CaseTypeNameColumnName = "CaseTypeName";
		public const string CaseTypeNameAbbrColumnName = "CaseTypeNameAbbr";
		public const string CaseTypePrefixColumnName = "CaseTypePrefix";
		public const string PriceThresholdColumnName = "PriceThreshold";
		private int _processID;
		public SqlCommand cmd = null;
		public View_ExpenseMapJFCaseCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_ExpenseMapJFCaseRow[] GetAll()
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
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[ExpenseID],"+
			"[JFCaseTypeID],"+
			"[IsOther],"+
			"[SortOrder],"+
			"[ExpenseName],"+
			"[CaseTypeName],"+
			"[CaseTypeNameAbbr],"+
			"[CaseTypePrefix],"+
			"[PriceThreshold]"+
			" FROM [dbo].[View_ExpenseMapJFCase]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "View_ExpenseMapJFCase"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ExpenseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("JFCaseTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsOther",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ExpenseName",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("CaseTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CaseTypeNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CaseTypePrefix",Type.GetType("System.String"));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("PriceThreshold",Type.GetType("System.Int32"));
			return dataTable;
		}
		public View_ExpenseMapJFCaseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_ExpenseMapJFCaseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_ExpenseMapJFCaseRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_ExpenseMapJFCaseRow"/> objects.</returns>
		public virtual View_ExpenseMapJFCaseRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_ExpenseMapJFCase]", top);
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
		public View_ExpenseMapJFCaseRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_ExpenseMapJFCaseRow[] rows = null;
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
		public DataTable GetView_ExpenseMapJFCasePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ExpenseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ExpenseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_ExpenseMapJFCase] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ExpenseID,JFCaseTypeID,IsOther,SortOrder,ExpenseName,CaseTypeName,CaseTypeNameAbbr,CaseTypePrefix,PriceThreshold," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_ExpenseMapJFCase].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_ExpenseMapJFCase] " + whereSql +
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
		public View_ExpenseMapJFCaseItemsPaging GetView_ExpenseMapJFCasePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ExpenseID")
		{
		View_ExpenseMapJFCaseItemsPaging obj = new View_ExpenseMapJFCaseItemsPaging();
		DataTable dt = GetView_ExpenseMapJFCasePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_ExpenseMapJFCaseItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_ExpenseMapJFCaseItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ExpenseID = Convert.ToInt32(dt.Rows[i]["ExpenseID"]);
			record.JFCaseTypeID = Convert.ToInt32(dt.Rows[i]["JFCaseTypeID"]);
			if (dt.Rows[i]["IsOther"] != DBNull.Value)
			record.IsOther = Convert.ToBoolean(dt.Rows[i]["IsOther"]);
			if (dt.Rows[i]["SortOrder"] != DBNull.Value)
			record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
			record.ExpenseName = dt.Rows[i]["ExpenseName"].ToString();
			record.CaseTypeName = dt.Rows[i]["CaseTypeName"].ToString();
			record.CaseTypeNameAbbr = dt.Rows[i]["CaseTypeNameAbbr"].ToString();
			record.CaseTypePrefix = dt.Rows[i]["CaseTypePrefix"].ToString();
			if (dt.Rows[i]["PriceThreshold"] != DBNull.Value)
			record.PriceThreshold = Convert.ToInt32(dt.Rows[i]["PriceThreshold"]);
			recordList.Add(record);
		}
		obj.view_ExpenseMapJFCaseItems = (View_ExpenseMapJFCaseItems[])(recordList.ToArray(typeof(View_ExpenseMapJFCaseItems)));
		return obj;
		}
		protected View_ExpenseMapJFCaseRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_ExpenseMapJFCaseRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_ExpenseMapJFCaseRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int expenseIDColumnIndex = reader.GetOrdinal("ExpenseID");
			int jFCaseTypeIDColumnIndex = reader.GetOrdinal("JFCaseTypeID");
			int isOtherColumnIndex = reader.GetOrdinal("IsOther");
			int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
			int expenseNameColumnIndex = reader.GetOrdinal("ExpenseName");
			int caseTypeNameColumnIndex = reader.GetOrdinal("CaseTypeName");
			int caseTypeNameAbbrColumnIndex = reader.GetOrdinal("CaseTypeNameAbbr");
			int caseTypePrefixColumnIndex = reader.GetOrdinal("CaseTypePrefix");
			int priceThresholdColumnIndex = reader.GetOrdinal("PriceThreshold");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_ExpenseMapJFCaseRow record = new View_ExpenseMapJFCaseRow();
					recordList.Add(record);
					record.ExpenseID =  Convert.ToInt32(reader.GetValue(expenseIDColumnIndex));
					record.JFCaseTypeID =  Convert.ToInt32(reader.GetValue(jFCaseTypeIDColumnIndex));
					if (!reader.IsDBNull(isOtherColumnIndex)) record.IsOther =  Convert.ToBoolean(reader.GetValue(isOtherColumnIndex));

					if (!reader.IsDBNull(sortOrderColumnIndex)) record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));

					if (!reader.IsDBNull(expenseNameColumnIndex)) record.ExpenseName =  Convert.ToString(reader.GetValue(expenseNameColumnIndex));

					if (!reader.IsDBNull(caseTypeNameColumnIndex)) record.CaseTypeName =  Convert.ToString(reader.GetValue(caseTypeNameColumnIndex));

					if (!reader.IsDBNull(caseTypeNameAbbrColumnIndex)) record.CaseTypeNameAbbr =  Convert.ToString(reader.GetValue(caseTypeNameAbbrColumnIndex));

					if (!reader.IsDBNull(caseTypePrefixColumnIndex)) record.CaseTypePrefix =  Convert.ToString(reader.GetValue(caseTypePrefixColumnIndex));

					if (!reader.IsDBNull(priceThresholdColumnIndex)) record.PriceThreshold =  Convert.ToInt32(reader.GetValue(priceThresholdColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_ExpenseMapJFCaseRow[])(recordList.ToArray(typeof(View_ExpenseMapJFCaseRow)));
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
				case "ExpenseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "JFCaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsOther":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "SortOrder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ExpenseName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseTypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseTypeNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseTypePrefix":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "PriceThreshold":
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

