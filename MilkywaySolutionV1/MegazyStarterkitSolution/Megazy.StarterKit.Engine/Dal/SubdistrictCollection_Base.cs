using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using Megazy.StarterKit.Engine.Structure;
namespace Megazy.StarterKit.Engine.Dal
{
	[Serializable]
	public partial class SubdistrictCollection_Base : MarshalByRefObject
	{
		public const string SubdistrictIDColumnName = "SubdistrictID";
		public const string DistrictIDColumnName = "DistrictID";
		public const string SubdistrictCodeColumnName = "SubdistrictCode";
		public const string SubdistrictNameColumnName = "SubdistrictName";
		public const string SubdistrictNameENColumnName = "SubdistrictNameEN";
		public const string LatitudeColumnName = "Latitude";
		public const string LongitudeColumnName = "Longitude";
		public const string PostCodeColumnName = "PostCode";
		public const string GeometryColumnName = "Geometry";
		public const string IsActiveColumnName = "IsActive";
		private int _processID;
		public SqlCommand cmd = null;
		public SubdistrictCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SubdistrictRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual SubdistrictPaging GetPagingRelyOnSubdistrictIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SubdistrictPaging subdistrictPaging = new SubdistrictPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(SubdistrictID) as TotalRow from [dbo].[Subdistrict]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			subdistrictPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			subdistrictPaging.totalPage = (int)Math.Ceiling((double) subdistrictPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnSubdistrictID(whereSql, "SubdistrictID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			subdistrictPaging.subdistrictRow = MapRecords(command);
			return subdistrictPaging;
		}
		public virtual SubdistrictPaging GetPagingRelyOnSubdistrictIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SubdistrictPaging subdistrictPaging = new SubdistrictPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(SubdistrictID) as TotalRow from [dbo].[Subdistrict]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			subdistrictPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			subdistrictPaging.totalPage = (int)Math.Ceiling((double)subdistrictPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnSubdistrictID(whereSql, "SubdistrictID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			subdistrictPaging.subdistrictRow = MapRecords(command);
			return subdistrictPaging;
		}
		public virtual SubdistrictRow[] GetPagingRelyOnSubdistrictIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minSubdistrictID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SubdistrictID < " + minSubdistrictID.ToString();
			}
			else
			{
				whereSql = "SubdistrictID < " + minSubdistrictID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSubdistrictID(whereSql, "SubdistrictID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SubdistrictRow[] GetPagingRelyOnSubdistrictIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minSubdistrictID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SubdistrictID > " + minSubdistrictID.ToString();
			}
			else
			{
				whereSql = "SubdistrictID > " + minSubdistrictID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSubdistrictID(whereSql, "SubdistrictID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SubdistrictRow[] GetPagingRelyOnSubdistrictIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxSubdistrictID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SubdistrictID < " + maxSubdistrictID.ToString();
			}
			else
			{
				whereSql = "SubdistrictID < " + maxSubdistrictID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSubdistrictID(whereSql, "SubdistrictID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SubdistrictRow[] GetPagingRelyOnSubdistrictIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxSubdistrictID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SubdistrictID > " + maxSubdistrictID.ToString();
			}
			else
			{
				whereSql = "SubdistrictID > " + maxSubdistrictID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSubdistrictID(whereSql, "SubdistrictID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SubdistrictRow[] GetPagingRelyOnSubdistrictIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "SubdistrictID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			SubdistrictRow[] subdistrictRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnSubdistrictID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				subdistrictRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnSubdistrictIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				subdistrictRow = MapRecords(command);
			}
			return subdistrictRow;
		}
		public virtual SubdistrictRow[] GetPagingRelyOnSubdistrictIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "SubdistrictID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			SubdistrictRow[] subdistrictRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnSubdistrictID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				subdistrictRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnSubdistrictIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				subdistrictRow = MapRecords(command);
			}
			return subdistrictRow;
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
			"[SubdistrictID],"+
			"[DistrictID],"+
			"[SubdistrictCode],"+
			"[SubdistrictName],"+
			"[SubdistrictNameEN],"+
			"[Latitude],"+
			"[Longitude],"+
			"[PostCode],"+
			"[Geometry].STAsText() AS Geometry,"+
			"[IsActive]"+
			" FROM [dbo].[Subdistrict]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSubdistrictID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Subdistrict]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSubdistrictIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "SubdistrictID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Subdistrict] where SubdistrictID < (select min(minSubdistrictID) from(select top " + (rowPerPage * pageNumber).ToString() + " SubdistrictID as minSubdistrictID from [dbo].[Subdistrict]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Subdistrict]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSubdistrictIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "SubdistrictID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Subdistrict] where SubdistrictID > (select max(maxSubdistrictID) from(select top " + (rowPerPage * pageNumber).ToString() + " SubdistrictID as maxSubdistrictID from [dbo].[Subdistrict]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Subdistrict]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Subdistrict]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Subdistrict"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("SubdistrictID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DistrictID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SubdistrictCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("SubdistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SubdistrictNameEN",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Latitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Longitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("PostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Geometry",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public virtual SubdistrictRow[] GetByDistrictID(int districtId)
		{
			return MapRecords(CreateGetByDistrictIDCommand(districtId));
		}
		public virtual DataTable GetByDistrictIDAsDataTable(int districtId)
		{
			return MapRecordsToDataTable(CreateGetByDistrictIDCommand(districtId));
		}
		protected virtual IDbCommand CreateGetByDistrictIDCommand(int districtId)
		{
			string whereSql = "";
			whereSql += "[DistrictID]=" + CreateSqlParameterName("DistrictID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DistrictID", districtId);
			return cmd;
		}
		public SubdistrictRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SubdistrictRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SubdistrictRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SubdistrictRow"/> objects.</returns>
		public virtual SubdistrictRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Subdistrict]", top);
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
		public SubdistrictRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SubdistrictRow[] rows = null;
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
		public DataTable GetSubdistrictPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SubdistrictID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "SubdistrictID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(SubdistrictID) AS TotalRow FROM [dbo].[Subdistrict] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,SubdistrictID,DistrictID,SubdistrictCode,SubdistrictName,SubdistrictNameEN,Latitude,Longitude,PostCode,Geometry.STAsText() AS Geometry,IsActive," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Subdistrict] " + whereSql +
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
		public SubdistrictItemsPaging GetSubdistrictPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SubdistrictID")
		{
		SubdistrictItemsPaging obj = new SubdistrictItemsPaging();
		DataTable dt = GetSubdistrictPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SubdistrictItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SubdistrictItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.SubdistrictID = Convert.ToInt32(dt.Rows[i]["SubdistrictID"]);
			if (dt.Rows[i]["DistrictID"] != DBNull.Value)
			record.DistrictID = Convert.ToInt32(dt.Rows[i]["DistrictID"]);
			record.SubdistrictCode = dt.Rows[i]["SubdistrictCode"].ToString();
			record.SubdistrictName = dt.Rows[i]["SubdistrictName"].ToString();
			record.SubdistrictNameEN = dt.Rows[i]["SubdistrictNameEN"].ToString();
			if (dt.Rows[i]["Latitude"] != DBNull.Value)
			record.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);
			if (dt.Rows[i]["Longitude"] != DBNull.Value)
			record.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);
			record.PostCode = dt.Rows[i]["PostCode"].ToString();
			record.Geometry = dt.Rows[i]["Geometry"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			recordList.Add(record);
		}
		obj.subdistrictItems = (SubdistrictItems[])(recordList.ToArray(typeof(SubdistrictItems)));
		return obj;
		}
		public SubdistrictRow GetByPrimaryKey(int subdistrictID)
		{
			string whereSql = "[SubdistrictID]=" + CreateSqlParameterName("SubdistrictID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SubdistrictID", subdistrictID);
			SubdistrictRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(SubdistrictRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Subdistrict] (" +
			"[DistrictID], " + 
			"[SubdistrictCode], " + 
			"[SubdistrictName], " + 
			"[SubdistrictNameEN], " + 
			"[Latitude], " + 
			"[Longitude], " + 
			"[PostCode], " + 
			"[Geometry], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("DistrictID") + ", " +
			CreateSqlParameterName("SubdistrictCode") + ", " +
			CreateSqlParameterName("SubdistrictName") + ", " +
			CreateSqlParameterName("SubdistrictNameEN") + ", " +
			CreateSqlParameterName("Latitude") + ", " +
			CreateSqlParameterName("Longitude") + ", " +
			CreateSqlParameterName("PostCode") + ", " +
			CreateGEOMETRYSqlParameterName("Geometry") + ", " +
			CreateSqlParameterName("IsActive") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "DistrictID", value.IsDistrictIDNull ? DBNull.Value : (object)value.DistrictID);
			AddParameter(cmd, "SubdistrictCode", value.SubdistrictCode);
			AddParameter(cmd, "SubdistrictName", value.SubdistrictName);
			AddParameter(cmd, "SubdistrictNameEN", value.SubdistrictNameEN);
			AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
			AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
			AddParameter(cmd, "PostCode", value.PostCode);
			AddParameter(cmd, "Geometry", value.Geometry);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(SubdistrictRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Subdistrict] (" +
			"[DistrictID], " + 
			"[SubdistrictCode], " + 
			"[SubdistrictName], " + 
			"[SubdistrictNameEN], " + 
			"[Latitude], " + 
			"[Longitude], " + 
			"[PostCode], " + 
			"[Geometry], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("DistrictID") + ", " +
			CreateSqlParameterName("SubdistrictCode") + ", " +
			CreateSqlParameterName("SubdistrictName") + ", " +
			CreateSqlParameterName("SubdistrictNameEN") + ", " +
			CreateSqlParameterName("Latitude") + ", " +
			CreateSqlParameterName("Longitude") + ", " +
			CreateSqlParameterName("PostCode") + ", " +
			CreateGEOMETRYSqlParameterName("Geometry") + ", " +
			CreateSqlParameterName("IsActive") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "DistrictID", value.IsDistrictIDNull ? DBNull.Value : (object)value.DistrictID);
			AddParameter(cmd, "SubdistrictCode", Sanitizer.GetSafeHtmlFragment(value.SubdistrictCode));
			AddParameter(cmd, "SubdistrictName", Sanitizer.GetSafeHtmlFragment(value.SubdistrictName));
			AddParameter(cmd, "SubdistrictNameEN", Sanitizer.GetSafeHtmlFragment(value.SubdistrictNameEN));
			AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
			AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
			AddParameter(cmd, "PostCode", Sanitizer.GetSafeHtmlFragment(value.PostCode));
			AddParameter(cmd, "Geometry", Sanitizer.GetSafeHtmlFragment(value.Geometry));
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(SubdistrictRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSubdistrictID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetDistrictID)
				{
					strUpdate += "[DistrictID]=" + CreateSqlParameterName("DistrictID") + ",";
				}
				if (value._IsSetSubdistrictCode)
				{
					strUpdate += "[SubdistrictCode]=" + CreateSqlParameterName("SubdistrictCode") + ",";
				}
				if (value._IsSetSubdistrictName)
				{
					strUpdate += "[SubdistrictName]=" + CreateSqlParameterName("SubdistrictName") + ",";
				}
				if (value._IsSetSubdistrictNameEN)
				{
					strUpdate += "[SubdistrictNameEN]=" + CreateSqlParameterName("SubdistrictNameEN") + ",";
				}
				if (value._IsSetLatitude)
				{
					strUpdate += "[Latitude]=" + CreateSqlParameterName("Latitude") + ",";
				}
				if (value._IsSetLongitude)
				{
					strUpdate += "[Longitude]=" + CreateSqlParameterName("Longitude") + ",";
				}
				if (value._IsSetPostCode)
				{
					strUpdate += "[PostCode]=" + CreateSqlParameterName("PostCode") + ",";
				}
				if (value._IsSetGeometry)
				{
					strUpdate += "[Geometry]=" + CreateGEOMETRYSqlParameterName("Geometry") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Subdistrict] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SubdistrictID]=" + CreateSqlParameterName("SubdistrictID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SubdistrictID", value.SubdistrictID);
					AddParameter(cmd, "DistrictID", value.IsDistrictIDNull ? DBNull.Value : (object)value.DistrictID);
					AddParameter(cmd, "SubdistrictCode", value.SubdistrictCode);
					AddParameter(cmd, "SubdistrictName", value.SubdistrictName);
					AddParameter(cmd, "SubdistrictNameEN", value.SubdistrictNameEN);
					AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
					AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
					AddParameter(cmd, "PostCode", value.PostCode);
					AddParameter(cmd, "Geometry", value.Geometry);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(SubdistrictID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SubdistrictRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSubdistrictID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetDistrictID)
				{
					strUpdate += "[DistrictID]=" + CreateSqlParameterName("DistrictID") + ",";
				}
				if (value._IsSetSubdistrictCode)
				{
					strUpdate += "[SubdistrictCode]=" + CreateSqlParameterName("SubdistrictCode") + ",";
				}
				if (value._IsSetSubdistrictName)
				{
					strUpdate += "[SubdistrictName]=" + CreateSqlParameterName("SubdistrictName") + ",";
				}
				if (value._IsSetSubdistrictNameEN)
				{
					strUpdate += "[SubdistrictNameEN]=" + CreateSqlParameterName("SubdistrictNameEN") + ",";
				}
				if (value._IsSetLatitude)
				{
					strUpdate += "[Latitude]=" + CreateSqlParameterName("Latitude") + ",";
				}
				if (value._IsSetLongitude)
				{
					strUpdate += "[Longitude]=" + CreateSqlParameterName("Longitude") + ",";
				}
				if (value._IsSetPostCode)
				{
					strUpdate += "[PostCode]=" + CreateSqlParameterName("PostCode") + ",";
				}
				if (value._IsSetGeometry)
				{
					strUpdate += "[Geometry]=" + CreateGEOMETRYSqlParameterName("Geometry") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Subdistrict] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SubdistrictID]=" + CreateSqlParameterName("SubdistrictID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SubdistrictID", value.SubdistrictID);
					AddParameter(cmd, "DistrictID", value.IsDistrictIDNull ? DBNull.Value : (object)value.DistrictID);
					AddParameter(cmd, "SubdistrictCode", Sanitizer.GetSafeHtmlFragment(value.SubdistrictCode));
					AddParameter(cmd, "SubdistrictName", Sanitizer.GetSafeHtmlFragment(value.SubdistrictName));
					AddParameter(cmd, "SubdistrictNameEN", Sanitizer.GetSafeHtmlFragment(value.SubdistrictNameEN));
					AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
					AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
					AddParameter(cmd, "PostCode", Sanitizer.GetSafeHtmlFragment(value.PostCode));
					AddParameter(cmd, "Geometry", Sanitizer.GetSafeHtmlFragment(value.Geometry));
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(SubdistrictID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int subdistrictID)
		{
			string whereSql = "[SubdistrictID]=" + CreateSqlParameterName("SubdistrictID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SubdistrictID", subdistrictID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public SubdistrictRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			SubdistrictRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByDistrictID(int districtId)
		{
			return DeleteByDistrictID(districtId, false);
		}
		public int DeleteByDistrictID(int districtId, bool districtIdNull)
		{
			return CreateDeleteByDistrictIDCommand(districtId, districtIdNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByDistrictIDCommand(int districtId, bool districtIdNull)
		{
			string whereSql = "";
			if (districtIdNull)
				whereSql += "[DistrictID] IS NULL";
			else
				whereSql += "[DistrictID]=" + CreateSqlParameterName("DistrictID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!districtIdNull)
				AddParameter(cmd, "DistrictID", districtId);
			return cmd;
		}
		protected SubdistrictRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SubdistrictRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SubdistrictRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int subdistrictIDColumnIndex = reader.GetOrdinal("SubdistrictID");
			int districtIdColumnIndex = reader.GetOrdinal("DistrictID");
			int subdistrictCodeColumnIndex = reader.GetOrdinal("SubdistrictCode");
			int subdistrictNameColumnIndex = reader.GetOrdinal("SubdistrictName");
			int subdistrictNameENColumnIndex = reader.GetOrdinal("SubdistrictNameEN");
			int latitudeColumnIndex = reader.GetOrdinal("Latitude");
			int longitudeColumnIndex = reader.GetOrdinal("Longitude");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			int geometryColumnIndex = reader.GetOrdinal("Geometry");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					SubdistrictRow record = new SubdistrictRow();
					recordList.Add(record);
					record.SubdistrictID =  Convert.ToInt32(reader.GetValue(subdistrictIDColumnIndex));
					if (!reader.IsDBNull(districtIdColumnIndex)) record.DistrictID =  Convert.ToInt32(reader.GetValue(districtIdColumnIndex));

					if (!reader.IsDBNull(subdistrictCodeColumnIndex)) record.SubdistrictCode =  Convert.ToString(reader.GetValue(subdistrictCodeColumnIndex));

					if (!reader.IsDBNull(subdistrictNameColumnIndex)) record.SubdistrictName =  Convert.ToString(reader.GetValue(subdistrictNameColumnIndex));

					if (!reader.IsDBNull(subdistrictNameENColumnIndex)) record.SubdistrictNameEN =  Convert.ToString(reader.GetValue(subdistrictNameENColumnIndex));

					if (!reader.IsDBNull(latitudeColumnIndex)) record.Latitude =  Convert.ToDouble(reader.GetValue(latitudeColumnIndex));

					if (!reader.IsDBNull(longitudeColumnIndex)) record.Longitude =  Convert.ToDouble(reader.GetValue(longitudeColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (!reader.IsDBNull(geometryColumnIndex)) record.Geometry =  Convert.ToString(reader.GetValue(geometryColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SubdistrictRow[])(recordList.ToArray(typeof(SubdistrictRow)));
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
				case "SubdistrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DistrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubdistrictCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SubdistrictName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SubdistrictNameEN":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Latitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Longitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "PostCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Geometry":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

