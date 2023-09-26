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
	public partial class ProvinceCollection_Base : MarshalByRefObject
	{
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string CountryCodeColumnName = "CountryCode";
		public const string ProvinceCodeColumnName = "ProvinceCode";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string ProvinceNameENColumnName = "ProvinceNameEN";
		public const string RegionIDColumnName = "RegionID";
		public const string LatitudeColumnName = "Latitude";
		public const string LongitudeColumnName = "Longitude";
		public const string GeometryColumnName = "Geometry";
		public const string IsActiveColumnName = "IsActive";
		private int _processID;
		public SqlCommand cmd = null;
		public ProvinceCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ProvinceRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual ProvincePaging GetPagingRelyOnProvinceIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ProvincePaging provincePaging = new ProvincePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ProvinceID) as TotalRow from [dbo].[Province]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			provincePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			provincePaging.totalPage = (int)Math.Ceiling((double) provincePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnProvinceID(whereSql, "ProvinceID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			provincePaging.provinceRow = MapRecords(command);
			return provincePaging;
		}
		public virtual ProvincePaging GetPagingRelyOnProvinceIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ProvincePaging provincePaging = new ProvincePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ProvinceID) as TotalRow from [dbo].[Province]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			provincePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			provincePaging.totalPage = (int)Math.Ceiling((double)provincePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnProvinceID(whereSql, "ProvinceID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			provincePaging.provinceRow = MapRecords(command);
			return provincePaging;
		}
		public virtual ProvinceRow[] GetPagingRelyOnProvinceIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minProvinceID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ProvinceID < " + minProvinceID.ToString();
			}
			else
			{
				whereSql = "ProvinceID < " + minProvinceID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnProvinceID(whereSql, "ProvinceID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ProvinceRow[] GetPagingRelyOnProvinceIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minProvinceID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ProvinceID > " + minProvinceID.ToString();
			}
			else
			{
				whereSql = "ProvinceID > " + minProvinceID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnProvinceID(whereSql, "ProvinceID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ProvinceRow[] GetPagingRelyOnProvinceIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxProvinceID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ProvinceID < " + maxProvinceID.ToString();
			}
			else
			{
				whereSql = "ProvinceID < " + maxProvinceID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnProvinceID(whereSql, "ProvinceID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ProvinceRow[] GetPagingRelyOnProvinceIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxProvinceID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ProvinceID > " + maxProvinceID.ToString();
			}
			else
			{
				whereSql = "ProvinceID > " + maxProvinceID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnProvinceID(whereSql, "ProvinceID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ProvinceRow[] GetPagingRelyOnProvinceIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ProvinceID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			ProvinceRow[] provinceRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnProvinceID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				provinceRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnProvinceIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				provinceRow = MapRecords(command);
			}
			return provinceRow;
		}
		public virtual ProvinceRow[] GetPagingRelyOnProvinceIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ProvinceID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			ProvinceRow[] provinceRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnProvinceID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				provinceRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnProvinceIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				provinceRow = MapRecords(command);
			}
			return provinceRow;
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
			"[ProvinceID],"+
			"[CountryCode],"+
			"[ProvinceCode],"+
			"[ProvinceName],"+
			"[ProvinceNameEN],"+
			"[RegionID],"+
			"[Latitude],"+
			"[Longitude],"+
			"[Geometry].STAsText() AS Geometry,"+
			"[IsActive]"+
			" FROM [dbo].[Province]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnProvinceID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Province]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnProvinceIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ProvinceID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Province] where ProvinceID < (select min(minProvinceID) from(select top " + (rowPerPage * pageNumber).ToString() + " ProvinceID as minProvinceID from [dbo].[Province]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Province]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnProvinceIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ProvinceID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Province] where ProvinceID > (select max(maxProvinceID) from(select top " + (rowPerPage * pageNumber).ToString() + " ProvinceID as maxProvinceID from [dbo].[Province]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Province]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Province]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Province"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CountryCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 2;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceCode",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ProvinceNameEN",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("RegionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Latitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Longitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Geometry",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public virtual ProvinceRow[] GetByRegionID(int regionID)
		{
			return MapRecords(CreateGetByRegionIDCommand(regionID));
		}
		public virtual DataTable GetByRegionIDAsDataTable(int regionID)
		{
			return MapRecordsToDataTable(CreateGetByRegionIDCommand(regionID));
		}
		protected virtual IDbCommand CreateGetByRegionIDCommand(int regionID)
		{
			string whereSql = "";
			whereSql += "[RegionID]=" + CreateSqlParameterName("RegionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RegionID", regionID);
			return cmd;
		}
		public ProvinceRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ProvinceRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ProvinceRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ProvinceRow"/> objects.</returns>
		public virtual ProvinceRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Province]", top);
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
		public ProvinceRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ProvinceRow[] rows = null;
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
		public DataTable GetProvincePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProvinceID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ProvinceID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ProvinceID) AS TotalRow FROM [dbo].[Province] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ProvinceID,CountryCode,ProvinceCode,ProvinceName,ProvinceNameEN,RegionID,Latitude,Longitude,Geometry.STAsText() AS Geometry,IsActive," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Province] " + whereSql +
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
		public ProvinceItemsPaging GetProvincePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProvinceID")
		{
		ProvinceItemsPaging obj = new ProvinceItemsPaging();
		DataTable dt = GetProvincePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ProvinceItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ProvinceItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.CountryCode = dt.Rows[i]["CountryCode"].ToString();
			record.ProvinceCode = Convert.ToInt32(dt.Rows[i]["ProvinceCode"]);
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			record.ProvinceNameEN = dt.Rows[i]["ProvinceNameEN"].ToString();
			if (dt.Rows[i]["RegionID"] != DBNull.Value)
			record.RegionID = Convert.ToInt32(dt.Rows[i]["RegionID"]);
			if (dt.Rows[i]["Latitude"] != DBNull.Value)
			record.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);
			if (dt.Rows[i]["Longitude"] != DBNull.Value)
			record.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);
			record.Geometry = dt.Rows[i]["Geometry"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			recordList.Add(record);
		}
		obj.provinceItems = (ProvinceItems[])(recordList.ToArray(typeof(ProvinceItems)));
		return obj;
		}
		public ProvinceRow GetByPrimaryKey(int provinceID)
		{
			string whereSql = "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProvinceID", provinceID);
			ProvinceRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(ProvinceRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Province] (" +
			"[CountryCode], " + 
			"[ProvinceCode], " + 
			"[ProvinceName], " + 
			"[ProvinceNameEN], " + 
			"[RegionID], " + 
			"[Latitude], " + 
			"[Longitude], " + 
			"[Geometry], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("CountryCode") + ", " +
			CreateSqlParameterName("ProvinceCode") + ", " +
			CreateSqlParameterName("ProvinceName") + ", " +
			CreateSqlParameterName("ProvinceNameEN") + ", " +
			CreateSqlParameterName("RegionID") + ", " +
			CreateSqlParameterName("Latitude") + ", " +
			CreateSqlParameterName("Longitude") + ", " +
			CreateGEOMETRYSqlParameterName("Geometry") + ", " +
			CreateSqlParameterName("IsActive") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CountryCode",value.CountryCode);
			AddParameter(cmd, "ProvinceCode", value.ProvinceCode);
			AddParameter(cmd, "ProvinceName", value.ProvinceName);
			AddParameter(cmd, "ProvinceNameEN", value.ProvinceNameEN);
			AddParameter(cmd, "RegionID", value.IsRegionIDNull ? DBNull.Value : (object)value.RegionID);
			AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
			AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
			AddParameter(cmd, "Geometry", value.Geometry);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(ProvinceRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Province] (" +
			"[CountryCode], " + 
			"[ProvinceCode], " + 
			"[ProvinceName], " + 
			"[ProvinceNameEN], " + 
			"[RegionID], " + 
			"[Latitude], " + 
			"[Longitude], " + 
			"[Geometry], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("CountryCode") + ", " +
			CreateSqlParameterName("ProvinceCode") + ", " +
			CreateSqlParameterName("ProvinceName") + ", " +
			CreateSqlParameterName("ProvinceNameEN") + ", " +
			CreateSqlParameterName("RegionID") + ", " +
			CreateSqlParameterName("Latitude") + ", " +
			CreateSqlParameterName("Longitude") + ", " +
			CreateGEOMETRYSqlParameterName("Geometry") + ", " +
			CreateSqlParameterName("IsActive") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CountryCode", Sanitizer.GetSafeHtmlFragment(value.CountryCode));
			AddParameter(cmd, "ProvinceCode", value.ProvinceCode);
			AddParameter(cmd, "ProvinceName", Sanitizer.GetSafeHtmlFragment(value.ProvinceName));
			AddParameter(cmd, "ProvinceNameEN", Sanitizer.GetSafeHtmlFragment(value.ProvinceNameEN));
			AddParameter(cmd, "RegionID", value.IsRegionIDNull ? DBNull.Value : (object)value.RegionID);
			AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
			AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
			AddParameter(cmd, "Geometry", Sanitizer.GetSafeHtmlFragment(value.Geometry));
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(ProvinceRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProvinceID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCountryCode)
				{
					strUpdate += "[CountryCode]=" + CreateSqlParameterName("CountryCode") + ",";
				}
				if (value._IsSetProvinceCode)
				{
					strUpdate += "[ProvinceCode]=" + CreateSqlParameterName("ProvinceCode") + ",";
				}
				if (value._IsSetProvinceName)
				{
					strUpdate += "[ProvinceName]=" + CreateSqlParameterName("ProvinceName") + ",";
				}
				if (value._IsSetProvinceNameEN)
				{
					strUpdate += "[ProvinceNameEN]=" + CreateSqlParameterName("ProvinceNameEN") + ",";
				}
				if (value._IsSetRegionID)
				{
					strUpdate += "[RegionID]=" + CreateSqlParameterName("RegionID") + ",";
				}
				if (value._IsSetLatitude)
				{
					strUpdate += "[Latitude]=" + CreateSqlParameterName("Latitude") + ",";
				}
				if (value._IsSetLongitude)
				{
					strUpdate += "[Longitude]=" + CreateSqlParameterName("Longitude") + ",";
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
					strUpdate = "UPDATE [dbo].[Province] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "CountryCode",value.CountryCode);
					AddParameter(cmd, "ProvinceCode", value.ProvinceCode);
					AddParameter(cmd, "ProvinceName", value.ProvinceName);
					AddParameter(cmd, "ProvinceNameEN", value.ProvinceNameEN);
					AddParameter(cmd, "RegionID", value.IsRegionIDNull ? DBNull.Value : (object)value.RegionID);
					AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
					AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ProvinceID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ProvinceRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProvinceID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCountryCode)
				{
					strUpdate += "[CountryCode]=" + CreateSqlParameterName("CountryCode") + ",";
				}
				if (value._IsSetProvinceCode)
				{
					strUpdate += "[ProvinceCode]=" + CreateSqlParameterName("ProvinceCode") + ",";
				}
				if (value._IsSetProvinceName)
				{
					strUpdate += "[ProvinceName]=" + CreateSqlParameterName("ProvinceName") + ",";
				}
				if (value._IsSetProvinceNameEN)
				{
					strUpdate += "[ProvinceNameEN]=" + CreateSqlParameterName("ProvinceNameEN") + ",";
				}
				if (value._IsSetRegionID)
				{
					strUpdate += "[RegionID]=" + CreateSqlParameterName("RegionID") + ",";
				}
				if (value._IsSetLatitude)
				{
					strUpdate += "[Latitude]=" + CreateSqlParameterName("Latitude") + ",";
				}
				if (value._IsSetLongitude)
				{
					strUpdate += "[Longitude]=" + CreateSqlParameterName("Longitude") + ",";
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
					strUpdate = "UPDATE [dbo].[Province] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "CountryCode", Sanitizer.GetSafeHtmlFragment(value.CountryCode));
					AddParameter(cmd, "ProvinceCode", value.ProvinceCode);
					AddParameter(cmd, "ProvinceName", Sanitizer.GetSafeHtmlFragment(value.ProvinceName));
					AddParameter(cmd, "ProvinceNameEN", Sanitizer.GetSafeHtmlFragment(value.ProvinceNameEN));
					AddParameter(cmd, "RegionID", value.IsRegionIDNull ? DBNull.Value : (object)value.RegionID);
					AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
					AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ProvinceID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int provinceID)
		{
			string whereSql = "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProvinceID", provinceID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public ProvinceRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			ProvinceRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByRegionID(int regionID)
		{
			return DeleteByRegionID(regionID, false);
		}
		public int DeleteByRegionID(int regionID, bool regionIDNull)
		{
			return CreateDeleteByRegionIDCommand(regionID, regionIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByRegionIDCommand(int regionID, bool regionIDNull)
		{
			string whereSql = "";
			if (regionIDNull)
				whereSql += "[RegionID] IS NULL";
			else
				whereSql += "[RegionID]=" + CreateSqlParameterName("RegionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!regionIDNull)
				AddParameter(cmd, "RegionID", regionID);
			return cmd;
		}
		protected ProvinceRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ProvinceRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ProvinceRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int countrycodeColumnIndex = reader.GetOrdinal("CountryCode");
			int provinceCodeColumnIndex = reader.GetOrdinal("ProvinceCode");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int provinceNameENColumnIndex = reader.GetOrdinal("ProvinceNameEN");
			int regionIDColumnIndex = reader.GetOrdinal("RegionID");
			int latitudeColumnIndex = reader.GetOrdinal("Latitude");
			int longitudeColumnIndex = reader.GetOrdinal("Longitude");
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
					ProvinceRow record = new ProvinceRow();
					recordList.Add(record);
					record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));
					record.CountryCode =  Convert.ToString(reader.GetValue(countrycodeColumnIndex));
					record.ProvinceCode =  Convert.ToInt32(reader.GetValue(provinceCodeColumnIndex));
					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(provinceNameENColumnIndex)) record.ProvinceNameEN =  Convert.ToString(reader.GetValue(provinceNameENColumnIndex));

					if (!reader.IsDBNull(regionIDColumnIndex)) record.RegionID =  Convert.ToInt32(reader.GetValue(regionIDColumnIndex));

					if (!reader.IsDBNull(latitudeColumnIndex)) record.Latitude =  Convert.ToDouble(reader.GetValue(latitudeColumnIndex));

					if (!reader.IsDBNull(longitudeColumnIndex)) record.Longitude =  Convert.ToDouble(reader.GetValue(longitudeColumnIndex));

					if (!reader.IsDBNull(geometryColumnIndex)) record.Geometry =  Convert.ToString(reader.GetValue(geometryColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ProvinceRow[])(recordList.ToArray(typeof(ProvinceRow)));
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
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CountryCode":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceCode":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ProvinceNameEN":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RegionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Latitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Longitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
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

