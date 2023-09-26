using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using Megazy.StarterKit.Mvc.Transaction.Structure;
namespace Megazy.StarterKit.Mvc.Transaction.Dal
{
	[Serializable]
	public partial class ProvinceExtensionCollection_Base : MarshalByRefObject
	{
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string ProvinceTypeCodeColumnName = "ProvinceTypeCode";
		public const string GroupCodeColumnName = "GroupCode";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ProvinceExtensionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ProvinceExtensionRow[] GetAll()
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
			"[ProvinceID],"+
			"[ProvinceTypeCode],"+
			"[GroupCode],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ProvinceExtension]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ProvinceExtension]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ProvinceExtension"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceTypeCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GroupCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual ProvinceExtensionRow[] GetByProvinceID(int provinceID)
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
		public virtual ProvinceExtensionRow[] GetByProvinceTypeCode(string provinceTypeCode)
		{
			return MapRecords(CreateGetByProvinceTypeCodeCommand(provinceTypeCode));
		}
		public virtual DataTable GetByProvinceTypeCodeAsDataTable(string provinceTypeCode)
		{
			return MapRecordsToDataTable(CreateGetByProvinceTypeCodeCommand(provinceTypeCode));
		}
		protected virtual IDbCommand CreateGetByProvinceTypeCodeCommand(string provinceTypeCode)
		{
			string whereSql = "";
			whereSql += "[ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProvinceTypeCode", provinceTypeCode);
			return cmd;
		}
		public ProvinceExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ProvinceExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ProvinceExtensionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ProvinceExtensionRow"/> objects.</returns>
		public virtual ProvinceExtensionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ProvinceExtension]", top);
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
		public ProvinceExtensionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ProvinceExtensionRow[] rows = null;
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
		public DataTable GetProvinceExtensionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProvinceID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ProvinceID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ProvinceID) AS TotalRow FROM [dbo].[ProvinceExtension] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ProvinceID,ProvinceTypeCode,GroupCode,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [ProvinceExtension].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ProvinceExtension] " + whereSql +
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
		public ProvinceExtensionItemsPaging GetProvinceExtensionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProvinceID")
		{
		ProvinceExtensionItemsPaging obj = new ProvinceExtensionItemsPaging();
		DataTable dt = GetProvinceExtensionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ProvinceExtensionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ProvinceExtensionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.ProvinceTypeCode = dt.Rows[i]["ProvinceTypeCode"].ToString();
			record.GroupCode = dt.Rows[i]["GroupCode"].ToString();
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.provinceExtensionItems = (ProvinceExtensionItems[])(recordList.ToArray(typeof(ProvinceExtensionItems)));
		return obj;
		}
		public ProvinceExtensionRow GetByPrimaryKey(int provinceID, string provinceTypeCode)
		{
			string whereSql = "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + " AND [ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProvinceID", provinceID);
			AddParameter(cmd, "ProvinceTypeCode", provinceTypeCode);
			ProvinceExtensionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ProvinceExtensionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProvinceExtension] (" +
			"[ProvinceID], " + 
			"[ProvinceTypeCode], " + 
			"[GroupCode], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("ProvinceTypeCode") + ", " +
			CreateSqlParameterName("GroupCode") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "ProvinceTypeCode",value.ProvinceTypeCode);
			AddParameter(cmd, "GroupCode", value.GroupCode);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ProvinceExtensionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProvinceExtension] (" +
			"[ProvinceID], " + 
			"[ProvinceTypeCode], " + 
			"[GroupCode], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("ProvinceTypeCode") + ", " +
			CreateSqlParameterName("GroupCode") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "ProvinceTypeCode", Sanitizer.GetSafeHtmlFragment(value.ProvinceTypeCode));
			AddParameter(cmd, "GroupCode", Sanitizer.GetSafeHtmlFragment(value.GroupCode));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ProvinceExtensionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProvinceID == true && value._IsSetProvinceTypeCode == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetGroupCode)
				{
					strUpdate += "[GroupCode]=" + CreateSqlParameterName("GroupCode") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProvinceExtension] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID")+ " AND [ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "ProvinceTypeCode",value.ProvinceTypeCode);
					AddParameter(cmd, "GroupCode", value.GroupCode);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ProvinceID,ProvinceTypeCode)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ProvinceExtensionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProvinceID == true && value._IsSetProvinceTypeCode == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetGroupCode)
				{
					strUpdate += "[GroupCode]=" + CreateSqlParameterName("GroupCode") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProvinceExtension] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID")+ " AND [ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "ProvinceTypeCode", Sanitizer.GetSafeHtmlFragment(value.ProvinceTypeCode));
					AddParameter(cmd, "GroupCode", Sanitizer.GetSafeHtmlFragment(value.GroupCode));
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
				Exception ex = new Exception("Set incorrect primarykey PK(ProvinceID,ProvinceTypeCode)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int provinceID, string provinceTypeCode)
		{
			string whereSql = "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + " AND [ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProvinceID", provinceID);
			AddParameter(cmd, "ProvinceTypeCode", provinceTypeCode);
			return 0 < cmd.ExecuteNonQuery();
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
		public int DeleteByProvinceTypeCode(string provinceTypeCode)
		{
			return CreateDeleteByProvinceTypeCodeCommand(provinceTypeCode).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByProvinceTypeCodeCommand(string provinceTypeCode)
		{
			string whereSql = "";
			whereSql += "[ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProvinceTypeCode", provinceTypeCode);
			return cmd;
		}
		protected ProvinceExtensionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ProvinceExtensionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ProvinceExtensionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int provinceTypeCodeColumnIndex = reader.GetOrdinal("ProvinceTypeCode");
			int groupCodeColumnIndex = reader.GetOrdinal("GroupCode");
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
					ProvinceExtensionRow record = new ProvinceExtensionRow();
					recordList.Add(record);
					record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));
					record.ProvinceTypeCode =  Convert.ToString(reader.GetValue(provinceTypeCodeColumnIndex));
					if (!reader.IsDBNull(groupCodeColumnIndex)) record.GroupCode =  Convert.ToString(reader.GetValue(groupCodeColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ProvinceExtensionRow[])(recordList.ToArray(typeof(ProvinceExtensionRow)));
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
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceTypeCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "GroupCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

