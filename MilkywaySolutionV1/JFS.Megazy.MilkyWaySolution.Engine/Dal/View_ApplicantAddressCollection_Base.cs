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
	public partial class View_ApplicantAddressCollection_Base : MarshalByRefObject
	{
		public const string AddressIDColumnName = "AddressID";
		public const string Address1ColumnName = "Address1";
		public const string HouseNoColumnName = "HouseNo";
		public const string VillageNoColumnName = "VillageNo";
		public const string StreetColumnName = "Street";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string DisctrictIDColumnName = "DisctrictID";
		public const string SubdistrictIDColumnName = "SubdistrictID";
		public const string PostCodeColumnName = "PostCode";
		public const string CreatedateColumnName = "Createdate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string CountryCodeColumnName = "CountryCode";
		public const string ProvinceCodeColumnName = "ProvinceCode";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string ProvinceNameENColumnName = "ProvinceNameEN";
		public const string DistrictCodeColumnName = "DistrictCode";
		public const string DistrictNameColumnName = "DistrictName";
		public const string DistrictNameENColumnName = "DistrictNameEN";
		public const string SubdistrictCodeColumnName = "SubdistrictCode";
		public const string SubdistrictNameColumnName = "SubdistrictName";
		public const string SubdistrictNameENColumnName = "SubdistrictNameEN";
		public const string DistrictPostCodeColumnName = "DistrictPostCode";
		public const string AddressTypeIDColumnName = "AddressTypeID";
		public const string TypeNameColumnName = "TypeName";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string LatitudeColumnName = "Latitude";
		public const string LongitudeColumnName = "Longitude";
		public const string StayColumnName = "Stay";
		public const string StayUnitColumnName = "StayUnit";
		public const string IsPresentAddressColumnName = "IsPresentAddress";
		public const string IsPermanentAddressColumnName = "IsPermanentAddress";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string SoiColumnName = "Soi";
		private int _processID;
		public SqlCommand cmd = null;
		public View_ApplicantAddressCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_ApplicantAddressRow[] GetAll()
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
			"[AddressID],"+
			"[Address1],"+
			"[HouseNo],"+
			"[VillageNo],"+
			"[Street],"+
			"[ProvinceID],"+
			"[DisctrictID],"+
			"[SubdistrictID],"+
			"[PostCode],"+
			"[Createdate],"+
			"[ModifiedDate],"+
			"[CountryCode],"+
			"[ProvinceCode],"+
			"[ProvinceName],"+
			"[ProvinceNameEN],"+
			"[DistrictCode],"+
			"[DistrictName],"+
			"[DistrictNameEN],"+
			"[SubdistrictCode],"+
			"[SubdistrictName],"+
			"[SubdistrictNameEN],"+
			"[DistrictPostCode],"+
			"[AddressTypeID],"+
			"[TypeName],"+
			"[ApplicantID],"+
			"[Latitude],"+
			"[Longitude],"+
			"[Stay],"+
			"[StayUnit],"+
			"[IsPresentAddress],"+
			"[IsPermanentAddress],"+
			"[TelephoneNo],"+
			"[Soi]"+
			" FROM [dbo].[View_ApplicantAddress]";
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
				TableName = "View_ApplicantAddress"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Address1",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("HouseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("VillageNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Street",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DisctrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SubdistrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("PostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("Createdate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("CountryCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 2;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceCode",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ProvinceNameEN",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DistrictCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("DistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DistrictNameEN",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SubdistrictCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("SubdistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SubdistrictNameEN",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DistrictPostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("AddressTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Latitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Longitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Stay",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("StayUnit",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsPresentAddress",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsPermanentAddress",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Soi",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			return dataTable;
		}
		public View_ApplicantAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_ApplicantAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_ApplicantAddressRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_ApplicantAddressRow"/> objects.</returns>
		public virtual View_ApplicantAddressRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_ApplicantAddress]", top);
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
		public View_ApplicantAddressRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_ApplicantAddressRow[] rows = null;
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
		public DataTable GetView_ApplicantAddressPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AddressID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "AddressID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_ApplicantAddress] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,AddressID,Address1,HouseNo,VillageNo,Street,ProvinceID,DisctrictID,SubdistrictID,PostCode,Createdate,ModifiedDate,CountryCode,ProvinceCode,ProvinceName,ProvinceNameEN,DistrictCode,DistrictName,DistrictNameEN,SubdistrictCode,SubdistrictName,SubdistrictNameEN,DistrictPostCode,AddressTypeID,TypeName,ApplicantID,Latitude,Longitude,Stay,StayUnit,IsPresentAddress,IsPermanentAddress,TelephoneNo,Soi," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_ApplicantAddress].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_ApplicantAddress] " + whereSql +
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
		public View_ApplicantAddressItemsPaging GetView_ApplicantAddressPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AddressID")
		{
		View_ApplicantAddressItemsPaging obj = new View_ApplicantAddressItemsPaging();
		DataTable dt = GetView_ApplicantAddressPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_ApplicantAddressItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_ApplicantAddressItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			record.Address1 = dt.Rows[i]["Address1"].ToString();
			record.HouseNo = dt.Rows[i]["HouseNo"].ToString();
			record.VillageNo = dt.Rows[i]["VillageNo"].ToString();
			record.Street = dt.Rows[i]["Street"].ToString();
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			if (dt.Rows[i]["DisctrictID"] != DBNull.Value)
			record.DisctrictID = Convert.ToInt32(dt.Rows[i]["DisctrictID"]);
			if (dt.Rows[i]["SubdistrictID"] != DBNull.Value)
			record.SubdistrictID = Convert.ToInt32(dt.Rows[i]["SubdistrictID"]);
			record.PostCode = dt.Rows[i]["PostCode"].ToString();
			if (dt.Rows[i]["Createdate"] != DBNull.Value)
			record.Createdate = Convert.ToDateTime(dt.Rows[i]["Createdate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.CountryCode = dt.Rows[i]["CountryCode"].ToString();
			record.ProvinceCode = Convert.ToInt32(dt.Rows[i]["ProvinceCode"]);
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			record.ProvinceNameEN = dt.Rows[i]["ProvinceNameEN"].ToString();
			record.DistrictCode = dt.Rows[i]["DistrictCode"].ToString();
			record.DistrictName = dt.Rows[i]["DistrictName"].ToString();
			record.DistrictNameEN = dt.Rows[i]["DistrictNameEN"].ToString();
			record.SubdistrictCode = dt.Rows[i]["SubdistrictCode"].ToString();
			record.SubdistrictName = dt.Rows[i]["SubdistrictName"].ToString();
			record.SubdistrictNameEN = dt.Rows[i]["SubdistrictNameEN"].ToString();
			record.DistrictPostCode = dt.Rows[i]["DistrictPostCode"].ToString();
			record.AddressTypeID = Convert.ToInt32(dt.Rows[i]["AddressTypeID"]);
			record.TypeName = dt.Rows[i]["TypeName"].ToString();
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["Latitude"] != DBNull.Value)
			record.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);
			if (dt.Rows[i]["Longitude"] != DBNull.Value)
			record.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);
			record.Stay = Convert.ToInt32(dt.Rows[i]["Stay"]);
			record.StayUnit = dt.Rows[i]["StayUnit"].ToString();
			record.IsPresentAddress = Convert.ToBoolean(dt.Rows[i]["IsPresentAddress"]);
			record.IsPermanentAddress = Convert.ToBoolean(dt.Rows[i]["IsPermanentAddress"]);
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.Soi = dt.Rows[i]["Soi"].ToString();
			recordList.Add(record);
		}
		obj.view_ApplicantAddressItems = (View_ApplicantAddressItems[])(recordList.ToArray(typeof(View_ApplicantAddressItems)));
		return obj;
		}
		protected View_ApplicantAddressRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_ApplicantAddressRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_ApplicantAddressRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int address1ColumnIndex = reader.GetOrdinal("Address1");
			int houseNoColumnIndex = reader.GetOrdinal("HouseNo");
			int villageNoColumnIndex = reader.GetOrdinal("VillageNo");
			int streetColumnIndex = reader.GetOrdinal("Street");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int disctrictIdColumnIndex = reader.GetOrdinal("DisctrictID");
			int subdistrictIDColumnIndex = reader.GetOrdinal("SubdistrictID");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			int createdateColumnIndex = reader.GetOrdinal("Createdate");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int countrycodeColumnIndex = reader.GetOrdinal("CountryCode");
			int provinceCodeColumnIndex = reader.GetOrdinal("ProvinceCode");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int provinceNameENColumnIndex = reader.GetOrdinal("ProvinceNameEN");
			int districtCodeColumnIndex = reader.GetOrdinal("DistrictCode");
			int districtNameColumnIndex = reader.GetOrdinal("DistrictName");
			int districtNameENColumnIndex = reader.GetOrdinal("DistrictNameEN");
			int subdistrictCodeColumnIndex = reader.GetOrdinal("SubdistrictCode");
			int subdistrictNameColumnIndex = reader.GetOrdinal("SubdistrictName");
			int subdistrictNameENColumnIndex = reader.GetOrdinal("SubdistrictNameEN");
			int districtPostCodeColumnIndex = reader.GetOrdinal("DistrictPostCode");
			int addressTypeIDColumnIndex = reader.GetOrdinal("AddressTypeID");
			int typeNameColumnIndex = reader.GetOrdinal("TypeName");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int latitudeColumnIndex = reader.GetOrdinal("Latitude");
			int longitudeColumnIndex = reader.GetOrdinal("Longitude");
			int stayColumnIndex = reader.GetOrdinal("Stay");
			int stayUnitColumnIndex = reader.GetOrdinal("StayUnit");
			int isPresentAddressColumnIndex = reader.GetOrdinal("IsPresentAddress");
			int isPermanentAddressColumnIndex = reader.GetOrdinal("IsPermanentAddress");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int soiColumnIndex = reader.GetOrdinal("Soi");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_ApplicantAddressRow record = new View_ApplicantAddressRow();
					recordList.Add(record);
					record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));
					if (!reader.IsDBNull(address1ColumnIndex)) record.Address1 =  Convert.ToString(reader.GetValue(address1ColumnIndex));

					if (!reader.IsDBNull(houseNoColumnIndex)) record.HouseNo =  Convert.ToString(reader.GetValue(houseNoColumnIndex));

					if (!reader.IsDBNull(villageNoColumnIndex)) record.VillageNo =  Convert.ToString(reader.GetValue(villageNoColumnIndex));

					if (!reader.IsDBNull(streetColumnIndex)) record.Street =  Convert.ToString(reader.GetValue(streetColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(disctrictIdColumnIndex)) record.DisctrictID =  Convert.ToInt32(reader.GetValue(disctrictIdColumnIndex));

					if (!reader.IsDBNull(subdistrictIDColumnIndex)) record.SubdistrictID =  Convert.ToInt32(reader.GetValue(subdistrictIDColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (!reader.IsDBNull(createdateColumnIndex)) record.Createdate =  Convert.ToDateTime(reader.GetValue(createdateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					record.CountryCode =  Convert.ToString(reader.GetValue(countrycodeColumnIndex));
					record.ProvinceCode =  Convert.ToInt32(reader.GetValue(provinceCodeColumnIndex));
					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(provinceNameENColumnIndex)) record.ProvinceNameEN =  Convert.ToString(reader.GetValue(provinceNameENColumnIndex));

					if (!reader.IsDBNull(districtCodeColumnIndex)) record.DistrictCode =  Convert.ToString(reader.GetValue(districtCodeColumnIndex));

					if (!reader.IsDBNull(districtNameColumnIndex)) record.DistrictName =  Convert.ToString(reader.GetValue(districtNameColumnIndex));

					if (!reader.IsDBNull(districtNameENColumnIndex)) record.DistrictNameEN =  Convert.ToString(reader.GetValue(districtNameENColumnIndex));

					if (!reader.IsDBNull(subdistrictCodeColumnIndex)) record.SubdistrictCode =  Convert.ToString(reader.GetValue(subdistrictCodeColumnIndex));

					if (!reader.IsDBNull(subdistrictNameColumnIndex)) record.SubdistrictName =  Convert.ToString(reader.GetValue(subdistrictNameColumnIndex));

					if (!reader.IsDBNull(subdistrictNameENColumnIndex)) record.SubdistrictNameEN =  Convert.ToString(reader.GetValue(subdistrictNameENColumnIndex));

					if (!reader.IsDBNull(districtPostCodeColumnIndex)) record.DistrictPostCode =  Convert.ToString(reader.GetValue(districtPostCodeColumnIndex));

					record.AddressTypeID =  Convert.ToInt32(reader.GetValue(addressTypeIDColumnIndex));
					record.TypeName =  Convert.ToString(reader.GetValue(typeNameColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(latitudeColumnIndex)) record.Latitude =  Convert.ToDouble(reader.GetValue(latitudeColumnIndex));

					if (!reader.IsDBNull(longitudeColumnIndex)) record.Longitude =  Convert.ToDouble(reader.GetValue(longitudeColumnIndex));

					record.Stay =  Convert.ToInt32(reader.GetValue(stayColumnIndex));
					record.StayUnit =  Convert.ToString(reader.GetValue(stayUnitColumnIndex));
					record.IsPresentAddress =  Convert.ToBoolean(reader.GetValue(isPresentAddressColumnIndex));
					record.IsPermanentAddress =  Convert.ToBoolean(reader.GetValue(isPermanentAddressColumnIndex));
					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(soiColumnIndex)) record.Soi =  Convert.ToString(reader.GetValue(soiColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_ApplicantAddressRow[])(recordList.ToArray(typeof(View_ApplicantAddressRow)));
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
				case "Street":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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
				case "Createdate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "CountryCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ProvinceCode":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceNameEN":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DistrictCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DistrictName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DistrictNameEN":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SubdistrictCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SubdistrictName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SubdistrictNameEN":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DistrictPostCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AddressTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Latitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Longitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Stay":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "StayUnit":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsPresentAddress":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsPermanentAddress":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Soi":
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

