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
	public partial class CaseProjectSourceFundCollection_Base : MarshalByRefObject
	{
		public const string SourceFundIDColumnName = "SourceFundID";
		public const string CaseIDColumnName = "CaseID";
		public const string SourceFundNameColumnName = "SourceFundName";
		public const string AmountColumnName = "Amount";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseProjectSourceFundCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseProjectSourceFundRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual CaseProjectSourceFundPaging GetPagingRelyOnSourceFundIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseProjectSourceFundPaging caseProjectSourceFundPaging = new CaseProjectSourceFundPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(SourceFundID) as TotalRow from [dbo].[CaseProjectSourceFund]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseProjectSourceFundPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseProjectSourceFundPaging.totalPage = (int)Math.Ceiling((double) caseProjectSourceFundPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnSourceFundID(whereSql, "SourceFundID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseProjectSourceFundPaging.caseProjectSourceFundRow = MapRecords(command);
			return caseProjectSourceFundPaging;
		}
		public virtual CaseProjectSourceFundPaging GetPagingRelyOnSourceFundIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseProjectSourceFundPaging caseProjectSourceFundPaging = new CaseProjectSourceFundPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(SourceFundID) as TotalRow from [dbo].[CaseProjectSourceFund]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseProjectSourceFundPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseProjectSourceFundPaging.totalPage = (int)Math.Ceiling((double)caseProjectSourceFundPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnSourceFundID(whereSql, "SourceFundID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseProjectSourceFundPaging.caseProjectSourceFundRow = MapRecords(command);
			return caseProjectSourceFundPaging;
		}
		public virtual CaseProjectSourceFundRow[] GetPagingRelyOnSourceFundIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minSourceFundID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SourceFundID < " + minSourceFundID.ToString();
			}
			else
			{
				whereSql = "SourceFundID < " + minSourceFundID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSourceFundID(whereSql, "SourceFundID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectSourceFundRow[] GetPagingRelyOnSourceFundIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minSourceFundID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SourceFundID > " + minSourceFundID.ToString();
			}
			else
			{
				whereSql = "SourceFundID > " + minSourceFundID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSourceFundID(whereSql, "SourceFundID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectSourceFundRow[] GetPagingRelyOnSourceFundIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxSourceFundID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SourceFundID < " + maxSourceFundID.ToString();
			}
			else
			{
				whereSql = "SourceFundID < " + maxSourceFundID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSourceFundID(whereSql, "SourceFundID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectSourceFundRow[] GetPagingRelyOnSourceFundIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxSourceFundID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SourceFundID > " + maxSourceFundID.ToString();
			}
			else
			{
				whereSql = "SourceFundID > " + maxSourceFundID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSourceFundID(whereSql, "SourceFundID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectSourceFundRow[] GetPagingRelyOnSourceFundIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "SourceFundID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			CaseProjectSourceFundRow[] caseProjectSourceFundRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnSourceFundID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectSourceFundRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnSourceFundIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectSourceFundRow = MapRecords(command);
			}
			return caseProjectSourceFundRow;
		}
		public virtual CaseProjectSourceFundRow[] GetPagingRelyOnSourceFundIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "SourceFundID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			CaseProjectSourceFundRow[] caseProjectSourceFundRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnSourceFundID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectSourceFundRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnSourceFundIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectSourceFundRow = MapRecords(command);
			}
			return caseProjectSourceFundRow;
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
			"[SourceFundID],"+
			"[CaseID],"+
			"[SourceFundName],"+
			"[Amount],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseProjectSourceFund]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSourceFundID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectSourceFund]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSourceFundIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "SourceFundID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectSourceFund] where SourceFundID < (select min(minSourceFundID) from(select top " + (rowPerPage * pageNumber).ToString() + " SourceFundID as minSourceFundID from [dbo].[CaseProjectSourceFund]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseProjectSourceFund]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSourceFundIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "SourceFundID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectSourceFund] where SourceFundID > (select max(maxSourceFundID) from(select top " + (rowPerPage * pageNumber).ToString() + " SourceFundID as maxSourceFundID from [dbo].[CaseProjectSourceFund]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseProjectSourceFund]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseProjectSourceFund]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseProjectSourceFund"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("SourceFundID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SourceFundName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Amount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual CaseProjectSourceFundRow[] GetByCaseID(int caseID)
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
		public CaseProjectSourceFundRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseProjectSourceFundRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseProjectSourceFundRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseProjectSourceFundRow"/> objects.</returns>
		public virtual CaseProjectSourceFundRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseProjectSourceFund]", top);
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
		public CaseProjectSourceFundRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseProjectSourceFundRow[] rows = null;
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
		public DataTable GetCaseProjectSourceFundPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SourceFundID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "SourceFundID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(SourceFundID) AS TotalRow FROM [dbo].[CaseProjectSourceFund] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,SourceFundID,CaseID,SourceFundName,Amount,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseProjectSourceFund] " + whereSql +
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
		public CaseProjectSourceFundItemsPaging GetCaseProjectSourceFundPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SourceFundID")
		{
		CaseProjectSourceFundItemsPaging obj = new CaseProjectSourceFundItemsPaging();
		DataTable dt = GetCaseProjectSourceFundPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseProjectSourceFundItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseProjectSourceFundItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.SourceFundID = Convert.ToInt32(dt.Rows[i]["SourceFundID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.SourceFundName = dt.Rows[i]["SourceFundName"].ToString();
			if (dt.Rows[i]["Amount"] != DBNull.Value)
			record.Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseProjectSourceFundItems = (CaseProjectSourceFundItems[])(recordList.ToArray(typeof(CaseProjectSourceFundItems)));
		return obj;
		}
		public CaseProjectSourceFundRow GetByPrimaryKey(int sourceFundID)
		{
			string whereSql = "[SourceFundID]=" + CreateSqlParameterName("SourceFundID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SourceFundID", sourceFundID);
			CaseProjectSourceFundRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(CaseProjectSourceFundRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseProjectSourceFund] (" +
			"[CaseID], " + 
			"[SourceFundName], " + 
			"[Amount], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("SourceFundName") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "SourceFundName",value.SourceFundName);
			AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(CaseProjectSourceFundRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseProjectSourceFund] (" +
			"[CaseID], " + 
			"[SourceFundName], " + 
			"[Amount], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("SourceFundName") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "SourceFundName", Sanitizer.GetSafeHtmlFragment(value.SourceFundName));
			AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(CaseProjectSourceFundRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSourceFundID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetSourceFundName)
				{
					strUpdate += "[SourceFundName]=" + CreateSqlParameterName("SourceFundName") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseProjectSourceFund] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SourceFundID]=" + CreateSqlParameterName("SourceFundID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SourceFundID", value.SourceFundID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "SourceFundName",value.SourceFundName);
					AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
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
				Exception ex = new Exception("Set incorrect primarykey PK(SourceFundID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseProjectSourceFundRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSourceFundID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetSourceFundName)
				{
					strUpdate += "[SourceFundName]=" + CreateSqlParameterName("SourceFundName") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseProjectSourceFund] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SourceFundID]=" + CreateSqlParameterName("SourceFundID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SourceFundID", value.SourceFundID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "SourceFundName", Sanitizer.GetSafeHtmlFragment(value.SourceFundName));
					AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
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
				Exception ex = new Exception("Set incorrect primarykey PK(SourceFundID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int sourceFundID)
		{
			string whereSql = "[SourceFundID]=" + CreateSqlParameterName("SourceFundID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SourceFundID", sourceFundID);
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
		protected CaseProjectSourceFundRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseProjectSourceFundRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseProjectSourceFundRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int sourceFundIDColumnIndex = reader.GetOrdinal("SourceFundID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int sourceFundNameColumnIndex = reader.GetOrdinal("SourceFundName");
			int amountColumnIndex = reader.GetOrdinal("Amount");
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
					CaseProjectSourceFundRow record = new CaseProjectSourceFundRow();
					recordList.Add(record);
					record.SourceFundID =  Convert.ToInt32(reader.GetValue(sourceFundIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.SourceFundName =  Convert.ToString(reader.GetValue(sourceFundNameColumnIndex));
					if (!reader.IsDBNull(amountColumnIndex)) record.Amount =  Convert.ToDouble(reader.GetValue(amountColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseProjectSourceFundRow[])(recordList.ToArray(typeof(CaseProjectSourceFundRow)));
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
				case "SourceFundID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SourceFundName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Amount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
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

