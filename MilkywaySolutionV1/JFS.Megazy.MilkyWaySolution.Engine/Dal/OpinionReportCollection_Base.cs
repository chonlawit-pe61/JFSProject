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
	public partial class OpinionReportCollection_Base : MarshalByRefObject
	{
		public const string OpinionReportIDColumnName = "OpinionReportID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string FormIDColumnName = "FormID";
		public const string SeniorLawyerNameColumnName = "SeniorLawyerName";
		public const string SeniorPositionColumnName = "SeniorPosition";
		public const string DirectorNameColumnName = "DirectorName";
		public const string DirectorPositionColumnName = "DirectorPosition";
		public const string ChairmanNameColumnName = "ChairmanName";
		public const string ChairmanPositionColumnName = "ChairmanPosition";
		public const string CrateDateColumnName = "CrateDate";
		private int _processID;
		public SqlCommand cmd = null;
		public OpinionReportCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual OpinionReportRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual OpinionReportPaging GetPagingRelyOnOpinionReportIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			OpinionReportPaging opinionReportPaging = new OpinionReportPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(OpinionReportID) as TotalRow from [dbo].[OpinionReport]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			opinionReportPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			opinionReportPaging.totalPage = (int)Math.Ceiling((double) opinionReportPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnOpinionReportID(whereSql, "OpinionReportID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			opinionReportPaging.opinionReportRow = MapRecords(command);
			return opinionReportPaging;
		}
		public virtual OpinionReportPaging GetPagingRelyOnOpinionReportIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			OpinionReportPaging opinionReportPaging = new OpinionReportPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(OpinionReportID) as TotalRow from [dbo].[OpinionReport]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			opinionReportPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			opinionReportPaging.totalPage = (int)Math.Ceiling((double)opinionReportPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnOpinionReportID(whereSql, "OpinionReportID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			opinionReportPaging.opinionReportRow = MapRecords(command);
			return opinionReportPaging;
		}
		public virtual OpinionReportRow[] GetPagingRelyOnOpinionReportIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minOpinionReportID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And OpinionReportID < " + minOpinionReportID.ToString();
			}
			else
			{
				whereSql = "OpinionReportID < " + minOpinionReportID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnOpinionReportID(whereSql, "OpinionReportID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual OpinionReportRow[] GetPagingRelyOnOpinionReportIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minOpinionReportID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And OpinionReportID > " + minOpinionReportID.ToString();
			}
			else
			{
				whereSql = "OpinionReportID > " + minOpinionReportID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnOpinionReportID(whereSql, "OpinionReportID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual OpinionReportRow[] GetPagingRelyOnOpinionReportIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxOpinionReportID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And OpinionReportID < " + maxOpinionReportID.ToString();
			}
			else
			{
				whereSql = "OpinionReportID < " + maxOpinionReportID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnOpinionReportID(whereSql, "OpinionReportID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual OpinionReportRow[] GetPagingRelyOnOpinionReportIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxOpinionReportID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And OpinionReportID > " + maxOpinionReportID.ToString();
			}
			else
			{
				whereSql = "OpinionReportID > " + maxOpinionReportID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnOpinionReportID(whereSql, "OpinionReportID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual OpinionReportRow[] GetPagingRelyOnOpinionReportIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "OpinionReportID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			OpinionReportRow[] opinionReportRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnOpinionReportID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				opinionReportRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnOpinionReportIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				opinionReportRow = MapRecords(command);
			}
			return opinionReportRow;
		}
		public virtual OpinionReportRow[] GetPagingRelyOnOpinionReportIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "OpinionReportID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			OpinionReportRow[] opinionReportRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnOpinionReportID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				opinionReportRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnOpinionReportIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				opinionReportRow = MapRecords(command);
			}
			return opinionReportRow;
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
			"[OpinionReportID],"+
			"[ApplicantID],"+
			"[FormID],"+
			"[SeniorLawyerName],"+
			"[SeniorPosition],"+
			"[DirectorName],"+
			"[DirectorPosition],"+
			"[ChairmanName],"+
			"[ChairmanPosition],"+
			"[CrateDate]"+
			" FROM [dbo].[OpinionReport]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnOpinionReportID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[OpinionReport]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnOpinionReportIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "OpinionReportID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[OpinionReport] where OpinionReportID < (select min(minOpinionReportID) from(select top " + (rowPerPage * pageNumber).ToString() + " OpinionReportID as minOpinionReportID from [dbo].[OpinionReport]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[OpinionReport]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnOpinionReportIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "OpinionReportID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[OpinionReport] where OpinionReportID > (select max(maxOpinionReportID) from(select top " + (rowPerPage * pageNumber).ToString() + " OpinionReportID as maxOpinionReportID from [dbo].[OpinionReport]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[OpinionReport]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[OpinionReport]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "OpinionReport"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("OpinionReportID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SeniorLawyerName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("SeniorPosition",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("DirectorName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DirectorPosition",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("ChairmanName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ChairmanPosition",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CrateDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual OpinionReportRow[] GetByApplicantID(int applicantID)
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
		public virtual OpinionReportRow[] GetByFormID(int formID)
		{
			return MapRecords(CreateGetByFormIDCommand(formID));
		}
		public virtual DataTable GetByFormIDAsDataTable(int formID)
		{
			return MapRecordsToDataTable(CreateGetByFormIDCommand(formID));
		}
		protected virtual IDbCommand CreateGetByFormIDCommand(int formID)
		{
			string whereSql = "";
			whereSql += "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FormID", formID);
			return cmd;
		}
		public OpinionReportRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual OpinionReportRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="OpinionReportRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OpinionReportRow"/> objects.</returns>
		public virtual OpinionReportRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[OpinionReport]", top);
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
		public OpinionReportRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			OpinionReportRow[] rows = null;
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
		public DataTable GetOpinionReportPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "OpinionReportID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "OpinionReportID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(OpinionReportID) AS TotalRow FROM [dbo].[OpinionReport] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,OpinionReportID,ApplicantID,FormID,SeniorLawyerName,SeniorPosition,DirectorName,DirectorPosition,ChairmanName,ChairmanPosition,CrateDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[OpinionReport] " + whereSql +
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
		public OpinionReportItemsPaging GetOpinionReportPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "OpinionReportID")
		{
		OpinionReportItemsPaging obj = new OpinionReportItemsPaging();
		DataTable dt = GetOpinionReportPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		OpinionReportItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new OpinionReportItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.OpinionReportID = Convert.ToInt32(dt.Rows[i]["OpinionReportID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["FormID"] != DBNull.Value)
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			record.SeniorLawyerName = dt.Rows[i]["SeniorLawyerName"].ToString();
			record.SeniorPosition = dt.Rows[i]["SeniorPosition"].ToString();
			record.DirectorName = dt.Rows[i]["DirectorName"].ToString();
			record.DirectorPosition = dt.Rows[i]["DirectorPosition"].ToString();
			record.ChairmanName = dt.Rows[i]["ChairmanName"].ToString();
			record.ChairmanPosition = dt.Rows[i]["ChairmanPosition"].ToString();
			if (dt.Rows[i]["CrateDate"] != DBNull.Value)
			record.CrateDate = Convert.ToDateTime(dt.Rows[i]["CrateDate"]);
			recordList.Add(record);
		}
		obj.opinionReportItems = (OpinionReportItems[])(recordList.ToArray(typeof(OpinionReportItems)));
		return obj;
		}
		public OpinionReportRow GetByPrimaryKey(int opinionReportID)
		{
			string whereSql = "[OpinionReportID]=" + CreateSqlParameterName("OpinionReportID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "OpinionReportID", opinionReportID);
			OpinionReportRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(OpinionReportRow value)		{
			string sqlStr = "INSERT INTO [dbo].[OpinionReport] (" +
			"[ApplicantID], " + 
			"[FormID], " + 
			"[SeniorLawyerName], " + 
			"[SeniorPosition], " + 
			"[DirectorName], " + 
			"[DirectorPosition], " + 
			"[ChairmanName], " + 
			"[ChairmanPosition], " + 
			"[CrateDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("SeniorLawyerName") + ", " +
			CreateSqlParameterName("SeniorPosition") + ", " +
			CreateSqlParameterName("DirectorName") + ", " +
			CreateSqlParameterName("DirectorPosition") + ", " +
			CreateSqlParameterName("ChairmanName") + ", " +
			CreateSqlParameterName("ChairmanPosition") + ", " +
			CreateSqlParameterName("CrateDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "FormID", value.IsFormIDNull ? DBNull.Value : (object)value.FormID);
			AddParameter(cmd, "SeniorLawyerName", value.SeniorLawyerName);
			AddParameter(cmd, "SeniorPosition", value.SeniorPosition);
			AddParameter(cmd, "DirectorName", value.DirectorName);
			AddParameter(cmd, "DirectorPosition", value.DirectorPosition);
			AddParameter(cmd, "ChairmanName", value.ChairmanName);
			AddParameter(cmd, "ChairmanPosition", value.ChairmanPosition);
			AddParameter(cmd, "CrateDate", value.IsCrateDateNull ? DBNull.Value : (object)value.CrateDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(OpinionReportRow value)		{
			string sqlStr = "INSERT INTO [dbo].[OpinionReport] (" +
			"[ApplicantID], " + 
			"[FormID], " + 
			"[SeniorLawyerName], " + 
			"[SeniorPosition], " + 
			"[DirectorName], " + 
			"[DirectorPosition], " + 
			"[ChairmanName], " + 
			"[ChairmanPosition], " + 
			"[CrateDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("SeniorLawyerName") + ", " +
			CreateSqlParameterName("SeniorPosition") + ", " +
			CreateSqlParameterName("DirectorName") + ", " +
			CreateSqlParameterName("DirectorPosition") + ", " +
			CreateSqlParameterName("ChairmanName") + ", " +
			CreateSqlParameterName("ChairmanPosition") + ", " +
			CreateSqlParameterName("CrateDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "FormID", value.IsFormIDNull ? DBNull.Value : (object)value.FormID);
			AddParameter(cmd, "SeniorLawyerName", Sanitizer.GetSafeHtmlFragment(value.SeniorLawyerName));
			AddParameter(cmd, "SeniorPosition", Sanitizer.GetSafeHtmlFragment(value.SeniorPosition));
			AddParameter(cmd, "DirectorName", Sanitizer.GetSafeHtmlFragment(value.DirectorName));
			AddParameter(cmd, "DirectorPosition", Sanitizer.GetSafeHtmlFragment(value.DirectorPosition));
			AddParameter(cmd, "ChairmanName", Sanitizer.GetSafeHtmlFragment(value.ChairmanName));
			AddParameter(cmd, "ChairmanPosition", Sanitizer.GetSafeHtmlFragment(value.ChairmanPosition));
			AddParameter(cmd, "CrateDate", value.IsCrateDateNull ? DBNull.Value : (object)value.CrateDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(OpinionReportRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetOpinionReportID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetFormID)
				{
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID") + ",";
				}
				if (value._IsSetSeniorLawyerName)
				{
					strUpdate += "[SeniorLawyerName]=" + CreateSqlParameterName("SeniorLawyerName") + ",";
				}
				if (value._IsSetSeniorPosition)
				{
					strUpdate += "[SeniorPosition]=" + CreateSqlParameterName("SeniorPosition") + ",";
				}
				if (value._IsSetDirectorName)
				{
					strUpdate += "[DirectorName]=" + CreateSqlParameterName("DirectorName") + ",";
				}
				if (value._IsSetDirectorPosition)
				{
					strUpdate += "[DirectorPosition]=" + CreateSqlParameterName("DirectorPosition") + ",";
				}
				if (value._IsSetChairmanName)
				{
					strUpdate += "[ChairmanName]=" + CreateSqlParameterName("ChairmanName") + ",";
				}
				if (value._IsSetChairmanPosition)
				{
					strUpdate += "[ChairmanPosition]=" + CreateSqlParameterName("ChairmanPosition") + ",";
				}
				if (value._IsSetCrateDate)
				{
					strUpdate += "[CrateDate]=" + CreateSqlParameterName("CrateDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[OpinionReport] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[OpinionReportID]=" + CreateSqlParameterName("OpinionReportID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "OpinionReportID", value.OpinionReportID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "FormID", value.IsFormIDNull ? DBNull.Value : (object)value.FormID);
					AddParameter(cmd, "SeniorLawyerName", value.SeniorLawyerName);
					AddParameter(cmd, "SeniorPosition", value.SeniorPosition);
					AddParameter(cmd, "DirectorName", value.DirectorName);
					AddParameter(cmd, "DirectorPosition", value.DirectorPosition);
					AddParameter(cmd, "ChairmanName", value.ChairmanName);
					AddParameter(cmd, "ChairmanPosition", value.ChairmanPosition);
					AddParameter(cmd, "CrateDate", value.IsCrateDateNull ? DBNull.Value : (object)value.CrateDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(OpinionReportID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(OpinionReportRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetOpinionReportID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetFormID)
				{
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID") + ",";
				}
				if (value._IsSetSeniorLawyerName)
				{
					strUpdate += "[SeniorLawyerName]=" + CreateSqlParameterName("SeniorLawyerName") + ",";
				}
				if (value._IsSetSeniorPosition)
				{
					strUpdate += "[SeniorPosition]=" + CreateSqlParameterName("SeniorPosition") + ",";
				}
				if (value._IsSetDirectorName)
				{
					strUpdate += "[DirectorName]=" + CreateSqlParameterName("DirectorName") + ",";
				}
				if (value._IsSetDirectorPosition)
				{
					strUpdate += "[DirectorPosition]=" + CreateSqlParameterName("DirectorPosition") + ",";
				}
				if (value._IsSetChairmanName)
				{
					strUpdate += "[ChairmanName]=" + CreateSqlParameterName("ChairmanName") + ",";
				}
				if (value._IsSetChairmanPosition)
				{
					strUpdate += "[ChairmanPosition]=" + CreateSqlParameterName("ChairmanPosition") + ",";
				}
				if (value._IsSetCrateDate)
				{
					strUpdate += "[CrateDate]=" + CreateSqlParameterName("CrateDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[OpinionReport] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[OpinionReportID]=" + CreateSqlParameterName("OpinionReportID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "OpinionReportID", value.OpinionReportID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "FormID", value.IsFormIDNull ? DBNull.Value : (object)value.FormID);
					AddParameter(cmd, "SeniorLawyerName", Sanitizer.GetSafeHtmlFragment(value.SeniorLawyerName));
					AddParameter(cmd, "SeniorPosition", Sanitizer.GetSafeHtmlFragment(value.SeniorPosition));
					AddParameter(cmd, "DirectorName", Sanitizer.GetSafeHtmlFragment(value.DirectorName));
					AddParameter(cmd, "DirectorPosition", Sanitizer.GetSafeHtmlFragment(value.DirectorPosition));
					AddParameter(cmd, "ChairmanName", Sanitizer.GetSafeHtmlFragment(value.ChairmanName));
					AddParameter(cmd, "ChairmanPosition", Sanitizer.GetSafeHtmlFragment(value.ChairmanPosition));
					AddParameter(cmd, "CrateDate", value.IsCrateDateNull ? DBNull.Value : (object)value.CrateDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(OpinionReportID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int opinionReportID)
		{
			string whereSql = "[OpinionReportID]=" + CreateSqlParameterName("OpinionReportID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "OpinionReportID", opinionReportID);
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
		public int DeleteByFormID(int formID)
		{
			return DeleteByFormID(formID, false);
		}
		public int DeleteByFormID(int formID, bool formIDNull)
		{
			return CreateDeleteByFormIDCommand(formID, formIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFormIDCommand(int formID, bool formIDNull)
		{
			string whereSql = "";
			if (formIDNull)
				whereSql += "[FormID] IS NULL";
			else
				whereSql += "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!formIDNull)
				AddParameter(cmd, "FormID", formID);
			return cmd;
		}
		protected OpinionReportRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected OpinionReportRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected OpinionReportRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int opinionReportIDColumnIndex = reader.GetOrdinal("OpinionReportID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int seniorLawyerNameColumnIndex = reader.GetOrdinal("SeniorLawyerName");
			int seniorPositionColumnIndex = reader.GetOrdinal("SeniorPosition");
			int directorNameColumnIndex = reader.GetOrdinal("DirectorName");
			int directorPositionColumnIndex = reader.GetOrdinal("DirectorPosition");
			int chairmanNameColumnIndex = reader.GetOrdinal("ChairmanName");
			int chairmanPositionColumnIndex = reader.GetOrdinal("ChairmanPosition");
			int crateDateColumnIndex = reader.GetOrdinal("CrateDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					OpinionReportRow record = new OpinionReportRow();
					recordList.Add(record);
					record.OpinionReportID =  Convert.ToInt32(reader.GetValue(opinionReportIDColumnIndex));
					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(formIDColumnIndex)) record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));

					if (!reader.IsDBNull(seniorLawyerNameColumnIndex)) record.SeniorLawyerName =  Convert.ToString(reader.GetValue(seniorLawyerNameColumnIndex));

					if (!reader.IsDBNull(seniorPositionColumnIndex)) record.SeniorPosition =  Convert.ToString(reader.GetValue(seniorPositionColumnIndex));

					if (!reader.IsDBNull(directorNameColumnIndex)) record.DirectorName =  Convert.ToString(reader.GetValue(directorNameColumnIndex));

					if (!reader.IsDBNull(directorPositionColumnIndex)) record.DirectorPosition =  Convert.ToString(reader.GetValue(directorPositionColumnIndex));

					if (!reader.IsDBNull(chairmanNameColumnIndex)) record.ChairmanName =  Convert.ToString(reader.GetValue(chairmanNameColumnIndex));

					if (!reader.IsDBNull(chairmanPositionColumnIndex)) record.ChairmanPosition =  Convert.ToString(reader.GetValue(chairmanPositionColumnIndex));

					if (!reader.IsDBNull(crateDateColumnIndex)) record.CrateDate =  Convert.ToDateTime(reader.GetValue(crateDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OpinionReportRow[])(recordList.ToArray(typeof(OpinionReportRow)));
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
				case "OpinionReportID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SeniorLawyerName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SeniorPosition":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DirectorName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DirectorPosition":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ChairmanName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ChairmanPosition":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CrateDate":
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

