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
	public partial class DistrictCollection_Base : MarshalByRefObject
	{
		public const string DistrictIDColumnName = "DistrictID";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string DistrictCodeColumnName = "DistrictCode";
		public const string DistrictNameColumnName = "DistrictName";
		public const string DistrictNameENColumnName = "DistrictNameEN";
		public const string LatitudeColumnName = "Latitude";
		public const string LongitudeColumnName = "Longitude";
		public const string GeometryColumnName = "Geometry";
		public const string IsActiveColumnName = "IsActive";
		private int _processID;
		public SqlCommand cmd = null;
		public DistrictCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual DistrictRow[] GetAll()
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
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[DistrictID],"+
			"[ProvinceID],"+
			"[DistrictCode],"+
			"[DistrictName],"+
			"[DistrictNameEN],"+
			"[Latitude],"+
			"[Longitude],"+
			"[Geometry].STAsText() AS Geometry,"+
			"[IsActive]"+
			" FROM [dbo].[District]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[District]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "District"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("DistrictID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DistrictCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("DistrictName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DistrictNameEN",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Latitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Longitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Geometry",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public virtual DistrictRow[] GetByProvinceID(int provinceID)
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
		public DistrictRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual DistrictRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="DistrictRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DistrictRow"/> objects.</returns>
		public virtual DistrictRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[District]", top);
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
		public DistrictRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			DistrictRow[] rows = null;
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
		public DataTable GetDistrictPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "DistrictID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "DistrictID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(DistrictID) AS TotalRow FROM [dbo].[District] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,DistrictID,ProvinceID,DistrictCode,DistrictName,DistrictNameEN,Latitude,Longitude,Geometry.STAsText() AS Geometry,IsActive," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[District] " + whereSql +
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
		public DistrictItemsPaging GetDistrictPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "DistrictID")
		{
		DistrictItemsPaging obj = new DistrictItemsPaging();
		DataTable dt = GetDistrictPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		DistrictItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new DistrictItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.DistrictID = Convert.ToInt32(dt.Rows[i]["DistrictID"]);
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.DistrictCode = dt.Rows[i]["DistrictCode"].ToString();
			record.DistrictName = dt.Rows[i]["DistrictName"].ToString();
			record.DistrictNameEN = dt.Rows[i]["DistrictNameEN"].ToString();
			if (dt.Rows[i]["Latitude"] != DBNull.Value)
			record.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);
			if (dt.Rows[i]["Longitude"] != DBNull.Value)
			record.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);
			record.Geometry = dt.Rows[i]["Geometry"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			recordList.Add(record);
		}
		obj.districtItems = (DistrictItems[])(recordList.ToArray(typeof(DistrictItems)));
		return obj;
		}
		public DistrictRow GetByPrimaryKey(int districtId)
		{
			string whereSql = "[DistrictID]=" + CreateSqlParameterName("DistrictID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DistrictID", districtId);
			DistrictRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(DistrictRow value)		{
			string sqlStr = "INSERT INTO [dbo].[District] (" +
			"[DistrictID], " + 
			"[ProvinceID], " + 
			"[DistrictCode], " + 
			"[DistrictName], " + 
			"[DistrictNameEN], " + 
			"[Latitude], " + 
			"[Longitude], " + 
			"[Geometry], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("DistrictID") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DistrictCode") + ", " +
			CreateSqlParameterName("DistrictName") + ", " +
			CreateSqlParameterName("DistrictNameEN") + ", " +
			CreateSqlParameterName("Latitude") + ", " +
			CreateSqlParameterName("Longitude") + ", " +
			CreateGEOMETRYSqlParameterName("Geometry") + ", " +
			CreateSqlParameterName("IsActive") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "DistrictID", value.DistrictID);
			AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
			AddParameter(cmd, "DistrictCode", value.DistrictCode);
			AddParameter(cmd, "DistrictName", value.DistrictName);
			AddParameter(cmd, "DistrictNameEN", value.DistrictNameEN);
			AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
			AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
			AddParameter(cmd, "Geometry", value.Geometry);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(DistrictRow value)		{
			string sqlStr = "INSERT INTO [dbo].[District] (" +
			"[DistrictID], " + 
			"[ProvinceID], " + 
			"[DistrictCode], " + 
			"[DistrictName], " + 
			"[DistrictNameEN], " + 
			"[Latitude], " + 
			"[Longitude], " + 
			"[Geometry], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("DistrictID") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DistrictCode") + ", " +
			CreateSqlParameterName("DistrictName") + ", " +
			CreateSqlParameterName("DistrictNameEN") + ", " +
			CreateSqlParameterName("Latitude") + ", " +
			CreateSqlParameterName("Longitude") + ", " +
			CreateGEOMETRYSqlParameterName("Geometry") + ", " +
			CreateSqlParameterName("IsActive") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "DistrictID", value.DistrictID);
			AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
			AddParameter(cmd, "DistrictCode", Sanitizer.GetSafeHtmlFragment(value.DistrictCode));
			AddParameter(cmd, "DistrictName", Sanitizer.GetSafeHtmlFragment(value.DistrictName));
			AddParameter(cmd, "DistrictNameEN", Sanitizer.GetSafeHtmlFragment(value.DistrictNameEN));
			AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
			AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
			AddParameter(cmd, "Geometry", Sanitizer.GetSafeHtmlFragment(value.Geometry));
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			cmd.ExecuteNonQuery();
		}
		public bool Update(DistrictRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetDistrictID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDistrictCode)
				{
					strUpdate += "[DistrictCode]=" + CreateSqlParameterName("DistrictCode") + ",";
				}
				if (value._IsSetDistrictName)
				{
					strUpdate += "[DistrictName]=" + CreateSqlParameterName("DistrictName") + ",";
				}
				if (value._IsSetDistrictNameEN)
				{
					strUpdate += "[DistrictNameEN]=" + CreateSqlParameterName("DistrictNameEN") + ",";
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
					strUpdate = "UPDATE [dbo].[District] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[DistrictID]=" + CreateSqlParameterName("DistrictID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "DistrictID", value.DistrictID);
					AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
					AddParameter(cmd, "DistrictCode", value.DistrictCode);
					AddParameter(cmd, "DistrictName", value.DistrictName);
					AddParameter(cmd, "DistrictNameEN", value.DistrictNameEN);
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
				Exception ex = new Exception("Set incorrect primarykey PK(DistrictID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(DistrictRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetDistrictID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDistrictCode)
				{
					strUpdate += "[DistrictCode]=" + CreateSqlParameterName("DistrictCode") + ",";
				}
				if (value._IsSetDistrictName)
				{
					strUpdate += "[DistrictName]=" + CreateSqlParameterName("DistrictName") + ",";
				}
				if (value._IsSetDistrictNameEN)
				{
					strUpdate += "[DistrictNameEN]=" + CreateSqlParameterName("DistrictNameEN") + ",";
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
					strUpdate = "UPDATE [dbo].[District] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[DistrictID]=" + CreateSqlParameterName("DistrictID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "DistrictID", value.DistrictID);
					AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
					AddParameter(cmd, "DistrictCode", Sanitizer.GetSafeHtmlFragment(value.DistrictCode));
					AddParameter(cmd, "DistrictName", Sanitizer.GetSafeHtmlFragment(value.DistrictName));
					AddParameter(cmd, "DistrictNameEN", Sanitizer.GetSafeHtmlFragment(value.DistrictNameEN));
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
				Exception ex = new Exception("Set incorrect primarykey PK(DistrictID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int districtId)
		{
			string whereSql = "[DistrictID]=" + CreateSqlParameterName("DistrictID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DistrictID", districtId);
			return 0 < cmd.ExecuteNonQuery();
		}
		public DistrictRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			DistrictRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
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
		protected DistrictRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected DistrictRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected DistrictRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int districtIdColumnIndex = reader.GetOrdinal("DistrictID");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int districtCodeColumnIndex = reader.GetOrdinal("DistrictCode");
			int districtNameColumnIndex = reader.GetOrdinal("DistrictName");
			int districtNameENColumnIndex = reader.GetOrdinal("DistrictNameEN");
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
					DistrictRow record = new DistrictRow();
					recordList.Add(record);
					record.DistrictID =  Convert.ToInt32(reader.GetValue(districtIdColumnIndex));
					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(districtCodeColumnIndex)) record.DistrictCode =  Convert.ToString(reader.GetValue(districtCodeColumnIndex));

					if (!reader.IsDBNull(districtNameColumnIndex)) record.DistrictName =  Convert.ToString(reader.GetValue(districtNameColumnIndex));

					if (!reader.IsDBNull(districtNameENColumnIndex)) record.DistrictNameEN =  Convert.ToString(reader.GetValue(districtNameENColumnIndex));

					if (!reader.IsDBNull(latitudeColumnIndex)) record.Latitude =  Convert.ToDouble(reader.GetValue(latitudeColumnIndex));

					if (!reader.IsDBNull(longitudeColumnIndex)) record.Longitude =  Convert.ToDouble(reader.GetValue(longitudeColumnIndex));

					if (!reader.IsDBNull(geometryColumnIndex)) record.Geometry =  Convert.ToString(reader.GetValue(geometryColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DistrictRow[])(recordList.ToArray(typeof(DistrictRow)));
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
				case "DistrictID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DistrictCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DistrictName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DistrictNameEN":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

