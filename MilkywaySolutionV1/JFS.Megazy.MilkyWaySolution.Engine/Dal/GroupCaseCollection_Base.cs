using System.ServiceModel;
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
	public partial class GroupCaseCollection_Base : MarshalByRefObject
	{
		public const string GroupIDColumnName = "GroupID";
		public const string CreateDateColumnName = "CreateDate";
		public const string GroupNameColumnName = "GroupName";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string DeleteFlagColumnName = "DeleteFlag";
		public const string UserCreateIDColumnName = "UserCreateID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public GroupCaseCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual GroupCaseRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual GroupCasePaging GetPagingRelyOnGroupIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			GroupCasePaging groupCasePaging = new GroupCasePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(GroupID) as TotalRow from [dbo].[GroupCase]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			groupCasePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			groupCasePaging.totalPage = (int)Math.Ceiling((double) groupCasePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnGroupID(whereSql, "GroupID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			groupCasePaging.groupCaseRow = MapRecords(command);
			return groupCasePaging;
		}
		public virtual GroupCasePaging GetPagingRelyOnGroupIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			GroupCasePaging groupCasePaging = new GroupCasePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(GroupID) as TotalRow from [dbo].[GroupCase]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			groupCasePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			groupCasePaging.totalPage = (int)Math.Ceiling((double)groupCasePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnGroupID(whereSql, "GroupID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			groupCasePaging.groupCaseRow = MapRecords(command);
			return groupCasePaging;
		}
		public virtual GroupCaseRow[] GetPagingRelyOnGroupIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minGroupID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And GroupID < " + minGroupID.ToString();
			}
			else
			{
				whereSql = "GroupID < " + minGroupID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnGroupID(whereSql, "GroupID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual GroupCaseRow[] GetPagingRelyOnGroupIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minGroupID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And GroupID > " + minGroupID.ToString();
			}
			else
			{
				whereSql = "GroupID > " + minGroupID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnGroupID(whereSql, "GroupID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual GroupCaseRow[] GetPagingRelyOnGroupIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxGroupID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And GroupID < " + maxGroupID.ToString();
			}
			else
			{
				whereSql = "GroupID < " + maxGroupID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnGroupID(whereSql, "GroupID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual GroupCaseRow[] GetPagingRelyOnGroupIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxGroupID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And GroupID > " + maxGroupID.ToString();
			}
			else
			{
				whereSql = "GroupID > " + maxGroupID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnGroupID(whereSql, "GroupID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual GroupCaseRow[] GetPagingRelyOnGroupIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "GroupID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			GroupCaseRow[] groupCaseRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnGroupID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				groupCaseRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnGroupIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				groupCaseRow = MapRecords(command);
			}
			return groupCaseRow;
		}
		public virtual GroupCaseRow[] GetPagingRelyOnGroupIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "GroupID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			GroupCaseRow[] groupCaseRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnGroupID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				groupCaseRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnGroupIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				groupCaseRow = MapRecords(command);
			}
			return groupCaseRow;
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
			"[GroupID],"+
			"[CreateDate],"+
			"[GroupName],"+
			"[DepartmentID],"+
			"[DeleteFlag],"+
			"[UserCreateID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[GroupCase]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnGroupID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[GroupCase]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnGroupIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "GroupID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[GroupCase] where GroupID < (select min(minGroupID) from(select top " + (rowPerPage * pageNumber).ToString() + " GroupID as minGroupID from [dbo].[GroupCase]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[GroupCase]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnGroupIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "GroupID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[GroupCase] where GroupID > (select max(maxGroupID) from(select top " + (rowPerPage * pageNumber).ToString() + " GroupID as maxGroupID from [dbo].[GroupCase]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[GroupCase]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[GroupCase]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "GroupCase"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("GroupID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GroupName",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DeleteFlag",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserCreateID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual GroupCaseRow[] GetByDepartmentID(int departmentId)
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
		public virtual GroupCaseRow[] GetByUserCreateID(int userCreateID)
		{
			return MapRecords(CreateGetByUserCreateIDCommand(userCreateID));
		}
		public virtual DataTable GetByUserCreateIDAsDataTable(int userCreateID)
		{
			return MapRecordsToDataTable(CreateGetByUserCreateIDCommand(userCreateID));
		}
		protected virtual IDbCommand CreateGetByUserCreateIDCommand(int userCreateID)
		{
			string whereSql = "";
			whereSql += "[UserCreateID]=" + CreateSqlParameterName("UserCreateID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UserCreateID", userCreateID);
			return cmd;
		}
		public GroupCaseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual GroupCaseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="GroupCaseRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="GroupCaseRow"/> objects.</returns>
		public virtual GroupCaseRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[GroupCase]", top);
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
		public GroupCaseRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			GroupCaseRow[] rows = null;
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
		public DataTable GetGroupCasePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "GroupID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "GroupID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(GroupID) AS TotalRow FROM [dbo].[GroupCase] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,GroupID,CreateDate,GroupName,DepartmentID,DeleteFlag,UserCreateID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[GroupCase] " + whereSql +
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
		public GroupCaseItemsPaging GetGroupCasePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "GroupID")
		{
		GroupCaseItemsPaging obj = new GroupCaseItemsPaging();
		DataTable dt = GetGroupCasePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		GroupCaseItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new GroupCaseItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.GroupID = Convert.ToInt32(dt.Rows[i]["GroupID"]);
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			record.GroupName = dt.Rows[i]["GroupName"].ToString();
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.DeleteFlag = Convert.ToBoolean(dt.Rows[i]["DeleteFlag"]);
			record.UserCreateID = Convert.ToInt32(dt.Rows[i]["UserCreateID"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.groupCaseItems = (GroupCaseItems[])(recordList.ToArray(typeof(GroupCaseItems)));
		return obj;
		}
		public GroupCaseRow GetByPrimaryKey(int groupID)
		{
			string whereSql = "[GroupID]=" + CreateSqlParameterName("GroupID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "GroupID", groupID);
			GroupCaseRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(GroupCaseRow value)		{
			string sqlStr = "INSERT INTO [dbo].[GroupCase] (" +
			"[CreateDate], " + 
			"[GroupName], " + 
			"[DepartmentID], " + 
			"[DeleteFlag], " + 
			"[UserCreateID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("GroupName") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("DeleteFlag") + ", " +
			CreateSqlParameterName("UserCreateID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
			AddParameter(cmd, "GroupName", value.IsGroupNameNull ? DBNull.Value : (object)value.GroupName);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "DeleteFlag", value.DeleteFlag);
			AddParameter(cmd, "UserCreateID", value.UserCreateID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(GroupCaseRow value)		{
			string sqlStr = "INSERT INTO [dbo].[GroupCase] (" +
			"[CreateDate], " + 
			"[GroupName], " + 
			"[DepartmentID], " + 
			"[DeleteFlag], " + 
			"[UserCreateID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("GroupName") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("DeleteFlag") + ", " +
			CreateSqlParameterName("UserCreateID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
			AddParameter(cmd, "GroupName", value.IsGroupNameNull ? DBNull.Value : (object)value.GroupName);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "DeleteFlag", value.DeleteFlag);
			AddParameter(cmd, "UserCreateID", value.UserCreateID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(GroupCaseRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetGroupID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetGroupName)
				{
					strUpdate += "[GroupName]=" + CreateSqlParameterName("GroupName") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetDeleteFlag)
				{
					strUpdate += "[DeleteFlag]=" + CreateSqlParameterName("DeleteFlag") + ",";
				}
				if (value._IsSetUserCreateID)
				{
					strUpdate += "[UserCreateID]=" + CreateSqlParameterName("UserCreateID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[GroupCase] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[GroupID]=" + CreateSqlParameterName("GroupID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "GroupID", value.GroupID);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
					AddParameter(cmd, "GroupName", value.GroupName);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "DeleteFlag", value.DeleteFlag);
					AddParameter(cmd, "UserCreateID", value.UserCreateID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(GroupID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(GroupCaseRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetGroupID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetGroupName)
				{
					strUpdate += "[GroupName]=" + CreateSqlParameterName("GroupName") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetDeleteFlag)
				{
					strUpdate += "[DeleteFlag]=" + CreateSqlParameterName("DeleteFlag") + ",";
				}
				if (value._IsSetUserCreateID)
				{
					strUpdate += "[UserCreateID]=" + CreateSqlParameterName("UserCreateID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[GroupCase] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[GroupID]=" + CreateSqlParameterName("GroupID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "GroupID", value.GroupID);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
					AddParameter(cmd, "GroupName", Sanitizer.GetSafeHtmlFragment(value.GroupName));
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "DeleteFlag", value.DeleteFlag);
					AddParameter(cmd, "UserCreateID", value.UserCreateID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(GroupID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int groupID)
		{
			string whereSql = "[GroupID]=" + CreateSqlParameterName("GroupID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "GroupID", groupID);
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
		public int DeleteByUserCreateID(int userCreateID)
		{
			return CreateDeleteByUserCreateIDCommand(userCreateID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByUserCreateIDCommand(int userCreateID)
		{
			string whereSql = "";
			whereSql += "[UserCreateID]=" + CreateSqlParameterName("UserCreateID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UserCreateID", userCreateID);
			return cmd;
		}
		protected GroupCaseRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected GroupCaseRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected GroupCaseRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int groupIDColumnIndex = reader.GetOrdinal("GroupID");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int groupNameColumnIndex = reader.GetOrdinal("GroupName");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int deleteFlagColumnIndex = reader.GetOrdinal("DeleteFlag");
			int userCreateIDColumnIndex = reader.GetOrdinal("UserCreateID");
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
					GroupCaseRow record = new GroupCaseRow();
					recordList.Add(record);
					record.GroupID =  Convert.ToInt32(reader.GetValue(groupIDColumnIndex));
					record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));
					if (!reader.IsDBNull(groupNameColumnIndex)) record.GroupName =  Convert.ToString(reader.GetValue(groupNameColumnIndex));

					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					record.DeleteFlag =  Convert.ToBoolean(reader.GetValue(deleteFlagColumnIndex));
					record.UserCreateID =  Convert.ToInt32(reader.GetValue(userCreateIDColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					record.MapRecord = true;
					if (countRecordRow > 1) 
					{
						record.Many = true;
					}
					else
					{
						record.Many = false;
					}
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (GroupCaseRow[])(recordList.ToArray(typeof(GroupCaseRow)));
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
				case "GroupID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "GroupName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DeleteFlag":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "UserCreateID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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
				throw new FaultException("Zero ProcessID");
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

