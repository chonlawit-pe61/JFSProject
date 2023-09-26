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
	public partial class CaseSubCategoryCollection_Base : MarshalByRefObject
	{
		public const string CaseSubCategoryIDColumnName = "CaseSubCategoryID";
		public const string CaseCategoryIDColumnName = "CaseCategoryID";
		public const string CaseSubCategoryNameColumnName = "CaseSubCategoryName";
		public const string SortOrderColumnName = "SortOrder";
		public const string IsActvieColumnName = "IsActvie";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseSubCategoryCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseSubCategoryRow[] GetAll()
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
			"[CaseSubCategoryID],"+
			"[CaseCategoryID],"+
			"[CaseSubCategoryName],"+
			"[SortOrder],"+
			"[IsActvie],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseSubCategory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseSubCategory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseSubCategory"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseSubCategoryID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseCategoryID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseSubCategoryName",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsActvie",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual CaseSubCategoryRow[] GetByCaseCategoryID(int casecategoryID)
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
		public CaseSubCategoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseSubCategoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseSubCategoryRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseSubCategoryRow"/> objects.</returns>
		public virtual CaseSubCategoryRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseSubCategory]", top);
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
		public CaseSubCategoryRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseSubCategoryRow[] rows = null;
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
		public DataTable GetCaseSubCategoryPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseSubCategoryID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CaseSubCategoryID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(CaseSubCategoryID) AS TotalRow FROM [dbo].[CaseSubCategory] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseSubCategoryID,CaseCategoryID,CaseSubCategoryName,SortOrder,IsActvie,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseSubCategory] " + whereSql +
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
		public CaseSubCategoryItemsPaging GetCaseSubCategoryPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseSubCategoryID")
		{
		CaseSubCategoryItemsPaging obj = new CaseSubCategoryItemsPaging();
		DataTable dt = GetCaseSubCategoryPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseSubCategoryItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseSubCategoryItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseSubCategoryID = Convert.ToInt32(dt.Rows[i]["CaseSubCategoryID"]);
			record.CaseCategoryID = Convert.ToInt32(dt.Rows[i]["CaseCategoryID"]);
			record.CaseSubCategoryName = dt.Rows[i]["CaseSubCategoryName"].ToString();
			if (dt.Rows[i]["SortOrder"] != DBNull.Value)
			record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
			record.IsActvie = Convert.ToBoolean(dt.Rows[i]["IsActvie"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseSubcategoryItems = (CaseSubCategoryItems[])(recordList.ToArray(typeof(CaseSubCategoryItems)));
		return obj;
		}
		public CaseSubCategoryRow GetByPrimaryKey(int caseSubcategoryID)
		{
			string whereSql = "[CaseSubCategoryID]=" + CreateSqlParameterName("CaseSubCategoryID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseSubCategoryID", caseSubcategoryID);
			CaseSubCategoryRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseSubCategoryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseSubCategory] (" +
			"[CaseSubCategoryID], " + 
			"[CaseCategoryID], " + 
			"[CaseSubCategoryName], " + 
			"[SortOrder], " + 
			"[IsActvie], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseSubCategoryID") + ", " +
			CreateSqlParameterName("CaseCategoryID") + ", " +
			CreateSqlParameterName("CaseSubCategoryName") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActvie") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseSubCategoryID", value.CaseSubCategoryID);
			AddParameter(cmd, "CaseCategoryID", value.CaseCategoryID);
			AddParameter(cmd, "CaseSubCategoryName",value.CaseSubCategoryName);
			AddParameter(cmd, "SortOrder", value.IsSortOrderNull ? DBNull.Value : (object)value.SortOrder);
			AddParameter(cmd, "IsActvie", value.IsActvie);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseSubCategoryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseSubCategory] (" +
			"[CaseSubCategoryID], " + 
			"[CaseCategoryID], " + 
			"[CaseSubCategoryName], " + 
			"[SortOrder], " + 
			"[IsActvie], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseSubCategoryID") + ", " +
			CreateSqlParameterName("CaseCategoryID") + ", " +
			CreateSqlParameterName("CaseSubCategoryName") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActvie") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseSubCategoryID", value.CaseSubCategoryID);
			AddParameter(cmd, "CaseCategoryID", value.CaseCategoryID);
			AddParameter(cmd, "CaseSubCategoryName", Sanitizer.GetSafeHtmlFragment(value.CaseSubCategoryName));
			AddParameter(cmd, "SortOrder", value.IsSortOrderNull ? DBNull.Value : (object)value.SortOrder);
			AddParameter(cmd, "IsActvie", value.IsActvie);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseSubCategoryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseSubCategoryID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseCategoryID)
				{
					strUpdate += "[CaseCategoryID]=" + CreateSqlParameterName("CaseCategoryID") + ",";
				}
				if (value._IsSetCaseSubCategoryName)
				{
					strUpdate += "[CaseSubCategoryName]=" + CreateSqlParameterName("CaseSubCategoryName") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsActvie)
				{
					strUpdate += "[IsActvie]=" + CreateSqlParameterName("IsActvie") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseSubCategory] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseSubCategoryID]=" + CreateSqlParameterName("CaseSubCategoryID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseSubCategoryID", value.CaseSubCategoryID);
					AddParameter(cmd, "CaseCategoryID", value.CaseCategoryID);
					AddParameter(cmd, "CaseSubCategoryName",value.CaseSubCategoryName);
					AddParameter(cmd, "SortOrder", value.IsSortOrderNull ? DBNull.Value : (object)value.SortOrder);
					AddParameter(cmd, "IsActvie", value.IsActvie);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseSubCategoryID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseSubCategoryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseSubCategoryID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseCategoryID)
				{
					strUpdate += "[CaseCategoryID]=" + CreateSqlParameterName("CaseCategoryID") + ",";
				}
				if (value._IsSetCaseSubCategoryName)
				{
					strUpdate += "[CaseSubCategoryName]=" + CreateSqlParameterName("CaseSubCategoryName") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsActvie)
				{
					strUpdate += "[IsActvie]=" + CreateSqlParameterName("IsActvie") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseSubCategory] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseSubCategoryID]=" + CreateSqlParameterName("CaseSubCategoryID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseSubCategoryID", value.CaseSubCategoryID);
					AddParameter(cmd, "CaseCategoryID", value.CaseCategoryID);
					AddParameter(cmd, "CaseSubCategoryName", Sanitizer.GetSafeHtmlFragment(value.CaseSubCategoryName));
					AddParameter(cmd, "SortOrder", value.IsSortOrderNull ? DBNull.Value : (object)value.SortOrder);
					AddParameter(cmd, "IsActvie", value.IsActvie);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseSubCategoryID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseSubcategoryID)
		{
			string whereSql = "[CaseSubCategoryID]=" + CreateSqlParameterName("CaseSubCategoryID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseSubCategoryID", caseSubcategoryID);
			return 0 < cmd.ExecuteNonQuery();
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
		protected CaseSubCategoryRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseSubCategoryRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseSubCategoryRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseSubcategoryIDColumnIndex = reader.GetOrdinal("CaseSubCategoryID");
			int casecategoryIDColumnIndex = reader.GetOrdinal("CaseCategoryID");
			int caseSubcategoryNameColumnIndex = reader.GetOrdinal("CaseSubCategoryName");
			int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
			int isActvieColumnIndex = reader.GetOrdinal("IsActvie");
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
					CaseSubCategoryRow record = new CaseSubCategoryRow();
					recordList.Add(record);
					record.CaseSubCategoryID =  Convert.ToInt32(reader.GetValue(caseSubcategoryIDColumnIndex));
					record.CaseCategoryID =  Convert.ToInt32(reader.GetValue(casecategoryIDColumnIndex));
					record.CaseSubCategoryName =  Convert.ToString(reader.GetValue(caseSubcategoryNameColumnIndex));
					if (!reader.IsDBNull(sortOrderColumnIndex)) record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));

					record.IsActvie =  Convert.ToBoolean(reader.GetValue(isActvieColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseSubCategoryRow[])(recordList.ToArray(typeof(CaseSubCategoryRow)));
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
				case "CaseSubCategoryID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseCategoryID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseSubCategoryName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SortOrder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsActvie":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

