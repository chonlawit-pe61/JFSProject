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
	public partial class View_DepartmentCollection_Base : MarshalByRefObject
	{
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string DepartmentNameAbbrColumnName = "DepartmentNameAbbr";
		public const string DepartmentCodeColumnName = "DepartmentCode";
		public const string IsActiveColumnName = "IsActive";
		public const string SortOderColumnName = "SortOder";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string FaxNoColumnName = "FaxNo";
		public const string LatitudeColumnName = "Latitude";
		public const string LongitudeColumnName = "Longitude";
		public const string Address1ColumnName = "Address1";
		public const string HouseNoColumnName = "HouseNo";
		public const string VillageNoColumnName = "VillageNo";
		public const string StreetColumnName = "Street";
		public const string DisctrictIDColumnName = "DisctrictID";
		public const string SubdistrictIDColumnName = "SubdistrictID";
		public const string PostCodeColumnName = "PostCode";
		public const string SubdistrictNameColumnName = "SubdistrictName";
		public const string DistrictNameColumnName = "DistrictName";
		public const string GeometryColumnName = "Geometry";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string SoiColumnName = "Soi";
		public const string ProvinceTypeCodeColumnName = "ProvinceTypeCode";
		private int _processID;
		public SqlCommand cmd = null;
		public View_DepartmentCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_DepartmentRow[] GetAll()
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
			"[DepartmentID],"+
			"[ProvinceID],"+
			"[DepartmentName],"+
			"[DepartmentNameAbbr],"+
			"[DepartmentCode],"+
			"[IsActive],"+
			"[SortOder],"+
			"[TelephoneNo],"+
			"[FaxNo],"+
			"[Latitude],"+
			"[Longitude],"+
			"[Address1],"+
			"[HouseNo],"+
			"[VillageNo],"+
			"[Street],"+
			"[DisctrictID],"+
			"[SubdistrictID],"+
			"[PostCode],"+
			"[SubdistrictName],"+
			"[DistrictName],"+
			"[Geometry].STAsText() AS Geometry,"+
			"[ProvinceName],"+
			"[Soi],"+
			"[ProvinceTypeCode]"+
			" FROM [dbo].[View_Department]";
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
				TableName = "View_Department"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("SortOder",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FaxNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Latitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Longitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Address1",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("HouseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("VillageNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Street",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DisctrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SubdistrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("PostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("SubdistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Geometry",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Soi",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ProvinceTypeCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			return dataTable;
		}
		public View_DepartmentRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_DepartmentRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_DepartmentRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_DepartmentRow"/> objects.</returns>
		public virtual View_DepartmentRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_Department]", top);
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
		public View_DepartmentRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_DepartmentRow[] rows = null;
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
		public DataTable GetView_DepartmentPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "DepartmentID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "DepartmentID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_Department] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,DepartmentID,ProvinceID,DepartmentName,DepartmentNameAbbr,DepartmentCode,IsActive,SortOder,TelephoneNo,FaxNo,Latitude,Longitude,Address1,HouseNo,VillageNo,Street,DisctrictID,SubdistrictID,PostCode,SubdistrictName,DistrictName,Geometry.STAsText() AS Geometry,ProvinceName,Soi,ProvinceTypeCode," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_Department].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_Department] " + whereSql +
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
		public View_DepartmentItemsPaging GetView_DepartmentPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "DepartmentID")
		{
		View_DepartmentItemsPaging obj = new View_DepartmentItemsPaging();
		DataTable dt = GetView_DepartmentPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_DepartmentItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_DepartmentItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			record.DepartmentNameAbbr = dt.Rows[i]["DepartmentNameAbbr"].ToString();
			record.DepartmentCode = dt.Rows[i]["DepartmentCode"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["SortOder"] != DBNull.Value)
			record.SortOder = Convert.ToInt32(dt.Rows[i]["SortOder"]);
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.FaxNo = dt.Rows[i]["FaxNo"].ToString();
			if (dt.Rows[i]["Latitude"] != DBNull.Value)
			record.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);
			if (dt.Rows[i]["Longitude"] != DBNull.Value)
			record.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);
			record.Address1 = dt.Rows[i]["Address1"].ToString();
			record.HouseNo = dt.Rows[i]["HouseNo"].ToString();
			record.VillageNo = dt.Rows[i]["VillageNo"].ToString();
			record.Street = dt.Rows[i]["Street"].ToString();
			if (dt.Rows[i]["DisctrictID"] != DBNull.Value)
			record.DisctrictID = Convert.ToInt32(dt.Rows[i]["DisctrictID"]);
			if (dt.Rows[i]["SubdistrictID"] != DBNull.Value)
			record.SubdistrictID = Convert.ToInt32(dt.Rows[i]["SubdistrictID"]);
			record.PostCode = dt.Rows[i]["PostCode"].ToString();
			record.SubdistrictName = dt.Rows[i]["SubdistrictName"].ToString();
			record.DistrictName = dt.Rows[i]["DistrictName"].ToString();
			record.Geometry = dt.Rows[i]["Geometry"].ToString();
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			record.Soi = dt.Rows[i]["Soi"].ToString();
			record.ProvinceTypeCode = dt.Rows[i]["ProvinceTypeCode"].ToString();
			recordList.Add(record);
		}
		obj.view_DepartmentItems = (View_DepartmentItems[])(recordList.ToArray(typeof(View_DepartmentItems)));
		return obj;
		}
		public View_DepartmentRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			View_DepartmentRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected View_DepartmentRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_DepartmentRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_DepartmentRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int departmentNameColumnIndex = reader.GetOrdinal("DepartmentName");
			int departmentNameAbbrColumnIndex = reader.GetOrdinal("DepartmentNameAbbr");
			int departmentCodeColumnIndex = reader.GetOrdinal("DepartmentCode");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int sortOderColumnIndex = reader.GetOrdinal("SortOder");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int faxNoColumnIndex = reader.GetOrdinal("FaxNo");
			int latitudeColumnIndex = reader.GetOrdinal("Latitude");
			int longitudeColumnIndex = reader.GetOrdinal("Longitude");
			int address1ColumnIndex = reader.GetOrdinal("Address1");
			int houseNoColumnIndex = reader.GetOrdinal("HouseNo");
			int villageNoColumnIndex = reader.GetOrdinal("VillageNo");
			int streetColumnIndex = reader.GetOrdinal("Street");
			int disctrictIdColumnIndex = reader.GetOrdinal("DisctrictID");
			int subdistrictIDColumnIndex = reader.GetOrdinal("SubdistrictID");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			int subdistrictNameColumnIndex = reader.GetOrdinal("SubdistrictName");
			int districtNameColumnIndex = reader.GetOrdinal("DistrictName");
			int geometryColumnIndex = reader.GetOrdinal("Geometry");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int soiColumnIndex = reader.GetOrdinal("Soi");
			int provinceTypeCodeColumnIndex = reader.GetOrdinal("ProvinceTypeCode");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_DepartmentRow record = new View_DepartmentRow();
					recordList.Add(record);
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));
					record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));
					record.DepartmentNameAbbr =  Convert.ToString(reader.GetValue(departmentNameAbbrColumnIndex));
					if (!reader.IsDBNull(departmentCodeColumnIndex)) record.DepartmentCode =  Convert.ToString(reader.GetValue(departmentCodeColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(sortOderColumnIndex)) record.SortOder =  Convert.ToInt32(reader.GetValue(sortOderColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(faxNoColumnIndex)) record.FaxNo =  Convert.ToString(reader.GetValue(faxNoColumnIndex));

					if (!reader.IsDBNull(latitudeColumnIndex)) record.Latitude =  Convert.ToDouble(reader.GetValue(latitudeColumnIndex));

					if (!reader.IsDBNull(longitudeColumnIndex)) record.Longitude =  Convert.ToDouble(reader.GetValue(longitudeColumnIndex));

					if (!reader.IsDBNull(address1ColumnIndex)) record.Address1 =  Convert.ToString(reader.GetValue(address1ColumnIndex));

					if (!reader.IsDBNull(houseNoColumnIndex)) record.HouseNo =  Convert.ToString(reader.GetValue(houseNoColumnIndex));

					if (!reader.IsDBNull(villageNoColumnIndex)) record.VillageNo =  Convert.ToString(reader.GetValue(villageNoColumnIndex));

					if (!reader.IsDBNull(streetColumnIndex)) record.Street =  Convert.ToString(reader.GetValue(streetColumnIndex));

					if (!reader.IsDBNull(disctrictIdColumnIndex)) record.DisctrictID =  Convert.ToInt32(reader.GetValue(disctrictIdColumnIndex));

					if (!reader.IsDBNull(subdistrictIDColumnIndex)) record.SubdistrictID =  Convert.ToInt32(reader.GetValue(subdistrictIDColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (!reader.IsDBNull(subdistrictNameColumnIndex)) record.SubdistrictName =  Convert.ToString(reader.GetValue(subdistrictNameColumnIndex));

					if (!reader.IsDBNull(districtNameColumnIndex)) record.DistrictName =  Convert.ToString(reader.GetValue(districtNameColumnIndex));

					if (!reader.IsDBNull(geometryColumnIndex)) record.Geometry =  Convert.ToString(reader.GetValue(geometryColumnIndex));

					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(soiColumnIndex)) record.Soi =  Convert.ToString(reader.GetValue(soiColumnIndex));

					if (!reader.IsDBNull(provinceTypeCodeColumnIndex)) record.ProvinceTypeCode =  Convert.ToString(reader.GetValue(provinceTypeCodeColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_DepartmentRow[])(recordList.ToArray(typeof(View_DepartmentRow)));
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
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "SortOder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FaxNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Latitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Longitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
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
				case "DisctrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubdistrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PostCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SubdistrictName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DistrictName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Geometry":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Soi":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceTypeCode":
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

