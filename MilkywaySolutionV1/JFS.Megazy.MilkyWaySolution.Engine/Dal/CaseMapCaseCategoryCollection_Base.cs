using System.ServiceModel;
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
	public partial class CaseMapCaseCategoryCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string CaseCategoryIDColumnName = "CaseCategoryID";
		public const string CaseSubCategoryIDColumnName = "CaseSubCategoryID";
		public const string OtherCategoryColumnName = "OtherCategory";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseMapCaseCategoryCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseMapCaseCategoryRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
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
			"[CaseID],"+
			"[CaseCategoryID],"+
			"[CaseSubCategoryID],"+
			"[OtherCategory],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseMapCaseCategory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseMapCaseCategory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseMapCaseCategory"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseCategoryID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseSubCategoryID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("OtherCategory",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseMapCaseCategoryRow[] GetByCaseID(int caseID)
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
		public virtual CaseMapCaseCategoryRow[] GetByCaseCategoryID(int casecategoryID)
		{
			return MapRecords(CreateGetByCaseCategoryIDCommand(casecategoryID));
		}
		public virtual DataTable GetByCaseCategoryIDAsDataTable(int casecategoryID)
		{
			return MapRecordsToDataTable(CreateGetByCaseCategoryIDCommand(casecategoryID));
		}
		protected virtual IDbCommand CreateGetByCaseCategoryIDCommand(int casecategoryID)
		{
			string whereSql = "";
			whereSql += "[CaseCategoryID]=" + CreateSqlParameterName("CaseCategoryID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseCategoryID", casecategoryID);
			return cmd;
		}
		public virtual CaseMapCaseCategoryRow[] GetByCaseSubCategoryID(int caseSubcategoryID)
		{
			return MapRecords(CreateGetByCaseSubCategoryIDCommand(caseSubcategoryID));
		}
		public virtual DataTable GetByCaseSubCategoryIDAsDataTable(int caseSubcategoryID)
		{
			return MapRecordsToDataTable(CreateGetByCaseSubCategoryIDCommand(caseSubcategoryID));
		}
		protected virtual IDbCommand CreateGetByCaseSubCategoryIDCommand(int caseSubcategoryID)
		{
			string whereSql = "";
			whereSql += "[CaseSubCategoryID]=" + CreateSqlParameterName("CaseSubCategoryID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseSubCategoryID", caseSubcategoryID);
			return cmd;
		}
		public CaseMapCaseCategoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseMapCaseCategoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseMapCaseCategoryRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseMapCaseCategoryRow"/> objects.</returns>
		public virtual CaseMapCaseCategoryRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseMapCaseCategory]", top);
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
		public CaseMapCaseCategoryRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseMapCaseCategoryRow[] rows = null;
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
		public DataTable GetCaseMapCaseCategoryPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[CaseMapCaseCategory] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,CaseCategoryID,CaseSubCategoryID,OtherCategory,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseMapCaseCategory] " + whereSql +
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
		public CaseMapCaseCategoryItemsPaging GetCaseMapCaseCategoryPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseMapCaseCategoryItemsPaging obj = new CaseMapCaseCategoryItemsPaging();
		DataTable dt = GetCaseMapCaseCategoryPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseMapCaseCategoryItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseMapCaseCategoryItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.CaseCategoryID = Convert.ToInt32(dt.Rows[i]["CaseCategoryID"]);
			if (dt.Rows[i]["CaseSubCategoryID"] != DBNull.Value)
			record.CaseSubCategoryID = Convert.ToInt32(dt.Rows[i]["CaseSubCategoryID"]);
			record.OtherCategory = dt.Rows[i]["OtherCategory"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseMapcasecategoryItems = (CaseMapCaseCategoryItems[])(recordList.ToArray(typeof(CaseMapCaseCategoryItems)));
		return obj;
		}
		public CaseMapCaseCategoryRow GetByPrimaryKey(int caseID, int casecategoryID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [CaseCategoryID]=" + CreateSqlParameterName("CaseCategoryID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "CaseCategoryID", casecategoryID);
			CaseMapCaseCategoryRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseMapCaseCategoryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseMapCaseCategory] (" +
			"[CaseID], " + 
			"[CaseCategoryID], " + 
			"[CaseSubCategoryID], " + 
			"[OtherCategory], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("CaseCategoryID") + ", " +
			CreateSqlParameterName("CaseSubCategoryID") + ", " +
			CreateSqlParameterName("OtherCategory") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "CaseCategoryID", value.CaseCategoryID);
			AddParameter(cmd, "CaseSubCategoryID", value.IsCaseSubCategoryIDNull ? DBNull.Value : (object)value.CaseSubCategoryID);
			AddParameter(cmd, "OtherCategory", value.IsOtherCategoryNull ? DBNull.Value : (object)value.OtherCategory);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseMapCaseCategoryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseMapCaseCategory] (" +
			"[CaseID], " + 
			"[CaseCategoryID], " + 
			"[CaseSubCategoryID], " + 
			"[OtherCategory], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("CaseCategoryID") + ", " +
			CreateSqlParameterName("CaseSubCategoryID") + ", " +
			CreateSqlParameterName("OtherCategory") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "CaseCategoryID", value.CaseCategoryID);
			AddParameter(cmd, "CaseSubCategoryID", value.IsCaseSubCategoryIDNull ? DBNull.Value : (object)value.CaseSubCategoryID);
			AddParameter(cmd, "OtherCategory", value.IsOtherCategoryNull ? DBNull.Value : (object)value.OtherCategory);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseMapCaseCategoryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetCaseCategoryID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseSubCategoryID)
				{
					strUpdate += "[CaseSubCategoryID]=" + CreateSqlParameterName("CaseSubCategoryID") + ",";
				}
				if (value._IsSetOtherCategory)
				{
					strUpdate += "[OtherCategory]=" + CreateSqlParameterName("OtherCategory") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseMapCaseCategory] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [CaseCategoryID]=" + CreateSqlParameterName("CaseCategoryID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "CaseCategoryID", value.CaseCategoryID);
				if (value._IsSetCaseSubCategoryID)
				{
					AddParameter(cmd, "CaseSubCategoryID", value.IsCaseSubCategoryIDNull ? DBNull.Value : (object)value.CaseSubCategoryID);
				}
					AddParameter(cmd, "OtherCategory", value.OtherCategory);
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,CaseCategoryID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseMapCaseCategoryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetCaseCategoryID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseSubCategoryID)
				{
					strUpdate += "[CaseSubCategoryID]=" + CreateSqlParameterName("CaseSubCategoryID") + ",";
				}
				if (value._IsSetOtherCategory)
				{
					strUpdate += "[OtherCategory]=" + CreateSqlParameterName("OtherCategory") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseMapCaseCategory] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [CaseCategoryID]=" + CreateSqlParameterName("CaseCategoryID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "CaseCategoryID", value.CaseCategoryID);
				if (value._IsSetCaseSubCategoryID)
				{
					AddParameter(cmd, "CaseSubCategoryID", value.IsCaseSubCategoryIDNull ? DBNull.Value : (object)value.CaseSubCategoryID);
				}
					AddParameter(cmd, "OtherCategory", Sanitizer.GetSafeHtmlFragment(value.OtherCategory));
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,CaseCategoryID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID, int casecategoryID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [CaseCategoryID]=" + CreateSqlParameterName("CaseCategoryID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "CaseCategoryID", casecategoryID);
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
		public int DeleteByCaseCategoryID(int casecategoryID)
		{
			return CreateDeleteByCaseCategoryIDCommand(casecategoryID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseCategoryIDCommand(int casecategoryID)
		{
			string whereSql = "";
			whereSql += "[CaseCategoryID]=" + CreateSqlParameterName("CaseCategoryID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseCategoryID", casecategoryID);
			return cmd;
		}
		public int DeleteByCaseSubCategoryID(int caseSubcategoryID)
		{
			return DeleteByCaseSubCategoryID(caseSubcategoryID, false);
		}
		public int DeleteByCaseSubCategoryID(int caseSubcategoryID, bool caseSubcategoryIDNull)
		{
			return CreateDeleteByCaseSubCategoryIDCommand(caseSubcategoryID, caseSubcategoryIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseSubCategoryIDCommand(int caseSubcategoryID, bool caseSubcategoryIDNull)
		{
			string whereSql = "";
			if (caseSubcategoryIDNull)
				whereSql += "[CaseSubCategoryID] IS NULL";
			else
				whereSql += "[CaseSubCategoryID]=" + CreateSqlParameterName("CaseSubCategoryID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!caseSubcategoryIDNull)
				AddParameter(cmd, "CaseSubCategoryID", caseSubcategoryID);
			return cmd;
		}
		protected CaseMapCaseCategoryRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseMapCaseCategoryRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseMapCaseCategoryRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int casecategoryIDColumnIndex = reader.GetOrdinal("CaseCategoryID");
			int caseSubcategoryIDColumnIndex = reader.GetOrdinal("CaseSubCategoryID");
			int otherCategoryColumnIndex = reader.GetOrdinal("OtherCategory");
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
					CaseMapCaseCategoryRow record = new CaseMapCaseCategoryRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.CaseCategoryID =  Convert.ToInt32(reader.GetValue(casecategoryIDColumnIndex));
					if (!reader.IsDBNull(caseSubcategoryIDColumnIndex)) record.CaseSubCategoryID =  Convert.ToInt32(reader.GetValue(caseSubcategoryIDColumnIndex));

					if (!reader.IsDBNull(otherCategoryColumnIndex)) record.OtherCategory =  Convert.ToString(reader.GetValue(otherCategoryColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					record.MapRecord = true;
					if (countRecordRow > 1) 
					{
						record.Many = true;
					}
					else
					{
						record.Many = false;
					}
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseMapCaseCategoryRow[])(recordList.ToArray(typeof(CaseMapCaseCategoryRow)));
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
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseCategoryID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseSubCategoryID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OtherCategory":
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
				throw new FaultException("Zero ProcessID");
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

