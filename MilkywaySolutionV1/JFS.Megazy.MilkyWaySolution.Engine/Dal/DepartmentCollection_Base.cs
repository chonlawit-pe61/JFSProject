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
	public partial class DepartmentCollection_Base : MarshalByRefObject
	{
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string DepartmentNameAbbrColumnName = "DepartmentNameAbbr";
		public const string DepartmentCodeColumnName = "DepartmentCode";
		public const string IsActiveColumnName = "IsActive";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string SortOderColumnName = "SortOder";
		private int _processID;
		public SqlCommand cmd = null;
		public DepartmentCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual DepartmentRow[] GetAll()
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
			"[DepartmentID],"+
			"[ProvinceID],"+
			"[DepartmentName],"+
			"[DepartmentNameAbbr],"+
			"[DepartmentCode],"+
			"[IsActive],"+
			"[ModifiedDate],"+
			"[SortOder]"+
			" FROM [dbo].[Department]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Department]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Department"
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
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("SortOder",Type.GetType("System.Int32"));
			return dataTable;
		}
		public virtual DepartmentRow[] GetByProvinceID(int provinceID)
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
		public DepartmentRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual DepartmentRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="DepartmentRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DepartmentRow"/> objects.</returns>
		public virtual DepartmentRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Department]", top);
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
		public DepartmentRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			DepartmentRow[] rows = null;
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
		public DataTable GetDepartmentPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "DepartmentID")
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
		string sql = "SELECT COUNT(DepartmentID) AS TotalRow FROM [dbo].[Department] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,DepartmentID,ProvinceID,DepartmentName,DepartmentNameAbbr,DepartmentCode,IsActive,ModifiedDate,SortOder," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Department] " + whereSql +
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
		public DepartmentItemsPaging GetDepartmentPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "DepartmentID")
		{
		DepartmentItemsPaging obj = new DepartmentItemsPaging();
		DataTable dt = GetDepartmentPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		DepartmentItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new DepartmentItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			record.DepartmentNameAbbr = dt.Rows[i]["DepartmentNameAbbr"].ToString();
			record.DepartmentCode = dt.Rows[i]["DepartmentCode"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["SortOder"] != DBNull.Value)
			record.SortOder = Convert.ToInt32(dt.Rows[i]["SortOder"]);
			recordList.Add(record);
		}
		obj.departmentItems = (DepartmentItems[])(recordList.ToArray(typeof(DepartmentItems)));
		return obj;
		}
		public DepartmentRow GetByPrimaryKey(int departmentId)
		{
			string whereSql = "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DepartmentID", departmentId);
			DepartmentRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(DepartmentRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Department] (" +
			"[DepartmentID], " + 
			"[ProvinceID], " + 
			"[DepartmentName], " + 
			"[DepartmentNameAbbr], " + 
			"[DepartmentCode], " + 
			"[IsActive], " + 
			"[ModifiedDate], " + 
			"[SortOder]			" + 
			") VALUES (" +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DepartmentName") + ", " +
			CreateSqlParameterName("DepartmentNameAbbr") + ", " +
			CreateSqlParameterName("DepartmentCode") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("SortOder") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "DepartmentName",value.DepartmentName);
			AddParameter(cmd, "DepartmentNameAbbr",value.DepartmentNameAbbr);
			AddParameter(cmd, "DepartmentCode", value.DepartmentCode);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "SortOder", value.IsSortOderNull ? DBNull.Value : (object)value.SortOder);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(DepartmentRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Department] (" +
			"[DepartmentID], " + 
			"[ProvinceID], " + 
			"[DepartmentName], " + 
			"[DepartmentNameAbbr], " + 
			"[DepartmentCode], " + 
			"[IsActive], " + 
			"[ModifiedDate], " + 
			"[SortOder]			" + 
			") VALUES (" +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DepartmentName") + ", " +
			CreateSqlParameterName("DepartmentNameAbbr") + ", " +
			CreateSqlParameterName("DepartmentCode") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("SortOder") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "DepartmentName", Sanitizer.GetSafeHtmlFragment(value.DepartmentName));
			AddParameter(cmd, "DepartmentNameAbbr", Sanitizer.GetSafeHtmlFragment(value.DepartmentNameAbbr));
			AddParameter(cmd, "DepartmentCode", Sanitizer.GetSafeHtmlFragment(value.DepartmentCode));
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "SortOder", value.IsSortOderNull ? DBNull.Value : (object)value.SortOder);
			cmd.ExecuteNonQuery();
		}
		public bool Update(DepartmentRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDepartmentName)
				{
					strUpdate += "[DepartmentName]=" + CreateSqlParameterName("DepartmentName") + ",";
				}
				if (value._IsSetDepartmentNameAbbr)
				{
					strUpdate += "[DepartmentNameAbbr]=" + CreateSqlParameterName("DepartmentNameAbbr") + ",";
				}
				if (value._IsSetDepartmentCode)
				{
					strUpdate += "[DepartmentCode]=" + CreateSqlParameterName("DepartmentCode") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetSortOder)
				{
					strUpdate += "[SortOder]=" + CreateSqlParameterName("SortOder") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Department] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "DepartmentName",value.DepartmentName);
					AddParameter(cmd, "DepartmentNameAbbr",value.DepartmentNameAbbr);
					AddParameter(cmd, "DepartmentCode", value.DepartmentCode);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "SortOder", value.IsSortOderNull ? DBNull.Value : (object)value.SortOder);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(DepartmentRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDepartmentName)
				{
					strUpdate += "[DepartmentName]=" + CreateSqlParameterName("DepartmentName") + ",";
				}
				if (value._IsSetDepartmentNameAbbr)
				{
					strUpdate += "[DepartmentNameAbbr]=" + CreateSqlParameterName("DepartmentNameAbbr") + ",";
				}
				if (value._IsSetDepartmentCode)
				{
					strUpdate += "[DepartmentCode]=" + CreateSqlParameterName("DepartmentCode") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetSortOder)
				{
					strUpdate += "[SortOder]=" + CreateSqlParameterName("SortOder") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Department] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "DepartmentName", Sanitizer.GetSafeHtmlFragment(value.DepartmentName));
					AddParameter(cmd, "DepartmentNameAbbr", Sanitizer.GetSafeHtmlFragment(value.DepartmentNameAbbr));
					AddParameter(cmd, "DepartmentCode", Sanitizer.GetSafeHtmlFragment(value.DepartmentCode));
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "SortOder", value.IsSortOderNull ? DBNull.Value : (object)value.SortOder);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int departmentId)
		{
			string whereSql = "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DepartmentID", departmentId);
			return 0 < cmd.ExecuteNonQuery();
		}
		public DepartmentRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			DepartmentRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByProvinceID(int provinceID)
		{
			return CreateDeleteByProvinceIDCommand(provinceID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByProvinceIDCommand(int provinceID)
		{
			string whereSql = "";
			whereSql += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProvinceID", provinceID);
			return cmd;
		}
		protected DepartmentRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected DepartmentRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected DepartmentRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
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
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int sortOderColumnIndex = reader.GetOrdinal("SortOder");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					DepartmentRow record = new DepartmentRow();
					recordList.Add(record);
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));
					record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));
					record.DepartmentNameAbbr =  Convert.ToString(reader.GetValue(departmentNameAbbrColumnIndex));
					if (!reader.IsDBNull(departmentCodeColumnIndex)) record.DepartmentCode =  Convert.ToString(reader.GetValue(departmentCodeColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(sortOderColumnIndex)) record.SortOder =  Convert.ToInt32(reader.GetValue(sortOderColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DepartmentRow[])(recordList.ToArray(typeof(DepartmentRow)));
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
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DepartmentNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DepartmentCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "SortOder":
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

