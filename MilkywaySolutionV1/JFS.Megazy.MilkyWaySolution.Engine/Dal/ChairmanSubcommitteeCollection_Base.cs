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
	public partial class ChairmanSubcommitteeCollection_Base : MarshalByRefObject
	{
		public const string ChairmanSubcommitteeIDColumnName = "ChairmanSubcommitteeID";
		public const string SubcommitteeIDColumnName = "SubcommitteeID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string PositionColumnName = "Position";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string IsActiveColumnName = "IsActive";
		private int _processID;
		public SqlCommand cmd = null;
		public ChairmanSubcommitteeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ChairmanSubcommitteeRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual ChairmanSubcommitteePaging GetPagingRelyOnChairmanSubcommitteeIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ChairmanSubcommitteePaging chairmanSubcommitteePaging = new ChairmanSubcommitteePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ChairmanSubcommitteeID) as TotalRow from [dbo].[ChairmanSubcommittee]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			chairmanSubcommitteePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			chairmanSubcommitteePaging.totalPage = (int)Math.Ceiling((double) chairmanSubcommitteePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnChairmanSubcommitteeID(whereSql, "ChairmanSubcommitteeID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			chairmanSubcommitteePaging.chairmanSubcommitteeRow = MapRecords(command);
			return chairmanSubcommitteePaging;
		}
		public virtual ChairmanSubcommitteePaging GetPagingRelyOnChairmanSubcommitteeIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ChairmanSubcommitteePaging chairmanSubcommitteePaging = new ChairmanSubcommitteePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ChairmanSubcommitteeID) as TotalRow from [dbo].[ChairmanSubcommittee]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			chairmanSubcommitteePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			chairmanSubcommitteePaging.totalPage = (int)Math.Ceiling((double)chairmanSubcommitteePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnChairmanSubcommitteeID(whereSql, "ChairmanSubcommitteeID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			chairmanSubcommitteePaging.chairmanSubcommitteeRow = MapRecords(command);
			return chairmanSubcommitteePaging;
		}
		public virtual ChairmanSubcommitteeRow[] GetPagingRelyOnChairmanSubcommitteeIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minChairmanSubcommitteeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ChairmanSubcommitteeID < " + minChairmanSubcommitteeID.ToString();
			}
			else
			{
				whereSql = "ChairmanSubcommitteeID < " + minChairmanSubcommitteeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnChairmanSubcommitteeID(whereSql, "ChairmanSubcommitteeID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ChairmanSubcommitteeRow[] GetPagingRelyOnChairmanSubcommitteeIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minChairmanSubcommitteeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ChairmanSubcommitteeID > " + minChairmanSubcommitteeID.ToString();
			}
			else
			{
				whereSql = "ChairmanSubcommitteeID > " + minChairmanSubcommitteeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnChairmanSubcommitteeID(whereSql, "ChairmanSubcommitteeID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ChairmanSubcommitteeRow[] GetPagingRelyOnChairmanSubcommitteeIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxChairmanSubcommitteeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ChairmanSubcommitteeID < " + maxChairmanSubcommitteeID.ToString();
			}
			else
			{
				whereSql = "ChairmanSubcommitteeID < " + maxChairmanSubcommitteeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnChairmanSubcommitteeID(whereSql, "ChairmanSubcommitteeID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ChairmanSubcommitteeRow[] GetPagingRelyOnChairmanSubcommitteeIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxChairmanSubcommitteeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ChairmanSubcommitteeID > " + maxChairmanSubcommitteeID.ToString();
			}
			else
			{
				whereSql = "ChairmanSubcommitteeID > " + maxChairmanSubcommitteeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnChairmanSubcommitteeID(whereSql, "ChairmanSubcommitteeID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ChairmanSubcommitteeRow[] GetPagingRelyOnChairmanSubcommitteeIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ChairmanSubcommitteeID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			ChairmanSubcommitteeRow[] chairmanSubcommitteeRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnChairmanSubcommitteeID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				chairmanSubcommitteeRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnChairmanSubcommitteeIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				chairmanSubcommitteeRow = MapRecords(command);
			}
			return chairmanSubcommitteeRow;
		}
		public virtual ChairmanSubcommitteeRow[] GetPagingRelyOnChairmanSubcommitteeIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ChairmanSubcommitteeID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			ChairmanSubcommitteeRow[] chairmanSubcommitteeRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnChairmanSubcommitteeID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				chairmanSubcommitteeRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnChairmanSubcommitteeIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				chairmanSubcommitteeRow = MapRecords(command);
			}
			return chairmanSubcommitteeRow;
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
			"[ChairmanSubcommitteeID],"+
			"[SubcommitteeID],"+
			"[DepartmentID],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[Position],"+
			"[ModifiedDate],"+
			"[IsActive]"+
			" FROM [dbo].[ChairmanSubcommittee]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnChairmanSubcommitteeID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ChairmanSubcommittee]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnChairmanSubcommitteeIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ChairmanSubcommitteeID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ChairmanSubcommittee] where ChairmanSubcommitteeID < (select min(minChairmanSubcommitteeID) from(select top " + (rowPerPage * pageNumber).ToString() + " ChairmanSubcommitteeID as minChairmanSubcommitteeID from [dbo].[ChairmanSubcommittee]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ChairmanSubcommittee]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnChairmanSubcommitteeIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ChairmanSubcommitteeID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ChairmanSubcommittee] where ChairmanSubcommitteeID > (select max(maxChairmanSubcommitteeID) from(select top " + (rowPerPage * pageNumber).ToString() + " ChairmanSubcommitteeID as maxChairmanSubcommitteeID from [dbo].[ChairmanSubcommittee]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ChairmanSubcommittee]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ChairmanSubcommittee]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ChairmanSubcommittee"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ChairmanSubcommitteeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SubcommitteeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Position",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public virtual ChairmanSubcommitteeRow[] GetBySubcommitteeID(int subcommitteeID)
		{
			return MapRecords(CreateGetBySubcommitteeIDCommand(subcommitteeID));
		}
		public virtual DataTable GetBySubcommitteeIDAsDataTable(int subcommitteeID)
		{
			return MapRecordsToDataTable(CreateGetBySubcommitteeIDCommand(subcommitteeID));
		}
		protected virtual IDbCommand CreateGetBySubcommitteeIDCommand(int subcommitteeID)
		{
			string whereSql = "";
			whereSql += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SubcommitteeID", subcommitteeID);
			return cmd;
		}
		public virtual ChairmanSubcommitteeRow[] GetByDepartmentID(int departmentId)
		{
			return MapRecords(CreateGetByDepartmentIDCommand(departmentId));
		}
		public virtual DataTable GetByDepartmentIDAsDataTable(int departmentId)
		{
			return MapRecordsToDataTable(CreateGetByDepartmentIDCommand(departmentId));
		}
		protected virtual IDbCommand CreateGetByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		public ChairmanSubcommitteeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ChairmanSubcommitteeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ChairmanSubcommitteeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ChairmanSubcommitteeRow"/> objects.</returns>
		public virtual ChairmanSubcommitteeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ChairmanSubcommittee]", top);
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
		public ChairmanSubcommitteeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ChairmanSubcommitteeRow[] rows = null;
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
		public DataTable GetChairmanSubcommitteePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ChairmanSubcommitteeID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ChairmanSubcommitteeID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ChairmanSubcommitteeID) AS TotalRow FROM [dbo].[ChairmanSubcommittee] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ChairmanSubcommitteeID,SubcommitteeID,DepartmentID,Title,FirstName,LastName,Position,ModifiedDate,IsActive," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ChairmanSubcommittee] " + whereSql +
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
		public ChairmanSubcommitteeItemsPaging GetChairmanSubcommitteePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ChairmanSubcommitteeID")
		{
		ChairmanSubcommitteeItemsPaging obj = new ChairmanSubcommitteeItemsPaging();
		DataTable dt = GetChairmanSubcommitteePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ChairmanSubcommitteeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ChairmanSubcommitteeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ChairmanSubcommitteeID = Convert.ToInt32(dt.Rows[i]["ChairmanSubcommitteeID"]);
			if (dt.Rows[i]["SubcommitteeID"] != DBNull.Value)
			record.SubcommitteeID = Convert.ToInt32(dt.Rows[i]["SubcommitteeID"]);
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.Position = dt.Rows[i]["Position"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			recordList.Add(record);
		}
		obj.chairmanSubcommitteeItems = (ChairmanSubcommitteeItems[])(recordList.ToArray(typeof(ChairmanSubcommitteeItems)));
		return obj;
		}
		public ChairmanSubcommitteeRow GetByPrimaryKey(int chairmanSubcommitteeID)
		{
			string whereSql = "[ChairmanSubcommitteeID]=" + CreateSqlParameterName("ChairmanSubcommitteeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ChairmanSubcommitteeID", chairmanSubcommitteeID);
			ChairmanSubcommitteeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(ChairmanSubcommitteeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ChairmanSubcommittee] (" +
			"[SubcommitteeID], " + 
			"[DepartmentID], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[Position], " + 
			"[ModifiedDate], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("SubcommitteeID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("Position") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("IsActive") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "SubcommitteeID", value.IsSubcommitteeIDNull ? DBNull.Value : (object)value.SubcommitteeID);
			AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
			AddParameter(cmd, "Title", value.Title);
			AddParameter(cmd, "FirstName", value.FirstName);
			AddParameter(cmd, "LastName", value.LastName);
			AddParameter(cmd, "Position", value.Position);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(ChairmanSubcommitteeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ChairmanSubcommittee] (" +
			"[SubcommitteeID], " + 
			"[DepartmentID], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[Position], " + 
			"[ModifiedDate], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("SubcommitteeID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("Position") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("IsActive") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "SubcommitteeID", value.IsSubcommitteeIDNull ? DBNull.Value : (object)value.SubcommitteeID);
			AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "Position", Sanitizer.GetSafeHtmlFragment(value.Position));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(ChairmanSubcommitteeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetChairmanSubcommitteeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSubcommitteeID)
				{
					strUpdate += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetPosition)
				{
					strUpdate += "[Position]=" + CreateSqlParameterName("Position") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ChairmanSubcommittee] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ChairmanSubcommitteeID]=" + CreateSqlParameterName("ChairmanSubcommitteeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ChairmanSubcommitteeID", value.ChairmanSubcommitteeID);
					AddParameter(cmd, "SubcommitteeID", value.IsSubcommitteeIDNull ? DBNull.Value : (object)value.SubcommitteeID);
					AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
					AddParameter(cmd, "Position", value.Position);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ChairmanSubcommitteeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ChairmanSubcommitteeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetChairmanSubcommitteeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSubcommitteeID)
				{
					strUpdate += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetPosition)
				{
					strUpdate += "[Position]=" + CreateSqlParameterName("Position") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ChairmanSubcommittee] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ChairmanSubcommitteeID]=" + CreateSqlParameterName("ChairmanSubcommitteeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ChairmanSubcommitteeID", value.ChairmanSubcommitteeID);
					AddParameter(cmd, "SubcommitteeID", value.IsSubcommitteeIDNull ? DBNull.Value : (object)value.SubcommitteeID);
					AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "Position", Sanitizer.GetSafeHtmlFragment(value.Position));
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ChairmanSubcommitteeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int chairmanSubcommitteeID)
		{
			string whereSql = "[ChairmanSubcommitteeID]=" + CreateSqlParameterName("ChairmanSubcommitteeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ChairmanSubcommitteeID", chairmanSubcommitteeID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public ChairmanSubcommitteeRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			ChairmanSubcommitteeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteBySubcommitteeID(int subcommitteeID)
		{
			return DeleteBySubcommitteeID(subcommitteeID, false);
		}
		public int DeleteBySubcommitteeID(int subcommitteeID, bool subcommitteeIDNull)
		{
			return CreateDeleteBySubcommitteeIDCommand(subcommitteeID, subcommitteeIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteBySubcommitteeIDCommand(int subcommitteeID, bool subcommitteeIDNull)
		{
			string whereSql = "";
			if (subcommitteeIDNull)
				whereSql += "[SubcommitteeID] IS NULL";
			else
				whereSql += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!subcommitteeIDNull)
				AddParameter(cmd, "SubcommitteeID", subcommitteeID);
			return cmd;
		}
		public int DeleteByDepartmentID(int departmentId)
		{
			return DeleteByDepartmentID(departmentId, false);
		}
		public int DeleteByDepartmentID(int departmentId, bool departmentIdNull)
		{
			return CreateDeleteByDepartmentIDCommand(departmentId, departmentIdNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByDepartmentIDCommand(int departmentId, bool departmentIdNull)
		{
			string whereSql = "";
			if (departmentIdNull)
				whereSql += "[DepartmentID] IS NULL";
			else
				whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!departmentIdNull)
				AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		protected ChairmanSubcommitteeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ChairmanSubcommitteeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ChairmanSubcommitteeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int chairmanSubcommitteeIDColumnIndex = reader.GetOrdinal("ChairmanSubcommitteeID");
			int subcommitteeIDColumnIndex = reader.GetOrdinal("SubcommitteeID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int positionColumnIndex = reader.GetOrdinal("Position");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
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
					ChairmanSubcommitteeRow record = new ChairmanSubcommitteeRow();
					recordList.Add(record);
					record.ChairmanSubcommitteeID =  Convert.ToInt32(reader.GetValue(chairmanSubcommitteeIDColumnIndex));
					if (!reader.IsDBNull(subcommitteeIDColumnIndex)) record.SubcommitteeID =  Convert.ToInt32(reader.GetValue(subcommitteeIDColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(positionColumnIndex)) record.Position =  Convert.ToString(reader.GetValue(positionColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ChairmanSubcommitteeRow[])(recordList.ToArray(typeof(ChairmanSubcommitteeRow)));
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
				case "ChairmanSubcommitteeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubcommitteeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Position":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
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

