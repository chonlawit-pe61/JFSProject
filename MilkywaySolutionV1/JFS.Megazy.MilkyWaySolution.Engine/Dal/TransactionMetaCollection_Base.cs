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
	public partial class TransactionMetaCollection_Base : MarshalByRefObject
	{
		public const string MetaIDColumnName = "MetaID";
		public const string TransactionIDColumnName = "TransactionID";
		public const string MetaKeyColumnName = "MetaKey";
		public const string MetaValueColumnName = "MetaValue";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public TransactionMetaCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual TransactionMetaRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual TransactionMetaPaging GetPagingRelyOnMetaIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TransactionMetaPaging transactionMetaPaging = new TransactionMetaPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(MetaID) as TotalRow from [dbo].[TransactionMeta]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			transactionMetaPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			transactionMetaPaging.totalPage = (int)Math.Ceiling((double) transactionMetaPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			transactionMetaPaging.transactionMetaRow = MapRecords(command);
			return transactionMetaPaging;
		}
		public virtual TransactionMetaPaging GetPagingRelyOnMetaIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			TransactionMetaPaging transactionMetaPaging = new TransactionMetaPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(MetaID) as TotalRow from [dbo].[TransactionMeta]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			transactionMetaPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			transactionMetaPaging.totalPage = (int)Math.Ceiling((double)transactionMetaPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			transactionMetaPaging.transactionMetaRow = MapRecords(command);
			return transactionMetaPaging;
		}
		public virtual TransactionMetaRow[] GetPagingRelyOnMetaIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minMetaID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MetaID < " + minMetaID.ToString();
			}
			else
			{
				whereSql = "MetaID < " + minMetaID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionMetaRow[] GetPagingRelyOnMetaIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minMetaID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MetaID > " + minMetaID.ToString();
			}
			else
			{
				whereSql = "MetaID > " + minMetaID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionMetaRow[] GetPagingRelyOnMetaIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxMetaID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MetaID < " + maxMetaID.ToString();
			}
			else
			{
				whereSql = "MetaID < " + maxMetaID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionMetaRow[] GetPagingRelyOnMetaIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxMetaID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MetaID > " + maxMetaID.ToString();
			}
			else
			{
				whereSql = "MetaID > " + maxMetaID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual TransactionMetaRow[] GetPagingRelyOnMetaIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "MetaID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			TransactionMetaRow[] transactionMetaRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionMetaRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnMetaIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionMetaRow = MapRecords(command);
			}
			return transactionMetaRow;
		}
		public virtual TransactionMetaRow[] GetPagingRelyOnMetaIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "MetaID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			TransactionMetaRow[] transactionMetaRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionMetaRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnMetaIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				transactionMetaRow = MapRecords(command);
			}
			return transactionMetaRow;
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
			"[MetaID],"+
			"[TransactionID],"+
			"[MetaKey],"+
			"[MetaValue],"+
			"[ModifiedDate]"+
			" FROM [dbo].[TransactionMeta]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMetaID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionMeta]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMetaIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "MetaID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionMeta] where MetaID < (select min(minMetaID) from(select top " + (rowPerPage * pageNumber).ToString() + " MetaID as minMetaID from [dbo].[TransactionMeta]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[TransactionMeta]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMetaIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "MetaID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[TransactionMeta] where MetaID > (select max(maxMetaID) from(select top " + (rowPerPage * pageNumber).ToString() + " MetaID as maxMetaID from [dbo].[TransactionMeta]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[TransactionMeta]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[TransactionMeta]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "TransactionMeta"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("MetaID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MetaKey",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("MetaValue",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual TransactionMetaRow[] GetByTransactionID(int transactionID)
		{
			return MapRecords(CreateGetByTransactionIDCommand(transactionID));
		}
		public virtual DataTable GetByTransactionIDAsDataTable(int transactionID)
		{
			return MapRecordsToDataTable(CreateGetByTransactionIDCommand(transactionID));
		}
		protected virtual IDbCommand CreateGetByTransactionIDCommand(int transactionID)
		{
			string whereSql = "";
			whereSql += "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionID", transactionID);
			return cmd;
		}
		public TransactionMetaRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual TransactionMetaRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="TransactionMetaRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TransactionMetaRow"/> objects.</returns>
		public virtual TransactionMetaRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[TransactionMeta]", top);
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
		public TransactionMetaRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			TransactionMetaRow[] rows = null;
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
		public DataTable GetTransactionMetaPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MetaID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "MetaID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[TransactionMeta] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MetaID,TransactionID,MetaKey,MetaValue,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [TransactionMeta].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[TransactionMeta] " + whereSql +
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
		public TransactionMetaItemsPaging GetTransactionMetaPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MetaID")
		{
		TransactionMetaItemsPaging obj = new TransactionMetaItemsPaging();
		DataTable dt = GetTransactionMetaPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		TransactionMetaItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new TransactionMetaItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.MetaID = Convert.ToInt32(dt.Rows[i]["MetaID"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.MetaKey = dt.Rows[i]["MetaKey"].ToString();
			record.MetaValue = dt.Rows[i]["MetaValue"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.transactionMetaItems = (TransactionMetaItems[])(recordList.ToArray(typeof(TransactionMetaItems)));
		return obj;
		}
		public TransactionMetaRow GetByPrimaryKey(int metaID)
		{
			string whereSql = "[MetaID]=" + CreateSqlParameterName("MetaID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MetaID", metaID);
			TransactionMetaRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(TransactionMetaRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TransactionMeta] (" +
			"[TransactionID], " + 
			"[MetaKey], " + 
			"[MetaValue], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("MetaKey") + ", " +
			CreateSqlParameterName("MetaValue") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "MetaKey", value.MetaKey);
			AddParameter(cmd, "MetaValue", value.MetaValue);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(TransactionMetaRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TransactionMeta] (" +
			"[TransactionID], " + 
			"[MetaKey], " + 
			"[MetaValue], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("MetaKey") + ", " +
			CreateSqlParameterName("MetaValue") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "MetaKey", Sanitizer.GetSafeHtmlFragment(value.MetaKey));
			AddParameter(cmd, "MetaValue", Sanitizer.GetSafeHtmlFragment(value.MetaValue));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(TransactionMetaRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMetaID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionID)
				{
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID") + ",";
				}
				if (value._IsSetMetaKey)
				{
					strUpdate += "[MetaKey]=" + CreateSqlParameterName("MetaKey") + ",";
				}
				if (value._IsSetMetaValue)
				{
					strUpdate += "[MetaValue]=" + CreateSqlParameterName("MetaValue") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TransactionMeta] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MetaID]=" + CreateSqlParameterName("MetaID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MetaID", value.MetaID);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "MetaKey", value.MetaKey);
					AddParameter(cmd, "MetaValue", value.MetaValue);
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
				Exception ex = new Exception("Set incorrect primarykey PK(MetaID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(TransactionMetaRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMetaID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTransactionID)
				{
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID") + ",";
				}
				if (value._IsSetMetaKey)
				{
					strUpdate += "[MetaKey]=" + CreateSqlParameterName("MetaKey") + ",";
				}
				if (value._IsSetMetaValue)
				{
					strUpdate += "[MetaValue]=" + CreateSqlParameterName("MetaValue") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TransactionMeta] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MetaID]=" + CreateSqlParameterName("MetaID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MetaID", value.MetaID);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "MetaKey", Sanitizer.GetSafeHtmlFragment(value.MetaKey));
					AddParameter(cmd, "MetaValue", Sanitizer.GetSafeHtmlFragment(value.MetaValue));
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
				Exception ex = new Exception("Set incorrect primarykey PK(MetaID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int metaID)
		{
			string whereSql = "[MetaID]=" + CreateSqlParameterName("MetaID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MetaID", metaID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByTransactionID(int transactionID)
		{
			return CreateDeleteByTransactionIDCommand(transactionID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTransactionIDCommand(int transactionID)
		{
			string whereSql = "";
			whereSql += "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionID", transactionID);
			return cmd;
		}
		protected TransactionMetaRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected TransactionMetaRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected TransactionMetaRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int metaIDColumnIndex = reader.GetOrdinal("MetaID");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int metaKeyColumnIndex = reader.GetOrdinal("MetaKey");
			int metaValueColumnIndex = reader.GetOrdinal("MetaValue");
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
					TransactionMetaRow record = new TransactionMetaRow();
					recordList.Add(record);
					record.MetaID =  Convert.ToInt32(reader.GetValue(metaIDColumnIndex));
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(metaKeyColumnIndex)) record.MetaKey =  Convert.ToString(reader.GetValue(metaKeyColumnIndex));

					if (!reader.IsDBNull(metaValueColumnIndex)) record.MetaValue =  Convert.ToString(reader.GetValue(metaValueColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TransactionMetaRow[])(recordList.ToArray(typeof(TransactionMetaRow)));
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
				case "MetaID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MetaKey":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "MetaValue":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

