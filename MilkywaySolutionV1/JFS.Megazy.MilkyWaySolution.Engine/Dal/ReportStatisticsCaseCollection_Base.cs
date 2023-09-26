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
	public partial class ReportStatisticsCaseCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string GenderColumnName = "Gender";
		public const string JFCaseNoColumnName = "JFCaseNo";
		public const string SubjectColumnName = "Subject";
		public const string RegisterDateColumnName = "RegisterDate";
		public const string QTColumnName = "QT";
		public const string YYYYColumnName = "YYYY";
		public const string ThaiQuarterColumnName = "ThaiQuarter";
		public const string ThaiFiscalYearColumnName = "ThaiFiscalYear";
		public const string MMColumnName = "MM";
		public const string ThaiMonthColumnName = "ThaiMonth";
		public const string MeetingDateColumnName = "MeetingDate";
		public const string IsAdditionalColumnName = "IsAdditional";
		public const string IsReviewColumnName = "IsReview";
		public const string JFCaseTypeIDColumnName = "JFCaseTypeID";
		public const string CaseTypeNameAbbrColumnName = "CaseTypeNameAbbr";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string StatusIDColumnName = "StatusID";
		public const string CaseApplicationStatusNameColumnName = "CaseApplicationStatusName";
		public const string WorkStepIDColumnName = "WorkStepID";
		public const string WorkStepNameColumnName = "WorkStepName";
		public const string Step1ColumnName = "Step1";
		public const string Step2ColumnName = "Step2";
		public const string Step3ColumnName = "Step3";
		public const string Step4ColumnName = "Step4";
		public const string Step5ColumnName = "Step5";
		public const string Step6ColumnName = "Step6";
		public const string Step7ColumnName = "Step7";
		public const string Step8ColumnName = "Step8";
		public const string Step9ColumnName = "Step9";
		public const string Step10ColumnName = "Step10";
		public const string Step11ColumnName = "Step11";
		public const string Step12ColumnName = "Step12";
		public const string Step13ColumnName = "Step13";
		public const string OpinionIDColumnName = "OpinionID";
		public const string OpinionNameColumnName = "OpinionName";
		public const string OfficerRoleIDColumnName = "OfficerRoleID";
		public const string OfficerRoleNameColumnName = "OfficerRoleName";
		public const string IsPayColumnName = "IsPay";
		public const string IsAppealColumnName = "IsAppeal";
		public const string RegionIDColumnName = "RegionID";
		public const string RegionNameColumnName = "RegionName";
		public const string LawyerIDColumnName = "LawyerID";
		public const string LawyerNameColumnName = "LawyerName";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string ReferenceMSCCODEColumnName = "ReferenceMSCCODE";
		public const string DeletedFlagColumnName = "DeletedFlag";
		private int _processID;
		public SqlCommand cmd = null;
		public ReportStatisticsCaseCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ReportStatisticsCaseRow[] GetAll()
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
			"[DepartmentID],"+
			"[FirstName],"+
			"[LastName],"+
			"[Gender],"+
			"[JFCaseNo],"+
			"[Subject],"+
			"[RegisterDate],"+
			"[QT],"+
			"[YYYY],"+
			"[ThaiQuarter],"+
			"[ThaiFiscalYear],"+
			"[MM],"+
			"[ThaiMonth],"+
			"[MeetingDate],"+
			"[IsAdditional],"+
			"[IsReview],"+
			"[JFCaseTypeID],"+
			"[CaseTypeNameAbbr],"+
			"[DepartmentName],"+
			"[StatusID],"+
			"[CaseApplicationStatusName],"+
			"[WorkStepID],"+
			"[WorkStepName],"+
			"[Step1],"+
			"[Step2],"+
			"[Step3],"+
			"[Step4],"+
			"[Step5],"+
			"[Step6],"+
			"[Step7],"+
			"[Step8],"+
			"[Step9],"+
			"[Step10],"+
			"[Step11],"+
			"[Step12],"+
			"[Step13],"+
			"[OpinionID],"+
			"[OpinionName],"+
			"[OfficerRoleID],"+
			"[OfficerRoleName],"+
			"[IsPay],"+
			"[IsAppeal],"+
			"[RegionID],"+
			"[RegionName],"+
			"[LawyerID],"+
			"[LawyerName],"+
			"[ProvinceID],"+
			"[ProvinceName],"+
			"[ReferenceMSCCODE],"+
			"[DeletedFlag]"+
			" FROM [dbo].[ReportStatisticsCase]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ReportStatisticsCase]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ReportStatisticsCase"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("JFCaseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("RegisterDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("QT",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("YYYY",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ThaiQuarter",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ThaiFiscalYear",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("MM",Type.GetType("System.String"));
			dataColumn.MaxLength = 2;
			dataColumn = dataTable.Columns.Add("ThaiMonth",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("MeetingDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("IsAdditional",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsReview",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("JFCaseTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseTypeNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("StatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CaseApplicationStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("WorkStepID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("WorkStepName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Step1",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step2",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step3",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step4",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step5",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step6",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step7",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step8",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step9",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step10",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step11",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step12",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Step13",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("OpinionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("OpinionName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OfficerRoleID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("OfficerRoleName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsPay",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsAppeal",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RegionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RegionName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LawyerID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("LawyerName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ReferenceMSCCODE",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("DeletedFlag",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public ReportStatisticsCaseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ReportStatisticsCaseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ReportStatisticsCaseRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ReportStatisticsCaseRow"/> objects.</returns>
		public virtual ReportStatisticsCaseRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ReportStatisticsCase]", top);
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
		public ReportStatisticsCaseRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ReportStatisticsCaseRow[] rows = null;
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
		public DataTable GetReportStatisticsCasePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[ReportStatisticsCase] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,ApplicantID,DepartmentID,FirstName,LastName,Gender,JFCaseNo,Subject,RegisterDate,QT,YYYY,ThaiQuarter,ThaiFiscalYear,MM,ThaiMonth,MeetingDate,IsAdditional,IsReview,JFCaseTypeID,CaseTypeNameAbbr,DepartmentName,StatusID,CaseApplicationStatusName,WorkStepID,WorkStepName,Step1,Step2,Step3,Step4,Step5,Step6,Step7,Step8,Step9,Step10,Step11,Step12,Step13,OpinionID,OpinionName,OfficerRoleID,OfficerRoleName,IsPay,IsAppeal,RegionID,RegionName,LawyerID,LawyerName,ProvinceID,ProvinceName,ReferenceMSCCODE,DeletedFlag," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [ReportStatisticsCase].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ReportStatisticsCase] " + whereSql +
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
		public ReportStatisticsCaseItemsPaging GetReportStatisticsCasePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		ReportStatisticsCaseItemsPaging obj = new ReportStatisticsCaseItemsPaging();
		DataTable dt = GetReportStatisticsCasePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ReportStatisticsCaseItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ReportStatisticsCaseItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.JFCaseNo = dt.Rows[i]["JFCaseNo"].ToString();
			record.Subject = dt.Rows[i]["Subject"].ToString();
			if (dt.Rows[i]["RegisterDate"] != DBNull.Value)
			record.RegisterDate = Convert.ToDateTime(dt.Rows[i]["RegisterDate"]);
			if (dt.Rows[i]["QT"] != DBNull.Value)
			record.QT = Convert.ToInt32(dt.Rows[i]["QT"]);
			if (dt.Rows[i]["YYYY"] != DBNull.Value)
			record.YYYY = Convert.ToInt32(dt.Rows[i]["YYYY"]);
			if (dt.Rows[i]["ThaiQuarter"] != DBNull.Value)
			record.ThaiQuarter = Convert.ToInt32(dt.Rows[i]["ThaiQuarter"]);
			if (dt.Rows[i]["ThaiFiscalYear"] != DBNull.Value)
			record.ThaiFiscalYear = Convert.ToInt32(dt.Rows[i]["ThaiFiscalYear"]);
			record.MM = dt.Rows[i]["MM"].ToString();
			record.ThaiMonth = dt.Rows[i]["ThaiMonth"].ToString();
			if (dt.Rows[i]["MeetingDate"] != DBNull.Value)
			record.MeetingDate = Convert.ToDateTime(dt.Rows[i]["MeetingDate"]);
			record.IsAdditional = Convert.ToBoolean(dt.Rows[i]["IsAdditional"]);
			record.IsReview = Convert.ToBoolean(dt.Rows[i]["IsReview"]);
			record.JFCaseTypeID = Convert.ToInt32(dt.Rows[i]["JFCaseTypeID"]);
			record.CaseTypeNameAbbr = dt.Rows[i]["CaseTypeNameAbbr"].ToString();
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			if (dt.Rows[i]["StatusID"] != DBNull.Value)
			record.StatusID = Convert.ToInt32(dt.Rows[i]["StatusID"]);
			record.CaseApplicationStatusName = dt.Rows[i]["CaseApplicationStatusName"].ToString();
			if (dt.Rows[i]["WorkStepID"] != DBNull.Value)
			record.WorkStepID = Convert.ToInt32(dt.Rows[i]["WorkStepID"]);
			record.WorkStepName = dt.Rows[i]["WorkStepName"].ToString();
			if (dt.Rows[i]["Step1"] != DBNull.Value)
			record.Step1 = Convert.ToDateTime(dt.Rows[i]["Step1"]);
			if (dt.Rows[i]["Step2"] != DBNull.Value)
			record.Step2 = Convert.ToDateTime(dt.Rows[i]["Step2"]);
			if (dt.Rows[i]["Step3"] != DBNull.Value)
			record.Step3 = Convert.ToDateTime(dt.Rows[i]["Step3"]);
			if (dt.Rows[i]["Step4"] != DBNull.Value)
			record.Step4 = Convert.ToDateTime(dt.Rows[i]["Step4"]);
			if (dt.Rows[i]["Step5"] != DBNull.Value)
			record.Step5 = Convert.ToDateTime(dt.Rows[i]["Step5"]);
			if (dt.Rows[i]["Step6"] != DBNull.Value)
			record.Step6 = Convert.ToDateTime(dt.Rows[i]["Step6"]);
			if (dt.Rows[i]["Step7"] != DBNull.Value)
			record.Step7 = Convert.ToDateTime(dt.Rows[i]["Step7"]);
			if (dt.Rows[i]["Step8"] != DBNull.Value)
			record.Step8 = Convert.ToDateTime(dt.Rows[i]["Step8"]);
			if (dt.Rows[i]["Step9"] != DBNull.Value)
			record.Step9 = Convert.ToDateTime(dt.Rows[i]["Step9"]);
			if (dt.Rows[i]["Step10"] != DBNull.Value)
			record.Step10 = Convert.ToDateTime(dt.Rows[i]["Step10"]);
			if (dt.Rows[i]["Step11"] != DBNull.Value)
			record.Step11 = Convert.ToDateTime(dt.Rows[i]["Step11"]);
			if (dt.Rows[i]["Step12"] != DBNull.Value)
			record.Step12 = Convert.ToDateTime(dt.Rows[i]["Step12"]);
			if (dt.Rows[i]["Step13"] != DBNull.Value)
			record.Step13 = Convert.ToDateTime(dt.Rows[i]["Step13"]);
			if (dt.Rows[i]["OpinionID"] != DBNull.Value)
			record.OpinionID = Convert.ToInt32(dt.Rows[i]["OpinionID"]);
			record.OpinionName = dt.Rows[i]["OpinionName"].ToString();
			if (dt.Rows[i]["OfficerRoleID"] != DBNull.Value)
			record.OfficerRoleID = Convert.ToInt32(dt.Rows[i]["OfficerRoleID"]);
			record.OfficerRoleName = dt.Rows[i]["OfficerRoleName"].ToString();
			record.IsPay = Convert.ToBoolean(dt.Rows[i]["IsPay"]);
			record.IsAppeal = Convert.ToBoolean(dt.Rows[i]["IsAppeal"]);
			if (dt.Rows[i]["RegionID"] != DBNull.Value)
			record.RegionID = Convert.ToInt32(dt.Rows[i]["RegionID"]);
			record.RegionName = dt.Rows[i]["RegionName"].ToString();
			if (dt.Rows[i]["LawyerID"] != DBNull.Value)
			record.LawyerID = Convert.ToInt32(dt.Rows[i]["LawyerID"]);
			record.LawyerName = dt.Rows[i]["LawyerName"].ToString();
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			record.ReferenceMSCCODE = dt.Rows[i]["ReferenceMSCCODE"].ToString();
			record.DeletedFlag = Convert.ToBoolean(dt.Rows[i]["DeletedFlag"]);
			recordList.Add(record);
		}
		obj.reportStatisticsCaseItems = (ReportStatisticsCaseItems[])(recordList.ToArray(typeof(ReportStatisticsCaseItems)));
		return obj;
		}
		/// <summary>
		/// เรียกข้อมูลจำนวนเรคคอร์ดโดย Column
		/// </summary>
		/// <param name="sqlParameter"></param>
		/// <param name="whereSql">ID = 1</param>
		/// <returns></returns>
		public int GetCountByColumnName(List<SqlParameter> sqlParameter, string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SqlCommand command = CreateCountCommand(whereSql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return (Int32)cmd.ExecuteScalar();
		}
		protected virtual SqlCommand CreateCountCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql =  "SELECT "+
			" COUNT(*)" +
			" FROM [dbo].[ReportStatisticsCase]"; 
			if (null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql; 
			 return CreateCommand(sql); 
		}
		public ReportStatisticsCaseRow GetByPrimaryKey(int caseID, int applicantID, int departmentId)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "DepartmentID", departmentId);
			ReportStatisticsCaseRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ReportStatisticsCaseRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ReportStatisticsCase] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[Gender], " + 
			"[JFCaseNo], " + 
			"[Subject], " + 
			"[RegisterDate], " + 
			"[QT], " + 
			"[YYYY], " + 
			"[ThaiQuarter], " + 
			"[ThaiFiscalYear], " + 
			"[MM], " + 
			"[ThaiMonth], " + 
			"[MeetingDate], " + 
			"[IsAdditional], " + 
			"[IsReview], " + 
			"[JFCaseTypeID], " + 
			"[CaseTypeNameAbbr], " + 
			"[DepartmentName], " + 
			"[StatusID], " + 
			"[CaseApplicationStatusName], " + 
			"[WorkStepID], " + 
			"[WorkStepName], " + 
			"[Step1], " + 
			"[Step2], " + 
			"[Step3], " + 
			"[Step4], " + 
			"[Step5], " + 
			"[Step6], " + 
			"[Step7], " + 
			"[Step8], " + 
			"[Step9], " + 
			"[Step10], " + 
			"[Step11], " + 
			"[Step12], " + 
			"[Step13], " + 
			"[OpinionID], " + 
			"[OpinionName], " + 
			"[OfficerRoleID], " + 
			"[OfficerRoleName], " + 
			"[IsPay], " + 
			"[IsAppeal], " + 
			"[RegionID], " + 
			"[RegionName], " + 
			"[LawyerID], " + 
			"[LawyerName], " + 
			"[ProvinceID], " + 
			"[ProvinceName], " + 
			"[ReferenceMSCCODE], " + 
			"[DeletedFlag]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("JFCaseNo") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("RegisterDate") + ", " +
			CreateSqlParameterName("QT") + ", " +
			CreateSqlParameterName("YYYY") + ", " +
			CreateSqlParameterName("ThaiQuarter") + ", " +
			CreateSqlParameterName("ThaiFiscalYear") + ", " +
			CreateSqlParameterName("MM") + ", " +
			CreateSqlParameterName("ThaiMonth") + ", " +
			CreateSqlParameterName("MeetingDate") + ", " +
			CreateSqlParameterName("IsAdditional") + ", " +
			CreateSqlParameterName("IsReview") + ", " +
			CreateSqlParameterName("JFCaseTypeID") + ", " +
			CreateSqlParameterName("CaseTypeNameAbbr") + ", " +
			CreateSqlParameterName("DepartmentName") + ", " +
			CreateSqlParameterName("StatusID") + ", " +
			CreateSqlParameterName("CaseApplicationStatusName") + ", " +
			CreateSqlParameterName("WorkStepID") + ", " +
			CreateSqlParameterName("WorkStepName") + ", " +
			CreateSqlParameterName("Step1") + ", " +
			CreateSqlParameterName("Step2") + ", " +
			CreateSqlParameterName("Step3") + ", " +
			CreateSqlParameterName("Step4") + ", " +
			CreateSqlParameterName("Step5") + ", " +
			CreateSqlParameterName("Step6") + ", " +
			CreateSqlParameterName("Step7") + ", " +
			CreateSqlParameterName("Step8") + ", " +
			CreateSqlParameterName("Step9") + ", " +
			CreateSqlParameterName("Step10") + ", " +
			CreateSqlParameterName("Step11") + ", " +
			CreateSqlParameterName("Step12") + ", " +
			CreateSqlParameterName("Step13") + ", " +
			CreateSqlParameterName("OpinionID") + ", " +
			CreateSqlParameterName("OpinionName") + ", " +
			CreateSqlParameterName("OfficerRoleID") + ", " +
			CreateSqlParameterName("OfficerRoleName") + ", " +
			CreateSqlParameterName("IsPay") + ", " +
			CreateSqlParameterName("IsAppeal") + ", " +
			CreateSqlParameterName("RegionID") + ", " +
			CreateSqlParameterName("RegionName") + ", " +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("LawyerName") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("ProvinceName") + ", " +
			CreateSqlParameterName("ReferenceMSCCODE") + ", " +
			CreateSqlParameterName("DeletedFlag") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "FirstName", value.FirstName);
			AddParameter(cmd, "LastName", value.LastName);
			AddParameter(cmd, "Gender", value.Gender);
			AddParameter(cmd, "JFCaseNo", value.JFCaseNo);
			AddParameter(cmd, "Subject", value.Subject);
			AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
			AddParameter(cmd, "QT", value.IsQTNull ? DBNull.Value : (object)value.QT);
			AddParameter(cmd, "YYYY", value.IsYYYYNull ? DBNull.Value : (object)value.YYYY);
			AddParameter(cmd, "ThaiQuarter", value.IsThaiQuarterNull ? DBNull.Value : (object)value.ThaiQuarter);
			AddParameter(cmd, "ThaiFiscalYear", value.IsThaiFiscalYearNull ? DBNull.Value : (object)value.ThaiFiscalYear);
			AddParameter(cmd, "MM", value.MM);
			AddParameter(cmd, "ThaiMonth", value.ThaiMonth);
			AddParameter(cmd, "MeetingDate", value.IsMeetingDateNull ? DBNull.Value : (object)value.MeetingDate);
			AddParameter(cmd, "IsAdditional", value.IsAdditional);
			AddParameter(cmd, "IsReview", value.IsReview);
			AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
			AddParameter(cmd, "CaseTypeNameAbbr", value.CaseTypeNameAbbr);
			AddParameter(cmd, "DepartmentName", value.DepartmentName);
			AddParameter(cmd, "StatusID", value.IsStatusIDNull ? DBNull.Value : (object)value.StatusID);
			AddParameter(cmd, "CaseApplicationStatusName", value.CaseApplicationStatusName);
			AddParameter(cmd, "WorkStepID", value.IsWorkStepIDNull ? DBNull.Value : (object)value.WorkStepID);
			AddParameter(cmd, "WorkStepName", value.WorkStepName);
			AddParameter(cmd, "Step1", value.IsStep1Null ? DBNull.Value : (object)value.Step1);
			AddParameter(cmd, "Step2", value.IsStep2Null ? DBNull.Value : (object)value.Step2);
			AddParameter(cmd, "Step3", value.IsStep3Null ? DBNull.Value : (object)value.Step3);
			AddParameter(cmd, "Step4", value.IsStep4Null ? DBNull.Value : (object)value.Step4);
			AddParameter(cmd, "Step5", value.IsStep5Null ? DBNull.Value : (object)value.Step5);
			AddParameter(cmd, "Step6", value.IsStep6Null ? DBNull.Value : (object)value.Step6);
			AddParameter(cmd, "Step7", value.IsStep7Null ? DBNull.Value : (object)value.Step7);
			AddParameter(cmd, "Step8", value.IsStep8Null ? DBNull.Value : (object)value.Step8);
			AddParameter(cmd, "Step9", value.IsStep9Null ? DBNull.Value : (object)value.Step9);
			AddParameter(cmd, "Step10", value.IsStep10Null ? DBNull.Value : (object)value.Step10);
			AddParameter(cmd, "Step11", value.IsStep11Null ? DBNull.Value : (object)value.Step11);
			AddParameter(cmd, "Step12", value.IsStep12Null ? DBNull.Value : (object)value.Step12);
			AddParameter(cmd, "Step13", value.IsStep13Null ? DBNull.Value : (object)value.Step13);
			AddParameter(cmd, "OpinionID", value.IsOpinionIDNull ? DBNull.Value : (object)value.OpinionID);
			AddParameter(cmd, "OpinionName", value.OpinionName);
			AddParameter(cmd, "OfficerRoleID", value.IsOfficerRoleIDNull ? DBNull.Value : (object)value.OfficerRoleID);
			AddParameter(cmd, "OfficerRoleName", value.OfficerRoleName);
			AddParameter(cmd, "IsPay", value.IsPay);
			AddParameter(cmd, "IsAppeal", value.IsAppeal);
			AddParameter(cmd, "RegionID", value.IsRegionIDNull ? DBNull.Value : (object)value.RegionID);
			AddParameter(cmd, "RegionName", value.RegionName);
			AddParameter(cmd, "LawyerID", value.IsLawyerIDNull ? DBNull.Value : (object)value.LawyerID);
			AddParameter(cmd, "LawyerName", value.LawyerName);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "ProvinceName", value.ProvinceName);
			AddParameter(cmd, "ReferenceMSCCODE", value.ReferenceMSCCODE);
			AddParameter(cmd, "DeletedFlag", value.DeletedFlag);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ReportStatisticsCaseRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ReportStatisticsCase] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[Gender], " + 
			"[JFCaseNo], " + 
			"[Subject], " + 
			"[RegisterDate], " + 
			"[QT], " + 
			"[YYYY], " + 
			"[ThaiQuarter], " + 
			"[ThaiFiscalYear], " + 
			"[MM], " + 
			"[ThaiMonth], " + 
			"[MeetingDate], " + 
			"[IsAdditional], " + 
			"[IsReview], " + 
			"[JFCaseTypeID], " + 
			"[CaseTypeNameAbbr], " + 
			"[DepartmentName], " + 
			"[StatusID], " + 
			"[CaseApplicationStatusName], " + 
			"[WorkStepID], " + 
			"[WorkStepName], " + 
			"[Step1], " + 
			"[Step2], " + 
			"[Step3], " + 
			"[Step4], " + 
			"[Step5], " + 
			"[Step6], " + 
			"[Step7], " + 
			"[Step8], " + 
			"[Step9], " + 
			"[Step10], " + 
			"[Step11], " + 
			"[Step12], " + 
			"[Step13], " + 
			"[OpinionID], " + 
			"[OpinionName], " + 
			"[OfficerRoleID], " + 
			"[OfficerRoleName], " + 
			"[IsPay], " + 
			"[IsAppeal], " + 
			"[RegionID], " + 
			"[RegionName], " + 
			"[LawyerID], " + 
			"[LawyerName], " + 
			"[ProvinceID], " + 
			"[ProvinceName], " + 
			"[ReferenceMSCCODE], " + 
			"[DeletedFlag]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("JFCaseNo") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("RegisterDate") + ", " +
			CreateSqlParameterName("QT") + ", " +
			CreateSqlParameterName("YYYY") + ", " +
			CreateSqlParameterName("ThaiQuarter") + ", " +
			CreateSqlParameterName("ThaiFiscalYear") + ", " +
			CreateSqlParameterName("MM") + ", " +
			CreateSqlParameterName("ThaiMonth") + ", " +
			CreateSqlParameterName("MeetingDate") + ", " +
			CreateSqlParameterName("IsAdditional") + ", " +
			CreateSqlParameterName("IsReview") + ", " +
			CreateSqlParameterName("JFCaseTypeID") + ", " +
			CreateSqlParameterName("CaseTypeNameAbbr") + ", " +
			CreateSqlParameterName("DepartmentName") + ", " +
			CreateSqlParameterName("StatusID") + ", " +
			CreateSqlParameterName("CaseApplicationStatusName") + ", " +
			CreateSqlParameterName("WorkStepID") + ", " +
			CreateSqlParameterName("WorkStepName") + ", " +
			CreateSqlParameterName("Step1") + ", " +
			CreateSqlParameterName("Step2") + ", " +
			CreateSqlParameterName("Step3") + ", " +
			CreateSqlParameterName("Step4") + ", " +
			CreateSqlParameterName("Step5") + ", " +
			CreateSqlParameterName("Step6") + ", " +
			CreateSqlParameterName("Step7") + ", " +
			CreateSqlParameterName("Step8") + ", " +
			CreateSqlParameterName("Step9") + ", " +
			CreateSqlParameterName("Step10") + ", " +
			CreateSqlParameterName("Step11") + ", " +
			CreateSqlParameterName("Step12") + ", " +
			CreateSqlParameterName("Step13") + ", " +
			CreateSqlParameterName("OpinionID") + ", " +
			CreateSqlParameterName("OpinionName") + ", " +
			CreateSqlParameterName("OfficerRoleID") + ", " +
			CreateSqlParameterName("OfficerRoleName") + ", " +
			CreateSqlParameterName("IsPay") + ", " +
			CreateSqlParameterName("IsAppeal") + ", " +
			CreateSqlParameterName("RegionID") + ", " +
			CreateSqlParameterName("RegionName") + ", " +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("LawyerName") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("ProvinceName") + ", " +
			CreateSqlParameterName("ReferenceMSCCODE") + ", " +
			CreateSqlParameterName("DeletedFlag") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
			AddParameter(cmd, "JFCaseNo", Sanitizer.GetSafeHtmlFragment(value.JFCaseNo));
			AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
			AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
			AddParameter(cmd, "QT", value.IsQTNull ? DBNull.Value : (object)value.QT);
			AddParameter(cmd, "YYYY", value.IsYYYYNull ? DBNull.Value : (object)value.YYYY);
			AddParameter(cmd, "ThaiQuarter", value.IsThaiQuarterNull ? DBNull.Value : (object)value.ThaiQuarter);
			AddParameter(cmd, "ThaiFiscalYear", value.IsThaiFiscalYearNull ? DBNull.Value : (object)value.ThaiFiscalYear);
			AddParameter(cmd, "MM", Sanitizer.GetSafeHtmlFragment(value.MM));
			AddParameter(cmd, "ThaiMonth", Sanitizer.GetSafeHtmlFragment(value.ThaiMonth));
			AddParameter(cmd, "MeetingDate", value.IsMeetingDateNull ? DBNull.Value : (object)value.MeetingDate);
			AddParameter(cmd, "IsAdditional", value.IsAdditional);
			AddParameter(cmd, "IsReview", value.IsReview);
			AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
			AddParameter(cmd, "CaseTypeNameAbbr", Sanitizer.GetSafeHtmlFragment(value.CaseTypeNameAbbr));
			AddParameter(cmd, "DepartmentName", Sanitizer.GetSafeHtmlFragment(value.DepartmentName));
			AddParameter(cmd, "StatusID", value.IsStatusIDNull ? DBNull.Value : (object)value.StatusID);
			AddParameter(cmd, "CaseApplicationStatusName", Sanitizer.GetSafeHtmlFragment(value.CaseApplicationStatusName));
			AddParameter(cmd, "WorkStepID", value.IsWorkStepIDNull ? DBNull.Value : (object)value.WorkStepID);
			AddParameter(cmd, "WorkStepName", Sanitizer.GetSafeHtmlFragment(value.WorkStepName));
			AddParameter(cmd, "Step1", value.IsStep1Null ? DBNull.Value : (object)value.Step1);
			AddParameter(cmd, "Step2", value.IsStep2Null ? DBNull.Value : (object)value.Step2);
			AddParameter(cmd, "Step3", value.IsStep3Null ? DBNull.Value : (object)value.Step3);
			AddParameter(cmd, "Step4", value.IsStep4Null ? DBNull.Value : (object)value.Step4);
			AddParameter(cmd, "Step5", value.IsStep5Null ? DBNull.Value : (object)value.Step5);
			AddParameter(cmd, "Step6", value.IsStep6Null ? DBNull.Value : (object)value.Step6);
			AddParameter(cmd, "Step7", value.IsStep7Null ? DBNull.Value : (object)value.Step7);
			AddParameter(cmd, "Step8", value.IsStep8Null ? DBNull.Value : (object)value.Step8);
			AddParameter(cmd, "Step9", value.IsStep9Null ? DBNull.Value : (object)value.Step9);
			AddParameter(cmd, "Step10", value.IsStep10Null ? DBNull.Value : (object)value.Step10);
			AddParameter(cmd, "Step11", value.IsStep11Null ? DBNull.Value : (object)value.Step11);
			AddParameter(cmd, "Step12", value.IsStep12Null ? DBNull.Value : (object)value.Step12);
			AddParameter(cmd, "Step13", value.IsStep13Null ? DBNull.Value : (object)value.Step13);
			AddParameter(cmd, "OpinionID", value.IsOpinionIDNull ? DBNull.Value : (object)value.OpinionID);
			AddParameter(cmd, "OpinionName", Sanitizer.GetSafeHtmlFragment(value.OpinionName));
			AddParameter(cmd, "OfficerRoleID", value.IsOfficerRoleIDNull ? DBNull.Value : (object)value.OfficerRoleID);
			AddParameter(cmd, "OfficerRoleName", Sanitizer.GetSafeHtmlFragment(value.OfficerRoleName));
			AddParameter(cmd, "IsPay", value.IsPay);
			AddParameter(cmd, "IsAppeal", value.IsAppeal);
			AddParameter(cmd, "RegionID", value.IsRegionIDNull ? DBNull.Value : (object)value.RegionID);
			AddParameter(cmd, "RegionName", Sanitizer.GetSafeHtmlFragment(value.RegionName));
			AddParameter(cmd, "LawyerID", value.IsLawyerIDNull ? DBNull.Value : (object)value.LawyerID);
			AddParameter(cmd, "LawyerName", Sanitizer.GetSafeHtmlFragment(value.LawyerName));
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "ProvinceName", Sanitizer.GetSafeHtmlFragment(value.ProvinceName));
			AddParameter(cmd, "ReferenceMSCCODE", Sanitizer.GetSafeHtmlFragment(value.ReferenceMSCCODE));
			AddParameter(cmd, "DeletedFlag", value.DeletedFlag);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ReportStatisticsCaseRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetApplicantID == true && value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetJFCaseNo)
				{
					strUpdate += "[JFCaseNo]=" + CreateSqlParameterName("JFCaseNo") + ",";
				}
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetRegisterDate)
				{
					strUpdate += "[RegisterDate]=" + CreateSqlParameterName("RegisterDate") + ",";
				}
				if (value._IsSetQT)
				{
					strUpdate += "[QT]=" + CreateSqlParameterName("QT") + ",";
				}
				if (value._IsSetYYYY)
				{
					strUpdate += "[YYYY]=" + CreateSqlParameterName("YYYY") + ",";
				}
				if (value._IsSetThaiQuarter)
				{
					strUpdate += "[ThaiQuarter]=" + CreateSqlParameterName("ThaiQuarter") + ",";
				}
				if (value._IsSetThaiFiscalYear)
				{
					strUpdate += "[ThaiFiscalYear]=" + CreateSqlParameterName("ThaiFiscalYear") + ",";
				}
				if (value._IsSetMM)
				{
					strUpdate += "[MM]=" + CreateSqlParameterName("MM") + ",";
				}
				if (value._IsSetThaiMonth)
				{
					strUpdate += "[ThaiMonth]=" + CreateSqlParameterName("ThaiMonth") + ",";
				}
				if (value._IsSetMeetingDate)
				{
					strUpdate += "[MeetingDate]=" + CreateSqlParameterName("MeetingDate") + ",";
				}
				if (value._IsSetIsAdditional)
				{
					strUpdate += "[IsAdditional]=" + CreateSqlParameterName("IsAdditional") + ",";
				}
				if (value._IsSetIsReview)
				{
					strUpdate += "[IsReview]=" + CreateSqlParameterName("IsReview") + ",";
				}
				if (value._IsSetJFCaseTypeID)
				{
					strUpdate += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID") + ",";
				}
				if (value._IsSetCaseTypeNameAbbr)
				{
					strUpdate += "[CaseTypeNameAbbr]=" + CreateSqlParameterName("CaseTypeNameAbbr") + ",";
				}
				if (value._IsSetDepartmentName)
				{
					strUpdate += "[DepartmentName]=" + CreateSqlParameterName("DepartmentName") + ",";
				}
				if (value._IsSetStatusID)
				{
					strUpdate += "[StatusID]=" + CreateSqlParameterName("StatusID") + ",";
				}
				if (value._IsSetCaseApplicationStatusName)
				{
					strUpdate += "[CaseApplicationStatusName]=" + CreateSqlParameterName("CaseApplicationStatusName") + ",";
				}
				if (value._IsSetWorkStepID)
				{
					strUpdate += "[WorkStepID]=" + CreateSqlParameterName("WorkStepID") + ",";
				}
				if (value._IsSetWorkStepName)
				{
					strUpdate += "[WorkStepName]=" + CreateSqlParameterName("WorkStepName") + ",";
				}
				if (value._IsSetStep1)
				{
					strUpdate += "[Step1]=" + CreateSqlParameterName("Step1") + ",";
				}
				if (value._IsSetStep2)
				{
					strUpdate += "[Step2]=" + CreateSqlParameterName("Step2") + ",";
				}
				if (value._IsSetStep3)
				{
					strUpdate += "[Step3]=" + CreateSqlParameterName("Step3") + ",";
				}
				if (value._IsSetStep4)
				{
					strUpdate += "[Step4]=" + CreateSqlParameterName("Step4") + ",";
				}
				if (value._IsSetStep5)
				{
					strUpdate += "[Step5]=" + CreateSqlParameterName("Step5") + ",";
				}
				if (value._IsSetStep6)
				{
					strUpdate += "[Step6]=" + CreateSqlParameterName("Step6") + ",";
				}
				if (value._IsSetStep7)
				{
					strUpdate += "[Step7]=" + CreateSqlParameterName("Step7") + ",";
				}
				if (value._IsSetStep8)
				{
					strUpdate += "[Step8]=" + CreateSqlParameterName("Step8") + ",";
				}
				if (value._IsSetStep9)
				{
					strUpdate += "[Step9]=" + CreateSqlParameterName("Step9") + ",";
				}
				if (value._IsSetStep10)
				{
					strUpdate += "[Step10]=" + CreateSqlParameterName("Step10") + ",";
				}
				if (value._IsSetStep11)
				{
					strUpdate += "[Step11]=" + CreateSqlParameterName("Step11") + ",";
				}
				if (value._IsSetStep12)
				{
					strUpdate += "[Step12]=" + CreateSqlParameterName("Step12") + ",";
				}
				if (value._IsSetStep13)
				{
					strUpdate += "[Step13]=" + CreateSqlParameterName("Step13") + ",";
				}
				if (value._IsSetOpinionID)
				{
					strUpdate += "[OpinionID]=" + CreateSqlParameterName("OpinionID") + ",";
				}
				if (value._IsSetOpinionName)
				{
					strUpdate += "[OpinionName]=" + CreateSqlParameterName("OpinionName") + ",";
				}
				if (value._IsSetOfficerRoleID)
				{
					strUpdate += "[OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID") + ",";
				}
				if (value._IsSetOfficerRoleName)
				{
					strUpdate += "[OfficerRoleName]=" + CreateSqlParameterName("OfficerRoleName") + ",";
				}
				if (value._IsSetIsPay)
				{
					strUpdate += "[IsPay]=" + CreateSqlParameterName("IsPay") + ",";
				}
				if (value._IsSetIsAppeal)
				{
					strUpdate += "[IsAppeal]=" + CreateSqlParameterName("IsAppeal") + ",";
				}
				if (value._IsSetRegionID)
				{
					strUpdate += "[RegionID]=" + CreateSqlParameterName("RegionID") + ",";
				}
				if (value._IsSetRegionName)
				{
					strUpdate += "[RegionName]=" + CreateSqlParameterName("RegionName") + ",";
				}
				if (value._IsSetLawyerID)
				{
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID") + ",";
				}
				if (value._IsSetLawyerName)
				{
					strUpdate += "[LawyerName]=" + CreateSqlParameterName("LawyerName") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetProvinceName)
				{
					strUpdate += "[ProvinceName]=" + CreateSqlParameterName("ProvinceName") + ",";
				}
				if (value._IsSetReferenceMSCCODE)
				{
					strUpdate += "[ReferenceMSCCODE]=" + CreateSqlParameterName("ReferenceMSCCODE") + ",";
				}
				if (value._IsSetDeletedFlag)
				{
					strUpdate += "[DeletedFlag]=" + CreateSqlParameterName("DeletedFlag") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ReportStatisticsCase] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
					AddParameter(cmd, "Gender", value.Gender);
					AddParameter(cmd, "JFCaseNo", value.JFCaseNo);
					AddParameter(cmd, "Subject", value.Subject);
					AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
					AddParameter(cmd, "QT", value.IsQTNull ? DBNull.Value : (object)value.QT);
					AddParameter(cmd, "YYYY", value.IsYYYYNull ? DBNull.Value : (object)value.YYYY);
					AddParameter(cmd, "ThaiQuarter", value.IsThaiQuarterNull ? DBNull.Value : (object)value.ThaiQuarter);
					AddParameter(cmd, "ThaiFiscalYear", value.IsThaiFiscalYearNull ? DBNull.Value : (object)value.ThaiFiscalYear);
					AddParameter(cmd, "MM", value.MM);
					AddParameter(cmd, "ThaiMonth", value.ThaiMonth);
					AddParameter(cmd, "MeetingDate", value.IsMeetingDateNull ? DBNull.Value : (object)value.MeetingDate);
					AddParameter(cmd, "IsAdditional", value.IsAdditional);
					AddParameter(cmd, "IsReview", value.IsReview);
					AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
					AddParameter(cmd, "CaseTypeNameAbbr", value.CaseTypeNameAbbr);
					AddParameter(cmd, "DepartmentName", value.DepartmentName);
					AddParameter(cmd, "StatusID", value.IsStatusIDNull ? DBNull.Value : (object)value.StatusID);
					AddParameter(cmd, "CaseApplicationStatusName", value.CaseApplicationStatusName);
					AddParameter(cmd, "WorkStepID", value.IsWorkStepIDNull ? DBNull.Value : (object)value.WorkStepID);
					AddParameter(cmd, "WorkStepName", value.WorkStepName);
					AddParameter(cmd, "Step1", value.IsStep1Null ? DBNull.Value : (object)value.Step1);
					AddParameter(cmd, "Step2", value.IsStep2Null ? DBNull.Value : (object)value.Step2);
					AddParameter(cmd, "Step3", value.IsStep3Null ? DBNull.Value : (object)value.Step3);
					AddParameter(cmd, "Step4", value.IsStep4Null ? DBNull.Value : (object)value.Step4);
					AddParameter(cmd, "Step5", value.IsStep5Null ? DBNull.Value : (object)value.Step5);
					AddParameter(cmd, "Step6", value.IsStep6Null ? DBNull.Value : (object)value.Step6);
					AddParameter(cmd, "Step7", value.IsStep7Null ? DBNull.Value : (object)value.Step7);
					AddParameter(cmd, "Step8", value.IsStep8Null ? DBNull.Value : (object)value.Step8);
					AddParameter(cmd, "Step9", value.IsStep9Null ? DBNull.Value : (object)value.Step9);
					AddParameter(cmd, "Step10", value.IsStep10Null ? DBNull.Value : (object)value.Step10);
					AddParameter(cmd, "Step11", value.IsStep11Null ? DBNull.Value : (object)value.Step11);
					AddParameter(cmd, "Step12", value.IsStep12Null ? DBNull.Value : (object)value.Step12);
					AddParameter(cmd, "Step13", value.IsStep13Null ? DBNull.Value : (object)value.Step13);
					AddParameter(cmd, "OpinionID", value.IsOpinionIDNull ? DBNull.Value : (object)value.OpinionID);
					AddParameter(cmd, "OpinionName", value.OpinionName);
					AddParameter(cmd, "OfficerRoleID", value.IsOfficerRoleIDNull ? DBNull.Value : (object)value.OfficerRoleID);
					AddParameter(cmd, "OfficerRoleName", value.OfficerRoleName);
					AddParameter(cmd, "IsPay", value.IsPay);
					AddParameter(cmd, "IsAppeal", value.IsAppeal);
					AddParameter(cmd, "RegionID", value.IsRegionIDNull ? DBNull.Value : (object)value.RegionID);
					AddParameter(cmd, "RegionName", value.RegionName);
					AddParameter(cmd, "LawyerID", value.IsLawyerIDNull ? DBNull.Value : (object)value.LawyerID);
					AddParameter(cmd, "LawyerName", value.LawyerName);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "ProvinceName", value.ProvinceName);
					AddParameter(cmd, "ReferenceMSCCODE", value.ReferenceMSCCODE);
					AddParameter(cmd, "DeletedFlag", value.DeletedFlag);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,ApplicantID,DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ReportStatisticsCaseRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetApplicantID == true && value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetJFCaseNo)
				{
					strUpdate += "[JFCaseNo]=" + CreateSqlParameterName("JFCaseNo") + ",";
				}
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetRegisterDate)
				{
					strUpdate += "[RegisterDate]=" + CreateSqlParameterName("RegisterDate") + ",";
				}
				if (value._IsSetQT)
				{
					strUpdate += "[QT]=" + CreateSqlParameterName("QT") + ",";
				}
				if (value._IsSetYYYY)
				{
					strUpdate += "[YYYY]=" + CreateSqlParameterName("YYYY") + ",";
				}
				if (value._IsSetThaiQuarter)
				{
					strUpdate += "[ThaiQuarter]=" + CreateSqlParameterName("ThaiQuarter") + ",";
				}
				if (value._IsSetThaiFiscalYear)
				{
					strUpdate += "[ThaiFiscalYear]=" + CreateSqlParameterName("ThaiFiscalYear") + ",";
				}
				if (value._IsSetMM)
				{
					strUpdate += "[MM]=" + CreateSqlParameterName("MM") + ",";
				}
				if (value._IsSetThaiMonth)
				{
					strUpdate += "[ThaiMonth]=" + CreateSqlParameterName("ThaiMonth") + ",";
				}
				if (value._IsSetMeetingDate)
				{
					strUpdate += "[MeetingDate]=" + CreateSqlParameterName("MeetingDate") + ",";
				}
				if (value._IsSetIsAdditional)
				{
					strUpdate += "[IsAdditional]=" + CreateSqlParameterName("IsAdditional") + ",";
				}
				if (value._IsSetIsReview)
				{
					strUpdate += "[IsReview]=" + CreateSqlParameterName("IsReview") + ",";
				}
				if (value._IsSetJFCaseTypeID)
				{
					strUpdate += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID") + ",";
				}
				if (value._IsSetCaseTypeNameAbbr)
				{
					strUpdate += "[CaseTypeNameAbbr]=" + CreateSqlParameterName("CaseTypeNameAbbr") + ",";
				}
				if (value._IsSetDepartmentName)
				{
					strUpdate += "[DepartmentName]=" + CreateSqlParameterName("DepartmentName") + ",";
				}
				if (value._IsSetStatusID)
				{
					strUpdate += "[StatusID]=" + CreateSqlParameterName("StatusID") + ",";
				}
				if (value._IsSetCaseApplicationStatusName)
				{
					strUpdate += "[CaseApplicationStatusName]=" + CreateSqlParameterName("CaseApplicationStatusName") + ",";
				}
				if (value._IsSetWorkStepID)
				{
					strUpdate += "[WorkStepID]=" + CreateSqlParameterName("WorkStepID") + ",";
				}
				if (value._IsSetWorkStepName)
				{
					strUpdate += "[WorkStepName]=" + CreateSqlParameterName("WorkStepName") + ",";
				}
				if (value._IsSetStep1)
				{
					strUpdate += "[Step1]=" + CreateSqlParameterName("Step1") + ",";
				}
				if (value._IsSetStep2)
				{
					strUpdate += "[Step2]=" + CreateSqlParameterName("Step2") + ",";
				}
				if (value._IsSetStep3)
				{
					strUpdate += "[Step3]=" + CreateSqlParameterName("Step3") + ",";
				}
				if (value._IsSetStep4)
				{
					strUpdate += "[Step4]=" + CreateSqlParameterName("Step4") + ",";
				}
				if (value._IsSetStep5)
				{
					strUpdate += "[Step5]=" + CreateSqlParameterName("Step5") + ",";
				}
				if (value._IsSetStep6)
				{
					strUpdate += "[Step6]=" + CreateSqlParameterName("Step6") + ",";
				}
				if (value._IsSetStep7)
				{
					strUpdate += "[Step7]=" + CreateSqlParameterName("Step7") + ",";
				}
				if (value._IsSetStep8)
				{
					strUpdate += "[Step8]=" + CreateSqlParameterName("Step8") + ",";
				}
				if (value._IsSetStep9)
				{
					strUpdate += "[Step9]=" + CreateSqlParameterName("Step9") + ",";
				}
				if (value._IsSetStep10)
				{
					strUpdate += "[Step10]=" + CreateSqlParameterName("Step10") + ",";
				}
				if (value._IsSetStep11)
				{
					strUpdate += "[Step11]=" + CreateSqlParameterName("Step11") + ",";
				}
				if (value._IsSetStep12)
				{
					strUpdate += "[Step12]=" + CreateSqlParameterName("Step12") + ",";
				}
				if (value._IsSetStep13)
				{
					strUpdate += "[Step13]=" + CreateSqlParameterName("Step13") + ",";
				}
				if (value._IsSetOpinionID)
				{
					strUpdate += "[OpinionID]=" + CreateSqlParameterName("OpinionID") + ",";
				}
				if (value._IsSetOpinionName)
				{
					strUpdate += "[OpinionName]=" + CreateSqlParameterName("OpinionName") + ",";
				}
				if (value._IsSetOfficerRoleID)
				{
					strUpdate += "[OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID") + ",";
				}
				if (value._IsSetOfficerRoleName)
				{
					strUpdate += "[OfficerRoleName]=" + CreateSqlParameterName("OfficerRoleName") + ",";
				}
				if (value._IsSetIsPay)
				{
					strUpdate += "[IsPay]=" + CreateSqlParameterName("IsPay") + ",";
				}
				if (value._IsSetIsAppeal)
				{
					strUpdate += "[IsAppeal]=" + CreateSqlParameterName("IsAppeal") + ",";
				}
				if (value._IsSetRegionID)
				{
					strUpdate += "[RegionID]=" + CreateSqlParameterName("RegionID") + ",";
				}
				if (value._IsSetRegionName)
				{
					strUpdate += "[RegionName]=" + CreateSqlParameterName("RegionName") + ",";
				}
				if (value._IsSetLawyerID)
				{
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID") + ",";
				}
				if (value._IsSetLawyerName)
				{
					strUpdate += "[LawyerName]=" + CreateSqlParameterName("LawyerName") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetProvinceName)
				{
					strUpdate += "[ProvinceName]=" + CreateSqlParameterName("ProvinceName") + ",";
				}
				if (value._IsSetReferenceMSCCODE)
				{
					strUpdate += "[ReferenceMSCCODE]=" + CreateSqlParameterName("ReferenceMSCCODE") + ",";
				}
				if (value._IsSetDeletedFlag)
				{
					strUpdate += "[DeletedFlag]=" + CreateSqlParameterName("DeletedFlag") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ReportStatisticsCase] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
					AddParameter(cmd, "JFCaseNo", Sanitizer.GetSafeHtmlFragment(value.JFCaseNo));
					AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
					AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
					AddParameter(cmd, "QT", value.IsQTNull ? DBNull.Value : (object)value.QT);
					AddParameter(cmd, "YYYY", value.IsYYYYNull ? DBNull.Value : (object)value.YYYY);
					AddParameter(cmd, "ThaiQuarter", value.IsThaiQuarterNull ? DBNull.Value : (object)value.ThaiQuarter);
					AddParameter(cmd, "ThaiFiscalYear", value.IsThaiFiscalYearNull ? DBNull.Value : (object)value.ThaiFiscalYear);
					AddParameter(cmd, "MM", Sanitizer.GetSafeHtmlFragment(value.MM));
					AddParameter(cmd, "ThaiMonth", Sanitizer.GetSafeHtmlFragment(value.ThaiMonth));
					AddParameter(cmd, "MeetingDate", value.IsMeetingDateNull ? DBNull.Value : (object)value.MeetingDate);
					AddParameter(cmd, "IsAdditional", value.IsAdditional);
					AddParameter(cmd, "IsReview", value.IsReview);
					AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
					AddParameter(cmd, "CaseTypeNameAbbr", Sanitizer.GetSafeHtmlFragment(value.CaseTypeNameAbbr));
					AddParameter(cmd, "DepartmentName", Sanitizer.GetSafeHtmlFragment(value.DepartmentName));
					AddParameter(cmd, "StatusID", value.IsStatusIDNull ? DBNull.Value : (object)value.StatusID);
					AddParameter(cmd, "CaseApplicationStatusName", Sanitizer.GetSafeHtmlFragment(value.CaseApplicationStatusName));
					AddParameter(cmd, "WorkStepID", value.IsWorkStepIDNull ? DBNull.Value : (object)value.WorkStepID);
					AddParameter(cmd, "WorkStepName", Sanitizer.GetSafeHtmlFragment(value.WorkStepName));
					AddParameter(cmd, "Step1", value.IsStep1Null ? DBNull.Value : (object)value.Step1);
					AddParameter(cmd, "Step2", value.IsStep2Null ? DBNull.Value : (object)value.Step2);
					AddParameter(cmd, "Step3", value.IsStep3Null ? DBNull.Value : (object)value.Step3);
					AddParameter(cmd, "Step4", value.IsStep4Null ? DBNull.Value : (object)value.Step4);
					AddParameter(cmd, "Step5", value.IsStep5Null ? DBNull.Value : (object)value.Step5);
					AddParameter(cmd, "Step6", value.IsStep6Null ? DBNull.Value : (object)value.Step6);
					AddParameter(cmd, "Step7", value.IsStep7Null ? DBNull.Value : (object)value.Step7);
					AddParameter(cmd, "Step8", value.IsStep8Null ? DBNull.Value : (object)value.Step8);
					AddParameter(cmd, "Step9", value.IsStep9Null ? DBNull.Value : (object)value.Step9);
					AddParameter(cmd, "Step10", value.IsStep10Null ? DBNull.Value : (object)value.Step10);
					AddParameter(cmd, "Step11", value.IsStep11Null ? DBNull.Value : (object)value.Step11);
					AddParameter(cmd, "Step12", value.IsStep12Null ? DBNull.Value : (object)value.Step12);
					AddParameter(cmd, "Step13", value.IsStep13Null ? DBNull.Value : (object)value.Step13);
					AddParameter(cmd, "OpinionID", value.IsOpinionIDNull ? DBNull.Value : (object)value.OpinionID);
					AddParameter(cmd, "OpinionName", Sanitizer.GetSafeHtmlFragment(value.OpinionName));
					AddParameter(cmd, "OfficerRoleID", value.IsOfficerRoleIDNull ? DBNull.Value : (object)value.OfficerRoleID);
					AddParameter(cmd, "OfficerRoleName", Sanitizer.GetSafeHtmlFragment(value.OfficerRoleName));
					AddParameter(cmd, "IsPay", value.IsPay);
					AddParameter(cmd, "IsAppeal", value.IsAppeal);
					AddParameter(cmd, "RegionID", value.IsRegionIDNull ? DBNull.Value : (object)value.RegionID);
					AddParameter(cmd, "RegionName", Sanitizer.GetSafeHtmlFragment(value.RegionName));
					AddParameter(cmd, "LawyerID", value.IsLawyerIDNull ? DBNull.Value : (object)value.LawyerID);
					AddParameter(cmd, "LawyerName", Sanitizer.GetSafeHtmlFragment(value.LawyerName));
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "ProvinceName", Sanitizer.GetSafeHtmlFragment(value.ProvinceName));
					AddParameter(cmd, "ReferenceMSCCODE", Sanitizer.GetSafeHtmlFragment(value.ReferenceMSCCODE));
					AddParameter(cmd, "DeletedFlag", value.DeletedFlag);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,ApplicantID,DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID, int applicantID, int departmentId)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "DepartmentID", departmentId);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected ReportStatisticsCaseRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ReportStatisticsCaseRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ReportStatisticsCaseRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int jFCaseNoColumnIndex = reader.GetOrdinal("JFCaseNo");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int registerDateColumnIndex = reader.GetOrdinal("RegisterDate");
			int qTColumnIndex = reader.GetOrdinal("QT");
			int yyyyColumnIndex = reader.GetOrdinal("YYYY");
			int thaiQuarterColumnIndex = reader.GetOrdinal("ThaiQuarter");
			int thaiFiscalYearColumnIndex = reader.GetOrdinal("ThaiFiscalYear");
			int mmColumnIndex = reader.GetOrdinal("MM");
			int thaiMonthColumnIndex = reader.GetOrdinal("ThaiMonth");
			int meetingDateColumnIndex = reader.GetOrdinal("MeetingDate");
			int isAdditionalColumnIndex = reader.GetOrdinal("IsAdditional");
			int isReviewColumnIndex = reader.GetOrdinal("IsReview");
			int jFCaseTypeIDColumnIndex = reader.GetOrdinal("JFCaseTypeID");
			int caseTypeNameAbbrColumnIndex = reader.GetOrdinal("CaseTypeNameAbbr");
			int departmentNameColumnIndex = reader.GetOrdinal("DepartmentName");
			int statusIDColumnIndex = reader.GetOrdinal("StatusID");
			int caseApplicationStatusNameColumnIndex = reader.GetOrdinal("CaseApplicationStatusName");
			int workStepIDColumnIndex = reader.GetOrdinal("WorkStepID");
			int workStepNameColumnIndex = reader.GetOrdinal("WorkStepName");
			int step1ColumnIndex = reader.GetOrdinal("Step1");
			int step2ColumnIndex = reader.GetOrdinal("Step2");
			int step3ColumnIndex = reader.GetOrdinal("Step3");
			int step4ColumnIndex = reader.GetOrdinal("Step4");
			int step5ColumnIndex = reader.GetOrdinal("Step5");
			int step6ColumnIndex = reader.GetOrdinal("Step6");
			int step7ColumnIndex = reader.GetOrdinal("Step7");
			int step8ColumnIndex = reader.GetOrdinal("Step8");
			int step9ColumnIndex = reader.GetOrdinal("Step9");
			int step10ColumnIndex = reader.GetOrdinal("Step10");
			int step11ColumnIndex = reader.GetOrdinal("Step11");
			int step12ColumnIndex = reader.GetOrdinal("Step12");
			int step13ColumnIndex = reader.GetOrdinal("Step13");
			int opinionIDColumnIndex = reader.GetOrdinal("OpinionID");
			int opinionNameColumnIndex = reader.GetOrdinal("OpinionName");
			int officerRoleIDColumnIndex = reader.GetOrdinal("OfficerRoleID");
			int officerRoleNameColumnIndex = reader.GetOrdinal("OfficerRoleName");
			int isPayColumnIndex = reader.GetOrdinal("IsPay");
			int isAppealColumnIndex = reader.GetOrdinal("IsAppeal");
			int regionIDColumnIndex = reader.GetOrdinal("RegionID");
			int regionNameColumnIndex = reader.GetOrdinal("RegionName");
			int lawyerIDColumnIndex = reader.GetOrdinal("LawyerID");
			int lawyerNameColumnIndex = reader.GetOrdinal("LawyerName");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int referenceMSCCODEColumnIndex = reader.GetOrdinal("ReferenceMSCCODE");
			int deletedFlagColumnIndex = reader.GetOrdinal("DeletedFlag");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ReportStatisticsCaseRow record = new ReportStatisticsCaseRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(jFCaseNoColumnIndex)) record.JFCaseNo =  Convert.ToString(reader.GetValue(jFCaseNoColumnIndex));

					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					if (!reader.IsDBNull(registerDateColumnIndex)) record.RegisterDate =  Convert.ToDateTime(reader.GetValue(registerDateColumnIndex));

					if (!reader.IsDBNull(qTColumnIndex)) record.QT =  Convert.ToInt32(reader.GetValue(qTColumnIndex));

					if (!reader.IsDBNull(yyyyColumnIndex)) record.YYYY =  Convert.ToInt32(reader.GetValue(yyyyColumnIndex));

					if (!reader.IsDBNull(thaiQuarterColumnIndex)) record.ThaiQuarter =  Convert.ToInt32(reader.GetValue(thaiQuarterColumnIndex));

					if (!reader.IsDBNull(thaiFiscalYearColumnIndex)) record.ThaiFiscalYear =  Convert.ToInt32(reader.GetValue(thaiFiscalYearColumnIndex));

					if (!reader.IsDBNull(mmColumnIndex)) record.MM =  Convert.ToString(reader.GetValue(mmColumnIndex));

					if (!reader.IsDBNull(thaiMonthColumnIndex)) record.ThaiMonth =  Convert.ToString(reader.GetValue(thaiMonthColumnIndex));

					if (!reader.IsDBNull(meetingDateColumnIndex)) record.MeetingDate =  Convert.ToDateTime(reader.GetValue(meetingDateColumnIndex));

					record.IsAdditional =  Convert.ToBoolean(reader.GetValue(isAdditionalColumnIndex));
					record.IsReview =  Convert.ToBoolean(reader.GetValue(isReviewColumnIndex));
					record.JFCaseTypeID =  Convert.ToInt32(reader.GetValue(jFCaseTypeIDColumnIndex));
					if (!reader.IsDBNull(caseTypeNameAbbrColumnIndex)) record.CaseTypeNameAbbr =  Convert.ToString(reader.GetValue(caseTypeNameAbbrColumnIndex));

					if (!reader.IsDBNull(departmentNameColumnIndex)) record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));

					if (!reader.IsDBNull(statusIDColumnIndex)) record.StatusID =  Convert.ToInt32(reader.GetValue(statusIDColumnIndex));

					if (!reader.IsDBNull(caseApplicationStatusNameColumnIndex)) record.CaseApplicationStatusName =  Convert.ToString(reader.GetValue(caseApplicationStatusNameColumnIndex));

					if (!reader.IsDBNull(workStepIDColumnIndex)) record.WorkStepID =  Convert.ToInt32(reader.GetValue(workStepIDColumnIndex));

					if (!reader.IsDBNull(workStepNameColumnIndex)) record.WorkStepName =  Convert.ToString(reader.GetValue(workStepNameColumnIndex));

					if (!reader.IsDBNull(step1ColumnIndex)) record.Step1 =  Convert.ToDateTime(reader.GetValue(step1ColumnIndex));

					if (!reader.IsDBNull(step2ColumnIndex)) record.Step2 =  Convert.ToDateTime(reader.GetValue(step2ColumnIndex));

					if (!reader.IsDBNull(step3ColumnIndex)) record.Step3 =  Convert.ToDateTime(reader.GetValue(step3ColumnIndex));

					if (!reader.IsDBNull(step4ColumnIndex)) record.Step4 =  Convert.ToDateTime(reader.GetValue(step4ColumnIndex));

					if (!reader.IsDBNull(step5ColumnIndex)) record.Step5 =  Convert.ToDateTime(reader.GetValue(step5ColumnIndex));

					if (!reader.IsDBNull(step6ColumnIndex)) record.Step6 =  Convert.ToDateTime(reader.GetValue(step6ColumnIndex));

					if (!reader.IsDBNull(step7ColumnIndex)) record.Step7 =  Convert.ToDateTime(reader.GetValue(step7ColumnIndex));

					if (!reader.IsDBNull(step8ColumnIndex)) record.Step8 =  Convert.ToDateTime(reader.GetValue(step8ColumnIndex));

					if (!reader.IsDBNull(step9ColumnIndex)) record.Step9 =  Convert.ToDateTime(reader.GetValue(step9ColumnIndex));

					if (!reader.IsDBNull(step10ColumnIndex)) record.Step10 =  Convert.ToDateTime(reader.GetValue(step10ColumnIndex));

					if (!reader.IsDBNull(step11ColumnIndex)) record.Step11 =  Convert.ToDateTime(reader.GetValue(step11ColumnIndex));

					if (!reader.IsDBNull(step12ColumnIndex)) record.Step12 =  Convert.ToDateTime(reader.GetValue(step12ColumnIndex));

					if (!reader.IsDBNull(step13ColumnIndex)) record.Step13 =  Convert.ToDateTime(reader.GetValue(step13ColumnIndex));

					if (!reader.IsDBNull(opinionIDColumnIndex)) record.OpinionID =  Convert.ToInt32(reader.GetValue(opinionIDColumnIndex));

					if (!reader.IsDBNull(opinionNameColumnIndex)) record.OpinionName =  Convert.ToString(reader.GetValue(opinionNameColumnIndex));

					if (!reader.IsDBNull(officerRoleIDColumnIndex)) record.OfficerRoleID =  Convert.ToInt32(reader.GetValue(officerRoleIDColumnIndex));

					if (!reader.IsDBNull(officerRoleNameColumnIndex)) record.OfficerRoleName =  Convert.ToString(reader.GetValue(officerRoleNameColumnIndex));

					record.IsPay =  Convert.ToBoolean(reader.GetValue(isPayColumnIndex));
					record.IsAppeal =  Convert.ToBoolean(reader.GetValue(isAppealColumnIndex));
					if (!reader.IsDBNull(regionIDColumnIndex)) record.RegionID =  Convert.ToInt32(reader.GetValue(regionIDColumnIndex));

					if (!reader.IsDBNull(regionNameColumnIndex)) record.RegionName =  Convert.ToString(reader.GetValue(regionNameColumnIndex));

					if (!reader.IsDBNull(lawyerIDColumnIndex)) record.LawyerID =  Convert.ToInt32(reader.GetValue(lawyerIDColumnIndex));

					if (!reader.IsDBNull(lawyerNameColumnIndex)) record.LawyerName =  Convert.ToString(reader.GetValue(lawyerNameColumnIndex));

					record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));
					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(referenceMSCCODEColumnIndex)) record.ReferenceMSCCODE =  Convert.ToString(reader.GetValue(referenceMSCCODEColumnIndex));

					record.DeletedFlag =  Convert.ToBoolean(reader.GetValue(deletedFlagColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ReportStatisticsCaseRow[])(recordList.ToArray(typeof(ReportStatisticsCaseRow)));
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
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "JFCaseNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RegisterDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "QT":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "YYYY":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ThaiQuarter":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ThaiFiscalYear":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MM":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ThaiMonth":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MeetingDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "IsAdditional":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsReview":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "JFCaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseTypeNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "StatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseApplicationStatusName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "WorkStepID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "WorkStepName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Step1":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step2":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step3":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step4":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step5":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step6":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step7":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step8":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step9":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step10":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step11":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step12":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Step13":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "OpinionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OpinionName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "OfficerRoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OfficerRoleName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsPay":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsAppeal":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "RegionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RegionName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LawyerID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LawyerName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReferenceMSCCODE":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DeletedFlag":
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

