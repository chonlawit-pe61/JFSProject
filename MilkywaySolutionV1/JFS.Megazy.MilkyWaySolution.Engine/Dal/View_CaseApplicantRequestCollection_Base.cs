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
	public partial class View_CaseApplicantRequestCollection_Base : MarshalByRefObject
	{
		public const string TransactionIDColumnName = "TransactionID";
		public const string ReferenceMSCIDColumnName = "ReferenceMSCID";
		public const string ReferenceMSCCodeColumnName = "ReferenceMSCCode";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string SubjectColumnName = "Subject";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string GenderColumnName = "Gender";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string PostCodeColumnName = "PostCode";
		public const string CardIDColumnName = "CardID";
		public const string DefactiveColumnName = "Defactive";
		public const string RemarkColumnName = "Remark";
		public const string CreateDateColumnName = "CreateDate";
		public const string CentralColumnName = "Central";
		public const string EmailColumnName = "Email";
		public const string AttachFileIDColumnName = "AttachFileID";
		public const string AddressIDColumnName = "AddressID";
		public const string ChannelIDColumnName = "ChannelID";
		public const string ChannelNameColumnName = "ChannelName";
		public const string StatusIDColumnName = "StatusID";
		public const string RaceNameColumnName = "RaceName";
		public const string ReligionNameColumnName = "ReligionName";
		public const string NationalityCodeColumnName = "NationalityCode";
		public const string EducationColumnName = "Education";
		public const string RaceIDColumnName = "RaceID";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string EducationLevelColumnName = "EducationLevel";
		public const string ReligionIDColumnName = "ReligionID";
		public const string NationalityIDColumnName = "NationalityID";
		public const string IsAgreeColumnName = "IsAgree";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string OrgNameColumnName = "OrgName";
		public const string MemberIDColumnName = "MemberID";
		public const string MemberFirstNameColumnName = "MemberFirstName";
		public const string MemberLastNameColumnName = "MemberLastName";
		public const string FileGalleryColumnName = "FileGallery";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public View_CaseApplicantRequestCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_CaseApplicantRequestRow[] GetAll()
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
			"[ReferenceMSCID],"+
			"[ReferenceMSCCode],"+
			"[DepartmentID],"+
			"[Subject],"+
			"[TelephoneNo],"+
			"[Gender],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[PostCode],"+
			"[CardID],"+
			"[Defactive],"+
			"[Remark],"+
			"[CreateDate],"+
			"[Central],"+
			"[Email],"+
			"[AttachFileID],"+
			"[AddressID],"+
			"[ChannelID],"+
			"[ChannelName],"+
			"[StatusID],"+
			"[RaceName],"+
			"[ReligionName],"+
			"[NationalityCode],"+
			"[Education],"+
			"[RaceID],"+
			"[DateOfBirth],"+
			"[EducationLevel],"+
			"[ReligionID],"+
			"[NationalityID],"+
			"[IsAgree],"+
			"[DepartmentName],"+
			"[ProvinceID],"+
			"[ProvinceName],"+
			"[OrgName],"+
			"[MemberID],"+
			"[MemberFirstName],"+
			"[MemberLastName],"+
			"[FileGallery],"+
			"[ModifiedDate]"+
			" FROM [dbo].[View_CaseApplicantRequest]";
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
				TableName = "View_CaseApplicantRequest"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ReferenceMSCID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("PostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("Defactive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Central",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("AttachFileID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ChannelID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ChannelName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("StatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RaceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ReligionName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NationalityCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 3;
			dataColumn = dataTable.Columns.Add("Education",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("EducationLevel",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsAgree",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("OrgName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("MemberID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("MemberFirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MemberLastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FileGallery",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public View_CaseApplicantRequestRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_CaseApplicantRequestRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_CaseApplicantRequestRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_CaseApplicantRequestRow"/> objects.</returns>
		public virtual View_CaseApplicantRequestRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_CaseApplicantRequest]", top);
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
		public View_CaseApplicantRequestRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_CaseApplicantRequestRow[] rows = null;
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
		public DataTable GetView_CaseApplicantRequestPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_CaseApplicantRequest] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionID,ReferenceMSCID,ReferenceMSCCode,DepartmentID,Subject,TelephoneNo,Gender,Title,FirstName,LastName,PostCode,CardID,Defactive,Remark,CreateDate,Central,Email,AttachFileID,AddressID,ChannelID,ChannelName,StatusID,RaceName,ReligionName,NationalityCode,Education,RaceID,DateOfBirth,EducationLevel,ReligionID,NationalityID,IsAgree,DepartmentName,ProvinceID,ProvinceName,OrgName,MemberID,MemberFirstName,MemberLastName,FileGallery,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_CaseApplicantRequest].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_CaseApplicantRequest] " + whereSql +
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
		public View_CaseApplicantRequestItemsPaging GetView_CaseApplicantRequestPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
		View_CaseApplicantRequestItemsPaging obj = new View_CaseApplicantRequestItemsPaging();
		DataTable dt = GetView_CaseApplicantRequestPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_CaseApplicantRequestItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_CaseApplicantRequestItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			if (dt.Rows[i]["ReferenceMSCID"] != DBNull.Value)
			record.ReferenceMSCID = Convert.ToInt32(dt.Rows[i]["ReferenceMSCID"]);
			record.ReferenceMSCCode = dt.Rows[i]["ReferenceMSCCode"].ToString();
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.PostCode = dt.Rows[i]["PostCode"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			if (dt.Rows[i]["Defactive"] != DBNull.Value)
			record.Defactive = Convert.ToBoolean(dt.Rows[i]["Defactive"]);
			record.Remark = dt.Rows[i]["Remark"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			record.Central = dt.Rows[i]["Central"].ToString();
			record.Email = dt.Rows[i]["Email"].ToString();
			if (dt.Rows[i]["AttachFileID"] != DBNull.Value)
			record.AttachFileID = Convert.ToInt32(dt.Rows[i]["AttachFileID"]);
			if (dt.Rows[i]["AddressID"] != DBNull.Value)
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			if (dt.Rows[i]["ChannelID"] != DBNull.Value)
			record.ChannelID = Convert.ToInt32(dt.Rows[i]["ChannelID"]);
			record.ChannelName = dt.Rows[i]["ChannelName"].ToString();
			if (dt.Rows[i]["StatusID"] != DBNull.Value)
			record.StatusID = Convert.ToInt32(dt.Rows[i]["StatusID"]);
			record.RaceName = dt.Rows[i]["RaceName"].ToString();
			record.ReligionName = dt.Rows[i]["ReligionName"].ToString();
			record.NationalityCode = dt.Rows[i]["NationalityCode"].ToString();
			record.Education = dt.Rows[i]["Education"].ToString();
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["EducationLevel"] != DBNull.Value)
			record.EducationLevel = Convert.ToInt32(dt.Rows[i]["EducationLevel"]);
			if (dt.Rows[i]["ReligionID"] != DBNull.Value)
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			record.IsAgree = Convert.ToBoolean(dt.Rows[i]["IsAgree"]);
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			record.OrgName = dt.Rows[i]["OrgName"].ToString();
			if (dt.Rows[i]["MemberID"] != DBNull.Value)
			record.MemberID = Convert.ToInt32(dt.Rows[i]["MemberID"]);
			record.MemberFirstName = dt.Rows[i]["MemberFirstName"].ToString();
			record.MemberLastName = dt.Rows[i]["MemberLastName"].ToString();
			record.FileGallery = dt.Rows[i]["FileGallery"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.view_CaseApplicantRequestItems = (View_CaseApplicantRequestItems[])(recordList.ToArray(typeof(View_CaseApplicantRequestItems)));
		return obj;
		}
		protected View_CaseApplicantRequestRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_CaseApplicantRequestRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_CaseApplicantRequestRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int referenceMSCIDColumnIndex = reader.GetOrdinal("ReferenceMSCID");
			int referenceMSCCodeColumnIndex = reader.GetOrdinal("ReferenceMSCCode");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int defactiveColumnIndex = reader.GetOrdinal("Defactive");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int centralColumnIndex = reader.GetOrdinal("Central");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int attachFileIDColumnIndex = reader.GetOrdinal("AttachFileID");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int channelIDColumnIndex = reader.GetOrdinal("ChannelID");
			int channelNameColumnIndex = reader.GetOrdinal("ChannelName");
			int statusIDColumnIndex = reader.GetOrdinal("StatusID");
			int raceNameColumnIndex = reader.GetOrdinal("RaceName");
			int religionNameColumnIndex = reader.GetOrdinal("ReligionName");
			int nationalityCodeColumnIndex = reader.GetOrdinal("NationalityCode");
			int educationColumnIndex = reader.GetOrdinal("Education");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int educationLevelColumnIndex = reader.GetOrdinal("EducationLevel");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int isAgreeColumnIndex = reader.GetOrdinal("IsAgree");
			int departmentNameColumnIndex = reader.GetOrdinal("DepartmentName");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int orgNameColumnIndex = reader.GetOrdinal("OrgName");
			int memberIDColumnIndex = reader.GetOrdinal("MemberID");
			int memberFirstNameColumnIndex = reader.GetOrdinal("MemberFirstName");
			int memberLastNameColumnIndex = reader.GetOrdinal("MemberLastName");
			int fileGalleryColumnIndex = reader.GetOrdinal("FileGallery");
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
					View_CaseApplicantRequestRow record = new View_CaseApplicantRequestRow();
					recordList.Add(record);
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(referenceMSCIDColumnIndex)) record.ReferenceMSCID =  Convert.ToInt32(reader.GetValue(referenceMSCIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCCodeColumnIndex)) record.ReferenceMSCCode =  Convert.ToString(reader.GetValue(referenceMSCCodeColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(defactiveColumnIndex)) record.Defactive =  Convert.ToBoolean(reader.GetValue(defactiveColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(centralColumnIndex)) record.Central =  Convert.ToString(reader.GetValue(centralColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(attachFileIDColumnIndex)) record.AttachFileID =  Convert.ToInt32(reader.GetValue(attachFileIDColumnIndex));

					if (!reader.IsDBNull(addressIDColumnIndex)) record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));

					if (!reader.IsDBNull(channelIDColumnIndex)) record.ChannelID =  Convert.ToInt32(reader.GetValue(channelIDColumnIndex));

					if (!reader.IsDBNull(channelNameColumnIndex)) record.ChannelName =  Convert.ToString(reader.GetValue(channelNameColumnIndex));

					if (!reader.IsDBNull(statusIDColumnIndex)) record.StatusID =  Convert.ToInt32(reader.GetValue(statusIDColumnIndex));

					if (!reader.IsDBNull(raceNameColumnIndex)) record.RaceName =  Convert.ToString(reader.GetValue(raceNameColumnIndex));

					if (!reader.IsDBNull(religionNameColumnIndex)) record.ReligionName =  Convert.ToString(reader.GetValue(religionNameColumnIndex));

					if (!reader.IsDBNull(nationalityCodeColumnIndex)) record.NationalityCode =  Convert.ToString(reader.GetValue(nationalityCodeColumnIndex));

					if (!reader.IsDBNull(educationColumnIndex)) record.Education =  Convert.ToString(reader.GetValue(educationColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(educationLevelColumnIndex)) record.EducationLevel =  Convert.ToInt32(reader.GetValue(educationLevelColumnIndex));

					if (!reader.IsDBNull(religionIDColumnIndex)) record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

					record.IsAgree =  Convert.ToBoolean(reader.GetValue(isAgreeColumnIndex));
					if (!reader.IsDBNull(departmentNameColumnIndex)) record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(orgNameColumnIndex)) record.OrgName =  Convert.ToString(reader.GetValue(orgNameColumnIndex));

					if (!reader.IsDBNull(memberIDColumnIndex)) record.MemberID =  Convert.ToInt32(reader.GetValue(memberIDColumnIndex));

					if (!reader.IsDBNull(memberFirstNameColumnIndex)) record.MemberFirstName =  Convert.ToString(reader.GetValue(memberFirstNameColumnIndex));

					if (!reader.IsDBNull(memberLastNameColumnIndex)) record.MemberLastName =  Convert.ToString(reader.GetValue(memberLastNameColumnIndex));

					if (!reader.IsDBNull(fileGalleryColumnIndex)) record.FileGallery =  Convert.ToString(reader.GetValue(fileGalleryColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_CaseApplicantRequestRow[])(recordList.ToArray(typeof(View_CaseApplicantRequestRow)));
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
				case "ReferenceMSCID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Gender":
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
				case "PostCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Defactive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Central":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AttachFileID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ChannelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ChannelName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "StatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RaceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReligionName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "NationalityCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Education":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "EducationLevel":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsAgree":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "DepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "OrgName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "MemberID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MemberFirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "MemberLastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FileGallery":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

