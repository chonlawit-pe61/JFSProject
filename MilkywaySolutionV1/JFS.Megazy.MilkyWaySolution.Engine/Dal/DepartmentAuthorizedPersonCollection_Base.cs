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
	public partial class DepartmentAuthorizedPersonCollection_Base : MarshalByRefObject
	{
		public const string AuthorizedPersonIDColumnName = "AuthorizedPersonID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string AuthorizedPersonTitleColumnName = "AuthorizedPersonTitle";
		public const string AuthorizedPersonFirstNameColumnName = "AuthorizedPersonFirstName";
		public const string AuthorizedPersonLastNameColumnName = "AuthorizedPersonLastName";
		public const string AuthorizedPersonPositionColumnName = "AuthorizedPersonPosition";
		public const string MobileNumberColumnName = "MobileNumber";
		public const string PowerOfAttorneyColumnName = "PowerOfAttorney";
		public const string IsPrimaryColumnName = "IsPrimary";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public DepartmentAuthorizedPersonCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual DepartmentAuthorizedPersonRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual DepartmentAuthorizedPersonPaging GetPagingRelyOnAuthorizedPersonIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			DepartmentAuthorizedPersonPaging departmentAuthorizedPersonPaging = new DepartmentAuthorizedPersonPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AuthorizedPersonID) as TotalRow from [dbo].[DepartmentAuthorizedPerson]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			departmentAuthorizedPersonPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			departmentAuthorizedPersonPaging.totalPage = (int)Math.Ceiling((double) departmentAuthorizedPersonPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAuthorizedPersonID(whereSql, "AuthorizedPersonID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			departmentAuthorizedPersonPaging.departmentAuthorizedPersonRow = MapRecords(command);
			return departmentAuthorizedPersonPaging;
		}
		public virtual DepartmentAuthorizedPersonPaging GetPagingRelyOnAuthorizedPersonIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			DepartmentAuthorizedPersonPaging departmentAuthorizedPersonPaging = new DepartmentAuthorizedPersonPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AuthorizedPersonID) as TotalRow from [dbo].[DepartmentAuthorizedPerson]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			departmentAuthorizedPersonPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			departmentAuthorizedPersonPaging.totalPage = (int)Math.Ceiling((double)departmentAuthorizedPersonPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAuthorizedPersonID(whereSql, "AuthorizedPersonID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			departmentAuthorizedPersonPaging.departmentAuthorizedPersonRow = MapRecords(command);
			return departmentAuthorizedPersonPaging;
		}
		public virtual DepartmentAuthorizedPersonRow[] GetPagingRelyOnAuthorizedPersonIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAuthorizedPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AuthorizedPersonID < " + minAuthorizedPersonID.ToString();
			}
			else
			{
				whereSql = "AuthorizedPersonID < " + minAuthorizedPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAuthorizedPersonID(whereSql, "AuthorizedPersonID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual DepartmentAuthorizedPersonRow[] GetPagingRelyOnAuthorizedPersonIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAuthorizedPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AuthorizedPersonID > " + minAuthorizedPersonID.ToString();
			}
			else
			{
				whereSql = "AuthorizedPersonID > " + minAuthorizedPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAuthorizedPersonID(whereSql, "AuthorizedPersonID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual DepartmentAuthorizedPersonRow[] GetPagingRelyOnAuthorizedPersonIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAuthorizedPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AuthorizedPersonID < " + maxAuthorizedPersonID.ToString();
			}
			else
			{
				whereSql = "AuthorizedPersonID < " + maxAuthorizedPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAuthorizedPersonID(whereSql, "AuthorizedPersonID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual DepartmentAuthorizedPersonRow[] GetPagingRelyOnAuthorizedPersonIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAuthorizedPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AuthorizedPersonID > " + maxAuthorizedPersonID.ToString();
			}
			else
			{
				whereSql = "AuthorizedPersonID > " + maxAuthorizedPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAuthorizedPersonID(whereSql, "AuthorizedPersonID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual DepartmentAuthorizedPersonRow[] GetPagingRelyOnAuthorizedPersonIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AuthorizedPersonID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			DepartmentAuthorizedPersonRow[] departmentAuthorizedPersonRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAuthorizedPersonID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				departmentAuthorizedPersonRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAuthorizedPersonIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				departmentAuthorizedPersonRow = MapRecords(command);
			}
			return departmentAuthorizedPersonRow;
		}
		public virtual DepartmentAuthorizedPersonRow[] GetPagingRelyOnAuthorizedPersonIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AuthorizedPersonID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			DepartmentAuthorizedPersonRow[] departmentAuthorizedPersonRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAuthorizedPersonID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				departmentAuthorizedPersonRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAuthorizedPersonIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				departmentAuthorizedPersonRow = MapRecords(command);
			}
			return departmentAuthorizedPersonRow;
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
			"[AuthorizedPersonID],"+
			"[DepartmentID],"+
			"[AuthorizedPersonTitle],"+
			"[AuthorizedPersonFirstName],"+
			"[AuthorizedPersonLastName],"+
			"[AuthorizedPersonPosition],"+
			"[MobileNumber],"+
			"[PowerOfAttorney],"+
			"[IsPrimary],"+
			"[ModifiedDate]"+
			" FROM [dbo].[DepartmentAuthorizedPerson]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAuthorizedPersonID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[DepartmentAuthorizedPerson]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAuthorizedPersonIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AuthorizedPersonID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[DepartmentAuthorizedPerson] where AuthorizedPersonID < (select min(minAuthorizedPersonID) from(select top " + (rowPerPage * pageNumber).ToString() + " AuthorizedPersonID as minAuthorizedPersonID from [dbo].[DepartmentAuthorizedPerson]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[DepartmentAuthorizedPerson]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAuthorizedPersonIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AuthorizedPersonID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[DepartmentAuthorizedPerson] where AuthorizedPersonID > (select max(maxAuthorizedPersonID) from(select top " + (rowPerPage * pageNumber).ToString() + " AuthorizedPersonID as maxAuthorizedPersonID from [dbo].[DepartmentAuthorizedPerson]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[DepartmentAuthorizedPerson]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[DepartmentAuthorizedPerson]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "DepartmentAuthorizedPerson"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("AuthorizedPersonID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AuthorizedPersonTitle",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AuthorizedPersonFirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AuthorizedPersonLastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AuthorizedPersonPosition",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("MobileNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 12;
			dataColumn = dataTable.Columns.Add("PowerOfAttorney",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("IsPrimary",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual DepartmentAuthorizedPersonRow[] GetByDepartmentID(int departmentId)
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
		public DepartmentAuthorizedPersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual DepartmentAuthorizedPersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="DepartmentAuthorizedPersonRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DepartmentAuthorizedPersonRow"/> objects.</returns>
		public virtual DepartmentAuthorizedPersonRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[DepartmentAuthorizedPerson]", top);
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
		public DepartmentAuthorizedPersonRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			DepartmentAuthorizedPersonRow[] rows = null;
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
		public DataTable GetDepartmentAuthorizedPersonPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AuthorizedPersonID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "AuthorizedPersonID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(AuthorizedPersonID) AS TotalRow FROM [dbo].[DepartmentAuthorizedPerson] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,AuthorizedPersonID,DepartmentID,AuthorizedPersonTitle,AuthorizedPersonFirstName,AuthorizedPersonLastName,AuthorizedPersonPosition,MobileNumber,PowerOfAttorney,IsPrimary,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[DepartmentAuthorizedPerson] " + whereSql +
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
		public DepartmentAuthorizedPersonItemsPaging GetDepartmentAuthorizedPersonPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AuthorizedPersonID")
		{
		DepartmentAuthorizedPersonItemsPaging obj = new DepartmentAuthorizedPersonItemsPaging();
		DataTable dt = GetDepartmentAuthorizedPersonPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		DepartmentAuthorizedPersonItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new DepartmentAuthorizedPersonItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.AuthorizedPersonID = Convert.ToInt32(dt.Rows[i]["AuthorizedPersonID"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.AuthorizedPersonTitle = dt.Rows[i]["AuthorizedPersonTitle"].ToString();
			record.AuthorizedPersonFirstName = dt.Rows[i]["AuthorizedPersonFirstName"].ToString();
			record.AuthorizedPersonLastName = dt.Rows[i]["AuthorizedPersonLastName"].ToString();
			record.AuthorizedPersonPosition = dt.Rows[i]["AuthorizedPersonPosition"].ToString();
			record.MobileNumber = dt.Rows[i]["MobileNumber"].ToString();
			record.PowerOfAttorney = dt.Rows[i]["PowerOfAttorney"].ToString();
			record.IsPrimary = Convert.ToBoolean(dt.Rows[i]["IsPrimary"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.departmentAuthorizedPersonItems = (DepartmentAuthorizedPersonItems[])(recordList.ToArray(typeof(DepartmentAuthorizedPersonItems)));
		return obj;
		}
		public DepartmentAuthorizedPersonRow GetByPrimaryKey(int authorizedPersonID)
		{
			string whereSql = "[AuthorizedPersonID]=" + CreateSqlParameterName("AuthorizedPersonID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AuthorizedPersonID", authorizedPersonID);
			DepartmentAuthorizedPersonRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(DepartmentAuthorizedPersonRow value)		{
			string sqlStr = "INSERT INTO [dbo].[DepartmentAuthorizedPerson] (" +
			"[DepartmentID], " + 
			"[AuthorizedPersonTitle], " + 
			"[AuthorizedPersonFirstName], " + 
			"[AuthorizedPersonLastName], " + 
			"[AuthorizedPersonPosition], " + 
			"[MobileNumber], " + 
			"[PowerOfAttorney], " + 
			"[IsPrimary], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("AuthorizedPersonTitle") + ", " +
			CreateSqlParameterName("AuthorizedPersonFirstName") + ", " +
			CreateSqlParameterName("AuthorizedPersonLastName") + ", " +
			CreateSqlParameterName("AuthorizedPersonPosition") + ", " +
			CreateSqlParameterName("MobileNumber") + ", " +
			CreateSqlParameterName("PowerOfAttorney") + ", " +
			CreateSqlParameterName("IsPrimary") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "AuthorizedPersonTitle",value.AuthorizedPersonTitle);
			AddParameter(cmd, "AuthorizedPersonFirstName",value.AuthorizedPersonFirstName);
			AddParameter(cmd, "AuthorizedPersonLastName",value.AuthorizedPersonLastName);
			AddParameter(cmd, "AuthorizedPersonPosition", value.AuthorizedPersonPosition);
			AddParameter(cmd, "MobileNumber", value.MobileNumber);
			AddParameter(cmd, "PowerOfAttorney", value.PowerOfAttorney);
			AddParameter(cmd, "IsPrimary", value.IsPrimary);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(DepartmentAuthorizedPersonRow value)		{
			string sqlStr = "INSERT INTO [dbo].[DepartmentAuthorizedPerson] (" +
			"[DepartmentID], " + 
			"[AuthorizedPersonTitle], " + 
			"[AuthorizedPersonFirstName], " + 
			"[AuthorizedPersonLastName], " + 
			"[AuthorizedPersonPosition], " + 
			"[MobileNumber], " + 
			"[PowerOfAttorney], " + 
			"[IsPrimary], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("AuthorizedPersonTitle") + ", " +
			CreateSqlParameterName("AuthorizedPersonFirstName") + ", " +
			CreateSqlParameterName("AuthorizedPersonLastName") + ", " +
			CreateSqlParameterName("AuthorizedPersonPosition") + ", " +
			CreateSqlParameterName("MobileNumber") + ", " +
			CreateSqlParameterName("PowerOfAttorney") + ", " +
			CreateSqlParameterName("IsPrimary") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "AuthorizedPersonTitle", Sanitizer.GetSafeHtmlFragment(value.AuthorizedPersonTitle));
			AddParameter(cmd, "AuthorizedPersonFirstName", Sanitizer.GetSafeHtmlFragment(value.AuthorizedPersonFirstName));
			AddParameter(cmd, "AuthorizedPersonLastName", Sanitizer.GetSafeHtmlFragment(value.AuthorizedPersonLastName));
			AddParameter(cmd, "AuthorizedPersonPosition", Sanitizer.GetSafeHtmlFragment(value.AuthorizedPersonPosition));
			AddParameter(cmd, "MobileNumber", Sanitizer.GetSafeHtmlFragment(value.MobileNumber));
			AddParameter(cmd, "PowerOfAttorney", Sanitizer.GetSafeHtmlFragment(value.PowerOfAttorney));
			AddParameter(cmd, "IsPrimary", value.IsPrimary);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(DepartmentAuthorizedPersonRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAuthorizedPersonID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetAuthorizedPersonTitle)
				{
					strUpdate += "[AuthorizedPersonTitle]=" + CreateSqlParameterName("AuthorizedPersonTitle") + ",";
				}
				if (value._IsSetAuthorizedPersonFirstName)
				{
					strUpdate += "[AuthorizedPersonFirstName]=" + CreateSqlParameterName("AuthorizedPersonFirstName") + ",";
				}
				if (value._IsSetAuthorizedPersonLastName)
				{
					strUpdate += "[AuthorizedPersonLastName]=" + CreateSqlParameterName("AuthorizedPersonLastName") + ",";
				}
				if (value._IsSetAuthorizedPersonPosition)
				{
					strUpdate += "[AuthorizedPersonPosition]=" + CreateSqlParameterName("AuthorizedPersonPosition") + ",";
				}
				if (value._IsSetMobileNumber)
				{
					strUpdate += "[MobileNumber]=" + CreateSqlParameterName("MobileNumber") + ",";
				}
				if (value._IsSetPowerOfAttorney)
				{
					strUpdate += "[PowerOfAttorney]=" + CreateSqlParameterName("PowerOfAttorney") + ",";
				}
				if (value._IsSetIsPrimary)
				{
					strUpdate += "[IsPrimary]=" + CreateSqlParameterName("IsPrimary") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[DepartmentAuthorizedPerson] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AuthorizedPersonID]=" + CreateSqlParameterName("AuthorizedPersonID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AuthorizedPersonID", value.AuthorizedPersonID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "AuthorizedPersonTitle",value.AuthorizedPersonTitle);
					AddParameter(cmd, "AuthorizedPersonFirstName",value.AuthorizedPersonFirstName);
					AddParameter(cmd, "AuthorizedPersonLastName",value.AuthorizedPersonLastName);
					AddParameter(cmd, "AuthorizedPersonPosition", value.AuthorizedPersonPosition);
					AddParameter(cmd, "MobileNumber", value.MobileNumber);
					AddParameter(cmd, "PowerOfAttorney", value.PowerOfAttorney);
					AddParameter(cmd, "IsPrimary", value.IsPrimary);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(AuthorizedPersonID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(DepartmentAuthorizedPersonRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAuthorizedPersonID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetAuthorizedPersonTitle)
				{
					strUpdate += "[AuthorizedPersonTitle]=" + CreateSqlParameterName("AuthorizedPersonTitle") + ",";
				}
				if (value._IsSetAuthorizedPersonFirstName)
				{
					strUpdate += "[AuthorizedPersonFirstName]=" + CreateSqlParameterName("AuthorizedPersonFirstName") + ",";
				}
				if (value._IsSetAuthorizedPersonLastName)
				{
					strUpdate += "[AuthorizedPersonLastName]=" + CreateSqlParameterName("AuthorizedPersonLastName") + ",";
				}
				if (value._IsSetAuthorizedPersonPosition)
				{
					strUpdate += "[AuthorizedPersonPosition]=" + CreateSqlParameterName("AuthorizedPersonPosition") + ",";
				}
				if (value._IsSetMobileNumber)
				{
					strUpdate += "[MobileNumber]=" + CreateSqlParameterName("MobileNumber") + ",";
				}
				if (value._IsSetPowerOfAttorney)
				{
					strUpdate += "[PowerOfAttorney]=" + CreateSqlParameterName("PowerOfAttorney") + ",";
				}
				if (value._IsSetIsPrimary)
				{
					strUpdate += "[IsPrimary]=" + CreateSqlParameterName("IsPrimary") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[DepartmentAuthorizedPerson] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AuthorizedPersonID]=" + CreateSqlParameterName("AuthorizedPersonID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AuthorizedPersonID", value.AuthorizedPersonID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "AuthorizedPersonTitle", Sanitizer.GetSafeHtmlFragment(value.AuthorizedPersonTitle));
					AddParameter(cmd, "AuthorizedPersonFirstName", Sanitizer.GetSafeHtmlFragment(value.AuthorizedPersonFirstName));
					AddParameter(cmd, "AuthorizedPersonLastName", Sanitizer.GetSafeHtmlFragment(value.AuthorizedPersonLastName));
					AddParameter(cmd, "AuthorizedPersonPosition", Sanitizer.GetSafeHtmlFragment(value.AuthorizedPersonPosition));
					AddParameter(cmd, "MobileNumber", Sanitizer.GetSafeHtmlFragment(value.MobileNumber));
					AddParameter(cmd, "PowerOfAttorney", Sanitizer.GetSafeHtmlFragment(value.PowerOfAttorney));
					AddParameter(cmd, "IsPrimary", value.IsPrimary);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(AuthorizedPersonID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int authorizedPersonID)
		{
			string whereSql = "[AuthorizedPersonID]=" + CreateSqlParameterName("AuthorizedPersonID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AuthorizedPersonID", authorizedPersonID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByDepartmentID(int departmentId)
		{
			return CreateDeleteByDepartmentIDCommand(departmentId).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		protected DepartmentAuthorizedPersonRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected DepartmentAuthorizedPersonRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected DepartmentAuthorizedPersonRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int authorizedPersonIDColumnIndex = reader.GetOrdinal("AuthorizedPersonID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int authorizedPersonTitleColumnIndex = reader.GetOrdinal("AuthorizedPersonTitle");
			int authorizedPersonFirstNameColumnIndex = reader.GetOrdinal("AuthorizedPersonFirstName");
			int authorizedPersonLastNameColumnIndex = reader.GetOrdinal("AuthorizedPersonLastName");
			int authorizedPersonPositionColumnIndex = reader.GetOrdinal("AuthorizedPersonPosition");
			int mobileNumberColumnIndex = reader.GetOrdinal("MobileNumber");
			int powerOfAttorneyColumnIndex = reader.GetOrdinal("PowerOfAttorney");
			int isPrimaryColumnIndex = reader.GetOrdinal("IsPrimary");
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
					DepartmentAuthorizedPersonRow record = new DepartmentAuthorizedPersonRow();
					recordList.Add(record);
					record.AuthorizedPersonID =  Convert.ToInt32(reader.GetValue(authorizedPersonIDColumnIndex));
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					record.AuthorizedPersonTitle =  Convert.ToString(reader.GetValue(authorizedPersonTitleColumnIndex));
					record.AuthorizedPersonFirstName =  Convert.ToString(reader.GetValue(authorizedPersonFirstNameColumnIndex));
					record.AuthorizedPersonLastName =  Convert.ToString(reader.GetValue(authorizedPersonLastNameColumnIndex));
					if (!reader.IsDBNull(authorizedPersonPositionColumnIndex)) record.AuthorizedPersonPosition =  Convert.ToString(reader.GetValue(authorizedPersonPositionColumnIndex));

					if (!reader.IsDBNull(mobileNumberColumnIndex)) record.MobileNumber =  Convert.ToString(reader.GetValue(mobileNumberColumnIndex));

					if (!reader.IsDBNull(powerOfAttorneyColumnIndex)) record.PowerOfAttorney =  Convert.ToString(reader.GetValue(powerOfAttorneyColumnIndex));

					record.IsPrimary =  Convert.ToBoolean(reader.GetValue(isPrimaryColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DepartmentAuthorizedPersonRow[])(recordList.ToArray(typeof(DepartmentAuthorizedPersonRow)));
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
				case "AuthorizedPersonID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AuthorizedPersonTitle":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AuthorizedPersonFirstName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AuthorizedPersonLastName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AuthorizedPersonPosition":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MobileNumber":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "PowerOfAttorney":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsPrimary":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

