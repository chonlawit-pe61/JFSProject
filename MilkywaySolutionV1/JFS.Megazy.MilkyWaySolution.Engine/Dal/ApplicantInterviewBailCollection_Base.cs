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
	public partial class ApplicantInterviewBailCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string IssueDateColumnName = "IssueDate";
		public const string OfficerOrDepartmentColumnName = "OfficerOrDepartment";
		public const string ArrestNameColumnName = "ArrestName";
		public const string ArrestWithStatusColumnName = "ArrestWithStatus";
		public const string ArrestWithColumnName = "ArrestWith";
		public const string ChargeColumnName = "Charge";
		public const string PenaltyColumnName = "Penalty";
		public const string TestifyColumnName = "Testify";
		public const string CaptureAsColumnName = "CaptureAs";
		public const string AccusedTellCodeColumnName = "AccusedTellCode";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantInterviewBailCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantInterviewBailRow[] GetAll()
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
			"[ApplicantID],"+
			"[IssueDate],"+
			"[OfficerOrDepartment],"+
			"[ArrestName],"+
			"[ArrestWithStatus],"+
			"[ArrestWith],"+
			"[Charge],"+
			"[Penalty],"+
			"[Testify],"+
			"[CaptureAs],"+
			"[AccusedTellCode],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantInterviewBail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantInterviewBail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantInterviewBail"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IssueDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("OfficerOrDepartment",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ArrestName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ArrestWithStatus",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ArrestWith",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Charge",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("Penalty",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Testify",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("CaptureAs",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("AccusedTellCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ApplicantInterviewBailRow[] GetByApplicantID(int applicantID)
		{
			return MapRecords(CreateGetByApplicantIDCommand(applicantID));
		}
		public virtual DataTable GetByApplicantIDAsDataTable(int applicantID)
		{
			return MapRecordsToDataTable(CreateGetByApplicantIDCommand(applicantID));
		}
		protected virtual IDbCommand CreateGetByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public ApplicantInterviewBailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantInterviewBailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantInterviewBailRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantInterviewBailRow"/> objects.</returns>
		public virtual ApplicantInterviewBailRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantInterviewBail]", top);
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
		public ApplicantInterviewBailRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantInterviewBailRow[] rows = null;
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
		public DataTable GetApplicantInterviewBailPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ApplicantID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ApplicantID) AS TotalRow FROM [dbo].[ApplicantInterviewBail] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,IssueDate,OfficerOrDepartment,ArrestName,ArrestWithStatus,ArrestWith,Charge,Penalty,Testify,CaptureAs,AccusedTellCode,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantInterviewBail] " + whereSql +
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
		public ApplicantInterviewBailItemsPaging GetApplicantInterviewBailPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		ApplicantInterviewBailItemsPaging obj = new ApplicantInterviewBailItemsPaging();
		DataTable dt = GetApplicantInterviewBailPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantInterviewBailItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantInterviewBailItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["IssueDate"] != DBNull.Value)
			record.IssueDate = Convert.ToDateTime(dt.Rows[i]["IssueDate"]);
			record.OfficerOrDepartment = dt.Rows[i]["OfficerOrDepartment"].ToString();
			record.ArrestName = dt.Rows[i]["ArrestName"].ToString();
			if (dt.Rows[i]["ArrestWithStatus"] != DBNull.Value)
			record.ArrestWithStatus = Convert.ToBoolean(dt.Rows[i]["ArrestWithStatus"]);
			record.ArrestWith = dt.Rows[i]["ArrestWith"].ToString();
			record.Charge = dt.Rows[i]["Charge"].ToString();
			if (dt.Rows[i]["Penalty"] != DBNull.Value)
			record.Penalty = Convert.ToInt32(dt.Rows[i]["Penalty"]);
			record.Testify = dt.Rows[i]["Testify"].ToString();
			record.CaptureAs = dt.Rows[i]["CaptureAs"].ToString();
			record.AccusedTellCode = dt.Rows[i]["AccusedTellCode"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantInterviewBailItems = (ApplicantInterviewBailItems[])(recordList.ToArray(typeof(ApplicantInterviewBailItems)));
		return obj;
		}
		public ApplicantInterviewBailRow GetByPrimaryKey(int applicantID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			ApplicantInterviewBailRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ApplicantInterviewBailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantInterviewBail] (" +
			"[ApplicantID], " + 
			"[IssueDate], " + 
			"[OfficerOrDepartment], " + 
			"[ArrestName], " + 
			"[ArrestWithStatus], " + 
			"[ArrestWith], " + 
			"[Charge], " + 
			"[Penalty], " + 
			"[Testify], " + 
			"[CaptureAs], " + 
			"[AccusedTellCode], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("IssueDate") + ", " +
			CreateSqlParameterName("OfficerOrDepartment") + ", " +
			CreateSqlParameterName("ArrestName") + ", " +
			CreateSqlParameterName("ArrestWithStatus") + ", " +
			CreateSqlParameterName("ArrestWith") + ", " +
			CreateSqlParameterName("Charge") + ", " +
			CreateSqlParameterName("Penalty") + ", " +
			CreateSqlParameterName("Testify") + ", " +
			CreateSqlParameterName("CaptureAs") + ", " +
			CreateSqlParameterName("AccusedTellCode") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
			AddParameter(cmd, "OfficerOrDepartment", value.OfficerOrDepartment);
			AddParameter(cmd, "ArrestName", value.ArrestName);
			AddParameter(cmd, "ArrestWithStatus", value.IsArrestWithStatusNull ? DBNull.Value : (object)value.ArrestWithStatus);
			AddParameter(cmd, "ArrestWith", value.ArrestWith);
			AddParameter(cmd, "Charge", value.Charge);
			AddParameter(cmd, "Penalty", value.IsPenaltyNull ? DBNull.Value : (object)value.Penalty);
			AddParameter(cmd, "Testify", value.Testify);
			AddParameter(cmd, "CaptureAs", value.CaptureAs);
			AddParameter(cmd, "AccusedTellCode", value.AccusedTellCode);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ApplicantInterviewBailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantInterviewBail] (" +
			"[ApplicantID], " + 
			"[IssueDate], " + 
			"[OfficerOrDepartment], " + 
			"[ArrestName], " + 
			"[ArrestWithStatus], " + 
			"[ArrestWith], " + 
			"[Charge], " + 
			"[Penalty], " + 
			"[Testify], " + 
			"[CaptureAs], " + 
			"[AccusedTellCode], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("IssueDate") + ", " +
			CreateSqlParameterName("OfficerOrDepartment") + ", " +
			CreateSqlParameterName("ArrestName") + ", " +
			CreateSqlParameterName("ArrestWithStatus") + ", " +
			CreateSqlParameterName("ArrestWith") + ", " +
			CreateSqlParameterName("Charge") + ", " +
			CreateSqlParameterName("Penalty") + ", " +
			CreateSqlParameterName("Testify") + ", " +
			CreateSqlParameterName("CaptureAs") + ", " +
			CreateSqlParameterName("AccusedTellCode") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
			AddParameter(cmd, "OfficerOrDepartment", Sanitizer.GetSafeHtmlFragment(value.OfficerOrDepartment));
			AddParameter(cmd, "ArrestName", Sanitizer.GetSafeHtmlFragment(value.ArrestName));
			AddParameter(cmd, "ArrestWithStatus", value.IsArrestWithStatusNull ? DBNull.Value : (object)value.ArrestWithStatus);
			AddParameter(cmd, "ArrestWith", Sanitizer.GetSafeHtmlFragment(value.ArrestWith));
			AddParameter(cmd, "Charge", Sanitizer.GetSafeHtmlFragment(value.Charge));
			AddParameter(cmd, "Penalty", value.IsPenaltyNull ? DBNull.Value : (object)value.Penalty);
			AddParameter(cmd, "Testify", Sanitizer.GetSafeHtmlFragment(value.Testify));
			AddParameter(cmd, "CaptureAs", Sanitizer.GetSafeHtmlFragment(value.CaptureAs));
			AddParameter(cmd, "AccusedTellCode", Sanitizer.GetSafeHtmlFragment(value.AccusedTellCode));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ApplicantInterviewBailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetIssueDate)
				{
					strUpdate += "[IssueDate]=" + CreateSqlParameterName("IssueDate") + ",";
				}
				if (value._IsSetOfficerOrDepartment)
				{
					strUpdate += "[OfficerOrDepartment]=" + CreateSqlParameterName("OfficerOrDepartment") + ",";
				}
				if (value._IsSetArrestName)
				{
					strUpdate += "[ArrestName]=" + CreateSqlParameterName("ArrestName") + ",";
				}
				if (value._IsSetArrestWithStatus)
				{
					strUpdate += "[ArrestWithStatus]=" + CreateSqlParameterName("ArrestWithStatus") + ",";
				}
				if (value._IsSetArrestWith)
				{
					strUpdate += "[ArrestWith]=" + CreateSqlParameterName("ArrestWith") + ",";
				}
				if (value._IsSetCharge)
				{
					strUpdate += "[Charge]=" + CreateSqlParameterName("Charge") + ",";
				}
				if (value._IsSetPenalty)
				{
					strUpdate += "[Penalty]=" + CreateSqlParameterName("Penalty") + ",";
				}
				if (value._IsSetTestify)
				{
					strUpdate += "[Testify]=" + CreateSqlParameterName("Testify") + ",";
				}
				if (value._IsSetCaptureAs)
				{
					strUpdate += "[CaptureAs]=" + CreateSqlParameterName("CaptureAs") + ",";
				}
				if (value._IsSetAccusedTellCode)
				{
					strUpdate += "[AccusedTellCode]=" + CreateSqlParameterName("AccusedTellCode") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantInterviewBail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
					AddParameter(cmd, "OfficerOrDepartment", value.OfficerOrDepartment);
					AddParameter(cmd, "ArrestName", value.ArrestName);
					AddParameter(cmd, "ArrestWithStatus", value.IsArrestWithStatusNull ? DBNull.Value : (object)value.ArrestWithStatus);
					AddParameter(cmd, "ArrestWith", value.ArrestWith);
					AddParameter(cmd, "Charge", value.Charge);
					AddParameter(cmd, "Penalty", value.IsPenaltyNull ? DBNull.Value : (object)value.Penalty);
					AddParameter(cmd, "Testify", value.Testify);
					AddParameter(cmd, "CaptureAs", value.CaptureAs);
					AddParameter(cmd, "AccusedTellCode", value.AccusedTellCode);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantInterviewBailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetIssueDate)
				{
					strUpdate += "[IssueDate]=" + CreateSqlParameterName("IssueDate") + ",";
				}
				if (value._IsSetOfficerOrDepartment)
				{
					strUpdate += "[OfficerOrDepartment]=" + CreateSqlParameterName("OfficerOrDepartment") + ",";
				}
				if (value._IsSetArrestName)
				{
					strUpdate += "[ArrestName]=" + CreateSqlParameterName("ArrestName") + ",";
				}
				if (value._IsSetArrestWithStatus)
				{
					strUpdate += "[ArrestWithStatus]=" + CreateSqlParameterName("ArrestWithStatus") + ",";
				}
				if (value._IsSetArrestWith)
				{
					strUpdate += "[ArrestWith]=" + CreateSqlParameterName("ArrestWith") + ",";
				}
				if (value._IsSetCharge)
				{
					strUpdate += "[Charge]=" + CreateSqlParameterName("Charge") + ",";
				}
				if (value._IsSetPenalty)
				{
					strUpdate += "[Penalty]=" + CreateSqlParameterName("Penalty") + ",";
				}
				if (value._IsSetTestify)
				{
					strUpdate += "[Testify]=" + CreateSqlParameterName("Testify") + ",";
				}
				if (value._IsSetCaptureAs)
				{
					strUpdate += "[CaptureAs]=" + CreateSqlParameterName("CaptureAs") + ",";
				}
				if (value._IsSetAccusedTellCode)
				{
					strUpdate += "[AccusedTellCode]=" + CreateSqlParameterName("AccusedTellCode") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantInterviewBail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
					AddParameter(cmd, "OfficerOrDepartment", Sanitizer.GetSafeHtmlFragment(value.OfficerOrDepartment));
					AddParameter(cmd, "ArrestName", Sanitizer.GetSafeHtmlFragment(value.ArrestName));
					AddParameter(cmd, "ArrestWithStatus", value.IsArrestWithStatusNull ? DBNull.Value : (object)value.ArrestWithStatus);
					AddParameter(cmd, "ArrestWith", Sanitizer.GetSafeHtmlFragment(value.ArrestWith));
					AddParameter(cmd, "Charge", Sanitizer.GetSafeHtmlFragment(value.Charge));
					AddParameter(cmd, "Penalty", value.IsPenaltyNull ? DBNull.Value : (object)value.Penalty);
					AddParameter(cmd, "Testify", Sanitizer.GetSafeHtmlFragment(value.Testify));
					AddParameter(cmd, "CaptureAs", Sanitizer.GetSafeHtmlFragment(value.CaptureAs));
					AddParameter(cmd, "AccusedTellCode", Sanitizer.GetSafeHtmlFragment(value.AccusedTellCode));
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int applicantID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return CreateDeleteByApplicantIDCommand(applicantID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		protected ApplicantInterviewBailRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantInterviewBailRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantInterviewBailRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int issueDateColumnIndex = reader.GetOrdinal("IssueDate");
			int officerorDepartmentColumnIndex = reader.GetOrdinal("OfficerOrDepartment");
			int arrestNameColumnIndex = reader.GetOrdinal("ArrestName");
			int arrestWithStatusColumnIndex = reader.GetOrdinal("ArrestWithStatus");
			int arrestWithColumnIndex = reader.GetOrdinal("ArrestWith");
			int chargeColumnIndex = reader.GetOrdinal("Charge");
			int penaltyColumnIndex = reader.GetOrdinal("Penalty");
			int testifyColumnIndex = reader.GetOrdinal("Testify");
			int captureAsColumnIndex = reader.GetOrdinal("CaptureAs");
			int accusedTellCodeColumnIndex = reader.GetOrdinal("AccusedTellCode");
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
					ApplicantInterviewBailRow record = new ApplicantInterviewBailRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(issueDateColumnIndex)) record.IssueDate =  Convert.ToDateTime(reader.GetValue(issueDateColumnIndex));

					if (!reader.IsDBNull(officerorDepartmentColumnIndex)) record.OfficerOrDepartment =  Convert.ToString(reader.GetValue(officerorDepartmentColumnIndex));

					if (!reader.IsDBNull(arrestNameColumnIndex)) record.ArrestName =  Convert.ToString(reader.GetValue(arrestNameColumnIndex));

					if (!reader.IsDBNull(arrestWithStatusColumnIndex)) record.ArrestWithStatus =  Convert.ToBoolean(reader.GetValue(arrestWithStatusColumnIndex));

					if (!reader.IsDBNull(arrestWithColumnIndex)) record.ArrestWith =  Convert.ToString(reader.GetValue(arrestWithColumnIndex));

					if (!reader.IsDBNull(chargeColumnIndex)) record.Charge =  Convert.ToString(reader.GetValue(chargeColumnIndex));

					if (!reader.IsDBNull(penaltyColumnIndex)) record.Penalty =  Convert.ToInt32(reader.GetValue(penaltyColumnIndex));

					if (!reader.IsDBNull(testifyColumnIndex)) record.Testify =  Convert.ToString(reader.GetValue(testifyColumnIndex));

					if (!reader.IsDBNull(captureAsColumnIndex)) record.CaptureAs =  Convert.ToString(reader.GetValue(captureAsColumnIndex));

					if (!reader.IsDBNull(accusedTellCodeColumnIndex)) record.AccusedTellCode =  Convert.ToString(reader.GetValue(accusedTellCodeColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantInterviewBailRow[])(recordList.ToArray(typeof(ApplicantInterviewBailRow)));
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
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IssueDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "OfficerOrDepartment":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ArrestName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ArrestWithStatus":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "ArrestWith":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Charge":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Penalty":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Testify":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CaptureAs":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AccusedTellCode":
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

