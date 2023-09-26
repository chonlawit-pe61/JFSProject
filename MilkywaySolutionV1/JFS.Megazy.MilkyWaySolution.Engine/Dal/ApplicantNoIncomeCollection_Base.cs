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
	public partial class ApplicantNoIncomeCollection_Base : MarshalByRefObject
	{
		public const string NoIncomeIDColumnName = "NoIncomeID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string CauseColumnName = "Cause";
		public const string SupportByColumnName = "SupportBy";
		public const string IncomeColumnName = "Income";
		public const string IncomeUnitColumnName = "IncomeUnit";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantNoIncomeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantNoIncomeRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual ApplicantNoIncomePaging GetPagingRelyOnNoIncomeIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ApplicantNoIncomePaging applicantNoIncomePaging = new ApplicantNoIncomePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(NoIncomeID) as TotalRow from [dbo].[ApplicantNoIncome]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			applicantNoIncomePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			applicantNoIncomePaging.totalPage = (int)Math.Ceiling((double) applicantNoIncomePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnNoIncomeID(whereSql, "NoIncomeID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			applicantNoIncomePaging.applicantNoIncomeRow = MapRecords(command);
			return applicantNoIncomePaging;
		}
		public virtual ApplicantNoIncomePaging GetPagingRelyOnNoIncomeIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ApplicantNoIncomePaging applicantNoIncomePaging = new ApplicantNoIncomePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(NoIncomeID) as TotalRow from [dbo].[ApplicantNoIncome]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			applicantNoIncomePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			applicantNoIncomePaging.totalPage = (int)Math.Ceiling((double)applicantNoIncomePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnNoIncomeID(whereSql, "NoIncomeID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			applicantNoIncomePaging.applicantNoIncomeRow = MapRecords(command);
			return applicantNoIncomePaging;
		}
		public virtual ApplicantNoIncomeRow[] GetPagingRelyOnNoIncomeIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minNoIncomeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And NoIncomeID < " + minNoIncomeID.ToString();
			}
			else
			{
				whereSql = "NoIncomeID < " + minNoIncomeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnNoIncomeID(whereSql, "NoIncomeID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantNoIncomeRow[] GetPagingRelyOnNoIncomeIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minNoIncomeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And NoIncomeID > " + minNoIncomeID.ToString();
			}
			else
			{
				whereSql = "NoIncomeID > " + minNoIncomeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnNoIncomeID(whereSql, "NoIncomeID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantNoIncomeRow[] GetPagingRelyOnNoIncomeIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxNoIncomeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And NoIncomeID < " + maxNoIncomeID.ToString();
			}
			else
			{
				whereSql = "NoIncomeID < " + maxNoIncomeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnNoIncomeID(whereSql, "NoIncomeID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantNoIncomeRow[] GetPagingRelyOnNoIncomeIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxNoIncomeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And NoIncomeID > " + maxNoIncomeID.ToString();
			}
			else
			{
				whereSql = "NoIncomeID > " + maxNoIncomeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnNoIncomeID(whereSql, "NoIncomeID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantNoIncomeRow[] GetPagingRelyOnNoIncomeIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "NoIncomeID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			ApplicantNoIncomeRow[] applicantNoIncomeRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnNoIncomeID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantNoIncomeRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnNoIncomeIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantNoIncomeRow = MapRecords(command);
			}
			return applicantNoIncomeRow;
		}
		public virtual ApplicantNoIncomeRow[] GetPagingRelyOnNoIncomeIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "NoIncomeID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			ApplicantNoIncomeRow[] applicantNoIncomeRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnNoIncomeID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantNoIncomeRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnNoIncomeIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantNoIncomeRow = MapRecords(command);
			}
			return applicantNoIncomeRow;
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
			"[NoIncomeID],"+
			"[ApplicantID],"+
			"[Cause],"+
			"[SupportBy],"+
			"[Income],"+
			"[IncomeUnit],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantNoIncome]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnNoIncomeID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantNoIncome]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnNoIncomeIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "NoIncomeID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantNoIncome] where NoIncomeID < (select min(minNoIncomeID) from(select top " + (rowPerPage * pageNumber).ToString() + " NoIncomeID as minNoIncomeID from [dbo].[ApplicantNoIncome]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ApplicantNoIncome]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnNoIncomeIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "NoIncomeID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantNoIncome] where NoIncomeID > (select max(maxNoIncomeID) from(select top " + (rowPerPage * pageNumber).ToString() + " NoIncomeID as maxNoIncomeID from [dbo].[ApplicantNoIncome]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ApplicantNoIncome]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantNoIncome]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantNoIncome"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("NoIncomeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Cause",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("SupportBy",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Income",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("IncomeUnit",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ApplicantNoIncomeRow[] GetByApplicantID(int applicantID)
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
		public ApplicantNoIncomeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantNoIncomeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantNoIncomeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantNoIncomeRow"/> objects.</returns>
		public virtual ApplicantNoIncomeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantNoIncome]", top);
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
		public ApplicantNoIncomeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantNoIncomeRow[] rows = null;
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
		public DataTable GetApplicantNoIncomePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "NoIncomeID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "NoIncomeID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(NoIncomeID) AS TotalRow FROM [dbo].[ApplicantNoIncome] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,NoIncomeID,ApplicantID,Cause,SupportBy,Income,IncomeUnit,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantNoIncome] " + whereSql +
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
		public ApplicantNoIncomeItemsPaging GetApplicantNoIncomePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "NoIncomeID")
		{
		ApplicantNoIncomeItemsPaging obj = new ApplicantNoIncomeItemsPaging();
		DataTable dt = GetApplicantNoIncomePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantNoIncomeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantNoIncomeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.NoIncomeID = Convert.ToInt32(dt.Rows[i]["NoIncomeID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.Cause = dt.Rows[i]["Cause"].ToString();
			record.SupportBy = dt.Rows[i]["SupportBy"].ToString();
			if (dt.Rows[i]["Income"] != DBNull.Value)
			record.Income = Convert.ToDouble(dt.Rows[i]["Income"]);
			record.IncomeUnit = dt.Rows[i]["IncomeUnit"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantNoIncomeItems = (ApplicantNoIncomeItems[])(recordList.ToArray(typeof(ApplicantNoIncomeItems)));
		return obj;
		}
		public ApplicantNoIncomeRow GetByPrimaryKey(int noIncomeID)
		{
			string whereSql = "[NoIncomeID]=" + CreateSqlParameterName("NoIncomeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "NoIncomeID", noIncomeID);
			ApplicantNoIncomeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(ApplicantNoIncomeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantNoIncome] (" +
			"[ApplicantID], " + 
			"[Cause], " + 
			"[SupportBy], " + 
			"[Income], " + 
			"[IncomeUnit], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("Cause") + ", " +
			CreateSqlParameterName("SupportBy") + ", " +
			CreateSqlParameterName("Income") + ", " +
			CreateSqlParameterName("IncomeUnit") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "Cause", value.Cause);
			AddParameter(cmd, "SupportBy", value.SupportBy);
			AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
			AddParameter(cmd, "IncomeUnit", value.IncomeUnit);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(ApplicantNoIncomeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantNoIncome] (" +
			"[ApplicantID], " + 
			"[Cause], " + 
			"[SupportBy], " + 
			"[Income], " + 
			"[IncomeUnit], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("Cause") + ", " +
			CreateSqlParameterName("SupportBy") + ", " +
			CreateSqlParameterName("Income") + ", " +
			CreateSqlParameterName("IncomeUnit") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "Cause", Sanitizer.GetSafeHtmlFragment(value.Cause));
			AddParameter(cmd, "SupportBy", Sanitizer.GetSafeHtmlFragment(value.SupportBy));
			AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
			AddParameter(cmd, "IncomeUnit", Sanitizer.GetSafeHtmlFragment(value.IncomeUnit));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(ApplicantNoIncomeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetNoIncomeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetCause)
				{
					strUpdate += "[Cause]=" + CreateSqlParameterName("Cause") + ",";
				}
				if (value._IsSetSupportBy)
				{
					strUpdate += "[SupportBy]=" + CreateSqlParameterName("SupportBy") + ",";
				}
				if (value._IsSetIncome)
				{
					strUpdate += "[Income]=" + CreateSqlParameterName("Income") + ",";
				}
				if (value._IsSetIncomeUnit)
				{
					strUpdate += "[IncomeUnit]=" + CreateSqlParameterName("IncomeUnit") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantNoIncome] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[NoIncomeID]=" + CreateSqlParameterName("NoIncomeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "NoIncomeID", value.NoIncomeID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "Cause", value.Cause);
					AddParameter(cmd, "SupportBy", value.SupportBy);
					AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
					AddParameter(cmd, "IncomeUnit", value.IncomeUnit);
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
				Exception ex = new Exception("Set incorrect primarykey PK(NoIncomeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantNoIncomeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetNoIncomeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetCause)
				{
					strUpdate += "[Cause]=" + CreateSqlParameterName("Cause") + ",";
				}
				if (value._IsSetSupportBy)
				{
					strUpdate += "[SupportBy]=" + CreateSqlParameterName("SupportBy") + ",";
				}
				if (value._IsSetIncome)
				{
					strUpdate += "[Income]=" + CreateSqlParameterName("Income") + ",";
				}
				if (value._IsSetIncomeUnit)
				{
					strUpdate += "[IncomeUnit]=" + CreateSqlParameterName("IncomeUnit") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantNoIncome] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[NoIncomeID]=" + CreateSqlParameterName("NoIncomeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "NoIncomeID", value.NoIncomeID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "Cause", Sanitizer.GetSafeHtmlFragment(value.Cause));
					AddParameter(cmd, "SupportBy", Sanitizer.GetSafeHtmlFragment(value.SupportBy));
					AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
					AddParameter(cmd, "IncomeUnit", Sanitizer.GetSafeHtmlFragment(value.IncomeUnit));
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
				Exception ex = new Exception("Set incorrect primarykey PK(NoIncomeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int noIncomeID)
		{
			string whereSql = "[NoIncomeID]=" + CreateSqlParameterName("NoIncomeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "NoIncomeID", noIncomeID);
			return 0 < cmd.ExecuteNonQuery();
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
		protected ApplicantNoIncomeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantNoIncomeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantNoIncomeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int noIncomeIDColumnIndex = reader.GetOrdinal("NoIncomeID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int causeColumnIndex = reader.GetOrdinal("Cause");
			int supportByColumnIndex = reader.GetOrdinal("SupportBy");
			int incomeColumnIndex = reader.GetOrdinal("Income");
			int incomeUnitColumnIndex = reader.GetOrdinal("IncomeUnit");
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
					ApplicantNoIncomeRow record = new ApplicantNoIncomeRow();
					recordList.Add(record);
					record.NoIncomeID =  Convert.ToInt32(reader.GetValue(noIncomeIDColumnIndex));
					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(causeColumnIndex)) record.Cause =  Convert.ToString(reader.GetValue(causeColumnIndex));

					if (!reader.IsDBNull(supportByColumnIndex)) record.SupportBy =  Convert.ToString(reader.GetValue(supportByColumnIndex));

					if (!reader.IsDBNull(incomeColumnIndex)) record.Income =  Convert.ToDouble(reader.GetValue(incomeColumnIndex));

					if (!reader.IsDBNull(incomeUnitColumnIndex)) record.IncomeUnit =  Convert.ToString(reader.GetValue(incomeUnitColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantNoIncomeRow[])(recordList.ToArray(typeof(ApplicantNoIncomeRow)));
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
				case "NoIncomeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Cause":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SupportBy":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Income":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "IncomeUnit":
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

