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
	public partial class TransactionDetailCollection_Base : MarshalByRefObject
	{
		public const string TransactionDetailIDColumnName = "TransactionDetailID";
		public const string TransactionIDColumnName = "TransactionID";
		public const string BudgetIDColumnName = "BudgetID";
		public const string QtyColumnName = "Qty";
		public const string AmountColumnName = "Amount";
		public const string LineTotalColumnName = "LineTotal";
		public const string UnitColumnName = "Unit";
		public const string NoteColumnName = "Note";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public TransactionDetailCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual TransactionDetailRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual TransactionDetailPaging GetPagingRelyOnTransactionDetailIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TransactionDetailPaging transactionDetailPaging = new TransactionDetailPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionDetailID) as TotalRow from [dbo].[TransactionDetail]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			transactionDetailPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			transactionDetailPaging.totalPage = (int)Math.Ceiling((double) transactionDetailPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionDetailID(whereSql, "TransactionDetailID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			transactionDetailPaging.transactionDetailRow = MapRecords(command);
			return transactionDetailPaging;
		}
		public virtual TransactionDetailPaging GetPagingRelyOnTransactionDetailIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TransactionDetailPaging transactionDetailPaging = new TransactionDetailPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionDetailID) as TotalRow from [dbo].[TransactionDetail]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			transactionDetailPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			transactionDetailPaging.totalPage = (int)Math.Ceiling((double)transactionDetailPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionDetailID(whereSql, "TransactionDetailID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			transactionDetailPaging.transactionDetailRow = MapRecords(command);
			return transactionDetailPaging;
		}
		public virtual TransactionDetailRow[] GetPagingRelyOnTransactionDetailIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionDetailID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionDetailID < " + minTransactionDetailID.ToString();
			}
			else
			{
				whereSql = "TransactionDetailID < " + minTransactionDetailID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionDetailID(whereSql, "TransactionDetailID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionDetailRow[] GetPagingRelyOnTransactionDetailIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionDetailID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionDetailID > " + minTransactionDetailID.ToString();
			}
			else
			{
				whereSql = "TransactionDetailID > " + minTransactionDetailID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionDetailID(whereSql, "TransactionDetailID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionDetailRow[] GetPagingRelyOnTransactionDetailIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionDetailID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionDetailID < " + maxTransactionDetailID.ToString();
			}
			else
			{
				whereSql = "TransactionDetailID < " + maxTransactionDetailID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionDetailID(whereSql, "TransactionDetailID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionDetailRow[] GetPagingRelyOnTransactionDetailIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionDetailID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionDetailID > " + maxTransactionDetailID.ToString();
			}
			else
			{
				whereSql = "TransactionDetailID > " + maxTransactionDetailID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionDetailID(whereSql, "TransactionDetailID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionDetailRow[] GetPagingRelyOnTransactionDetailIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionDetailID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			TransactionDetailRow[] transactionDetailRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionDetailID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionDetailRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionDetailIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionDetailRow = MapRecords(command);
			}
			return transactionDetailRow;
		}
		public virtual TransactionDetailRow[] GetPagingRelyOnTransactionDetailIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionDetailID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			TransactionDetailRow[] transactionDetailRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionDetailID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionDetailRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionDetailIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionDetailRow = MapRecords(command);
			}
			return transactionDetailRow;
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
			"[TransactionDetailID],"+
			"[TransactionID],"+
			"[BudgetID],"+
			"[Qty],"+
			"[Amount],"+
			"[LineTotal],"+
			"[Unit],"+
			"[Note],"+
			"[ModifiedDate]"+
			" FROM [dbo].[TransactionDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionDetailID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionDetailIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionDetailID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionDetail] where TransactionDetailID < (select min(minTransactionDetailID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionDetailID as minTransactionDetailID from [dbo].[TransactionDetail]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[TransactionDetail]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionDetailIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionDetailID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionDetail] where TransactionDetailID > (select max(maxTransactionDetailID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionDetailID as maxTransactionDetailID from [dbo].[TransactionDetail]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[TransactionDetail]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[TransactionDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "TransactionDetail"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionDetailID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BudgetID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Qty",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Amount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("LineTotal",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Unit",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual TransactionDetailRow[] GetByTransactionID(int transactionID)
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
		public TransactionDetailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual TransactionDetailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="TransactionDetailRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TransactionDetailRow"/> objects.</returns>
		public virtual TransactionDetailRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[TransactionDetail]", top);
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
		public TransactionDetailRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			TransactionDetailRow[] rows = null;
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
		public DataTable GetTransactionDetailPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionDetailID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TransactionDetailID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TransactionDetailID) AS TotalRow FROM [dbo].[TransactionDetail] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionDetailID,TransactionID,BudgetID,Qty,Amount,LineTotal,Unit,Note,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [TransactionDetail].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[TransactionDetail] " + whereSql +
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
		public TransactionDetailItemsPaging GetTransactionDetailPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionDetailID")
		{
		TransactionDetailItemsPaging obj = new TransactionDetailItemsPaging();
		DataTable dt = GetTransactionDetailPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		TransactionDetailItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new TransactionDetailItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionDetailID = Convert.ToInt32(dt.Rows[i]["TransactionDetailID"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			if (dt.Rows[i]["BudgetID"] != DBNull.Value)
			record.BudgetID = Convert.ToInt32(dt.Rows[i]["BudgetID"]);
			if (dt.Rows[i]["Qty"] != DBNull.Value)
			record.Qty = Convert.ToInt32(dt.Rows[i]["Qty"]);
			if (dt.Rows[i]["Amount"] != DBNull.Value)
			record.Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
			if (dt.Rows[i]["LineTotal"] != DBNull.Value)
			record.LineTotal = Convert.ToDouble(dt.Rows[i]["LineTotal"]);
			record.Unit = dt.Rows[i]["Unit"].ToString();
			record.Note = dt.Rows[i]["Note"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.transactionDetailItems = (TransactionDetailItems[])(recordList.ToArray(typeof(TransactionDetailItems)));
		return obj;
		}
		public TransactionDetailRow GetByPrimaryKey(int transactionDetailID, int transactionID)
		{
			string whereSql = "[TransactionDetailID]=" + CreateSqlParameterName("TransactionDetailID") + " AND [TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionDetailID", transactionDetailID);
			AddParameter(cmd, "TransactionID", transactionID);
			TransactionDetailRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(TransactionDetailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TransactionDetail] (" +
			"[TransactionID], " + 
			"[BudgetID], " + 
			"[Qty], " + 
			"[Amount], " + 
			"[LineTotal], " + 
			"[Unit], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("BudgetID") + ", " +
			CreateSqlParameterName("Qty") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("LineTotal") + ", " +
			CreateSqlParameterName("Unit") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "BudgetID", value.IsBudgetIDNull ? DBNull.Value : (object)value.BudgetID);
			AddParameter(cmd, "Qty", value.IsQtyNull ? DBNull.Value : (object)value.Qty);
			AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
			AddParameter(cmd, "LineTotal", value.IsLineTotalNull ? DBNull.Value : (object)value.LineTotal);
			AddParameter(cmd, "Unit", value.Unit);
			AddParameter(cmd, "Note", value.Note);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(TransactionDetailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TransactionDetail] (" +
			"[TransactionID], " + 
			"[BudgetID], " + 
			"[Qty], " + 
			"[Amount], " + 
			"[LineTotal], " + 
			"[Unit], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("BudgetID") + ", " +
			CreateSqlParameterName("Qty") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("LineTotal") + ", " +
			CreateSqlParameterName("Unit") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "BudgetID", value.IsBudgetIDNull ? DBNull.Value : (object)value.BudgetID);
			AddParameter(cmd, "Qty", value.IsQtyNull ? DBNull.Value : (object)value.Qty);
			AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
			AddParameter(cmd, "LineTotal", value.IsLineTotalNull ? DBNull.Value : (object)value.LineTotal);
			AddParameter(cmd, "Unit", Sanitizer.GetSafeHtmlFragment(value.Unit));
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(TransactionDetailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionDetailID == true && value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetBudgetID)
				{
					strUpdate += "[BudgetID]=" + CreateSqlParameterName("BudgetID") + ",";
				}
				if (value._IsSetQty)
				{
					strUpdate += "[Qty]=" + CreateSqlParameterName("Qty") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetLineTotal)
				{
					strUpdate += "[LineTotal]=" + CreateSqlParameterName("LineTotal") + ",";
				}
				if (value._IsSetUnit)
				{
					strUpdate += "[Unit]=" + CreateSqlParameterName("Unit") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TransactionDetail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionDetailID]=" + CreateSqlParameterName("TransactionDetailID")+ " AND [TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionDetailID", value.TransactionDetailID);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "BudgetID", value.IsBudgetIDNull ? DBNull.Value : (object)value.BudgetID);
					AddParameter(cmd, "Qty", value.IsQtyNull ? DBNull.Value : (object)value.Qty);
					AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
					AddParameter(cmd, "LineTotal", value.IsLineTotalNull ? DBNull.Value : (object)value.LineTotal);
					AddParameter(cmd, "Unit", value.Unit);
					AddParameter(cmd, "Note", value.Note);
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
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionDetailID,TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(TransactionDetailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionDetailID == true && value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetBudgetID)
				{
					strUpdate += "[BudgetID]=" + CreateSqlParameterName("BudgetID") + ",";
				}
				if (value._IsSetQty)
				{
					strUpdate += "[Qty]=" + CreateSqlParameterName("Qty") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetLineTotal)
				{
					strUpdate += "[LineTotal]=" + CreateSqlParameterName("LineTotal") + ",";
				}
				if (value._IsSetUnit)
				{
					strUpdate += "[Unit]=" + CreateSqlParameterName("Unit") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TransactionDetail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionDetailID]=" + CreateSqlParameterName("TransactionDetailID")+ " AND [TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionDetailID", value.TransactionDetailID);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "BudgetID", value.IsBudgetIDNull ? DBNull.Value : (object)value.BudgetID);
					AddParameter(cmd, "Qty", value.IsQtyNull ? DBNull.Value : (object)value.Qty);
					AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
					AddParameter(cmd, "LineTotal", value.IsLineTotalNull ? DBNull.Value : (object)value.LineTotal);
					AddParameter(cmd, "Unit", Sanitizer.GetSafeHtmlFragment(value.Unit));
					AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
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
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionDetailID,TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int transactionDetailID, int transactionID)
		{
			string whereSql = "[TransactionDetailID]=" + CreateSqlParameterName("TransactionDetailID") + " AND [TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionDetailID", transactionDetailID);
			AddParameter(cmd, "TransactionID", transactionID);
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
		protected TransactionDetailRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected TransactionDetailRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected TransactionDetailRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionDetailIDColumnIndex = reader.GetOrdinal("TransactionDetailID");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int budgetIDColumnIndex = reader.GetOrdinal("BudgetID");
			int qtyColumnIndex = reader.GetOrdinal("Qty");
			int amountColumnIndex = reader.GetOrdinal("Amount");
			int lineTotalColumnIndex = reader.GetOrdinal("LineTotal");
			int unitColumnIndex = reader.GetOrdinal("Unit");
			int noteColumnIndex = reader.GetOrdinal("Note");
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
					TransactionDetailRow record = new TransactionDetailRow();
					recordList.Add(record);
					record.TransactionDetailID =  Convert.ToInt32(reader.GetValue(transactionDetailIDColumnIndex));
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(budgetIDColumnIndex)) record.BudgetID =  Convert.ToInt32(reader.GetValue(budgetIDColumnIndex));

					if (!reader.IsDBNull(qtyColumnIndex)) record.Qty =  Convert.ToInt32(reader.GetValue(qtyColumnIndex));

					if (!reader.IsDBNull(amountColumnIndex)) record.Amount =  Convert.ToDouble(reader.GetValue(amountColumnIndex));

					if (!reader.IsDBNull(lineTotalColumnIndex)) record.LineTotal =  Convert.ToDouble(reader.GetValue(lineTotalColumnIndex));

					if (!reader.IsDBNull(unitColumnIndex)) record.Unit =  Convert.ToString(reader.GetValue(unitColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TransactionDetailRow[])(recordList.ToArray(typeof(TransactionDetailRow)));
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
				case "TransactionDetailID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "BudgetID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Qty":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Amount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "LineTotal":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Unit":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Note":
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

