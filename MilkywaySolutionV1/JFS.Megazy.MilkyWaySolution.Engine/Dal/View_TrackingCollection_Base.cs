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
	public partial class View_TrackingCollection_Base : MarshalByRefObject
	{
		public const string AccusedTrackingIDColumnName = "AccusedTrackingID";
		public const string CaseIDColumnName = "CaseID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string StartDateColumnName = "StartDate";
		public const string EndDateColumnName = "EndDate";
		public const string LastReportDateColumnName = "LastReportDate";
		public const string DueDateColumnName = "DueDate";
		public const string OverDueColumnName = "OverDue";
		public const string SubjectColumnName = "Subject";
		public const string CaseTypeNameColumnName = "CaseTypeName";
		public const string CaseTypeNameAbbrColumnName = "CaseTypeNameAbbr";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string DepartmentNameAbbrColumnName = "DepartmentNameAbbr";
		public const string JFCaseNoColumnName = "JFCaseNo";
		public const string GenderColumnName = "Gender";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string CardIDColumnName = "CardID";
		public const string NoteColumnName = "Note";
		public const string IsCompleteColumnName = "IsComplete";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string JFCaseTypeIDColumnName = "JFCaseTypeID";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string SuretyFirstNameColumnName = "SuretyFirstName";
		public const string SuretyLastNameColumnName = "SuretyLastName";
		public const string SuretyTelephoneNoColumnName = "SuretyTelephoneNo";
		public const string SuretyAddressColumnName = "SuretyAddress";
		public const string ContractNoColumnName = "ContractNo";
		public const string ContractIDColumnName = "ContractID";
		private int _processID;
		public SqlCommand cmd = null;
		public View_TrackingCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_TrackingRow[] GetAll()
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
			"[AccusedTrackingID],"+
			"[CaseID],"+
			"[DepartmentID],"+
			"[ApplicantID],"+
			"[StartDate],"+
			"[EndDate],"+
			"[LastReportDate],"+
			"[DueDate],"+
			"[OverDue],"+
			"[Subject],"+
			"[CaseTypeName],"+
			"[CaseTypeNameAbbr],"+
			"[DepartmentName],"+
			"[DepartmentNameAbbr],"+
			"[JFCaseNo],"+
			"[Gender],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[CardID],"+
			"[Note],"+
			"[IsComplete],"+
			"[ModifiedDate],"+
			"[JFCaseTypeID],"+
			"[ProvinceID],"+
			"[SuretyFirstName],"+
			"[SuretyLastName],"+
			"[SuretyTelephoneNo],"+
			"[SuretyAddress],"+
			"[ContractNo],"+
			"[ContractID]"+
			" FROM [dbo].[View_Tracking]";
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
				TableName = "View_Tracking"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("AccusedTrackingID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("StartDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("EndDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("LastReportDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("DueDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("OverDue",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CaseTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CaseTypeNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("DepartmentNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("JFCaseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("IsComplete",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("JFCaseTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SuretyFirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SuretyLastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SuretyTelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SuretyAddress",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("ContractNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ContractID",Type.GetType("System.Int32"));
			return dataTable;
		}
		public View_TrackingRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_TrackingRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_TrackingRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_TrackingRow"/> objects.</returns>
		public virtual View_TrackingRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_Tracking]", top);
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
		public View_TrackingRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_TrackingRow[] rows = null;
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
		public DataTable GetView_TrackingPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AccusedTrackingID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "AccusedTrackingID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_Tracking] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,AccusedTrackingID,CaseID,DepartmentID,ApplicantID,StartDate,EndDate,LastReportDate,DueDate,OverDue,Subject,CaseTypeName,CaseTypeNameAbbr,DepartmentName,DepartmentNameAbbr,JFCaseNo,Gender,Title,FirstName,LastName,CardID,Note,IsComplete,ModifiedDate,JFCaseTypeID,ProvinceID,SuretyFirstName,SuretyLastName,SuretyTelephoneNo,SuretyAddress,ContractNo,ContractID," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_Tracking].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_Tracking] " + whereSql +
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
		public View_TrackingItemsPaging GetView_TrackingPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AccusedTrackingID")
		{
		View_TrackingItemsPaging obj = new View_TrackingItemsPaging();
		DataTable dt = GetView_TrackingPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_TrackingItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_TrackingItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.AccusedTrackingID = Convert.ToInt32(dt.Rows[i]["AccusedTrackingID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["StartDate"] != DBNull.Value)
			record.StartDate = Convert.ToDateTime(dt.Rows[i]["StartDate"]);
			if (dt.Rows[i]["EndDate"] != DBNull.Value)
			record.EndDate = Convert.ToDateTime(dt.Rows[i]["EndDate"]);
			if (dt.Rows[i]["LastReportDate"] != DBNull.Value)
			record.LastReportDate = Convert.ToDateTime(dt.Rows[i]["LastReportDate"]);
			if (dt.Rows[i]["DueDate"] != DBNull.Value)
			record.DueDate = Convert.ToDateTime(dt.Rows[i]["DueDate"]);
			if (dt.Rows[i]["OverDue"] != DBNull.Value)
			record.OverDue = Convert.ToInt32(dt.Rows[i]["OverDue"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.CaseTypeName = dt.Rows[i]["CaseTypeName"].ToString();
			record.CaseTypeNameAbbr = dt.Rows[i]["CaseTypeNameAbbr"].ToString();
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			record.DepartmentNameAbbr = dt.Rows[i]["DepartmentNameAbbr"].ToString();
			record.JFCaseNo = dt.Rows[i]["JFCaseNo"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.Note = dt.Rows[i]["Note"].ToString();
			if (dt.Rows[i]["IsComplete"] != DBNull.Value)
			record.IsComplete = Convert.ToBoolean(dt.Rows[i]["IsComplete"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["JFCaseTypeID"] != DBNull.Value)
			record.JFCaseTypeID = Convert.ToInt32(dt.Rows[i]["JFCaseTypeID"]);
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.SuretyFirstName = dt.Rows[i]["SuretyFirstName"].ToString();
			record.SuretyLastName = dt.Rows[i]["SuretyLastName"].ToString();
			record.SuretyTelephoneNo = dt.Rows[i]["SuretyTelephoneNo"].ToString();
			record.SuretyAddress = dt.Rows[i]["SuretyAddress"].ToString();
			record.ContractNo = dt.Rows[i]["ContractNo"].ToString();
			if (dt.Rows[i]["ContractID"] != DBNull.Value)
			record.ContractID = Convert.ToInt32(dt.Rows[i]["ContractID"]);
			recordList.Add(record);
		}
		obj.view_TrackingItems = (View_TrackingItems[])(recordList.ToArray(typeof(View_TrackingItems)));
		return obj;
		}
		protected View_TrackingRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_TrackingRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_TrackingRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int accusedTrackingIDColumnIndex = reader.GetOrdinal("AccusedTrackingID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int startDateColumnIndex = reader.GetOrdinal("StartDate");
			int endDateColumnIndex = reader.GetOrdinal("EndDate");
			int lastReportDateColumnIndex = reader.GetOrdinal("LastReportDate");
			int duedateColumnIndex = reader.GetOrdinal("DueDate");
			int overDueColumnIndex = reader.GetOrdinal("OverDue");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int caseTypeNameColumnIndex = reader.GetOrdinal("CaseTypeName");
			int caseTypeNameAbbrColumnIndex = reader.GetOrdinal("CaseTypeNameAbbr");
			int departmentNameColumnIndex = reader.GetOrdinal("DepartmentName");
			int departmentNameAbbrColumnIndex = reader.GetOrdinal("DepartmentNameAbbr");
			int jFCaseNoColumnIndex = reader.GetOrdinal("JFCaseNo");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int noteColumnIndex = reader.GetOrdinal("Note");
			int isCompleteColumnIndex = reader.GetOrdinal("IsComplete");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int jFCaseTypeIDColumnIndex = reader.GetOrdinal("JFCaseTypeID");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int suretyFirstNameColumnIndex = reader.GetOrdinal("SuretyFirstName");
			int suretyLastNameColumnIndex = reader.GetOrdinal("SuretyLastName");
			int suretyTelephoneNoColumnIndex = reader.GetOrdinal("SuretyTelephoneNo");
			int suretyAddressColumnIndex = reader.GetOrdinal("SuretyAddress");
			int contractNoColumnIndex = reader.GetOrdinal("ContractNo");
			int contractIDColumnIndex = reader.GetOrdinal("ContractID");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_TrackingRow record = new View_TrackingRow();
					recordList.Add(record);
					record.AccusedTrackingID =  Convert.ToInt32(reader.GetValue(accusedTrackingIDColumnIndex));
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(startDateColumnIndex)) record.StartDate =  Convert.ToDateTime(reader.GetValue(startDateColumnIndex));

					if (!reader.IsDBNull(endDateColumnIndex)) record.EndDate =  Convert.ToDateTime(reader.GetValue(endDateColumnIndex));

					if (!reader.IsDBNull(lastReportDateColumnIndex)) record.LastReportDate =  Convert.ToDateTime(reader.GetValue(lastReportDateColumnIndex));

					if (!reader.IsDBNull(duedateColumnIndex)) record.DueDate =  Convert.ToDateTime(reader.GetValue(duedateColumnIndex));

					if (!reader.IsDBNull(overDueColumnIndex)) record.OverDue =  Convert.ToInt32(reader.GetValue(overDueColumnIndex));

					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					if (!reader.IsDBNull(caseTypeNameColumnIndex)) record.CaseTypeName =  Convert.ToString(reader.GetValue(caseTypeNameColumnIndex));

					if (!reader.IsDBNull(caseTypeNameAbbrColumnIndex)) record.CaseTypeNameAbbr =  Convert.ToString(reader.GetValue(caseTypeNameAbbrColumnIndex));

					if (!reader.IsDBNull(departmentNameColumnIndex)) record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));

					if (!reader.IsDBNull(departmentNameAbbrColumnIndex)) record.DepartmentNameAbbr =  Convert.ToString(reader.GetValue(departmentNameAbbrColumnIndex));

					if (!reader.IsDBNull(jFCaseNoColumnIndex)) record.JFCaseNo =  Convert.ToString(reader.GetValue(jFCaseNoColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(isCompleteColumnIndex)) record.IsComplete =  Convert.ToBoolean(reader.GetValue(isCompleteColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(jFCaseTypeIDColumnIndex)) record.JFCaseTypeID =  Convert.ToInt32(reader.GetValue(jFCaseTypeIDColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(suretyFirstNameColumnIndex)) record.SuretyFirstName =  Convert.ToString(reader.GetValue(suretyFirstNameColumnIndex));

					if (!reader.IsDBNull(suretyLastNameColumnIndex)) record.SuretyLastName =  Convert.ToString(reader.GetValue(suretyLastNameColumnIndex));

					if (!reader.IsDBNull(suretyTelephoneNoColumnIndex)) record.SuretyTelephoneNo =  Convert.ToString(reader.GetValue(suretyTelephoneNoColumnIndex));

					if (!reader.IsDBNull(suretyAddressColumnIndex)) record.SuretyAddress =  Convert.ToString(reader.GetValue(suretyAddressColumnIndex));

					if (!reader.IsDBNull(contractNoColumnIndex)) record.ContractNo =  Convert.ToString(reader.GetValue(contractNoColumnIndex));

					if (!reader.IsDBNull(contractIDColumnIndex)) record.ContractID =  Convert.ToInt32(reader.GetValue(contractIDColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_TrackingRow[])(recordList.ToArray(typeof(View_TrackingRow)));
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
				case "AccusedTrackingID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "StartDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "EndDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "LastReportDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "DueDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "OverDue":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseTypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseTypeNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "JFCaseNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Note":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsComplete":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "JFCaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SuretyFirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SuretyLastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SuretyTelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SuretyAddress":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ContractNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ContractID":
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

