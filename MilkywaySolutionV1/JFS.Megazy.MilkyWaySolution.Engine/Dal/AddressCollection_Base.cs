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
	public partial class AddressCollection_Base : MarshalByRefObject
	{
		public const string AddressIDColumnName = "AddressID";
		public const string Address1ColumnName = "Address1";
		public const string HouseNoColumnName = "HouseNo";
		public const string VillageNoColumnName = "VillageNo";
		public const string SoiColumnName = "Soi";
		public const string StreetColumnName = "Street";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string DisctrictIDColumnName = "DisctrictID";
		public const string SubdistrictIDColumnName = "SubdistrictID";
		public const string PostCodeColumnName = "PostCode";
		public const string CreatedateColumnName = "Createdate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public AddressCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual AddressRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual AddressPaging GetPagingRelyOnAddressIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			AddressPaging addressPaging = new AddressPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AddressID) as TotalRow from [dbo].[Address]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			addressPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			addressPaging.totalPage = (int)Math.Ceiling((double) addressPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAddressID(whereSql, "AddressID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			addressPaging.addressRow = MapRecords(command);
			return addressPaging;
		}
		public virtual AddressPaging GetPagingRelyOnAddressIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			AddressPaging addressPaging = new AddressPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AddressID) as TotalRow from [dbo].[Address]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			addressPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			addressPaging.totalPage = (int)Math.Ceiling((double)addressPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAddressID(whereSql, "AddressID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			addressPaging.addressRow = MapRecords(command);
			return addressPaging;
		}
		public virtual AddressRow[] GetPagingRelyOnAddressIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAddressID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AddressID < " + minAddressID.ToString();
			}
			else
			{
				whereSql = "AddressID < " + minAddressID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAddressID(whereSql, "AddressID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AddressRow[] GetPagingRelyOnAddressIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAddressID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AddressID > " + minAddressID.ToString();
			}
			else
			{
				whereSql = "AddressID > " + minAddressID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAddressID(whereSql, "AddressID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AddressRow[] GetPagingRelyOnAddressIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAddressID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AddressID < " + maxAddressID.ToString();
			}
			else
			{
				whereSql = "AddressID < " + maxAddressID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAddressID(whereSql, "AddressID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AddressRow[] GetPagingRelyOnAddressIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAddressID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AddressID > " + maxAddressID.ToString();
			}
			else
			{
				whereSql = "AddressID > " + maxAddressID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAddressID(whereSql, "AddressID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AddressRow[] GetPagingRelyOnAddressIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AddressID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			AddressRow[] addressRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAddressID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				addressRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAddressIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				addressRow = MapRecords(command);
			}
			return addressRow;
		}
		public virtual AddressRow[] GetPagingRelyOnAddressIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AddressID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			AddressRow[] addressRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAddressID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				addressRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAddressIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				addressRow = MapRecords(command);
			}
			return addressRow;
		}
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[AddressID],"+
			"[Address1],"+
			"[HouseNo],"+
			"[VillageNo],"+
			"[Soi],"+
			"[Street],"+
			"[ProvinceID],"+
			"[DisctrictID],"+
			"[SubdistrictID],"+
			"[PostCode],"+
			"[Createdate],"+
			"[ModifiedDate]"+
			" FROM [dbo].[Address]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAddressID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Address]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAddressIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AddressID Desc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Address] where AddressID < (select min(minAddressID) from(select top " + (rowPerPage * pageNumber).ToString() + " AddressID as minAddressID from [dbo].[Address]" + subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Address]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAddressIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AddressID Asc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Address] where AddressID > (select max(maxAddressID) from(select top " + (rowPerPage * pageNumber).ToString() + " AddressID as maxAddressID from [dbo].[Address]" +  subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Address]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Address]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Address"
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
			dataColumn = dataTable.Columns.Add("Soi",Type.GetType("System.String"));
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
			return dataTable;
		}
		public virtual AddressRow[] GetByProvinceID(int provinceID)
		{
			return MapRecords(CreateGetByProvinceIDCommand(provinceID));
		}
		public virtual DataTable GetByProvinceIDAsDataTable(int provinceID)
		{
			return MapRecordsToDataTable(CreateGetByProvinceIDCommand(provinceID));
		}
		protected virtual IDbCommand CreateGetByProvinceIDCommand(int provinceID)
		{
			string whereSql = "";
			whereSql += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProvinceID", provinceID);
			return cmd;
		}
		public virtual AddressRow[] GetByDisctrictID(int disctrictId)
		{
			return MapRecords(CreateGetByDisctrictIDCommand(disctrictId));
		}
		public virtual DataTable GetByDisctrictIDAsDataTable(int disctrictId)
		{
			return MapRecordsToDataTable(CreateGetByDisctrictIDCommand(disctrictId));
		}
		protected virtual IDbCommand CreateGetByDisctrictIDCommand(int disctrictId)
		{
			string whereSql = "";
			whereSql += "[DisctrictID]=" + CreateSqlParameterName("DisctrictID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DisctrictID", disctrictId);
			return cmd;
		}
		public virtual AddressRow[] GetBySubdistrictID(int subdistrictID)
		{
			return MapRecords(CreateGetBySubdistrictIDCommand(subdistrictID));
		}
		public virtual DataTable GetBySubdistrictIDAsDataTable(int subdistrictID)
		{
			return MapRecordsToDataTable(CreateGetBySubdistrictIDCommand(subdistrictID));
		}
		protected virtual IDbCommand CreateGetBySubdistrictIDCommand(int subdistrictID)
		{
			string whereSql = "";
			whereSql += "[SubdistrictID]=" + CreateSqlParameterName("SubdistrictID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SubdistrictID", subdistrictID);
			return cmd;
		}
		public AddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual AddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="AddressRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="AddressRow"/> objects.</returns>
		public virtual AddressRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Address]", top);
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
		public AddressRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			AddressRow[] rows = null;
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
		public DataTable GetAddressPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AddressID")
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
		string sql = "SELECT COUNT(AddressID) AS TotalRow FROM [dbo].[Address] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,AddressID,Address1,HouseNo,VillageNo,Soi,Street,ProvinceID,DisctrictID,SubdistrictID,PostCode,Createdate,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Address] " + whereSql +
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
		public AddressItemsPaging GetAddressPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AddressID")
		{
		AddressItemsPaging obj = new AddressItemsPaging();
		DataTable dt = GetAddressPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		AddressItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new AddressItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			record.Address1 = dt.Rows[i]["Address1"].ToString();
			record.HouseNo = dt.Rows[i]["HouseNo"].ToString();
			record.VillageNo = dt.Rows[i]["VillageNo"].ToString();
			record.Soi = dt.Rows[i]["Soi"].ToString();
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
			recordList.Add(record);
		}
		obj.addressItems = (AddressItems[])(recordList.ToArray(typeof(AddressItems)));
		return obj;
		}
		public AddressRow GetByPrimaryKey(int addressID)
		{
			string whereSql = "[AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AddressID", addressID);
			AddressRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(AddressRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Address] (" +
			"[Address1], " + 
			"[HouseNo], " + 
			"[VillageNo], " + 
			"[Soi], " + 
			"[Street], " + 
			"[ProvinceID], " + 
			"[DisctrictID], " + 
			"[SubdistrictID], " + 
			"[PostCode], " + 
			"[Createdate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("Address1") + ", " +
			CreateSqlParameterName("HouseNo") + ", " +
			CreateSqlParameterName("VillageNo") + ", " +
			CreateSqlParameterName("Soi") + ", " +
			CreateSqlParameterName("Street") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DisctrictID") + ", " +
			CreateSqlParameterName("SubdistrictID") + ", " +
			CreateSqlParameterName("PostCode") + ", " +
			CreateSqlParameterName("Createdate") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Address1", value.Address1);
			AddParameter(cmd, "HouseNo", value.HouseNo);
			AddParameter(cmd, "VillageNo", value.VillageNo);
			AddParameter(cmd, "Soi", value.Soi);
			AddParameter(cmd, "Street", value.Street);
			AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
			AddParameter(cmd, "DisctrictID", value.IsDisctrictIDNull ? DBNull.Value : (object)value.DisctrictID);
			AddParameter(cmd, "SubdistrictID", value.IsSubdistrictIDNull ? DBNull.Value : (object)value.SubdistrictID);
			AddParameter(cmd, "PostCode", value.PostCode);
			AddParameter(cmd, "Createdate", value.IsCreatedateNull ? DBNull.Value : (object)value.Createdate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(AddressRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Address] (" +
			"[Address1], " + 
			"[HouseNo], " + 
			"[VillageNo], " + 
			"[Soi], " + 
			"[Street], " + 
			"[ProvinceID], " + 
			"[DisctrictID], " + 
			"[SubdistrictID], " + 
			"[PostCode], " + 
			"[Createdate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("Address1") + ", " +
			CreateSqlParameterName("HouseNo") + ", " +
			CreateSqlParameterName("VillageNo") + ", " +
			CreateSqlParameterName("Soi") + ", " +
			CreateSqlParameterName("Street") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DisctrictID") + ", " +
			CreateSqlParameterName("SubdistrictID") + ", " +
			CreateSqlParameterName("PostCode") + ", " +
			CreateSqlParameterName("Createdate") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Address1", Sanitizer.GetSafeHtmlFragment(value.Address1));
			AddParameter(cmd, "HouseNo", Sanitizer.GetSafeHtmlFragment(value.HouseNo));
			AddParameter(cmd, "VillageNo", Sanitizer.GetSafeHtmlFragment(value.VillageNo));
			AddParameter(cmd, "Soi", Sanitizer.GetSafeHtmlFragment(value.Soi));
			AddParameter(cmd, "Street", Sanitizer.GetSafeHtmlFragment(value.Street));
			AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
			AddParameter(cmd, "DisctrictID", value.IsDisctrictIDNull ? DBNull.Value : (object)value.DisctrictID);
			AddParameter(cmd, "SubdistrictID", value.IsSubdistrictIDNull ? DBNull.Value : (object)value.SubdistrictID);
			AddParameter(cmd, "PostCode", Sanitizer.GetSafeHtmlFragment(value.PostCode));
			AddParameter(cmd, "Createdate", value.IsCreatedateNull ? DBNull.Value : (object)value.Createdate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(AddressRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAddressID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAddress1)
				{
					strUpdate += "[Address1]=" + CreateSqlParameterName("Address1") + ",";
				}
				if (value._IsSetHouseNo)
				{
					strUpdate += "[HouseNo]=" + CreateSqlParameterName("HouseNo") + ",";
				}
				if (value._IsSetVillageNo)
				{
					strUpdate += "[VillageNo]=" + CreateSqlParameterName("VillageNo") + ",";
				}
				if (value._IsSetSoi)
				{
					strUpdate += "[Soi]=" + CreateSqlParameterName("Soi") + ",";
				}
				if (value._IsSetStreet)
				{
					strUpdate += "[Street]=" + CreateSqlParameterName("Street") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDisctrictID)
				{
					strUpdate += "[DisctrictID]=" + CreateSqlParameterName("DisctrictID") + ",";
				}
				if (value._IsSetSubdistrictID)
				{
					strUpdate += "[SubdistrictID]=" + CreateSqlParameterName("SubdistrictID") + ",";
				}
				if (value._IsSetPostCode)
				{
					strUpdate += "[PostCode]=" + CreateSqlParameterName("PostCode") + ",";
				}
				if (value._IsSetCreatedate)
				{
					strUpdate += "[Createdate]=" + CreateSqlParameterName("Createdate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Address] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AddressID", value.AddressID);
					AddParameter(cmd, "Address1", value.Address1);
					AddParameter(cmd, "HouseNo", value.HouseNo);
					AddParameter(cmd, "VillageNo", value.VillageNo);
					AddParameter(cmd, "Soi", value.Soi);
					AddParameter(cmd, "Street", value.Street);
					AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
					AddParameter(cmd, "DisctrictID", value.IsDisctrictIDNull ? DBNull.Value : (object)value.DisctrictID);
					AddParameter(cmd, "SubdistrictID", value.IsSubdistrictIDNull ? DBNull.Value : (object)value.SubdistrictID);
					AddParameter(cmd, "PostCode", value.PostCode);
					AddParameter(cmd, "Createdate", value.IsCreatedateNull ? DBNull.Value : (object)value.Createdate);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(AddressID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(AddressRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAddressID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAddress1)
				{
					strUpdate += "[Address1]=" + CreateSqlParameterName("Address1") + ",";
				}
				if (value._IsSetHouseNo)
				{
					strUpdate += "[HouseNo]=" + CreateSqlParameterName("HouseNo") + ",";
				}
				if (value._IsSetVillageNo)
				{
					strUpdate += "[VillageNo]=" + CreateSqlParameterName("VillageNo") + ",";
				}
				if (value._IsSetSoi)
				{
					strUpdate += "[Soi]=" + CreateSqlParameterName("Soi") + ",";
				}
				if (value._IsSetStreet)
				{
					strUpdate += "[Street]=" + CreateSqlParameterName("Street") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDisctrictID)
				{
					strUpdate += "[DisctrictID]=" + CreateSqlParameterName("DisctrictID") + ",";
				}
				if (value._IsSetSubdistrictID)
				{
					strUpdate += "[SubdistrictID]=" + CreateSqlParameterName("SubdistrictID") + ",";
				}
				if (value._IsSetPostCode)
				{
					strUpdate += "[PostCode]=" + CreateSqlParameterName("PostCode") + ",";
				}
				if (value._IsSetCreatedate)
				{
					strUpdate += "[Createdate]=" + CreateSqlParameterName("Createdate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Address] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AddressID", value.AddressID);
					AddParameter(cmd, "Address1", Sanitizer.GetSafeHtmlFragment(value.Address1));
					AddParameter(cmd, "HouseNo", Sanitizer.GetSafeHtmlFragment(value.HouseNo));
					AddParameter(cmd, "VillageNo", Sanitizer.GetSafeHtmlFragment(value.VillageNo));
					AddParameter(cmd, "Soi", Sanitizer.GetSafeHtmlFragment(value.Soi));
					AddParameter(cmd, "Street", Sanitizer.GetSafeHtmlFragment(value.Street));
					AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
					AddParameter(cmd, "DisctrictID", value.IsDisctrictIDNull ? DBNull.Value : (object)value.DisctrictID);
					AddParameter(cmd, "SubdistrictID", value.IsSubdistrictIDNull ? DBNull.Value : (object)value.SubdistrictID);
					AddParameter(cmd, "PostCode", Sanitizer.GetSafeHtmlFragment(value.PostCode));
					AddParameter(cmd, "Createdate", value.IsCreatedateNull ? DBNull.Value : (object)value.Createdate);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(AddressID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int addressID)
		{
			string whereSql = "[AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AddressID", addressID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByProvinceID(int provinceID)
		{
			return DeleteByProvinceID(provinceID, false);
		}
		public int DeleteByProvinceID(int provinceID, bool provinceIDNull)
		{
			return CreateDeleteByProvinceIDCommand(provinceID, provinceIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByProvinceIDCommand(int provinceID, bool provinceIDNull)
		{
			string whereSql = "";
			if (provinceIDNull)
				whereSql += "[ProvinceID] IS NULL";
			else
				whereSql += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!provinceIDNull)
				AddParameter(cmd, "ProvinceID", provinceID);
			return cmd;
		}
		public int DeleteByDisctrictID(int disctrictId)
		{
			return DeleteByDisctrictID(disctrictId, false);
		}
		public int DeleteByDisctrictID(int disctrictId, bool disctrictIdNull)
		{
			return CreateDeleteByDisctrictIDCommand(disctrictId, disctrictIdNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByDisctrictIDCommand(int disctrictId, bool disctrictIdNull)
		{
			string whereSql = "";
			if (disctrictIdNull)
				whereSql += "[DisctrictID] IS NULL";
			else
				whereSql += "[DisctrictID]=" + CreateSqlParameterName("DisctrictID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!disctrictIdNull)
				AddParameter(cmd, "DisctrictID", disctrictId);
			return cmd;
		}
		public int DeleteBySubdistrictID(int subdistrictID)
		{
			return DeleteBySubdistrictID(subdistrictID, false);
		}
		public int DeleteBySubdistrictID(int subdistrictID, bool subdistrictIDNull)
		{
			return CreateDeleteBySubdistrictIDCommand(subdistrictID, subdistrictIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteBySubdistrictIDCommand(int subdistrictID, bool subdistrictIDNull)
		{
			string whereSql = "";
			if (subdistrictIDNull)
				whereSql += "[SubdistrictID] IS NULL";
			else
				whereSql += "[SubdistrictID]=" + CreateSqlParameterName("SubdistrictID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!subdistrictIDNull)
				AddParameter(cmd, "SubdistrictID", subdistrictID);
			return cmd;
		}
		protected AddressRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected AddressRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected AddressRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int address1ColumnIndex = reader.GetOrdinal("Address1");
			int houseNoColumnIndex = reader.GetOrdinal("HouseNo");
			int villageNoColumnIndex = reader.GetOrdinal("VillageNo");
			int soiColumnIndex = reader.GetOrdinal("Soi");
			int streetColumnIndex = reader.GetOrdinal("Street");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int disctrictIdColumnIndex = reader.GetOrdinal("DisctrictID");
			int subdistrictIDColumnIndex = reader.GetOrdinal("SubdistrictID");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			int createdateColumnIndex = reader.GetOrdinal("Createdate");
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
					AddressRow record = new AddressRow();
					recordList.Add(record);
					record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));
					if (!reader.IsDBNull(address1ColumnIndex)) record.Address1 =  Convert.ToString(reader.GetValue(address1ColumnIndex));

					if (!reader.IsDBNull(houseNoColumnIndex)) record.HouseNo =  Convert.ToString(reader.GetValue(houseNoColumnIndex));

					if (!reader.IsDBNull(villageNoColumnIndex)) record.VillageNo =  Convert.ToString(reader.GetValue(villageNoColumnIndex));

					if (!reader.IsDBNull(soiColumnIndex)) record.Soi =  Convert.ToString(reader.GetValue(soiColumnIndex));

					if (!reader.IsDBNull(streetColumnIndex)) record.Street =  Convert.ToString(reader.GetValue(streetColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(disctrictIdColumnIndex)) record.DisctrictID =  Convert.ToInt32(reader.GetValue(disctrictIdColumnIndex));

					if (!reader.IsDBNull(subdistrictIDColumnIndex)) record.SubdistrictID =  Convert.ToInt32(reader.GetValue(subdistrictIDColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (!reader.IsDBNull(createdateColumnIndex)) record.Createdate =  Convert.ToDateTime(reader.GetValue(createdateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (AddressRow[])(recordList.ToArray(typeof(AddressRow)));
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
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "HouseNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "VillageNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Soi":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Street":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

