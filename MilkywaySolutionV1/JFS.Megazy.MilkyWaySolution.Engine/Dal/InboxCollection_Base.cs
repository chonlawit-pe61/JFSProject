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
	public partial class InboxCollection_Base : MarshalByRefObject
	{
		public const string InboxIDColumnName = "InboxID";
		public const string MessageTypeColumnName = "MessageType";
		public const string SubjectColumnName = "Subject";
		public const string CreateDateColumnName = "CreateDate";
		public const string PublishDateColumnName = "PublishDate";
		public const string ExternalLinkColumnName = "ExternalLink";
		public const string IsActiveColumnName = "IsActive";
		private int _processID;
		public SqlCommand cmd = null;
		public InboxCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual InboxRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual InboxPaging GetPagingRelyOnInboxIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			InboxPaging inboxPaging = new InboxPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(InboxID) as TotalRow from [dbo].[Inbox]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			inboxPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			inboxPaging.totalPage = (int)Math.Ceiling((double) inboxPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnInboxID(whereSql, "InboxID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			inboxPaging.inboxRow = MapRecords(command);
			return inboxPaging;
		}
		public virtual InboxPaging GetPagingRelyOnInboxIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			InboxPaging inboxPaging = new InboxPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(InboxID) as TotalRow from [dbo].[Inbox]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			inboxPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			inboxPaging.totalPage = (int)Math.Ceiling((double)inboxPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnInboxID(whereSql, "InboxID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			inboxPaging.inboxRow = MapRecords(command);
			return inboxPaging;
		}
		public virtual InboxRow[] GetPagingRelyOnInboxIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minInboxID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And InboxID < " + minInboxID.ToString();
			}
			else
			{
				whereSql = "InboxID < " + minInboxID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnInboxID(whereSql, "InboxID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual InboxRow[] GetPagingRelyOnInboxIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minInboxID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And InboxID > " + minInboxID.ToString();
			}
			else
			{
				whereSql = "InboxID > " + minInboxID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnInboxID(whereSql, "InboxID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual InboxRow[] GetPagingRelyOnInboxIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxInboxID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And InboxID < " + maxInboxID.ToString();
			}
			else
			{
				whereSql = "InboxID < " + maxInboxID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnInboxID(whereSql, "InboxID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual InboxRow[] GetPagingRelyOnInboxIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxInboxID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And InboxID > " + maxInboxID.ToString();
			}
			else
			{
				whereSql = "InboxID > " + maxInboxID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnInboxID(whereSql, "InboxID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual InboxRow[] GetPagingRelyOnInboxIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "InboxID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			InboxRow[] inboxRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnInboxID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				inboxRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnInboxIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				inboxRow = MapRecords(command);
			}
			return inboxRow;
		}
		public virtual InboxRow[] GetPagingRelyOnInboxIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "InboxID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			InboxRow[] inboxRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnInboxID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				inboxRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnInboxIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				inboxRow = MapRecords(command);
			}
			return inboxRow;
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
			"[InboxID],"+
			"[MessageType],"+
			"[Subject],"+
			"[CreateDate],"+
			"[PublishDate],"+
			"[ExternalLink],"+
			"[IsActive]"+
			" FROM [dbo].[Inbox]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnInboxID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Inbox]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnInboxIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "InboxID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Inbox] where InboxID < (select min(minInboxID) from(select top " + (rowPerPage * pageNumber).ToString() + " InboxID as minInboxID from [dbo].[Inbox]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Inbox]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnInboxIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "InboxID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Inbox] where InboxID > (select max(maxInboxID) from(select top " + (rowPerPage * pageNumber).ToString() + " InboxID as maxInboxID from [dbo].[Inbox]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Inbox]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Inbox]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Inbox"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("InboxID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MessageType",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PublishDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ExternalLink",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public InboxRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual InboxRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="InboxRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="InboxRow"/> objects.</returns>
		public virtual InboxRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Inbox]", top);
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
		public InboxRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			InboxRow[] rows = null;
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
		public DataTable GetInboxPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InboxID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "InboxID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(InboxID) AS TotalRow FROM [dbo].[Inbox] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,InboxID,MessageType,Subject,CreateDate,PublishDate,ExternalLink,IsActive," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Inbox] " + whereSql +
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
		public InboxItemsPaging GetInboxPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InboxID")
		{
		InboxItemsPaging obj = new InboxItemsPaging();
		DataTable dt = GetInboxPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		InboxItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new InboxItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.InboxID = Convert.ToInt32(dt.Rows[i]["InboxID"]);
			record.MessageType = dt.Rows[i]["MessageType"].ToString();
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["PublishDate"] != DBNull.Value)
			record.PublishDate = Convert.ToDateTime(dt.Rows[i]["PublishDate"]);
			record.ExternalLink = dt.Rows[i]["ExternalLink"].ToString();
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			recordList.Add(record);
		}
		obj.inboxItems = (InboxItems[])(recordList.ToArray(typeof(InboxItems)));
		return obj;
		}
		public InboxRow GetByPrimaryKey(int inboxiD)
		{
			string whereSql = "[InboxID]=" + CreateSqlParameterName("InboxID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InboxID", inboxiD);
			InboxRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(InboxRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Inbox] (" +
			"[MessageType], " + 
			"[Subject], " + 
			"[CreateDate], " + 
			"[PublishDate], " + 
			"[ExternalLink], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("MessageType") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("PublishDate") + ", " +
			CreateSqlParameterName("ExternalLink") + ", " +
			CreateSqlParameterName("IsActive") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MessageType",value.MessageType);
			AddParameter(cmd, "Subject",value.Subject);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
			AddParameter(cmd, "PublishDate", value.IsPublishDateNull ? DBNull.Value : (object)value.PublishDate);
			AddParameter(cmd, "ExternalLink", value.ExternalLink);
			AddParameter(cmd, "IsActive", value.IsActive);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(InboxRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Inbox] (" +
			"[MessageType], " + 
			"[Subject], " + 
			"[CreateDate], " + 
			"[PublishDate], " + 
			"[ExternalLink], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("MessageType") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("PublishDate") + ", " +
			CreateSqlParameterName("ExternalLink") + ", " +
			CreateSqlParameterName("IsActive") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MessageType", Sanitizer.GetSafeHtmlFragment(value.MessageType));
			AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
			AddParameter(cmd, "PublishDate", value.IsPublishDateNull ? DBNull.Value : (object)value.PublishDate);
			AddParameter(cmd, "ExternalLink", Sanitizer.GetSafeHtmlFragment(value.ExternalLink));
			AddParameter(cmd, "IsActive", value.IsActive);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(InboxRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetInboxID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMessageType)
				{
					strUpdate += "[MessageType]=" + CreateSqlParameterName("MessageType") + ",";
				}
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetPublishDate)
				{
					strUpdate += "[PublishDate]=" + CreateSqlParameterName("PublishDate") + ",";
				}
				if (value._IsSetExternalLink)
				{
					strUpdate += "[ExternalLink]=" + CreateSqlParameterName("ExternalLink") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Inbox] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[InboxID]=" + CreateSqlParameterName("InboxID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "InboxID", value.InboxID);
					AddParameter(cmd, "MessageType",value.MessageType);
					AddParameter(cmd, "Subject",value.Subject);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
					AddParameter(cmd, "PublishDate", value.IsPublishDateNull ? DBNull.Value : (object)value.PublishDate);
					AddParameter(cmd, "ExternalLink", value.ExternalLink);
					AddParameter(cmd, "IsActive", value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(InboxID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(InboxRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetInboxID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMessageType)
				{
					strUpdate += "[MessageType]=" + CreateSqlParameterName("MessageType") + ",";
				}
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetPublishDate)
				{
					strUpdate += "[PublishDate]=" + CreateSqlParameterName("PublishDate") + ",";
				}
				if (value._IsSetExternalLink)
				{
					strUpdate += "[ExternalLink]=" + CreateSqlParameterName("ExternalLink") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Inbox] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[InboxID]=" + CreateSqlParameterName("InboxID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "InboxID", value.InboxID);
					AddParameter(cmd, "MessageType", Sanitizer.GetSafeHtmlFragment(value.MessageType));
					AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
					AddParameter(cmd, "PublishDate", value.IsPublishDateNull ? DBNull.Value : (object)value.PublishDate);
					AddParameter(cmd, "ExternalLink", Sanitizer.GetSafeHtmlFragment(value.ExternalLink));
					AddParameter(cmd, "IsActive", value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(InboxID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int inboxiD)
		{
			string whereSql = "[InboxID]=" + CreateSqlParameterName("InboxID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "InboxID", inboxiD);
			return 0 < cmd.ExecuteNonQuery();
		}
		public InboxRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			InboxRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected InboxRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected InboxRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected InboxRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int inboxiDColumnIndex = reader.GetOrdinal("InboxID");
			int messageTypeColumnIndex = reader.GetOrdinal("MessageType");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int publishDateColumnIndex = reader.GetOrdinal("PublishDate");
			int externalLinkColumnIndex = reader.GetOrdinal("ExternalLink");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					InboxRow record = new InboxRow();
					recordList.Add(record);
					record.InboxID =  Convert.ToInt32(reader.GetValue(inboxiDColumnIndex));
					record.MessageType =  Convert.ToString(reader.GetValue(messageTypeColumnIndex));
					record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));
					record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));
					if (!reader.IsDBNull(publishDateColumnIndex)) record.PublishDate =  Convert.ToDateTime(reader.GetValue(publishDateColumnIndex));

					if (!reader.IsDBNull(externalLinkColumnIndex)) record.ExternalLink =  Convert.ToString(reader.GetValue(externalLinkColumnIndex));

					record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (InboxRow[])(recordList.ToArray(typeof(InboxRow)));
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
				case "InboxID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MessageType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "PublishDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ExternalLink":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsActive":
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

