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
	public partial class FAQCollection_Base : MarshalByRefObject
	{
		public const string FaqIDColumnName = "FaqID";
		public const string TitleColumnName = "Title";
		public const string DescriptionColumnName = "Description";
		public const string SeqColumnName = "Seq";
		public const string CreateDateColumnName = "CreateDate";
		private int _processID;
		public SqlCommand cmd = null;
		public FAQCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual FAQRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual FAQPaging GetPagingRelyOnFaqIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			FAQPaging fAQPaging = new FAQPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(FaqID) as TotalRow from [dbo].[FAQ]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			fAQPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			fAQPaging.totalPage = (int)Math.Ceiling((double) fAQPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnFaqID(whereSql, "FaqID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			fAQPaging.fAQRow = MapRecords(command);
			return fAQPaging;
		}
		public virtual FAQPaging GetPagingRelyOnFaqIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			FAQPaging fAQPaging = new FAQPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(FaqID) as TotalRow from [dbo].[FAQ]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			fAQPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			fAQPaging.totalPage = (int)Math.Ceiling((double)fAQPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnFaqID(whereSql, "FaqID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			fAQPaging.fAQRow = MapRecords(command);
			return fAQPaging;
		}
		public virtual FAQRow[] GetPagingRelyOnFaqIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minFaqID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FaqID < " + minFaqID.ToString();
			}
			else
			{
				whereSql = "FaqID < " + minFaqID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFaqID(whereSql, "FaqID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual FAQRow[] GetPagingRelyOnFaqIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minFaqID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FaqID > " + minFaqID.ToString();
			}
			else
			{
				whereSql = "FaqID > " + minFaqID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFaqID(whereSql, "FaqID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual FAQRow[] GetPagingRelyOnFaqIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxFaqID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FaqID < " + maxFaqID.ToString();
			}
			else
			{
				whereSql = "FaqID < " + maxFaqID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFaqID(whereSql, "FaqID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual FAQRow[] GetPagingRelyOnFaqIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxFaqID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And FaqID > " + maxFaqID.ToString();
			}
			else
			{
				whereSql = "FaqID > " + maxFaqID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnFaqID(whereSql, "FaqID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual FAQRow[] GetPagingRelyOnFaqIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "FaqID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			FAQRow[] fAQRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnFaqID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				fAQRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnFaqIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				fAQRow = MapRecords(command);
			}
			return fAQRow;
		}
		public virtual FAQRow[] GetPagingRelyOnFaqIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "FaqID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			FAQRow[] fAQRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnFaqID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				fAQRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnFaqIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				fAQRow = MapRecords(command);
			}
			return fAQRow;
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
			"[FaqID],"+
			"[Title],"+
			"[Description],"+
			"[Seq],"+
			"[CreateDate]"+
			" FROM [dbo].[FAQ]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFaqID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[FAQ]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFaqIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "FaqID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[FAQ] where FaqID < (select min(minFaqID) from(select top " + (rowPerPage * pageNumber).ToString() + " FaqID as minFaqID from [dbo].[FAQ]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[FAQ]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnFaqIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "FaqID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[FAQ] where FaqID > (select max(maxFaqID) from(select top " + (rowPerPage * pageNumber).ToString() + " FaqID as maxFaqID from [dbo].[FAQ]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[FAQ]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[FAQ]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "FAQ"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FaqID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Description",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Seq",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public FAQRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual FAQRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="FAQRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FAQRow"/> objects.</returns>
		public virtual FAQRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[FAQ]", top);
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
		public FAQRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			FAQRow[] rows = null;
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
		public DataTable GetFAQPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FaqID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "FaqID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(FaqID) AS TotalRow FROM [dbo].[FAQ] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,FaqID,Title,Description,Seq,CreateDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[FAQ] " + whereSql +
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
		public FAQItemsPaging GetFAQPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FaqID")
		{
		FAQItemsPaging obj = new FAQItemsPaging();
		DataTable dt = GetFAQPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		FAQItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new FAQItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.FaqID = Convert.ToInt32(dt.Rows[i]["FaqID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.Description = dt.Rows[i]["Description"].ToString();
			record.Seq = Convert.ToInt32(dt.Rows[i]["Seq"]);
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			recordList.Add(record);
		}
		obj.fAQItems = (FAQItems[])(recordList.ToArray(typeof(FAQItems)));
		return obj;
		}
		public FAQRow GetByPrimaryKey(int faqID)
		{
			string whereSql = "[FaqID]=" + CreateSqlParameterName("FaqID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FaqID", faqID);
			FAQRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(FAQRow value)		{
			string sqlStr = "INSERT INTO [dbo].[FAQ] (" +
			"[Title], " + 
			"[Description], " + 
			"[Seq], " + 
			"[CreateDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("Description") + ", " +
			CreateSqlParameterName("Seq") + ", " +
			CreateSqlParameterName("CreateDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Title",value.Title);
			AddParameter(cmd, "Description",value.Description);
			AddParameter(cmd, "Seq", value.Seq);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(FAQRow value)		{
			string sqlStr = "INSERT INTO [dbo].[FAQ] (" +
			"[Title], " + 
			"[Description], " + 
			"[Seq], " + 
			"[CreateDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("Description") + ", " +
			CreateSqlParameterName("Seq") + ", " +
			CreateSqlParameterName("CreateDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "Description", Sanitizer.GetSafeHtmlFragment(value.Description));
			AddParameter(cmd, "Seq", value.Seq);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.CreateDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(FAQRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFaqID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetDescription)
				{
					strUpdate += "[Description]=" + CreateSqlParameterName("Description") + ",";
				}
				if (value._IsSetSeq)
				{
					strUpdate += "[Seq]=" + CreateSqlParameterName("Seq") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[FAQ] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FaqID]=" + CreateSqlParameterName("FaqID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FaqID", value.FaqID);
					AddParameter(cmd, "Title",value.Title);
					AddParameter(cmd, "Description",value.Description);
					AddParameter(cmd, "Seq", value.Seq);
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
				Exception ex = new Exception("Set incorrect primarykey PK(FaqID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(FAQRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFaqID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetDescription)
				{
					strUpdate += "[Description]=" + CreateSqlParameterName("Description") + ",";
				}
				if (value._IsSetSeq)
				{
					strUpdate += "[Seq]=" + CreateSqlParameterName("Seq") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[FAQ] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FaqID]=" + CreateSqlParameterName("FaqID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FaqID", value.FaqID);
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "Description", Sanitizer.GetSafeHtmlFragment(value.Description));
					AddParameter(cmd, "Seq", value.Seq);
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
				Exception ex = new Exception("Set incorrect primarykey PK(FaqID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int faqID)
		{
			string whereSql = "[FaqID]=" + CreateSqlParameterName("FaqID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FaqID", faqID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected FAQRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected FAQRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected FAQRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int faqIDColumnIndex = reader.GetOrdinal("FaqID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int descriptionColumnIndex = reader.GetOrdinal("Description");
			int seqColumnIndex = reader.GetOrdinal("Seq");
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
					FAQRow record = new FAQRow();
					recordList.Add(record);
					record.FaqID =  Convert.ToInt32(reader.GetValue(faqIDColumnIndex));
					record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));
					record.Description =  Convert.ToString(reader.GetValue(descriptionColumnIndex));
					record.Seq =  Convert.ToInt32(reader.GetValue(seqColumnIndex));
					record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FAQRow[])(recordList.ToArray(typeof(FAQRow)));
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
				case "FaqID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Description":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Seq":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

