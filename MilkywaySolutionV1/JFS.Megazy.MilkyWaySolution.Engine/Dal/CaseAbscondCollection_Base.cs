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
	public partial class CaseAbscondCollection_Base : MarshalByRefObject
	{
		public const string AbscondIDColumnName = "AbscondID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseAbscondCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseAbscondRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual CaseAbscondPaging GetPagingRelyOnAbscondIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseAbscondPaging caseAbscondPaging = new CaseAbscondPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AbscondID) as TotalRow from [dbo].[CaseAbscond]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseAbscondPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseAbscondPaging.totalPage = (int)Math.Ceiling((double) caseAbscondPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAbscondID(whereSql, "AbscondID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseAbscondPaging.caseAbscondRow = MapRecords(command);
			return caseAbscondPaging;
		}
		public virtual CaseAbscondPaging GetPagingRelyOnAbscondIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseAbscondPaging caseAbscondPaging = new CaseAbscondPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(AbscondID) as TotalRow from [dbo].[CaseAbscond]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseAbscondPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseAbscondPaging.totalPage = (int)Math.Ceiling((double)caseAbscondPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnAbscondID(whereSql, "AbscondID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseAbscondPaging.caseAbscondRow = MapRecords(command);
			return caseAbscondPaging;
		}
		public virtual CaseAbscondRow[] GetPagingRelyOnAbscondIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAbscondID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AbscondID < " + minAbscondID.ToString();
			}
			else
			{
				whereSql = "AbscondID < " + minAbscondID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAbscondID(whereSql, "AbscondID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseAbscondRow[] GetPagingRelyOnAbscondIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minAbscondID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AbscondID > " + minAbscondID.ToString();
			}
			else
			{
				whereSql = "AbscondID > " + minAbscondID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAbscondID(whereSql, "AbscondID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseAbscondRow[] GetPagingRelyOnAbscondIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAbscondID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AbscondID < " + maxAbscondID.ToString();
			}
			else
			{
				whereSql = "AbscondID < " + maxAbscondID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAbscondID(whereSql, "AbscondID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseAbscondRow[] GetPagingRelyOnAbscondIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxAbscondID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And AbscondID > " + maxAbscondID.ToString();
			}
			else
			{
				whereSql = "AbscondID > " + maxAbscondID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnAbscondID(whereSql, "AbscondID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseAbscondRow[] GetPagingRelyOnAbscondIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AbscondID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			CaseAbscondRow[] caseAbscondRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAbscondID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseAbscondRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAbscondIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseAbscondRow = MapRecords(command);
			}
			return caseAbscondRow;
		}
		public virtual CaseAbscondRow[] GetPagingRelyOnAbscondIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "AbscondID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			CaseAbscondRow[] caseAbscondRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnAbscondID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseAbscondRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnAbscondIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseAbscondRow = MapRecords(command);
			}
			return caseAbscondRow;
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
			"[AbscondID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseAbscond]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAbscondID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseAbscond]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAbscondIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AbscondID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseAbscond] where AbscondID < (select min(minAbscondID) from(select top " + (rowPerPage * pageNumber).ToString() + " AbscondID as minAbscondID from [dbo].[CaseAbscond]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseAbscond]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnAbscondIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "AbscondID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseAbscond] where AbscondID > (select max(maxAbscondID) from(select top " + (rowPerPage * pageNumber).ToString() + " AbscondID as maxAbscondID from [dbo].[CaseAbscond]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseAbscond]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseAbscond]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseAbscond"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("AbscondID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseAbscondRow[] GetByCaseID(int caseID)
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
		public CaseAbscondRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseAbscondRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseAbscondRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseAbscondRow"/> objects.</returns>
		public virtual CaseAbscondRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseAbscond]", top);
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
		public CaseAbscondRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseAbscondRow[] rows = null;
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
		public DataTable GetCaseAbscondPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AbscondID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "AbscondID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(AbscondID) AS TotalRow FROM [dbo].[CaseAbscond] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,AbscondID,CaseID,ApplicantID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseAbscond] " + whereSql +
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
		public CaseAbscondItemsPaging GetCaseAbscondPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "AbscondID")
		{
		CaseAbscondItemsPaging obj = new CaseAbscondItemsPaging();
		DataTable dt = GetCaseAbscondPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseAbscondItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseAbscondItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.AbscondID = Convert.ToInt32(dt.Rows[i]["AbscondID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseAbscondItems = (CaseAbscondItems[])(recordList.ToArray(typeof(CaseAbscondItems)));
		return obj;
		}
		public CaseAbscondRow GetByPrimaryKey(int abscondID)
		{
			string whereSql = "[AbscondID]=" + CreateSqlParameterName("AbscondID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AbscondID", abscondID);
			CaseAbscondRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(CaseAbscondRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseAbscond] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(CaseAbscondRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseAbscond] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(CaseAbscondRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAbscondID == true )
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
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseAbscond] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AbscondID]=" + CreateSqlParameterName("AbscondID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AbscondID", value.AbscondID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(AbscondID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseAbscondRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetAbscondID == true )
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
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseAbscond] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[AbscondID]=" + CreateSqlParameterName("AbscondID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "AbscondID", value.AbscondID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(AbscondID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int abscondID)
		{
			string whereSql = "[AbscondID]=" + CreateSqlParameterName("AbscondID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AbscondID", abscondID);
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
		protected CaseAbscondRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseAbscondRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseAbscondRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int abscondIDColumnIndex = reader.GetOrdinal("AbscondID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
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
					CaseAbscondRow record = new CaseAbscondRow();
					recordList.Add(record);
					record.AbscondID =  Convert.ToInt32(reader.GetValue(abscondIDColumnIndex));
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseAbscondRow[])(recordList.ToArray(typeof(CaseAbscondRow)));
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
				case "AbscondID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
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

