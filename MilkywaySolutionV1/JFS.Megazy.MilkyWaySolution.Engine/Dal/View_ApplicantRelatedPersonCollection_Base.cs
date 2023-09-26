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
	public partial class View_ApplicantRelatedPersonCollection_Base : MarshalByRefObject
	{
		public const string ContactPersonIDColumnName = "ContactPersonID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string PersonRoleIDColumnName = "PersonRoleID";
		public const string TelephoneNumberColumnName = "TelephoneNumber";
		public const string EmailColumnName = "Email";
		public const string RelatedAsColumnName = "RelatedAs";
		public const string AddressIDColumnName = "AddressID";
		public const string PersonRoleNameColumnName = "PersonRoleName";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string AgeColumnName = "Age";
		public const string GenderCodeColumnName = "GenderCode";
		public const string CardIDColumnName = "CardID";
		public const string ReligionIDColumnName = "ReligionID";
		public const string NationalityIDColumnName = "NationalityID";
		public const string RaceIDColumnName = "RaceID";
		public const string GenderNameColumnName = "GenderName";
		public const string NationalityNameColumnName = "NationalityName";
		public const string RaceNameColumnName = "RaceName";
		public const string ReligionNameColumnName = "ReligionName";
		public const string Address1ColumnName = "Address1";
		public const string HouseNoColumnName = "HouseNo";
		public const string VillageNoColumnName = "VillageNo";
		public const string SoiColumnName = "Soi";
		public const string StreetColumnName = "Street";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string DisctrictIDColumnName = "DisctrictID";
		public const string DistrictNameColumnName = "DistrictName";
		public const string SubdistrictIDColumnName = "SubdistrictID";
		public const string SubdistrictNameColumnName = "SubdistrictName";
		public const string PostCodeColumnName = "PostCode";
		private int _processID;
		public SqlCommand cmd = null;
		public View_ApplicantRelatedPersonCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_ApplicantRelatedPersonRow[] GetAll()
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
			"[ContactPersonID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[PersonRoleID],"+
			"[TelephoneNumber],"+
			"[Email],"+
			"[RelatedAs],"+
			"[AddressID],"+
			"[PersonRoleName],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[DateOfBirth],"+
			"[Age],"+
			"[GenderCode],"+
			"[CardID],"+
			"[ReligionID],"+
			"[NationalityID],"+
			"[RaceID],"+
			"[GenderName],"+
			"[NationalityName],"+
			"[RaceName],"+
			"[ReligionName],"+
			"[Address1],"+
			"[HouseNo],"+
			"[VillageNo],"+
			"[Soi],"+
			"[Street],"+
			"[ProvinceID],"+
			"[ProvinceName],"+
			"[DisctrictID],"+
			"[DistrictName],"+
			"[SubdistrictID],"+
			"[SubdistrictName],"+
			"[PostCode]"+
			" FROM [dbo].[View_ApplicantRelatedPerson]";
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
				TableName = "View_ApplicantRelatedPerson"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ContactPersonID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PersonRoleID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("TelephoneNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("RelatedAs",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("PersonRoleName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Age",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("GenderCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("GenderName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NationalityName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("RaceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ReligionName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Address1",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("HouseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("VillageNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Soi",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Street",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DisctrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SubdistrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SubdistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("PostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 5;
			return dataTable;
		}
		public View_ApplicantRelatedPersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_ApplicantRelatedPersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_ApplicantRelatedPersonRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_ApplicantRelatedPersonRow"/> objects.</returns>
		public virtual View_ApplicantRelatedPersonRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_ApplicantRelatedPerson]", top);
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
		public View_ApplicantRelatedPersonRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_ApplicantRelatedPersonRow[] rows = null;
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
		public DataTable GetView_ApplicantRelatedPersonPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContactPersonID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ContactPersonID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_ApplicantRelatedPerson] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ContactPersonID,CaseID,ApplicantID,PersonRoleID,TelephoneNumber,Email,RelatedAs,AddressID,PersonRoleName,Title,FirstName,LastName,DateOfBirth,Age,GenderCode,CardID,ReligionID,NationalityID,RaceID,GenderName,NationalityName,RaceName,ReligionName,Address1,HouseNo,VillageNo,Soi,Street,ProvinceID,ProvinceName,DisctrictID,DistrictName,SubdistrictID,SubdistrictName,PostCode," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_ApplicantRelatedPerson].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_ApplicantRelatedPerson] " + whereSql +
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
		public View_ApplicantRelatedPersonItemsPaging GetView_ApplicantRelatedPersonPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContactPersonID")
		{
		View_ApplicantRelatedPersonItemsPaging obj = new View_ApplicantRelatedPersonItemsPaging();
		DataTable dt = GetView_ApplicantRelatedPersonPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_ApplicantRelatedPersonItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_ApplicantRelatedPersonItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ContactPersonID = Convert.ToInt32(dt.Rows[i]["ContactPersonID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["PersonRoleID"] != DBNull.Value)
			record.PersonRoleID = Convert.ToInt32(dt.Rows[i]["PersonRoleID"]);
			record.TelephoneNumber = dt.Rows[i]["TelephoneNumber"].ToString();
			record.Email = dt.Rows[i]["Email"].ToString();
			record.RelatedAs = dt.Rows[i]["RelatedAs"].ToString();
			if (dt.Rows[i]["AddressID"] != DBNull.Value)
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			record.PersonRoleName = dt.Rows[i]["PersonRoleName"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["Age"] != DBNull.Value)
			record.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
			record.GenderCode = dt.Rows[i]["GenderCode"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			if (dt.Rows[i]["ReligionID"] != DBNull.Value)
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			record.GenderName = dt.Rows[i]["GenderName"].ToString();
			record.NationalityName = dt.Rows[i]["NationalityName"].ToString();
			record.RaceName = dt.Rows[i]["RaceName"].ToString();
			record.ReligionName = dt.Rows[i]["ReligionName"].ToString();
			record.Address1 = dt.Rows[i]["Address1"].ToString();
			record.HouseNo = dt.Rows[i]["HouseNo"].ToString();
			record.VillageNo = dt.Rows[i]["VillageNo"].ToString();
			record.Soi = dt.Rows[i]["Soi"].ToString();
			record.Street = dt.Rows[i]["Street"].ToString();
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			if (dt.Rows[i]["DisctrictID"] != DBNull.Value)
			record.DisctrictID = Convert.ToInt32(dt.Rows[i]["DisctrictID"]);
			record.DistrictName = dt.Rows[i]["DistrictName"].ToString();
			if (dt.Rows[i]["SubdistrictID"] != DBNull.Value)
			record.SubdistrictID = Convert.ToInt32(dt.Rows[i]["SubdistrictID"]);
			record.SubdistrictName = dt.Rows[i]["SubdistrictName"].ToString();
			record.PostCode = dt.Rows[i]["PostCode"].ToString();
			recordList.Add(record);
		}
		obj.view_ApplicantRelatedPersonItems = (View_ApplicantRelatedPersonItems[])(recordList.ToArray(typeof(View_ApplicantRelatedPersonItems)));
		return obj;
		}
		protected View_ApplicantRelatedPersonRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_ApplicantRelatedPersonRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_ApplicantRelatedPersonRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int contactPersonIDColumnIndex = reader.GetOrdinal("ContactPersonID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int personRoleIDColumnIndex = reader.GetOrdinal("PersonRoleID");
			int telephoneNumberColumnIndex = reader.GetOrdinal("TelephoneNumber");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int relatedAsColumnIndex = reader.GetOrdinal("RelatedAs");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int personRoleNameColumnIndex = reader.GetOrdinal("PersonRoleName");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int ageColumnIndex = reader.GetOrdinal("Age");
			int genderCodeColumnIndex = reader.GetOrdinal("GenderCode");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int genderNameColumnIndex = reader.GetOrdinal("GenderName");
			int nationalitynameColumnIndex = reader.GetOrdinal("NationalityName");
			int raceNameColumnIndex = reader.GetOrdinal("RaceName");
			int religionNameColumnIndex = reader.GetOrdinal("ReligionName");
			int address1ColumnIndex = reader.GetOrdinal("Address1");
			int houseNoColumnIndex = reader.GetOrdinal("HouseNo");
			int villageNoColumnIndex = reader.GetOrdinal("VillageNo");
			int soiColumnIndex = reader.GetOrdinal("Soi");
			int streetColumnIndex = reader.GetOrdinal("Street");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int disctrictIdColumnIndex = reader.GetOrdinal("DisctrictID");
			int districtNameColumnIndex = reader.GetOrdinal("DistrictName");
			int subdistrictIDColumnIndex = reader.GetOrdinal("SubdistrictID");
			int subdistrictNameColumnIndex = reader.GetOrdinal("SubdistrictName");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_ApplicantRelatedPersonRow record = new View_ApplicantRelatedPersonRow();
					recordList.Add(record);
					record.ContactPersonID =  Convert.ToInt32(reader.GetValue(contactPersonIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(personRoleIDColumnIndex)) record.PersonRoleID =  Convert.ToInt32(reader.GetValue(personRoleIDColumnIndex));

					if (!reader.IsDBNull(telephoneNumberColumnIndex)) record.TelephoneNumber =  Convert.ToString(reader.GetValue(telephoneNumberColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(relatedAsColumnIndex)) record.RelatedAs =  Convert.ToString(reader.GetValue(relatedAsColumnIndex));

					if (!reader.IsDBNull(addressIDColumnIndex)) record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));

					if (!reader.IsDBNull(personRoleNameColumnIndex)) record.PersonRoleName =  Convert.ToString(reader.GetValue(personRoleNameColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(ageColumnIndex)) record.Age =  Convert.ToInt32(reader.GetValue(ageColumnIndex));

					if (!reader.IsDBNull(genderCodeColumnIndex)) record.GenderCode =  Convert.ToString(reader.GetValue(genderCodeColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(religionIDColumnIndex)) record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(genderNameColumnIndex)) record.GenderName =  Convert.ToString(reader.GetValue(genderNameColumnIndex));

					if (!reader.IsDBNull(nationalitynameColumnIndex)) record.NationalityName =  Convert.ToString(reader.GetValue(nationalitynameColumnIndex));

					if (!reader.IsDBNull(raceNameColumnIndex)) record.RaceName =  Convert.ToString(reader.GetValue(raceNameColumnIndex));

					if (!reader.IsDBNull(religionNameColumnIndex)) record.ReligionName =  Convert.ToString(reader.GetValue(religionNameColumnIndex));

					if (!reader.IsDBNull(address1ColumnIndex)) record.Address1 =  Convert.ToString(reader.GetValue(address1ColumnIndex));

					if (!reader.IsDBNull(houseNoColumnIndex)) record.HouseNo =  Convert.ToString(reader.GetValue(houseNoColumnIndex));

					if (!reader.IsDBNull(villageNoColumnIndex)) record.VillageNo =  Convert.ToString(reader.GetValue(villageNoColumnIndex));

					if (!reader.IsDBNull(soiColumnIndex)) record.Soi =  Convert.ToString(reader.GetValue(soiColumnIndex));

					if (!reader.IsDBNull(streetColumnIndex)) record.Street =  Convert.ToString(reader.GetValue(streetColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(disctrictIdColumnIndex)) record.DisctrictID =  Convert.ToInt32(reader.GetValue(disctrictIdColumnIndex));

					if (!reader.IsDBNull(districtNameColumnIndex)) record.DistrictName =  Convert.ToString(reader.GetValue(districtNameColumnIndex));

					if (!reader.IsDBNull(subdistrictIDColumnIndex)) record.SubdistrictID =  Convert.ToInt32(reader.GetValue(subdistrictIDColumnIndex));

					if (!reader.IsDBNull(subdistrictNameColumnIndex)) record.SubdistrictName =  Convert.ToString(reader.GetValue(subdistrictNameColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_ApplicantRelatedPersonRow[])(recordList.ToArray(typeof(View_ApplicantRelatedPersonRow)));
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
				case "ContactPersonID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PersonRoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TelephoneNumber":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RelatedAs":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PersonRoleName":
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
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "Age":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "GenderCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "GenderName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "NationalityName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RaceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReligionName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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
				case "Soi":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Street":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DisctrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DistrictName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SubdistrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubdistrictName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "PostCode":
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

