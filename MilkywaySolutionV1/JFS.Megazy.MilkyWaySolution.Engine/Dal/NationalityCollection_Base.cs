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
	public partial class NationalityCollection_Base : MarshalByRefObject
	{
		public const string NationalityIDColumnName = "NationalityID";
		public const string NationalityCodeColumnName = "NationalityCode";
		public const string NationalityNameColumnName = "NationalityName";
		public const string SortOrderColumnName = "SortOrder";
		public const string IsActiveColumnName = "IsActive";
		private int _processID;
		public SqlCommand cmd = null;
		public NationalityCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual NationalityRow[] GetAll()
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
			"[NationalityID],"+
			"[NationalityCode],"+
			"[NationalityName],"+
			"[SortOrder],"+
			"[IsActive]"+
			" FROM [dbo].[Nationality]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Nationality]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Nationality"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NationalityCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 3;
			dataColumn = dataTable.Columns.Add("NationalityName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public NationalityRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual NationalityRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="NationalityRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NationalityRow"/> objects.</returns>
		public virtual NationalityRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Nationality]", top);
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
		public NationalityRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			NationalityRow[] rows = null;
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
		public DataTable GetNationalityPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "NationalityID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "NationalityID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(NationalityID) AS TotalRow FROM [dbo].[Nationality] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,NationalityID,NationalityCode,NationalityName,SortOrder,IsActive," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Nationality] " + whereSql +
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
		public NationalityItemsPaging GetNationalityPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "NationalityID")
		{
		NationalityItemsPaging obj = new NationalityItemsPaging();
		DataTable dt = GetNationalityPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		NationalityItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new NationalityItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			record.NationalityCode = dt.Rows[i]["NationalityCode"].ToString();
			record.NationalityName = dt.Rows[i]["NationalityName"].ToString();
			if (dt.Rows[i]["SortOrder"] != DBNull.Value)
			record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			recordList.Add(record);
		}
		obj.nationalityItems = (NationalityItems[])(recordList.ToArray(typeof(NationalityItems)));
		return obj;
		}
		public NationalityRow GetByPrimaryKey(int nationalityID)
		{
			string whereSql = "[NationalityID]=" + CreateSqlParameterName("NationalityID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "NationalityID", nationalityID);
			NationalityRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(NationalityRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Nationality] (" +
			"[NationalityID], " + 
			"[NationalityCode], " + 
			"[NationalityName], " + 
			"[SortOrder], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("NationalityCode") + ", " +
			CreateSqlParameterName("NationalityName") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActive") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "NationalityID", value.NationalityID);
			AddParameter(cmd, "NationalityCode", value.NationalityCode);
			AddParameter(cmd, "NationalityName", value.NationalityName);
			AddParameter(cmd, "SortOrder", value.IsSortOrderNull ? DBNull.Value : (object)value.SortOrder);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(NationalityRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Nationality] (" +
			"[NationalityID], " + 
			"[NationalityCode], " + 
			"[NationalityName], " + 
			"[SortOrder], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("NationalityCode") + ", " +
			CreateSqlParameterName("NationalityName") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActive") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "NationalityID", value.NationalityID);
			AddParameter(cmd, "NationalityCode", Sanitizer.GetSafeHtmlFragment(value.NationalityCode));
			AddParameter(cmd, "NationalityName", Sanitizer.GetSafeHtmlFragment(value.NationalityName));
			AddParameter(cmd, "SortOrder", value.IsSortOrderNull ? DBNull.Value : (object)value.SortOrder);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			cmd.ExecuteNonQuery();
		}
		public bool Update(NationalityRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetNationalityID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetNationalityCode)
				{
					strUpdate += "[NationalityCode]=" + CreateSqlParameterName("NationalityCode") + ",";
				}
				if (value._IsSetNationalityName)
				{
					strUpdate += "[NationalityName]=" + CreateSqlParameterName("NationalityName") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Nationality] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "NationalityID", value.NationalityID);
					AddParameter(cmd, "NationalityCode", value.NationalityCode);
					AddParameter(cmd, "NationalityName", value.NationalityName);
					AddParameter(cmd, "SortOrder", value.IsSortOrderNull ? DBNull.Value : (object)value.SortOrder);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(NationalityID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(NationalityRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetNationalityID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetNationalityCode)
				{
					strUpdate += "[NationalityCode]=" + CreateSqlParameterName("NationalityCode") + ",";
				}
				if (value._IsSetNationalityName)
				{
					strUpdate += "[NationalityName]=" + CreateSqlParameterName("NationalityName") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Nationality] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "NationalityID", value.NationalityID);
					AddParameter(cmd, "NationalityCode", Sanitizer.GetSafeHtmlFragment(value.NationalityCode));
					AddParameter(cmd, "NationalityName", Sanitizer.GetSafeHtmlFragment(value.NationalityName));
					AddParameter(cmd, "SortOrder", value.IsSortOrderNull ? DBNull.Value : (object)value.SortOrder);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(NationalityID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int nationalityID)
		{
			string whereSql = "[NationalityID]=" + CreateSqlParameterName("NationalityID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "NationalityID", nationalityID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public NationalityRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			NationalityRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected NationalityRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected NationalityRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected NationalityRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int nationalityCodeColumnIndex = reader.GetOrdinal("NationalityCode");
			int nationalitynameColumnIndex = reader.GetOrdinal("NationalityName");
			int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					NationalityRow record = new NationalityRow();
					recordList.Add(record);
					record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));
					if (!reader.IsDBNull(nationalityCodeColumnIndex)) record.NationalityCode =  Convert.ToString(reader.GetValue(nationalityCodeColumnIndex));

					if (!reader.IsDBNull(nationalitynameColumnIndex)) record.NationalityName =  Convert.ToString(reader.GetValue(nationalitynameColumnIndex));

					if (!reader.IsDBNull(sortOrderColumnIndex)) record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NationalityRow[])(recordList.ToArray(typeof(NationalityRow)));
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
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityCode":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "NationalityName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SortOrder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

