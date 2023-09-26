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
	public partial class CaseApplicantOpinionCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string OfficerRoleIDColumnName = "OfficerRoleID";
		public const string IsAppealColumnName = "IsAppeal";
		public const string TermIDColumnName = "TermID";
		public const string IsFinalApprovedColumnName = "IsFinalApproved";
		public const string OpinionIDColumnName = "OpinionID";
		public const string AdditionalOpinionColumnName = "AdditionalOpinion";
		public const string CommentColumnName = "Comment";
		public const string ShortCommentColumnName = "ShortComment";
		public const string RemarkColumnName = "Remark";
		public const string IssueDateColumnName = "IssueDate";
		public const string CompleteDateColumnName = "CompleteDate";
		public const string IsAgreeColumnName = "IsAgree";
		public const string FollowAsOfficerRoleIDColumnName = "FollowAsOfficerRoleID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseApplicantOpinionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseApplicantOpinionRow[] GetAll()
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
			"[OfficerRoleID],"+
			"[IsAppeal],"+
			"[TermID],"+
			"[IsFinalApproved],"+
			"[OpinionID],"+
			"[AdditionalOpinion],"+
			"[Comment],"+
			"[ShortComment],"+
			"[Remark],"+
			"[IssueDate],"+
			"[CompleteDate],"+
			"[IsAgree],"+
			"[FollowAsOfficerRoleID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseApplicantOpinion]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseApplicantOpinion]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseApplicantOpinion"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OfficerRoleID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsAppeal",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TermID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsFinalApproved",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("OpinionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("AdditionalOpinion",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("Comment",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ShortComment",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("IssueDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("CompleteDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("IsAgree",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("FollowAsOfficerRoleID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseApplicantOpinionRow[] GetByOfficerRoleID(int officerRoleID)
		{
			return MapRecords(CreateGetByOfficerRoleIDCommand(officerRoleID));
		}
		public virtual DataTable GetByOfficerRoleIDAsDataTable(int officerRoleID)
		{
			return MapRecordsToDataTable(CreateGetByOfficerRoleIDCommand(officerRoleID));
		}
		protected virtual IDbCommand CreateGetByOfficerRoleIDCommand(int officerRoleID)
		{
			string whereSql = "";
			whereSql += "[OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "OfficerRoleID", officerRoleID);
			return cmd;
		}
		public virtual CaseApplicantOpinionRow[] GetByTermID(int termID)
		{
			return MapRecords(CreateGetByTermIDCommand(termID));
		}
		public virtual DataTable GetByTermIDAsDataTable(int termID)
		{
			return MapRecordsToDataTable(CreateGetByTermIDCommand(termID));
		}
		protected virtual IDbCommand CreateGetByTermIDCommand(int termID)
		{
			string whereSql = "";
			whereSql += "[TermID]=" + CreateSqlParameterName("TermID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TermID", termID);
			return cmd;
		}
		public virtual CaseApplicantOpinionRow[] GetByOpinionID(int opinionID)
		{
			return MapRecords(CreateGetByOpinionIDCommand(opinionID));
		}
		public virtual DataTable GetByOpinionIDAsDataTable(int opinionID)
		{
			return MapRecordsToDataTable(CreateGetByOpinionIDCommand(opinionID));
		}
		protected virtual IDbCommand CreateGetByOpinionIDCommand(int opinionID)
		{
			string whereSql = "";
			whereSql += "[OpinionID]=" + CreateSqlParameterName("OpinionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "OpinionID", opinionID);
			return cmd;
		}
		public virtual CaseApplicantOpinionRow[] GetByFollowAsOfficerRoleID(int followAsOfficerRoleID)
		{
			return MapRecords(CreateGetByFollowAsOfficerRoleIDCommand(followAsOfficerRoleID));
		}
		public virtual DataTable GetByFollowAsOfficerRoleIDAsDataTable(int followAsOfficerRoleID)
		{
			return MapRecordsToDataTable(CreateGetByFollowAsOfficerRoleIDCommand(followAsOfficerRoleID));
		}
		protected virtual IDbCommand CreateGetByFollowAsOfficerRoleIDCommand(int followAsOfficerRoleID)
		{
			string whereSql = "";
			whereSql += "[FollowAsOfficerRoleID]=" + CreateSqlParameterName("FollowAsOfficerRoleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FollowAsOfficerRoleID", followAsOfficerRoleID);
			return cmd;
		}
		public CaseApplicantOpinionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseApplicantOpinionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseApplicantOpinionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseApplicantOpinionRow"/> objects.</returns>
		public virtual CaseApplicantOpinionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseApplicantOpinion]", top);
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
		public CaseApplicantOpinionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseApplicantOpinionRow[] rows = null;
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
		public DataTable GetCaseApplicantOpinionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
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
		string sql = "SELECT COUNT(ApplicantID) AS TotalRow FROM [dbo].[CaseApplicantOpinion] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,OfficerRoleID,IsAppeal,TermID,IsFinalApproved,OpinionID,AdditionalOpinion,Comment,ShortComment,Remark,IssueDate,CompleteDate,IsAgree,FollowAsOfficerRoleID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseApplicantOpinion] " + whereSql +
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
		public CaseApplicantOpinionItemsPaging GetCaseApplicantOpinionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		CaseApplicantOpinionItemsPaging obj = new CaseApplicantOpinionItemsPaging();
		DataTable dt = GetCaseApplicantOpinionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseApplicantOpinionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseApplicantOpinionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.OfficerRoleID = Convert.ToInt32(dt.Rows[i]["OfficerRoleID"]);
			record.IsAppeal = Convert.ToBoolean(dt.Rows[i]["IsAppeal"]);
			if (dt.Rows[i]["TermID"] != DBNull.Value)
			record.TermID = Convert.ToInt32(dt.Rows[i]["TermID"]);
			if (dt.Rows[i]["IsFinalApproved"] != DBNull.Value)
			record.IsFinalApproved = Convert.ToBoolean(dt.Rows[i]["IsFinalApproved"]);
			if (dt.Rows[i]["OpinionID"] != DBNull.Value)
			record.OpinionID = Convert.ToInt32(dt.Rows[i]["OpinionID"]);
			record.AdditionalOpinion = dt.Rows[i]["AdditionalOpinion"].ToString();
			record.Comment = dt.Rows[i]["Comment"].ToString();
			record.ShortComment = dt.Rows[i]["ShortComment"].ToString();
			record.Remark = dt.Rows[i]["Remark"].ToString();
			if (dt.Rows[i]["IssueDate"] != DBNull.Value)
			record.IssueDate = Convert.ToDateTime(dt.Rows[i]["IssueDate"]);
			if (dt.Rows[i]["CompleteDate"] != DBNull.Value)
			record.CompleteDate = Convert.ToDateTime(dt.Rows[i]["CompleteDate"]);
			if (dt.Rows[i]["IsAgree"] != DBNull.Value)
			record.IsAgree = Convert.ToBoolean(dt.Rows[i]["IsAgree"]);
			if (dt.Rows[i]["FollowAsOfficerRoleID"] != DBNull.Value)
			record.FollowAsOfficerRoleID = Convert.ToInt32(dt.Rows[i]["FollowAsOfficerRoleID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseApplicantOpinionItems = (CaseApplicantOpinionItems[])(recordList.ToArray(typeof(CaseApplicantOpinionItems)));
		return obj;
		}
		public CaseApplicantOpinionRow GetByPrimaryKey(int applicantID, int officerRoleID, bool isAppeal)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID") + " AND [IsAppeal]=" + CreateSqlParameterName("IsAppeal");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "OfficerRoleID", officerRoleID);
			AddParameter(cmd, "IsAppeal", isAppeal);
			CaseApplicantOpinionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseApplicantOpinionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantOpinion] (" +
			"[ApplicantID], " + 
			"[OfficerRoleID], " + 
			"[IsAppeal], " + 
			"[TermID], " + 
			"[IsFinalApproved], " + 
			"[OpinionID], " + 
			"[AdditionalOpinion], " + 
			"[Comment], " + 
			"[ShortComment], " + 
			"[Remark], " + 
			"[IssueDate], " + 
			"[CompleteDate], " + 
			"[IsAgree], " + 
			"[FollowAsOfficerRoleID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("OfficerRoleID") + ", " +
			CreateSqlParameterName("IsAppeal") + ", " +
			CreateSqlParameterName("TermID") + ", " +
			CreateSqlParameterName("IsFinalApproved") + ", " +
			CreateSqlParameterName("OpinionID") + ", " +
			CreateSqlParameterName("AdditionalOpinion") + ", " +
			CreateSqlParameterName("Comment") + ", " +
			CreateSqlParameterName("ShortComment") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("IssueDate") + ", " +
			CreateSqlParameterName("CompleteDate") + ", " +
			CreateSqlParameterName("IsAgree") + ", " +
			CreateSqlParameterName("FollowAsOfficerRoleID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "OfficerRoleID", value.OfficerRoleID);
			AddParameter(cmd, "IsAppeal", value.IsAppeal);
			AddParameter(cmd, "TermID", value.IsTermIDNull ? DBNull.Value : (object)value.TermID);
			AddParameter(cmd, "IsFinalApproved", value.IsIsFinalApprovedNull ? DBNull.Value : (object)value.IsFinalApproved);
			AddParameter(cmd, "OpinionID", value.IsOpinionIDNull ? DBNull.Value : (object)value.OpinionID);
			AddParameter(cmd, "AdditionalOpinion", value.AdditionalOpinion);
			AddParameter(cmd, "Comment", value.Comment);
			AddParameter(cmd, "ShortComment", value.ShortComment);
			AddParameter(cmd, "Remark", value.Remark);
			AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
			AddParameter(cmd, "CompleteDate", value.IsCompleteDateNull ? DBNull.Value : (object)value.CompleteDate);
			AddParameter(cmd, "IsAgree", value.IsIsAgreeNull ? DBNull.Value : (object)value.IsAgree);
			AddParameter(cmd, "FollowAsOfficerRoleID", value.IsFollowAsOfficerRoleIDNull ? DBNull.Value : (object)value.FollowAsOfficerRoleID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseApplicantOpinionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantOpinion] (" +
			"[ApplicantID], " + 
			"[OfficerRoleID], " + 
			"[IsAppeal], " + 
			"[TermID], " + 
			"[IsFinalApproved], " + 
			"[OpinionID], " + 
			"[AdditionalOpinion], " + 
			"[Comment], " + 
			"[ShortComment], " + 
			"[Remark], " + 
			"[IssueDate], " + 
			"[CompleteDate], " + 
			"[IsAgree], " + 
			"[FollowAsOfficerRoleID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("OfficerRoleID") + ", " +
			CreateSqlParameterName("IsAppeal") + ", " +
			CreateSqlParameterName("TermID") + ", " +
			CreateSqlParameterName("IsFinalApproved") + ", " +
			CreateSqlParameterName("OpinionID") + ", " +
			CreateSqlParameterName("AdditionalOpinion") + ", " +
			CreateSqlParameterName("Comment") + ", " +
			CreateSqlParameterName("ShortComment") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("IssueDate") + ", " +
			CreateSqlParameterName("CompleteDate") + ", " +
			CreateSqlParameterName("IsAgree") + ", " +
			CreateSqlParameterName("FollowAsOfficerRoleID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "OfficerRoleID", value.OfficerRoleID);
			AddParameter(cmd, "IsAppeal", value.IsAppeal);
			AddParameter(cmd, "TermID", value.IsTermIDNull ? DBNull.Value : (object)value.TermID);
			AddParameter(cmd, "IsFinalApproved", value.IsIsFinalApprovedNull ? DBNull.Value : (object)value.IsFinalApproved);
			AddParameter(cmd, "OpinionID", value.IsOpinionIDNull ? DBNull.Value : (object)value.OpinionID);
			AddParameter(cmd, "AdditionalOpinion", Sanitizer.GetSafeHtmlFragment(value.AdditionalOpinion));
			AddParameter(cmd, "Comment", Sanitizer.GetSafeHtmlFragment(value.Comment));
			AddParameter(cmd, "ShortComment", Sanitizer.GetSafeHtmlFragment(value.ShortComment));
			AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
			AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
			AddParameter(cmd, "CompleteDate", value.IsCompleteDateNull ? DBNull.Value : (object)value.CompleteDate);
			AddParameter(cmd, "IsAgree", value.IsIsAgreeNull ? DBNull.Value : (object)value.IsAgree);
			AddParameter(cmd, "FollowAsOfficerRoleID", value.IsFollowAsOfficerRoleIDNull ? DBNull.Value : (object)value.FollowAsOfficerRoleID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseApplicantOpinionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetOfficerRoleID == true && value._IsSetIsAppeal == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTermID)
				{
					strUpdate += "[TermID]=" + CreateSqlParameterName("TermID") + ",";
				}
				if (value._IsSetIsFinalApproved)
				{
					strUpdate += "[IsFinalApproved]=" + CreateSqlParameterName("IsFinalApproved") + ",";
				}
				if (value._IsSetOpinionID)
				{
					strUpdate += "[OpinionID]=" + CreateSqlParameterName("OpinionID") + ",";
				}
				if (value._IsSetAdditionalOpinion)
				{
					strUpdate += "[AdditionalOpinion]=" + CreateSqlParameterName("AdditionalOpinion") + ",";
				}
				if (value._IsSetComment)
				{
					strUpdate += "[Comment]=" + CreateSqlParameterName("Comment") + ",";
				}
				if (value._IsSetShortComment)
				{
					strUpdate += "[ShortComment]=" + CreateSqlParameterName("ShortComment") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetIssueDate)
				{
					strUpdate += "[IssueDate]=" + CreateSqlParameterName("IssueDate") + ",";
				}
				if (value._IsSetCompleteDate)
				{
					strUpdate += "[CompleteDate]=" + CreateSqlParameterName("CompleteDate") + ",";
				}
				if (value._IsSetIsAgree)
				{
					strUpdate += "[IsAgree]=" + CreateSqlParameterName("IsAgree") + ",";
				}
				if (value._IsSetFollowAsOfficerRoleID)
				{
					strUpdate += "[FollowAsOfficerRoleID]=" + CreateSqlParameterName("FollowAsOfficerRoleID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantOpinion] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID")+ " AND [IsAppeal]=" + CreateSqlParameterName("IsAppeal");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "OfficerRoleID", value.OfficerRoleID);
					AddParameter(cmd, "IsAppeal", value.IsAppeal);
					AddParameter(cmd, "TermID", value.IsTermIDNull ? DBNull.Value : (object)value.TermID);
					AddParameter(cmd, "IsFinalApproved", value.IsIsFinalApprovedNull ? DBNull.Value : (object)value.IsFinalApproved);
					AddParameter(cmd, "OpinionID", value.IsOpinionIDNull ? DBNull.Value : (object)value.OpinionID);
					AddParameter(cmd, "AdditionalOpinion", value.AdditionalOpinion);
					AddParameter(cmd, "Comment", value.Comment);
					AddParameter(cmd, "ShortComment", value.ShortComment);
					AddParameter(cmd, "Remark", value.Remark);
					AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
					AddParameter(cmd, "CompleteDate", value.IsCompleteDateNull ? DBNull.Value : (object)value.CompleteDate);
					AddParameter(cmd, "IsAgree", value.IsIsAgreeNull ? DBNull.Value : (object)value.IsAgree);
					AddParameter(cmd, "FollowAsOfficerRoleID", value.IsFollowAsOfficerRoleIDNull ? DBNull.Value : (object)value.FollowAsOfficerRoleID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,OfficerRoleID,IsAppeal)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseApplicantOpinionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetOfficerRoleID == true && value._IsSetIsAppeal == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTermID)
				{
					strUpdate += "[TermID]=" + CreateSqlParameterName("TermID") + ",";
				}
				if (value._IsSetIsFinalApproved)
				{
					strUpdate += "[IsFinalApproved]=" + CreateSqlParameterName("IsFinalApproved") + ",";
				}
				if (value._IsSetOpinionID)
				{
					strUpdate += "[OpinionID]=" + CreateSqlParameterName("OpinionID") + ",";
				}
				if (value._IsSetAdditionalOpinion)
				{
					strUpdate += "[AdditionalOpinion]=" + CreateSqlParameterName("AdditionalOpinion") + ",";
				}
				if (value._IsSetComment)
				{
					strUpdate += "[Comment]=" + CreateSqlParameterName("Comment") + ",";
				}
				if (value._IsSetShortComment)
				{
					strUpdate += "[ShortComment]=" + CreateSqlParameterName("ShortComment") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetIssueDate)
				{
					strUpdate += "[IssueDate]=" + CreateSqlParameterName("IssueDate") + ",";
				}
				if (value._IsSetCompleteDate)
				{
					strUpdate += "[CompleteDate]=" + CreateSqlParameterName("CompleteDate") + ",";
				}
				if (value._IsSetIsAgree)
				{
					strUpdate += "[IsAgree]=" + CreateSqlParameterName("IsAgree") + ",";
				}
				if (value._IsSetFollowAsOfficerRoleID)
				{
					strUpdate += "[FollowAsOfficerRoleID]=" + CreateSqlParameterName("FollowAsOfficerRoleID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantOpinion] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID")+ " AND [IsAppeal]=" + CreateSqlParameterName("IsAppeal");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "OfficerRoleID", value.OfficerRoleID);
					AddParameter(cmd, "IsAppeal", value.IsAppeal);
					AddParameter(cmd, "TermID", value.IsTermIDNull ? DBNull.Value : (object)value.TermID);
					AddParameter(cmd, "IsFinalApproved", value.IsIsFinalApprovedNull ? DBNull.Value : (object)value.IsFinalApproved);
					AddParameter(cmd, "OpinionID", value.IsOpinionIDNull ? DBNull.Value : (object)value.OpinionID);
					AddParameter(cmd, "AdditionalOpinion", Sanitizer.GetSafeHtmlFragment(value.AdditionalOpinion));
					AddParameter(cmd, "Comment", Sanitizer.GetSafeHtmlFragment(value.Comment));
					AddParameter(cmd, "ShortComment", Sanitizer.GetSafeHtmlFragment(value.ShortComment));
					AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
					AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
					AddParameter(cmd, "CompleteDate", value.IsCompleteDateNull ? DBNull.Value : (object)value.CompleteDate);
					AddParameter(cmd, "IsAgree", value.IsIsAgreeNull ? DBNull.Value : (object)value.IsAgree);
					AddParameter(cmd, "FollowAsOfficerRoleID", value.IsFollowAsOfficerRoleIDNull ? DBNull.Value : (object)value.FollowAsOfficerRoleID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,OfficerRoleID,IsAppeal)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int applicantID, int officerRoleID, bool isAppeal)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID") + " AND [IsAppeal]=" + CreateSqlParameterName("IsAppeal");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "OfficerRoleID", officerRoleID);
			AddParameter(cmd, "IsAppeal", isAppeal);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByOfficerRoleID(int officerRoleID)
		{
			return CreateDeleteByOfficerRoleIDCommand(officerRoleID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByOfficerRoleIDCommand(int officerRoleID)
		{
			string whereSql = "";
			whereSql += "[OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "OfficerRoleID", officerRoleID);
			return cmd;
		}
		public int DeleteByTermID(int termID)
		{
			return DeleteByTermID(termID, false);
		}
		public int DeleteByTermID(int termID, bool termIDNull)
		{
			return CreateDeleteByTermIDCommand(termID, termIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTermIDCommand(int termID, bool termIDNull)
		{
			string whereSql = "";
			if (termIDNull)
				whereSql += "[TermID] IS NULL";
			else
				whereSql += "[TermID]=" + CreateSqlParameterName("TermID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!termIDNull)
				AddParameter(cmd, "TermID", termID);
			return cmd;
		}
		public int DeleteByOpinionID(int opinionID)
		{
			return DeleteByOpinionID(opinionID, false);
		}
		public int DeleteByOpinionID(int opinionID, bool opinionIDNull)
		{
			return CreateDeleteByOpinionIDCommand(opinionID, opinionIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByOpinionIDCommand(int opinionID, bool opinionIDNull)
		{
			string whereSql = "";
			if (opinionIDNull)
				whereSql += "[OpinionID] IS NULL";
			else
				whereSql += "[OpinionID]=" + CreateSqlParameterName("OpinionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!opinionIDNull)
				AddParameter(cmd, "OpinionID", opinionID);
			return cmd;
		}
		public int DeleteByFollowAsOfficerRoleID(int followAsOfficerRoleID)
		{
			return DeleteByFollowAsOfficerRoleID(followAsOfficerRoleID, false);
		}
		public int DeleteByFollowAsOfficerRoleID(int followAsOfficerRoleID, bool followAsOfficerRoleIDNull)
		{
			return CreateDeleteByFollowAsOfficerRoleIDCommand(followAsOfficerRoleID, followAsOfficerRoleIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFollowAsOfficerRoleIDCommand(int followAsOfficerRoleID, bool followAsOfficerRoleIDNull)
		{
			string whereSql = "";
			if (followAsOfficerRoleIDNull)
				whereSql += "[FollowAsOfficerRoleID] IS NULL";
			else
				whereSql += "[FollowAsOfficerRoleID]=" + CreateSqlParameterName("FollowAsOfficerRoleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!followAsOfficerRoleIDNull)
				AddParameter(cmd, "FollowAsOfficerRoleID", followAsOfficerRoleID);
			return cmd;
		}
		protected CaseApplicantOpinionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseApplicantOpinionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseApplicantOpinionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int officerRoleIDColumnIndex = reader.GetOrdinal("OfficerRoleID");
			int isAppealColumnIndex = reader.GetOrdinal("IsAppeal");
			int termIDColumnIndex = reader.GetOrdinal("TermID");
			int isFinalApprovedColumnIndex = reader.GetOrdinal("IsFinalApproved");
			int opinionIDColumnIndex = reader.GetOrdinal("OpinionID");
			int additionalOpinionColumnIndex = reader.GetOrdinal("AdditionalOpinion");
			int commentColumnIndex = reader.GetOrdinal("Comment");
			int shortCommentColumnIndex = reader.GetOrdinal("ShortComment");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
			int issueDateColumnIndex = reader.GetOrdinal("IssueDate");
			int completeDateColumnIndex = reader.GetOrdinal("CompleteDate");
			int isAgreeColumnIndex = reader.GetOrdinal("IsAgree");
			int followAsOfficerRoleIDColumnIndex = reader.GetOrdinal("FollowAsOfficerRoleID");
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
					CaseApplicantOpinionRow record = new CaseApplicantOpinionRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.OfficerRoleID =  Convert.ToInt32(reader.GetValue(officerRoleIDColumnIndex));
					record.IsAppeal =  Convert.ToBoolean(reader.GetValue(isAppealColumnIndex));
					if (!reader.IsDBNull(termIDColumnIndex)) record.TermID =  Convert.ToInt32(reader.GetValue(termIDColumnIndex));

					if (!reader.IsDBNull(isFinalApprovedColumnIndex)) record.IsFinalApproved =  Convert.ToBoolean(reader.GetValue(isFinalApprovedColumnIndex));

					if (!reader.IsDBNull(opinionIDColumnIndex)) record.OpinionID =  Convert.ToInt32(reader.GetValue(opinionIDColumnIndex));

					if (!reader.IsDBNull(additionalOpinionColumnIndex)) record.AdditionalOpinion =  Convert.ToString(reader.GetValue(additionalOpinionColumnIndex));

					if (!reader.IsDBNull(commentColumnIndex)) record.Comment =  Convert.ToString(reader.GetValue(commentColumnIndex));

					if (!reader.IsDBNull(shortCommentColumnIndex)) record.ShortComment =  Convert.ToString(reader.GetValue(shortCommentColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					if (!reader.IsDBNull(issueDateColumnIndex)) record.IssueDate =  Convert.ToDateTime(reader.GetValue(issueDateColumnIndex));

					if (!reader.IsDBNull(completeDateColumnIndex)) record.CompleteDate =  Convert.ToDateTime(reader.GetValue(completeDateColumnIndex));

					if (!reader.IsDBNull(isAgreeColumnIndex)) record.IsAgree =  Convert.ToBoolean(reader.GetValue(isAgreeColumnIndex));

					if (!reader.IsDBNull(followAsOfficerRoleIDColumnIndex)) record.FollowAsOfficerRoleID =  Convert.ToInt32(reader.GetValue(followAsOfficerRoleIDColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseApplicantOpinionRow[])(recordList.ToArray(typeof(CaseApplicantOpinionRow)));
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
				case "OfficerRoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsAppeal":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "TermID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsFinalApproved":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "OpinionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AdditionalOpinion":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Comment":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ShortComment":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IssueDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "CompleteDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "IsAgree":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "FollowAsOfficerRoleID":
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

