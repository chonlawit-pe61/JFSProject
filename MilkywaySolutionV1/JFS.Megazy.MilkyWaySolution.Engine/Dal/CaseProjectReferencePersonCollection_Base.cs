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
	public partial class CaseProjectReferencePersonCollection_Base : MarshalByRefObject
	{
		public const string RefPersonIDColumnName = "RefPersonID";
		public const string CaseIDColumnName = "CaseID";
		public const string RefPersonNameColumnName = "RefPersonName";
		public const string RefPersonAddressColumnName = "RefPersonAddress";
		public const string RefPersonTelephonNoColumnName = "RefPersonTelephonNo";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseProjectReferencePersonCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseProjectReferencePersonRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual CaseProjectReferencePersonPaging GetPagingRelyOnRefPersonIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseProjectReferencePersonPaging caseProjectReferencePersonPaging = new CaseProjectReferencePersonPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(RefPersonID) as TotalRow from [dbo].[CaseProjectReferencePerson]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseProjectReferencePersonPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseProjectReferencePersonPaging.totalPage = (int)Math.Ceiling((double) caseProjectReferencePersonPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnRefPersonID(whereSql, "RefPersonID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseProjectReferencePersonPaging.caseProjectReferencePersonRow = MapRecords(command);
			return caseProjectReferencePersonPaging;
		}
		public virtual CaseProjectReferencePersonPaging GetPagingRelyOnRefPersonIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseProjectReferencePersonPaging caseProjectReferencePersonPaging = new CaseProjectReferencePersonPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(RefPersonID) as TotalRow from [dbo].[CaseProjectReferencePerson]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseProjectReferencePersonPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseProjectReferencePersonPaging.totalPage = (int)Math.Ceiling((double)caseProjectReferencePersonPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnRefPersonID(whereSql, "RefPersonID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseProjectReferencePersonPaging.caseProjectReferencePersonRow = MapRecords(command);
			return caseProjectReferencePersonPaging;
		}
		public virtual CaseProjectReferencePersonRow[] GetPagingRelyOnRefPersonIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minRefPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And RefPersonID < " + minRefPersonID.ToString();
			}
			else
			{
				whereSql = "RefPersonID < " + minRefPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnRefPersonID(whereSql, "RefPersonID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectReferencePersonRow[] GetPagingRelyOnRefPersonIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minRefPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And RefPersonID > " + minRefPersonID.ToString();
			}
			else
			{
				whereSql = "RefPersonID > " + minRefPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnRefPersonID(whereSql, "RefPersonID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectReferencePersonRow[] GetPagingRelyOnRefPersonIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxRefPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And RefPersonID < " + maxRefPersonID.ToString();
			}
			else
			{
				whereSql = "RefPersonID < " + maxRefPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnRefPersonID(whereSql, "RefPersonID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectReferencePersonRow[] GetPagingRelyOnRefPersonIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxRefPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And RefPersonID > " + maxRefPersonID.ToString();
			}
			else
			{
				whereSql = "RefPersonID > " + maxRefPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnRefPersonID(whereSql, "RefPersonID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectReferencePersonRow[] GetPagingRelyOnRefPersonIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "RefPersonID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			CaseProjectReferencePersonRow[] caseProjectReferencePersonRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnRefPersonID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectReferencePersonRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnRefPersonIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectReferencePersonRow = MapRecords(command);
			}
			return caseProjectReferencePersonRow;
		}
		public virtual CaseProjectReferencePersonRow[] GetPagingRelyOnRefPersonIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "RefPersonID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			CaseProjectReferencePersonRow[] caseProjectReferencePersonRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnRefPersonID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectReferencePersonRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnRefPersonIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectReferencePersonRow = MapRecords(command);
			}
			return caseProjectReferencePersonRow;
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
			"[RefPersonID],"+
			"[CaseID],"+
			"[RefPersonName],"+
			"[RefPersonAddress],"+
			"[RefPersonTelephonNo],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseProjectReferencePerson]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnRefPersonID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectReferencePerson]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnRefPersonIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "RefPersonID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectReferencePerson] where RefPersonID < (select min(minRefPersonID) from(select top " + (rowPerPage * pageNumber).ToString() + " RefPersonID as minRefPersonID from [dbo].[CaseProjectReferencePerson]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseProjectReferencePerson]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnRefPersonIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "RefPersonID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectReferencePerson] where RefPersonID > (select max(maxRefPersonID) from(select top " + (rowPerPage * pageNumber).ToString() + " RefPersonID as maxRefPersonID from [dbo].[CaseProjectReferencePerson]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseProjectReferencePerson]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseProjectReferencePerson]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseProjectReferencePerson"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("RefPersonID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RefPersonName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RefPersonAddress",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("RefPersonTelephonNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseProjectReferencePersonRow[] GetByCaseID(int caseID)
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
		public CaseProjectReferencePersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseProjectReferencePersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseProjectReferencePersonRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseProjectReferencePersonRow"/> objects.</returns>
		public virtual CaseProjectReferencePersonRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseProjectReferencePerson]", top);
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
		public CaseProjectReferencePersonRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseProjectReferencePersonRow[] rows = null;
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
		public DataTable GetCaseProjectReferencePersonPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "RefPersonID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "RefPersonID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(RefPersonID) AS TotalRow FROM [dbo].[CaseProjectReferencePerson] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,RefPersonID,CaseID,RefPersonName,RefPersonAddress,RefPersonTelephonNo,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [CaseProjectReferencePerson].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseProjectReferencePerson] " + whereSql +
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
		public CaseProjectReferencePersonItemsPaging GetCaseProjectReferencePersonPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "RefPersonID")
		{
		CaseProjectReferencePersonItemsPaging obj = new CaseProjectReferencePersonItemsPaging();
		DataTable dt = GetCaseProjectReferencePersonPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseProjectReferencePersonItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseProjectReferencePersonItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.RefPersonID = Convert.ToInt32(dt.Rows[i]["RefPersonID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.RefPersonName = dt.Rows[i]["RefPersonName"].ToString();
			record.RefPersonAddress = dt.Rows[i]["RefPersonAddress"].ToString();
			record.RefPersonTelephonNo = dt.Rows[i]["RefPersonTelephonNo"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseProjectReferencePersonItems = (CaseProjectReferencePersonItems[])(recordList.ToArray(typeof(CaseProjectReferencePersonItems)));
		return obj;
		}
		public CaseProjectReferencePersonRow GetByPrimaryKey(int refPersonID)
		{
			string whereSql = "[RefPersonID]=" + CreateSqlParameterName("RefPersonID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RefPersonID", refPersonID);
			CaseProjectReferencePersonRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(CaseProjectReferencePersonRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseProjectReferencePerson] (" +
			"[CaseID], " + 
			"[RefPersonName], " + 
			"[RefPersonAddress], " + 
			"[RefPersonTelephonNo], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("RefPersonName") + ", " +
			CreateSqlParameterName("RefPersonAddress") + ", " +
			CreateSqlParameterName("RefPersonTelephonNo") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "RefPersonName",value.RefPersonName);
			AddParameter(cmd, "RefPersonAddress", value.RefPersonAddress);
			AddParameter(cmd, "RefPersonTelephonNo", value.RefPersonTelephonNo);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(CaseProjectReferencePersonRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseProjectReferencePerson] (" +
			"[CaseID], " + 
			"[RefPersonName], " + 
			"[RefPersonAddress], " + 
			"[RefPersonTelephonNo], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("RefPersonName") + ", " +
			CreateSqlParameterName("RefPersonAddress") + ", " +
			CreateSqlParameterName("RefPersonTelephonNo") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "RefPersonName", Sanitizer.GetSafeHtmlFragment(value.RefPersonName));
			AddParameter(cmd, "RefPersonAddress", Sanitizer.GetSafeHtmlFragment(value.RefPersonAddress));
			AddParameter(cmd, "RefPersonTelephonNo", Sanitizer.GetSafeHtmlFragment(value.RefPersonTelephonNo));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(CaseProjectReferencePersonRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetRefPersonID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetRefPersonName)
				{
					strUpdate += "[RefPersonName]=" + CreateSqlParameterName("RefPersonName") + ",";
				}
				if (value._IsSetRefPersonAddress)
				{
					strUpdate += "[RefPersonAddress]=" + CreateSqlParameterName("RefPersonAddress") + ",";
				}
				if (value._IsSetRefPersonTelephonNo)
				{
					strUpdate += "[RefPersonTelephonNo]=" + CreateSqlParameterName("RefPersonTelephonNo") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseProjectReferencePerson] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[RefPersonID]=" + CreateSqlParameterName("RefPersonID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "RefPersonID", value.RefPersonID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "RefPersonName",value.RefPersonName);
					AddParameter(cmd, "RefPersonAddress", value.RefPersonAddress);
					AddParameter(cmd, "RefPersonTelephonNo", value.RefPersonTelephonNo);
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
				Exception ex = new Exception("Set incorrect primarykey PK(RefPersonID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseProjectReferencePersonRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetRefPersonID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetRefPersonName)
				{
					strUpdate += "[RefPersonName]=" + CreateSqlParameterName("RefPersonName") + ",";
				}
				if (value._IsSetRefPersonAddress)
				{
					strUpdate += "[RefPersonAddress]=" + CreateSqlParameterName("RefPersonAddress") + ",";
				}
				if (value._IsSetRefPersonTelephonNo)
				{
					strUpdate += "[RefPersonTelephonNo]=" + CreateSqlParameterName("RefPersonTelephonNo") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseProjectReferencePerson] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[RefPersonID]=" + CreateSqlParameterName("RefPersonID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "RefPersonID", value.RefPersonID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "RefPersonName", Sanitizer.GetSafeHtmlFragment(value.RefPersonName));
					AddParameter(cmd, "RefPersonAddress", Sanitizer.GetSafeHtmlFragment(value.RefPersonAddress));
					AddParameter(cmd, "RefPersonTelephonNo", Sanitizer.GetSafeHtmlFragment(value.RefPersonTelephonNo));
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
				Exception ex = new Exception("Set incorrect primarykey PK(RefPersonID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int refPersonID)
		{
			string whereSql = "[RefPersonID]=" + CreateSqlParameterName("RefPersonID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "RefPersonID", refPersonID);
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
		protected CaseProjectReferencePersonRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseProjectReferencePersonRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseProjectReferencePersonRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int refPersonIDColumnIndex = reader.GetOrdinal("RefPersonID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int refPersonNameColumnIndex = reader.GetOrdinal("RefPersonName");
			int refPersonAddressColumnIndex = reader.GetOrdinal("RefPersonAddress");
			int refPersonTelephonNoColumnIndex = reader.GetOrdinal("RefPersonTelephonNo");
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
					CaseProjectReferencePersonRow record = new CaseProjectReferencePersonRow();
					recordList.Add(record);
					record.RefPersonID =  Convert.ToInt32(reader.GetValue(refPersonIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.RefPersonName =  Convert.ToString(reader.GetValue(refPersonNameColumnIndex));
					if (!reader.IsDBNull(refPersonAddressColumnIndex)) record.RefPersonAddress =  Convert.ToString(reader.GetValue(refPersonAddressColumnIndex));

					if (!reader.IsDBNull(refPersonTelephonNoColumnIndex)) record.RefPersonTelephonNo =  Convert.ToString(reader.GetValue(refPersonTelephonNoColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseProjectReferencePersonRow[])(recordList.ToArray(typeof(CaseProjectReferencePersonRow)));
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
				case "RefPersonID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RefPersonName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RefPersonAddress":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RefPersonTelephonNo":
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

