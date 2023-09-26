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
	public partial class AssignmentRecordCollection_Base : MarshalByRefObject
	{
		public const string AssignmentIDColumnName = "AssignmentID";
		public const string CaseIDColumnName = "CaseID";
		public const string UserIDColumnName = "UserID";
		public const string ViaSMSColumnName = "ViaSMS";
		public const string ViaEmailColumnName = "ViaEmail";
		public const string AssignmentNoteColumnName = "AssignmentNote";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public AssignmentRecordCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual AssignmentRecordRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual AssignmentRecordPaging GetPagingRelyOnAssignmentIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			AssignmentRecordPaging assignmentRecordPaging = new AssignmentRecordPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AssignmentID) as TotalRow from [dbo].[AssignmentRecord]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			assignmentRecordPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			assignmentRecordPaging.totalPage = (int)Math.Ceiling((double) assignmentRecordPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAssignmentID(whereSql, "AssignmentID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			assignmentRecordPaging.assignmentRecordRow = MapRecords(command);
			return assignmentRecordPaging;
		}
		public virtual AssignmentRecordPaging GetPagingRelyOnAssignmentIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			AssignmentRecordPaging assignmentRecordPaging = new AssignmentRecordPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AssignmentID) as TotalRow from [dbo].[AssignmentRecord]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			assignmentRecordPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			assignmentRecordPaging.totalPage = (int)Math.Ceiling((double)assignmentRecordPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAssignmentID(whereSql, "AssignmentID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			assignmentRecordPaging.assignmentRecordRow = MapRecords(command);
			return assignmentRecordPaging;
		}
		public virtual AssignmentRecordRow[] GetPagingRelyOnAssignmentIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAssignmentID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AssignmentID < " + minAssignmentID.ToString();
			}
			else
			{
				whereSql = "AssignmentID < " + minAssignmentID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAssignmentID(whereSql, "AssignmentID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AssignmentRecordRow[] GetPagingRelyOnAssignmentIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAssignmentID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AssignmentID > " + minAssignmentID.ToString();
			}
			else
			{
				whereSql = "AssignmentID > " + minAssignmentID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAssignmentID(whereSql, "AssignmentID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AssignmentRecordRow[] GetPagingRelyOnAssignmentIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAssignmentID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AssignmentID < " + maxAssignmentID.ToString();
			}
			else
			{
				whereSql = "AssignmentID < " + maxAssignmentID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAssignmentID(whereSql, "AssignmentID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AssignmentRecordRow[] GetPagingRelyOnAssignmentIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAssignmentID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AssignmentID > " + maxAssignmentID.ToString();
			}
			else
			{
				whereSql = "AssignmentID > " + maxAssignmentID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAssignmentID(whereSql, "AssignmentID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AssignmentRecordRow[] GetPagingRelyOnAssignmentIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AssignmentID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			AssignmentRecordRow[] assignmentRecordRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAssignmentID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				assignmentRecordRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAssignmentIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				assignmentRecordRow = MapRecords(command);
			}
			return assignmentRecordRow;
		}
		public virtual AssignmentRecordRow[] GetPagingRelyOnAssignmentIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AssignmentID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			AssignmentRecordRow[] assignmentRecordRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAssignmentID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				assignmentRecordRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAssignmentIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				assignmentRecordRow = MapRecords(command);
			}
			return assignmentRecordRow;
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
			"[AssignmentID],"+
			"[CaseID],"+
			"[UserID],"+
			"[ViaSMS],"+
			"[ViaEmail],"+
			"[AssignmentNote],"+
			"[ModifiedDate]"+
			" FROM [dbo].[AssignmentRecord]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAssignmentID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AssignmentRecord]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAssignmentIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AssignmentID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AssignmentRecord] where AssignmentID < (select min(minAssignmentID) from(select top " + (rowPerPage * pageNumber).ToString() + " AssignmentID as minAssignmentID from [dbo].[AssignmentRecord]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[AssignmentRecord]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAssignmentIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AssignmentID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AssignmentRecord] where AssignmentID > (select max(maxAssignmentID) from(select top " + (rowPerPage * pageNumber).ToString() + " AssignmentID as maxAssignmentID from [dbo].[AssignmentRecord]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[AssignmentRecord]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[AssignmentRecord]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "AssignmentRecord"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("AssignmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ViaSMS",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ViaEmail",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AssignmentNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual AssignmentRecordRow[] GetByCaseID(int caseID)
		{
			return MapRecords(CreateGetByCaseIDCommand(caseID));
		}
		public virtual DataTable GetByCaseIDAsDataTable(int caseID)
		{
			return MapRecordsToDataTable(CreateGetByCaseIDCommand(caseID));
		}
		protected virtual IDbCommand CreateGetByCaseIDCommand(int caseID)
		{
			string whereSql = "";
			whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public virtual AssignmentRecordRow[] GetByUserID(int userID)
		{
			return MapRecords(CreateGetByUserIDCommand(userID));
		}
		public virtual DataTable GetByUserIDAsDataTable(int userID)
		{
			return MapRecordsToDataTable(CreateGetByUserIDCommand(userID));
		}
		protected virtual IDbCommand CreateGetByUserIDCommand(int userID)
		{
			string whereSql = "";
			whereSql += "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UserID", userID);
			return cmd;
		}
		public AssignmentRecordRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual AssignmentRecordRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="AssignmentRecordRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="AssignmentRecordRow"/> objects.</returns>
		public virtual AssignmentRecordRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[AssignmentRecord]", top);
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
		public AssignmentRecordRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			AssignmentRecordRow[] rows = null;
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
		public DataTable GetAssignmentRecordPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AssignmentID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "AssignmentID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(AssignmentID) AS TotalRow FROM [dbo].[AssignmentRecord] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,AssignmentID,CaseID,UserID,ViaSMS,ViaEmail,AssignmentNote,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [AssignmentRecord].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[AssignmentRecord] " + whereSql +
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
		public AssignmentRecordItemsPaging GetAssignmentRecordPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AssignmentID")
		{
		AssignmentRecordItemsPaging obj = new AssignmentRecordItemsPaging();
		DataTable dt = GetAssignmentRecordPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		AssignmentRecordItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new AssignmentRecordItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.AssignmentID = Convert.ToInt32(dt.Rows[i]["AssignmentID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.ViaSMS = Convert.ToBoolean(dt.Rows[i]["ViaSMS"]);
			record.ViaEmail = Convert.ToBoolean(dt.Rows[i]["ViaEmail"]);
			record.AssignmentNote = dt.Rows[i]["AssignmentNote"].ToString();
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.assignmentRecordItems = (AssignmentRecordItems[])(recordList.ToArray(typeof(AssignmentRecordItems)));
		return obj;
		}
		public AssignmentRecordRow GetByPrimaryKey(int assignmentID)
		{
			string whereSql = "[AssignmentID]=" + CreateSqlParameterName("AssignmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AssignmentID", assignmentID);
			AssignmentRecordRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(AssignmentRecordRow value)		{
			string sqlStr = "INSERT INTO [dbo].[AssignmentRecord] (" +
			"[CaseID], " + 
			"[UserID], " + 
			"[ViaSMS], " + 
			"[ViaEmail], " + 
			"[AssignmentNote], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("ViaSMS") + ", " +
			CreateSqlParameterName("ViaEmail") + ", " +
			CreateSqlParameterName("AssignmentNote") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "ViaSMS", value.ViaSMS);
			AddParameter(cmd, "ViaEmail", value.ViaEmail);
			AddParameter(cmd, "AssignmentNote", value.AssignmentNote);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(AssignmentRecordRow value)		{
			string sqlStr = "INSERT INTO [dbo].[AssignmentRecord] (" +
			"[CaseID], " + 
			"[UserID], " + 
			"[ViaSMS], " + 
			"[ViaEmail], " + 
			"[AssignmentNote], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("ViaSMS") + ", " +
			CreateSqlParameterName("ViaEmail") + ", " +
			CreateSqlParameterName("AssignmentNote") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "ViaSMS", value.ViaSMS);
			AddParameter(cmd, "ViaEmail", value.ViaEmail);
			AddParameter(cmd, "AssignmentNote", Sanitizer.GetSafeHtmlFragment(value.AssignmentNote));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(AssignmentRecordRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAssignmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetViaSMS)
				{
					strUpdate += "[ViaSMS]=" + CreateSqlParameterName("ViaSMS") + ",";
				}
				if (value._IsSetViaEmail)
				{
					strUpdate += "[ViaEmail]=" + CreateSqlParameterName("ViaEmail") + ",";
				}
				if (value._IsSetAssignmentNote)
				{
					strUpdate += "[AssignmentNote]=" + CreateSqlParameterName("AssignmentNote") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[AssignmentRecord] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AssignmentID]=" + CreateSqlParameterName("AssignmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AssignmentID", value.AssignmentID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "ViaSMS", value.ViaSMS);
					AddParameter(cmd, "ViaEmail", value.ViaEmail);
					AddParameter(cmd, "AssignmentNote", value.AssignmentNote);
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
				Exception ex = new Exception("Set incorrect primarykey PK(AssignmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(AssignmentRecordRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAssignmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetViaSMS)
				{
					strUpdate += "[ViaSMS]=" + CreateSqlParameterName("ViaSMS") + ",";
				}
				if (value._IsSetViaEmail)
				{
					strUpdate += "[ViaEmail]=" + CreateSqlParameterName("ViaEmail") + ",";
				}
				if (value._IsSetAssignmentNote)
				{
					strUpdate += "[AssignmentNote]=" + CreateSqlParameterName("AssignmentNote") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[AssignmentRecord] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AssignmentID]=" + CreateSqlParameterName("AssignmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AssignmentID", value.AssignmentID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "ViaSMS", value.ViaSMS);
					AddParameter(cmd, "ViaEmail", value.ViaEmail);
					AddParameter(cmd, "AssignmentNote", Sanitizer.GetSafeHtmlFragment(value.AssignmentNote));
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
				Exception ex = new Exception("Set incorrect primarykey PK(AssignmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int assignmentID)
		{
			string whereSql = "[AssignmentID]=" + CreateSqlParameterName("AssignmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AssignmentID", assignmentID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByCaseID(int caseID)
		{
			return CreateDeleteByCaseIDCommand(caseID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseIDCommand(int caseID)
		{
			string whereSql = "";
			whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public int DeleteByUserID(int userID)
		{
			return CreateDeleteByUserIDCommand(userID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByUserIDCommand(int userID)
		{
			string whereSql = "";
			whereSql += "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UserID", userID);
			return cmd;
		}
		protected AssignmentRecordRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected AssignmentRecordRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected AssignmentRecordRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int assignmentIDColumnIndex = reader.GetOrdinal("AssignmentID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int viaSMSColumnIndex = reader.GetOrdinal("ViaSMS");
			int viaEmailColumnIndex = reader.GetOrdinal("ViaEmail");
			int assignmentNoteColumnIndex = reader.GetOrdinal("AssignmentNote");
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
					AssignmentRecordRow record = new AssignmentRecordRow();
					recordList.Add(record);
					record.AssignmentID =  Convert.ToInt32(reader.GetValue(assignmentIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					record.ViaSMS =  Convert.ToBoolean(reader.GetValue(viaSMSColumnIndex));
					record.ViaEmail =  Convert.ToBoolean(reader.GetValue(viaEmailColumnIndex));
					if (!reader.IsDBNull(assignmentNoteColumnIndex)) record.AssignmentNote =  Convert.ToString(reader.GetValue(assignmentNoteColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (AssignmentRecordRow[])(recordList.ToArray(typeof(AssignmentRecordRow)));
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
				case "AssignmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ViaSMS":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "ViaEmail":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "AssignmentNote":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

