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
	public partial class FormMapAttributeCollection_Base : MarshalByRefObject
	{
		public const string FormMapAttrIDColumnName = "FormMapAttrID";
		public const string FormIDColumnName = "FormID";
		public const string FormAttrIDColumnName = "FormAttrID";
		public const string SortIDColumnName = "SortID";
		public const string ColumnsColumnName = "Columns";
		private int _processID;
		public SqlCommand cmd = null;
		public FormMapAttributeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual FormMapAttributeRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual FormMapAttributePaging GetPagingRelyOnFormMapAttrIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			FormMapAttributePaging formMapAttributePaging = new FormMapAttributePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(FormMapAttrID) as TotalRow from [dbo].[FormMapAttribute]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			formMapAttributePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			formMapAttributePaging.totalPage = (int)Math.Ceiling((double) formMapAttributePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnFormMapAttrID(whereSql, "FormMapAttrID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			formMapAttributePaging.formMapAttributeRow = MapRecords(command);
			return formMapAttributePaging;
		}
		public virtual FormMapAttributePaging GetPagingRelyOnFormMapAttrIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			FormMapAttributePaging formMapAttributePaging = new FormMapAttributePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(FormMapAttrID) as TotalRow from [dbo].[FormMapAttribute]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			formMapAttributePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			formMapAttributePaging.totalPage = (int)Math.Ceiling((double)formMapAttributePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnFormMapAttrID(whereSql, "FormMapAttrID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			formMapAttributePaging.formMapAttributeRow = MapRecords(command);
			return formMapAttributePaging;
		}
		public virtual FormMapAttributeRow[] GetPagingRelyOnFormMapAttrIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minFormMapAttrID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FormMapAttrID < " + minFormMapAttrID.ToString();
			}
			else
			{
				whereSql = "FormMapAttrID < " + minFormMapAttrID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFormMapAttrID(whereSql, "FormMapAttrID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual FormMapAttributeRow[] GetPagingRelyOnFormMapAttrIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minFormMapAttrID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FormMapAttrID > " + minFormMapAttrID.ToString();
			}
			else
			{
				whereSql = "FormMapAttrID > " + minFormMapAttrID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFormMapAttrID(whereSql, "FormMapAttrID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual FormMapAttributeRow[] GetPagingRelyOnFormMapAttrIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxFormMapAttrID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FormMapAttrID < " + maxFormMapAttrID.ToString();
			}
			else
			{
				whereSql = "FormMapAttrID < " + maxFormMapAttrID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFormMapAttrID(whereSql, "FormMapAttrID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual FormMapAttributeRow[] GetPagingRelyOnFormMapAttrIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxFormMapAttrID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FormMapAttrID > " + maxFormMapAttrID.ToString();
			}
			else
			{
				whereSql = "FormMapAttrID > " + maxFormMapAttrID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFormMapAttrID(whereSql, "FormMapAttrID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual FormMapAttributeRow[] GetPagingRelyOnFormMapAttrIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "FormMapAttrID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			FormMapAttributeRow[] formMapAttributeRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnFormMapAttrID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				formMapAttributeRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnFormMapAttrIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				formMapAttributeRow = MapRecords(command);
			}
			return formMapAttributeRow;
		}
		public virtual FormMapAttributeRow[] GetPagingRelyOnFormMapAttrIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "FormMapAttrID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			FormMapAttributeRow[] formMapAttributeRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnFormMapAttrID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				formMapAttributeRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnFormMapAttrIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				formMapAttributeRow = MapRecords(command);
			}
			return formMapAttributeRow;
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
			"[FormMapAttrID],"+
			"[FormID],"+
			"[FormAttrID],"+
			"[SortID],"+
			"[Columns]"+
			" FROM [dbo].[FormMapAttribute]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFormMapAttrID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[FormMapAttribute]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFormMapAttrIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "FormMapAttrID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[FormMapAttribute] where FormMapAttrID < (select min(minFormMapAttrID) from(select top " + (rowPerPage * pageNumber).ToString() + " FormMapAttrID as minFormMapAttrID from [dbo].[FormMapAttribute]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[FormMapAttribute]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFormMapAttrIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "FormMapAttrID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[FormMapAttribute] where FormMapAttrID > (select max(maxFormMapAttrID) from(select top " + (rowPerPage * pageNumber).ToString() + " FormMapAttrID as maxFormMapAttrID from [dbo].[FormMapAttribute]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[FormMapAttribute]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[FormMapAttribute]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "FormMapAttribute"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FormMapAttrID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FormAttrID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SortID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Columns",Type.GetType("System.Int32"));
			return dataTable;
		}
		public virtual FormMapAttributeRow[] GetByFormID(int formID)
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
		public virtual FormMapAttributeRow[] GetByFormAttrID(int formAttrID)
		{
			return MapRecords(CreateGetByFormAttrIDCommand(formAttrID));
		}
		public virtual DataTable GetByFormAttrIDAsDataTable(int formAttrID)
		{
			return MapRecordsToDataTable(CreateGetByFormAttrIDCommand(formAttrID));
		}
		protected virtual IDbCommand CreateGetByFormAttrIDCommand(int formAttrID)
		{
			string whereSql = "";
			whereSql += "[FormAttrID]=" + CreateSqlParameterName("FormAttrID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FormAttrID", formAttrID);
			return cmd;
		}
		public FormMapAttributeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual FormMapAttributeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="FormMapAttributeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FormMapAttributeRow"/> objects.</returns>
		public virtual FormMapAttributeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[FormMapAttribute]", top);
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
		public FormMapAttributeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			FormMapAttributeRow[] rows = null;
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
		public DataTable GetFormMapAttributePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FormMapAttrID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "FormMapAttrID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(FormMapAttrID) AS TotalRow FROM [dbo].[FormMapAttribute] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,FormMapAttrID,FormID,FormAttrID,SortID,Columns," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[FormMapAttribute] " + whereSql +
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
		public FormMapAttributeItemsPaging GetFormMapAttributePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FormMapAttrID")
		{
		FormMapAttributeItemsPaging obj = new FormMapAttributeItemsPaging();
		DataTable dt = GetFormMapAttributePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		FormMapAttributeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new FormMapAttributeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.FormMapAttrID = Convert.ToInt32(dt.Rows[i]["FormMapAttrID"]);
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			record.FormAttrID = Convert.ToInt32(dt.Rows[i]["FormAttrID"]);
			if (dt.Rows[i]["SortID"] != DBNull.Value)
			record.SortID = Convert.ToInt32(dt.Rows[i]["SortID"]);
			if (dt.Rows[i]["Columns"] != DBNull.Value)
			record.Columns = Convert.ToInt32(dt.Rows[i]["Columns"]);
			recordList.Add(record);
		}
		obj.formMapAttributeItems = (FormMapAttributeItems[])(recordList.ToArray(typeof(FormMapAttributeItems)));
		return obj;
		}
		public FormMapAttributeRow GetByPrimaryKey(int formMapAttrID)
		{
			string whereSql = "[FormMapAttrID]=" + CreateSqlParameterName("FormMapAttrID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FormMapAttrID", formMapAttrID);
			FormMapAttributeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(FormMapAttributeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[FormMapAttribute] (" +
			"[FormID], " + 
			"[FormAttrID], " + 
			"[SortID], " + 
			"[Columns]			" + 
			") VALUES (" +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("FormAttrID") + ", " +
			CreateSqlParameterName("SortID") + ", " +
			CreateSqlParameterName("Columns") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "FormID", value.FormID);
			AddParameter(cmd, "FormAttrID", value.FormAttrID);
			AddParameter(cmd, "SortID", value.IsSortIDNull ? DBNull.Value : (object)value.SortID);
			AddParameter(cmd, "Columns", value.IsColumnsNull ? DBNull.Value : (object)value.Columns);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(FormMapAttributeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[FormMapAttribute] (" +
			"[FormID], " + 
			"[FormAttrID], " + 
			"[SortID], " + 
			"[Columns]			" + 
			") VALUES (" +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("FormAttrID") + ", " +
			CreateSqlParameterName("SortID") + ", " +
			CreateSqlParameterName("Columns") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "FormID", value.FormID);
			AddParameter(cmd, "FormAttrID", value.FormAttrID);
			AddParameter(cmd, "SortID", value.IsSortIDNull ? DBNull.Value : (object)value.SortID);
			AddParameter(cmd, "Columns", value.IsColumnsNull ? DBNull.Value : (object)value.Columns);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(FormMapAttributeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFormMapAttrID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetFormID)
				{
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID") + ",";
				}
				if (value._IsSetFormAttrID)
				{
					strUpdate += "[FormAttrID]=" + CreateSqlParameterName("FormAttrID") + ",";
				}
				if (value._IsSetSortID)
				{
					strUpdate += "[SortID]=" + CreateSqlParameterName("SortID") + ",";
				}
				if (value._IsSetColumns)
				{
					strUpdate += "[Columns]=" + CreateSqlParameterName("Columns") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[FormMapAttribute] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FormMapAttrID]=" + CreateSqlParameterName("FormMapAttrID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FormMapAttrID", value.FormMapAttrID);
					AddParameter(cmd, "FormID", value.FormID);
					AddParameter(cmd, "FormAttrID", value.FormAttrID);
					AddParameter(cmd, "SortID", value.IsSortIDNull ? DBNull.Value : (object)value.SortID);
					AddParameter(cmd, "Columns", value.IsColumnsNull ? DBNull.Value : (object)value.Columns);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(FormMapAttrID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(FormMapAttributeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFormMapAttrID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetFormID)
				{
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID") + ",";
				}
				if (value._IsSetFormAttrID)
				{
					strUpdate += "[FormAttrID]=" + CreateSqlParameterName("FormAttrID") + ",";
				}
				if (value._IsSetSortID)
				{
					strUpdate += "[SortID]=" + CreateSqlParameterName("SortID") + ",";
				}
				if (value._IsSetColumns)
				{
					strUpdate += "[Columns]=" + CreateSqlParameterName("Columns") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[FormMapAttribute] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FormMapAttrID]=" + CreateSqlParameterName("FormMapAttrID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FormMapAttrID", value.FormMapAttrID);
					AddParameter(cmd, "FormID", value.FormID);
					AddParameter(cmd, "FormAttrID", value.FormAttrID);
					AddParameter(cmd, "SortID", value.IsSortIDNull ? DBNull.Value : (object)value.SortID);
					AddParameter(cmd, "Columns", value.IsColumnsNull ? DBNull.Value : (object)value.Columns);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(FormMapAttrID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int formMapAttrID)
		{
			string whereSql = "[FormMapAttrID]=" + CreateSqlParameterName("FormMapAttrID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FormMapAttrID", formMapAttrID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByFormID(int formID)
		{
			return CreateDeleteByFormIDCommand(formID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFormIDCommand(int formID)
		{
			string whereSql = "";
			whereSql += "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FormID", formID);
			return cmd;
		}
		public int DeleteByFormAttrID(int formAttrID)
		{
			return CreateDeleteByFormAttrIDCommand(formAttrID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFormAttrIDCommand(int formAttrID)
		{
			string whereSql = "";
			whereSql += "[FormAttrID]=" + CreateSqlParameterName("FormAttrID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FormAttrID", formAttrID);
			return cmd;
		}
		protected FormMapAttributeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected FormMapAttributeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected FormMapAttributeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int formMapAttrIDColumnIndex = reader.GetOrdinal("FormMapAttrID");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int formAttrIDColumnIndex = reader.GetOrdinal("FormAttrID");
			int sortIDColumnIndex = reader.GetOrdinal("SortID");
			int columnsColumnIndex = reader.GetOrdinal("Columns");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					FormMapAttributeRow record = new FormMapAttributeRow();
					recordList.Add(record);
					record.FormMapAttrID =  Convert.ToInt32(reader.GetValue(formMapAttrIDColumnIndex));
					record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));
					record.FormAttrID =  Convert.ToInt32(reader.GetValue(formAttrIDColumnIndex));
					if (!reader.IsDBNull(sortIDColumnIndex)) record.SortID =  Convert.ToInt32(reader.GetValue(sortIDColumnIndex));

					if (!reader.IsDBNull(columnsColumnIndex)) record.Columns =  Convert.ToInt32(reader.GetValue(columnsColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FormMapAttributeRow[])(recordList.ToArray(typeof(FormMapAttributeRow)));
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
				case "FormMapAttrID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormAttrID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SortID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Columns":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

