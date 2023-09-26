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
	public partial class AccusedTrackingDetailCollection_Base : MarshalByRefObject
	{
		public const string TrackingIDColumnName = "TrackingID";
		public const string AccusedTrackingIDColumnName = "AccusedTrackingID";
		public const string TrackingCodeColumnName = "TrackingCode";
		public const string DueDateColumnName = "DueDate";
		public const string ReportDateColumnName = "ReportDate";
		public const string ReportToOfficerNameColumnName = "ReportToOfficerName";
		public const string ReportAtCodeColumnName = "ReportAtCode";
		public const string LocationNameColumnName = "LocationName";
		public const string NoteColumnName = "Note";
		public const string UserIDColumnName = "UserID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public AccusedTrackingDetailCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual AccusedTrackingDetailRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual AccusedTrackingDetailPaging GetPagingRelyOnTrackingIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			AccusedTrackingDetailPaging accusedTrackingDetailPaging = new AccusedTrackingDetailPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TrackingID) as TotalRow from [dbo].[AccusedTrackingDetail]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			accusedTrackingDetailPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			accusedTrackingDetailPaging.totalPage = (int)Math.Ceiling((double) accusedTrackingDetailPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTrackingID(whereSql, "TrackingID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			accusedTrackingDetailPaging.accusedTrackingDetailRow = MapRecords(command);
			return accusedTrackingDetailPaging;
		}
		public virtual AccusedTrackingDetailPaging GetPagingRelyOnTrackingIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			AccusedTrackingDetailPaging accusedTrackingDetailPaging = new AccusedTrackingDetailPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TrackingID) as TotalRow from [dbo].[AccusedTrackingDetail]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			accusedTrackingDetailPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			accusedTrackingDetailPaging.totalPage = (int)Math.Ceiling((double)accusedTrackingDetailPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTrackingID(whereSql, "TrackingID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			accusedTrackingDetailPaging.accusedTrackingDetailRow = MapRecords(command);
			return accusedTrackingDetailPaging;
		}
		public virtual AccusedTrackingDetailRow[] GetPagingRelyOnTrackingIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTrackingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TrackingID < " + minTrackingID.ToString();
			}
			else
			{
				whereSql = "TrackingID < " + minTrackingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTrackingID(whereSql, "TrackingID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AccusedTrackingDetailRow[] GetPagingRelyOnTrackingIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTrackingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TrackingID > " + minTrackingID.ToString();
			}
			else
			{
				whereSql = "TrackingID > " + minTrackingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTrackingID(whereSql, "TrackingID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AccusedTrackingDetailRow[] GetPagingRelyOnTrackingIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTrackingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TrackingID < " + maxTrackingID.ToString();
			}
			else
			{
				whereSql = "TrackingID < " + maxTrackingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTrackingID(whereSql, "TrackingID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AccusedTrackingDetailRow[] GetPagingRelyOnTrackingIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTrackingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TrackingID > " + maxTrackingID.ToString();
			}
			else
			{
				whereSql = "TrackingID > " + maxTrackingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTrackingID(whereSql, "TrackingID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AccusedTrackingDetailRow[] GetPagingRelyOnTrackingIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TrackingID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			AccusedTrackingDetailRow[] accusedTrackingDetailRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTrackingID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				accusedTrackingDetailRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTrackingIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				accusedTrackingDetailRow = MapRecords(command);
			}
			return accusedTrackingDetailRow;
		}
		public virtual AccusedTrackingDetailRow[] GetPagingRelyOnTrackingIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TrackingID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			AccusedTrackingDetailRow[] accusedTrackingDetailRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTrackingID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				accusedTrackingDetailRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTrackingIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				accusedTrackingDetailRow = MapRecords(command);
			}
			return accusedTrackingDetailRow;
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
			"[TrackingID],"+
			"[AccusedTrackingID],"+
			"[TrackingCode],"+
			"[DueDate],"+
			"[ReportDate],"+
			"[ReportToOfficerName],"+
			"[ReportAtCode],"+
			"[LocationName],"+
			"[Note],"+
			"[UserID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[AccusedTrackingDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTrackingID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AccusedTrackingDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTrackingIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TrackingID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AccusedTrackingDetail] where TrackingID < (select min(minTrackingID) from(select top " + (rowPerPage * pageNumber).ToString() + " TrackingID as minTrackingID from [dbo].[AccusedTrackingDetail]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[AccusedTrackingDetail]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTrackingIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TrackingID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AccusedTrackingDetail] where TrackingID > (select max(maxTrackingID) from(select top " + (rowPerPage * pageNumber).ToString() + " TrackingID as maxTrackingID from [dbo].[AccusedTrackingDetail]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[AccusedTrackingDetail]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[AccusedTrackingDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "AccusedTrackingDetail"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TrackingID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AccusedTrackingID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TrackingCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("DueDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ReportDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ReportToOfficerName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ReportAtCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("LocationName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual AccusedTrackingDetailRow[] GetByAccusedTrackingID(int accusedTrackingID)
		{
			return MapRecords(CreateGetByAccusedTrackingIDCommand(accusedTrackingID));
		}
		public virtual DataTable GetByAccusedTrackingIDAsDataTable(int accusedTrackingID)
		{
			return MapRecordsToDataTable(CreateGetByAccusedTrackingIDCommand(accusedTrackingID));
		}
		protected virtual IDbCommand CreateGetByAccusedTrackingIDCommand(int accusedTrackingID)
		{
			string whereSql = "";
			whereSql += "[AccusedTrackingID]=" + CreateSqlParameterName("AccusedTrackingID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AccusedTrackingID", accusedTrackingID);
			return cmd;
		}
		public AccusedTrackingDetailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual AccusedTrackingDetailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="AccusedTrackingDetailRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="AccusedTrackingDetailRow"/> objects.</returns>
		public virtual AccusedTrackingDetailRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[AccusedTrackingDetail]", top);
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
		public AccusedTrackingDetailRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			AccusedTrackingDetailRow[] rows = null;
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
		public DataTable GetAccusedTrackingDetailPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TrackingID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TrackingID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TrackingID) AS TotalRow FROM [dbo].[AccusedTrackingDetail] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TrackingID,AccusedTrackingID,TrackingCode,DueDate,ReportDate,ReportToOfficerName,ReportAtCode,LocationName,Note,UserID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[AccusedTrackingDetail] " + whereSql +
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
		public AccusedTrackingDetailItemsPaging GetAccusedTrackingDetailPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TrackingID")
		{
		AccusedTrackingDetailItemsPaging obj = new AccusedTrackingDetailItemsPaging();
		DataTable dt = GetAccusedTrackingDetailPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		AccusedTrackingDetailItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new AccusedTrackingDetailItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TrackingID = Convert.ToInt32(dt.Rows[i]["TrackingID"]);
			record.AccusedTrackingID = Convert.ToInt32(dt.Rows[i]["AccusedTrackingID"]);
			record.TrackingCode = dt.Rows[i]["TrackingCode"].ToString();
			record.DueDate = Convert.ToDateTime(dt.Rows[i]["DueDate"]);
			if (dt.Rows[i]["ReportDate"] != DBNull.Value)
			record.ReportDate = Convert.ToDateTime(dt.Rows[i]["ReportDate"]);
			record.ReportToOfficerName = dt.Rows[i]["ReportToOfficerName"].ToString();
			record.ReportAtCode = dt.Rows[i]["ReportAtCode"].ToString();
			record.LocationName = dt.Rows[i]["LocationName"].ToString();
			record.Note = dt.Rows[i]["Note"].ToString();
			if (dt.Rows[i]["UserID"] != DBNull.Value)
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.accusedTrackingDetailItems = (AccusedTrackingDetailItems[])(recordList.ToArray(typeof(AccusedTrackingDetailItems)));
		return obj;
		}
		public AccusedTrackingDetailRow GetByPrimaryKey(int trackingID)
		{
			string whereSql = "[TrackingID]=" + CreateSqlParameterName("TrackingID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TrackingID", trackingID);
			AccusedTrackingDetailRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(AccusedTrackingDetailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[AccusedTrackingDetail] (" +
			"[AccusedTrackingID], " + 
			"[TrackingCode], " + 
			"[DueDate], " + 
			"[ReportDate], " + 
			"[ReportToOfficerName], " + 
			"[ReportAtCode], " + 
			"[LocationName], " + 
			"[Note], " + 
			"[UserID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("AccusedTrackingID") + ", " +
			CreateSqlParameterName("TrackingCode") + ", " +
			CreateSqlParameterName("DueDate") + ", " +
			CreateSqlParameterName("ReportDate") + ", " +
			CreateSqlParameterName("ReportToOfficerName") + ", " +
			CreateSqlParameterName("ReportAtCode") + ", " +
			CreateSqlParameterName("LocationName") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "AccusedTrackingID", value.AccusedTrackingID);
			AddParameter(cmd, "TrackingCode", value.TrackingCode);
			AddParameter(cmd, "DueDate", value.IsDueDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DueDate);
			AddParameter(cmd, "ReportDate", value.IsReportDateNull ? DBNull.Value : (object)value.ReportDate);
			AddParameter(cmd, "ReportToOfficerName", value.ReportToOfficerName);
			AddParameter(cmd, "ReportAtCode", value.ReportAtCode);
			AddParameter(cmd, "LocationName", value.LocationName);
			AddParameter(cmd, "Note", value.Note);
			AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(AccusedTrackingDetailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[AccusedTrackingDetail] (" +
			"[AccusedTrackingID], " + 
			"[TrackingCode], " + 
			"[DueDate], " + 
			"[ReportDate], " + 
			"[ReportToOfficerName], " + 
			"[ReportAtCode], " + 
			"[LocationName], " + 
			"[Note], " + 
			"[UserID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("AccusedTrackingID") + ", " +
			CreateSqlParameterName("TrackingCode") + ", " +
			CreateSqlParameterName("DueDate") + ", " +
			CreateSqlParameterName("ReportDate") + ", " +
			CreateSqlParameterName("ReportToOfficerName") + ", " +
			CreateSqlParameterName("ReportAtCode") + ", " +
			CreateSqlParameterName("LocationName") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "AccusedTrackingID", value.AccusedTrackingID);
			AddParameter(cmd, "TrackingCode", Sanitizer.GetSafeHtmlFragment(value.TrackingCode));
			AddParameter(cmd, "DueDate", value.IsDueDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DueDate);
			AddParameter(cmd, "ReportDate", value.IsReportDateNull ? DBNull.Value : (object)value.ReportDate);
			AddParameter(cmd, "ReportToOfficerName", Sanitizer.GetSafeHtmlFragment(value.ReportToOfficerName));
			AddParameter(cmd, "ReportAtCode", Sanitizer.GetSafeHtmlFragment(value.ReportAtCode));
			AddParameter(cmd, "LocationName", Sanitizer.GetSafeHtmlFragment(value.LocationName));
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(AccusedTrackingDetailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTrackingID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAccusedTrackingID)
				{
					strUpdate += "[AccusedTrackingID]=" + CreateSqlParameterName("AccusedTrackingID") + ",";
				}
				if (value._IsSetTrackingCode)
				{
					strUpdate += "[TrackingCode]=" + CreateSqlParameterName("TrackingCode") + ",";
				}
				if (value._IsSetDueDate)
				{
					strUpdate += "[DueDate]=" + CreateSqlParameterName("DueDate") + ",";
				}
				if (value._IsSetReportDate)
				{
					strUpdate += "[ReportDate]=" + CreateSqlParameterName("ReportDate") + ",";
				}
				if (value._IsSetReportToOfficerName)
				{
					strUpdate += "[ReportToOfficerName]=" + CreateSqlParameterName("ReportToOfficerName") + ",";
				}
				if (value._IsSetReportAtCode)
				{
					strUpdate += "[ReportAtCode]=" + CreateSqlParameterName("ReportAtCode") + ",";
				}
				if (value._IsSetLocationName)
				{
					strUpdate += "[LocationName]=" + CreateSqlParameterName("LocationName") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[AccusedTrackingDetail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TrackingID]=" + CreateSqlParameterName("TrackingID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TrackingID", value.TrackingID);
					AddParameter(cmd, "AccusedTrackingID", value.AccusedTrackingID);
					AddParameter(cmd, "TrackingCode", value.TrackingCode);
					AddParameter(cmd, "DueDate", value.IsDueDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DueDate);
					AddParameter(cmd, "ReportDate", value.IsReportDateNull ? DBNull.Value : (object)value.ReportDate);
					AddParameter(cmd, "ReportToOfficerName", value.ReportToOfficerName);
					AddParameter(cmd, "ReportAtCode", value.ReportAtCode);
					AddParameter(cmd, "LocationName", value.LocationName);
					AddParameter(cmd, "Note", value.Note);
					AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(TrackingID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(AccusedTrackingDetailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTrackingID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAccusedTrackingID)
				{
					strUpdate += "[AccusedTrackingID]=" + CreateSqlParameterName("AccusedTrackingID") + ",";
				}
				if (value._IsSetTrackingCode)
				{
					strUpdate += "[TrackingCode]=" + CreateSqlParameterName("TrackingCode") + ",";
				}
				if (value._IsSetDueDate)
				{
					strUpdate += "[DueDate]=" + CreateSqlParameterName("DueDate") + ",";
				}
				if (value._IsSetReportDate)
				{
					strUpdate += "[ReportDate]=" + CreateSqlParameterName("ReportDate") + ",";
				}
				if (value._IsSetReportToOfficerName)
				{
					strUpdate += "[ReportToOfficerName]=" + CreateSqlParameterName("ReportToOfficerName") + ",";
				}
				if (value._IsSetReportAtCode)
				{
					strUpdate += "[ReportAtCode]=" + CreateSqlParameterName("ReportAtCode") + ",";
				}
				if (value._IsSetLocationName)
				{
					strUpdate += "[LocationName]=" + CreateSqlParameterName("LocationName") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[AccusedTrackingDetail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TrackingID]=" + CreateSqlParameterName("TrackingID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TrackingID", value.TrackingID);
					AddParameter(cmd, "AccusedTrackingID", value.AccusedTrackingID);
					AddParameter(cmd, "TrackingCode", Sanitizer.GetSafeHtmlFragment(value.TrackingCode));
					AddParameter(cmd, "DueDate", value.IsDueDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DueDate);
					AddParameter(cmd, "ReportDate", value.IsReportDateNull ? DBNull.Value : (object)value.ReportDate);
					AddParameter(cmd, "ReportToOfficerName", Sanitizer.GetSafeHtmlFragment(value.ReportToOfficerName));
					AddParameter(cmd, "ReportAtCode", Sanitizer.GetSafeHtmlFragment(value.ReportAtCode));
					AddParameter(cmd, "LocationName", Sanitizer.GetSafeHtmlFragment(value.LocationName));
					AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
					AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(TrackingID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int trackingID)
		{
			string whereSql = "[TrackingID]=" + CreateSqlParameterName("TrackingID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TrackingID", trackingID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByAccusedTrackingID(int accusedTrackingID)
		{
			return CreateDeleteByAccusedTrackingIDCommand(accusedTrackingID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAccusedTrackingIDCommand(int accusedTrackingID)
		{
			string whereSql = "";
			whereSql += "[AccusedTrackingID]=" + CreateSqlParameterName("AccusedTrackingID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AccusedTrackingID", accusedTrackingID);
			return cmd;
		}
		protected AccusedTrackingDetailRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected AccusedTrackingDetailRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected AccusedTrackingDetailRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int trackingIDColumnIndex = reader.GetOrdinal("TrackingID");
			int accusedTrackingIDColumnIndex = reader.GetOrdinal("AccusedTrackingID");
			int trackingCodeColumnIndex = reader.GetOrdinal("TrackingCode");
			int duedateColumnIndex = reader.GetOrdinal("DueDate");
			int reportDateColumnIndex = reader.GetOrdinal("ReportDate");
			int reportToOfficerNameColumnIndex = reader.GetOrdinal("ReportToOfficerName");
			int reportAtCodeColumnIndex = reader.GetOrdinal("ReportAtCode");
			int locationNameColumnIndex = reader.GetOrdinal("LocationName");
			int noteColumnIndex = reader.GetOrdinal("Note");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
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
					AccusedTrackingDetailRow record = new AccusedTrackingDetailRow();
					recordList.Add(record);
					record.TrackingID =  Convert.ToInt32(reader.GetValue(trackingIDColumnIndex));
					record.AccusedTrackingID =  Convert.ToInt32(reader.GetValue(accusedTrackingIDColumnIndex));
					if (!reader.IsDBNull(trackingCodeColumnIndex)) record.TrackingCode =  Convert.ToString(reader.GetValue(trackingCodeColumnIndex));

					record.DueDate =  Convert.ToDateTime(reader.GetValue(duedateColumnIndex));
					if (!reader.IsDBNull(reportDateColumnIndex)) record.ReportDate =  Convert.ToDateTime(reader.GetValue(reportDateColumnIndex));

					if (!reader.IsDBNull(reportToOfficerNameColumnIndex)) record.ReportToOfficerName =  Convert.ToString(reader.GetValue(reportToOfficerNameColumnIndex));

					if (!reader.IsDBNull(reportAtCodeColumnIndex)) record.ReportAtCode =  Convert.ToString(reader.GetValue(reportAtCodeColumnIndex));

					if (!reader.IsDBNull(locationNameColumnIndex)) record.LocationName =  Convert.ToString(reader.GetValue(locationNameColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(userIDColumnIndex)) record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (AccusedTrackingDetailRow[])(recordList.ToArray(typeof(AccusedTrackingDetailRow)));
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
				case "TrackingID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AccusedTrackingID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TrackingCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DueDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ReportDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ReportToOfficerName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ReportAtCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LocationName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Note":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

