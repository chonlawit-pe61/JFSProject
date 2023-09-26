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
	public partial class ChequeLogCollection_Base : MarshalByRefObject
	{
		public const string ChequeLogIDColumnName = "ChequeLogID";
		public const string TransactionIDColumnName = "TransactionID";
		public const string ChequeNoColumnName = "ChequeNo";
		public const string AmountColumnName = "Amount";
		public const string ChequeStatusColumnName = "ChequeStatus";
		public const string ChequeNoteColumnName = "ChequeNote";
		public const string MoneyOrderCertificateNumberColumnName = "MoneyOrderCertificateNumber";
		public const string DateCreatedColumnName = "DateCreated";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string AdditionalDataJsonColumnName = "AdditionalDataJson";
		public const string LastModifiedByUserIDColumnName = "LastModifiedByUserID";
		public const string FlagDeleteColumnName = "FlagDelete";
		private int _processID;
		public SqlCommand cmd = null;
		public ChequeLogCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ChequeLogRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual ChequeLogPaging GetPagingRelyOnChequeLogIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ChequeLogPaging chequeLogPaging = new ChequeLogPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ChequeLogID) as TotalRow from [dbo].[ChequeLog]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			chequeLogPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			chequeLogPaging.totalPage = (int)Math.Ceiling((double) chequeLogPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnChequeLogID(whereSql, "ChequeLogID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			chequeLogPaging.chequeLogRow = MapRecords(command);
			return chequeLogPaging;
		}
		public virtual ChequeLogPaging GetPagingRelyOnChequeLogIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ChequeLogPaging chequeLogPaging = new ChequeLogPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ChequeLogID) as TotalRow from [dbo].[ChequeLog]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			chequeLogPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			chequeLogPaging.totalPage = (int)Math.Ceiling((double)chequeLogPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnChequeLogID(whereSql, "ChequeLogID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			chequeLogPaging.chequeLogRow = MapRecords(command);
			return chequeLogPaging;
		}
		public virtual ChequeLogRow[] GetPagingRelyOnChequeLogIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minChequeLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ChequeLogID < " + minChequeLogID.ToString();
			}
			else
			{
				whereSql = "ChequeLogID < " + minChequeLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnChequeLogID(whereSql, "ChequeLogID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ChequeLogRow[] GetPagingRelyOnChequeLogIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minChequeLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ChequeLogID > " + minChequeLogID.ToString();
			}
			else
			{
				whereSql = "ChequeLogID > " + minChequeLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnChequeLogID(whereSql, "ChequeLogID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ChequeLogRow[] GetPagingRelyOnChequeLogIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxChequeLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ChequeLogID < " + maxChequeLogID.ToString();
			}
			else
			{
				whereSql = "ChequeLogID < " + maxChequeLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnChequeLogID(whereSql, "ChequeLogID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ChequeLogRow[] GetPagingRelyOnChequeLogIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxChequeLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ChequeLogID > " + maxChequeLogID.ToString();
			}
			else
			{
				whereSql = "ChequeLogID > " + maxChequeLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnChequeLogID(whereSql, "ChequeLogID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ChequeLogRow[] GetPagingRelyOnChequeLogIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ChequeLogID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			ChequeLogRow[] chequeLogRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnChequeLogID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				chequeLogRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnChequeLogIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				chequeLogRow = MapRecords(command);
			}
			return chequeLogRow;
		}
		public virtual ChequeLogRow[] GetPagingRelyOnChequeLogIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ChequeLogID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			ChequeLogRow[] chequeLogRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnChequeLogID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				chequeLogRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnChequeLogIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				chequeLogRow = MapRecords(command);
			}
			return chequeLogRow;
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
			"[ChequeLogID],"+
			"[TransactionID],"+
			"[ChequeNo],"+
			"[Amount],"+
			"[ChequeStatus],"+
			"[ChequeNote],"+
			"[MoneyOrderCertificateNumber],"+
			"[DateCreated],"+
			"[ModifiedDate],"+
			"[AdditionalDataJson],"+
			"[LastModifiedByUserID],"+
			"[FlagDelete]"+
			" FROM [dbo].[ChequeLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnChequeLogID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ChequeLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnChequeLogIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ChequeLogID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ChequeLog] where ChequeLogID < (select min(minChequeLogID) from(select top " + (rowPerPage * pageNumber).ToString() + " ChequeLogID as minChequeLogID from [dbo].[ChequeLog]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ChequeLog]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnChequeLogIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ChequeLogID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ChequeLog] where ChequeLogID > (select max(maxChequeLogID) from(select top " + (rowPerPage * pageNumber).ToString() + " ChequeLogID as maxChequeLogID from [dbo].[ChequeLog]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ChequeLog]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ChequeLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ChequeLog"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ChequeLogID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ChequeNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Amount",Type.GetType("System.Double"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ChequeStatus",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ChequeNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 3000;
			dataColumn = dataTable.Columns.Add("MoneyOrderCertificateNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DateCreated",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AdditionalDataJson",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("LastModifiedByUserID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FlagDelete",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual ChequeLogRow[] GetByTransactionID(int transactionID)
		{
			return MapRecords(CreateGetByTransactionIDCommand(transactionID));
		}
		public virtual DataTable GetByTransactionIDAsDataTable(int transactionID)
		{
			return MapRecordsToDataTable(CreateGetByTransactionIDCommand(transactionID));
		}
		protected virtual IDbCommand CreateGetByTransactionIDCommand(int transactionID)
		{
			string whereSql = "";
			whereSql += "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionID", transactionID);
			return cmd;
		}
		public virtual ChequeLogRow[] GetByLastModifiedByUserID(int lastModifiedByUserID)
		{
			return MapRecords(CreateGetByLastModifiedByUserIDCommand(lastModifiedByUserID));
		}
		public virtual DataTable GetByLastModifiedByUserIDAsDataTable(int lastModifiedByUserID)
		{
			return MapRecordsToDataTable(CreateGetByLastModifiedByUserIDCommand(lastModifiedByUserID));
		}
		protected virtual IDbCommand CreateGetByLastModifiedByUserIDCommand(int lastModifiedByUserID)
		{
			string whereSql = "";
			whereSql += "[LastModifiedByUserID]=" + CreateSqlParameterName("LastModifiedByUserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LastModifiedByUserID", lastModifiedByUserID);
			return cmd;
		}
		public ChequeLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ChequeLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ChequeLogRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ChequeLogRow"/> objects.</returns>
		public virtual ChequeLogRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ChequeLog]", top);
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
		public ChequeLogRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ChequeLogRow[] rows = null;
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
		public DataTable GetChequeLogPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ChequeLogID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ChequeLogID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[ChequeLog] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ChequeLogID,TransactionID,ChequeNo,Amount,ChequeStatus,ChequeNote,MoneyOrderCertificateNumber,DateCreated,ModifiedDate,AdditionalDataJson,LastModifiedByUserID,FlagDelete," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [ChequeLog].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ChequeLog] " + whereSql +
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
		public ChequeLogItemsPaging GetChequeLogPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ChequeLogID")
		{
		ChequeLogItemsPaging obj = new ChequeLogItemsPaging();
		DataTable dt = GetChequeLogPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ChequeLogItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ChequeLogItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ChequeLogID = Convert.ToInt32(dt.Rows[i]["ChequeLogID"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.ChequeNo = dt.Rows[i]["ChequeNo"].ToString();
			record.Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
			record.ChequeStatus = dt.Rows[i]["ChequeStatus"].ToString();
			record.ChequeNote = dt.Rows[i]["ChequeNote"].ToString();
			record.MoneyOrderCertificateNumber = dt.Rows[i]["MoneyOrderCertificateNumber"].ToString();
			record.DateCreated = Convert.ToDateTime(dt.Rows[i]["DateCreated"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.AdditionalDataJson = dt.Rows[i]["AdditionalDataJson"].ToString();
			if (dt.Rows[i]["LastModifiedByUserID"] != DBNull.Value)
			record.LastModifiedByUserID = Convert.ToInt32(dt.Rows[i]["LastModifiedByUserID"]);
			record.FlagDelete = Convert.ToBoolean(dt.Rows[i]["FlagDelete"]);
			recordList.Add(record);
		}
		obj.chequeLogItems = (ChequeLogItems[])(recordList.ToArray(typeof(ChequeLogItems)));
		return obj;
		}
		public ChequeLogRow GetByPrimaryKey(int chequeLogID)
		{
			string whereSql = "[ChequeLogID]=" + CreateSqlParameterName("ChequeLogID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ChequeLogID", chequeLogID);
			ChequeLogRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(ChequeLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ChequeLog] (" +
			"[TransactionID], " + 
			"[ChequeNo], " + 
			"[Amount], " + 
			"[ChequeStatus], " + 
			"[ChequeNote], " + 
			"[MoneyOrderCertificateNumber], " + 
			"[DateCreated], " + 
			"[ModifiedDate], " + 
			"[AdditionalDataJson], " + 
			"[LastModifiedByUserID], " + 
			"[FlagDelete]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("ChequeNo") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("ChequeStatus") + ", " +
			CreateSqlParameterName("ChequeNote") + ", " +
			CreateSqlParameterName("MoneyOrderCertificateNumber") + ", " +
			CreateSqlParameterName("DateCreated") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("AdditionalDataJson") + ", " +
			CreateSqlParameterName("LastModifiedByUserID") + ", " +
			CreateSqlParameterName("FlagDelete") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "ChequeNo",value.ChequeNo);
			AddParameter(cmd, "Amount", value.Amount);
			AddParameter(cmd, "ChequeStatus",value.ChequeStatus);
			AddParameter(cmd, "ChequeNote", value.ChequeNote);
			AddParameter(cmd, "MoneyOrderCertificateNumber", value.MoneyOrderCertificateNumber);
			AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			AddParameter(cmd, "AdditionalDataJson", value.AdditionalDataJson);
			AddParameter(cmd, "LastModifiedByUserID", value.IsLastModifiedByUserIDNull ? DBNull.Value : (object)value.LastModifiedByUserID);
			AddParameter(cmd, "FlagDelete", value.FlagDelete);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(ChequeLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ChequeLog] (" +
			"[TransactionID], " + 
			"[ChequeNo], " + 
			"[Amount], " + 
			"[ChequeStatus], " + 
			"[ChequeNote], " + 
			"[MoneyOrderCertificateNumber], " + 
			"[DateCreated], " + 
			"[ModifiedDate], " + 
			"[AdditionalDataJson], " + 
			"[LastModifiedByUserID], " + 
			"[FlagDelete]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("ChequeNo") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("ChequeStatus") + ", " +
			CreateSqlParameterName("ChequeNote") + ", " +
			CreateSqlParameterName("MoneyOrderCertificateNumber") + ", " +
			CreateSqlParameterName("DateCreated") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("AdditionalDataJson") + ", " +
			CreateSqlParameterName("LastModifiedByUserID") + ", " +
			CreateSqlParameterName("FlagDelete") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "ChequeNo", Sanitizer.GetSafeHtmlFragment(value.ChequeNo));
			AddParameter(cmd, "Amount", value.Amount);
			AddParameter(cmd, "ChequeStatus", Sanitizer.GetSafeHtmlFragment(value.ChequeStatus));
			AddParameter(cmd, "ChequeNote", Sanitizer.GetSafeHtmlFragment(value.ChequeNote));
			AddParameter(cmd, "MoneyOrderCertificateNumber", Sanitizer.GetSafeHtmlFragment(value.MoneyOrderCertificateNumber));
			AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			AddParameter(cmd, "AdditionalDataJson", Sanitizer.GetSafeHtmlFragment(value.AdditionalDataJson));
			AddParameter(cmd, "LastModifiedByUserID", value.IsLastModifiedByUserIDNull ? DBNull.Value : (object)value.LastModifiedByUserID);
			AddParameter(cmd, "FlagDelete", value.FlagDelete);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(ChequeLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetChequeLogID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionID)
				{
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID") + ",";
				}
				if (value._IsSetChequeNo)
				{
					strUpdate += "[ChequeNo]=" + CreateSqlParameterName("ChequeNo") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetChequeStatus)
				{
					strUpdate += "[ChequeStatus]=" + CreateSqlParameterName("ChequeStatus") + ",";
				}
				if (value._IsSetChequeNote)
				{
					strUpdate += "[ChequeNote]=" + CreateSqlParameterName("ChequeNote") + ",";
				}
				if (value._IsSetMoneyOrderCertificateNumber)
				{
					strUpdate += "[MoneyOrderCertificateNumber]=" + CreateSqlParameterName("MoneyOrderCertificateNumber") + ",";
				}
				if (value._IsSetDateCreated)
				{
					strUpdate += "[DateCreated]=" + CreateSqlParameterName("DateCreated") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetAdditionalDataJson)
				{
					strUpdate += "[AdditionalDataJson]=" + CreateSqlParameterName("AdditionalDataJson") + ",";
				}
				if (value._IsSetLastModifiedByUserID)
				{
					strUpdate += "[LastModifiedByUserID]=" + CreateSqlParameterName("LastModifiedByUserID") + ",";
				}
				if (value._IsSetFlagDelete)
				{
					strUpdate += "[FlagDelete]=" + CreateSqlParameterName("FlagDelete") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ChequeLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ChequeLogID]=" + CreateSqlParameterName("ChequeLogID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ChequeLogID", value.ChequeLogID);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "ChequeNo",value.ChequeNo);
					AddParameter(cmd, "Amount", value.Amount);
					AddParameter(cmd, "ChequeStatus",value.ChequeStatus);
					AddParameter(cmd, "ChequeNote", value.ChequeNote);
					AddParameter(cmd, "MoneyOrderCertificateNumber", value.MoneyOrderCertificateNumber);
					AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
					AddParameter(cmd, "AdditionalDataJson", value.AdditionalDataJson);
					AddParameter(cmd, "LastModifiedByUserID", value.IsLastModifiedByUserIDNull ? DBNull.Value : (object)value.LastModifiedByUserID);
					AddParameter(cmd, "FlagDelete", value.FlagDelete);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ChequeLogID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ChequeLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetChequeLogID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionID)
				{
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID") + ",";
				}
				if (value._IsSetChequeNo)
				{
					strUpdate += "[ChequeNo]=" + CreateSqlParameterName("ChequeNo") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetChequeStatus)
				{
					strUpdate += "[ChequeStatus]=" + CreateSqlParameterName("ChequeStatus") + ",";
				}
				if (value._IsSetChequeNote)
				{
					strUpdate += "[ChequeNote]=" + CreateSqlParameterName("ChequeNote") + ",";
				}
				if (value._IsSetMoneyOrderCertificateNumber)
				{
					strUpdate += "[MoneyOrderCertificateNumber]=" + CreateSqlParameterName("MoneyOrderCertificateNumber") + ",";
				}
				if (value._IsSetDateCreated)
				{
					strUpdate += "[DateCreated]=" + CreateSqlParameterName("DateCreated") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetAdditionalDataJson)
				{
					strUpdate += "[AdditionalDataJson]=" + CreateSqlParameterName("AdditionalDataJson") + ",";
				}
				if (value._IsSetLastModifiedByUserID)
				{
					strUpdate += "[LastModifiedByUserID]=" + CreateSqlParameterName("LastModifiedByUserID") + ",";
				}
				if (value._IsSetFlagDelete)
				{
					strUpdate += "[FlagDelete]=" + CreateSqlParameterName("FlagDelete") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ChequeLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ChequeLogID]=" + CreateSqlParameterName("ChequeLogID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ChequeLogID", value.ChequeLogID);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "ChequeNo", Sanitizer.GetSafeHtmlFragment(value.ChequeNo));
					AddParameter(cmd, "Amount", value.Amount);
					AddParameter(cmd, "ChequeStatus", Sanitizer.GetSafeHtmlFragment(value.ChequeStatus));
					AddParameter(cmd, "ChequeNote", Sanitizer.GetSafeHtmlFragment(value.ChequeNote));
					AddParameter(cmd, "MoneyOrderCertificateNumber", Sanitizer.GetSafeHtmlFragment(value.MoneyOrderCertificateNumber));
					AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
					AddParameter(cmd, "AdditionalDataJson", Sanitizer.GetSafeHtmlFragment(value.AdditionalDataJson));
					AddParameter(cmd, "LastModifiedByUserID", value.IsLastModifiedByUserIDNull ? DBNull.Value : (object)value.LastModifiedByUserID);
					AddParameter(cmd, "FlagDelete", value.FlagDelete);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ChequeLogID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int chequeLogID)
		{
			string whereSql = "[ChequeLogID]=" + CreateSqlParameterName("ChequeLogID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ChequeLogID", chequeLogID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByTransactionID(int transactionID)
		{
			return CreateDeleteByTransactionIDCommand(transactionID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTransactionIDCommand(int transactionID)
		{
			string whereSql = "";
			whereSql += "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionID", transactionID);
			return cmd;
		}
		public int DeleteByLastModifiedByUserID(int lastModifiedByUserID)
		{
			return DeleteByLastModifiedByUserID(lastModifiedByUserID, false);
		}
		public int DeleteByLastModifiedByUserID(int lastModifiedByUserID, bool lastModifiedByUserIDNull)
		{
			return CreateDeleteByLastModifiedByUserIDCommand(lastModifiedByUserID, lastModifiedByUserIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByLastModifiedByUserIDCommand(int lastModifiedByUserID, bool lastModifiedByUserIDNull)
		{
			string whereSql = "";
			if (lastModifiedByUserIDNull)
				whereSql += "[LastModifiedByUserID] IS NULL";
			else
				whereSql += "[LastModifiedByUserID]=" + CreateSqlParameterName("LastModifiedByUserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!lastModifiedByUserIDNull)
				AddParameter(cmd, "LastModifiedByUserID", lastModifiedByUserID);
			return cmd;
		}
		protected ChequeLogRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ChequeLogRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ChequeLogRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int chequeLogIDColumnIndex = reader.GetOrdinal("ChequeLogID");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int chequeNoColumnIndex = reader.GetOrdinal("ChequeNo");
			int amountColumnIndex = reader.GetOrdinal("Amount");
			int chequeStatusColumnIndex = reader.GetOrdinal("ChequeStatus");
			int chequeNoteColumnIndex = reader.GetOrdinal("ChequeNote");
			int moneyOrderCertificateNumberColumnIndex = reader.GetOrdinal("MoneyOrderCertificateNumber");
			int dateCreatedColumnIndex = reader.GetOrdinal("DateCreated");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int additionalDataJsonColumnIndex = reader.GetOrdinal("AdditionalDataJson");
			int lastModifiedByUserIDColumnIndex = reader.GetOrdinal("LastModifiedByUserID");
			int flagDeleteColumnIndex = reader.GetOrdinal("FlagDelete");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ChequeLogRow record = new ChequeLogRow();
					recordList.Add(record);
					record.ChequeLogID =  Convert.ToInt32(reader.GetValue(chequeLogIDColumnIndex));
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					record.ChequeNo =  Convert.ToString(reader.GetValue(chequeNoColumnIndex));
					record.Amount =  Convert.ToDouble(reader.GetValue(amountColumnIndex));
					record.ChequeStatus =  Convert.ToString(reader.GetValue(chequeStatusColumnIndex));
					if (!reader.IsDBNull(chequeNoteColumnIndex)) record.ChequeNote =  Convert.ToString(reader.GetValue(chequeNoteColumnIndex));

					if (!reader.IsDBNull(moneyOrderCertificateNumberColumnIndex)) record.MoneyOrderCertificateNumber =  Convert.ToString(reader.GetValue(moneyOrderCertificateNumberColumnIndex));

					record.DateCreated =  Convert.ToDateTime(reader.GetValue(dateCreatedColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (!reader.IsDBNull(additionalDataJsonColumnIndex)) record.AdditionalDataJson =  Convert.ToString(reader.GetValue(additionalDataJsonColumnIndex));

					if (!reader.IsDBNull(lastModifiedByUserIDColumnIndex)) record.LastModifiedByUserID =  Convert.ToInt32(reader.GetValue(lastModifiedByUserIDColumnIndex));

					record.FlagDelete =  Convert.ToBoolean(reader.GetValue(flagDeleteColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ChequeLogRow[])(recordList.ToArray(typeof(ChequeLogRow)));
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
				case "ChequeLogID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ChequeNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Amount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ChequeStatus":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ChequeNote":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "MoneyOrderCertificateNumber":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DateCreated":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "AdditionalDataJson":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LastModifiedByUserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FlagDelete":
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

