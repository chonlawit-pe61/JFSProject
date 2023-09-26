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
	public partial class QueueVersionCollection_Base : MarshalByRefObject
	{
		public const string QueueVersionIDColumnName = "QueueVersionID";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string QueueNameColumnName = "QueueName";
		public const string QueueYearColumnName = "QueueYear";
		public const string IsActiveColumnName = "IsActive";
		public const string CreateDateColumnName = "CreateDate";
		private int _processID;
		public SqlCommand cmd = null;
		public QueueVersionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual QueueVersionRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual QueueVersionPaging GetPagingRelyOnQueueVersionIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			QueueVersionPaging queueVersionPaging = new QueueVersionPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(QueueVersionID) as TotalRow from [dbo].[QueueVersion]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			queueVersionPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			queueVersionPaging.totalPage = (int)Math.Ceiling((double) queueVersionPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnQueueVersionID(whereSql, "QueueVersionID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			queueVersionPaging.queueVersionRow = MapRecords(command);
			return queueVersionPaging;
		}
		public virtual QueueVersionPaging GetPagingRelyOnQueueVersionIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			QueueVersionPaging queueVersionPaging = new QueueVersionPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(QueueVersionID) as TotalRow from [dbo].[QueueVersion]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			queueVersionPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			queueVersionPaging.totalPage = (int)Math.Ceiling((double)queueVersionPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnQueueVersionID(whereSql, "QueueVersionID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			queueVersionPaging.queueVersionRow = MapRecords(command);
			return queueVersionPaging;
		}
		public virtual QueueVersionRow[] GetPagingRelyOnQueueVersionIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minQueueVersionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And QueueVersionID < " + minQueueVersionID.ToString();
			}
			else
			{
				whereSql = "QueueVersionID < " + minQueueVersionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnQueueVersionID(whereSql, "QueueVersionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual QueueVersionRow[] GetPagingRelyOnQueueVersionIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minQueueVersionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And QueueVersionID > " + minQueueVersionID.ToString();
			}
			else
			{
				whereSql = "QueueVersionID > " + minQueueVersionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnQueueVersionID(whereSql, "QueueVersionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual QueueVersionRow[] GetPagingRelyOnQueueVersionIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxQueueVersionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And QueueVersionID < " + maxQueueVersionID.ToString();
			}
			else
			{
				whereSql = "QueueVersionID < " + maxQueueVersionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnQueueVersionID(whereSql, "QueueVersionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual QueueVersionRow[] GetPagingRelyOnQueueVersionIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxQueueVersionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And QueueVersionID > " + maxQueueVersionID.ToString();
			}
			else
			{
				whereSql = "QueueVersionID > " + maxQueueVersionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnQueueVersionID(whereSql, "QueueVersionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual QueueVersionRow[] GetPagingRelyOnQueueVersionIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "QueueVersionID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			QueueVersionRow[] queueVersionRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnQueueVersionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				queueVersionRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnQueueVersionIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				queueVersionRow = MapRecords(command);
			}
			return queueVersionRow;
		}
		public virtual QueueVersionRow[] GetPagingRelyOnQueueVersionIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "QueueVersionID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			QueueVersionRow[] queueVersionRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnQueueVersionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				queueVersionRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnQueueVersionIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				queueVersionRow = MapRecords(command);
			}
			return queueVersionRow;
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
			"[QueueVersionID],"+
			"[ProvinceID],"+
			"[QueueName],"+
			"[QueueYear],"+
			"[IsActive],"+
			"[CreateDate]"+
			" FROM [dbo].[QueueVersion]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnQueueVersionID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[QueueVersion]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnQueueVersionIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "QueueVersionID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[QueueVersion] where QueueVersionID < (select min(minQueueVersionID) from(select top " + (rowPerPage * pageNumber).ToString() + " QueueVersionID as minQueueVersionID from [dbo].[QueueVersion]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[QueueVersion]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnQueueVersionIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "QueueVersionID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[QueueVersion] where QueueVersionID > (select max(maxQueueVersionID) from(select top " + (rowPerPage * pageNumber).ToString() + " QueueVersionID as maxQueueVersionID from [dbo].[QueueVersion]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[QueueVersion]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[QueueVersion]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "QueueVersion"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("QueueVersionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("QueueName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("QueueYear",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual QueueVersionRow[] GetByProvinceID(int provinceID)
		{
			return MapRecords(CreateGetByProvinceIDCommand(provinceID));
		}
		public virtual DataTable GetByProvinceIDAsDataTable(int provinceID)
		{
			return MapRecordsToDataTable(CreateGetByProvinceIDCommand(provinceID));
		}
		protected virtual IDbCommand CreateGetByProvinceIDCommand(int provinceID)
		{
			string whereSql = "";
			whereSql += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProvinceID", provinceID);
			return cmd;
		}
		public QueueVersionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual QueueVersionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="QueueVersionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="QueueVersionRow"/> objects.</returns>
		public virtual QueueVersionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[QueueVersion]", top);
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
		public QueueVersionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			QueueVersionRow[] rows = null;
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
		public DataTable GetQueueVersionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "QueueVersionID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "QueueVersionID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(QueueVersionID) AS TotalRow FROM [dbo].[QueueVersion] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,QueueVersionID,ProvinceID,QueueName,QueueYear,IsActive,CreateDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [QueueVersion].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[QueueVersion] " + whereSql +
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
		public QueueVersionItemsPaging GetQueueVersionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "QueueVersionID")
		{
		QueueVersionItemsPaging obj = new QueueVersionItemsPaging();
		DataTable dt = GetQueueVersionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		QueueVersionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new QueueVersionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.QueueVersionID = Convert.ToInt32(dt.Rows[i]["QueueVersionID"]);
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.QueueName = dt.Rows[i]["QueueName"].ToString();
			record.QueueYear = Convert.ToInt32(dt.Rows[i]["QueueYear"]);
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			recordList.Add(record);
		}
		obj.queueVersionItems = (QueueVersionItems[])(recordList.ToArray(typeof(QueueVersionItems)));
		return obj;
		}
		public QueueVersionRow GetByPrimaryKey(int queueVersionID)
		{
			string whereSql = "[QueueVersionID]=" + CreateSqlParameterName("QueueVersionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "QueueVersionID", queueVersionID);
			QueueVersionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(QueueVersionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[QueueVersion] (" +
			"[ProvinceID], " + 
			"[QueueName], " + 
			"[QueueYear], " + 
			"[IsActive], " + 
			"[CreateDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("QueueName") + ", " +
			CreateSqlParameterName("QueueYear") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("CreateDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "QueueName", value.QueueName);
			AddParameter(cmd, "QueueYear", value.QueueYear);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(QueueVersionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[QueueVersion] (" +
			"[ProvinceID], " + 
			"[QueueName], " + 
			"[QueueYear], " + 
			"[IsActive], " + 
			"[CreateDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("QueueName") + ", " +
			CreateSqlParameterName("QueueYear") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("CreateDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "QueueName", Sanitizer.GetSafeHtmlFragment(value.QueueName));
			AddParameter(cmd, "QueueYear", value.QueueYear);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(QueueVersionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetQueueVersionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetQueueName)
				{
					strUpdate += "[QueueName]=" + CreateSqlParameterName("QueueName") + ",";
				}
				if (value._IsSetQueueYear)
				{
					strUpdate += "[QueueYear]=" + CreateSqlParameterName("QueueYear") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[QueueVersion] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[QueueVersionID]=" + CreateSqlParameterName("QueueVersionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "QueueVersionID", value.QueueVersionID);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "QueueName", value.QueueName);
					AddParameter(cmd, "QueueYear", value.QueueYear);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(QueueVersionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(QueueVersionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetQueueVersionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetQueueName)
				{
					strUpdate += "[QueueName]=" + CreateSqlParameterName("QueueName") + ",";
				}
				if (value._IsSetQueueYear)
				{
					strUpdate += "[QueueYear]=" + CreateSqlParameterName("QueueYear") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[QueueVersion] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[QueueVersionID]=" + CreateSqlParameterName("QueueVersionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "QueueVersionID", value.QueueVersionID);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "QueueName", Sanitizer.GetSafeHtmlFragment(value.QueueName));
					AddParameter(cmd, "QueueYear", value.QueueYear);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(QueueVersionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int queueVersionID)
		{
			string whereSql = "[QueueVersionID]=" + CreateSqlParameterName("QueueVersionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "QueueVersionID", queueVersionID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public QueueVersionRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			QueueVersionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByProvinceID(int provinceID)
		{
			return CreateDeleteByProvinceIDCommand(provinceID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByProvinceIDCommand(int provinceID)
		{
			string whereSql = "";
			whereSql += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProvinceID", provinceID);
			return cmd;
		}
		protected QueueVersionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected QueueVersionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected QueueVersionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int queueVersionIDColumnIndex = reader.GetOrdinal("QueueVersionID");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int queueNameColumnIndex = reader.GetOrdinal("QueueName");
			int queueYearColumnIndex = reader.GetOrdinal("QueueYear");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					QueueVersionRow record = new QueueVersionRow();
					recordList.Add(record);
					record.QueueVersionID =  Convert.ToInt32(reader.GetValue(queueVersionIDColumnIndex));
					record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));
					if (!reader.IsDBNull(queueNameColumnIndex)) record.QueueName =  Convert.ToString(reader.GetValue(queueNameColumnIndex));

					record.QueueYear =  Convert.ToInt32(reader.GetValue(queueYearColumnIndex));
					record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
					record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (QueueVersionRow[])(recordList.ToArray(typeof(QueueVersionRow)));
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
				case "QueueVersionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "QueueName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "QueueYear":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "CreateDate":
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

