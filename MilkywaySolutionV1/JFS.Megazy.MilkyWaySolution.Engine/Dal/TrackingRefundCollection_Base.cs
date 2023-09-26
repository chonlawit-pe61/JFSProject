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
	public partial class TrackingRefundCollection_Base : MarshalByRefObject
	{
		public const string TrakingRefundIDColumnName = "TrakingRefundID";
		public const string TransactionIDColumnName = "TransactionID";
		public const string ContractIDColumnName = "ContractID";
		public const string DescriptionColumnName = "Description";
		public const string AmountColumnName = "Amount";
		public const string RequestDateColumnName = "RequestDate";
		public const string ReceivedAmountColumnName = "ReceivedAmount";
		public const string ReceivedDateColumnName = "ReceivedDate";
		public const string RefundStatusIDColumnName = "RefundStatusID";
		public const string NoteColumnName = "Note";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public TrackingRefundCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual TrackingRefundRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual TrackingRefundPaging GetPagingRelyOnTrakingRefundIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TrackingRefundPaging trackingRefundPaging = new TrackingRefundPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TrakingRefundID) as TotalRow from [dbo].[TrackingRefund]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			trackingRefundPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			trackingRefundPaging.totalPage = (int)Math.Ceiling((double) trackingRefundPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTrakingRefundID(whereSql, "TrakingRefundID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			trackingRefundPaging.trackingRefundRow = MapRecords(command);
			return trackingRefundPaging;
		}
		public virtual TrackingRefundPaging GetPagingRelyOnTrakingRefundIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TrackingRefundPaging trackingRefundPaging = new TrackingRefundPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TrakingRefundID) as TotalRow from [dbo].[TrackingRefund]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			trackingRefundPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			trackingRefundPaging.totalPage = (int)Math.Ceiling((double)trackingRefundPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTrakingRefundID(whereSql, "TrakingRefundID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			trackingRefundPaging.trackingRefundRow = MapRecords(command);
			return trackingRefundPaging;
		}
		public virtual TrackingRefundRow[] GetPagingRelyOnTrakingRefundIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTrakingRefundID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TrakingRefundID < " + minTrakingRefundID.ToString();
			}
			else
			{
				whereSql = "TrakingRefundID < " + minTrakingRefundID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTrakingRefundID(whereSql, "TrakingRefundID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TrackingRefundRow[] GetPagingRelyOnTrakingRefundIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTrakingRefundID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TrakingRefundID > " + minTrakingRefundID.ToString();
			}
			else
			{
				whereSql = "TrakingRefundID > " + minTrakingRefundID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTrakingRefundID(whereSql, "TrakingRefundID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TrackingRefundRow[] GetPagingRelyOnTrakingRefundIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTrakingRefundID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TrakingRefundID < " + maxTrakingRefundID.ToString();
			}
			else
			{
				whereSql = "TrakingRefundID < " + maxTrakingRefundID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTrakingRefundID(whereSql, "TrakingRefundID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TrackingRefundRow[] GetPagingRelyOnTrakingRefundIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTrakingRefundID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TrakingRefundID > " + maxTrakingRefundID.ToString();
			}
			else
			{
				whereSql = "TrakingRefundID > " + maxTrakingRefundID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTrakingRefundID(whereSql, "TrakingRefundID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TrackingRefundRow[] GetPagingRelyOnTrakingRefundIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TrakingRefundID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			TrackingRefundRow[] trackingRefundRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTrakingRefundID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				trackingRefundRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTrakingRefundIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				trackingRefundRow = MapRecords(command);
			}
			return trackingRefundRow;
		}
		public virtual TrackingRefundRow[] GetPagingRelyOnTrakingRefundIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TrakingRefundID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			TrackingRefundRow[] trackingRefundRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTrakingRefundID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				trackingRefundRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTrakingRefundIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				trackingRefundRow = MapRecords(command);
			}
			return trackingRefundRow;
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
			"[TrakingRefundID],"+
			"[TransactionID],"+
			"[ContractID],"+
			"[Description],"+
			"[Amount],"+
			"[RequestDate],"+
			"[ReceivedAmount],"+
			"[ReceivedDate],"+
			"[RefundStatusID],"+
			"[Note],"+
			"[ModifiedDate]"+
			" FROM [dbo].[TrackingRefund]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTrakingRefundID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TrackingRefund]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTrakingRefundIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TrakingRefundID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TrackingRefund] where TrakingRefundID < (select min(minTrakingRefundID) from(select top " + (rowPerPage * pageNumber).ToString() + " TrakingRefundID as minTrakingRefundID from [dbo].[TrackingRefund]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[TrackingRefund]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTrakingRefundIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TrakingRefundID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TrackingRefund] where TrakingRefundID > (select max(maxTrakingRefundID) from(select top " + (rowPerPage * pageNumber).ToString() + " TrakingRefundID as maxTrakingRefundID from [dbo].[TrackingRefund]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[TrackingRefund]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[TrackingRefund]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "TrackingRefund"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TrakingRefundID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ContractID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Description",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("Amount",Type.GetType("System.Double"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RequestDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ReceivedAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("ReceivedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RefundStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual TrackingRefundRow[] GetByTransactionID(int transactionID)
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
		public virtual TrackingRefundRow[] GetByContractID(int contractID)
		{
			return MapRecords(CreateGetByContractIDCommand(contractID));
		}
		public virtual DataTable GetByContractIDAsDataTable(int contractID)
		{
			return MapRecordsToDataTable(CreateGetByContractIDCommand(contractID));
		}
		protected virtual IDbCommand CreateGetByContractIDCommand(int contractID)
		{
			string whereSql = "";
			whereSql += "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ContractID", contractID);
			return cmd;
		}
		public virtual TrackingRefundRow[] GetByRefundStatusID(int refundStatusID)
		{
			return MapRecords(CreateGetByRefundStatusIDCommand(refundStatusID));
		}
		public virtual DataTable GetByRefundStatusIDAsDataTable(int refundStatusID)
		{
			return MapRecordsToDataTable(CreateGetByRefundStatusIDCommand(refundStatusID));
		}
		protected virtual IDbCommand CreateGetByRefundStatusIDCommand(int refundStatusID)
		{
			string whereSql = "";
			whereSql += "[RefundStatusID]=" + CreateSqlParameterName("RefundStatusID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RefundStatusID", refundStatusID);
			return cmd;
		}
		public TrackingRefundRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual TrackingRefundRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="TrackingRefundRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TrackingRefundRow"/> objects.</returns>
		public virtual TrackingRefundRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[TrackingRefund]", top);
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
		public TrackingRefundRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			TrackingRefundRow[] rows = null;
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
		public DataTable GetTrackingRefundPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TrakingRefundID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TrakingRefundID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TrakingRefundID) AS TotalRow FROM [dbo].[TrackingRefund] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TrakingRefundID,TransactionID,ContractID,Description,Amount,RequestDate,ReceivedAmount,ReceivedDate,RefundStatusID,Note,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[TrackingRefund] " + whereSql +
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
		public TrackingRefundItemsPaging GetTrackingRefundPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TrakingRefundID")
		{
		TrackingRefundItemsPaging obj = new TrackingRefundItemsPaging();
		DataTable dt = GetTrackingRefundPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		TrackingRefundItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new TrackingRefundItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TrakingRefundID = Convert.ToInt32(dt.Rows[i]["TrakingRefundID"]);
			if (dt.Rows[i]["TransactionID"] != DBNull.Value)
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.ContractID = Convert.ToInt32(dt.Rows[i]["ContractID"]);
			record.Description = dt.Rows[i]["Description"].ToString();
			record.Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
			if (dt.Rows[i]["RequestDate"] != DBNull.Value)
			record.RequestDate = Convert.ToDateTime(dt.Rows[i]["RequestDate"]);
			if (dt.Rows[i]["ReceivedAmount"] != DBNull.Value)
			record.ReceivedAmount = Convert.ToDouble(dt.Rows[i]["ReceivedAmount"]);
			if (dt.Rows[i]["ReceivedDate"] != DBNull.Value)
			record.ReceivedDate = Convert.ToDateTime(dt.Rows[i]["ReceivedDate"]);
			record.RefundStatusID = Convert.ToInt32(dt.Rows[i]["RefundStatusID"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.trackingRefundItems = (TrackingRefundItems[])(recordList.ToArray(typeof(TrackingRefundItems)));
		return obj;
		}
		public TrackingRefundRow GetByPrimaryKey(int trakingRefundID)
		{
			string whereSql = "[TrakingRefundID]=" + CreateSqlParameterName("TrakingRefundID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TrakingRefundID", trakingRefundID);
			TrackingRefundRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(TrackingRefundRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TrackingRefund] (" +
			"[TransactionID], " + 
			"[ContractID], " + 
			"[Description], " + 
			"[Amount], " + 
			"[RequestDate], " + 
			"[ReceivedAmount], " + 
			"[ReceivedDate], " + 
			"[RefundStatusID], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("ContractID") + ", " +
			CreateSqlParameterName("Description") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("RequestDate") + ", " +
			CreateSqlParameterName("ReceivedAmount") + ", " +
			CreateSqlParameterName("ReceivedDate") + ", " +
			CreateSqlParameterName("RefundStatusID") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.IsTransactionIDNull ? DBNull.Value : (object)value.TransactionID);
			AddParameter(cmd, "ContractID", value.ContractID);
			AddParameter(cmd, "Description", value.Description);
			AddParameter(cmd, "Amount", value.Amount);
			AddParameter(cmd, "RequestDate", value.IsRequestDateNull ? DBNull.Value : (object)value.RequestDate);
			AddParameter(cmd, "ReceivedAmount", value.IsReceivedAmountNull ? DBNull.Value : (object)value.ReceivedAmount);
			AddParameter(cmd, "ReceivedDate", value.IsReceivedDateNull ? DBNull.Value : (object)value.ReceivedDate);
			AddParameter(cmd, "RefundStatusID", value.RefundStatusID);
			AddParameter(cmd, "Note", value.Note);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(TrackingRefundRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TrackingRefund] (" +
			"[TransactionID], " + 
			"[ContractID], " + 
			"[Description], " + 
			"[Amount], " + 
			"[RequestDate], " + 
			"[ReceivedAmount], " + 
			"[ReceivedDate], " + 
			"[RefundStatusID], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("ContractID") + ", " +
			CreateSqlParameterName("Description") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("RequestDate") + ", " +
			CreateSqlParameterName("ReceivedAmount") + ", " +
			CreateSqlParameterName("ReceivedDate") + ", " +
			CreateSqlParameterName("RefundStatusID") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.IsTransactionIDNull ? DBNull.Value : (object)value.TransactionID);
			AddParameter(cmd, "ContractID", value.ContractID);
			AddParameter(cmd, "Description", Sanitizer.GetSafeHtmlFragment(value.Description));
			AddParameter(cmd, "Amount", value.Amount);
			AddParameter(cmd, "RequestDate", value.IsRequestDateNull ? DBNull.Value : (object)value.RequestDate);
			AddParameter(cmd, "ReceivedAmount", value.IsReceivedAmountNull ? DBNull.Value : (object)value.ReceivedAmount);
			AddParameter(cmd, "ReceivedDate", value.IsReceivedDateNull ? DBNull.Value : (object)value.ReceivedDate);
			AddParameter(cmd, "RefundStatusID", value.RefundStatusID);
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(TrackingRefundRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTrakingRefundID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionID)
				{
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID") + ",";
				}
				if (value._IsSetContractID)
				{
					strUpdate += "[ContractID]=" + CreateSqlParameterName("ContractID") + ",";
				}
				if (value._IsSetDescription)
				{
					strUpdate += "[Description]=" + CreateSqlParameterName("Description") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetRequestDate)
				{
					strUpdate += "[RequestDate]=" + CreateSqlParameterName("RequestDate") + ",";
				}
				if (value._IsSetReceivedAmount)
				{
					strUpdate += "[ReceivedAmount]=" + CreateSqlParameterName("ReceivedAmount") + ",";
				}
				if (value._IsSetReceivedDate)
				{
					strUpdate += "[ReceivedDate]=" + CreateSqlParameterName("ReceivedDate") + ",";
				}
				if (value._IsSetRefundStatusID)
				{
					strUpdate += "[RefundStatusID]=" + CreateSqlParameterName("RefundStatusID") + ",";
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
					strUpdate = "UPDATE [dbo].[TrackingRefund] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TrakingRefundID]=" + CreateSqlParameterName("TrakingRefundID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TrakingRefundID", value.TrakingRefundID);
					AddParameter(cmd, "TransactionID", value.IsTransactionIDNull ? DBNull.Value : (object)value.TransactionID);
					AddParameter(cmd, "ContractID", value.ContractID);
					AddParameter(cmd, "Description", value.Description);
					AddParameter(cmd, "Amount", value.Amount);
					AddParameter(cmd, "RequestDate", value.IsRequestDateNull ? DBNull.Value : (object)value.RequestDate);
					AddParameter(cmd, "ReceivedAmount", value.IsReceivedAmountNull ? DBNull.Value : (object)value.ReceivedAmount);
					AddParameter(cmd, "ReceivedDate", value.IsReceivedDateNull ? DBNull.Value : (object)value.ReceivedDate);
					AddParameter(cmd, "RefundStatusID", value.RefundStatusID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(TrakingRefundID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(TrackingRefundRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTrakingRefundID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionID)
				{
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID") + ",";
				}
				if (value._IsSetContractID)
				{
					strUpdate += "[ContractID]=" + CreateSqlParameterName("ContractID") + ",";
				}
				if (value._IsSetDescription)
				{
					strUpdate += "[Description]=" + CreateSqlParameterName("Description") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetRequestDate)
				{
					strUpdate += "[RequestDate]=" + CreateSqlParameterName("RequestDate") + ",";
				}
				if (value._IsSetReceivedAmount)
				{
					strUpdate += "[ReceivedAmount]=" + CreateSqlParameterName("ReceivedAmount") + ",";
				}
				if (value._IsSetReceivedDate)
				{
					strUpdate += "[ReceivedDate]=" + CreateSqlParameterName("ReceivedDate") + ",";
				}
				if (value._IsSetRefundStatusID)
				{
					strUpdate += "[RefundStatusID]=" + CreateSqlParameterName("RefundStatusID") + ",";
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
					strUpdate = "UPDATE [dbo].[TrackingRefund] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TrakingRefundID]=" + CreateSqlParameterName("TrakingRefundID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TrakingRefundID", value.TrakingRefundID);
					AddParameter(cmd, "TransactionID", value.IsTransactionIDNull ? DBNull.Value : (object)value.TransactionID);
					AddParameter(cmd, "ContractID", value.ContractID);
					AddParameter(cmd, "Description", Sanitizer.GetSafeHtmlFragment(value.Description));
					AddParameter(cmd, "Amount", value.Amount);
					AddParameter(cmd, "RequestDate", value.IsRequestDateNull ? DBNull.Value : (object)value.RequestDate);
					AddParameter(cmd, "ReceivedAmount", value.IsReceivedAmountNull ? DBNull.Value : (object)value.ReceivedAmount);
					AddParameter(cmd, "ReceivedDate", value.IsReceivedDateNull ? DBNull.Value : (object)value.ReceivedDate);
					AddParameter(cmd, "RefundStatusID", value.RefundStatusID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(TrakingRefundID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int trakingRefundID)
		{
			string whereSql = "[TrakingRefundID]=" + CreateSqlParameterName("TrakingRefundID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TrakingRefundID", trakingRefundID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByTransactionID(int transactionID)
		{
			return DeleteByTransactionID(transactionID, false);
		}
		public int DeleteByTransactionID(int transactionID, bool transactionIDNull)
		{
			return CreateDeleteByTransactionIDCommand(transactionID, transactionIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTransactionIDCommand(int transactionID, bool transactionIDNull)
		{
			string whereSql = "";
			if (transactionIDNull)
				whereSql += "[TransactionID] IS NULL";
			else
				whereSql += "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!transactionIDNull)
				AddParameter(cmd, "TransactionID", transactionID);
			return cmd;
		}
		public int DeleteByContractID(int contractID)
		{
			return CreateDeleteByContractIDCommand(contractID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByContractIDCommand(int contractID)
		{
			string whereSql = "";
			whereSql += "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ContractID", contractID);
			return cmd;
		}
		public int DeleteByRefundStatusID(int refundStatusID)
		{
			return CreateDeleteByRefundStatusIDCommand(refundStatusID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByRefundStatusIDCommand(int refundStatusID)
		{
			string whereSql = "";
			whereSql += "[RefundStatusID]=" + CreateSqlParameterName("RefundStatusID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "RefundStatusID", refundStatusID);
			return cmd;
		}
		protected TrackingRefundRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected TrackingRefundRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected TrackingRefundRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int trakingRefundIDColumnIndex = reader.GetOrdinal("TrakingRefundID");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int contractIDColumnIndex = reader.GetOrdinal("ContractID");
			int descriptionColumnIndex = reader.GetOrdinal("Description");
			int amountColumnIndex = reader.GetOrdinal("Amount");
			int requestDateColumnIndex = reader.GetOrdinal("RequestDate");
			int receivedAmountColumnIndex = reader.GetOrdinal("ReceivedAmount");
			int receivedDateColumnIndex = reader.GetOrdinal("ReceivedDate");
			int refundStatusIDColumnIndex = reader.GetOrdinal("RefundStatusID");
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
					TrackingRefundRow record = new TrackingRefundRow();
					recordList.Add(record);
					record.TrakingRefundID =  Convert.ToInt32(reader.GetValue(trakingRefundIDColumnIndex));
					if (!reader.IsDBNull(transactionIDColumnIndex)) record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));

					record.ContractID =  Convert.ToInt32(reader.GetValue(contractIDColumnIndex));
					if (!reader.IsDBNull(descriptionColumnIndex)) record.Description =  Convert.ToString(reader.GetValue(descriptionColumnIndex));

					record.Amount =  Convert.ToDouble(reader.GetValue(amountColumnIndex));
					if (!reader.IsDBNull(requestDateColumnIndex)) record.RequestDate =  Convert.ToDateTime(reader.GetValue(requestDateColumnIndex));

					if (!reader.IsDBNull(receivedAmountColumnIndex)) record.ReceivedAmount =  Convert.ToDouble(reader.GetValue(receivedAmountColumnIndex));

					if (!reader.IsDBNull(receivedDateColumnIndex)) record.ReceivedDate =  Convert.ToDateTime(reader.GetValue(receivedDateColumnIndex));

					record.RefundStatusID =  Convert.ToInt32(reader.GetValue(refundStatusIDColumnIndex));
					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TrackingRefundRow[])(recordList.ToArray(typeof(TrackingRefundRow)));
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
				case "TrakingRefundID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ContractID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Description":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Amount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "RequestDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ReceivedAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ReceivedDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "RefundStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

