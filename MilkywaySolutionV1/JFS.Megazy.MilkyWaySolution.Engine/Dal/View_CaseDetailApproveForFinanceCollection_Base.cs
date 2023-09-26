using System.ServiceModel;
using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	public partial class View_CaseDetailApproveForFinanceCollection_Base
	{
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string JFCaseNoColumnName = "JFCaseNo";
		public const string IsFinalApprovedColumnName = "IsFinalApproved";
		public const string OpinionIDColumnName = "OpinionID";
		public const string OpinionNameColumnName = "OpinionName";
		public const string OfficerRoleIDColumnName = "OfficerRoleID";
		public const string SubjectColumnName = "Subject";
		public const string JFCaseTypeIDColumnName = "JFCaseTypeID";
		public const string CaseTypeNameColumnName = "CaseTypeName";
		public const string CaseTypeNameAbbrColumnName = "CaseTypeNameAbbr";
		public const string ReferenceCaseIDColumnName = "ReferenceCaseID";
		public const string ReferenceMSCIDColumnName = "ReferenceMSCID";
		public const string ReferenceMSCCODEColumnName = "ReferenceMSCCODE";
		public const string CreateDateColumnName = "CreateDate";
		public const string RegisterDateColumnName = "RegisterDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string AgeColumnName = "Age";
		public const string RequestAmountColumnName = "RequestAmount";
		public const string HasProxyColumnName = "HasProxy";
		public const string GenderColumnName = "Gender";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string RaceIDColumnName = "RaceID";
		public const string RaceNameColumnName = "RaceName";
		public const string NationalityIDColumnName = "NationalityID";
		public const string NationalityNameColumnName = "NationalityName";
		public const string ReligionIDColumnName = "ReligionID";
		public const string ReligionNameColumnName = "ReligionName";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string DepartmentNameAbbrColumnName = "DepartmentNameAbbr";
		public const string WorkStepIDColumnName = "WorkStepID";
		public const string WorkStepNameColumnName = "WorkStepName";
		public const string StatusIDColumnName = "StatusID";
		public const string CaseApplicationStatusNameColumnName = "CaseApplicationStatusName";
		public const string CardIDColumnName = "CardID";
		public const string CardTypeNameColumnName = "CardTypeName";
		public const string CardTypeColumnName = "CardType";
		public const string IsAppealColumnName = "IsAppeal";
		public const string LawyerIDColumnName = "LawyerID";
		public const string LawyerFirstNameColumnName = "LawyerFirstName";
		public const string LawyerLastNameColumnName = "LawyerLastName";
		public const string TemIDColumnName = "TemID";
		public const string SubcommitteeIDColumnName = "SubcommitteeID";
		public const string SubcommitteeNameColumnName = "SubcommitteeName";
		public const string BudgetIDColumnName = "BudgetID";
		public const string BudgetNameColumnName = "BudgetName";
		public const string ApproveByIDColumnName = "ApproveByID";
		public const string ApproveByColumnName = "ApproveBy";
		public const string TotalAmountColumnName = "TotalAmount";
		public const string RedNoColumnName = "RedNo";
		public const string BlackNoColumnName = "BlackNo";
		public const string DeletedFlagColumnName = "DeletedFlag";
		private int _processID;
		public SqlCommand cmd = null;
		public View_CaseDetailApproveForFinanceCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_CaseDetailApproveForFinanceRow[] GetAll()
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
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[CaseID],"+
			"[ApplicantID],"+
			"[JFCaseNo],"+
			"[IsFinalApproved],"+
			"[OpinionID],"+
			"[OpinionName],"+
			"[OfficerRoleID],"+
			"[Subject],"+
			"[JFCaseTypeID],"+
			"[CaseTypeName],"+
			"[CaseTypeNameAbbr],"+
			"[ReferenceCaseID],"+
			"[ReferenceMSCID],"+
			"[ReferenceMSCCODE],"+
			"[CreateDate],"+
			"[RegisterDate],"+
			"[ModifiedDate],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[Age],"+
			"[RequestAmount],"+
			"[HasProxy],"+
			"[Gender],"+
			"[DateOfBirth],"+
			"[RaceID],"+
			"[RaceName],"+
			"[NationalityID],"+
			"[NationalityName],"+
			"[ReligionID],"+
			"[ReligionName],"+
			"[ProvinceID],"+
			"[ProvinceName],"+
			"[DepartmentID],"+
			"[DepartmentName],"+
			"[DepartmentNameAbbr],"+
			"[WorkStepID],"+
			"[WorkStepName],"+
			"[StatusID],"+
			"[CaseApplicationStatusName],"+
			"[CardID],"+
			"[CardTypeName],"+
			"[CardType],"+
			"[IsAppeal],"+
			"[LawyerID],"+
			"[LawyerFirstName],"+
			"[LawyerLastName],"+
			"[TemID],"+
			"[SubcommitteeID],"+
			"[SubcommitteeName],"+
			"[BudgetID],"+
			"[BudgetName],"+
			"[ApproveByID],"+
			"[ApproveBy],"+
			"[TotalAmount],"+
			"[RedNo],"+
			"[BlackNo],"+
			"[DeletedFlag]"+
			" FROM [dbo].[View_CaseDetailApproveForFinance]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "View_CaseDetailApproveForFinance"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("JFCaseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsFinalApproved",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("OpinionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("OpinionName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OfficerRoleID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("JFCaseTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CaseTypeNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ReferenceCaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCCODE",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RegisterDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Age",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RequestAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("HasProxy",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RaceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReligionName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("DepartmentNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("WorkStepID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("WorkStepName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("StatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CaseApplicationStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CardTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CardType",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsAppeal",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("LawyerID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("LawyerFirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LawyerLastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TemID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SubcommitteeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SubcommitteeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("BudgetID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("BudgetName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ApproveByID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApproveBy",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TotalAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("RedNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("BlackNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("DeletedFlag",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public View_CaseDetailApproveForFinanceRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_CaseDetailApproveForFinanceRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_CaseDetailApproveForFinanceRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_CaseDetailApproveForFinanceRow"/> objects.</returns>
		public virtual View_CaseDetailApproveForFinanceRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_CaseDetailApproveForFinance]", top);
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
		public View_CaseDetailApproveForFinanceRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_CaseDetailApproveForFinanceRow[] rows = null;
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
		public DataTable GetView_CaseDetailApproveForFinancePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
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
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[View_CaseDetailApproveForFinance] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,ApplicantID,JFCaseNo,IsFinalApproved,OpinionID,OpinionName,OfficerRoleID,Subject,JFCaseTypeID,CaseTypeName,CaseTypeNameAbbr,ReferenceCaseID,ReferenceMSCID,ReferenceMSCCODE,CreateDate,RegisterDate,ModifiedDate,Title,FirstName,LastName,Age,RequestAmount,HasProxy,Gender,DateOfBirth,RaceID,RaceName,NationalityID,NationalityName,ReligionID,ReligionName,ProvinceID,ProvinceName,DepartmentID,DepartmentName,DepartmentNameAbbr,WorkStepID,WorkStepName,StatusID,CaseApplicationStatusName,CardID,CardTypeName,CardType,IsAppeal,LawyerID,LawyerFirstName,LawyerLastName,TemID,SubcommitteeID,SubcommitteeName,BudgetID,BudgetName,ApproveByID,ApproveBy,TotalAmount,RedNo,BlackNo,DeletedFlag," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_CaseDetailApproveForFinance] " + whereSql +
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
		public View_CaseDetailApproveForFinanceItemsPaging GetView_CaseDetailApproveForFinancePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		View_CaseDetailApproveForFinanceItemsPaging obj = new View_CaseDetailApproveForFinanceItemsPaging();
		DataTable dt = GetView_CaseDetailApproveForFinancePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_CaseDetailApproveForFinanceItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_CaseDetailApproveForFinanceItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.JFCaseNo = dt.Rows[i]["JFCaseNo"].ToString();
			if (dt.Rows[i]["IsFinalApproved"] != DBNull.Value)
			record.IsFinalApproved = Convert.ToBoolean(dt.Rows[i]["IsFinalApproved"]);
			if (dt.Rows[i]["OpinionID"] != DBNull.Value)
			record.OpinionID = Convert.ToInt32(dt.Rows[i]["OpinionID"]);
			record.OpinionName = dt.Rows[i]["OpinionName"].ToString();
			record.OfficerRoleID = Convert.ToInt32(dt.Rows[i]["OfficerRoleID"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.JFCaseTypeID = Convert.ToInt32(dt.Rows[i]["JFCaseTypeID"]);
			record.CaseTypeName = dt.Rows[i]["CaseTypeName"].ToString();
			record.CaseTypeNameAbbr = dt.Rows[i]["CaseTypeNameAbbr"].ToString();
			if (dt.Rows[i]["ReferenceCaseID"] != DBNull.Value)
			record.ReferenceCaseID = Convert.ToInt32(dt.Rows[i]["ReferenceCaseID"]);
			if (dt.Rows[i]["ReferenceMSCID"] != DBNull.Value)
			record.ReferenceMSCID = Convert.ToInt32(dt.Rows[i]["ReferenceMSCID"]);
			record.ReferenceMSCCODE = dt.Rows[i]["ReferenceMSCCODE"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["RegisterDate"] != DBNull.Value)
			record.RegisterDate = Convert.ToDateTime(dt.Rows[i]["RegisterDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
			if (dt.Rows[i]["RequestAmount"] != DBNull.Value)
			record.RequestAmount = Convert.ToDouble(dt.Rows[i]["RequestAmount"]);
			if (dt.Rows[i]["HasProxy"] != DBNull.Value)
			record.HasProxy = Convert.ToBoolean(dt.Rows[i]["HasProxy"]);
			record.Gender = dt.Rows[i]["Gender"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			record.RaceName = dt.Rows[i]["RaceName"].ToString();
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			record.NationalityName = dt.Rows[i]["NationalityName"].ToString();
			if (dt.Rows[i]["ReligionID"] != DBNull.Value)
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			record.ReligionName = dt.Rows[i]["ReligionName"].ToString();
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			record.DepartmentNameAbbr = dt.Rows[i]["DepartmentNameAbbr"].ToString();
			if (dt.Rows[i]["WorkStepID"] != DBNull.Value)
			record.WorkStepID = Convert.ToInt32(dt.Rows[i]["WorkStepID"]);
			record.WorkStepName = dt.Rows[i]["WorkStepName"].ToString();
			if (dt.Rows[i]["StatusID"] != DBNull.Value)
			record.StatusID = Convert.ToInt32(dt.Rows[i]["StatusID"]);
			record.CaseApplicationStatusName = dt.Rows[i]["CaseApplicationStatusName"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.CardTypeName = dt.Rows[i]["CardTypeName"].ToString();
			if (dt.Rows[i]["CardType"] != DBNull.Value)
			record.CardType = Convert.ToInt32(dt.Rows[i]["CardType"]);
			if (dt.Rows[i]["IsAppeal"] != DBNull.Value)
			record.IsAppeal = Convert.ToBoolean(dt.Rows[i]["IsAppeal"]);
			if (dt.Rows[i]["LawyerID"] != DBNull.Value)
			record.LawyerID = Convert.ToInt32(dt.Rows[i]["LawyerID"]);
			record.LawyerFirstName = dt.Rows[i]["LawyerFirstName"].ToString();
			record.LawyerLastName = dt.Rows[i]["LawyerLastName"].ToString();
			record.TemID = Convert.ToInt32(dt.Rows[i]["TemID"]);
			if (dt.Rows[i]["SubcommitteeID"] != DBNull.Value)
			record.SubcommitteeID = Convert.ToInt32(dt.Rows[i]["SubcommitteeID"]);
			record.SubcommitteeName = dt.Rows[i]["SubcommitteeName"].ToString();
			if (dt.Rows[i]["BudgetID"] != DBNull.Value)
			record.BudgetID = Convert.ToInt32(dt.Rows[i]["BudgetID"]);
			record.BudgetName = dt.Rows[i]["BudgetName"].ToString();
			if (dt.Rows[i]["ApproveByID"] != DBNull.Value)
			record.ApproveByID = Convert.ToInt32(dt.Rows[i]["ApproveByID"]);
			record.ApproveBy = dt.Rows[i]["ApproveBy"].ToString();
			if (dt.Rows[i]["TotalAmount"] != DBNull.Value)
			record.TotalAmount = Convert.ToDouble(dt.Rows[i]["TotalAmount"]);
			record.RedNo = dt.Rows[i]["RedNo"].ToString();
			record.BlackNo = dt.Rows[i]["BlackNo"].ToString();
			record.DeletedFlag = Convert.ToBoolean(dt.Rows[i]["DeletedFlag"]);
			recordList.Add(record);
		}
		obj.view_CaseDetailApproveForFinanceItems = (View_CaseDetailApproveForFinanceItems[])(recordList.ToArray(typeof(View_CaseDetailApproveForFinanceItems)));
		return obj;
		}
		protected View_CaseDetailApproveForFinanceRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_CaseDetailApproveForFinanceRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_CaseDetailApproveForFinanceRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int jFCaseNoColumnIndex = reader.GetOrdinal("JFCaseNo");
			int isFinalApprovedColumnIndex = reader.GetOrdinal("IsFinalApproved");
			int opinionIDColumnIndex = reader.GetOrdinal("OpinionID");
			int opinionNameColumnIndex = reader.GetOrdinal("OpinionName");
			int officerRoleIDColumnIndex = reader.GetOrdinal("OfficerRoleID");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int jFCaseTypeIDColumnIndex = reader.GetOrdinal("JFCaseTypeID");
			int caseTypeNameColumnIndex = reader.GetOrdinal("CaseTypeName");
			int caseTypeNameAbbrColumnIndex = reader.GetOrdinal("CaseTypeNameAbbr");
			int referenceCaseIDColumnIndex = reader.GetOrdinal("ReferenceCaseID");
			int referenceMSCIDColumnIndex = reader.GetOrdinal("ReferenceMSCID");
			int referenceMSCCODEColumnIndex = reader.GetOrdinal("ReferenceMSCCODE");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int registerDateColumnIndex = reader.GetOrdinal("RegisterDate");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int ageColumnIndex = reader.GetOrdinal("Age");
			int requestAmountColumnIndex = reader.GetOrdinal("RequestAmount");
			int hasProxyColumnIndex = reader.GetOrdinal("HasProxy");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int raceNameColumnIndex = reader.GetOrdinal("RaceName");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int nationalitynameColumnIndex = reader.GetOrdinal("NationalityName");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int religionNameColumnIndex = reader.GetOrdinal("ReligionName");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int departmentNameColumnIndex = reader.GetOrdinal("DepartmentName");
			int departmentNameAbbrColumnIndex = reader.GetOrdinal("DepartmentNameAbbr");
			int workStepIDColumnIndex = reader.GetOrdinal("WorkStepID");
			int workStepNameColumnIndex = reader.GetOrdinal("WorkStepName");
			int statusIDColumnIndex = reader.GetOrdinal("StatusID");
			int caseApplicationStatusNameColumnIndex = reader.GetOrdinal("CaseApplicationStatusName");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int cardTypeNameColumnIndex = reader.GetOrdinal("CardTypeName");
			int cardTypeColumnIndex = reader.GetOrdinal("CardType");
			int isAppealColumnIndex = reader.GetOrdinal("IsAppeal");
			int lawyerIDColumnIndex = reader.GetOrdinal("LawyerID");
			int lawyerFirstNameColumnIndex = reader.GetOrdinal("LawyerFirstName");
			int lawyerlastNameColumnIndex = reader.GetOrdinal("LawyerLastName");
			int temIDColumnIndex = reader.GetOrdinal("TemID");
			int subcommitteeIDColumnIndex = reader.GetOrdinal("SubcommitteeID");
			int subcommitteeNameColumnIndex = reader.GetOrdinal("SubcommitteeName");
			int budgetIDColumnIndex = reader.GetOrdinal("BudgetID");
			int budgetNameColumnIndex = reader.GetOrdinal("BudgetName");
			int approveByIDColumnIndex = reader.GetOrdinal("ApproveByID");
			int approveByColumnIndex = reader.GetOrdinal("ApproveBy");
			int totalAmountColumnIndex = reader.GetOrdinal("TotalAmount");
			int redNoColumnIndex = reader.GetOrdinal("RedNo");
			int blackNoColumnIndex = reader.GetOrdinal("BlackNo");
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
					View_CaseDetailApproveForFinanceRow record = new View_CaseDetailApproveForFinanceRow();
					recordList.Add(record);
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.JFCaseNo =  Convert.ToString(reader.GetValue(jFCaseNoColumnIndex));
					if (!reader.IsDBNull(isFinalApprovedColumnIndex)) record.IsFinalApproved =  Convert.ToBoolean(reader.GetValue(isFinalApprovedColumnIndex));

					if (!reader.IsDBNull(opinionIDColumnIndex)) record.OpinionID =  Convert.ToInt32(reader.GetValue(opinionIDColumnIndex));

					if (!reader.IsDBNull(opinionNameColumnIndex)) record.OpinionName =  Convert.ToString(reader.GetValue(opinionNameColumnIndex));

					record.OfficerRoleID =  Convert.ToInt32(reader.GetValue(officerRoleIDColumnIndex));
					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					record.JFCaseTypeID =  Convert.ToInt32(reader.GetValue(jFCaseTypeIDColumnIndex));
					if (!reader.IsDBNull(caseTypeNameColumnIndex)) record.CaseTypeName =  Convert.ToString(reader.GetValue(caseTypeNameColumnIndex));

					if (!reader.IsDBNull(caseTypeNameAbbrColumnIndex)) record.CaseTypeNameAbbr =  Convert.ToString(reader.GetValue(caseTypeNameAbbrColumnIndex));

					if (!reader.IsDBNull(referenceCaseIDColumnIndex)) record.ReferenceCaseID =  Convert.ToInt32(reader.GetValue(referenceCaseIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCIDColumnIndex)) record.ReferenceMSCID =  Convert.ToInt32(reader.GetValue(referenceMSCIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCCODEColumnIndex)) record.ReferenceMSCCODE =  Convert.ToString(reader.GetValue(referenceMSCCODEColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(registerDateColumnIndex)) record.RegisterDate =  Convert.ToDateTime(reader.GetValue(registerDateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					record.Age =  Convert.ToInt32(reader.GetValue(ageColumnIndex));
					if (!reader.IsDBNull(requestAmountColumnIndex)) record.RequestAmount =  Convert.ToDouble(reader.GetValue(requestAmountColumnIndex));

					if (!reader.IsDBNull(hasProxyColumnIndex)) record.HasProxy =  Convert.ToBoolean(reader.GetValue(hasProxyColumnIndex));

					record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));
					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(raceNameColumnIndex)) record.RaceName =  Convert.ToString(reader.GetValue(raceNameColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

					if (!reader.IsDBNull(nationalitynameColumnIndex)) record.NationalityName =  Convert.ToString(reader.GetValue(nationalitynameColumnIndex));

					if (!reader.IsDBNull(religionIDColumnIndex)) record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));

					if (!reader.IsDBNull(religionNameColumnIndex)) record.ReligionName =  Convert.ToString(reader.GetValue(religionNameColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(departmentNameColumnIndex)) record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));

					if (!reader.IsDBNull(departmentNameAbbrColumnIndex)) record.DepartmentNameAbbr =  Convert.ToString(reader.GetValue(departmentNameAbbrColumnIndex));

					if (!reader.IsDBNull(workStepIDColumnIndex)) record.WorkStepID =  Convert.ToInt32(reader.GetValue(workStepIDColumnIndex));

					if (!reader.IsDBNull(workStepNameColumnIndex)) record.WorkStepName =  Convert.ToString(reader.GetValue(workStepNameColumnIndex));

					if (!reader.IsDBNull(statusIDColumnIndex)) record.StatusID =  Convert.ToInt32(reader.GetValue(statusIDColumnIndex));

					if (!reader.IsDBNull(caseApplicationStatusNameColumnIndex)) record.CaseApplicationStatusName =  Convert.ToString(reader.GetValue(caseApplicationStatusNameColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(cardTypeNameColumnIndex)) record.CardTypeName =  Convert.ToString(reader.GetValue(cardTypeNameColumnIndex));

					if (!reader.IsDBNull(cardTypeColumnIndex)) record.CardType =  Convert.ToInt32(reader.GetValue(cardTypeColumnIndex));

					if (!reader.IsDBNull(isAppealColumnIndex)) record.IsAppeal =  Convert.ToBoolean(reader.GetValue(isAppealColumnIndex));

					if (!reader.IsDBNull(lawyerIDColumnIndex)) record.LawyerID =  Convert.ToInt32(reader.GetValue(lawyerIDColumnIndex));

					if (!reader.IsDBNull(lawyerFirstNameColumnIndex)) record.LawyerFirstName =  Convert.ToString(reader.GetValue(lawyerFirstNameColumnIndex));

					if (!reader.IsDBNull(lawyerlastNameColumnIndex)) record.LawyerLastName =  Convert.ToString(reader.GetValue(lawyerlastNameColumnIndex));

					record.TemID =  Convert.ToInt32(reader.GetValue(temIDColumnIndex));
					if (!reader.IsDBNull(subcommitteeIDColumnIndex)) record.SubcommitteeID =  Convert.ToInt32(reader.GetValue(subcommitteeIDColumnIndex));

					if (!reader.IsDBNull(subcommitteeNameColumnIndex)) record.SubcommitteeName =  Convert.ToString(reader.GetValue(subcommitteeNameColumnIndex));

					if (!reader.IsDBNull(budgetIDColumnIndex)) record.BudgetID =  Convert.ToInt32(reader.GetValue(budgetIDColumnIndex));

					if (!reader.IsDBNull(budgetNameColumnIndex)) record.BudgetName =  Convert.ToString(reader.GetValue(budgetNameColumnIndex));

					if (!reader.IsDBNull(approveByIDColumnIndex)) record.ApproveByID =  Convert.ToInt32(reader.GetValue(approveByIDColumnIndex));

					if (!reader.IsDBNull(approveByColumnIndex)) record.ApproveBy =  Convert.ToString(reader.GetValue(approveByColumnIndex));

					if (!reader.IsDBNull(totalAmountColumnIndex)) record.TotalAmount =  Convert.ToDouble(reader.GetValue(totalAmountColumnIndex));

					if (!reader.IsDBNull(redNoColumnIndex)) record.RedNo =  Convert.ToString(reader.GetValue(redNoColumnIndex));

					if (!reader.IsDBNull(blackNoColumnIndex)) record.BlackNo =  Convert.ToString(reader.GetValue(blackNoColumnIndex));

					record.DeletedFlag =  Convert.ToBoolean(reader.GetValue(deletedFlagColumnIndex));
					record.MapRecord = true;
					if (countRecordRow > 1) 
					{
						record.Many = true;
					}
					else
					{
						record.Many = false;
					}
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_CaseDetailApproveForFinanceRow[])(recordList.ToArray(typeof(View_CaseDetailApproveForFinanceRow)));
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
				case "JFCaseNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsFinalApproved":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "JFCaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseTypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseTypeNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReferenceCaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCCODE":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "RegisterDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Age":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RequestAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "HasProxy":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RaceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReligionName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "WorkStepID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "WorkStepName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "StatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseApplicationStatusName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CardTypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CardType":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsAppeal":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "LawyerID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LawyerFirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LawyerLastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TemID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubcommitteeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubcommitteeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BudgetID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "BudgetName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ApproveByID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApproveBy":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TotalAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "RedNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BlackNo":
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
				throw new FaultException("Zero ProcessID");
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

