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
	public partial class View_ApplicantFamilyAddressCollection_Base : MarshalByRefObject
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
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string ProvinceCodeColumnName = "ProvinceCode";
		public const string CountryCodeColumnName = "CountryCode";
		public const string DistrictNameColumnName = "DistrictName";
		public const string DistrictCodeColumnName = "DistrictCode";
		public const string DistrictNameENColumnName = "DistrictNameEN";
		public const string SubdistrictNameColumnName = "SubdistrictName";
		public const string SubdistrictCodeColumnName = "SubdistrictCode";
		public const string SoiColumnName = "Soi";
		private int _processID;
		public SqlCommand cmd = null;
		public View_ApplicantFamilyAddressCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_ApplicantFamilyAddressRow[] GetAll()
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
			"[ProvinceName],"+
			"[ProvinceCode],"+
			"[CountryCode],"+
			"[DistrictName],"+
			"[DistrictCode],"+
			"[DistrictNameEN],"+
			"[SubdistrictName],"+
			"[SubdistrictCode],"+
			"[Soi]"+
			" FROM [dbo].[View_ApplicantFamilyAddress]";
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
				TableName = "View_ApplicantFamilyAddress"
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
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ProvinceCode",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CountryCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 2;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DistrictCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("DistrictNameEN",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SubdistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SubdistrictCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("Soi",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			return dataTable;
		}
		public View_ApplicantFamilyAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_ApplicantFamilyAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_ApplicantFamilyAddressRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_ApplicantFamilyAddressRow"/> objects.</returns>
		public virtual View_ApplicantFamilyAddressRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_ApplicantFamilyAddress]", top);
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
		public View_ApplicantFamilyAddressRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_ApplicantFamilyAddressRow[] rows = null;
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
		public DataTable GetView_ApplicantFamilyAddressPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AddressID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_ApplicantFamilyAddress] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,AddressID,Address1,HouseNo,VillageNo,Street,ProvinceID,DisctrictID,SubdistrictID,PostCode,ProvinceName,ProvinceCode,CountryCode,DistrictName,DistrictCode,DistrictNameEN,SubdistrictName,SubdistrictCode,Soi," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_ApplicantFamilyAddress].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_ApplicantFamilyAddress] " + whereSql +
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
		public View_ApplicantFamilyAddressItemsPaging GetView_ApplicantFamilyAddressPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AddressID")
		{
		View_ApplicantFamilyAddressItemsPaging obj = new View_ApplicantFamilyAddressItemsPaging();
		DataTable dt = GetView_ApplicantFamilyAddressPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_ApplicantFamilyAddressItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_ApplicantFamilyAddressItems();
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
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			record.ProvinceCode = Convert.ToInt32(dt.Rows[i]["ProvinceCode"]);
			record.CountryCode = dt.Rows[i]["CountryCode"].ToString();
			record.DistrictName = dt.Rows[i]["DistrictName"].ToString();
			record.DistrictCode = dt.Rows[i]["DistrictCode"].ToString();
			record.DistrictNameEN = dt.Rows[i]["DistrictNameEN"].ToString();
			record.SubdistrictName = dt.Rows[i]["SubdistrictName"].ToString();
			record.SubdistrictCode = dt.Rows[i]["SubdistrictCode"].ToString();
			record.Soi = dt.Rows[i]["Soi"].ToString();
			recordList.Add(record);
		}
		obj.view_ApplicantFamilyAddressItems = (View_ApplicantFamilyAddressItems[])(recordList.ToArray(typeof(View_ApplicantFamilyAddressItems)));
		return obj;
		}
		protected View_ApplicantFamilyAddressRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_ApplicantFamilyAddressRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_ApplicantFamilyAddressRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
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
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int provinceCodeColumnIndex = reader.GetOrdinal("ProvinceCode");
			int countrycodeColumnIndex = reader.GetOrdinal("CountryCode");
			int districtNameColumnIndex = reader.GetOrdinal("DistrictName");
			int districtCodeColumnIndex = reader.GetOrdinal("DistrictCode");
			int districtNameENColumnIndex = reader.GetOrdinal("DistrictNameEN");
			int subdistrictNameColumnIndex = reader.GetOrdinal("SubdistrictName");
			int subdistrictCodeColumnIndex = reader.GetOrdinal("SubdistrictCode");
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
					View_ApplicantFamilyAddressRow record = new View_ApplicantFamilyAddressRow();
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

					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					record.ProvinceCode =  Convert.ToInt32(reader.GetValue(provinceCodeColumnIndex));
					record.CountryCode =  Convert.ToString(reader.GetValue(countrycodeColumnIndex));
					if (!reader.IsDBNull(districtNameColumnIndex)) record.DistrictName =  Convert.ToString(reader.GetValue(districtNameColumnIndex));

					if (!reader.IsDBNull(districtCodeColumnIndex)) record.DistrictCode =  Convert.ToString(reader.GetValue(districtCodeColumnIndex));

					if (!reader.IsDBNull(districtNameENColumnIndex)) record.DistrictNameEN =  Convert.ToString(reader.GetValue(districtNameENColumnIndex));

					if (!reader.IsDBNull(subdistrictNameColumnIndex)) record.SubdistrictName =  Convert.ToString(reader.GetValue(subdistrictNameColumnIndex));

					if (!reader.IsDBNull(subdistrictCodeColumnIndex)) record.SubdistrictCode =  Convert.ToString(reader.GetValue(subdistrictCodeColumnIndex));

					if (!reader.IsDBNull(soiColumnIndex)) record.Soi =  Convert.ToString(reader.GetValue(soiColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_ApplicantFamilyAddressRow[])(recordList.ToArray(typeof(View_ApplicantFamilyAddressRow)));
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
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceCode":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CountryCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DistrictName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DistrictCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DistrictNameEN":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SubdistrictName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SubdistrictCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

