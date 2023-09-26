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
	public partial class ShortMessageLogCollection_Base : MarshalByRefObject
	{
		public const string MessageIDColumnName = "MessageID";
		public const string PhonenumberColumnName = "Phonenumber";
		public const string ShortMessageColumnName = "ShortMessage";
		public const string SenderNameColumnName = "SenderName";
		public const string SendStatusColumnName = "SendStatus";
		public const string UsedCreditColumnName = "UsedCredit";
		public const string RemainCreditColumnName = "RemainCredit";
		public const string DateCreatedColumnName = "DateCreated";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ShortMessageLogCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ShortMessageLogRow[] GetAll()
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
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[MessageID],"+
			"[Phonenumber],"+
			"[ShortMessage],"+
			"[SenderName],"+
			"[SendStatus],"+
			"[UsedCredit],"+
			"[RemainCredit],"+
			"[DateCreated],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ShortMessageLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ShortMessageLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ShortMessageLog"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("MessageID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Phonenumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ShortMessage",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("SenderName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("SendStatus",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("UsedCredit",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RemainCredit",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DateCreated",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public ShortMessageLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ShortMessageLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ShortMessageLogRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ShortMessageLogRow"/> objects.</returns>
		public virtual ShortMessageLogRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ShortMessageLog]", top);
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
		public ShortMessageLogRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ShortMessageLogRow[] rows = null;
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
		public DataTable GetShortMessageLogPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MessageID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[ShortMessageLog] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MessageID,Phonenumber,ShortMessage,SenderName,SendStatus,UsedCredit,RemainCredit,DateCreated,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [ShortMessageLog].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ShortMessageLog] " + whereSql +
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
		public ShortMessageLogItemsPaging GetShortMessageLogPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MessageID")
		{
		ShortMessageLogItemsPaging obj = new ShortMessageLogItemsPaging();
		DataTable dt = GetShortMessageLogPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ShortMessageLogItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ShortMessageLogItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.MessageID = dt.Rows[i]["MessageID"].ToString();
			record.Phonenumber = dt.Rows[i]["Phonenumber"].ToString();
			record.ShortMessage = dt.Rows[i]["ShortMessage"].ToString();
			record.SenderName = dt.Rows[i]["SenderName"].ToString();
			record.SendStatus = dt.Rows[i]["SendStatus"].ToString();
			if (dt.Rows[i]["UsedCredit"] != DBNull.Value)
			record.UsedCredit = Convert.ToInt32(dt.Rows[i]["UsedCredit"]);
			if (dt.Rows[i]["RemainCredit"] != DBNull.Value)
			record.RemainCredit = Convert.ToInt32(dt.Rows[i]["RemainCredit"]);
			record.DateCreated = Convert.ToDateTime(dt.Rows[i]["DateCreated"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.shortMessageLogItems = (ShortMessageLogItems[])(recordList.ToArray(typeof(ShortMessageLogItems)));
		return obj;
		}
		public ShortMessageLogRow GetByPrimaryKey(string messageID)
		{
			string whereSql = "[MessageID]=" + CreateSqlParameterName("MessageID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MessageID", messageID);
			ShortMessageLogRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ShortMessageLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ShortMessageLog] (" +
			"[MessageID], " + 
			"[Phonenumber], " + 
			"[ShortMessage], " + 
			"[SenderName], " + 
			"[SendStatus], " + 
			"[UsedCredit], " + 
			"[RemainCredit], " + 
			"[DateCreated], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("MessageID") + ", " +
			CreateSqlParameterName("Phonenumber") + ", " +
			CreateSqlParameterName("ShortMessage") + ", " +
			CreateSqlParameterName("SenderName") + ", " +
			CreateSqlParameterName("SendStatus") + ", " +
			CreateSqlParameterName("UsedCredit") + ", " +
			CreateSqlParameterName("RemainCredit") + ", " +
			CreateSqlParameterName("DateCreated") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MessageID",value.MessageID);
			AddParameter(cmd, "Phonenumber",value.Phonenumber);
			AddParameter(cmd, "ShortMessage", value.ShortMessage);
			AddParameter(cmd, "SenderName", value.SenderName);
			AddParameter(cmd, "SendStatus", value.SendStatus);
			AddParameter(cmd, "UsedCredit", value.IsUsedCreditNull ? DBNull.Value : (object)value.UsedCredit);
			AddParameter(cmd, "RemainCredit", value.IsRemainCreditNull ? DBNull.Value : (object)value.RemainCredit);
			AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ShortMessageLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ShortMessageLog] (" +
			"[MessageID], " + 
			"[Phonenumber], " + 
			"[ShortMessage], " + 
			"[SenderName], " + 
			"[SendStatus], " + 
			"[UsedCredit], " + 
			"[RemainCredit], " + 
			"[DateCreated], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("MessageID") + ", " +
			CreateSqlParameterName("Phonenumber") + ", " +
			CreateSqlParameterName("ShortMessage") + ", " +
			CreateSqlParameterName("SenderName") + ", " +
			CreateSqlParameterName("SendStatus") + ", " +
			CreateSqlParameterName("UsedCredit") + ", " +
			CreateSqlParameterName("RemainCredit") + ", " +
			CreateSqlParameterName("DateCreated") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MessageID", Sanitizer.GetSafeHtmlFragment(value.MessageID));
			AddParameter(cmd, "Phonenumber", Sanitizer.GetSafeHtmlFragment(value.Phonenumber));
			AddParameter(cmd, "ShortMessage", Sanitizer.GetSafeHtmlFragment(value.ShortMessage));
			AddParameter(cmd, "SenderName", Sanitizer.GetSafeHtmlFragment(value.SenderName));
			AddParameter(cmd, "SendStatus", Sanitizer.GetSafeHtmlFragment(value.SendStatus));
			AddParameter(cmd, "UsedCredit", value.IsUsedCreditNull ? DBNull.Value : (object)value.UsedCredit);
			AddParameter(cmd, "RemainCredit", value.IsRemainCreditNull ? DBNull.Value : (object)value.RemainCredit);
			AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ShortMessageLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMessageID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPhonenumber)
				{
					strUpdate += "[Phonenumber]=" + CreateSqlParameterName("Phonenumber") + ",";
				}
				if (value._IsSetShortMessage)
				{
					strUpdate += "[ShortMessage]=" + CreateSqlParameterName("ShortMessage") + ",";
				}
				if (value._IsSetSenderName)
				{
					strUpdate += "[SenderName]=" + CreateSqlParameterName("SenderName") + ",";
				}
				if (value._IsSetSendStatus)
				{
					strUpdate += "[SendStatus]=" + CreateSqlParameterName("SendStatus") + ",";
				}
				if (value._IsSetUsedCredit)
				{
					strUpdate += "[UsedCredit]=" + CreateSqlParameterName("UsedCredit") + ",";
				}
				if (value._IsSetRemainCredit)
				{
					strUpdate += "[RemainCredit]=" + CreateSqlParameterName("RemainCredit") + ",";
				}
				if (value._IsSetDateCreated)
				{
					strUpdate += "[DateCreated]=" + CreateSqlParameterName("DateCreated") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ShortMessageLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MessageID]=" + CreateSqlParameterName("MessageID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MessageID",value.MessageID);
					AddParameter(cmd, "Phonenumber",value.Phonenumber);
					AddParameter(cmd, "ShortMessage", value.ShortMessage);
					AddParameter(cmd, "SenderName", value.SenderName);
					AddParameter(cmd, "SendStatus", value.SendStatus);
					AddParameter(cmd, "UsedCredit", value.IsUsedCreditNull ? DBNull.Value : (object)value.UsedCredit);
					AddParameter(cmd, "RemainCredit", value.IsRemainCreditNull ? DBNull.Value : (object)value.RemainCredit);
					AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
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
				Exception ex = new Exception("Set incorrect primarykey PK(MessageID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ShortMessageLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMessageID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPhonenumber)
				{
					strUpdate += "[Phonenumber]=" + CreateSqlParameterName("Phonenumber") + ",";
				}
				if (value._IsSetShortMessage)
				{
					strUpdate += "[ShortMessage]=" + CreateSqlParameterName("ShortMessage") + ",";
				}
				if (value._IsSetSenderName)
				{
					strUpdate += "[SenderName]=" + CreateSqlParameterName("SenderName") + ",";
				}
				if (value._IsSetSendStatus)
				{
					strUpdate += "[SendStatus]=" + CreateSqlParameterName("SendStatus") + ",";
				}
				if (value._IsSetUsedCredit)
				{
					strUpdate += "[UsedCredit]=" + CreateSqlParameterName("UsedCredit") + ",";
				}
				if (value._IsSetRemainCredit)
				{
					strUpdate += "[RemainCredit]=" + CreateSqlParameterName("RemainCredit") + ",";
				}
				if (value._IsSetDateCreated)
				{
					strUpdate += "[DateCreated]=" + CreateSqlParameterName("DateCreated") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ShortMessageLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MessageID]=" + CreateSqlParameterName("MessageID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MessageID", Sanitizer.GetSafeHtmlFragment(value.MessageID));
					AddParameter(cmd, "Phonenumber", Sanitizer.GetSafeHtmlFragment(value.Phonenumber));
					AddParameter(cmd, "ShortMessage", Sanitizer.GetSafeHtmlFragment(value.ShortMessage));
					AddParameter(cmd, "SenderName", Sanitizer.GetSafeHtmlFragment(value.SenderName));
					AddParameter(cmd, "SendStatus", Sanitizer.GetSafeHtmlFragment(value.SendStatus));
					AddParameter(cmd, "UsedCredit", value.IsUsedCreditNull ? DBNull.Value : (object)value.UsedCredit);
					AddParameter(cmd, "RemainCredit", value.IsRemainCreditNull ? DBNull.Value : (object)value.RemainCredit);
					AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
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
				Exception ex = new Exception("Set incorrect primarykey PK(MessageID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(string messageID)
		{
			string whereSql = "[MessageID]=" + CreateSqlParameterName("MessageID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MessageID", messageID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected ShortMessageLogRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ShortMessageLogRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ShortMessageLogRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int messageIDColumnIndex = reader.GetOrdinal("MessageID");
			int phonenumberColumnIndex = reader.GetOrdinal("Phonenumber");
			int shortMessageColumnIndex = reader.GetOrdinal("ShortMessage");
			int senderNameColumnIndex = reader.GetOrdinal("SenderName");
			int sendstatusColumnIndex = reader.GetOrdinal("SendStatus");
			int usedCreditColumnIndex = reader.GetOrdinal("UsedCredit");
			int remainCreditColumnIndex = reader.GetOrdinal("RemainCredit");
			int dateCreatedColumnIndex = reader.GetOrdinal("DateCreated");
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
					ShortMessageLogRow record = new ShortMessageLogRow();
					recordList.Add(record);
					record.MessageID =  Convert.ToString(reader.GetValue(messageIDColumnIndex));
					record.Phonenumber =  Convert.ToString(reader.GetValue(phonenumberColumnIndex));
					if (!reader.IsDBNull(shortMessageColumnIndex)) record.ShortMessage =  Convert.ToString(reader.GetValue(shortMessageColumnIndex));

					if (!reader.IsDBNull(senderNameColumnIndex)) record.SenderName =  Convert.ToString(reader.GetValue(senderNameColumnIndex));

					if (!reader.IsDBNull(sendstatusColumnIndex)) record.SendStatus =  Convert.ToString(reader.GetValue(sendstatusColumnIndex));

					if (!reader.IsDBNull(usedCreditColumnIndex)) record.UsedCredit =  Convert.ToInt32(reader.GetValue(usedCreditColumnIndex));

					if (!reader.IsDBNull(remainCreditColumnIndex)) record.RemainCredit =  Convert.ToInt32(reader.GetValue(remainCreditColumnIndex));

					record.DateCreated =  Convert.ToDateTime(reader.GetValue(dateCreatedColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ShortMessageLogRow[])(recordList.ToArray(typeof(ShortMessageLogRow)));
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
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Phonenumber":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ShortMessage":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SenderName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SendStatus":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "UsedCredit":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RemainCredit":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DateCreated":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
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

