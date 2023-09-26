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
	public partial class CaseMeetingMinutesCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string IsReviewColumnName = "IsReview";
		public const string IsAdditionalColumnName = "IsAdditional";
		public const string MeetingDateColumnName = "MeetingDate";
		public const string MeetingResultsColumnName = "MeetingResults";
		public const string TimesColumnName = "Times";
		public const string MeetingPlaceColumnName = "MeetingPlace";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string NoteColumnName = "Note";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseMeetingMinutesCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseMeetingMinutesRow[] GetAll()
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
			"[CaseID],"+
			"[ApplicantID],"+
			"[IsReview],"+
			"[IsAdditional],"+
			"[MeetingDate],"+
			"[MeetingResults],"+
			"[Times],"+
			"[MeetingPlace],"+
			"[ModifiedDate],"+
			"[Note]"+
			" FROM [dbo].[CaseMeetingMinutes]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseMeetingMinutes]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseMeetingMinutes"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsReview",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsAdditional",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MeetingDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("MeetingResults",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Times",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("MeetingPlace",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			return dataTable;
		}
		public CaseMeetingMinutesRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseMeetingMinutesRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseMeetingMinutesRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseMeetingMinutesRow"/> objects.</returns>
		public virtual CaseMeetingMinutesRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseMeetingMinutes]", top);
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
		public CaseMeetingMinutesRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseMeetingMinutesRow[] rows = null;
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
		public DataTable GetCaseMeetingMinutesPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[CaseMeetingMinutes] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,ApplicantID,IsReview,IsAdditional,MeetingDate,MeetingResults,Times,MeetingPlace,ModifiedDate,Note," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [CaseMeetingMinutes].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseMeetingMinutes] " + whereSql +
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
		public CaseMeetingMinutesItemsPaging GetCaseMeetingMinutesPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseMeetingMinutesItemsPaging obj = new CaseMeetingMinutesItemsPaging();
		DataTable dt = GetCaseMeetingMinutesPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseMeetingMinutesItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseMeetingMinutesItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.IsReview = Convert.ToBoolean(dt.Rows[i]["IsReview"]);
			record.IsAdditional = Convert.ToBoolean(dt.Rows[i]["IsAdditional"]);
			if (dt.Rows[i]["MeetingDate"] != DBNull.Value)
			record.MeetingDate = Convert.ToDateTime(dt.Rows[i]["MeetingDate"]);
			record.MeetingResults = dt.Rows[i]["MeetingResults"].ToString();
			record.Times = dt.Rows[i]["Times"].ToString();
			record.MeetingPlace = dt.Rows[i]["MeetingPlace"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			recordList.Add(record);
		}
		obj.caseMeetingMinutesItems = (CaseMeetingMinutesItems[])(recordList.ToArray(typeof(CaseMeetingMinutesItems)));
		return obj;
		}
		public CaseMeetingMinutesRow GetByPrimaryKey(int caseID, int applicantID, bool isReview, bool isAdditional)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [IsReview]=" + CreateSqlParameterName("IsReview") + " AND [IsAdditional]=" + CreateSqlParameterName("IsAdditional");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "IsReview", isReview);
			AddParameter(cmd, "IsAdditional", isAdditional);
			CaseMeetingMinutesRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseMeetingMinutesRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseMeetingMinutes] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[IsReview], " + 
			"[IsAdditional], " + 
			"[MeetingDate], " + 
			"[MeetingResults], " + 
			"[Times], " + 
			"[MeetingPlace], " + 
			"[ModifiedDate], " + 
			"[Note]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("IsReview") + ", " +
			CreateSqlParameterName("IsAdditional") + ", " +
			CreateSqlParameterName("MeetingDate") + ", " +
			CreateSqlParameterName("MeetingResults") + ", " +
			CreateSqlParameterName("Times") + ", " +
			CreateSqlParameterName("MeetingPlace") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("Note") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "IsReview", value.IsReview);
			AddParameter(cmd, "IsAdditional", value.IsAdditional);
			AddParameter(cmd, "MeetingDate", value.IsMeetingDateNull ? DBNull.Value : (object)value.MeetingDate);
			AddParameter(cmd, "MeetingResults", value.MeetingResults);
			AddParameter(cmd, "Times", value.Times);
			AddParameter(cmd, "MeetingPlace", value.MeetingPlace);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "Note", value.Note);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseMeetingMinutesRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseMeetingMinutes] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[IsReview], " + 
			"[IsAdditional], " + 
			"[MeetingDate], " + 
			"[MeetingResults], " + 
			"[Times], " + 
			"[MeetingPlace], " + 
			"[ModifiedDate], " + 
			"[Note]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("IsReview") + ", " +
			CreateSqlParameterName("IsAdditional") + ", " +
			CreateSqlParameterName("MeetingDate") + ", " +
			CreateSqlParameterName("MeetingResults") + ", " +
			CreateSqlParameterName("Times") + ", " +
			CreateSqlParameterName("MeetingPlace") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("Note") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "IsReview", value.IsReview);
			AddParameter(cmd, "IsAdditional", value.IsAdditional);
			AddParameter(cmd, "MeetingDate", value.IsMeetingDateNull ? DBNull.Value : (object)value.MeetingDate);
			AddParameter(cmd, "MeetingResults", Sanitizer.GetSafeHtmlFragment(value.MeetingResults));
			AddParameter(cmd, "Times", Sanitizer.GetSafeHtmlFragment(value.Times));
			AddParameter(cmd, "MeetingPlace", Sanitizer.GetSafeHtmlFragment(value.MeetingPlace));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseMeetingMinutesRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetApplicantID == true && value._IsSetIsReview == true && value._IsSetIsAdditional == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMeetingDate)
				{
					strUpdate += "[MeetingDate]=" + CreateSqlParameterName("MeetingDate") + ",";
				}
				if (value._IsSetMeetingResults)
				{
					strUpdate += "[MeetingResults]=" + CreateSqlParameterName("MeetingResults") + ",";
				}
				if (value._IsSetTimes)
				{
					strUpdate += "[Times]=" + CreateSqlParameterName("Times") + ",";
				}
				if (value._IsSetMeetingPlace)
				{
					strUpdate += "[MeetingPlace]=" + CreateSqlParameterName("MeetingPlace") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseMeetingMinutes] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [IsReview]=" + CreateSqlParameterName("IsReview")+ " AND [IsAdditional]=" + CreateSqlParameterName("IsAdditional");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "IsReview", value.IsReview);
					AddParameter(cmd, "IsAdditional", value.IsAdditional);
					AddParameter(cmd, "MeetingDate", value.IsMeetingDateNull ? DBNull.Value : (object)value.MeetingDate);
					AddParameter(cmd, "MeetingResults", value.MeetingResults);
					AddParameter(cmd, "Times", value.Times);
					AddParameter(cmd, "MeetingPlace", value.MeetingPlace);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "Note", value.Note);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,ApplicantID,IsReview,IsAdditional)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseMeetingMinutesRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetApplicantID == true && value._IsSetIsReview == true && value._IsSetIsAdditional == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMeetingDate)
				{
					strUpdate += "[MeetingDate]=" + CreateSqlParameterName("MeetingDate") + ",";
				}
				if (value._IsSetMeetingResults)
				{
					strUpdate += "[MeetingResults]=" + CreateSqlParameterName("MeetingResults") + ",";
				}
				if (value._IsSetTimes)
				{
					strUpdate += "[Times]=" + CreateSqlParameterName("Times") + ",";
				}
				if (value._IsSetMeetingPlace)
				{
					strUpdate += "[MeetingPlace]=" + CreateSqlParameterName("MeetingPlace") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseMeetingMinutes] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [IsReview]=" + CreateSqlParameterName("IsReview")+ " AND [IsAdditional]=" + CreateSqlParameterName("IsAdditional");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "IsReview", value.IsReview);
					AddParameter(cmd, "IsAdditional", value.IsAdditional);
					AddParameter(cmd, "MeetingDate", value.IsMeetingDateNull ? DBNull.Value : (object)value.MeetingDate);
					AddParameter(cmd, "MeetingResults", Sanitizer.GetSafeHtmlFragment(value.MeetingResults));
					AddParameter(cmd, "Times", Sanitizer.GetSafeHtmlFragment(value.Times));
					AddParameter(cmd, "MeetingPlace", Sanitizer.GetSafeHtmlFragment(value.MeetingPlace));
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,ApplicantID,IsReview,IsAdditional)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID, int applicantID, bool isReview, bool isAdditional)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [IsReview]=" + CreateSqlParameterName("IsReview") + " AND [IsAdditional]=" + CreateSqlParameterName("IsAdditional");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "IsReview", isReview);
			AddParameter(cmd, "IsAdditional", isAdditional);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected CaseMeetingMinutesRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseMeetingMinutesRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseMeetingMinutesRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int isReviewColumnIndex = reader.GetOrdinal("IsReview");
			int isAdditionalColumnIndex = reader.GetOrdinal("IsAdditional");
			int meetingDateColumnIndex = reader.GetOrdinal("MeetingDate");
			int meetingResultsColumnIndex = reader.GetOrdinal("MeetingResults");
			int timesColumnIndex = reader.GetOrdinal("Times");
			int meetingPlaceColumnIndex = reader.GetOrdinal("MeetingPlace");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int noteColumnIndex = reader.GetOrdinal("Note");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					CaseMeetingMinutesRow record = new CaseMeetingMinutesRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.IsReview =  Convert.ToBoolean(reader.GetValue(isReviewColumnIndex));
					record.IsAdditional =  Convert.ToBoolean(reader.GetValue(isAdditionalColumnIndex));
					if (!reader.IsDBNull(meetingDateColumnIndex)) record.MeetingDate =  Convert.ToDateTime(reader.GetValue(meetingDateColumnIndex));

					if (!reader.IsDBNull(meetingResultsColumnIndex)) record.MeetingResults =  Convert.ToString(reader.GetValue(meetingResultsColumnIndex));

					if (!reader.IsDBNull(timesColumnIndex)) record.Times =  Convert.ToString(reader.GetValue(timesColumnIndex));

					if (!reader.IsDBNull(meetingPlaceColumnIndex)) record.MeetingPlace =  Convert.ToString(reader.GetValue(meetingPlaceColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseMeetingMinutesRow[])(recordList.ToArray(typeof(CaseMeetingMinutesRow)));
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
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsReview":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsAdditional":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "MeetingDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "MeetingResults":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Times":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MeetingPlace":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Note":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

