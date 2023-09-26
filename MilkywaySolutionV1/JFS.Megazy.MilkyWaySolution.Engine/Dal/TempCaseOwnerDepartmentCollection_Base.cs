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
	public partial class TempCaseOwnerDepartmentCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string ReferenceDepartmentIDColumnName = "ReferenceDepartmentID";
		public const string IsSysnColumnName = "IsSysn";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public TempCaseOwnerDepartmentCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual TempCaseOwnerDepartmentRow[] GetAll()
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
			"[DepartmentID],"+
			"[ReferenceDepartmentID],"+
			"[IsSysn],"+
			"[ModifiedDate]"+
			" FROM [dbo].[TempCaseOwnerDepartment]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[TempCaseOwnerDepartment]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "TempCaseOwnerDepartment"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ReferenceDepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsSysn",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public TempCaseOwnerDepartmentRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual TempCaseOwnerDepartmentRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="TempCaseOwnerDepartmentRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TempCaseOwnerDepartmentRow"/> objects.</returns>
		public virtual TempCaseOwnerDepartmentRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[TempCaseOwnerDepartment]", top);
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
		public TempCaseOwnerDepartmentRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			TempCaseOwnerDepartmentRow[] rows = null;
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
		public DataTable GetTempCaseOwnerDepartmentPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[TempCaseOwnerDepartment] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,DepartmentID,ReferenceDepartmentID,IsSysn,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [TempCaseOwnerDepartment].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[TempCaseOwnerDepartment] " + whereSql +
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
		public TempCaseOwnerDepartmentItemsPaging GetTempCaseOwnerDepartmentPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		TempCaseOwnerDepartmentItemsPaging obj = new TempCaseOwnerDepartmentItemsPaging();
		DataTable dt = GetTempCaseOwnerDepartmentPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		TempCaseOwnerDepartmentItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new TempCaseOwnerDepartmentItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			if (dt.Rows[i]["ReferenceDepartmentID"] != DBNull.Value)
			record.ReferenceDepartmentID = Convert.ToInt32(dt.Rows[i]["ReferenceDepartmentID"]);
			record.IsSysn = Convert.ToBoolean(dt.Rows[i]["IsSysn"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.tempCaseOwnerDepartmentItems = (TempCaseOwnerDepartmentItems[])(recordList.ToArray(typeof(TempCaseOwnerDepartmentItems)));
		return obj;
		}
		/// <summary>
		/// เรียกข้อมูลจำนวนเรคคอร์ดโดย Column
		/// </summary>
		/// <param name="sqlParameter"></param>
		/// <param name="whereSql">ID = 1</param>
		/// <returns></returns>
		public int GetCountByColumnName(List<SqlParameter> sqlParameter, string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SqlCommand command = CreateCountCommand(whereSql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return (Int32)cmd.ExecuteScalar();
		}
		protected virtual SqlCommand CreateCountCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql =  "SELECT "+
			" COUNT(*)" +
			" FROM [dbo].[TempCaseOwnerDepartment]"; 
			if (null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql; 
			 return CreateCommand(sql); 
		}
		public TempCaseOwnerDepartmentRow GetByPrimaryKey(int caseID, int departmentId)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "DepartmentID", departmentId);
			TempCaseOwnerDepartmentRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(TempCaseOwnerDepartmentRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TempCaseOwnerDepartment] (" +
			"[CaseID], " + 
			"[DepartmentID], " + 
			"[ReferenceDepartmentID], " + 
			"[IsSysn], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ReferenceDepartmentID") + ", " +
			CreateSqlParameterName("IsSysn") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "ReferenceDepartmentID", value.IsReferenceDepartmentIDNull ? DBNull.Value : (object)value.ReferenceDepartmentID);
			AddParameter(cmd, "IsSysn", value.IsSysn);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(TempCaseOwnerDepartmentRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TempCaseOwnerDepartment] (" +
			"[CaseID], " + 
			"[DepartmentID], " + 
			"[ReferenceDepartmentID], " + 
			"[IsSysn], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ReferenceDepartmentID") + ", " +
			CreateSqlParameterName("IsSysn") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "ReferenceDepartmentID", value.IsReferenceDepartmentIDNull ? DBNull.Value : (object)value.ReferenceDepartmentID);
			AddParameter(cmd, "IsSysn", value.IsSysn);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(TempCaseOwnerDepartmentRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetReferenceDepartmentID)
				{
					strUpdate += "[ReferenceDepartmentID]=" + CreateSqlParameterName("ReferenceDepartmentID") + ",";
				}
				if (value._IsSetIsSysn)
				{
					strUpdate += "[IsSysn]=" + CreateSqlParameterName("IsSysn") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TempCaseOwnerDepartment] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ReferenceDepartmentID", value.IsReferenceDepartmentIDNull ? DBNull.Value : (object)value.ReferenceDepartmentID);
					AddParameter(cmd, "IsSysn", value.IsSysn);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(TempCaseOwnerDepartmentRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetReferenceDepartmentID)
				{
					strUpdate += "[ReferenceDepartmentID]=" + CreateSqlParameterName("ReferenceDepartmentID") + ",";
				}
				if (value._IsSetIsSysn)
				{
					strUpdate += "[IsSysn]=" + CreateSqlParameterName("IsSysn") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TempCaseOwnerDepartment] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ReferenceDepartmentID", value.IsReferenceDepartmentIDNull ? DBNull.Value : (object)value.ReferenceDepartmentID);
					AddParameter(cmd, "IsSysn", value.IsSysn);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID, int departmentId)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "DepartmentID", departmentId);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected TempCaseOwnerDepartmentRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected TempCaseOwnerDepartmentRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected TempCaseOwnerDepartmentRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int referenceDepartmentIDColumnIndex = reader.GetOrdinal("ReferenceDepartmentID");
			int isSysnColumnIndex = reader.GetOrdinal("IsSysn");
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
					TempCaseOwnerDepartmentRow record = new TempCaseOwnerDepartmentRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					if (!reader.IsDBNull(referenceDepartmentIDColumnIndex)) record.ReferenceDepartmentID =  Convert.ToInt32(reader.GetValue(referenceDepartmentIDColumnIndex));

					record.IsSysn =  Convert.ToBoolean(reader.GetValue(isSysnColumnIndex));
					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TempCaseOwnerDepartmentRow[])(recordList.ToArray(typeof(TempCaseOwnerDepartmentRow)));
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
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceDepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsSysn":
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

