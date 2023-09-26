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
	public partial class View_LawyerCollection_Base : MarshalByRefObject
	{
		public const string LawyerIDColumnName = "LawyerID";
		public const string LawyerTypeIDColumnName = "LawyerTypeID";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string CardIDColumnName = "CardID";
		public const string GenderColumnName = "Gender";
		public const string LicenseNoColumnName = "LicenseNo";
		public const string LicenseTypeColumnName = "LicenseType";
		public const string IssueDateColumnName = "IssueDate";
		public const string ExprieDateColumnName = "ExprieDate";
		public const string EmailColumnName = "Email";
		public const string MobileNoColumnName = "MobileNo";
		public const string EducationColumnName = "Education";
		public const string RemarkColumnName = "Remark";
		public const string NumberOfConductCaseColumnName = "NumberOfConductCase";
		public const string YearsExperienceColumnName = "YearsExperience";
		public const string RegisterDateColumnName = "RegisterDate";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string LawyerStatusIDColumnName = "LawyerStatusID";
		public const string LawyerStatusNameColumnName = "LawyerStatusName";
		public const string AddressIDColumnName = "AddressID";
		public const string AddressTypeIDColumnName = "AddressTypeID";
		public const string FaxNoColumnName = "FaxNo";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string IsPrimaryColumnName = "IsPrimary";
		public const string IsActiveColumnName = "IsActive";
		public const string Address1ColumnName = "Address1";
		public const string HouseNoColumnName = "HouseNo";
		public const string VillageNoColumnName = "VillageNo";
		public const string StreetColumnName = "Street";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string LawyerProvinceNameColumnName = "LawyerProvinceName";
		public const string DisctrictIDColumnName = "DisctrictID";
		public const string SubdistrictIDColumnName = "SubdistrictID";
		public const string PostCodeColumnName = "PostCode";
		public const string LawyerOfficeIDColumnName = "LawyerOfficeID";
		public const string LawyerFirmNameColumnName = "LawyerFirmName";
		public const string FirmelephoneNoColumnName = "FirmelephoneNo";
		public const string FirmFaxNoColumnName = "FirmFaxNo";
		public const string FirmEmailColumnName = "FirmEmail";
		public const string FirmIsActiveColumnName = "FirmIsActive";
		public const string LawyerTypeNameColumnName = "LawyerTypeName";
		public const string TerritoryColumnName = "Territory";
		public const string EnrollmentYearColumnName = "EnrollmentYear";
		private int _processID;
		public SqlCommand cmd = null;
		public View_LawyerCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_LawyerRow[] GetAll()
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
			"[LawyerID],"+
			"[LawyerTypeID],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[CardID],"+
			"[Gender],"+
			"[LicenseNo],"+
			"[LicenseType],"+
			"[IssueDate],"+
			"[ExprieDate],"+
			"[Email],"+
			"[MobileNo],"+
			"[Education],"+
			"[Remark],"+
			"[NumberOfConductCase],"+
			"[YearsExperience],"+
			"[RegisterDate],"+
			"[DateOfBirth],"+
			"[ModifiedDate],"+
			"[LawyerStatusID],"+
			"[LawyerStatusName],"+
			"[AddressID],"+
			"[AddressTypeID],"+
			"[FaxNo],"+
			"[TelephoneNo],"+
			"[IsPrimary],"+
			"[IsActive],"+
			"[Address1],"+
			"[HouseNo],"+
			"[VillageNo],"+
			"[Street],"+
			"[ProvinceID],"+
			"[LawyerProvinceName],"+
			"[DisctrictID],"+
			"[SubdistrictID],"+
			"[PostCode],"+
			"[LawyerOfficeID],"+
			"[LawyerFirmName],"+
			"[FirmelephoneNo],"+
			"[FirmFaxNo],"+
			"[FirmEmail],"+
			"[FirmIsActive],"+
			"[LawyerTypeName],"+
			"[Territory],"+
			"[EnrollmentYear]"+
			" FROM [dbo].[View_Lawyer]";
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
				TableName = "View_Lawyer"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("LawyerID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LawyerTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("LicenseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LicenseType",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("IssueDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ExprieDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("MobileNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Education",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("NumberOfConductCase",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("YearsExperience",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RegisterDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("LawyerStatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("LawyerStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("AddressTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FaxNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsPrimary",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Address1",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("HouseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("VillageNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Street",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("LawyerProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DisctrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SubdistrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("PostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("LawyerOfficeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("LawyerFirmName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("FirmelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirmFaxNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirmEmail",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("FirmIsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("LawyerTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Territory",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("EnrollmentYear",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			return dataTable;
		}
		public View_LawyerRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_LawyerRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_LawyerRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_LawyerRow"/> objects.</returns>
		public virtual View_LawyerRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_Lawyer]", top);
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
		public View_LawyerRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_LawyerRow[] rows = null;
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
		public DataTable GetView_LawyerPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LawyerID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "LawyerID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_Lawyer] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,LawyerID,LawyerTypeID,Title,FirstName,LastName,CardID,Gender,LicenseNo,LicenseType,IssueDate,ExprieDate,Email,MobileNo,Education,Remark,NumberOfConductCase,YearsExperience,RegisterDate,DateOfBirth,ModifiedDate,LawyerStatusID,LawyerStatusName,AddressID,AddressTypeID,FaxNo,TelephoneNo,IsPrimary,IsActive,Address1,HouseNo,VillageNo,Street,ProvinceID,LawyerProvinceName,DisctrictID,SubdistrictID,PostCode,LawyerOfficeID,LawyerFirmName,FirmelephoneNo,FirmFaxNo,FirmEmail,FirmIsActive,LawyerTypeName,Territory,EnrollmentYear," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_Lawyer].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_Lawyer] " + whereSql +
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
		public View_LawyerItemsPaging GetView_LawyerPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LawyerID")
		{
		View_LawyerItemsPaging obj = new View_LawyerItemsPaging();
		DataTable dt = GetView_LawyerPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_LawyerItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_LawyerItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.LawyerID = Convert.ToInt32(dt.Rows[i]["LawyerID"]);
			if (dt.Rows[i]["LawyerTypeID"] != DBNull.Value)
			record.LawyerTypeID = Convert.ToInt32(dt.Rows[i]["LawyerTypeID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.LicenseNo = dt.Rows[i]["LicenseNo"].ToString();
			record.LicenseType = dt.Rows[i]["LicenseType"].ToString();
			if (dt.Rows[i]["IssueDate"] != DBNull.Value)
			record.IssueDate = Convert.ToDateTime(dt.Rows[i]["IssueDate"]);
			if (dt.Rows[i]["ExprieDate"] != DBNull.Value)
			record.ExprieDate = Convert.ToDateTime(dt.Rows[i]["ExprieDate"]);
			record.Email = dt.Rows[i]["Email"].ToString();
			record.MobileNo = dt.Rows[i]["MobileNo"].ToString();
			record.Education = dt.Rows[i]["Education"].ToString();
			record.Remark = dt.Rows[i]["Remark"].ToString();
			if (dt.Rows[i]["NumberOfConductCase"] != DBNull.Value)
			record.NumberOfConductCase = Convert.ToInt32(dt.Rows[i]["NumberOfConductCase"]);
			if (dt.Rows[i]["YearsExperience"] != DBNull.Value)
			record.YearsExperience = Convert.ToInt32(dt.Rows[i]["YearsExperience"]);
			if (dt.Rows[i]["RegisterDate"] != DBNull.Value)
			record.RegisterDate = Convert.ToDateTime(dt.Rows[i]["RegisterDate"]);
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["LawyerStatusID"] != DBNull.Value)
			record.LawyerStatusID = Convert.ToInt32(dt.Rows[i]["LawyerStatusID"]);
			record.LawyerStatusName = dt.Rows[i]["LawyerStatusName"].ToString();
			if (dt.Rows[i]["AddressID"] != DBNull.Value)
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			if (dt.Rows[i]["AddressTypeID"] != DBNull.Value)
			record.AddressTypeID = Convert.ToInt32(dt.Rows[i]["AddressTypeID"]);
			record.FaxNo = dt.Rows[i]["FaxNo"].ToString();
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			if (dt.Rows[i]["IsPrimary"] != DBNull.Value)
			record.IsPrimary = Convert.ToBoolean(dt.Rows[i]["IsPrimary"]);
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			record.Address1 = dt.Rows[i]["Address1"].ToString();
			record.HouseNo = dt.Rows[i]["HouseNo"].ToString();
			record.VillageNo = dt.Rows[i]["VillageNo"].ToString();
			record.Street = dt.Rows[i]["Street"].ToString();
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.LawyerProvinceName = dt.Rows[i]["LawyerProvinceName"].ToString();
			if (dt.Rows[i]["DisctrictID"] != DBNull.Value)
			record.DisctrictID = Convert.ToInt32(dt.Rows[i]["DisctrictID"]);
			if (dt.Rows[i]["SubdistrictID"] != DBNull.Value)
			record.SubdistrictID = Convert.ToInt32(dt.Rows[i]["SubdistrictID"]);
			record.PostCode = dt.Rows[i]["PostCode"].ToString();
			if (dt.Rows[i]["LawyerOfficeID"] != DBNull.Value)
			record.LawyerOfficeID = Convert.ToInt32(dt.Rows[i]["LawyerOfficeID"]);
			record.LawyerFirmName = dt.Rows[i]["LawyerFirmName"].ToString();
			record.FirmelephoneNo = dt.Rows[i]["FirmelephoneNo"].ToString();
			record.FirmFaxNo = dt.Rows[i]["FirmFaxNo"].ToString();
			record.FirmEmail = dt.Rows[i]["FirmEmail"].ToString();
			if (dt.Rows[i]["FirmIsActive"] != DBNull.Value)
			record.FirmIsActive = Convert.ToBoolean(dt.Rows[i]["FirmIsActive"]);
			record.LawyerTypeName = dt.Rows[i]["LawyerTypeName"].ToString();
			record.Territory = dt.Rows[i]["Territory"].ToString();
			record.EnrollmentYear = dt.Rows[i]["EnrollmentYear"].ToString();
			recordList.Add(record);
		}
		obj.view_LawyerItems = (View_LawyerItems[])(recordList.ToArray(typeof(View_LawyerItems)));
		return obj;
		}
		public View_LawyerRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			View_LawyerRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected View_LawyerRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_LawyerRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_LawyerRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int lawyerIDColumnIndex = reader.GetOrdinal("LawyerID");
			int lawyerTypeIDColumnIndex = reader.GetOrdinal("LawyerTypeID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int licenseNoColumnIndex = reader.GetOrdinal("LicenseNo");
			int licenseTypeColumnIndex = reader.GetOrdinal("LicenseType");
			int issueDateColumnIndex = reader.GetOrdinal("IssueDate");
			int exprieDateColumnIndex = reader.GetOrdinal("ExprieDate");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int mobileNoColumnIndex = reader.GetOrdinal("MobileNo");
			int educationColumnIndex = reader.GetOrdinal("Education");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
			int numberOfConductCaseColumnIndex = reader.GetOrdinal("NumberOfConductCase");
			int yearsExperienceColumnIndex = reader.GetOrdinal("YearsExperience");
			int registerDateColumnIndex = reader.GetOrdinal("RegisterDate");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int lawyerStatusIDColumnIndex = reader.GetOrdinal("LawyerStatusID");
			int lawyerStatusNameColumnIndex = reader.GetOrdinal("LawyerStatusName");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int addressTypeIDColumnIndex = reader.GetOrdinal("AddressTypeID");
			int faxNoColumnIndex = reader.GetOrdinal("FaxNo");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int isPrimaryColumnIndex = reader.GetOrdinal("IsPrimary");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int address1ColumnIndex = reader.GetOrdinal("Address1");
			int houseNoColumnIndex = reader.GetOrdinal("HouseNo");
			int villageNoColumnIndex = reader.GetOrdinal("VillageNo");
			int streetColumnIndex = reader.GetOrdinal("Street");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int lawyerProvinceNameColumnIndex = reader.GetOrdinal("LawyerProvinceName");
			int disctrictIdColumnIndex = reader.GetOrdinal("DisctrictID");
			int subdistrictIDColumnIndex = reader.GetOrdinal("SubdistrictID");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			int lawyerOfficeIDColumnIndex = reader.GetOrdinal("LawyerOfficeID");
			int lawyerFirmNameColumnIndex = reader.GetOrdinal("LawyerFirmName");
			int firmelephoneNoColumnIndex = reader.GetOrdinal("FirmelephoneNo");
			int firmfaxNoColumnIndex = reader.GetOrdinal("FirmFaxNo");
			int firmEmailColumnIndex = reader.GetOrdinal("FirmEmail");
			int firmIsActiveColumnIndex = reader.GetOrdinal("FirmIsActive");
			int lawyerTypeNameColumnIndex = reader.GetOrdinal("LawyerTypeName");
			int territoryColumnIndex = reader.GetOrdinal("Territory");
			int enrollmentYearColumnIndex = reader.GetOrdinal("EnrollmentYear");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_LawyerRow record = new View_LawyerRow();
					recordList.Add(record);
					record.LawyerID =  Convert.ToInt32(reader.GetValue(lawyerIDColumnIndex));
					if (!reader.IsDBNull(lawyerTypeIDColumnIndex)) record.LawyerTypeID =  Convert.ToInt32(reader.GetValue(lawyerTypeIDColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(licenseNoColumnIndex)) record.LicenseNo =  Convert.ToString(reader.GetValue(licenseNoColumnIndex));

					if (!reader.IsDBNull(licenseTypeColumnIndex)) record.LicenseType =  Convert.ToString(reader.GetValue(licenseTypeColumnIndex));

					if (!reader.IsDBNull(issueDateColumnIndex)) record.IssueDate =  Convert.ToDateTime(reader.GetValue(issueDateColumnIndex));

					if (!reader.IsDBNull(exprieDateColumnIndex)) record.ExprieDate =  Convert.ToDateTime(reader.GetValue(exprieDateColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(mobileNoColumnIndex)) record.MobileNo =  Convert.ToString(reader.GetValue(mobileNoColumnIndex));

					if (!reader.IsDBNull(educationColumnIndex)) record.Education =  Convert.ToString(reader.GetValue(educationColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					if (!reader.IsDBNull(numberOfConductCaseColumnIndex)) record.NumberOfConductCase =  Convert.ToInt32(reader.GetValue(numberOfConductCaseColumnIndex));

					if (!reader.IsDBNull(yearsExperienceColumnIndex)) record.YearsExperience =  Convert.ToInt32(reader.GetValue(yearsExperienceColumnIndex));

					if (!reader.IsDBNull(registerDateColumnIndex)) record.RegisterDate =  Convert.ToDateTime(reader.GetValue(registerDateColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(lawyerStatusIDColumnIndex)) record.LawyerStatusID =  Convert.ToInt32(reader.GetValue(lawyerStatusIDColumnIndex));

					if (!reader.IsDBNull(lawyerStatusNameColumnIndex)) record.LawyerStatusName =  Convert.ToString(reader.GetValue(lawyerStatusNameColumnIndex));

					if (!reader.IsDBNull(addressIDColumnIndex)) record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));

					if (!reader.IsDBNull(addressTypeIDColumnIndex)) record.AddressTypeID =  Convert.ToInt32(reader.GetValue(addressTypeIDColumnIndex));

					if (!reader.IsDBNull(faxNoColumnIndex)) record.FaxNo =  Convert.ToString(reader.GetValue(faxNoColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(isPrimaryColumnIndex)) record.IsPrimary =  Convert.ToBoolean(reader.GetValue(isPrimaryColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(address1ColumnIndex)) record.Address1 =  Convert.ToString(reader.GetValue(address1ColumnIndex));

					if (!reader.IsDBNull(houseNoColumnIndex)) record.HouseNo =  Convert.ToString(reader.GetValue(houseNoColumnIndex));

					if (!reader.IsDBNull(villageNoColumnIndex)) record.VillageNo =  Convert.ToString(reader.GetValue(villageNoColumnIndex));

					if (!reader.IsDBNull(streetColumnIndex)) record.Street =  Convert.ToString(reader.GetValue(streetColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(lawyerProvinceNameColumnIndex)) record.LawyerProvinceName =  Convert.ToString(reader.GetValue(lawyerProvinceNameColumnIndex));

					if (!reader.IsDBNull(disctrictIdColumnIndex)) record.DisctrictID =  Convert.ToInt32(reader.GetValue(disctrictIdColumnIndex));

					if (!reader.IsDBNull(subdistrictIDColumnIndex)) record.SubdistrictID =  Convert.ToInt32(reader.GetValue(subdistrictIDColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (!reader.IsDBNull(lawyerOfficeIDColumnIndex)) record.LawyerOfficeID =  Convert.ToInt32(reader.GetValue(lawyerOfficeIDColumnIndex));

					if (!reader.IsDBNull(lawyerFirmNameColumnIndex)) record.LawyerFirmName =  Convert.ToString(reader.GetValue(lawyerFirmNameColumnIndex));

					if (!reader.IsDBNull(firmelephoneNoColumnIndex)) record.FirmelephoneNo =  Convert.ToString(reader.GetValue(firmelephoneNoColumnIndex));

					if (!reader.IsDBNull(firmfaxNoColumnIndex)) record.FirmFaxNo =  Convert.ToString(reader.GetValue(firmfaxNoColumnIndex));

					if (!reader.IsDBNull(firmEmailColumnIndex)) record.FirmEmail =  Convert.ToString(reader.GetValue(firmEmailColumnIndex));

					if (!reader.IsDBNull(firmIsActiveColumnIndex)) record.FirmIsActive =  Convert.ToBoolean(reader.GetValue(firmIsActiveColumnIndex));

					record.LawyerTypeName =  Convert.ToString(reader.GetValue(lawyerTypeNameColumnIndex));
					if (!reader.IsDBNull(territoryColumnIndex)) record.Territory =  Convert.ToString(reader.GetValue(territoryColumnIndex));

					if (!reader.IsDBNull(enrollmentYearColumnIndex)) record.EnrollmentYear =  Convert.ToString(reader.GetValue(enrollmentYearColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_LawyerRow[])(recordList.ToArray(typeof(View_LawyerRow)));
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
				case "LawyerID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LawyerTypeID":
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
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LicenseNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LicenseType":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IssueDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ExprieDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MobileNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Education":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "NumberOfConductCase":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "YearsExperience":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RegisterDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "LawyerStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LawyerStatusName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FaxNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsPrimary":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Address1":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "HouseNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "VillageNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Street":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LawyerProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DisctrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubdistrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PostCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LawyerOfficeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LawyerFirmName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FirmelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FirmFaxNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FirmEmail":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FirmIsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "LawyerTypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Territory":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "EnrollmentYear":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

