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
	public partial class LawyerQueueCollection_Base : MarshalByRefObject
	{
		public const string QueueIDColumnName = "QueueID";
		public const string QueueVersionIDColumnName = "QueueVersionID";
		public const string LawyerIDColumnName = "LawyerID";
		public const string QueueRunningCodeColumnName = "QueueRunningCode";
		public const string QueueNoteColumnName = "QueueNote";
		public const string PriorityColumnName = "Priority";
		public const string QueueStatusIDColumnName = "QueueStatusID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public LawyerQueueCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual LawyerQueueRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual LawyerQueuePaging GetPagingRelyOnQueueIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			LawyerQueuePaging lawyerQueuePaging = new LawyerQueuePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(QueueID) as TotalRow from [dbo].[LawyerQueue]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			lawyerQueuePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			lawyerQueuePaging.totalPage = (int)Math.Ceiling((double) lawyerQueuePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnQueueID(whereSql, "QueueID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			lawyerQueuePaging.lawyerQueueRow = MapRecords(command);
			return lawyerQueuePaging;
		}
		public virtual LawyerQueuePaging GetPagingRelyOnQueueIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			LawyerQueuePaging lawyerQueuePaging = new LawyerQueuePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(QueueID) as TotalRow from [dbo].[LawyerQueue]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			lawyerQueuePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			lawyerQueuePaging.totalPage = (int)Math.Ceiling((double)lawyerQueuePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnQueueID(whereSql, "QueueID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			lawyerQueuePaging.lawyerQueueRow = MapRecords(command);
			return lawyerQueuePaging;
		}
		public virtual LawyerQueueRow[] GetPagingRelyOnQueueIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minQueueID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And QueueID < " + minQueueID.ToString();
			}
			else
			{
				whereSql = "QueueID < " + minQueueID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnQueueID(whereSql, "QueueID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual LawyerQueueRow[] GetPagingRelyOnQueueIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minQueueID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And QueueID > " + minQueueID.ToString();
			}
			else
			{
				whereSql = "QueueID > " + minQueueID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnQueueID(whereSql, "QueueID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual LawyerQueueRow[] GetPagingRelyOnQueueIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxQueueID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And QueueID < " + maxQueueID.ToString();
			}
			else
			{
				whereSql = "QueueID < " + maxQueueID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnQueueID(whereSql, "QueueID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual LawyerQueueRow[] GetPagingRelyOnQueueIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxQueueID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And QueueID > " + maxQueueID.ToString();
			}
			else
			{
				whereSql = "QueueID > " + maxQueueID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnQueueID(whereSql, "QueueID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual LawyerQueueRow[] GetPagingRelyOnQueueIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "QueueID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			LawyerQueueRow[] lawyerQueueRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnQueueID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				lawyerQueueRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnQueueIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				lawyerQueueRow = MapRecords(command);
			}
			return lawyerQueueRow;
		}
		public virtual LawyerQueueRow[] GetPagingRelyOnQueueIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "QueueID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			LawyerQueueRow[] lawyerQueueRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnQueueID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				lawyerQueueRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnQueueIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				lawyerQueueRow = MapRecords(command);
			}
			return lawyerQueueRow;
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
			"[QueueID],"+
			"[QueueVersionID],"+
			"[LawyerID],"+
			"[QueueRunningCode],"+
			"[QueueNote],"+
			"[Priority],"+
			"[QueueStatusID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[LawyerQueue]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnQueueID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[LawyerQueue]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnQueueIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "QueueID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[LawyerQueue] where QueueID < (select min(minQueueID) from(select top " + (rowPerPage * pageNumber).ToString() + " QueueID as minQueueID from [dbo].[LawyerQueue]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[LawyerQueue]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnQueueIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "QueueID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[LawyerQueue] where QueueID > (select max(maxQueueID) from(select top " + (rowPerPage * pageNumber).ToString() + " QueueID as maxQueueID from [dbo].[LawyerQueue]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[LawyerQueue]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[LawyerQueue]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "LawyerQueue"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("QueueID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("QueueVersionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LawyerID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("QueueRunningCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("QueueNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("Priority",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("QueueStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual LawyerQueueRow[] GetByQueueID(int queueID)
		{
			return MapRecords(CreateGetByQueueIDCommand(queueID));
		}
		public virtual DataTable GetByQueueIDAsDataTable(int queueID)
		{
			return MapRecordsToDataTable(CreateGetByQueueIDCommand(queueID));
		}
		protected virtual IDbCommand CreateGetByQueueIDCommand(int queueID)
		{
			string whereSql = "";
			whereSql += "[QueueID]=" + CreateSqlParameterName("QueueID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "QueueID", queueID);
			return cmd;
		}
		public virtual LawyerQueueRow[] GetByQueueVersionID(int queueVersionID)
		{
			return MapRecords(CreateGetByQueueVersionIDCommand(queueVersionID));
		}
		public virtual DataTable GetByQueueVersionIDAsDataTable(int queueVersionID)
		{
			return MapRecordsToDataTable(CreateGetByQueueVersionIDCommand(queueVersionID));
		}
		protected virtual IDbCommand CreateGetByQueueVersionIDCommand(int queueVersionID)
		{
			string whereSql = "";
			whereSql += "[QueueVersionID]=" + CreateSqlParameterName("QueueVersionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "QueueVersionID", queueVersionID);
			return cmd;
		}
		public virtual LawyerQueueRow[] GetByLawyerID(int lawyerID)
		{
			return MapRecords(CreateGetByLawyerIDCommand(lawyerID));
		}
		public virtual DataTable GetByLawyerIDAsDataTable(int lawyerID)
		{
			return MapRecordsToDataTable(CreateGetByLawyerIDCommand(lawyerID));
		}
		protected virtual IDbCommand CreateGetByLawyerIDCommand(int lawyerID)
		{
			string whereSql = "";
			whereSql += "[LawyerID]=" + CreateSqlParameterName("LawyerID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LawyerID", lawyerID);
			return cmd;
		}
		public virtual LawyerQueueRow[] GetByQueueStatusID(int queueStatusID)
		{
			return MapRecords(CreateGetByQueueStatusIDCommand(queueStatusID));
		}
		public virtual DataTable GetByQueueStatusIDAsDataTable(int queueStatusID)
		{
			return MapRecordsToDataTable(CreateGetByQueueStatusIDCommand(queueStatusID));
		}
		protected virtual IDbCommand CreateGetByQueueStatusIDCommand(int queueStatusID)
		{
			string whereSql = "";
			whereSql += "[QueueStatusID]=" + CreateSqlParameterName("QueueStatusID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "QueueStatusID", queueStatusID);
			return cmd;
		}
		public LawyerQueueRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual LawyerQueueRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="LawyerQueueRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LawyerQueueRow"/> objects.</returns>
		public virtual LawyerQueueRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[LawyerQueue]", top);
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
		public LawyerQueueRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			LawyerQueueRow[] rows = null;
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
		public DataTable GetLawyerQueuePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "QueueID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "QueueID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(QueueID) AS TotalRow FROM [dbo].[LawyerQueue] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,QueueID,QueueVersionID,LawyerID,QueueRunningCode,QueueNote,Priority,QueueStatusID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [LawyerQueue].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[LawyerQueue] " + whereSql +
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
		public LawyerQueueItemsPaging GetLawyerQueuePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "QueueID")
		{
		LawyerQueueItemsPaging obj = new LawyerQueueItemsPaging();
		DataTable dt = GetLawyerQueuePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		LawyerQueueItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new LawyerQueueItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.QueueID = Convert.ToInt32(dt.Rows[i]["QueueID"]);
			record.QueueVersionID = Convert.ToInt32(dt.Rows[i]["QueueVersionID"]);
			record.LawyerID = Convert.ToInt32(dt.Rows[i]["LawyerID"]);
			record.QueueRunningCode = dt.Rows[i]["QueueRunningCode"].ToString();
			record.QueueNote = dt.Rows[i]["QueueNote"].ToString();
			record.Priority = Convert.ToInt32(dt.Rows[i]["Priority"]);
			record.QueueStatusID = Convert.ToInt32(dt.Rows[i]["QueueStatusID"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.lawyerQueueItems = (LawyerQueueItems[])(recordList.ToArray(typeof(LawyerQueueItems)));
		return obj;
		}
		public LawyerQueueRow GetByPrimaryKey(int queueID)
		{
			string whereSql = "[QueueID]=" + CreateSqlParameterName("QueueID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "QueueID", queueID);
			LawyerQueueRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(LawyerQueueRow value)		{
			string sqlStr = "INSERT INTO [dbo].[LawyerQueue] (" +
			"[QueueVersionID], " + 
			"[LawyerID], " + 
			"[QueueRunningCode], " + 
			"[QueueNote], " + 
			"[Priority], " + 
			"[QueueStatusID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("QueueVersionID") + ", " +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("QueueRunningCode") + ", " +
			CreateSqlParameterName("QueueNote") + ", " +
			CreateSqlParameterName("Priority") + ", " +
			CreateSqlParameterName("QueueStatusID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "QueueVersionID", value.QueueVersionID);
			AddParameter(cmd, "LawyerID", value.LawyerID);
			AddParameter(cmd, "QueueRunningCode", value.QueueRunningCode);
			AddParameter(cmd, "QueueNote", value.QueueNote);
			AddParameter(cmd, "Priority", value.Priority);
			AddParameter(cmd, "QueueStatusID", value.QueueStatusID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(LawyerQueueRow value)		{
			string sqlStr = "INSERT INTO [dbo].[LawyerQueue] (" +
			"[QueueVersionID], " + 
			"[LawyerID], " + 
			"[QueueRunningCode], " + 
			"[QueueNote], " + 
			"[Priority], " + 
			"[QueueStatusID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("QueueVersionID") + ", " +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("QueueRunningCode") + ", " +
			CreateSqlParameterName("QueueNote") + ", " +
			CreateSqlParameterName("Priority") + ", " +
			CreateSqlParameterName("QueueStatusID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "QueueVersionID", value.QueueVersionID);
			AddParameter(cmd, "LawyerID", value.LawyerID);
			AddParameter(cmd, "QueueRunningCode", Sanitizer.GetSafeHtmlFragment(value.QueueRunningCode));
			AddParameter(cmd, "QueueNote", Sanitizer.GetSafeHtmlFragment(value.QueueNote));
			AddParameter(cmd, "Priority", value.Priority);
			AddParameter(cmd, "QueueStatusID", value.QueueStatusID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(LawyerQueueRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetQueueID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetQueueVersionID)
				{
					strUpdate += "[QueueVersionID]=" + CreateSqlParameterName("QueueVersionID") + ",";
				}
				if (value._IsSetLawyerID)
				{
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID") + ",";
				}
				if (value._IsSetQueueRunningCode)
				{
					strUpdate += "[QueueRunningCode]=" + CreateSqlParameterName("QueueRunningCode") + ",";
				}
				if (value._IsSetQueueNote)
				{
					strUpdate += "[QueueNote]=" + CreateSqlParameterName("QueueNote") + ",";
				}
				if (value._IsSetPriority)
				{
					strUpdate += "[Priority]=" + CreateSqlParameterName("Priority") + ",";
				}
				if (value._IsSetQueueStatusID)
				{
					strUpdate += "[QueueStatusID]=" + CreateSqlParameterName("QueueStatusID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[LawyerQueue] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[QueueID]=" + CreateSqlParameterName("QueueID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "QueueID", value.QueueID);
					AddParameter(cmd, "QueueVersionID", value.QueueVersionID);
					AddParameter(cmd, "LawyerID", value.LawyerID);
					AddParameter(cmd, "QueueRunningCode", value.QueueRunningCode);
					AddParameter(cmd, "QueueNote", value.QueueNote);
					AddParameter(cmd, "Priority", value.Priority);
					AddParameter(cmd, "QueueStatusID", value.QueueStatusID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(QueueID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(LawyerQueueRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetQueueID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetQueueVersionID)
				{
					strUpdate += "[QueueVersionID]=" + CreateSqlParameterName("QueueVersionID") + ",";
				}
				if (value._IsSetLawyerID)
				{
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID") + ",";
				}
				if (value._IsSetQueueRunningCode)
				{
					strUpdate += "[QueueRunningCode]=" + CreateSqlParameterName("QueueRunningCode") + ",";
				}
				if (value._IsSetQueueNote)
				{
					strUpdate += "[QueueNote]=" + CreateSqlParameterName("QueueNote") + ",";
				}
				if (value._IsSetPriority)
				{
					strUpdate += "[Priority]=" + CreateSqlParameterName("Priority") + ",";
				}
				if (value._IsSetQueueStatusID)
				{
					strUpdate += "[QueueStatusID]=" + CreateSqlParameterName("QueueStatusID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[LawyerQueue] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[QueueID]=" + CreateSqlParameterName("QueueID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "QueueID", value.QueueID);
					AddParameter(cmd, "QueueVersionID", value.QueueVersionID);
					AddParameter(cmd, "LawyerID", value.LawyerID);
					AddParameter(cmd, "QueueRunningCode", Sanitizer.GetSafeHtmlFragment(value.QueueRunningCode));
					AddParameter(cmd, "QueueNote", Sanitizer.GetSafeHtmlFragment(value.QueueNote));
					AddParameter(cmd, "Priority", value.Priority);
					AddParameter(cmd, "QueueStatusID", value.QueueStatusID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(QueueID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int queueID)
		{
			string whereSql = "[QueueID]=" + CreateSqlParameterName("QueueID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "QueueID", queueID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByQueueID(int queueID)
		{
			return CreateDeleteByQueueIDCommand(queueID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByQueueIDCommand(int queueID)
		{
			string whereSql = "";
			whereSql += "[QueueID]=" + CreateSqlParameterName("QueueID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "QueueID", queueID);
			return cmd;
		}
		public int DeleteByQueueVersionID(int queueVersionID)
		{
			return CreateDeleteByQueueVersionIDCommand(queueVersionID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByQueueVersionIDCommand(int queueVersionID)
		{
			string whereSql = "";
			whereSql += "[QueueVersionID]=" + CreateSqlParameterName("QueueVersionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "QueueVersionID", queueVersionID);
			return cmd;
		}
		public int DeleteByLawyerID(int lawyerID)
		{
			return CreateDeleteByLawyerIDCommand(lawyerID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByLawyerIDCommand(int lawyerID)
		{
			string whereSql = "";
			whereSql += "[LawyerID]=" + CreateSqlParameterName("LawyerID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LawyerID", lawyerID);
			return cmd;
		}
		public int DeleteByQueueStatusID(int queueStatusID)
		{
			return CreateDeleteByQueueStatusIDCommand(queueStatusID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByQueueStatusIDCommand(int queueStatusID)
		{
			string whereSql = "";
			whereSql += "[QueueStatusID]=" + CreateSqlParameterName("QueueStatusID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "QueueStatusID", queueStatusID);
			return cmd;
		}
		protected LawyerQueueRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected LawyerQueueRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected LawyerQueueRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int queueIDColumnIndex = reader.GetOrdinal("QueueID");
			int queueVersionIDColumnIndex = reader.GetOrdinal("QueueVersionID");
			int lawyerIDColumnIndex = reader.GetOrdinal("LawyerID");
			int queueRunningCodeColumnIndex = reader.GetOrdinal("QueueRunningCode");
			int queueNoteColumnIndex = reader.GetOrdinal("QueueNote");
			int priorityColumnIndex = reader.GetOrdinal("Priority");
			int queueStatusIDColumnIndex = reader.GetOrdinal("QueueStatusID");
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
					LawyerQueueRow record = new LawyerQueueRow();
					recordList.Add(record);
					record.QueueID =  Convert.ToInt32(reader.GetValue(queueIDColumnIndex));
					record.QueueVersionID =  Convert.ToInt32(reader.GetValue(queueVersionIDColumnIndex));
					record.LawyerID =  Convert.ToInt32(reader.GetValue(lawyerIDColumnIndex));
					if (!reader.IsDBNull(queueRunningCodeColumnIndex)) record.QueueRunningCode =  Convert.ToString(reader.GetValue(queueRunningCodeColumnIndex));

					if (!reader.IsDBNull(queueNoteColumnIndex)) record.QueueNote =  Convert.ToString(reader.GetValue(queueNoteColumnIndex));

					record.Priority =  Convert.ToInt32(reader.GetValue(priorityColumnIndex));
					record.QueueStatusID =  Convert.ToInt32(reader.GetValue(queueStatusIDColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LawyerQueueRow[])(recordList.ToArray(typeof(LawyerQueueRow)));
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
				case "QueueID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "QueueVersionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LawyerID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "QueueRunningCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "QueueNote":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Priority":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "QueueStatusID":
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

