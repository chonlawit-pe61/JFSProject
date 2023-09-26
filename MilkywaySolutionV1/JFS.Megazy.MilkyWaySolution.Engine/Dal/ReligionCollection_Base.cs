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
	public partial class ReligionCollection_Base : MarshalByRefObject
	{
		public const string ReligionIDColumnName = "ReligionID";
		public const string ReligionCodeColumnName = "ReligionCode";
		public const string ReligionNameColumnName = "ReligionName";
		public const string IsActiveColumnName = "IsActive";
		public const string IsOtherColumnName = "IsOther";
		private int _processID;
		public SqlCommand cmd = null;
		public ReligionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ReligionRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual ReligionPaging GetPagingRelyOnReligionIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ReligionPaging religionPaging = new ReligionPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ReligionID) as TotalRow from [dbo].[Religion]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			religionPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			religionPaging.totalPage = (int)Math.Ceiling((double) religionPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnReligionID(whereSql, "ReligionID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			religionPaging.religionRow = MapRecords(command);
			return religionPaging;
		}
		public virtual ReligionPaging GetPagingRelyOnReligionIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ReligionPaging religionPaging = new ReligionPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ReligionID) as TotalRow from [dbo].[Religion]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			religionPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			religionPaging.totalPage = (int)Math.Ceiling((double)religionPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnReligionID(whereSql, "ReligionID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			religionPaging.religionRow = MapRecords(command);
			return religionPaging;
		}
		public virtual ReligionRow[] GetPagingRelyOnReligionIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minReligionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ReligionID < " + minReligionID.ToString();
			}
			else
			{
				whereSql = "ReligionID < " + minReligionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnReligionID(whereSql, "ReligionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ReligionRow[] GetPagingRelyOnReligionIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minReligionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ReligionID > " + minReligionID.ToString();
			}
			else
			{
				whereSql = "ReligionID > " + minReligionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnReligionID(whereSql, "ReligionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ReligionRow[] GetPagingRelyOnReligionIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxReligionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ReligionID < " + maxReligionID.ToString();
			}
			else
			{
				whereSql = "ReligionID < " + maxReligionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnReligionID(whereSql, "ReligionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ReligionRow[] GetPagingRelyOnReligionIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxReligionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ReligionID > " + maxReligionID.ToString();
			}
			else
			{
				whereSql = "ReligionID > " + maxReligionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnReligionID(whereSql, "ReligionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ReligionRow[] GetPagingRelyOnReligionIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ReligionID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			ReligionRow[] religionRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnReligionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				religionRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnReligionIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				religionRow = MapRecords(command);
			}
			return religionRow;
		}
		public virtual ReligionRow[] GetPagingRelyOnReligionIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ReligionID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			ReligionRow[] religionRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnReligionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				religionRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnReligionIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				religionRow = MapRecords(command);
			}
			return religionRow;
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
			"[ReligionID],"+
			"[ReligionCode],"+
			"[ReligionName],"+
			"[IsActive],"+
			"[IsOther]"+
			" FROM [dbo].[Religion]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnReligionID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Religion]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnReligionIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ReligionID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Religion] where ReligionID < (select min(minReligionID) from(select top " + (rowPerPage * pageNumber).ToString() + " ReligionID as minReligionID from [dbo].[Religion]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Religion]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnReligionIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ReligionID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Religion] where ReligionID > (select max(maxReligionID) from(select top " + (rowPerPage * pageNumber).ToString() + " ReligionID as maxReligionID from [dbo].[Religion]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Religion]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Religion]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Religion"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ReligionCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 3;
			dataColumn = dataTable.Columns.Add("ReligionName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsOther",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public ReligionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ReligionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ReligionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ReligionRow"/> objects.</returns>
		public virtual ReligionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Religion]", top);
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
		public ReligionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ReligionRow[] rows = null;
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
		public DataTable GetReligionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ReligionID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ReligionID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ReligionID) AS TotalRow FROM [dbo].[Religion] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ReligionID,ReligionCode,ReligionName,IsActive,IsOther," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Religion] " + whereSql +
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
		public ReligionItemsPaging GetReligionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ReligionID")
		{
		ReligionItemsPaging obj = new ReligionItemsPaging();
		DataTable dt = GetReligionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ReligionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ReligionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			record.ReligionCode = dt.Rows[i]["ReligionCode"].ToString();
			record.ReligionName = dt.Rows[i]["ReligionName"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["IsOther"] != DBNull.Value)
			record.IsOther = Convert.ToBoolean(dt.Rows[i]["IsOther"]);
			recordList.Add(record);
		}
		obj.religionItems = (ReligionItems[])(recordList.ToArray(typeof(ReligionItems)));
		return obj;
		}
		public ReligionRow GetByPrimaryKey(int religionID)
		{
			string whereSql = "[ReligionID]=" + CreateSqlParameterName("ReligionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ReligionID", religionID);
			ReligionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(ReligionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Religion] (" +
			"[ReligionCode], " + 
			"[ReligionName], " + 
			"[IsActive], " + 
			"[IsOther]			" + 
			") VALUES (" +
			CreateSqlParameterName("ReligionCode") + ", " +
			CreateSqlParameterName("ReligionName") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("IsOther") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ReligionCode", value.ReligionCode);
			AddParameter(cmd, "ReligionName", value.ReligionName);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "IsOther", value.IsIsOtherNull ? DBNull.Value : (object)value.IsOther);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(ReligionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Religion] (" +
			"[ReligionCode], " + 
			"[ReligionName], " + 
			"[IsActive], " + 
			"[IsOther]			" + 
			") VALUES (" +
			CreateSqlParameterName("ReligionCode") + ", " +
			CreateSqlParameterName("ReligionName") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("IsOther") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ReligionCode", Sanitizer.GetSafeHtmlFragment(value.ReligionCode));
			AddParameter(cmd, "ReligionName", Sanitizer.GetSafeHtmlFragment(value.ReligionName));
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "IsOther", value.IsIsOtherNull ? DBNull.Value : (object)value.IsOther);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(ReligionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetReligionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetReligionCode)
				{
					strUpdate += "[ReligionCode]=" + CreateSqlParameterName("ReligionCode") + ",";
				}
				if (value._IsSetReligionName)
				{
					strUpdate += "[ReligionName]=" + CreateSqlParameterName("ReligionName") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetIsOther)
				{
					strUpdate += "[IsOther]=" + CreateSqlParameterName("IsOther") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Religion] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ReligionID", value.ReligionID);
					AddParameter(cmd, "ReligionCode", value.ReligionCode);
					AddParameter(cmd, "ReligionName", value.ReligionName);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
					AddParameter(cmd, "IsOther", value.IsIsOtherNull ? DBNull.Value : (object)value.IsOther);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ReligionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ReligionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetReligionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetReligionCode)
				{
					strUpdate += "[ReligionCode]=" + CreateSqlParameterName("ReligionCode") + ",";
				}
				if (value._IsSetReligionName)
				{
					strUpdate += "[ReligionName]=" + CreateSqlParameterName("ReligionName") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetIsOther)
				{
					strUpdate += "[IsOther]=" + CreateSqlParameterName("IsOther") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Religion] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ReligionID", value.ReligionID);
					AddParameter(cmd, "ReligionCode", Sanitizer.GetSafeHtmlFragment(value.ReligionCode));
					AddParameter(cmd, "ReligionName", Sanitizer.GetSafeHtmlFragment(value.ReligionName));
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
					AddParameter(cmd, "IsOther", value.IsIsOtherNull ? DBNull.Value : (object)value.IsOther);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ReligionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int religionID)
		{
			string whereSql = "[ReligionID]=" + CreateSqlParameterName("ReligionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ReligionID", religionID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public ReligionRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			ReligionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected ReligionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ReligionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ReligionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int religionCodeColumnIndex = reader.GetOrdinal("ReligionCode");
			int religionNameColumnIndex = reader.GetOrdinal("ReligionName");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int isOtherColumnIndex = reader.GetOrdinal("IsOther");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ReligionRow record = new ReligionRow();
					recordList.Add(record);
					record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));
					if (!reader.IsDBNull(religionCodeColumnIndex)) record.ReligionCode =  Convert.ToString(reader.GetValue(religionCodeColumnIndex));

					if (!reader.IsDBNull(religionNameColumnIndex)) record.ReligionName =  Convert.ToString(reader.GetValue(religionNameColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(isOtherColumnIndex)) record.IsOther =  Convert.ToBoolean(reader.GetValue(isOtherColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ReligionRow[])(recordList.ToArray(typeof(ReligionRow)));
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
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReligionCode":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReligionName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsOther":
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

