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
	public partial class CaseApplicantTempCollection_Base : MarshalByRefObject
	{
		public const string TransactionIDColumnName = "TransactionID";
		public const string ReferenceMSCIDColumnName = "ReferenceMSCID";
		public const string ReferenceMSCCodeColumnName = "ReferenceMSCCode";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string SubjectColumnName = "Subject";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string GenderColumnName = "Gender";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string PostCodeColumnName = "PostCode";
		public const string CardIDColumnName = "CardID";
		public const string DefactiveColumnName = "Defactive";
		public const string RemarkColumnName = "Remark";
		public const string CreateDateColumnName = "CreateDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string StatusColumnName = "Status";
		public const string CentralColumnName = "Central";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseApplicantTempCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseApplicantTempRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual CaseApplicantTempPaging GetPagingRelyOnTransactionIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseApplicantTempPaging caseApplicantTempPaging = new CaseApplicantTempPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionID) as TotalRow from [dbo].[CaseApplicantTemp]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseApplicantTempPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseApplicantTempPaging.totalPage = (int)Math.Ceiling((double) caseApplicantTempPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseApplicantTempPaging.caseApplicantTempRow = MapRecords(command);
			return caseApplicantTempPaging;
		}
		public virtual CaseApplicantTempPaging GetPagingRelyOnTransactionIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseApplicantTempPaging caseApplicantTempPaging = new CaseApplicantTempPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionID) as TotalRow from [dbo].[CaseApplicantTemp]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseApplicantTempPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseApplicantTempPaging.totalPage = (int)Math.Ceiling((double)caseApplicantTempPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseApplicantTempPaging.caseApplicantTempRow = MapRecords(command);
			return caseApplicantTempPaging;
		}
		public virtual CaseApplicantTempRow[] GetPagingRelyOnTransactionIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID < " + minTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID < " + minTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseApplicantTempRow[] GetPagingRelyOnTransactionIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID > " + minTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID > " + minTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseApplicantTempRow[] GetPagingRelyOnTransactionIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID < " + maxTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID < " + maxTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseApplicantTempRow[] GetPagingRelyOnTransactionIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID > " + maxTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID > " + maxTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseApplicantTempRow[] GetPagingRelyOnTransactionIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			CaseApplicantTempRow[] caseApplicantTempRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseApplicantTempRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseApplicantTempRow = MapRecords(command);
			}
			return caseApplicantTempRow;
		}
		public virtual CaseApplicantTempRow[] GetPagingRelyOnTransactionIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			CaseApplicantTempRow[] caseApplicantTempRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseApplicantTempRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseApplicantTempRow = MapRecords(command);
			}
			return caseApplicantTempRow;
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
			"[TransactionID],"+
			"[ReferenceMSCID],"+
			"[ReferenceMSCCode],"+
			"[ProvinceID],"+
			"[DepartmentID],"+
			"[Subject],"+
			"[TelephoneNo],"+
			"[Gender],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[ProvinceName],"+
			"[PostCode],"+
			"[CardID],"+
			"[Defactive],"+
			"[Remark],"+
			"[CreateDate],"+
			"[ModifiedDate],"+
			"[Status],"+
			"[Central]"+
			" FROM [dbo].[CaseApplicantTemp]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseApplicantTemp]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseApplicantTemp] where TransactionID < (select min(minTransactionID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionID as minTransactionID from [dbo].[CaseApplicantTemp]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseApplicantTemp]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseApplicantTemp] where TransactionID > (select max(maxTransactionID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionID as maxTransactionID from [dbo].[CaseApplicantTemp]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseApplicantTemp]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseApplicantTemp]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseApplicantTemp"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ReferenceMSCID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("PostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("Defactive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Status",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Central",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			return dataTable;
		}
		public CaseApplicantTempRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseApplicantTempRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseApplicantTempRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseApplicantTempRow"/> objects.</returns>
		public virtual CaseApplicantTempRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseApplicantTemp]", top);
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
		public CaseApplicantTempRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseApplicantTempRow[] rows = null;
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
		public DataTable GetCaseApplicantTempPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TransactionID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TransactionID) AS TotalRow FROM [dbo].[CaseApplicantTemp] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionID,ReferenceMSCID,ReferenceMSCCode,ProvinceID,DepartmentID,Subject,TelephoneNo,Gender,Title,FirstName,LastName,ProvinceName,PostCode,CardID,Defactive,Remark,CreateDate,ModifiedDate,Status,Central," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseApplicantTemp] " + whereSql +
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
		public CaseApplicantTempItemsPaging GetCaseApplicantTempPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
		CaseApplicantTempItemsPaging obj = new CaseApplicantTempItemsPaging();
		DataTable dt = GetCaseApplicantTempPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseApplicantTempItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseApplicantTempItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			if (dt.Rows[i]["ReferenceMSCID"] != DBNull.Value)
			record.ReferenceMSCID = Convert.ToInt32(dt.Rows[i]["ReferenceMSCID"]);
			record.ReferenceMSCCode = dt.Rows[i]["ReferenceMSCCode"].ToString();
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			record.PostCode = dt.Rows[i]["PostCode"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			if (dt.Rows[i]["Defactive"] != DBNull.Value)
			record.Defactive = Convert.ToBoolean(dt.Rows[i]["Defactive"]);
			record.Remark = dt.Rows[i]["Remark"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["Status"] != DBNull.Value)
			record.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
			record.Central = dt.Rows[i]["Central"].ToString();
			recordList.Add(record);
		}
		obj.caseApplicantTempItems = (CaseApplicantTempItems[])(recordList.ToArray(typeof(CaseApplicantTempItems)));
		return obj;
		}
		public CaseApplicantTempRow GetByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionID", transactionID);
			CaseApplicantTempRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(CaseApplicantTempRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantTemp] (" +
			"[ReferenceMSCID], " + 
			"[ReferenceMSCCode], " + 
			"[ProvinceID], " + 
			"[DepartmentID], " + 
			"[Subject], " + 
			"[TelephoneNo], " + 
			"[Gender], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[ProvinceName], " + 
			"[PostCode], " + 
			"[CardID], " + 
			"[Defactive], " + 
			"[Remark], " + 
			"[CreateDate], " + 
			"[ModifiedDate], " + 
			"[Status], " + 
			"[Central]			" + 
			") VALUES (" +
			CreateSqlParameterName("ReferenceMSCID") + ", " +
			CreateSqlParameterName("ReferenceMSCCode") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("ProvinceName") + ", " +
			CreateSqlParameterName("PostCode") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Defactive") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("Status") + ", " +
			CreateSqlParameterName("Central") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
			AddParameter(cmd, "ReferenceMSCCode", value.ReferenceMSCCode);
			AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
			AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
			AddParameter(cmd, "Subject", value.Subject);
			AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
			AddParameter(cmd, "Gender", value.Gender);
			AddParameter(cmd, "Title", value.Title);
			AddParameter(cmd, "FirstName", value.FirstName);
			AddParameter(cmd, "LastName", value.LastName);
			AddParameter(cmd, "ProvinceName", value.ProvinceName);
			AddParameter(cmd, "PostCode", value.PostCode);
			AddParameter(cmd, "CardID", value.CardID);
			AddParameter(cmd, "Defactive", value.IsDefactiveNull ? DBNull.Value : (object)value.Defactive);
			AddParameter(cmd, "Remark", value.Remark);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "Status", value.IsStatusNull ? DBNull.Value : (object)value.Status);
			AddParameter(cmd, "Central", value.Central);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(CaseApplicantTempRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantTemp] (" +
			"[ReferenceMSCID], " + 
			"[ReferenceMSCCode], " + 
			"[ProvinceID], " + 
			"[DepartmentID], " + 
			"[Subject], " + 
			"[TelephoneNo], " + 
			"[Gender], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[ProvinceName], " + 
			"[PostCode], " + 
			"[CardID], " + 
			"[Defactive], " + 
			"[Remark], " + 
			"[CreateDate], " + 
			"[ModifiedDate], " + 
			"[Status], " + 
			"[Central]			" + 
			") VALUES (" +
			CreateSqlParameterName("ReferenceMSCID") + ", " +
			CreateSqlParameterName("ReferenceMSCCode") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("ProvinceName") + ", " +
			CreateSqlParameterName("PostCode") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Defactive") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("Status") + ", " +
			CreateSqlParameterName("Central") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
			AddParameter(cmd, "ReferenceMSCCode", Sanitizer.GetSafeHtmlFragment(value.ReferenceMSCCode));
			AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
			AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
			AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
			AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
			AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "ProvinceName", Sanitizer.GetSafeHtmlFragment(value.ProvinceName));
			AddParameter(cmd, "PostCode", Sanitizer.GetSafeHtmlFragment(value.PostCode));
			AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
			AddParameter(cmd, "Defactive", value.IsDefactiveNull ? DBNull.Value : (object)value.Defactive);
			AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "Status", value.IsStatusNull ? DBNull.Value : (object)value.Status);
			AddParameter(cmd, "Central", Sanitizer.GetSafeHtmlFragment(value.Central));
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(CaseApplicantTempRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetReferenceMSCID)
				{
					strUpdate += "[ReferenceMSCID]=" + CreateSqlParameterName("ReferenceMSCID") + ",";
				}
				if (value._IsSetReferenceMSCCode)
				{
					strUpdate += "[ReferenceMSCCode]=" + CreateSqlParameterName("ReferenceMSCCode") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetProvinceName)
				{
					strUpdate += "[ProvinceName]=" + CreateSqlParameterName("ProvinceName") + ",";
				}
				if (value._IsSetPostCode)
				{
					strUpdate += "[PostCode]=" + CreateSqlParameterName("PostCode") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetDefactive)
				{
					strUpdate += "[Defactive]=" + CreateSqlParameterName("Defactive") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetStatus)
				{
					strUpdate += "[Status]=" + CreateSqlParameterName("Status") + ",";
				}
				if (value._IsSetCentral)
				{
					strUpdate += "[Central]=" + CreateSqlParameterName("Central") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantTemp] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
					AddParameter(cmd, "ReferenceMSCCode", value.ReferenceMSCCode);
					AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
					AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
					AddParameter(cmd, "Subject", value.Subject);
					AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
					AddParameter(cmd, "Gender", value.Gender);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
					AddParameter(cmd, "ProvinceName", value.ProvinceName);
					AddParameter(cmd, "PostCode", value.PostCode);
					AddParameter(cmd, "CardID", value.CardID);
					AddParameter(cmd, "Defactive", value.IsDefactiveNull ? DBNull.Value : (object)value.Defactive);
					AddParameter(cmd, "Remark", value.Remark);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "Status", value.IsStatusNull ? DBNull.Value : (object)value.Status);
					AddParameter(cmd, "Central", value.Central);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseApplicantTempRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetReferenceMSCID)
				{
					strUpdate += "[ReferenceMSCID]=" + CreateSqlParameterName("ReferenceMSCID") + ",";
				}
				if (value._IsSetReferenceMSCCode)
				{
					strUpdate += "[ReferenceMSCCode]=" + CreateSqlParameterName("ReferenceMSCCode") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetProvinceName)
				{
					strUpdate += "[ProvinceName]=" + CreateSqlParameterName("ProvinceName") + ",";
				}
				if (value._IsSetPostCode)
				{
					strUpdate += "[PostCode]=" + CreateSqlParameterName("PostCode") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetDefactive)
				{
					strUpdate += "[Defactive]=" + CreateSqlParameterName("Defactive") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetStatus)
				{
					strUpdate += "[Status]=" + CreateSqlParameterName("Status") + ",";
				}
				if (value._IsSetCentral)
				{
					strUpdate += "[Central]=" + CreateSqlParameterName("Central") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantTemp] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
					AddParameter(cmd, "ReferenceMSCCode", Sanitizer.GetSafeHtmlFragment(value.ReferenceMSCCode));
					AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
					AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
					AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
					AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
					AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "ProvinceName", Sanitizer.GetSafeHtmlFragment(value.ProvinceName));
					AddParameter(cmd, "PostCode", Sanitizer.GetSafeHtmlFragment(value.PostCode));
					AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
					AddParameter(cmd, "Defactive", value.IsDefactiveNull ? DBNull.Value : (object)value.Defactive);
					AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "Status", value.IsStatusNull ? DBNull.Value : (object)value.Status);
					AddParameter(cmd, "Central", Sanitizer.GetSafeHtmlFragment(value.Central));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionID", transactionID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected CaseApplicantTempRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseApplicantTempRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseApplicantTempRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int referenceMSCIDColumnIndex = reader.GetOrdinal("ReferenceMSCID");
			int referenceMSCCodeColumnIndex = reader.GetOrdinal("ReferenceMSCCode");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int defactiveColumnIndex = reader.GetOrdinal("Defactive");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int statusColumnIndex = reader.GetOrdinal("Status");
			int centralColumnIndex = reader.GetOrdinal("Central");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					CaseApplicantTempRow record = new CaseApplicantTempRow();
					recordList.Add(record);
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(referenceMSCIDColumnIndex)) record.ReferenceMSCID =  Convert.ToInt32(reader.GetValue(referenceMSCIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCCodeColumnIndex)) record.ReferenceMSCCode =  Convert.ToString(reader.GetValue(referenceMSCCodeColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(defactiveColumnIndex)) record.Defactive =  Convert.ToBoolean(reader.GetValue(defactiveColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(statusColumnIndex)) record.Status =  Convert.ToInt32(reader.GetValue(statusColumnIndex));

					if (!reader.IsDBNull(centralColumnIndex)) record.Central =  Convert.ToString(reader.GetValue(centralColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseApplicantTempRow[])(recordList.ToArray(typeof(CaseApplicantTempRow)));
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
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "PostCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Defactive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Status":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Central":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

