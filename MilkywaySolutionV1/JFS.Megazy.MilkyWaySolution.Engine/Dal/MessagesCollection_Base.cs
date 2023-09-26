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
	public partial class MessagesCollection_Base : MarshalByRefObject
	{
		public const string MessageIDColumnName = "MessageID";
		public const string SubjectColumnName = "Subject";
		public const string BodyColumnName = "Body";
		public const string CreateDateColumnName = "CreateDate";
		public const string AuthorIDColumnName = "AuthorID";
		private int _processID;
		public SqlCommand cmd = null;
		public MessagesCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual MessagesRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual MessagesPaging GetPagingRelyOnMessageIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			MessagesPaging messagesPaging = new MessagesPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(MessageID) as TotalRow from [dbo].[Messages]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			messagesPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			messagesPaging.totalPage = (int)Math.Ceiling((double) messagesPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnMessageID(whereSql, "MessageID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			messagesPaging.messagesRow = MapRecords(command);
			return messagesPaging;
		}
		public virtual MessagesPaging GetPagingRelyOnMessageIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			MessagesPaging messagesPaging = new MessagesPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(MessageID) as TotalRow from [dbo].[Messages]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			messagesPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			messagesPaging.totalPage = (int)Math.Ceiling((double)messagesPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnMessageID(whereSql, "MessageID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			messagesPaging.messagesRow = MapRecords(command);
			return messagesPaging;
		}
		public virtual MessagesRow[] GetPagingRelyOnMessageIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minMessageID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MessageID < " + minMessageID.ToString();
			}
			else
			{
				whereSql = "MessageID < " + minMessageID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMessageID(whereSql, "MessageID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual MessagesRow[] GetPagingRelyOnMessageIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minMessageID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MessageID > " + minMessageID.ToString();
			}
			else
			{
				whereSql = "MessageID > " + minMessageID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMessageID(whereSql, "MessageID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual MessagesRow[] GetPagingRelyOnMessageIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxMessageID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MessageID < " + maxMessageID.ToString();
			}
			else
			{
				whereSql = "MessageID < " + maxMessageID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMessageID(whereSql, "MessageID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual MessagesRow[] GetPagingRelyOnMessageIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxMessageID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MessageID > " + maxMessageID.ToString();
			}
			else
			{
				whereSql = "MessageID > " + maxMessageID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMessageID(whereSql, "MessageID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual MessagesRow[] GetPagingRelyOnMessageIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "MessageID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			MessagesRow[] messagesRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnMessageID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				messagesRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnMessageIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				messagesRow = MapRecords(command);
			}
			return messagesRow;
		}
		public virtual MessagesRow[] GetPagingRelyOnMessageIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "MessageID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			MessagesRow[] messagesRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnMessageID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				messagesRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnMessageIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				messagesRow = MapRecords(command);
			}
			return messagesRow;
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
			"[MessageID],"+
			"[Subject],"+
			"[Body],"+
			"[CreateDate],"+
			"[AuthorID]"+
			" FROM [dbo].[Messages]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMessageID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Messages]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMessageIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "MessageID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Messages] where MessageID < (select min(minMessageID) from(select top " + (rowPerPage * pageNumber).ToString() + " MessageID as minMessageID from [dbo].[Messages]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Messages]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMessageIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "MessageID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Messages] where MessageID > (select max(maxMessageID) from(select top " + (rowPerPage * pageNumber).ToString() + " MessageID as maxMessageID from [dbo].[Messages]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Messages]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Messages]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Messages"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("MessageID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Body",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("AuthorID",Type.GetType("System.Int32"));
			return dataTable;
		}
		public MessagesRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual MessagesRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="MessagesRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MessagesRow"/> objects.</returns>
		public virtual MessagesRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Messages]", top);
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
		public MessagesRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			MessagesRow[] rows = null;
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
		public DataTable GetMessagesPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MessageID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "MessageID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(MessageID) AS TotalRow FROM [dbo].[Messages] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MessageID,Subject,Body,CreateDate,AuthorID," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Messages] " + whereSql +
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
		public MessagesItemsPaging GetMessagesPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MessageID")
		{
		MessagesItemsPaging obj = new MessagesItemsPaging();
		DataTable dt = GetMessagesPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		MessagesItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new MessagesItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.MessageID = Convert.ToInt32(dt.Rows[i]["MessageID"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.Body = dt.Rows[i]["Body"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["AuthorID"] != DBNull.Value)
			record.AuthorID = Convert.ToInt32(dt.Rows[i]["AuthorID"]);
			recordList.Add(record);
		}
		obj.messagesItems = (MessagesItems[])(recordList.ToArray(typeof(MessagesItems)));
		return obj;
		}
		public MessagesRow GetByPrimaryKey(int messageID)
		{
			string whereSql = "[MessageID]=" + CreateSqlParameterName("MessageID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MessageID", messageID);
			MessagesRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(MessagesRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Messages] (" +
			"[Subject], " + 
			"[Body], " + 
			"[CreateDate], " + 
			"[AuthorID]			" + 
			") VALUES (" +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("Body") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("AuthorID") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Subject", value.Subject);
			AddParameter(cmd, "Body", value.Body);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "AuthorID", value.IsAuthorIDNull ? DBNull.Value : (object)value.AuthorID);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(MessagesRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Messages] (" +
			"[Subject], " + 
			"[Body], " + 
			"[CreateDate], " + 
			"[AuthorID]			" + 
			") VALUES (" +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("Body") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("AuthorID") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
			AddParameter(cmd, "Body", Sanitizer.GetSafeHtmlFragment(value.Body));
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "AuthorID", value.IsAuthorIDNull ? DBNull.Value : (object)value.AuthorID);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(MessagesRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMessageID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetBody)
				{
					strUpdate += "[Body]=" + CreateSqlParameterName("Body") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetAuthorID)
				{
					strUpdate += "[AuthorID]=" + CreateSqlParameterName("AuthorID") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Messages] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MessageID]=" + CreateSqlParameterName("MessageID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MessageID", value.MessageID);
					AddParameter(cmd, "Subject", value.Subject);
					AddParameter(cmd, "Body", value.Body);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
					AddParameter(cmd, "AuthorID", value.IsAuthorIDNull ? DBNull.Value : (object)value.AuthorID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MessageID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(MessagesRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMessageID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetBody)
				{
					strUpdate += "[Body]=" + CreateSqlParameterName("Body") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetAuthorID)
				{
					strUpdate += "[AuthorID]=" + CreateSqlParameterName("AuthorID") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Messages] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MessageID]=" + CreateSqlParameterName("MessageID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MessageID", value.MessageID);
					AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
					AddParameter(cmd, "Body", Sanitizer.GetSafeHtmlFragment(value.Body));
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
					AddParameter(cmd, "AuthorID", value.IsAuthorIDNull ? DBNull.Value : (object)value.AuthorID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MessageID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int messageID)
		{
			string whereSql = "[MessageID]=" + CreateSqlParameterName("MessageID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MessageID", messageID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected MessagesRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected MessagesRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected MessagesRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int messageIDColumnIndex = reader.GetOrdinal("MessageID");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int bodyColumnIndex = reader.GetOrdinal("Body");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int authorIDColumnIndex = reader.GetOrdinal("AuthorID");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					MessagesRow record = new MessagesRow();
					recordList.Add(record);
					record.MessageID =  Convert.ToInt32(reader.GetValue(messageIDColumnIndex));
					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					if (!reader.IsDBNull(bodyColumnIndex)) record.Body =  Convert.ToString(reader.GetValue(bodyColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(authorIDColumnIndex)) record.AuthorID =  Convert.ToInt32(reader.GetValue(authorIDColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MessagesRow[])(recordList.ToArray(typeof(MessagesRow)));
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
				case "MessageID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Body":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "AuthorID":
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

