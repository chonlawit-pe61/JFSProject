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
	public partial class View_OfficerApprovedExpenseCollection_Base : MarshalByRefObject
	{
		public const string ApprovedIDColumnName = "ApprovedID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string OfficerRoleIDColumnName = "OfficerRoleID";
		public const string OfficerRoleNameColumnName = "OfficerRoleName";
		public const string TotalAmountColumnName = "TotalAmount";
		public const string ApproveDateColumnName = "ApproveDate";
		public const string IsFinalApprovedColumnName = "IsFinalApproved";
		public const string NoteColumnName = "Note";
		public const string BudgetIDColumnName = "BudgetID";
		public const string BudgetNameColumnName = "BudgetName";
		private int _processID;
		public SqlCommand cmd = null;
		public View_OfficerApprovedExpenseCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_OfficerApprovedExpenseRow[] GetAll()
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
			"[ApprovedID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[OfficerRoleID],"+
			"[OfficerRoleName],"+
			"[TotalAmount],"+
			"[ApproveDate],"+
			"[IsFinalApproved],"+
			"[Note],"+
			"[BudgetID],"+
			"[BudgetName]"+
			" FROM [dbo].[View_OfficerApprovedExpense]";
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
				TableName = "View_OfficerApprovedExpense"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApprovedID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OfficerRoleID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OfficerRoleName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TotalAmount",Type.GetType("System.Double"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApproveDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsFinalApproved",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("BudgetID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BudgetName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public View_OfficerApprovedExpenseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_OfficerApprovedExpenseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_OfficerApprovedExpenseRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_OfficerApprovedExpenseRow"/> objects.</returns>
		public virtual View_OfficerApprovedExpenseRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_OfficerApprovedExpense]", top);
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
		public View_OfficerApprovedExpenseRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_OfficerApprovedExpenseRow[] rows = null;
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
		public DataTable GetView_OfficerApprovedExpensePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApprovedID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ApprovedID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_OfficerApprovedExpense] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApprovedID,CaseID,ApplicantID,OfficerRoleID,OfficerRoleName,TotalAmount,ApproveDate,IsFinalApproved,Note,BudgetID,BudgetName," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_OfficerApprovedExpense].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_OfficerApprovedExpense] " + whereSql +
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
		public View_OfficerApprovedExpenseItemsPaging GetView_OfficerApprovedExpensePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApprovedID")
		{
		View_OfficerApprovedExpenseItemsPaging obj = new View_OfficerApprovedExpenseItemsPaging();
		DataTable dt = GetView_OfficerApprovedExpensePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_OfficerApprovedExpenseItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_OfficerApprovedExpenseItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApprovedID = Convert.ToInt32(dt.Rows[i]["ApprovedID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.OfficerRoleID = Convert.ToInt32(dt.Rows[i]["OfficerRoleID"]);
			record.OfficerRoleName = dt.Rows[i]["OfficerRoleName"].ToString();
			record.TotalAmount = Convert.ToDouble(dt.Rows[i]["TotalAmount"]);
			record.ApproveDate = Convert.ToDateTime(dt.Rows[i]["ApproveDate"]);
			record.IsFinalApproved = Convert.ToBoolean(dt.Rows[i]["IsFinalApproved"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			record.BudgetID = Convert.ToInt32(dt.Rows[i]["BudgetID"]);
			record.BudgetName = dt.Rows[i]["BudgetName"].ToString();
			recordList.Add(record);
		}
		obj.view_OfficerApprovedExpenseItems = (View_OfficerApprovedExpenseItems[])(recordList.ToArray(typeof(View_OfficerApprovedExpenseItems)));
		return obj;
		}
		protected View_OfficerApprovedExpenseRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_OfficerApprovedExpenseRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_OfficerApprovedExpenseRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int approvedIDColumnIndex = reader.GetOrdinal("ApprovedID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int officerRoleIDColumnIndex = reader.GetOrdinal("OfficerRoleID");
			int officerRoleNameColumnIndex = reader.GetOrdinal("OfficerRoleName");
			int totalAmountColumnIndex = reader.GetOrdinal("TotalAmount");
			int approveDateColumnIndex = reader.GetOrdinal("ApproveDate");
			int isFinalApprovedColumnIndex = reader.GetOrdinal("IsFinalApproved");
			int noteColumnIndex = reader.GetOrdinal("Note");
			int budgetIDColumnIndex = reader.GetOrdinal("BudgetID");
			int budgetNameColumnIndex = reader.GetOrdinal("BudgetName");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_OfficerApprovedExpenseRow record = new View_OfficerApprovedExpenseRow();
					recordList.Add(record);
					record.ApprovedID =  Convert.ToInt32(reader.GetValue(approvedIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.OfficerRoleID =  Convert.ToInt32(reader.GetValue(officerRoleIDColumnIndex));
					if (!reader.IsDBNull(officerRoleNameColumnIndex)) record.OfficerRoleName =  Convert.ToString(reader.GetValue(officerRoleNameColumnIndex));

					record.TotalAmount =  Convert.ToDouble(reader.GetValue(totalAmountColumnIndex));
					record.ApproveDate =  Convert.ToDateTime(reader.GetValue(approveDateColumnIndex));
					record.IsFinalApproved =  Convert.ToBoolean(reader.GetValue(isFinalApprovedColumnIndex));
					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					record.BudgetID =  Convert.ToInt32(reader.GetValue(budgetIDColumnIndex));
					record.BudgetName =  Convert.ToString(reader.GetValue(budgetNameColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_OfficerApprovedExpenseRow[])(recordList.ToArray(typeof(View_OfficerApprovedExpenseRow)));
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
				case "ApprovedID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OfficerRoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OfficerRoleName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TotalAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ApproveDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "IsFinalApproved":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Note":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BudgetID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "BudgetName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

