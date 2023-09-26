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
	public partial class AccusedTrackingCollection_Base : MarshalByRefObject
	{
		public const string AccusedTrackingIDColumnName = "AccusedTrackingID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string ContractIDColumnName = "ContractID";
		public const string StartDateColumnName = "StartDate";
		public const string EndDateColumnName = "EndDate";
		public const string NoteColumnName = "Note";
		public const string SuretyFirstNameColumnName = "SuretyFirstName";
		public const string SuretyLastNameColumnName = "SuretyLastName";
		public const string SuretyTelephoneNoColumnName = "SuretyTelephoneNo";
		public const string SuretyAddressColumnName = "SuretyAddress";
		public const string IsCompleteColumnName = "IsComplete";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public AccusedTrackingCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual AccusedTrackingRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual AccusedTrackingPaging GetPagingRelyOnAccusedTrackingIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			AccusedTrackingPaging accusedTrackingPaging = new AccusedTrackingPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AccusedTrackingID) as TotalRow from [dbo].[AccusedTracking]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			accusedTrackingPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			accusedTrackingPaging.totalPage = (int)Math.Ceiling((double) accusedTrackingPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAccusedTrackingID(whereSql, "AccusedTrackingID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			accusedTrackingPaging.accusedTrackingRow = MapRecords(command);
			return accusedTrackingPaging;
		}
		public virtual AccusedTrackingPaging GetPagingRelyOnAccusedTrackingIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			AccusedTrackingPaging accusedTrackingPaging = new AccusedTrackingPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AccusedTrackingID) as TotalRow from [dbo].[AccusedTracking]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			accusedTrackingPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			accusedTrackingPaging.totalPage = (int)Math.Ceiling((double)accusedTrackingPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAccusedTrackingID(whereSql, "AccusedTrackingID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			accusedTrackingPaging.accusedTrackingRow = MapRecords(command);
			return accusedTrackingPaging;
		}
		public virtual AccusedTrackingRow[] GetPagingRelyOnAccusedTrackingIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAccusedTrackingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AccusedTrackingID < " + minAccusedTrackingID.ToString();
			}
			else
			{
				whereSql = "AccusedTrackingID < " + minAccusedTrackingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAccusedTrackingID(whereSql, "AccusedTrackingID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AccusedTrackingRow[] GetPagingRelyOnAccusedTrackingIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAccusedTrackingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AccusedTrackingID > " + minAccusedTrackingID.ToString();
			}
			else
			{
				whereSql = "AccusedTrackingID > " + minAccusedTrackingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAccusedTrackingID(whereSql, "AccusedTrackingID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AccusedTrackingRow[] GetPagingRelyOnAccusedTrackingIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAccusedTrackingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AccusedTrackingID < " + maxAccusedTrackingID.ToString();
			}
			else
			{
				whereSql = "AccusedTrackingID < " + maxAccusedTrackingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAccusedTrackingID(whereSql, "AccusedTrackingID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AccusedTrackingRow[] GetPagingRelyOnAccusedTrackingIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAccusedTrackingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AccusedTrackingID > " + maxAccusedTrackingID.ToString();
			}
			else
			{
				whereSql = "AccusedTrackingID > " + maxAccusedTrackingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAccusedTrackingID(whereSql, "AccusedTrackingID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual AccusedTrackingRow[] GetPagingRelyOnAccusedTrackingIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AccusedTrackingID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			AccusedTrackingRow[] accusedTrackingRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAccusedTrackingID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				accusedTrackingRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAccusedTrackingIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				accusedTrackingRow = MapRecords(command);
			}
			return accusedTrackingRow;
		}
		public virtual AccusedTrackingRow[] GetPagingRelyOnAccusedTrackingIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AccusedTrackingID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			AccusedTrackingRow[] accusedTrackingRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAccusedTrackingID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				accusedTrackingRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAccusedTrackingIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				accusedTrackingRow = MapRecords(command);
			}
			return accusedTrackingRow;
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
			"[AccusedTrackingID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[DepartmentID],"+
			"[ContractID],"+
			"[StartDate],"+
			"[EndDate],"+
			"[Note],"+
			"[SuretyFirstName],"+
			"[SuretyLastName],"+
			"[SuretyTelephoneNo],"+
			"[SuretyAddress],"+
			"[IsComplete],"+
			"[ModifiedDate]"+
			" FROM [dbo].[AccusedTracking]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAccusedTrackingID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AccusedTracking]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAccusedTrackingIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AccusedTrackingID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AccusedTracking] where AccusedTrackingID < (select min(minAccusedTrackingID) from(select top " + (rowPerPage * pageNumber).ToString() + " AccusedTrackingID as minAccusedTrackingID from [dbo].[AccusedTracking]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[AccusedTracking]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAccusedTrackingIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AccusedTrackingID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[AccusedTracking] where AccusedTrackingID > (select max(maxAccusedTrackingID) from(select top " + (rowPerPage * pageNumber).ToString() + " AccusedTrackingID as maxAccusedTrackingID from [dbo].[AccusedTracking]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[AccusedTracking]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[AccusedTracking]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "AccusedTracking"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("AccusedTrackingID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ContractID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("StartDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("EndDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("SuretyFirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SuretyLastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SuretyTelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SuretyAddress",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("IsComplete",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual AccusedTrackingRow[] GetByCaseID(int caseID)
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
		public virtual AccusedTrackingRow[] GetByApplicantID(int applicantID)
		{
			return MapRecords(CreateGetByApplicantIDCommand(applicantID));
		}
		public virtual DataTable GetByApplicantIDAsDataTable(int applicantID)
		{
			return MapRecordsToDataTable(CreateGetByApplicantIDCommand(applicantID));
		}
		protected virtual IDbCommand CreateGetByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public virtual AccusedTrackingRow[] GetByDepartmentID(int departmentId)
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
		public virtual AccusedTrackingRow[] GetByContractID(int contractID)
		{
			return MapRecords(CreateGetByContractIDCommand(contractID));
		}
		public virtual DataTable GetByContractIDAsDataTable(int contractID)
		{
			return MapRecordsToDataTable(CreateGetByContractIDCommand(contractID));
		}
		protected virtual IDbCommand CreateGetByContractIDCommand(int contractID)
		{
			string whereSql = "";
			whereSql += "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ContractID", contractID);
			return cmd;
		}
		public AccusedTrackingRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual AccusedTrackingRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="AccusedTrackingRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="AccusedTrackingRow"/> objects.</returns>
		public virtual AccusedTrackingRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[AccusedTracking]", top);
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
		public AccusedTrackingRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			AccusedTrackingRow[] rows = null;
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
		public DataTable GetAccusedTrackingPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AccusedTrackingID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "AccusedTrackingID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(AccusedTrackingID) AS TotalRow FROM [dbo].[AccusedTracking] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,AccusedTrackingID,CaseID,ApplicantID,DepartmentID,ContractID,StartDate,EndDate,Note,SuretyFirstName,SuretyLastName,SuretyTelephoneNo,SuretyAddress,IsComplete,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[AccusedTracking] " + whereSql +
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
		public AccusedTrackingItemsPaging GetAccusedTrackingPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AccusedTrackingID")
		{
		AccusedTrackingItemsPaging obj = new AccusedTrackingItemsPaging();
		DataTable dt = GetAccusedTrackingPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		AccusedTrackingItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new AccusedTrackingItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.AccusedTrackingID = Convert.ToInt32(dt.Rows[i]["AccusedTrackingID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			if (dt.Rows[i]["ContractID"] != DBNull.Value)
			record.ContractID = Convert.ToInt32(dt.Rows[i]["ContractID"]);
			if (dt.Rows[i]["StartDate"] != DBNull.Value)
			record.StartDate = Convert.ToDateTime(dt.Rows[i]["StartDate"]);
			if (dt.Rows[i]["EndDate"] != DBNull.Value)
			record.EndDate = Convert.ToDateTime(dt.Rows[i]["EndDate"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			record.SuretyFirstName = dt.Rows[i]["SuretyFirstName"].ToString();
			record.SuretyLastName = dt.Rows[i]["SuretyLastName"].ToString();
			record.SuretyTelephoneNo = dt.Rows[i]["SuretyTelephoneNo"].ToString();
			record.SuretyAddress = dt.Rows[i]["SuretyAddress"].ToString();
			if (dt.Rows[i]["IsComplete"] != DBNull.Value)
			record.IsComplete = Convert.ToBoolean(dt.Rows[i]["IsComplete"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.accusedTrackingItems = (AccusedTrackingItems[])(recordList.ToArray(typeof(AccusedTrackingItems)));
		return obj;
		}
		public AccusedTrackingRow GetByPrimaryKey(int accusedTrackingID)
		{
			string whereSql = "[AccusedTrackingID]=" + CreateSqlParameterName("AccusedTrackingID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AccusedTrackingID", accusedTrackingID);
			AccusedTrackingRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(AccusedTrackingRow value)		{
			string sqlStr = "INSERT INTO [dbo].[AccusedTracking] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[ContractID], " + 
			"[StartDate], " + 
			"[EndDate], " + 
			"[Note], " + 
			"[SuretyFirstName], " + 
			"[SuretyLastName], " + 
			"[SuretyTelephoneNo], " + 
			"[SuretyAddress], " + 
			"[IsComplete], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ContractID") + ", " +
			CreateSqlParameterName("StartDate") + ", " +
			CreateSqlParameterName("EndDate") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("SuretyFirstName") + ", " +
			CreateSqlParameterName("SuretyLastName") + ", " +
			CreateSqlParameterName("SuretyTelephoneNo") + ", " +
			CreateSqlParameterName("SuretyAddress") + ", " +
			CreateSqlParameterName("IsComplete") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
			AddParameter(cmd, "ContractID", value.IsContractIDNull ? DBNull.Value : (object)value.ContractID);
			AddParameter(cmd, "StartDate", value.IsStartDateNull ? DBNull.Value : (object)value.StartDate);
			AddParameter(cmd, "EndDate", value.IsEndDateNull ? DBNull.Value : (object)value.EndDate);
			AddParameter(cmd, "Note", value.Note);
			AddParameter(cmd, "SuretyFirstName", value.SuretyFirstName);
			AddParameter(cmd, "SuretyLastName", value.SuretyLastName);
			AddParameter(cmd, "SuretyTelephoneNo", value.SuretyTelephoneNo);
			AddParameter(cmd, "SuretyAddress", value.SuretyAddress);
			AddParameter(cmd, "IsComplete", value.IsIsCompleteNull ? DBNull.Value : (object)value.IsComplete);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(AccusedTrackingRow value)		{
			string sqlStr = "INSERT INTO [dbo].[AccusedTracking] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[ContractID], " + 
			"[StartDate], " + 
			"[EndDate], " + 
			"[Note], " + 
			"[SuretyFirstName], " + 
			"[SuretyLastName], " + 
			"[SuretyTelephoneNo], " + 
			"[SuretyAddress], " + 
			"[IsComplete], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ContractID") + ", " +
			CreateSqlParameterName("StartDate") + ", " +
			CreateSqlParameterName("EndDate") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("SuretyFirstName") + ", " +
			CreateSqlParameterName("SuretyLastName") + ", " +
			CreateSqlParameterName("SuretyTelephoneNo") + ", " +
			CreateSqlParameterName("SuretyAddress") + ", " +
			CreateSqlParameterName("IsComplete") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
			AddParameter(cmd, "ContractID", value.IsContractIDNull ? DBNull.Value : (object)value.ContractID);
			AddParameter(cmd, "StartDate", value.IsStartDateNull ? DBNull.Value : (object)value.StartDate);
			AddParameter(cmd, "EndDate", value.IsEndDateNull ? DBNull.Value : (object)value.EndDate);
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			AddParameter(cmd, "SuretyFirstName", Sanitizer.GetSafeHtmlFragment(value.SuretyFirstName));
			AddParameter(cmd, "SuretyLastName", Sanitizer.GetSafeHtmlFragment(value.SuretyLastName));
			AddParameter(cmd, "SuretyTelephoneNo", Sanitizer.GetSafeHtmlFragment(value.SuretyTelephoneNo));
			AddParameter(cmd, "SuretyAddress", Sanitizer.GetSafeHtmlFragment(value.SuretyAddress));
			AddParameter(cmd, "IsComplete", value.IsIsCompleteNull ? DBNull.Value : (object)value.IsComplete);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(AccusedTrackingRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAccusedTrackingID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetContractID)
				{
					strUpdate += "[ContractID]=" + CreateSqlParameterName("ContractID") + ",";
				}
				if (value._IsSetStartDate)
				{
					strUpdate += "[StartDate]=" + CreateSqlParameterName("StartDate") + ",";
				}
				if (value._IsSetEndDate)
				{
					strUpdate += "[EndDate]=" + CreateSqlParameterName("EndDate") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetSuretyFirstName)
				{
					strUpdate += "[SuretyFirstName]=" + CreateSqlParameterName("SuretyFirstName") + ",";
				}
				if (value._IsSetSuretyLastName)
				{
					strUpdate += "[SuretyLastName]=" + CreateSqlParameterName("SuretyLastName") + ",";
				}
				if (value._IsSetSuretyTelephoneNo)
				{
					strUpdate += "[SuretyTelephoneNo]=" + CreateSqlParameterName("SuretyTelephoneNo") + ",";
				}
				if (value._IsSetSuretyAddress)
				{
					strUpdate += "[SuretyAddress]=" + CreateSqlParameterName("SuretyAddress") + ",";
				}
				if (value._IsSetIsComplete)
				{
					strUpdate += "[IsComplete]=" + CreateSqlParameterName("IsComplete") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[AccusedTracking] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AccusedTrackingID]=" + CreateSqlParameterName("AccusedTrackingID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AccusedTrackingID", value.AccusedTrackingID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
					AddParameter(cmd, "ContractID", value.IsContractIDNull ? DBNull.Value : (object)value.ContractID);
					AddParameter(cmd, "StartDate", value.IsStartDateNull ? DBNull.Value : (object)value.StartDate);
					AddParameter(cmd, "EndDate", value.IsEndDateNull ? DBNull.Value : (object)value.EndDate);
					AddParameter(cmd, "Note", value.Note);
					AddParameter(cmd, "SuretyFirstName", value.SuretyFirstName);
					AddParameter(cmd, "SuretyLastName", value.SuretyLastName);
					AddParameter(cmd, "SuretyTelephoneNo", value.SuretyTelephoneNo);
					AddParameter(cmd, "SuretyAddress", value.SuretyAddress);
					AddParameter(cmd, "IsComplete", value.IsIsCompleteNull ? DBNull.Value : (object)value.IsComplete);
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
				Exception ex = new Exception("Set incorrect primarykey PK(AccusedTrackingID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(AccusedTrackingRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAccusedTrackingID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetContractID)
				{
					strUpdate += "[ContractID]=" + CreateSqlParameterName("ContractID") + ",";
				}
				if (value._IsSetStartDate)
				{
					strUpdate += "[StartDate]=" + CreateSqlParameterName("StartDate") + ",";
				}
				if (value._IsSetEndDate)
				{
					strUpdate += "[EndDate]=" + CreateSqlParameterName("EndDate") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetSuretyFirstName)
				{
					strUpdate += "[SuretyFirstName]=" + CreateSqlParameterName("SuretyFirstName") + ",";
				}
				if (value._IsSetSuretyLastName)
				{
					strUpdate += "[SuretyLastName]=" + CreateSqlParameterName("SuretyLastName") + ",";
				}
				if (value._IsSetSuretyTelephoneNo)
				{
					strUpdate += "[SuretyTelephoneNo]=" + CreateSqlParameterName("SuretyTelephoneNo") + ",";
				}
				if (value._IsSetSuretyAddress)
				{
					strUpdate += "[SuretyAddress]=" + CreateSqlParameterName("SuretyAddress") + ",";
				}
				if (value._IsSetIsComplete)
				{
					strUpdate += "[IsComplete]=" + CreateSqlParameterName("IsComplete") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[AccusedTracking] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AccusedTrackingID]=" + CreateSqlParameterName("AccusedTrackingID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AccusedTrackingID", value.AccusedTrackingID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
					AddParameter(cmd, "ContractID", value.IsContractIDNull ? DBNull.Value : (object)value.ContractID);
					AddParameter(cmd, "StartDate", value.IsStartDateNull ? DBNull.Value : (object)value.StartDate);
					AddParameter(cmd, "EndDate", value.IsEndDateNull ? DBNull.Value : (object)value.EndDate);
					AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
					AddParameter(cmd, "SuretyFirstName", Sanitizer.GetSafeHtmlFragment(value.SuretyFirstName));
					AddParameter(cmd, "SuretyLastName", Sanitizer.GetSafeHtmlFragment(value.SuretyLastName));
					AddParameter(cmd, "SuretyTelephoneNo", Sanitizer.GetSafeHtmlFragment(value.SuretyTelephoneNo));
					AddParameter(cmd, "SuretyAddress", Sanitizer.GetSafeHtmlFragment(value.SuretyAddress));
					AddParameter(cmd, "IsComplete", value.IsIsCompleteNull ? DBNull.Value : (object)value.IsComplete);
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
				Exception ex = new Exception("Set incorrect primarykey PK(AccusedTrackingID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int accusedTrackingID)
		{
			string whereSql = "[AccusedTrackingID]=" + CreateSqlParameterName("AccusedTrackingID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AccusedTrackingID", accusedTrackingID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByCaseID(int caseID)
		{
			return DeleteByCaseID(caseID, false);
		}
		public int DeleteByCaseID(int caseID, bool caseIDNull)
		{
			return CreateDeleteByCaseIDCommand(caseID, caseIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseIDCommand(int caseID, bool caseIDNull)
		{
			string whereSql = "";
			if (caseIDNull)
				whereSql += "[CaseID] IS NULL";
			else
				whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!caseIDNull)
				AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return DeleteByApplicantID(applicantID, false);
		}
		public int DeleteByApplicantID(int applicantID, bool applicantIDNull)
		{
			return CreateDeleteByApplicantIDCommand(applicantID, applicantIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID, bool applicantIDNull)
		{
			string whereSql = "";
			if (applicantIDNull)
				whereSql += "[ApplicantID] IS NULL";
			else
				whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!applicantIDNull)
				AddParameter(cmd, "ApplicantID", applicantID);
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
		public int DeleteByContractID(int contractID)
		{
			return DeleteByContractID(contractID, false);
		}
		public int DeleteByContractID(int contractID, bool contractIDNull)
		{
			return CreateDeleteByContractIDCommand(contractID, contractIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByContractIDCommand(int contractID, bool contractIDNull)
		{
			string whereSql = "";
			if (contractIDNull)
				whereSql += "[ContractID] IS NULL";
			else
				whereSql += "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!contractIDNull)
				AddParameter(cmd, "ContractID", contractID);
			return cmd;
		}
		protected AccusedTrackingRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected AccusedTrackingRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected AccusedTrackingRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int accusedTrackingIDColumnIndex = reader.GetOrdinal("AccusedTrackingID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int contractIDColumnIndex = reader.GetOrdinal("ContractID");
			int startDateColumnIndex = reader.GetOrdinal("StartDate");
			int endDateColumnIndex = reader.GetOrdinal("EndDate");
			int noteColumnIndex = reader.GetOrdinal("Note");
			int suretyFirstNameColumnIndex = reader.GetOrdinal("SuretyFirstName");
			int suretyLastNameColumnIndex = reader.GetOrdinal("SuretyLastName");
			int suretyTelephoneNoColumnIndex = reader.GetOrdinal("SuretyTelephoneNo");
			int suretyAddressColumnIndex = reader.GetOrdinal("SuretyAddress");
			int isCompleteColumnIndex = reader.GetOrdinal("IsComplete");
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
					AccusedTrackingRow record = new AccusedTrackingRow();
					recordList.Add(record);
					record.AccusedTrackingID =  Convert.ToInt32(reader.GetValue(accusedTrackingIDColumnIndex));
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(contractIDColumnIndex)) record.ContractID =  Convert.ToInt32(reader.GetValue(contractIDColumnIndex));

					if (!reader.IsDBNull(startDateColumnIndex)) record.StartDate =  Convert.ToDateTime(reader.GetValue(startDateColumnIndex));

					if (!reader.IsDBNull(endDateColumnIndex)) record.EndDate =  Convert.ToDateTime(reader.GetValue(endDateColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(suretyFirstNameColumnIndex)) record.SuretyFirstName =  Convert.ToString(reader.GetValue(suretyFirstNameColumnIndex));

					if (!reader.IsDBNull(suretyLastNameColumnIndex)) record.SuretyLastName =  Convert.ToString(reader.GetValue(suretyLastNameColumnIndex));

					if (!reader.IsDBNull(suretyTelephoneNoColumnIndex)) record.SuretyTelephoneNo =  Convert.ToString(reader.GetValue(suretyTelephoneNoColumnIndex));

					if (!reader.IsDBNull(suretyAddressColumnIndex)) record.SuretyAddress =  Convert.ToString(reader.GetValue(suretyAddressColumnIndex));

					if (!reader.IsDBNull(isCompleteColumnIndex)) record.IsComplete =  Convert.ToBoolean(reader.GetValue(isCompleteColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (AccusedTrackingRow[])(recordList.ToArray(typeof(AccusedTrackingRow)));
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
				case "AccusedTrackingID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ContractID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "StartDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "EndDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "Note":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SuretyFirstName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SuretyLastName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SuretyTelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SuretyAddress":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsComplete":
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

