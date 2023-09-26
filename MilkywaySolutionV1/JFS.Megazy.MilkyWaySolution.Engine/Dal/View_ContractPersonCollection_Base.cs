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
	public partial class View_ContractPersonCollection_Base : MarshalByRefObject
	{
		public const string ContractIDColumnName = "ContractID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string ContractNoColumnName = "ContractNo";
		public const string ContractDateColumnName = "ContractDate";
		public const string ContractNoteColumnName = "ContractNote";
		public const string PersonIDColumnName = "PersonID";
		public const string RoleIDColumnName = "RoleID";
		public const string AddressIDColumnName = "AddressID";
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
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string RoleNameColumnName = "RoleName";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string AgeColumnName = "Age";
		public const string GenderCodeColumnName = "GenderCode";
		public const string CardIDColumnName = "CardID";
		public const string RelateColumnName = "Relate";
		public const string PositionColumnName = "Position";
		public const string FormIDColumnName = "FormID";
		public const string IssuedAtColumnName = "IssuedAt";
		public const string RaceIDColumnName = "RaceID";
		public const string NationalityIDColumnName = "NationalityID";
		public const string DepartmentIDColumnName = "DepartmentID";
		private int _processID;
		public SqlCommand cmd = null;
		public View_ContractPersonCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_ContractPersonRow[] GetAll()
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
			"[ContractID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[ContractNo],"+
			"[ContractDate],"+
			"[ContractNote],"+
			"[PersonID],"+
			"[RoleID],"+
			"[AddressID],"+
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
			"[PostCode],"+
			"[TelephoneNo],"+
			"[RoleName],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[DateOfBirth],"+
			"[Age],"+
			"[GenderCode],"+
			"[CardID],"+
			"[Relate],"+
			"[Position],"+
			"[FormID],"+
			"[IssuedAt],"+
			"[RaceID],"+
			"[NationalityID],"+
			"[DepartmentID]"+
			" FROM [dbo].[View_ContractPerson]";
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
				TableName = "View_ContractPerson"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ContractID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ContractNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ContractDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ContractNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("PersonID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RoleID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
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
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("RoleName",Type.GetType("System.String"));
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
			dataColumn = dataTable.Columns.Add("Relate",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Position",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IssuedAt",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			return dataTable;
		}
		public View_ContractPersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_ContractPersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_ContractPersonRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_ContractPersonRow"/> objects.</returns>
		public virtual View_ContractPersonRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_ContractPerson]", top);
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
		public View_ContractPersonRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_ContractPersonRow[] rows = null;
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
		public DataTable GetView_ContractPersonPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContractID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ContractID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_ContractPerson] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ContractID,CaseID,ApplicantID,ContractNo,ContractDate,ContractNote,PersonID,RoleID,AddressID,Address1,HouseNo,VillageNo,Soi,Street,ProvinceID,ProvinceName,DisctrictID,DistrictName,SubdistrictID,SubdistrictName,PostCode,TelephoneNo,RoleName,Title,FirstName,LastName,DateOfBirth,Age,GenderCode,CardID,Relate,Position,FormID,IssuedAt,RaceID,NationalityID,DepartmentID," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_ContractPerson].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_ContractPerson] " + whereSql +
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
		public View_ContractPersonItemsPaging GetView_ContractPersonPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContractID")
		{
		View_ContractPersonItemsPaging obj = new View_ContractPersonItemsPaging();
		DataTable dt = GetView_ContractPersonPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_ContractPersonItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_ContractPersonItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ContractID = Convert.ToInt32(dt.Rows[i]["ContractID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.ContractNo = dt.Rows[i]["ContractNo"].ToString();
			if (dt.Rows[i]["ContractDate"] != DBNull.Value)
			record.ContractDate = Convert.ToDateTime(dt.Rows[i]["ContractDate"]);
			record.ContractNote = dt.Rows[i]["ContractNote"].ToString();
			record.PersonID = Convert.ToInt32(dt.Rows[i]["PersonID"]);
			if (dt.Rows[i]["RoleID"] != DBNull.Value)
			record.RoleID = Convert.ToInt32(dt.Rows[i]["RoleID"]);
			if (dt.Rows[i]["AddressID"] != DBNull.Value)
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
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
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.RoleName = dt.Rows[i]["RoleName"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["Age"] != DBNull.Value)
			record.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
			record.GenderCode = dt.Rows[i]["GenderCode"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.Relate = dt.Rows[i]["Relate"].ToString();
			record.Position = dt.Rows[i]["Position"].ToString();
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			record.IssuedAt = dt.Rows[i]["IssuedAt"].ToString();
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			recordList.Add(record);
		}
		obj.view_ContractPersonItems = (View_ContractPersonItems[])(recordList.ToArray(typeof(View_ContractPersonItems)));
		return obj;
		}
		protected View_ContractPersonRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_ContractPersonRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_ContractPersonRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int contractIDColumnIndex = reader.GetOrdinal("ContractID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int contractNoColumnIndex = reader.GetOrdinal("ContractNo");
			int contractDateColumnIndex = reader.GetOrdinal("ContractDate");
			int contractNoteColumnIndex = reader.GetOrdinal("ContractNote");
			int personIDColumnIndex = reader.GetOrdinal("PersonID");
			int roleIDColumnIndex = reader.GetOrdinal("RoleID");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
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
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int roleNameColumnIndex = reader.GetOrdinal("RoleName");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int ageColumnIndex = reader.GetOrdinal("Age");
			int genderCodeColumnIndex = reader.GetOrdinal("GenderCode");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int relateColumnIndex = reader.GetOrdinal("Relate");
			int positionColumnIndex = reader.GetOrdinal("Position");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int issuedAtColumnIndex = reader.GetOrdinal("IssuedAt");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_ContractPersonRow record = new View_ContractPersonRow();
					recordList.Add(record);
					record.ContractID =  Convert.ToInt32(reader.GetValue(contractIDColumnIndex));
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(contractNoColumnIndex)) record.ContractNo =  Convert.ToString(reader.GetValue(contractNoColumnIndex));

					if (!reader.IsDBNull(contractDateColumnIndex)) record.ContractDate =  Convert.ToDateTime(reader.GetValue(contractDateColumnIndex));

					if (!reader.IsDBNull(contractNoteColumnIndex)) record.ContractNote =  Convert.ToString(reader.GetValue(contractNoteColumnIndex));

					record.PersonID =  Convert.ToInt32(reader.GetValue(personIDColumnIndex));
					if (!reader.IsDBNull(roleIDColumnIndex)) record.RoleID =  Convert.ToInt32(reader.GetValue(roleIDColumnIndex));

					if (!reader.IsDBNull(addressIDColumnIndex)) record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));

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

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(roleNameColumnIndex)) record.RoleName =  Convert.ToString(reader.GetValue(roleNameColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(ageColumnIndex)) record.Age =  Convert.ToInt32(reader.GetValue(ageColumnIndex));

					if (!reader.IsDBNull(genderCodeColumnIndex)) record.GenderCode =  Convert.ToString(reader.GetValue(genderCodeColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(relateColumnIndex)) record.Relate =  Convert.ToString(reader.GetValue(relateColumnIndex));

					if (!reader.IsDBNull(positionColumnIndex)) record.Position =  Convert.ToString(reader.GetValue(positionColumnIndex));

					record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));
					if (!reader.IsDBNull(issuedAtColumnIndex)) record.IssuedAt =  Convert.ToString(reader.GetValue(issuedAtColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_ContractPersonRow[])(recordList.ToArray(typeof(View_ContractPersonRow)));
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
				case "ContractID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ContractNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ContractDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ContractNote":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "PersonID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RoleName":
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
				case "Relate":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Position":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IssuedAt":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
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

