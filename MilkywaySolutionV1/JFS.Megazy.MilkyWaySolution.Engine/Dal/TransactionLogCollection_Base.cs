using System.ServiceModel;
using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	public partial class TransactionLogCollection_Base
	{
		public const string TransactionLogColumnName = "TransactionLog";
		public const string TransactionIDColumnName = "TransactionID";
		public const string ReferenceFinanceIDColumnName = "ReferenceFinanceID";
		public const string TransactionDateColumnName = "TransactionDate";
		public const string PaymentStatusColumnName = "PaymentStatus";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public TransactionLogCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual TransactionLogRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual TransactionLogPaging GetPagingRelyOnTransactionLogdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TransactionLogPaging transactionLogPaging = new TransactionLogPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionLog) as TotalRow from [dbo].[TransactionLog]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			transactionLogPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			transactionLogPaging.totalPage = (int)Math.Ceiling((double) transactionLogPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionLog(whereSql, "TransactionLog Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			transactionLogPaging.transactionLogRow = MapRecords(command);
			return transactionLogPaging;
		}
		public virtual TransactionLogPaging GetPagingRelyOnTransactionLogasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TransactionLogPaging transactionLogPaging = new TransactionLogPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionLog) as TotalRow from [dbo].[TransactionLog]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			transactionLogPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			transactionLogPaging.totalPage = (int)Math.Ceiling((double)transactionLogPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionLog(whereSql, "TransactionLog asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			transactionLogPaging.transactionLogRow = MapRecords(command);
			return transactionLogPaging;
		}
		public virtual TransactionLogRow[] GetPagingRelyOnTransactionLogdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionLog)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionLog < " + minTransactionLog.ToString();
			}
			else
			{
				whereSql = "TransactionLog < " + minTransactionLog.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionLog(whereSql, "TransactionLog Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionLogRow[] GetPagingRelyOnTransactionLogascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionLog)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionLog > " + minTransactionLog.ToString();
			}
			else
			{
				whereSql = "TransactionLog > " + minTransactionLog.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionLog(whereSql, "TransactionLog Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionLogRow[] GetPagingRelyOnTransactionLogascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionLog)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionLog < " + maxTransactionLog.ToString();
			}
			else
			{
				whereSql = "TransactionLog < " + maxTransactionLog.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionLog(whereSql, "TransactionLog Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionLogRow[] GetPagingRelyOnTransactionLogdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionLog)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionLog > " + maxTransactionLog.ToString();
			}
			else
			{
				whereSql = "TransactionLog > " + maxTransactionLog.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionLog(whereSql, "TransactionLog Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionLogRow[] GetPagingRelyOnTransactionLogdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionLog Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			TransactionLogRow[] transactionLogRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionLog(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionLogRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionLogdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionLogRow = MapRecords(command);
			}
			return transactionLogRow;
		}
		public virtual TransactionLogRow[] GetPagingRelyOnTransactionLogascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionLog Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			TransactionLogRow[] transactionLogRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionLog(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionLogRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionLogascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionLogRow = MapRecords(command);
			}
			return transactionLogRow;
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
			"[TransactionLog],"+
			"[TransactionID],"+
			"[ReferenceFinanceID],"+
			"[TransactionDate],"+
			"[PaymentStatus],"+
			"[ModifiedDate]"+
			" FROM [dbo].[TransactionLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionLog(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionLogdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionLog Desc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionLog] where TransactionLog < (select min(minTransactionLog) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionLog as minTransactionLog from [dbo].[TransactionLog]" + subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[TransactionLog]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionLogascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionLog Asc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionLog] where TransactionLog > (select max(maxTransactionLog) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionLog as maxTransactionLog from [dbo].[TransactionLog]" +  subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[TransactionLog]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[TransactionLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "TransactionLog"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionLog",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceFinanceID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TransactionDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("PaymentStatus",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public TransactionLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual TransactionLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="TransactionLogRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TransactionLogRow"/> objects.</returns>
		public virtual TransactionLogRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[TransactionLog]", top);
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
		public TransactionLogRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			TransactionLogRow[] rows = null;
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
		public DataTable GetTransactionLogPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionLog")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TransactionLog";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TransactionLog) AS TotalRow FROM [dbo].[TransactionLog] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionLog,TransactionID,ReferenceFinanceID,TransactionDate,PaymentStatus,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[TransactionLog] " + whereSql +
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
		public TransactionLogItemsPaging GetTransactionLogPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionLog")
		{
		TransactionLogItemsPaging obj = new TransactionLogItemsPaging();
		DataTable dt = GetTransactionLogPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		TransactionLogItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new TransactionLogItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionLog = Convert.ToInt32(dt.Rows[i]["TransactionLog"]);
			if (dt.Rows[i]["TransactionID"] != DBNull.Value)
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.ReferenceFinanceID = dt.Rows[i]["ReferenceFinanceID"].ToString();
			if (dt.Rows[i]["TransactionDate"] != DBNull.Value)
			record.TransactionDate = Convert.ToDateTime(dt.Rows[i]["TransactionDate"]);
			record.PaymentStatus = dt.Rows[i]["PaymentStatus"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.transactionLogItems = (TransactionLogItems[])(recordList.ToArray(typeof(TransactionLogItems)));
		return obj;
		}
		public TransactionLogRow GetByPrimaryKey(int transactionLog)
		{
			string whereSql = "[TransactionLog]=" + CreateSqlParameterName("TransactionLog");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionLog", transactionLog);
			TransactionLogRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(TransactionLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TransactionLog] (" +
			"[TransactionID], " + 
			"[ReferenceFinanceID], " + 
			"[TransactionDate], " + 
			"[PaymentStatus], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("ReferenceFinanceID") + ", " +
			CreateSqlParameterName("TransactionDate") + ", " +
			CreateSqlParameterName("PaymentStatus") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.IsTransactionIDNull ? DBNull.Value : (object)value.TransactionID);
			AddParameter(cmd, "ReferenceFinanceID", value.IsReferenceFinanceIDNull ? DBNull.Value : (object)value.ReferenceFinanceID);
			AddParameter(cmd, "TransactionDate", value.IsTransactionDateNull ? DBNull.Value : (object)value.TransactionDate);
			AddParameter(cmd, "PaymentStatus", value.IsPaymentStatusNull ? DBNull.Value : (object)value.PaymentStatus);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(TransactionLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TransactionLog] (" +
			"[TransactionID], " + 
			"[ReferenceFinanceID], " + 
			"[TransactionDate], " + 
			"[PaymentStatus], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("ReferenceFinanceID") + ", " +
			CreateSqlParameterName("TransactionDate") + ", " +
			CreateSqlParameterName("PaymentStatus") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.IsTransactionIDNull ? DBNull.Value : (object)value.TransactionID);
			AddParameter(cmd, "ReferenceFinanceID", value.IsReferenceFinanceIDNull ? DBNull.Value : (object)value.ReferenceFinanceID);
			AddParameter(cmd, "TransactionDate", value.IsTransactionDateNull ? DBNull.Value : (object)value.TransactionDate);
			AddParameter(cmd, "PaymentStatus", value.IsPaymentStatusNull ? DBNull.Value : (object)value.PaymentStatus);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(TransactionLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionLog == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionID)
				{
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID") + ",";
				}
				if (value._IsSetReferenceFinanceID)
				{
					strUpdate += "[ReferenceFinanceID]=" + CreateSqlParameterName("ReferenceFinanceID") + ",";
				}
				if (value._IsSetTransactionDate)
				{
					strUpdate += "[TransactionDate]=" + CreateSqlParameterName("TransactionDate") + ",";
				}
				if (value._IsSetPaymentStatus)
				{
					strUpdate += "[PaymentStatus]=" + CreateSqlParameterName("PaymentStatus") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TransactionLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionLog]=" + CreateSqlParameterName("TransactionLog");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionLog", value.TransactionLog);
				if (value._IsSetTransactionID)
				{
					AddParameter(cmd, "TransactionID", value.IsTransactionIDNull ? DBNull.Value : (object)value.TransactionID);
				}
					AddParameter(cmd, "ReferenceFinanceID", value.ReferenceFinanceID);
				if (value._IsSetTransactionDate)
				{
					AddParameter(cmd, "TransactionDate", value.IsTransactionDateNull ? DBNull.Value : (object)value.TransactionDate);
				}
					AddParameter(cmd, "PaymentStatus", value.PaymentStatus);
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionLog)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(TransactionLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionLog == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionID)
				{
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID") + ",";
				}
				if (value._IsSetReferenceFinanceID)
				{
					strUpdate += "[ReferenceFinanceID]=" + CreateSqlParameterName("ReferenceFinanceID") + ",";
				}
				if (value._IsSetTransactionDate)
				{
					strUpdate += "[TransactionDate]=" + CreateSqlParameterName("TransactionDate") + ",";
				}
				if (value._IsSetPaymentStatus)
				{
					strUpdate += "[PaymentStatus]=" + CreateSqlParameterName("PaymentStatus") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TransactionLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionLog]=" + CreateSqlParameterName("TransactionLog");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionLog", value.TransactionLog);
				if (value._IsSetTransactionID)
				{
					AddParameter(cmd, "TransactionID", value.IsTransactionIDNull ? DBNull.Value : (object)value.TransactionID);
				}
					AddParameter(cmd, "ReferenceFinanceID", Sanitizer.GetSafeHtmlFragment(value.ReferenceFinanceID));
				if (value._IsSetTransactionDate)
				{
					AddParameter(cmd, "TransactionDate", value.IsTransactionDateNull ? DBNull.Value : (object)value.TransactionDate);
				}
					AddParameter(cmd, "PaymentStatus", Sanitizer.GetSafeHtmlFragment(value.PaymentStatus));
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionLog)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int transactionLog)
		{
			string whereSql = "[TransactionLog]=" + CreateSqlParameterName("TransactionLog");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionLog", transactionLog);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected TransactionLogRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected TransactionLogRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected TransactionLogRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionLogColumnIndex = reader.GetOrdinal("TransactionLog");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int referenceFinanceIDColumnIndex = reader.GetOrdinal("ReferenceFinanceID");
			int transactionDateColumnIndex = reader.GetOrdinal("TransactionDate");
			int paymentStatusColumnIndex = reader.GetOrdinal("PaymentStatus");
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
					TransactionLogRow record = new TransactionLogRow();
					recordList.Add(record);
					record.TransactionLog =  Convert.ToInt32(reader.GetValue(transactionLogColumnIndex));
					if (!reader.IsDBNull(transactionIDColumnIndex)) record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));

					if (!reader.IsDBNull(referenceFinanceIDColumnIndex)) record.ReferenceFinanceID =  Convert.ToString(reader.GetValue(referenceFinanceIDColumnIndex));

					if (!reader.IsDBNull(transactionDateColumnIndex)) record.TransactionDate =  Convert.ToDateTime(reader.GetValue(transactionDateColumnIndex));

					if (!reader.IsDBNull(paymentStatusColumnIndex)) record.PaymentStatus =  Convert.ToString(reader.GetValue(paymentStatusColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					record.MapRecord = true;
					if (countRecordRow > 1) 
					{
						record.Many = true;
					}
					else
					{
						record.Many = false;
					}
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TransactionLogRow[])(recordList.ToArray(typeof(TransactionLogRow)));
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
				case "TransactionLog":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceFinanceID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TransactionDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "PaymentStatus":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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
				throw new FaultException("Zero ProcessID");
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

