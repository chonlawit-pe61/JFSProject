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
	public partial class ApplicantFamilyCollection_Base : MarshalByRefObject
	{
		public const string FamilyIDColumnName = "FamilyID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string GroupNameColumnName = "GroupName";
		public const string NameColumnName = "Name";
		public const string AgeColumnName = "Age";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string CareerColumnName = "Career";
		public const string AddressLineColumnName = "AddressLine";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantFamilyCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantFamilyRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual ApplicantFamilyPaging GetPagingRelyOnFamilyIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ApplicantFamilyPaging applicantFamilyPaging = new ApplicantFamilyPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(FamilyID) as TotalRow from [dbo].[ApplicantFamily]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			applicantFamilyPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			applicantFamilyPaging.totalPage = (int)Math.Ceiling((double) applicantFamilyPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnFamilyID(whereSql, "FamilyID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			applicantFamilyPaging.applicantFamilyRow = MapRecords(command);
			return applicantFamilyPaging;
		}
		public virtual ApplicantFamilyPaging GetPagingRelyOnFamilyIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ApplicantFamilyPaging applicantFamilyPaging = new ApplicantFamilyPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(FamilyID) as TotalRow from [dbo].[ApplicantFamily]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			applicantFamilyPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			applicantFamilyPaging.totalPage = (int)Math.Ceiling((double)applicantFamilyPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnFamilyID(whereSql, "FamilyID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			applicantFamilyPaging.applicantFamilyRow = MapRecords(command);
			return applicantFamilyPaging;
		}
		public virtual ApplicantFamilyRow[] GetPagingRelyOnFamilyIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minFamilyID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FamilyID < " + minFamilyID.ToString();
			}
			else
			{
				whereSql = "FamilyID < " + minFamilyID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFamilyID(whereSql, "FamilyID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantFamilyRow[] GetPagingRelyOnFamilyIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minFamilyID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FamilyID > " + minFamilyID.ToString();
			}
			else
			{
				whereSql = "FamilyID > " + minFamilyID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFamilyID(whereSql, "FamilyID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantFamilyRow[] GetPagingRelyOnFamilyIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxFamilyID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FamilyID < " + maxFamilyID.ToString();
			}
			else
			{
				whereSql = "FamilyID < " + maxFamilyID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFamilyID(whereSql, "FamilyID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantFamilyRow[] GetPagingRelyOnFamilyIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxFamilyID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FamilyID > " + maxFamilyID.ToString();
			}
			else
			{
				whereSql = "FamilyID > " + maxFamilyID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFamilyID(whereSql, "FamilyID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantFamilyRow[] GetPagingRelyOnFamilyIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "FamilyID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			ApplicantFamilyRow[] applicantFamilyRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnFamilyID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantFamilyRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnFamilyIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantFamilyRow = MapRecords(command);
			}
			return applicantFamilyRow;
		}
		public virtual ApplicantFamilyRow[] GetPagingRelyOnFamilyIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "FamilyID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			ApplicantFamilyRow[] applicantFamilyRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnFamilyID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantFamilyRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnFamilyIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantFamilyRow = MapRecords(command);
			}
			return applicantFamilyRow;
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
			"[FamilyID],"+
			"[ApplicantID],"+
			"[GroupName],"+
			"[Name],"+
			"[Age],"+
			"[TelephoneNo],"+
			"[Career],"+
			"[AddressLine],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantFamily]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFamilyID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantFamily]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFamilyIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "FamilyID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantFamily] where FamilyID < (select min(minFamilyID) from(select top " + (rowPerPage * pageNumber).ToString() + " FamilyID as minFamilyID from [dbo].[ApplicantFamily]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ApplicantFamily]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFamilyIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "FamilyID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantFamily] where FamilyID > (select max(maxFamilyID) from(select top " + (rowPerPage * pageNumber).ToString() + " FamilyID as maxFamilyID from [dbo].[ApplicantFamily]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ApplicantFamily]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantFamily]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantFamily"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FamilyID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GroupName",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("Name",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Age",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Career",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("AddressLine",Type.GetType("System.String"));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ApplicantFamilyRow[] GetByApplicantID(int applicantID)
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
		public ApplicantFamilyRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantFamilyRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantFamilyRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantFamilyRow"/> objects.</returns>
		public virtual ApplicantFamilyRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantFamily]", top);
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
		public ApplicantFamilyRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantFamilyRow[] rows = null;
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
		public DataTable GetApplicantFamilyPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FamilyID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "FamilyID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(FamilyID) AS TotalRow FROM [dbo].[ApplicantFamily] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,FamilyID,ApplicantID,GroupName,Name,Age,TelephoneNo,Career,AddressLine,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantFamily] " + whereSql +
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
		public ApplicantFamilyItemsPaging GetApplicantFamilyPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FamilyID")
		{
		ApplicantFamilyItemsPaging obj = new ApplicantFamilyItemsPaging();
		DataTable dt = GetApplicantFamilyPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantFamilyItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantFamilyItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.FamilyID = Convert.ToInt32(dt.Rows[i]["FamilyID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.GroupName = dt.Rows[i]["GroupName"].ToString();
			record.Name = dt.Rows[i]["Name"].ToString();
			if (dt.Rows[i]["Age"] != DBNull.Value)
			record.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.Career = dt.Rows[i]["Career"].ToString();
			record.AddressLine = dt.Rows[i]["AddressLine"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantFamilyItems = (ApplicantFamilyItems[])(recordList.ToArray(typeof(ApplicantFamilyItems)));
		return obj;
		}
		public ApplicantFamilyRow GetByPrimaryKey(int familyID)
		{
			string whereSql = "[FamilyID]=" + CreateSqlParameterName("FamilyID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FamilyID", familyID);
			ApplicantFamilyRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(ApplicantFamilyRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantFamily] (" +
			"[ApplicantID], " + 
			"[GroupName], " + 
			"[Name], " + 
			"[Age], " + 
			"[TelephoneNo], " + 
			"[Career], " + 
			"[AddressLine], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("GroupName") + ", " +
			CreateSqlParameterName("Name") + ", " +
			CreateSqlParameterName("Age") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("Career") + ", " +
			CreateSqlParameterName("AddressLine") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "GroupName", value.GroupName);
			AddParameter(cmd, "Name", value.Name);
			AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
			AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
			AddParameter(cmd, "Career", value.Career);
			AddParameter(cmd, "AddressLine", value.AddressLine);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(ApplicantFamilyRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantFamily] (" +
			"[ApplicantID], " + 
			"[GroupName], " + 
			"[Name], " + 
			"[Age], " + 
			"[TelephoneNo], " + 
			"[Career], " + 
			"[AddressLine], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("GroupName") + ", " +
			CreateSqlParameterName("Name") + ", " +
			CreateSqlParameterName("Age") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("Career") + ", " +
			CreateSqlParameterName("AddressLine") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "GroupName", Sanitizer.GetSafeHtmlFragment(value.GroupName));
			AddParameter(cmd, "Name", Sanitizer.GetSafeHtmlFragment(value.Name));
			AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
			AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
			AddParameter(cmd, "Career", Sanitizer.GetSafeHtmlFragment(value.Career));
			AddParameter(cmd, "AddressLine", Sanitizer.GetSafeHtmlFragment(value.AddressLine));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(ApplicantFamilyRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFamilyID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetGroupName)
				{
					strUpdate += "[GroupName]=" + CreateSqlParameterName("GroupName") + ",";
				}
				if (value._IsSetName)
				{
					strUpdate += "[Name]=" + CreateSqlParameterName("Name") + ",";
				}
				if (value._IsSetAge)
				{
					strUpdate += "[Age]=" + CreateSqlParameterName("Age") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetCareer)
				{
					strUpdate += "[Career]=" + CreateSqlParameterName("Career") + ",";
				}
				if (value._IsSetAddressLine)
				{
					strUpdate += "[AddressLine]=" + CreateSqlParameterName("AddressLine") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantFamily] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FamilyID]=" + CreateSqlParameterName("FamilyID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FamilyID", value.FamilyID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "GroupName", value.GroupName);
					AddParameter(cmd, "Name", value.Name);
					AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
					AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
					AddParameter(cmd, "Career", value.Career);
					AddParameter(cmd, "AddressLine", value.AddressLine);
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
				Exception ex = new Exception("Set incorrect primarykey PK(FamilyID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantFamilyRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFamilyID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetGroupName)
				{
					strUpdate += "[GroupName]=" + CreateSqlParameterName("GroupName") + ",";
				}
				if (value._IsSetName)
				{
					strUpdate += "[Name]=" + CreateSqlParameterName("Name") + ",";
				}
				if (value._IsSetAge)
				{
					strUpdate += "[Age]=" + CreateSqlParameterName("Age") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetCareer)
				{
					strUpdate += "[Career]=" + CreateSqlParameterName("Career") + ",";
				}
				if (value._IsSetAddressLine)
				{
					strUpdate += "[AddressLine]=" + CreateSqlParameterName("AddressLine") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantFamily] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FamilyID]=" + CreateSqlParameterName("FamilyID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FamilyID", value.FamilyID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "GroupName", Sanitizer.GetSafeHtmlFragment(value.GroupName));
					AddParameter(cmd, "Name", Sanitizer.GetSafeHtmlFragment(value.Name));
					AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
					AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
					AddParameter(cmd, "Career", Sanitizer.GetSafeHtmlFragment(value.Career));
					AddParameter(cmd, "AddressLine", Sanitizer.GetSafeHtmlFragment(value.AddressLine));
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
				Exception ex = new Exception("Set incorrect primarykey PK(FamilyID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int familyID)
		{
			string whereSql = "[FamilyID]=" + CreateSqlParameterName("FamilyID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FamilyID", familyID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return CreateDeleteByApplicantIDCommand(applicantID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		protected ApplicantFamilyRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantFamilyRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantFamilyRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int familyIDColumnIndex = reader.GetOrdinal("FamilyID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int groupNameColumnIndex = reader.GetOrdinal("GroupName");
			int nameColumnIndex = reader.GetOrdinal("Name");
			int ageColumnIndex = reader.GetOrdinal("Age");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int careerColumnIndex = reader.GetOrdinal("Career");
			int addressLineColumnIndex = reader.GetOrdinal("AddressLine");
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
					ApplicantFamilyRow record = new ApplicantFamilyRow();
					recordList.Add(record);
					record.FamilyID =  Convert.ToInt32(reader.GetValue(familyIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(groupNameColumnIndex)) record.GroupName =  Convert.ToString(reader.GetValue(groupNameColumnIndex));

					if (!reader.IsDBNull(nameColumnIndex)) record.Name =  Convert.ToString(reader.GetValue(nameColumnIndex));

					if (!reader.IsDBNull(ageColumnIndex)) record.Age =  Convert.ToInt32(reader.GetValue(ageColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(careerColumnIndex)) record.Career =  Convert.ToString(reader.GetValue(careerColumnIndex));

					if (!reader.IsDBNull(addressLineColumnIndex)) record.AddressLine =  Convert.ToString(reader.GetValue(addressLineColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantFamilyRow[])(recordList.ToArray(typeof(ApplicantFamilyRow)));
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
				case "FamilyID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "GroupName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Name":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Age":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Career":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AddressLine":
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

