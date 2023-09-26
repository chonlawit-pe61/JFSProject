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
	public partial class View_TransactionCollection_Base
	{
		public const string TransactionIDColumnName = "TransactionID";
		public const string ContractNoColumnName = "ContractNo";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string TransactionAmountColumnName = "TransactionAmount";
		public const string ContractIDColumnName = "ContractID";
		public const string FormIDColumnName = "FormID";
		public const string FormNameColumnName = "FormName";
		public const string TransactionStatusIDColumnName = "TransactionStatusID";
		public const string TransactionStatusNameColumnName = "TransactionStatusName";
		public const string TransactionTypeIDColumnName = "TransactionTypeID";
		public const string TrasactionTypeDescColumnName = "TrasactionTypeDesc";
		public const string RedNoColumnName = "RedNo";
		public const string BlackNoColumnName = "BlackNo";
		public const string CourIDColumnName = "CourID";
		public const string CourtNameColumnName = "CourtName";
		public const string TransactionNoColumnName = "TransactionNo";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string CreateDateColumnName = "CreateDate";
		public const string TranferDateColumnName = "TranferDate";
		public const string WorkStepIDColumnName = "WorkStepID";
		public const string AgeColumnName = "Age";
		public const string GenderColumnName = "Gender";
		public const string CardIDColumnName = "CardID";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string JFCaseNoColumnName = "JFCaseNo";
		public const string PaidDateColumnName = "PaidDate";
		public const string TotalAmountPaidColumnName = "TotalAmountPaid";
		public const string AmountColumnName = "Amount";
		public const string ContractDateColumnName = "ContractDate";
		public const string SigningPlaceColumnName = "SigningPlace";
		public const string ContractNoteColumnName = "ContractNote";
		public const string NoteColumnName = "Note";
		public const string FinancialOfficerNoteColumnName = "FinancialOfficerNote";
		public const string PayerColumnName = "Payer";
		public const string PayeeColumnName = "Payee";
		public const string AdditionnalCourtNameColumnName = "AdditionnalCourtName";
		public const string CourtLevelColumnName = "CourtLevel";
		public const string LawyerAddressLineColumnName = "LawyerAddressLine";
		public const string BankAccountNameColumnName = "BankAccountName";
		public const string BankAccountNoColumnName = "BankAccountNo";
		public const string BankNameColumnName = "BankName";
		public const string BankBranchColumnName = "BankBranch";
		public const string BankAccountTypeColumnName = "BankAccountType";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string DeleteFlagColumnName = "DeleteFlag";
		public const string TransactionDateColumnName = "TransactionDate";
		public const string PaymentListJsonColumnName = "PaymentListJson";
		public const string TransactionDetailColumnName = "TransactionDetail";
		public const string IsCancelColumnName = "IsCancel";
		public const string RefTransactionIDColumnName = "RefTransactionID";
		public const string RefTransactionNoColumnName = "RefTransactionNo";
		public const string JFPortalReceiveDateColumnName = "JFPortalReceiveDate";
		public const string IsRequestRefundColumnName = "IsRequestRefund";
		private int _processID;
		public SqlCommand cmd = null;
		public View_TransactionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_TransactionRow[] GetAll()
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
			"[TransactionID],"+
			"[ContractNo],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[TransactionAmount],"+
			"[ContractID],"+
			"[FormID],"+
			"[FormName],"+
			"[TransactionStatusID],"+
			"[TransactionStatusName],"+
			"[TransactionTypeID],"+
			"[TrasactionTypeDesc],"+
			"[RedNo],"+
			"[BlackNo],"+
			"[CourID],"+
			"[CourtName],"+
			"[TransactionNo],"+
			"[DepartmentID],"+
			"[DepartmentName],"+
			"[CreateDate],"+
			"[TranferDate],"+
			"[WorkStepID],"+
			"[Age],"+
			"[Gender],"+
			"[CardID],"+
			"[DateOfBirth],"+
			"[JFCaseNo],"+
			"[PaidDate],"+
			"[TotalAmountPaid],"+
			"[Amount],"+
			"[ContractDate],"+
			"[SigningPlace],"+
			"[ContractNote],"+
			"[Note],"+
			"[FinancialOfficerNote],"+
			"[Payer],"+
			"[Payee],"+
			"[AdditionnalCourtName],"+
			"[CourtLevel],"+
			"[LawyerAddressLine],"+
			"[BankAccountName],"+
			"[BankAccountNo],"+
			"[BankName],"+
			"[BankBranch],"+
			"[BankAccountType],"+
			"[ModifiedDate],"+
			"[DeleteFlag],"+
			"[TransactionDate],"+
			"[PaymentListJson],"+
			"[TransactionDetail],"+
			"[IsCancel],"+
			"[RefTransactionID],"+
			"[RefTransactionNo],"+
			"[JFPortalReceiveDate],"+
			"[IsRequestRefund]"+
			" FROM [dbo].[View_Transaction]";
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
				TableName = "View_Transaction"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ContractNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("TransactionAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("ContractID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FormName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("TransactionStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TransactionTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TrasactionTypeDesc",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RedNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("BlackNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CourID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CourtName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("TransactionNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("TranferDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("WorkStepID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Age",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("JFCaseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("PaidDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("TotalAmountPaid",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Amount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("ContractDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("SigningPlace",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ContractNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("FinancialOfficerNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("Payer",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("Payee",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("AdditionnalCourtName",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("CourtLevel",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LawyerAddressLine",Type.GetType("System.String"));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("BankAccountName",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("BankAccountNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("BankName",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("BankBranch",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("BankAccountType",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("DeleteFlag",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("TransactionDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("PaymentListJson",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("TransactionDetail",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("IsCancel",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("RefTransactionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RefTransactionNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("JFPortalReceiveDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("IsRequestRefund",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public View_TransactionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_TransactionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_TransactionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_TransactionRow"/> objects.</returns>
		public virtual View_TransactionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_Transaction]", top);
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
		public View_TransactionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_TransactionRow[] rows = null;
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
		public DataTable GetView_TransactionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TransactionID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TransactionID) AS TotalRow FROM [dbo].[View_Transaction] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionID,ContractNo,CaseID,ApplicantID,Title,FirstName,LastName,TransactionAmount,ContractID,FormID,FormName,TransactionStatusID,TransactionStatusName,TransactionTypeID,TrasactionTypeDesc,RedNo,BlackNo,CourID,CourtName,TransactionNo,DepartmentID,DepartmentName,CreateDate,TranferDate,WorkStepID,Age,Gender,CardID,DateOfBirth,JFCaseNo,PaidDate,TotalAmountPaid,Amount,ContractDate,SigningPlace,ContractNote,Note,FinancialOfficerNote,Payer,Payee,AdditionnalCourtName,CourtLevel,LawyerAddressLine,BankAccountName,BankAccountNo,BankName,BankBranch,BankAccountType,ModifiedDate,DeleteFlag,TransactionDate,PaymentListJson,TransactionDetail,IsCancel,RefTransactionID,RefTransactionNo,JFPortalReceiveDate,IsRequestRefund," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_Transaction] " + whereSql +
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
		public View_TransactionItemsPaging GetView_TransactionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
		View_TransactionItemsPaging obj = new View_TransactionItemsPaging();
		DataTable dt = GetView_TransactionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_TransactionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_TransactionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.ContractNo = dt.Rows[i]["ContractNo"].ToString();
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			if (dt.Rows[i]["TransactionAmount"] != DBNull.Value)
			record.TransactionAmount = Convert.ToDouble(dt.Rows[i]["TransactionAmount"]);
			if (dt.Rows[i]["ContractID"] != DBNull.Value)
			record.ContractID = Convert.ToInt32(dt.Rows[i]["ContractID"]);
			if (dt.Rows[i]["FormID"] != DBNull.Value)
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			record.FormName = dt.Rows[i]["FormName"].ToString();
			record.TransactionStatusID = Convert.ToInt32(dt.Rows[i]["TransactionStatusID"]);
			record.TransactionStatusName = dt.Rows[i]["TransactionStatusName"].ToString();
			record.TransactionTypeID = Convert.ToInt32(dt.Rows[i]["TransactionTypeID"]);
			record.TrasactionTypeDesc = dt.Rows[i]["TrasactionTypeDesc"].ToString();
			record.RedNo = dt.Rows[i]["RedNo"].ToString();
			record.BlackNo = dt.Rows[i]["BlackNo"].ToString();
			if (dt.Rows[i]["CourID"] != DBNull.Value)
			record.CourID = Convert.ToInt32(dt.Rows[i]["CourID"]);
			record.CourtName = dt.Rows[i]["CourtName"].ToString();
			record.TransactionNo = dt.Rows[i]["TransactionNo"].ToString();
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["TranferDate"] != DBNull.Value)
			record.TranferDate = Convert.ToDateTime(dt.Rows[i]["TranferDate"]);
			if (dt.Rows[i]["WorkStepID"] != DBNull.Value)
			record.WorkStepID = Convert.ToInt32(dt.Rows[i]["WorkStepID"]);
			if (dt.Rows[i]["Age"] != DBNull.Value)
			record.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			record.JFCaseNo = dt.Rows[i]["JFCaseNo"].ToString();
			if (dt.Rows[i]["PaidDate"] != DBNull.Value)
			record.PaidDate = Convert.ToDateTime(dt.Rows[i]["PaidDate"]);
			if (dt.Rows[i]["TotalAmountPaid"] != DBNull.Value)
			record.TotalAmountPaid = Convert.ToDouble(dt.Rows[i]["TotalAmountPaid"]);
			if (dt.Rows[i]["Amount"] != DBNull.Value)
			record.Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
			if (dt.Rows[i]["ContractDate"] != DBNull.Value)
			record.ContractDate = Convert.ToDateTime(dt.Rows[i]["ContractDate"]);
			record.SigningPlace = dt.Rows[i]["SigningPlace"].ToString();
			record.ContractNote = dt.Rows[i]["ContractNote"].ToString();
			record.Note = dt.Rows[i]["Note"].ToString();
			record.FinancialOfficerNote = dt.Rows[i]["FinancialOfficerNote"].ToString();
			record.Payer = dt.Rows[i]["Payer"].ToString();
			record.Payee = dt.Rows[i]["Payee"].ToString();
			record.AdditionnalCourtName = dt.Rows[i]["AdditionnalCourtName"].ToString();
			record.CourtLevel = dt.Rows[i]["CourtLevel"].ToString();
			record.LawyerAddressLine = dt.Rows[i]["LawyerAddressLine"].ToString();
			record.BankAccountName = dt.Rows[i]["BankAccountName"].ToString();
			record.BankAccountNo = dt.Rows[i]["BankAccountNo"].ToString();
			record.BankName = dt.Rows[i]["BankName"].ToString();
			record.BankBranch = dt.Rows[i]["BankBranch"].ToString();
			record.BankAccountType = dt.Rows[i]["BankAccountType"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["DeleteFlag"] != DBNull.Value)
			record.DeleteFlag = Convert.ToBoolean(dt.Rows[i]["DeleteFlag"]);
			if (dt.Rows[i]["TransactionDate"] != DBNull.Value)
			record.TransactionDate = Convert.ToDateTime(dt.Rows[i]["TransactionDate"]);
			record.PaymentListJson = dt.Rows[i]["PaymentListJson"].ToString();
			record.TransactionDetail = dt.Rows[i]["TransactionDetail"].ToString();
			if (dt.Rows[i]["IsCancel"] != DBNull.Value)
			record.IsCancel = Convert.ToBoolean(dt.Rows[i]["IsCancel"]);
			if (dt.Rows[i]["RefTransactionID"] != DBNull.Value)
			record.RefTransactionID = Convert.ToInt32(dt.Rows[i]["RefTransactionID"]);
			record.RefTransactionNo = dt.Rows[i]["RefTransactionNo"].ToString();
			if (dt.Rows[i]["JFPortalReceiveDate"] != DBNull.Value)
			record.JFPortalReceiveDate = Convert.ToDateTime(dt.Rows[i]["JFPortalReceiveDate"]);
			if (dt.Rows[i]["IsRequestRefund"] != DBNull.Value)
			record.IsRequestRefund = Convert.ToBoolean(dt.Rows[i]["IsRequestRefund"]);
			recordList.Add(record);
		}
		obj.view_TransactionItems = (View_TransactionItems[])(recordList.ToArray(typeof(View_TransactionItems)));
		return obj;
		}
		protected View_TransactionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_TransactionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_TransactionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int contractNoColumnIndex = reader.GetOrdinal("ContractNo");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int transactionAmountColumnIndex = reader.GetOrdinal("TransactionAmount");
			int contractIDColumnIndex = reader.GetOrdinal("ContractID");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int formNameColumnIndex = reader.GetOrdinal("FormName");
			int transactionStatusIDColumnIndex = reader.GetOrdinal("TransactionStatusID");
			int transactionStatusNameColumnIndex = reader.GetOrdinal("TransactionStatusName");
			int transactiontypeIDColumnIndex = reader.GetOrdinal("TransactionTypeID");
			int trasactiontypeDescColumnIndex = reader.GetOrdinal("TrasactionTypeDesc");
			int redNoColumnIndex = reader.GetOrdinal("RedNo");
			int blackNoColumnIndex = reader.GetOrdinal("BlackNo");
			int courIDColumnIndex = reader.GetOrdinal("CourID");
			int courtNameColumnIndex = reader.GetOrdinal("CourtName");
			int transactionNoColumnIndex = reader.GetOrdinal("TransactionNo");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int departmentNameColumnIndex = reader.GetOrdinal("DepartmentName");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int tranferDateColumnIndex = reader.GetOrdinal("TranferDate");
			int workStepIDColumnIndex = reader.GetOrdinal("WorkStepID");
			int ageColumnIndex = reader.GetOrdinal("Age");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int jFCaseNoColumnIndex = reader.GetOrdinal("JFCaseNo");
			int paidDateColumnIndex = reader.GetOrdinal("PaidDate");
			int totalAmountPaidColumnIndex = reader.GetOrdinal("TotalAmountPaid");
			int amountColumnIndex = reader.GetOrdinal("Amount");
			int contractDateColumnIndex = reader.GetOrdinal("ContractDate");
			int signingPlaceColumnIndex = reader.GetOrdinal("SigningPlace");
			int contractNoteColumnIndex = reader.GetOrdinal("ContractNote");
			int noteColumnIndex = reader.GetOrdinal("Note");
			int financialOfficerNoteColumnIndex = reader.GetOrdinal("FinancialOfficerNote");
			int payerColumnIndex = reader.GetOrdinal("Payer");
			int payeeColumnIndex = reader.GetOrdinal("Payee");
			int additionnalCourtNameColumnIndex = reader.GetOrdinal("AdditionnalCourtName");
			int courtLevelColumnIndex = reader.GetOrdinal("CourtLevel");
			int lawyerAddresslineColumnIndex = reader.GetOrdinal("LawyerAddressLine");
			int bankAccountNameColumnIndex = reader.GetOrdinal("BankAccountName");
			int bankAccountNoColumnIndex = reader.GetOrdinal("BankAccountNo");
			int bankNameColumnIndex = reader.GetOrdinal("BankName");
			int bankbranchColumnIndex = reader.GetOrdinal("BankBranch");
			int bankAccountTypeColumnIndex = reader.GetOrdinal("BankAccountType");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int deleteFlagColumnIndex = reader.GetOrdinal("DeleteFlag");
			int transactionDateColumnIndex = reader.GetOrdinal("TransactionDate");
			int paymentListJsonColumnIndex = reader.GetOrdinal("PaymentListJson");
			int transactionDetailColumnIndex = reader.GetOrdinal("TransactionDetail");
			int isCancelColumnIndex = reader.GetOrdinal("IsCancel");
			int refTransactionIDColumnIndex = reader.GetOrdinal("RefTransactionID");
			int refTransactionNoColumnIndex = reader.GetOrdinal("RefTransactionNo");
			int jFPortalReceiveDateColumnIndex = reader.GetOrdinal("JFPortalReceiveDate");
			int isRequestRefundColumnIndex = reader.GetOrdinal("IsRequestRefund");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_TransactionRow record = new View_TransactionRow();
					recordList.Add(record);
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(contractNoColumnIndex)) record.ContractNo =  Convert.ToString(reader.GetValue(contractNoColumnIndex));

					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(transactionAmountColumnIndex)) record.TransactionAmount =  Convert.ToDouble(reader.GetValue(transactionAmountColumnIndex));

					if (!reader.IsDBNull(contractIDColumnIndex)) record.ContractID =  Convert.ToInt32(reader.GetValue(contractIDColumnIndex));

					if (!reader.IsDBNull(formIDColumnIndex)) record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));

					if (!reader.IsDBNull(formNameColumnIndex)) record.FormName =  Convert.ToString(reader.GetValue(formNameColumnIndex));

					record.TransactionStatusID =  Convert.ToInt32(reader.GetValue(transactionStatusIDColumnIndex));
					if (!reader.IsDBNull(transactionStatusNameColumnIndex)) record.TransactionStatusName =  Convert.ToString(reader.GetValue(transactionStatusNameColumnIndex));

					record.TransactionTypeID =  Convert.ToInt32(reader.GetValue(transactiontypeIDColumnIndex));
					record.TrasactionTypeDesc =  Convert.ToString(reader.GetValue(trasactiontypeDescColumnIndex));
					if (!reader.IsDBNull(redNoColumnIndex)) record.RedNo =  Convert.ToString(reader.GetValue(redNoColumnIndex));

					if (!reader.IsDBNull(blackNoColumnIndex)) record.BlackNo =  Convert.ToString(reader.GetValue(blackNoColumnIndex));

					if (!reader.IsDBNull(courIDColumnIndex)) record.CourID =  Convert.ToInt32(reader.GetValue(courIDColumnIndex));

					if (!reader.IsDBNull(courtNameColumnIndex)) record.CourtName =  Convert.ToString(reader.GetValue(courtNameColumnIndex));

					if (!reader.IsDBNull(transactionNoColumnIndex)) record.TransactionNo =  Convert.ToString(reader.GetValue(transactionNoColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(departmentNameColumnIndex)) record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(tranferDateColumnIndex)) record.TranferDate =  Convert.ToDateTime(reader.GetValue(tranferDateColumnIndex));

					if (!reader.IsDBNull(workStepIDColumnIndex)) record.WorkStepID =  Convert.ToInt32(reader.GetValue(workStepIDColumnIndex));

					if (!reader.IsDBNull(ageColumnIndex)) record.Age =  Convert.ToInt32(reader.GetValue(ageColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(jFCaseNoColumnIndex)) record.JFCaseNo =  Convert.ToString(reader.GetValue(jFCaseNoColumnIndex));

					if (!reader.IsDBNull(paidDateColumnIndex)) record.PaidDate =  Convert.ToDateTime(reader.GetValue(paidDateColumnIndex));

					if (!reader.IsDBNull(totalAmountPaidColumnIndex)) record.TotalAmountPaid =  Convert.ToDouble(reader.GetValue(totalAmountPaidColumnIndex));

					if (!reader.IsDBNull(amountColumnIndex)) record.Amount =  Convert.ToDouble(reader.GetValue(amountColumnIndex));

					if (!reader.IsDBNull(contractDateColumnIndex)) record.ContractDate =  Convert.ToDateTime(reader.GetValue(contractDateColumnIndex));

					if (!reader.IsDBNull(signingPlaceColumnIndex)) record.SigningPlace =  Convert.ToString(reader.GetValue(signingPlaceColumnIndex));

					if (!reader.IsDBNull(contractNoteColumnIndex)) record.ContractNote =  Convert.ToString(reader.GetValue(contractNoteColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(financialOfficerNoteColumnIndex)) record.FinancialOfficerNote =  Convert.ToString(reader.GetValue(financialOfficerNoteColumnIndex));

					if (!reader.IsDBNull(payerColumnIndex)) record.Payer =  Convert.ToString(reader.GetValue(payerColumnIndex));

					if (!reader.IsDBNull(payeeColumnIndex)) record.Payee =  Convert.ToString(reader.GetValue(payeeColumnIndex));

					if (!reader.IsDBNull(additionnalCourtNameColumnIndex)) record.AdditionnalCourtName =  Convert.ToString(reader.GetValue(additionnalCourtNameColumnIndex));

					if (!reader.IsDBNull(courtLevelColumnIndex)) record.CourtLevel =  Convert.ToString(reader.GetValue(courtLevelColumnIndex));

					if (!reader.IsDBNull(lawyerAddresslineColumnIndex)) record.LawyerAddressLine =  Convert.ToString(reader.GetValue(lawyerAddresslineColumnIndex));

					if (!reader.IsDBNull(bankAccountNameColumnIndex)) record.BankAccountName =  Convert.ToString(reader.GetValue(bankAccountNameColumnIndex));

					if (!reader.IsDBNull(bankAccountNoColumnIndex)) record.BankAccountNo =  Convert.ToString(reader.GetValue(bankAccountNoColumnIndex));

					if (!reader.IsDBNull(bankNameColumnIndex)) record.BankName =  Convert.ToString(reader.GetValue(bankNameColumnIndex));

					if (!reader.IsDBNull(bankbranchColumnIndex)) record.BankBranch =  Convert.ToString(reader.GetValue(bankbranchColumnIndex));

					if (!reader.IsDBNull(bankAccountTypeColumnIndex)) record.BankAccountType =  Convert.ToString(reader.GetValue(bankAccountTypeColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(deleteFlagColumnIndex)) record.DeleteFlag =  Convert.ToBoolean(reader.GetValue(deleteFlagColumnIndex));

					if (!reader.IsDBNull(transactionDateColumnIndex)) record.TransactionDate =  Convert.ToDateTime(reader.GetValue(transactionDateColumnIndex));

					if (!reader.IsDBNull(paymentListJsonColumnIndex)) record.PaymentListJson =  Convert.ToString(reader.GetValue(paymentListJsonColumnIndex));

					if (!reader.IsDBNull(transactionDetailColumnIndex)) record.TransactionDetail =  Convert.ToString(reader.GetValue(transactionDetailColumnIndex));

					if (!reader.IsDBNull(isCancelColumnIndex)) record.IsCancel =  Convert.ToBoolean(reader.GetValue(isCancelColumnIndex));

					if (!reader.IsDBNull(refTransactionIDColumnIndex)) record.RefTransactionID =  Convert.ToInt32(reader.GetValue(refTransactionIDColumnIndex));

					if (!reader.IsDBNull(refTransactionNoColumnIndex)) record.RefTransactionNo =  Convert.ToString(reader.GetValue(refTransactionNoColumnIndex));

					if (!reader.IsDBNull(jFPortalReceiveDateColumnIndex)) record.JFPortalReceiveDate =  Convert.ToDateTime(reader.GetValue(jFPortalReceiveDateColumnIndex));

					if (!reader.IsDBNull(isRequestRefundColumnIndex)) record.IsRequestRefund =  Convert.ToBoolean(reader.GetValue(isRequestRefundColumnIndex));

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
			return (View_TransactionRow[])(recordList.ToArray(typeof(View_TransactionRow)));
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
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ContractNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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
				case "TransactionAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ContractID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TransactionStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionStatusName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TransactionTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TrasactionTypeDesc":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RedNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BlackNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CourID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CourtName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TransactionNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "TranferDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "WorkStepID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Age":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "JFCaseNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "PaidDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "TotalAmountPaid":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Amount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ContractDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "SigningPlace":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ContractNote":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Note":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FinancialOfficerNote":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Payer":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Payee":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "AdditionnalCourtName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CourtLevel":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LawyerAddressLine":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankAccountName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankAccountNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankBranch":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankAccountType":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "DeleteFlag":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "TransactionDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "PaymentListJson":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TransactionDetail":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsCancel":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "RefTransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RefTransactionNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "JFPortalReceiveDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "IsRequestRefund":
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

