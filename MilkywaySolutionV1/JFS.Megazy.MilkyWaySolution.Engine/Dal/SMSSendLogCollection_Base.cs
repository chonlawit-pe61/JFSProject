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
	public partial class SMSSendLogCollection_Base : MarshalByRefObject
	{
		public const string MessageIDColumnName = "MessageID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string CaseIDColumnName = "CaseID";
		public const string SendToColumnName = "SendTo";
		public const string TelephoneNumberColumnName = "TelephoneNumber";
		public const string IsOTPColumnName = "IsOTP";
		public const string MessageColumnName = "Message";
		public const string SendDateColumnName = "SendDate";
		public const string SendStatusColumnName = "SendStatus";
		public const string SendTypeColumnName = "SendType";
		public const string SendNoteColumnName = "SendNote";
		public const string SendStatusNameColumnName = "SendStatusName";
		public const string UsedCreditColumnName = "UsedCredit";
		public const string RemainCreditColumnName = "RemainCredit";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public SMSSendLogCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SMSSendLogRow[] GetAll()
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
			"[ApplicantID],"+
			"[CaseID],"+
			"[SendTo],"+
			"[TelephoneNumber],"+
			"[IsOTP],"+
			"[Message],"+
			"[SendDate],"+
			"[SendStatus],"+
			"[SendType],"+
			"[SendNote],"+
			"[SendStatusName],"+
			"[UsedCredit],"+
			"[RemainCredit],"+
			"[ModifiedDate]"+
			" FROM [dbo].[SMSSendLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[SMSSendLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "SMSSendLog"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("MessageID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SendTo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TelephoneNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("IsOTP",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Message",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("SendDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("SendStatus",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("SendType",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SendNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("SendStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("UsedCredit",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RemainCredit",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public SMSSendLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SMSSendLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SMSSendLogRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SMSSendLogRow"/> objects.</returns>
		public virtual SMSSendLogRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[SMSSendLog]", top);
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
		public SMSSendLogRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SMSSendLogRow[] rows = null;
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
		public DataTable GetSMSSendLogPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MessageID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[SMSSendLog] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MessageID,ApplicantID,CaseID,SendTo,TelephoneNumber,IsOTP,Message,SendDate,SendStatus,SendType,SendNote,SendStatusName,UsedCredit,RemainCredit,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [SMSSendLog].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[SMSSendLog] " + whereSql +
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
		public SMSSendLogItemsPaging GetSMSSendLogPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MessageID")
		{
		SMSSendLogItemsPaging obj = new SMSSendLogItemsPaging();
		DataTable dt = GetSMSSendLogPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SMSSendLogItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SMSSendLogItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.MessageID = dt.Rows[i]["MessageID"].ToString();
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.SendTo = dt.Rows[i]["SendTo"].ToString();
			record.TelephoneNumber = dt.Rows[i]["TelephoneNumber"].ToString();
			if (dt.Rows[i]["IsOTP"] != DBNull.Value)
			record.IsOTP = Convert.ToBoolean(dt.Rows[i]["IsOTP"]);
			record.Message = dt.Rows[i]["Message"].ToString();
			if (dt.Rows[i]["SendDate"] != DBNull.Value)
			record.SendDate = Convert.ToDateTime(dt.Rows[i]["SendDate"]);
			if (dt.Rows[i]["SendStatus"] != DBNull.Value)
			record.SendStatus = Convert.ToBoolean(dt.Rows[i]["SendStatus"]);
			record.SendType = dt.Rows[i]["SendType"].ToString();
			record.SendNote = dt.Rows[i]["SendNote"].ToString();
			record.SendStatusName = dt.Rows[i]["SendStatusName"].ToString();
			if (dt.Rows[i]["UsedCredit"] != DBNull.Value)
			record.UsedCredit = Convert.ToInt32(dt.Rows[i]["UsedCredit"]);
			if (dt.Rows[i]["RemainCredit"] != DBNull.Value)
			record.RemainCredit = Convert.ToInt32(dt.Rows[i]["RemainCredit"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.sMssendLogItems = (SMSSendLogItems[])(recordList.ToArray(typeof(SMSSendLogItems)));
		return obj;
		}
		public SMSSendLogRow GetByPrimaryKey(string messageID)
		{
			string whereSql = "[MessageID]=" + CreateSqlParameterName("MessageID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MessageID", messageID);
			SMSSendLogRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(SMSSendLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SMSSendLog] (" +
			"[MessageID], " + 
			"[ApplicantID], " + 
			"[CaseID], " + 
			"[SendTo], " + 
			"[TelephoneNumber], " + 
			"[IsOTP], " + 
			"[Message], " + 
			"[SendDate], " + 
			"[SendStatus], " + 
			"[SendType], " + 
			"[SendNote], " + 
			"[SendStatusName], " + 
			"[UsedCredit], " + 
			"[RemainCredit], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("MessageID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("SendTo") + ", " +
			CreateSqlParameterName("TelephoneNumber") + ", " +
			CreateSqlParameterName("IsOTP") + ", " +
			CreateSqlParameterName("Message") + ", " +
			CreateSqlParameterName("SendDate") + ", " +
			CreateSqlParameterName("SendStatus") + ", " +
			CreateSqlParameterName("SendType") + ", " +
			CreateSqlParameterName("SendNote") + ", " +
			CreateSqlParameterName("SendStatusName") + ", " +
			CreateSqlParameterName("UsedCredit") + ", " +
			CreateSqlParameterName("RemainCredit") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MessageID",value.MessageID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "SendTo", value.SendTo);
			AddParameter(cmd, "TelephoneNumber", value.TelephoneNumber);
			AddParameter(cmd, "IsOTP", value.IsIsOTPNull ? DBNull.Value : (object)value.IsOTP);
			AddParameter(cmd, "Message", value.Message);
			AddParameter(cmd, "SendDate", value.IsSendDateNull ? DBNull.Value : (object)value.SendDate);
			AddParameter(cmd, "SendStatus", value.IsSendStatusNull ? DBNull.Value : (object)value.SendStatus);
			AddParameter(cmd, "SendType", value.SendType);
			AddParameter(cmd, "SendNote", value.SendNote);
			AddParameter(cmd, "SendStatusName", value.SendStatusName);
			AddParameter(cmd, "UsedCredit", value.IsUsedCreditNull ? DBNull.Value : (object)value.UsedCredit);
			AddParameter(cmd, "RemainCredit", value.IsRemainCreditNull ? DBNull.Value : (object)value.RemainCredit);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(SMSSendLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SMSSendLog] (" +
			"[MessageID], " + 
			"[ApplicantID], " + 
			"[CaseID], " + 
			"[SendTo], " + 
			"[TelephoneNumber], " + 
			"[IsOTP], " + 
			"[Message], " + 
			"[SendDate], " + 
			"[SendStatus], " + 
			"[SendType], " + 
			"[SendNote], " + 
			"[SendStatusName], " + 
			"[UsedCredit], " + 
			"[RemainCredit], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("MessageID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("SendTo") + ", " +
			CreateSqlParameterName("TelephoneNumber") + ", " +
			CreateSqlParameterName("IsOTP") + ", " +
			CreateSqlParameterName("Message") + ", " +
			CreateSqlParameterName("SendDate") + ", " +
			CreateSqlParameterName("SendStatus") + ", " +
			CreateSqlParameterName("SendType") + ", " +
			CreateSqlParameterName("SendNote") + ", " +
			CreateSqlParameterName("SendStatusName") + ", " +
			CreateSqlParameterName("UsedCredit") + ", " +
			CreateSqlParameterName("RemainCredit") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MessageID", Sanitizer.GetSafeHtmlFragment(value.MessageID));
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "SendTo", Sanitizer.GetSafeHtmlFragment(value.SendTo));
			AddParameter(cmd, "TelephoneNumber", Sanitizer.GetSafeHtmlFragment(value.TelephoneNumber));
			AddParameter(cmd, "IsOTP", value.IsIsOTPNull ? DBNull.Value : (object)value.IsOTP);
			AddParameter(cmd, "Message", Sanitizer.GetSafeHtmlFragment(value.Message));
			AddParameter(cmd, "SendDate", value.IsSendDateNull ? DBNull.Value : (object)value.SendDate);
			AddParameter(cmd, "SendStatus", value.IsSendStatusNull ? DBNull.Value : (object)value.SendStatus);
			AddParameter(cmd, "SendType", Sanitizer.GetSafeHtmlFragment(value.SendType));
			AddParameter(cmd, "SendNote", Sanitizer.GetSafeHtmlFragment(value.SendNote));
			AddParameter(cmd, "SendStatusName", Sanitizer.GetSafeHtmlFragment(value.SendStatusName));
			AddParameter(cmd, "UsedCredit", value.IsUsedCreditNull ? DBNull.Value : (object)value.UsedCredit);
			AddParameter(cmd, "RemainCredit", value.IsRemainCreditNull ? DBNull.Value : (object)value.RemainCredit);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(SMSSendLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMessageID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetSendTo)
				{
					strUpdate += "[SendTo]=" + CreateSqlParameterName("SendTo") + ",";
				}
				if (value._IsSetTelephoneNumber)
				{
					strUpdate += "[TelephoneNumber]=" + CreateSqlParameterName("TelephoneNumber") + ",";
				}
				if (value._IsSetIsOTP)
				{
					strUpdate += "[IsOTP]=" + CreateSqlParameterName("IsOTP") + ",";
				}
				if (value._IsSetMessage)
				{
					strUpdate += "[Message]=" + CreateSqlParameterName("Message") + ",";
				}
				if (value._IsSetSendDate)
				{
					strUpdate += "[SendDate]=" + CreateSqlParameterName("SendDate") + ",";
				}
				if (value._IsSetSendStatus)
				{
					strUpdate += "[SendStatus]=" + CreateSqlParameterName("SendStatus") + ",";
				}
				if (value._IsSetSendType)
				{
					strUpdate += "[SendType]=" + CreateSqlParameterName("SendType") + ",";
				}
				if (value._IsSetSendNote)
				{
					strUpdate += "[SendNote]=" + CreateSqlParameterName("SendNote") + ",";
				}
				if (value._IsSetSendStatusName)
				{
					strUpdate += "[SendStatusName]=" + CreateSqlParameterName("SendStatusName") + ",";
				}
				if (value._IsSetUsedCredit)
				{
					strUpdate += "[UsedCredit]=" + CreateSqlParameterName("UsedCredit") + ",";
				}
				if (value._IsSetRemainCredit)
				{
					strUpdate += "[RemainCredit]=" + CreateSqlParameterName("RemainCredit") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SMSSendLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MessageID]=" + CreateSqlParameterName("MessageID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MessageID",value.MessageID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "SendTo", value.SendTo);
					AddParameter(cmd, "TelephoneNumber", value.TelephoneNumber);
					AddParameter(cmd, "IsOTP", value.IsIsOTPNull ? DBNull.Value : (object)value.IsOTP);
					AddParameter(cmd, "Message", value.Message);
					AddParameter(cmd, "SendDate", value.IsSendDateNull ? DBNull.Value : (object)value.SendDate);
					AddParameter(cmd, "SendStatus", value.IsSendStatusNull ? DBNull.Value : (object)value.SendStatus);
					AddParameter(cmd, "SendType", value.SendType);
					AddParameter(cmd, "SendNote", value.SendNote);
					AddParameter(cmd, "SendStatusName", value.SendStatusName);
					AddParameter(cmd, "UsedCredit", value.IsUsedCreditNull ? DBNull.Value : (object)value.UsedCredit);
					AddParameter(cmd, "RemainCredit", value.IsRemainCreditNull ? DBNull.Value : (object)value.RemainCredit);
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
				Exception ex = new Exception("Set incorrect primarykey PK(MessageID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SMSSendLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMessageID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetSendTo)
				{
					strUpdate += "[SendTo]=" + CreateSqlParameterName("SendTo") + ",";
				}
				if (value._IsSetTelephoneNumber)
				{
					strUpdate += "[TelephoneNumber]=" + CreateSqlParameterName("TelephoneNumber") + ",";
				}
				if (value._IsSetIsOTP)
				{
					strUpdate += "[IsOTP]=" + CreateSqlParameterName("IsOTP") + ",";
				}
				if (value._IsSetMessage)
				{
					strUpdate += "[Message]=" + CreateSqlParameterName("Message") + ",";
				}
				if (value._IsSetSendDate)
				{
					strUpdate += "[SendDate]=" + CreateSqlParameterName("SendDate") + ",";
				}
				if (value._IsSetSendStatus)
				{
					strUpdate += "[SendStatus]=" + CreateSqlParameterName("SendStatus") + ",";
				}
				if (value._IsSetSendType)
				{
					strUpdate += "[SendType]=" + CreateSqlParameterName("SendType") + ",";
				}
				if (value._IsSetSendNote)
				{
					strUpdate += "[SendNote]=" + CreateSqlParameterName("SendNote") + ",";
				}
				if (value._IsSetSendStatusName)
				{
					strUpdate += "[SendStatusName]=" + CreateSqlParameterName("SendStatusName") + ",";
				}
				if (value._IsSetUsedCredit)
				{
					strUpdate += "[UsedCredit]=" + CreateSqlParameterName("UsedCredit") + ",";
				}
				if (value._IsSetRemainCredit)
				{
					strUpdate += "[RemainCredit]=" + CreateSqlParameterName("RemainCredit") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SMSSendLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MessageID]=" + CreateSqlParameterName("MessageID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MessageID", Sanitizer.GetSafeHtmlFragment(value.MessageID));
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "SendTo", Sanitizer.GetSafeHtmlFragment(value.SendTo));
					AddParameter(cmd, "TelephoneNumber", Sanitizer.GetSafeHtmlFragment(value.TelephoneNumber));
					AddParameter(cmd, "IsOTP", value.IsIsOTPNull ? DBNull.Value : (object)value.IsOTP);
					AddParameter(cmd, "Message", Sanitizer.GetSafeHtmlFragment(value.Message));
					AddParameter(cmd, "SendDate", value.IsSendDateNull ? DBNull.Value : (object)value.SendDate);
					AddParameter(cmd, "SendStatus", value.IsSendStatusNull ? DBNull.Value : (object)value.SendStatus);
					AddParameter(cmd, "SendType", Sanitizer.GetSafeHtmlFragment(value.SendType));
					AddParameter(cmd, "SendNote", Sanitizer.GetSafeHtmlFragment(value.SendNote));
					AddParameter(cmd, "SendStatusName", Sanitizer.GetSafeHtmlFragment(value.SendStatusName));
					AddParameter(cmd, "UsedCredit", value.IsUsedCreditNull ? DBNull.Value : (object)value.UsedCredit);
					AddParameter(cmd, "RemainCredit", value.IsRemainCreditNull ? DBNull.Value : (object)value.RemainCredit);
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
		protected SMSSendLogRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SMSSendLogRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SMSSendLogRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int messageIDColumnIndex = reader.GetOrdinal("MessageID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int sendToColumnIndex = reader.GetOrdinal("SendTo");
			int telephoneNumberColumnIndex = reader.GetOrdinal("TelephoneNumber");
			int isOTPColumnIndex = reader.GetOrdinal("IsOTP");
			int messageColumnIndex = reader.GetOrdinal("Message");
			int sendDateColumnIndex = reader.GetOrdinal("SendDate");
			int sendstatusColumnIndex = reader.GetOrdinal("SendStatus");
			int sendTypeColumnIndex = reader.GetOrdinal("SendType");
			int sendNoteColumnIndex = reader.GetOrdinal("SendNote");
			int sendstatusNameColumnIndex = reader.GetOrdinal("SendStatusName");
			int usedCreditColumnIndex = reader.GetOrdinal("UsedCredit");
			int remainCreditColumnIndex = reader.GetOrdinal("RemainCredit");
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
					SMSSendLogRow record = new SMSSendLogRow();
					recordList.Add(record);
					record.MessageID =  Convert.ToString(reader.GetValue(messageIDColumnIndex));
					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(sendToColumnIndex)) record.SendTo =  Convert.ToString(reader.GetValue(sendToColumnIndex));

					if (!reader.IsDBNull(telephoneNumberColumnIndex)) record.TelephoneNumber =  Convert.ToString(reader.GetValue(telephoneNumberColumnIndex));

					if (!reader.IsDBNull(isOTPColumnIndex)) record.IsOTP =  Convert.ToBoolean(reader.GetValue(isOTPColumnIndex));

					if (!reader.IsDBNull(messageColumnIndex)) record.Message =  Convert.ToString(reader.GetValue(messageColumnIndex));

					if (!reader.IsDBNull(sendDateColumnIndex)) record.SendDate =  Convert.ToDateTime(reader.GetValue(sendDateColumnIndex));

					if (!reader.IsDBNull(sendstatusColumnIndex)) record.SendStatus =  Convert.ToBoolean(reader.GetValue(sendstatusColumnIndex));

					if (!reader.IsDBNull(sendTypeColumnIndex)) record.SendType =  Convert.ToString(reader.GetValue(sendTypeColumnIndex));

					if (!reader.IsDBNull(sendNoteColumnIndex)) record.SendNote =  Convert.ToString(reader.GetValue(sendNoteColumnIndex));

					if (!reader.IsDBNull(sendstatusNameColumnIndex)) record.SendStatusName =  Convert.ToString(reader.GetValue(sendstatusNameColumnIndex));

					if (!reader.IsDBNull(usedCreditColumnIndex)) record.UsedCredit =  Convert.ToInt32(reader.GetValue(usedCreditColumnIndex));

					if (!reader.IsDBNull(remainCreditColumnIndex)) record.RemainCredit =  Convert.ToInt32(reader.GetValue(remainCreditColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SMSSendLogRow[])(recordList.ToArray(typeof(SMSSendLogRow)));
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
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SendTo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TelephoneNumber":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsOTP":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Message":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SendDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "SendStatus":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "SendType":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SendNote":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SendStatusName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "UsedCredit":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RemainCredit":
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

