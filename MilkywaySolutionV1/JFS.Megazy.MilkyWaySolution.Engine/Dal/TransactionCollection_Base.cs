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
	[Serializable]
	public partial class TransactionCollection_Base : MarshalByRefObject
	{
		public const string TransactionIDColumnName = "TransactionID";
		public const string TransactionNoColumnName = "TransactionNo";
		public const string TransactionTypeColumnName = "TransactionType";
		public const string RefApplicantIDColumnName = "RefApplicantID";
		public const string RefCaseIDColumnName = "RefCaseID";
		public const string RefContractIDColumnName = "RefContractID";
		public const string TotalAmountColumnName = "TotalAmount";
		public const string TotalAmountPaidColumnName = "TotalAmountPaid";
		public const string NoteColumnName = "Note";
		public const string FinancialOfficerNoteColumnName = "FinancialOfficerNote";
		public const string TranferDateColumnName = "TranferDate";
		public const string PaidDateColumnName = "PaidDate";
		public const string TransactionStatusIDColumnName = "TransactionStatusID";
		public const string DeleteFlagColumnName = "DeleteFlag";
		public const string CreateDateColumnName = "CreateDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string TransactionDateColumnName = "TransactionDate";
		public const string PaymentListJsonColumnName = "PaymentListJson";
		public const string ReceiveDateColumnName = "ReceiveDate";
		private int _processID;
		public SqlCommand cmd = null;
		public TransactionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual TransactionRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual TransactionPaging GetPagingRelyOnTransactionIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TransactionPaging transactionPaging = new TransactionPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionID) as TotalRow from [dbo].[Transaction]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			transactionPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			transactionPaging.totalPage = (int)Math.Ceiling((double) transactionPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			transactionPaging.transactionRow = MapRecords(command);
			return transactionPaging;
		}
		public virtual TransactionPaging GetPagingRelyOnTransactionIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TransactionPaging transactionPaging = new TransactionPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionID) as TotalRow from [dbo].[Transaction]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			transactionPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			transactionPaging.totalPage = (int)Math.Ceiling((double)transactionPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			transactionPaging.transactionRow = MapRecords(command);
			return transactionPaging;
		}
		public virtual TransactionRow[] GetPagingRelyOnTransactionIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID < " + minTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID < " + minTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionRow[] GetPagingRelyOnTransactionIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID > " + minTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID > " + minTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionRow[] GetPagingRelyOnTransactionIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID < " + maxTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID < " + maxTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionRow[] GetPagingRelyOnTransactionIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID > " + maxTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID > " + maxTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionRow[] GetPagingRelyOnTransactionIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			TransactionRow[] transactionRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionRow = MapRecords(command);
			}
			return transactionRow;
		}
		public virtual TransactionRow[] GetPagingRelyOnTransactionIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			TransactionRow[] transactionRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionRow = MapRecords(command);
			}
			return transactionRow;
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
			"[TransactionID],"+
			"[TransactionNo],"+
			"[TransactionType],"+
			"[RefApplicantID],"+
			"[RefCaseID],"+
			"[RefContractID],"+
			"[TotalAmount],"+
			"[TotalAmountPaid],"+
			"[Note],"+
			"[FinancialOfficerNote],"+
			"[TranferDate],"+
			"[PaidDate],"+
			"[TransactionStatusID],"+
			"[DeleteFlag],"+
			"[CreateDate],"+
			"[ModifiedDate],"+
			"[TransactionDate],"+
			"[PaymentListJson],"+
			"[ReceiveDate]"+
			" FROM [dbo].[Transaction]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Transaction]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Transaction] where TransactionID < (select min(minTransactionID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionID as minTransactionID from [dbo].[Transaction]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[Transaction]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Transaction] where TransactionID > (select max(maxTransactionID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionID as maxTransactionID from [dbo].[Transaction]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[Transaction]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Transaction]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Transaction"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("TransactionType",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RefApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RefCaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RefContractID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("TotalAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("TotalAmountPaid",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("FinancialOfficerNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("TranferDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("PaidDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("TransactionStatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DeleteFlag",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("TransactionDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("PaymentListJson",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ReceiveDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual TransactionRow[] GetByTransactionType(int transactiontype)
		{
			return MapRecords(CreateGetByTransactionTypeCommand(transactiontype));
		}
		public virtual DataTable GetByTransactionTypeAsDataTable(int transactiontype)
		{
			return MapRecordsToDataTable(CreateGetByTransactionTypeCommand(transactiontype));
		}
		protected virtual IDbCommand CreateGetByTransactionTypeCommand(int transactiontype)
		{
			string whereSql = "";
			whereSql += "[TransactionType]=" + CreateSqlParameterName("TransactionType");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionType", transactiontype);
			return cmd;
		}
		public virtual TransactionRow[] GetByTransactionStatusID(int transactionStatusID)
		{
			return MapRecords(CreateGetByTransactionStatusIDCommand(transactionStatusID));
		}
		public virtual DataTable GetByTransactionStatusIDAsDataTable(int transactionStatusID)
		{
			return MapRecordsToDataTable(CreateGetByTransactionStatusIDCommand(transactionStatusID));
		}
		protected virtual IDbCommand CreateGetByTransactionStatusIDCommand(int transactionStatusID)
		{
			string whereSql = "";
			whereSql += "[TransactionStatusID]=" + CreateSqlParameterName("TransactionStatusID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionStatusID", transactionStatusID);
			return cmd;
		}
		public TransactionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual TransactionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="TransactionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TransactionRow"/> objects.</returns>
		public virtual TransactionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Transaction]", top);
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
		public TransactionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			TransactionRow[] rows = null;
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
		public DataTable GetTransactionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TransactionID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TransactionID) AS TotalRow FROM [dbo].[Transaction] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionID,TransactionNo,TransactionType,RefApplicantID,RefCaseID,RefContractID,TotalAmount,TotalAmountPaid,Note,FinancialOfficerNote,TranferDate,PaidDate,TransactionStatusID,DeleteFlag,CreateDate,ModifiedDate,TransactionDate,PaymentListJson,ReceiveDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Transaction] " + whereSql +
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
		public TransactionItemsPaging GetTransactionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
		TransactionItemsPaging obj = new TransactionItemsPaging();
		DataTable dt = GetTransactionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		TransactionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new TransactionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.TransactionNo = dt.Rows[i]["TransactionNo"].ToString();
			record.TransactionType = Convert.ToInt32(dt.Rows[i]["TransactionType"]);
			if (dt.Rows[i]["RefApplicantID"] != DBNull.Value)
			record.RefApplicantID = Convert.ToInt32(dt.Rows[i]["RefApplicantID"]);
			if (dt.Rows[i]["RefCaseID"] != DBNull.Value)
			record.RefCaseID = Convert.ToInt32(dt.Rows[i]["RefCaseID"]);
			if (dt.Rows[i]["RefContractID"] != DBNull.Value)
			record.RefContractID = Convert.ToInt32(dt.Rows[i]["RefContractID"]);
			if (dt.Rows[i]["TotalAmount"] != DBNull.Value)
			record.TotalAmount = Convert.ToDouble(dt.Rows[i]["TotalAmount"]);
			if (dt.Rows[i]["TotalAmountPaid"] != DBNull.Value)
			record.TotalAmountPaid = Convert.ToDouble(dt.Rows[i]["TotalAmountPaid"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			record.FinancialOfficerNote = dt.Rows[i]["FinancialOfficerNote"].ToString();
			if (dt.Rows[i]["TranferDate"] != DBNull.Value)
			record.TranferDate = Convert.ToDateTime(dt.Rows[i]["TranferDate"]);
			if (dt.Rows[i]["PaidDate"] != DBNull.Value)
			record.PaidDate = Convert.ToDateTime(dt.Rows[i]["PaidDate"]);
			if (dt.Rows[i]["TransactionStatusID"] != DBNull.Value)
			record.TransactionStatusID = Convert.ToInt32(dt.Rows[i]["TransactionStatusID"]);
			if (dt.Rows[i]["DeleteFlag"] != DBNull.Value)
			record.DeleteFlag = Convert.ToBoolean(dt.Rows[i]["DeleteFlag"]);
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["TransactionDate"] != DBNull.Value)
			record.TransactionDate = Convert.ToDateTime(dt.Rows[i]["TransactionDate"]);
			record.PaymentListJson = dt.Rows[i]["PaymentListJson"].ToString();
			if (dt.Rows[i]["ReceiveDate"] != DBNull.Value)
			record.ReceiveDate = Convert.ToDateTime(dt.Rows[i]["ReceiveDate"]);
			recordList.Add(record);
		}
		obj.transactionItems = (TransactionItems[])(recordList.ToArray(typeof(TransactionItems)));
		return obj;
		}
		public TransactionRow GetByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionID", transactionID);
			TransactionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(TransactionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Transaction] (" +
			"[TransactionNo], " + 
			"[TransactionType], " + 
			"[RefApplicantID], " + 
			"[RefCaseID], " + 
			"[RefContractID], " + 
			"[TotalAmount], " + 
			"[TotalAmountPaid], " + 
			"[Note], " + 
			"[FinancialOfficerNote], " + 
			"[TranferDate], " + 
			"[PaidDate], " + 
			"[TransactionStatusID], " + 
			"[DeleteFlag], " + 
			"[CreateDate], " + 
			"[ModifiedDate], " + 
			"[TransactionDate], " + 
			"[PaymentListJson], " + 
			"[ReceiveDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionNo") + ", " +
			CreateSqlParameterName("TransactionType") + ", " +
			CreateSqlParameterName("RefApplicantID") + ", " +
			CreateSqlParameterName("RefCaseID") + ", " +
			CreateSqlParameterName("RefContractID") + ", " +
			CreateSqlParameterName("TotalAmount") + ", " +
			CreateSqlParameterName("TotalAmountPaid") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("FinancialOfficerNote") + ", " +
			CreateSqlParameterName("TranferDate") + ", " +
			CreateSqlParameterName("PaidDate") + ", " +
			CreateSqlParameterName("TransactionStatusID") + ", " +
			CreateSqlParameterName("DeleteFlag") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("TransactionDate") + ", " +
			CreateSqlParameterName("PaymentListJson") + ", " +
			CreateSqlParameterName("ReceiveDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionNo", value.IsTransactionNoNull ? DBNull.Value : (object)value.TransactionNo);
			AddParameter(cmd, "TransactionType", value.TransactionType);
			AddParameter(cmd, "RefApplicantID", value.IsRefApplicantIDNull ? DBNull.Value : (object)value.RefApplicantID);
			AddParameter(cmd, "RefCaseID", value.IsRefCaseIDNull ? DBNull.Value : (object)value.RefCaseID);
			AddParameter(cmd, "RefContractID", value.IsRefContractIDNull ? DBNull.Value : (object)value.RefContractID);
			AddParameter(cmd, "TotalAmount", value.IsTotalAmountNull ? DBNull.Value : (object)value.TotalAmount);
			AddParameter(cmd, "TotalAmountPaid", value.IsTotalAmountPaidNull ? DBNull.Value : (object)value.TotalAmountPaid);
			AddParameter(cmd, "Note", value.IsNoteNull ? DBNull.Value : (object)value.Note);
			AddParameter(cmd, "FinancialOfficerNote", value.IsFinancialOfficerNoteNull ? DBNull.Value : (object)value.FinancialOfficerNote);
			AddParameter(cmd, "TranferDate", value.IsTranferDateNull ? DBNull.Value : (object)value.TranferDate);
			AddParameter(cmd, "PaidDate", value.IsPaidDateNull ? DBNull.Value : (object)value.PaidDate);
			AddParameter(cmd, "TransactionStatusID", value.IsTransactionStatusIDNull ? DBNull.Value : (object)value.TransactionStatusID);
			AddParameter(cmd, "DeleteFlag", value.IsDeleteFlagNull ? DBNull.Value : (object)value.DeleteFlag);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "TransactionDate", value.IsTransactionDateNull ? DBNull.Value : (object)value.TransactionDate);
			AddParameter(cmd, "PaymentListJson", value.IsPaymentListJsonNull ? DBNull.Value : (object)value.PaymentListJson);
			AddParameter(cmd, "ReceiveDate", value.IsReceiveDateNull ? DBNull.Value : (object)value.ReceiveDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(TransactionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Transaction] (" +
			"[TransactionNo], " + 
			"[TransactionType], " + 
			"[RefApplicantID], " + 
			"[RefCaseID], " + 
			"[RefContractID], " + 
			"[TotalAmount], " + 
			"[TotalAmountPaid], " + 
			"[Note], " + 
			"[FinancialOfficerNote], " + 
			"[TranferDate], " + 
			"[PaidDate], " + 
			"[TransactionStatusID], " + 
			"[DeleteFlag], " + 
			"[CreateDate], " + 
			"[ModifiedDate], " + 
			"[TransactionDate], " + 
			"[PaymentListJson], " + 
			"[ReceiveDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionNo") + ", " +
			CreateSqlParameterName("TransactionType") + ", " +
			CreateSqlParameterName("RefApplicantID") + ", " +
			CreateSqlParameterName("RefCaseID") + ", " +
			CreateSqlParameterName("RefContractID") + ", " +
			CreateSqlParameterName("TotalAmount") + ", " +
			CreateSqlParameterName("TotalAmountPaid") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("FinancialOfficerNote") + ", " +
			CreateSqlParameterName("TranferDate") + ", " +
			CreateSqlParameterName("PaidDate") + ", " +
			CreateSqlParameterName("TransactionStatusID") + ", " +
			CreateSqlParameterName("DeleteFlag") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("TransactionDate") + ", " +
			CreateSqlParameterName("PaymentListJson") + ", " +
			CreateSqlParameterName("ReceiveDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionNo", value.IsTransactionNoNull ? DBNull.Value : (object)value.TransactionNo);
			AddParameter(cmd, "TransactionType", value.TransactionType);
			AddParameter(cmd, "RefApplicantID", value.IsRefApplicantIDNull ? DBNull.Value : (object)value.RefApplicantID);
			AddParameter(cmd, "RefCaseID", value.IsRefCaseIDNull ? DBNull.Value : (object)value.RefCaseID);
			AddParameter(cmd, "RefContractID", value.IsRefContractIDNull ? DBNull.Value : (object)value.RefContractID);
			AddParameter(cmd, "TotalAmount", value.IsTotalAmountNull ? DBNull.Value : (object)value.TotalAmount);
			AddParameter(cmd, "TotalAmountPaid", value.IsTotalAmountPaidNull ? DBNull.Value : (object)value.TotalAmountPaid);
			AddParameter(cmd, "Note", value.IsNoteNull ? DBNull.Value : (object)value.Note);
			AddParameter(cmd, "FinancialOfficerNote", value.IsFinancialOfficerNoteNull ? DBNull.Value : (object)value.FinancialOfficerNote);
			AddParameter(cmd, "TranferDate", value.IsTranferDateNull ? DBNull.Value : (object)value.TranferDate);
			AddParameter(cmd, "PaidDate", value.IsPaidDateNull ? DBNull.Value : (object)value.PaidDate);
			AddParameter(cmd, "TransactionStatusID", value.IsTransactionStatusIDNull ? DBNull.Value : (object)value.TransactionStatusID);
			AddParameter(cmd, "DeleteFlag", value.IsDeleteFlagNull ? DBNull.Value : (object)value.DeleteFlag);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "TransactionDate", value.IsTransactionDateNull ? DBNull.Value : (object)value.TransactionDate);
			AddParameter(cmd, "PaymentListJson", value.IsPaymentListJsonNull ? DBNull.Value : (object)value.PaymentListJson);
			AddParameter(cmd, "ReceiveDate", value.IsReceiveDateNull ? DBNull.Value : (object)value.ReceiveDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(TransactionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionNo)
				{
					strUpdate += "[TransactionNo]=" + CreateSqlParameterName("TransactionNo") + ",";
				}
				if (value._IsSetTransactionType)
				{
					strUpdate += "[TransactionType]=" + CreateSqlParameterName("TransactionType") + ",";
				}
				if (value._IsSetRefApplicantID)
				{
					strUpdate += "[RefApplicantID]=" + CreateSqlParameterName("RefApplicantID") + ",";
				}
				if (value._IsSetRefCaseID)
				{
					strUpdate += "[RefCaseID]=" + CreateSqlParameterName("RefCaseID") + ",";
				}
				if (value._IsSetRefContractID)
				{
					strUpdate += "[RefContractID]=" + CreateSqlParameterName("RefContractID") + ",";
				}
				if (value._IsSetTotalAmount)
				{
					strUpdate += "[TotalAmount]=" + CreateSqlParameterName("TotalAmount") + ",";
				}
				if (value._IsSetTotalAmountPaid)
				{
					strUpdate += "[TotalAmountPaid]=" + CreateSqlParameterName("TotalAmountPaid") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetFinancialOfficerNote)
				{
					strUpdate += "[FinancialOfficerNote]=" + CreateSqlParameterName("FinancialOfficerNote") + ",";
				}
				if (value._IsSetTranferDate)
				{
					strUpdate += "[TranferDate]=" + CreateSqlParameterName("TranferDate") + ",";
				}
				if (value._IsSetPaidDate)
				{
					strUpdate += "[PaidDate]=" + CreateSqlParameterName("PaidDate") + ",";
				}
				if (value._IsSetTransactionStatusID)
				{
					strUpdate += "[TransactionStatusID]=" + CreateSqlParameterName("TransactionStatusID") + ",";
				}
				if (value._IsSetDeleteFlag)
				{
					strUpdate += "[DeleteFlag]=" + CreateSqlParameterName("DeleteFlag") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetTransactionDate)
				{
					strUpdate += "[TransactionDate]=" + CreateSqlParameterName("TransactionDate") + ",";
				}
				if (value._IsSetPaymentListJson)
				{
					strUpdate += "[PaymentListJson]=" + CreateSqlParameterName("PaymentListJson") + ",";
				}
				if (value._IsSetReceiveDate)
				{
					strUpdate += "[ReceiveDate]=" + CreateSqlParameterName("ReceiveDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Transaction] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "TransactionNo", value.TransactionNo);
					AddParameter(cmd, "TransactionType", value.TransactionType);
				if (value._IsSetRefApplicantID)
				{
					AddParameter(cmd, "RefApplicantID", value.IsRefApplicantIDNull ? DBNull.Value : (object)value.RefApplicantID);
				}
				if (value._IsSetRefCaseID)
				{
					AddParameter(cmd, "RefCaseID", value.IsRefCaseIDNull ? DBNull.Value : (object)value.RefCaseID);
				}
				if (value._IsSetRefContractID)
				{
					AddParameter(cmd, "RefContractID", value.IsRefContractIDNull ? DBNull.Value : (object)value.RefContractID);
				}
				if (value._IsSetTotalAmount)
				{
					AddParameter(cmd, "TotalAmount", value.IsTotalAmountNull ? DBNull.Value : (object)value.TotalAmount);
				}
				if (value._IsSetTotalAmountPaid)
				{
					AddParameter(cmd, "TotalAmountPaid", value.IsTotalAmountPaidNull ? DBNull.Value : (object)value.TotalAmountPaid);
				}
					AddParameter(cmd, "Note", value.Note);
					AddParameter(cmd, "FinancialOfficerNote", value.FinancialOfficerNote);
				if (value._IsSetTranferDate)
				{
					AddParameter(cmd, "TranferDate", value.IsTranferDateNull ? DBNull.Value : (object)value.TranferDate);
				}
				if (value._IsSetPaidDate)
				{
					AddParameter(cmd, "PaidDate", value.IsPaidDateNull ? DBNull.Value : (object)value.PaidDate);
				}
				if (value._IsSetTransactionStatusID)
				{
					AddParameter(cmd, "TransactionStatusID", value.IsTransactionStatusIDNull ? DBNull.Value : (object)value.TransactionStatusID);
				}
				if (value._IsSetDeleteFlag)
				{
					AddParameter(cmd, "DeleteFlag", value.IsDeleteFlagNull ? DBNull.Value : (object)value.DeleteFlag);
				}
				if (value._IsSetCreateDate)
				{
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
				}
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				if (value._IsSetTransactionDate)
				{
					AddParameter(cmd, "TransactionDate", value.IsTransactionDateNull ? DBNull.Value : (object)value.TransactionDate);
				}
					AddParameter(cmd, "PaymentListJson", value.PaymentListJson);
				if (value._IsSetReceiveDate)
				{
					AddParameter(cmd, "ReceiveDate", value.IsReceiveDateNull ? DBNull.Value : (object)value.ReceiveDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(TransactionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionNo)
				{
					strUpdate += "[TransactionNo]=" + CreateSqlParameterName("TransactionNo") + ",";
				}
				if (value._IsSetTransactionType)
				{
					strUpdate += "[TransactionType]=" + CreateSqlParameterName("TransactionType") + ",";
				}
				if (value._IsSetRefApplicantID)
				{
					strUpdate += "[RefApplicantID]=" + CreateSqlParameterName("RefApplicantID") + ",";
				}
				if (value._IsSetRefCaseID)
				{
					strUpdate += "[RefCaseID]=" + CreateSqlParameterName("RefCaseID") + ",";
				}
				if (value._IsSetRefContractID)
				{
					strUpdate += "[RefContractID]=" + CreateSqlParameterName("RefContractID") + ",";
				}
				if (value._IsSetTotalAmount)
				{
					strUpdate += "[TotalAmount]=" + CreateSqlParameterName("TotalAmount") + ",";
				}
				if (value._IsSetTotalAmountPaid)
				{
					strUpdate += "[TotalAmountPaid]=" + CreateSqlParameterName("TotalAmountPaid") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetFinancialOfficerNote)
				{
					strUpdate += "[FinancialOfficerNote]=" + CreateSqlParameterName("FinancialOfficerNote") + ",";
				}
				if (value._IsSetTranferDate)
				{
					strUpdate += "[TranferDate]=" + CreateSqlParameterName("TranferDate") + ",";
				}
				if (value._IsSetPaidDate)
				{
					strUpdate += "[PaidDate]=" + CreateSqlParameterName("PaidDate") + ",";
				}
				if (value._IsSetTransactionStatusID)
				{
					strUpdate += "[TransactionStatusID]=" + CreateSqlParameterName("TransactionStatusID") + ",";
				}
				if (value._IsSetDeleteFlag)
				{
					strUpdate += "[DeleteFlag]=" + CreateSqlParameterName("DeleteFlag") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetTransactionDate)
				{
					strUpdate += "[TransactionDate]=" + CreateSqlParameterName("TransactionDate") + ",";
				}
				if (value._IsSetPaymentListJson)
				{
					strUpdate += "[PaymentListJson]=" + CreateSqlParameterName("PaymentListJson") + ",";
				}
				if (value._IsSetReceiveDate)
				{
					strUpdate += "[ReceiveDate]=" + CreateSqlParameterName("ReceiveDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Transaction] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "TransactionNo", Sanitizer.GetSafeHtmlFragment(value.TransactionNo));
					AddParameter(cmd, "TransactionType", value.TransactionType);
				if (value._IsSetRefApplicantID)
				{
					AddParameter(cmd, "RefApplicantID", value.IsRefApplicantIDNull ? DBNull.Value : (object)value.RefApplicantID);
				}
				if (value._IsSetRefCaseID)
				{
					AddParameter(cmd, "RefCaseID", value.IsRefCaseIDNull ? DBNull.Value : (object)value.RefCaseID);
				}
				if (value._IsSetRefContractID)
				{
					AddParameter(cmd, "RefContractID", value.IsRefContractIDNull ? DBNull.Value : (object)value.RefContractID);
				}
				if (value._IsSetTotalAmount)
				{
					AddParameter(cmd, "TotalAmount", value.IsTotalAmountNull ? DBNull.Value : (object)value.TotalAmount);
				}
				if (value._IsSetTotalAmountPaid)
				{
					AddParameter(cmd, "TotalAmountPaid", value.IsTotalAmountPaidNull ? DBNull.Value : (object)value.TotalAmountPaid);
				}
					AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
					AddParameter(cmd, "FinancialOfficerNote", Sanitizer.GetSafeHtmlFragment(value.FinancialOfficerNote));
				if (value._IsSetTranferDate)
				{
					AddParameter(cmd, "TranferDate", value.IsTranferDateNull ? DBNull.Value : (object)value.TranferDate);
				}
				if (value._IsSetPaidDate)
				{
					AddParameter(cmd, "PaidDate", value.IsPaidDateNull ? DBNull.Value : (object)value.PaidDate);
				}
				if (value._IsSetTransactionStatusID)
				{
					AddParameter(cmd, "TransactionStatusID", value.IsTransactionStatusIDNull ? DBNull.Value : (object)value.TransactionStatusID);
				}
				if (value._IsSetDeleteFlag)
				{
					AddParameter(cmd, "DeleteFlag", value.IsDeleteFlagNull ? DBNull.Value : (object)value.DeleteFlag);
				}
				if (value._IsSetCreateDate)
				{
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
				}
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				if (value._IsSetTransactionDate)
				{
					AddParameter(cmd, "TransactionDate", value.IsTransactionDateNull ? DBNull.Value : (object)value.TransactionDate);
				}
					AddParameter(cmd, "PaymentListJson", Sanitizer.GetSafeHtmlFragment(value.PaymentListJson));
				if (value._IsSetReceiveDate)
				{
					AddParameter(cmd, "ReceiveDate", value.IsReceiveDateNull ? DBNull.Value : (object)value.ReceiveDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionID", transactionID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByTransactionType(int transactiontype)
		{
			return CreateDeleteByTransactionTypeCommand(transactiontype).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTransactionTypeCommand(int transactiontype)
		{
			string whereSql = "";
			whereSql += "[TransactionType]=" + CreateSqlParameterName("TransactionType");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionType", transactiontype);
			return cmd;
		}
		public int DeleteByTransactionStatusID(int transactionStatusID)
		{
			return DeleteByTransactionStatusID(transactionStatusID, false);
		}
		public int DeleteByTransactionStatusID(int transactionStatusID, bool transactionStatusIDNull)
		{
			return CreateDeleteByTransactionStatusIDCommand(transactionStatusID, transactionStatusIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTransactionStatusIDCommand(int transactionStatusID, bool transactionStatusIDNull)
		{
			string whereSql = "";
			if (transactionStatusIDNull)
				whereSql += "[TransactionStatusID] IS NULL";
			else
				whereSql += "[TransactionStatusID]=" + CreateSqlParameterName("TransactionStatusID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!transactionStatusIDNull)
				AddParameter(cmd, "TransactionStatusID", transactionStatusID);
			return cmd;
		}
		protected TransactionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected TransactionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected TransactionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int transactionNoColumnIndex = reader.GetOrdinal("TransactionNo");
			int transactiontypeColumnIndex = reader.GetOrdinal("TransactionType");
			int refApplicantIDColumnIndex = reader.GetOrdinal("RefApplicantID");
			int refCaseIDColumnIndex = reader.GetOrdinal("RefCaseID");
			int refContractIDColumnIndex = reader.GetOrdinal("RefContractID");
			int totalAmountColumnIndex = reader.GetOrdinal("TotalAmount");
			int totalAmountPaidColumnIndex = reader.GetOrdinal("TotalAmountPaid");
			int noteColumnIndex = reader.GetOrdinal("Note");
			int financialOfficerNoteColumnIndex = reader.GetOrdinal("FinancialOfficerNote");
			int tranferDateColumnIndex = reader.GetOrdinal("TranferDate");
			int paidDateColumnIndex = reader.GetOrdinal("PaidDate");
			int transactionStatusIDColumnIndex = reader.GetOrdinal("TransactionStatusID");
			int deleteFlagColumnIndex = reader.GetOrdinal("DeleteFlag");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int transactionDateColumnIndex = reader.GetOrdinal("TransactionDate");
			int paymentListJsonColumnIndex = reader.GetOrdinal("PaymentListJson");
			int receiveDateColumnIndex = reader.GetOrdinal("ReceiveDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					TransactionRow record = new TransactionRow();
					recordList.Add(record);
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(transactionNoColumnIndex)) record.TransactionNo =  Convert.ToString(reader.GetValue(transactionNoColumnIndex));

					record.TransactionType =  Convert.ToInt32(reader.GetValue(transactiontypeColumnIndex));
					if (!reader.IsDBNull(refApplicantIDColumnIndex)) record.RefApplicantID =  Convert.ToInt32(reader.GetValue(refApplicantIDColumnIndex));

					if (!reader.IsDBNull(refCaseIDColumnIndex)) record.RefCaseID =  Convert.ToInt32(reader.GetValue(refCaseIDColumnIndex));

					if (!reader.IsDBNull(refContractIDColumnIndex)) record.RefContractID =  Convert.ToInt32(reader.GetValue(refContractIDColumnIndex));

					if (!reader.IsDBNull(totalAmountColumnIndex)) record.TotalAmount =  Convert.ToDouble(reader.GetValue(totalAmountColumnIndex));

					if (!reader.IsDBNull(totalAmountPaidColumnIndex)) record.TotalAmountPaid =  Convert.ToDouble(reader.GetValue(totalAmountPaidColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(financialOfficerNoteColumnIndex)) record.FinancialOfficerNote =  Convert.ToString(reader.GetValue(financialOfficerNoteColumnIndex));

					if (!reader.IsDBNull(tranferDateColumnIndex)) record.TranferDate =  Convert.ToDateTime(reader.GetValue(tranferDateColumnIndex));

					if (!reader.IsDBNull(paidDateColumnIndex)) record.PaidDate =  Convert.ToDateTime(reader.GetValue(paidDateColumnIndex));

					if (!reader.IsDBNull(transactionStatusIDColumnIndex)) record.TransactionStatusID =  Convert.ToInt32(reader.GetValue(transactionStatusIDColumnIndex));

					if (!reader.IsDBNull(deleteFlagColumnIndex)) record.DeleteFlag =  Convert.ToBoolean(reader.GetValue(deleteFlagColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(transactionDateColumnIndex)) record.TransactionDate =  Convert.ToDateTime(reader.GetValue(transactionDateColumnIndex));

					if (!reader.IsDBNull(paymentListJsonColumnIndex)) record.PaymentListJson =  Convert.ToString(reader.GetValue(paymentListJsonColumnIndex));

					if (!reader.IsDBNull(receiveDateColumnIndex)) record.ReceiveDate =  Convert.ToDateTime(reader.GetValue(receiveDateColumnIndex));

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
			return (TransactionRow[])(recordList.ToArray(typeof(TransactionRow)));
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
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TransactionType":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RefApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RefCaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RefContractID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TotalAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "TotalAmountPaid":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Note":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FinancialOfficerNote":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TranferDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "PaidDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "TransactionStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DeleteFlag":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "TransactionDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "PaymentListJson":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReceiveDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
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

