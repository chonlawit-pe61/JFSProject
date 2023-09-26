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
	public partial class ApplicantIncomeCollection_Base : MarshalByRefObject
	{
		public const string IncomeIDColumnName = "IncomeID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string IsPermanentColumnName = "IsPermanent";
		public const string OcupationPositionColumnName = "OcupationPosition";
		public const string IncomeColumnName = "Income";
		public const string IncomeUnitColumnName = "IncomeUnit";
		public const string WorkPlaceColumnName = "WorkPlace";
		public const string TelphoneNoColumnName = "TelphoneNo";
		public const string YearsExperienceColumnName = "YearsExperience";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantIncomeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantIncomeRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual ApplicantIncomePaging GetPagingRelyOnIncomeIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ApplicantIncomePaging applicantIncomePaging = new ApplicantIncomePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(IncomeID) as TotalRow from [dbo].[ApplicantIncome]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			applicantIncomePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			applicantIncomePaging.totalPage = (int)Math.Ceiling((double) applicantIncomePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnIncomeID(whereSql, "IncomeID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			applicantIncomePaging.applicantIncomeRow = MapRecords(command);
			return applicantIncomePaging;
		}
		public virtual ApplicantIncomePaging GetPagingRelyOnIncomeIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ApplicantIncomePaging applicantIncomePaging = new ApplicantIncomePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(IncomeID) as TotalRow from [dbo].[ApplicantIncome]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			applicantIncomePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			applicantIncomePaging.totalPage = (int)Math.Ceiling((double)applicantIncomePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnIncomeID(whereSql, "IncomeID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			applicantIncomePaging.applicantIncomeRow = MapRecords(command);
			return applicantIncomePaging;
		}
		public virtual ApplicantIncomeRow[] GetPagingRelyOnIncomeIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minIncomeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And IncomeID < " + minIncomeID.ToString();
			}
			else
			{
				whereSql = "IncomeID < " + minIncomeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnIncomeID(whereSql, "IncomeID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantIncomeRow[] GetPagingRelyOnIncomeIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minIncomeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And IncomeID > " + minIncomeID.ToString();
			}
			else
			{
				whereSql = "IncomeID > " + minIncomeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnIncomeID(whereSql, "IncomeID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantIncomeRow[] GetPagingRelyOnIncomeIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxIncomeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And IncomeID < " + maxIncomeID.ToString();
			}
			else
			{
				whereSql = "IncomeID < " + maxIncomeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnIncomeID(whereSql, "IncomeID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantIncomeRow[] GetPagingRelyOnIncomeIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxIncomeID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And IncomeID > " + maxIncomeID.ToString();
			}
			else
			{
				whereSql = "IncomeID > " + maxIncomeID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnIncomeID(whereSql, "IncomeID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ApplicantIncomeRow[] GetPagingRelyOnIncomeIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "IncomeID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			ApplicantIncomeRow[] applicantIncomeRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnIncomeID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantIncomeRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnIncomeIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantIncomeRow = MapRecords(command);
			}
			return applicantIncomeRow;
		}
		public virtual ApplicantIncomeRow[] GetPagingRelyOnIncomeIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "IncomeID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			ApplicantIncomeRow[] applicantIncomeRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnIncomeID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantIncomeRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnIncomeIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				applicantIncomeRow = MapRecords(command);
			}
			return applicantIncomeRow;
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
			"[IncomeID],"+
			"[ApplicantID],"+
			"[IsPermanent],"+
			"[OcupationPosition],"+
			"[Income],"+
			"[IncomeUnit],"+
			"[WorkPlace],"+
			"[TelphoneNo],"+
			"[YearsExperience],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantIncome]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnIncomeID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantIncome]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnIncomeIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "IncomeID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantIncome] where IncomeID < (select min(minIncomeID) from(select top " + (rowPerPage * pageNumber).ToString() + " IncomeID as minIncomeID from [dbo].[ApplicantIncome]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ApplicantIncome]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnIncomeIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "IncomeID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[ApplicantIncome] where IncomeID > (select max(maxIncomeID) from(select top " + (rowPerPage * pageNumber).ToString() + " IncomeID as maxIncomeID from [dbo].[ApplicantIncome]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[ApplicantIncome]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantIncome]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantIncome"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("IncomeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsPermanent",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("OcupationPosition",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Income",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("IncomeUnit",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("WorkPlace",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("TelphoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("YearsExperience",Type.GetType("System.Decimal"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ApplicantIncomeRow[] GetByApplicantID(int applicantID)
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
		public ApplicantIncomeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantIncomeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantIncomeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantIncomeRow"/> objects.</returns>
		public virtual ApplicantIncomeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantIncome]", top);
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
		public ApplicantIncomeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantIncomeRow[] rows = null;
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
		public DataTable GetApplicantIncomePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "IncomeID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "IncomeID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(IncomeID) AS TotalRow FROM [dbo].[ApplicantIncome] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,IncomeID,ApplicantID,IsPermanent,OcupationPosition,Income,IncomeUnit,WorkPlace,TelphoneNo,YearsExperience,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantIncome] " + whereSql +
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
		public ApplicantIncomeItemsPaging GetApplicantIncomePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "IncomeID")
		{
		ApplicantIncomeItemsPaging obj = new ApplicantIncomeItemsPaging();
		DataTable dt = GetApplicantIncomePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantIncomeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantIncomeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.IncomeID = Convert.ToInt32(dt.Rows[i]["IncomeID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["IsPermanent"] != DBNull.Value)
			record.IsPermanent = Convert.ToBoolean(dt.Rows[i]["IsPermanent"]);
			record.OcupationPosition = dt.Rows[i]["OcupationPosition"].ToString();
			if (dt.Rows[i]["Income"] != DBNull.Value)
			record.Income = Convert.ToDouble(dt.Rows[i]["Income"]);
			record.IncomeUnit = dt.Rows[i]["IncomeUnit"].ToString();
			record.WorkPlace = dt.Rows[i]["WorkPlace"].ToString();
			record.TelphoneNo = dt.Rows[i]["TelphoneNo"].ToString();
			if (dt.Rows[i]["YearsExperience"] != DBNull.Value)
			record.YearsExperience = Convert.ToDecimal(dt.Rows[i]["YearsExperience"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantIncomeItems = (ApplicantIncomeItems[])(recordList.ToArray(typeof(ApplicantIncomeItems)));
		return obj;
		}
		public ApplicantIncomeRow GetByPrimaryKey(int incomeiD)
		{
			string whereSql = "[IncomeID]=" + CreateSqlParameterName("IncomeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IncomeID", incomeiD);
			ApplicantIncomeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(ApplicantIncomeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantIncome] (" +
			"[ApplicantID], " + 
			"[IsPermanent], " + 
			"[OcupationPosition], " + 
			"[Income], " + 
			"[IncomeUnit], " + 
			"[WorkPlace], " + 
			"[TelphoneNo], " + 
			"[YearsExperience], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("IsPermanent") + ", " +
			CreateSqlParameterName("OcupationPosition") + ", " +
			CreateSqlParameterName("Income") + ", " +
			CreateSqlParameterName("IncomeUnit") + ", " +
			CreateSqlParameterName("WorkPlace") + ", " +
			CreateSqlParameterName("TelphoneNo") + ", " +
			CreateSqlParameterName("YearsExperience") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "IsPermanent", value.IsIsPermanentNull ? DBNull.Value : (object)value.IsPermanent);
			AddParameter(cmd, "OcupationPosition", value.OcupationPosition);
			AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
			AddParameter(cmd, "IncomeUnit", value.IncomeUnit);
			AddParameter(cmd, "WorkPlace", value.WorkPlace);
			AddParameter(cmd, "TelphoneNo", value.TelphoneNo);
			AddParameter(cmd, "YearsExperience", value.IsYearsExperienceNull ? DBNull.Value : (object)value.YearsExperience);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(ApplicantIncomeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantIncome] (" +
			"[ApplicantID], " + 
			"[IsPermanent], " + 
			"[OcupationPosition], " + 
			"[Income], " + 
			"[IncomeUnit], " + 
			"[WorkPlace], " + 
			"[TelphoneNo], " + 
			"[YearsExperience], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("IsPermanent") + ", " +
			CreateSqlParameterName("OcupationPosition") + ", " +
			CreateSqlParameterName("Income") + ", " +
			CreateSqlParameterName("IncomeUnit") + ", " +
			CreateSqlParameterName("WorkPlace") + ", " +
			CreateSqlParameterName("TelphoneNo") + ", " +
			CreateSqlParameterName("YearsExperience") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "IsPermanent", value.IsIsPermanentNull ? DBNull.Value : (object)value.IsPermanent);
			AddParameter(cmd, "OcupationPosition", Sanitizer.GetSafeHtmlFragment(value.OcupationPosition));
			AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
			AddParameter(cmd, "IncomeUnit", Sanitizer.GetSafeHtmlFragment(value.IncomeUnit));
			AddParameter(cmd, "WorkPlace", Sanitizer.GetSafeHtmlFragment(value.WorkPlace));
			AddParameter(cmd, "TelphoneNo", Sanitizer.GetSafeHtmlFragment(value.TelphoneNo));
			AddParameter(cmd, "YearsExperience", value.IsYearsExperienceNull ? DBNull.Value : (object)value.YearsExperience);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(ApplicantIncomeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetIncomeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetIsPermanent)
				{
					strUpdate += "[IsPermanent]=" + CreateSqlParameterName("IsPermanent") + ",";
				}
				if (value._IsSetOcupationPosition)
				{
					strUpdate += "[OcupationPosition]=" + CreateSqlParameterName("OcupationPosition") + ",";
				}
				if (value._IsSetIncome)
				{
					strUpdate += "[Income]=" + CreateSqlParameterName("Income") + ",";
				}
				if (value._IsSetIncomeUnit)
				{
					strUpdate += "[IncomeUnit]=" + CreateSqlParameterName("IncomeUnit") + ",";
				}
				if (value._IsSetWorkPlace)
				{
					strUpdate += "[WorkPlace]=" + CreateSqlParameterName("WorkPlace") + ",";
				}
				if (value._IsSetTelphoneNo)
				{
					strUpdate += "[TelphoneNo]=" + CreateSqlParameterName("TelphoneNo") + ",";
				}
				if (value._IsSetYearsExperience)
				{
					strUpdate += "[YearsExperience]=" + CreateSqlParameterName("YearsExperience") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantIncome] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[IncomeID]=" + CreateSqlParameterName("IncomeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "IncomeID", value.IncomeID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "IsPermanent", value.IsIsPermanentNull ? DBNull.Value : (object)value.IsPermanent);
					AddParameter(cmd, "OcupationPosition", value.OcupationPosition);
					AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
					AddParameter(cmd, "IncomeUnit", value.IncomeUnit);
					AddParameter(cmd, "WorkPlace", value.WorkPlace);
					AddParameter(cmd, "TelphoneNo", value.TelphoneNo);
					AddParameter(cmd, "YearsExperience", value.IsYearsExperienceNull ? DBNull.Value : (object)value.YearsExperience);
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
				Exception ex = new Exception("Set incorrect primarykey PK(IncomeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantIncomeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetIncomeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetIsPermanent)
				{
					strUpdate += "[IsPermanent]=" + CreateSqlParameterName("IsPermanent") + ",";
				}
				if (value._IsSetOcupationPosition)
				{
					strUpdate += "[OcupationPosition]=" + CreateSqlParameterName("OcupationPosition") + ",";
				}
				if (value._IsSetIncome)
				{
					strUpdate += "[Income]=" + CreateSqlParameterName("Income") + ",";
				}
				if (value._IsSetIncomeUnit)
				{
					strUpdate += "[IncomeUnit]=" + CreateSqlParameterName("IncomeUnit") + ",";
				}
				if (value._IsSetWorkPlace)
				{
					strUpdate += "[WorkPlace]=" + CreateSqlParameterName("WorkPlace") + ",";
				}
				if (value._IsSetTelphoneNo)
				{
					strUpdate += "[TelphoneNo]=" + CreateSqlParameterName("TelphoneNo") + ",";
				}
				if (value._IsSetYearsExperience)
				{
					strUpdate += "[YearsExperience]=" + CreateSqlParameterName("YearsExperience") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantIncome] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[IncomeID]=" + CreateSqlParameterName("IncomeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "IncomeID", value.IncomeID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "IsPermanent", value.IsIsPermanentNull ? DBNull.Value : (object)value.IsPermanent);
					AddParameter(cmd, "OcupationPosition", Sanitizer.GetSafeHtmlFragment(value.OcupationPosition));
					AddParameter(cmd, "Income", value.IsIncomeNull ? DBNull.Value : (object)value.Income);
					AddParameter(cmd, "IncomeUnit", Sanitizer.GetSafeHtmlFragment(value.IncomeUnit));
					AddParameter(cmd, "WorkPlace", Sanitizer.GetSafeHtmlFragment(value.WorkPlace));
					AddParameter(cmd, "TelphoneNo", Sanitizer.GetSafeHtmlFragment(value.TelphoneNo));
					AddParameter(cmd, "YearsExperience", value.IsYearsExperienceNull ? DBNull.Value : (object)value.YearsExperience);
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
				Exception ex = new Exception("Set incorrect primarykey PK(IncomeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int incomeiD)
		{
			string whereSql = "[IncomeID]=" + CreateSqlParameterName("IncomeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "IncomeID", incomeiD);
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
		protected ApplicantIncomeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantIncomeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantIncomeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int incomeiDColumnIndex = reader.GetOrdinal("IncomeID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int isPermanentColumnIndex = reader.GetOrdinal("IsPermanent");
			int ocupationPositionColumnIndex = reader.GetOrdinal("OcupationPosition");
			int incomeColumnIndex = reader.GetOrdinal("Income");
			int incomeUnitColumnIndex = reader.GetOrdinal("IncomeUnit");
			int workPlaceColumnIndex = reader.GetOrdinal("WorkPlace");
			int telphoneNoColumnIndex = reader.GetOrdinal("TelphoneNo");
			int yearsExperienceColumnIndex = reader.GetOrdinal("YearsExperience");
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
					ApplicantIncomeRow record = new ApplicantIncomeRow();
					recordList.Add(record);
					record.IncomeID =  Convert.ToInt32(reader.GetValue(incomeiDColumnIndex));
					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(isPermanentColumnIndex)) record.IsPermanent =  Convert.ToBoolean(reader.GetValue(isPermanentColumnIndex));

					if (!reader.IsDBNull(ocupationPositionColumnIndex)) record.OcupationPosition =  Convert.ToString(reader.GetValue(ocupationPositionColumnIndex));

					if (!reader.IsDBNull(incomeColumnIndex)) record.Income =  Convert.ToDouble(reader.GetValue(incomeColumnIndex));

					if (!reader.IsDBNull(incomeUnitColumnIndex)) record.IncomeUnit =  Convert.ToString(reader.GetValue(incomeUnitColumnIndex));

					if (!reader.IsDBNull(workPlaceColumnIndex)) record.WorkPlace =  Convert.ToString(reader.GetValue(workPlaceColumnIndex));

					if (!reader.IsDBNull(telphoneNoColumnIndex)) record.TelphoneNo =  Convert.ToString(reader.GetValue(telphoneNoColumnIndex));

					if (!reader.IsDBNull(yearsExperienceColumnIndex)) record.YearsExperience =  Convert.ToDecimal(reader.GetValue(yearsExperienceColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantIncomeRow[])(recordList.ToArray(typeof(ApplicantIncomeRow)));
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
				case "IncomeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsPermanent":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "OcupationPosition":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Income":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "IncomeUnit":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "WorkPlace":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TelphoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "YearsExperience":
					parameter = AddParameter(cmd, paramName, DbType.Decimal, value);
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

