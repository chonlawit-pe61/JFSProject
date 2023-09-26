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
	public partial class View_CaseApplicationMemberMapping2Collection_Base
	{
		public const string CaseIDColumnName = "CaseID";
		public const string MemberIDColumnName = "MemberID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string ReferenceMSCIDColumnName = "ReferenceMSCID";
		public const string OwnerDepartmentIDColumnName = "OwnerDepartmentID";
		public const string SubjectColumnName = "Subject";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string GenderColumnName = "Gender";
		public const string RequestAmountColumnName = "RequestAmount";
		public const string DeletedFlagColumnName = "DeletedFlag";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string StatusIDColumnName = "StatusID";
		public const string CaseApplicationStatusNameColumnName = "CaseApplicationStatusName";
		public const string WorkStepIDColumnName = "WorkStepID";
		public const string WorkStepNameColumnName = "WorkStepName";
		public const string ReferenceDepartmentIDColumnName = "ReferenceDepartmentID";
		public const string MemberFirstNameColumnName = "MemberFirstName";
		public const string MemberLastNameColumnName = "MemberLastName";
		public const string OrgNameColumnName = "OrgName";
		public const string MemberGenderColumnName = "MemberGender";
		public const string EmailColumnName = "Email";
		public const string PhoneNumberColumnName = "PhoneNumber";
		public const string CreateDateColumnName = "CreateDate";
		private int _processID;
		public SqlCommand cmd = null;
		public View_CaseApplicationMemberMapping2Collection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_CaseApplicationMemberMapping2Row[] GetAll()
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
			"[MemberID],"+
			"[ApplicantID],"+
			"[ReferenceMSCID],"+
			"[OwnerDepartmentID],"+
			"[Subject],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[Gender],"+
			"[RequestAmount],"+
			"[DeletedFlag],"+
			"[DepartmentID],"+
			"[StatusID],"+
			"[CaseApplicationStatusName],"+
			"[WorkStepID],"+
			"[WorkStepName],"+
			"[ReferenceDepartmentID],"+
			"[MemberFirstName],"+
			"[MemberLastName],"+
			"[OrgName],"+
			"[MemberGender],"+
			"[Email],"+
			"[PhoneNumber],"+
			"[CreateDate]"+
			" FROM [dbo].[View_CaseApplicationMemberMapping2]";
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
				TableName = "View_CaseApplicationMemberMapping2"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MemberID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("OwnerDepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("RequestAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("DeletedFlag",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("StatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CaseApplicationStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("WorkStepID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("WorkStepName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ReferenceDepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("MemberFirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MemberLastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OrgName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("MemberGender",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("PhoneNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public View_CaseApplicationMemberMapping2Row[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_CaseApplicationMemberMapping2Row[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_CaseApplicationMemberMapping2Row"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_CaseApplicationMemberMapping2Row"/> objects.</returns>
		public virtual View_CaseApplicationMemberMapping2Row[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_CaseApplicationMemberMapping2]", top);
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
		public View_CaseApplicationMemberMapping2Row GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_CaseApplicationMemberMapping2Row[] rows = null;
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
		public DataTable GetView_CaseApplicationMemberMapping2PagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
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
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[View_CaseApplicationMemberMapping2] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,MemberID,ApplicantID,ReferenceMSCID,OwnerDepartmentID,Subject,Title,FirstName,LastName,Gender,RequestAmount,DeletedFlag,DepartmentID,StatusID,CaseApplicationStatusName,WorkStepID,WorkStepName,ReferenceDepartmentID,MemberFirstName,MemberLastName,OrgName,MemberGender,Email,PhoneNumber,CreateDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_CaseApplicationMemberMapping2] " + whereSql +
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
		public View_CaseApplicationMemberMapping2ItemsPaging GetView_CaseApplicationMemberMapping2PagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		View_CaseApplicationMemberMapping2ItemsPaging obj = new View_CaseApplicationMemberMapping2ItemsPaging();
		DataTable dt = GetView_CaseApplicationMemberMapping2PagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_CaseApplicationMemberMapping2Items record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_CaseApplicationMemberMapping2Items();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.MemberID = Convert.ToInt32(dt.Rows[i]["MemberID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["ReferenceMSCID"] != DBNull.Value)
			record.ReferenceMSCID = Convert.ToInt32(dt.Rows[i]["ReferenceMSCID"]);
			if (dt.Rows[i]["OwnerDepartmentID"] != DBNull.Value)
			record.OwnerDepartmentID = Convert.ToInt32(dt.Rows[i]["OwnerDepartmentID"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			if (dt.Rows[i]["RequestAmount"] != DBNull.Value)
			record.RequestAmount = Convert.ToDouble(dt.Rows[i]["RequestAmount"]);
			record.DeletedFlag = Convert.ToBoolean(dt.Rows[i]["DeletedFlag"]);
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			if (dt.Rows[i]["StatusID"] != DBNull.Value)
			record.StatusID = Convert.ToInt32(dt.Rows[i]["StatusID"]);
			record.CaseApplicationStatusName = dt.Rows[i]["CaseApplicationStatusName"].ToString();
			if (dt.Rows[i]["WorkStepID"] != DBNull.Value)
			record.WorkStepID = Convert.ToInt32(dt.Rows[i]["WorkStepID"]);
			record.WorkStepName = dt.Rows[i]["WorkStepName"].ToString();
			if (dt.Rows[i]["ReferenceDepartmentID"] != DBNull.Value)
			record.ReferenceDepartmentID = Convert.ToInt32(dt.Rows[i]["ReferenceDepartmentID"]);
			record.MemberFirstName = dt.Rows[i]["MemberFirstName"].ToString();
			record.MemberLastName = dt.Rows[i]["MemberLastName"].ToString();
			record.OrgName = dt.Rows[i]["OrgName"].ToString();
			if (dt.Rows[i]["MemberGender"] != DBNull.Value)
			record.MemberGender = Convert.ToInt32(dt.Rows[i]["MemberGender"]);
			record.Email = dt.Rows[i]["Email"].ToString();
			record.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			recordList.Add(record);
		}
		obj.view_CaseApplicationMemberMapping2Items = (View_CaseApplicationMemberMapping2Items[])(recordList.ToArray(typeof(View_CaseApplicationMemberMapping2Items)));
		return obj;
		}
		protected View_CaseApplicationMemberMapping2Row[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_CaseApplicationMemberMapping2Row[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_CaseApplicationMemberMapping2Row[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int memberIDColumnIndex = reader.GetOrdinal("MemberID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int referenceMSCIDColumnIndex = reader.GetOrdinal("ReferenceMSCID");
			int ownerDepartmentIDColumnIndex = reader.GetOrdinal("OwnerDepartmentID");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int requestAmountColumnIndex = reader.GetOrdinal("RequestAmount");
			int deletedFlagColumnIndex = reader.GetOrdinal("DeletedFlag");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int statusIDColumnIndex = reader.GetOrdinal("StatusID");
			int caseApplicationStatusNameColumnIndex = reader.GetOrdinal("CaseApplicationStatusName");
			int workStepIDColumnIndex = reader.GetOrdinal("WorkStepID");
			int workStepNameColumnIndex = reader.GetOrdinal("WorkStepName");
			int referenceDepartmentIDColumnIndex = reader.GetOrdinal("ReferenceDepartmentID");
			int memberFirstNameColumnIndex = reader.GetOrdinal("MemberFirstName");
			int memberLastNameColumnIndex = reader.GetOrdinal("MemberLastName");
			int orgNameColumnIndex = reader.GetOrdinal("OrgName");
			int memberGenderColumnIndex = reader.GetOrdinal("MemberGender");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int phoneNumberColumnIndex = reader.GetOrdinal("PhoneNumber");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_CaseApplicationMemberMapping2Row record = new View_CaseApplicationMemberMapping2Row();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.MemberID =  Convert.ToInt32(reader.GetValue(memberIDColumnIndex));
					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCIDColumnIndex)) record.ReferenceMSCID =  Convert.ToInt32(reader.GetValue(referenceMSCIDColumnIndex));

					if (!reader.IsDBNull(ownerDepartmentIDColumnIndex)) record.OwnerDepartmentID =  Convert.ToInt32(reader.GetValue(ownerDepartmentIDColumnIndex));

					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(requestAmountColumnIndex)) record.RequestAmount =  Convert.ToDouble(reader.GetValue(requestAmountColumnIndex));

					record.DeletedFlag =  Convert.ToBoolean(reader.GetValue(deletedFlagColumnIndex));
					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(statusIDColumnIndex)) record.StatusID =  Convert.ToInt32(reader.GetValue(statusIDColumnIndex));

					if (!reader.IsDBNull(caseApplicationStatusNameColumnIndex)) record.CaseApplicationStatusName =  Convert.ToString(reader.GetValue(caseApplicationStatusNameColumnIndex));

					if (!reader.IsDBNull(workStepIDColumnIndex)) record.WorkStepID =  Convert.ToInt32(reader.GetValue(workStepIDColumnIndex));

					if (!reader.IsDBNull(workStepNameColumnIndex)) record.WorkStepName =  Convert.ToString(reader.GetValue(workStepNameColumnIndex));

					if (!reader.IsDBNull(referenceDepartmentIDColumnIndex)) record.ReferenceDepartmentID =  Convert.ToInt32(reader.GetValue(referenceDepartmentIDColumnIndex));

					if (!reader.IsDBNull(memberFirstNameColumnIndex)) record.MemberFirstName =  Convert.ToString(reader.GetValue(memberFirstNameColumnIndex));

					if (!reader.IsDBNull(memberLastNameColumnIndex)) record.MemberLastName =  Convert.ToString(reader.GetValue(memberLastNameColumnIndex));

					if (!reader.IsDBNull(orgNameColumnIndex)) record.OrgName =  Convert.ToString(reader.GetValue(orgNameColumnIndex));

					if (!reader.IsDBNull(memberGenderColumnIndex)) record.MemberGender =  Convert.ToInt32(reader.GetValue(memberGenderColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(phoneNumberColumnIndex)) record.PhoneNumber =  Convert.ToString(reader.GetValue(phoneNumberColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

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
			return (View_CaseApplicationMemberMapping2Row[])(recordList.ToArray(typeof(View_CaseApplicationMemberMapping2Row)));
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
				case "MemberID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OwnerDepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RequestAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "DeletedFlag":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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
				case "ReferenceDepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MemberFirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "MemberLastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "OrgName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "MemberGender":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "PhoneNumber":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CreateDate":
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

