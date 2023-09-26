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
	public partial class ArchivalCopyMapJFCaseTypeCollection_Base : MarshalByRefObject
	{
		public const string ArchivalCopyIDColumnName = "ArchivalCopyID";
		public const string JFCaseTypeIDColumnName = "JFCaseTypeID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ArchivalCopyMapJFCaseTypeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ArchivalCopyMapJFCaseTypeRow[] GetAll()
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
			"[ArchivalCopyID],"+
			"[JFCaseTypeID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ArchivalCopyMapJFCaseType]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ArchivalCopyMapJFCaseType]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ArchivalCopyMapJFCaseType"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ArchivalCopyID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("JFCaseTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ArchivalCopyMapJFCaseTypeRow[] GetByArchivalCopyID(int archivalCopyID)
		{
			return MapRecords(CreateGetByArchivalCopyIDCommand(archivalCopyID));
		}
		public virtual DataTable GetByArchivalCopyIDAsDataTable(int archivalCopyID)
		{
			return MapRecordsToDataTable(CreateGetByArchivalCopyIDCommand(archivalCopyID));
		}
		protected virtual IDbCommand CreateGetByArchivalCopyIDCommand(int archivalCopyID)
		{
			string whereSql = "";
			whereSql += "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ArchivalCopyID", archivalCopyID);
			return cmd;
		}
		public virtual ArchivalCopyMapJFCaseTypeRow[] GetByJFCaseTypeID(int jFCaseTypeID)
		{
			return MapRecords(CreateGetByJFCaseTypeIDCommand(jFCaseTypeID));
		}
		public virtual DataTable GetByJFCaseTypeIDAsDataTable(int jFCaseTypeID)
		{
			return MapRecordsToDataTable(CreateGetByJFCaseTypeIDCommand(jFCaseTypeID));
		}
		protected virtual IDbCommand CreateGetByJFCaseTypeIDCommand(int jFCaseTypeID)
		{
			string whereSql = "";
			whereSql += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "JFCaseTypeID", jFCaseTypeID);
			return cmd;
		}
		public ArchivalCopyMapJFCaseTypeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ArchivalCopyMapJFCaseTypeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ArchivalCopyMapJFCaseTypeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ArchivalCopyMapJFCaseTypeRow"/> objects.</returns>
		public virtual ArchivalCopyMapJFCaseTypeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ArchivalCopyMapJFCaseType]", top);
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
		public ArchivalCopyMapJFCaseTypeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ArchivalCopyMapJFCaseTypeRow[] rows = null;
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
		public DataTable GetArchivalCopyMapJFCaseTypePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ArchivalCopyID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ArchivalCopyID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ArchivalCopyID) AS TotalRow FROM [dbo].[ArchivalCopyMapJFCaseType] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ArchivalCopyID,JFCaseTypeID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ArchivalCopyMapJFCaseType] " + whereSql +
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
		public ArchivalCopyMapJFCaseTypeItemsPaging GetArchivalCopyMapJFCaseTypePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ArchivalCopyID")
		{
		ArchivalCopyMapJFCaseTypeItemsPaging obj = new ArchivalCopyMapJFCaseTypeItemsPaging();
		DataTable dt = GetArchivalCopyMapJFCaseTypePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ArchivalCopyMapJFCaseTypeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ArchivalCopyMapJFCaseTypeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ArchivalCopyID = Convert.ToInt32(dt.Rows[i]["ArchivalCopyID"]);
			record.JFCaseTypeID = Convert.ToInt32(dt.Rows[i]["JFCaseTypeID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.archivalCopyMapJFCaseTypeItems = (ArchivalCopyMapJFCaseTypeItems[])(recordList.ToArray(typeof(ArchivalCopyMapJFCaseTypeItems)));
		return obj;
		}
		public ArchivalCopyMapJFCaseTypeRow GetByPrimaryKey(int archivalCopyID, int jFCaseTypeID)
		{
			string whereSql = "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID") + " AND [JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ArchivalCopyID", archivalCopyID);
			AddParameter(cmd, "JFCaseTypeID", jFCaseTypeID);
			ArchivalCopyMapJFCaseTypeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ArchivalCopyMapJFCaseTypeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ArchivalCopyMapJFCaseType] (" +
			"[ArchivalCopyID], " + 
			"[JFCaseTypeID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ArchivalCopyID") + ", " +
			CreateSqlParameterName("JFCaseTypeID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ArchivalCopyID", value.ArchivalCopyID);
			AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ArchivalCopyMapJFCaseTypeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ArchivalCopyMapJFCaseType] (" +
			"[ArchivalCopyID], " + 
			"[JFCaseTypeID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ArchivalCopyID") + ", " +
			CreateSqlParameterName("JFCaseTypeID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ArchivalCopyID", value.ArchivalCopyID);
			AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ArchivalCopyMapJFCaseTypeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetArchivalCopyID == true && value._IsSetJFCaseTypeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ArchivalCopyMapJFCaseType] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID")+ " AND [JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ArchivalCopyID", value.ArchivalCopyID);
					AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ArchivalCopyID,JFCaseTypeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ArchivalCopyMapJFCaseTypeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetArchivalCopyID == true && value._IsSetJFCaseTypeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ArchivalCopyMapJFCaseType] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID")+ " AND [JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ArchivalCopyID", value.ArchivalCopyID);
					AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ArchivalCopyID,JFCaseTypeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int archivalCopyID, int jFCaseTypeID)
		{
			string whereSql = "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID") + " AND [JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ArchivalCopyID", archivalCopyID);
			AddParameter(cmd, "JFCaseTypeID", jFCaseTypeID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByArchivalCopyID(int archivalCopyID)
		{
			return CreateDeleteByArchivalCopyIDCommand(archivalCopyID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByArchivalCopyIDCommand(int archivalCopyID)
		{
			string whereSql = "";
			whereSql += "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ArchivalCopyID", archivalCopyID);
			return cmd;
		}
		public int DeleteByJFCaseTypeID(int jFCaseTypeID)
		{
			return CreateDeleteByJFCaseTypeIDCommand(jFCaseTypeID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByJFCaseTypeIDCommand(int jFCaseTypeID)
		{
			string whereSql = "";
			whereSql += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "JFCaseTypeID", jFCaseTypeID);
			return cmd;
		}
		protected ArchivalCopyMapJFCaseTypeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ArchivalCopyMapJFCaseTypeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ArchivalCopyMapJFCaseTypeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int archivalCopyIDColumnIndex = reader.GetOrdinal("ArchivalCopyID");
			int jFCaseTypeIDColumnIndex = reader.GetOrdinal("JFCaseTypeID");
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
					ArchivalCopyMapJFCaseTypeRow record = new ArchivalCopyMapJFCaseTypeRow();
					recordList.Add(record);
					record.ArchivalCopyID =  Convert.ToInt32(reader.GetValue(archivalCopyIDColumnIndex));
					record.JFCaseTypeID =  Convert.ToInt32(reader.GetValue(jFCaseTypeIDColumnIndex));
					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ArchivalCopyMapJFCaseTypeRow[])(recordList.ToArray(typeof(ArchivalCopyMapJFCaseTypeRow)));
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
				case "ArchivalCopyID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "JFCaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

