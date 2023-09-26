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
	public partial class InspectValueListCollection_Base : MarshalByRefObject
	{
		public const string InspectValueListIDColumnName = "InspectValueListID";
		public const string InspectValueTypeIDColumnName = "InspectValueTypeID";
		public const string InspectValueListNameColumnName = "InspectValueListName";
		private int _processID;
		public SqlCommand cmd = null;
		public InspectValueListCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual InspectValueListRow[] GetAll()
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
			"[InspectValueListID],"+
			"[InspectValueTypeID],"+
			"[InspectValueListName]"+
			" FROM [dbo].[InspectValueList]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[InspectValueList]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "InspectValueList"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("InspectValueListID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InspectValueTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("InspectValueListName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			return dataTable;
		}
		public virtual InspectValueListRow[] GetByInspectValueTypeID(int inspectValueTypeiD)
		{
			return MapRecords(CreateGetByInspectValueTypeIDCommand(inspectValueTypeiD));
		}
		public virtual DataTable GetByInspectValueTypeIDAsDataTable(int inspectValueTypeiD)
		{
			return MapRecordsToDataTable(CreateGetByInspectValueTypeIDCommand(inspectValueTypeiD));
		}
		protected virtual IDbCommand CreateGetByInspectValueTypeIDCommand(int inspectValueTypeiD)
		{
			string whereSql = "";
			whereSql += "[InspectValueTypeID]=" + CreateSqlParameterName("InspectValueTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InspectValueTypeID", inspectValueTypeiD);
			return cmd;
		}
		public InspectValueListRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual InspectValueListRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="InspectValueListRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="InspectValueListRow"/> objects.</returns>
		public virtual InspectValueListRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[InspectValueList]", top);
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
		public InspectValueListRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			InspectValueListRow[] rows = null;
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
		public DataTable GetInspectValueListPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InspectValueListID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "InspectValueListID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(InspectValueListID) AS TotalRow FROM [dbo].[InspectValueList] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,InspectValueListID,InspectValueTypeID,InspectValueListName," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [InspectValueList].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[InspectValueList] " + whereSql +
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
		public InspectValueListItemsPaging GetInspectValueListPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InspectValueListID")
		{
		InspectValueListItemsPaging obj = new InspectValueListItemsPaging();
		DataTable dt = GetInspectValueListPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		InspectValueListItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new InspectValueListItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.InspectValueListID = Convert.ToInt32(dt.Rows[i]["InspectValueListID"]);
			if (dt.Rows[i]["InspectValueTypeID"] != DBNull.Value)
			record.InspectValueTypeID = Convert.ToInt32(dt.Rows[i]["InspectValueTypeID"]);
			record.InspectValueListName = dt.Rows[i]["InspectValueListName"].ToString();
			recordList.Add(record);
		}
		obj.inspectValueListItems = (InspectValueListItems[])(recordList.ToArray(typeof(InspectValueListItems)));
		return obj;
		}
		public InspectValueListRow GetByPrimaryKey(int inspectValueListiD)
		{
			string whereSql = "[InspectValueListID]=" + CreateSqlParameterName("InspectValueListID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InspectValueListID", inspectValueListiD);
			InspectValueListRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(InspectValueListRow value)		{
			string sqlStr = "INSERT INTO [dbo].[InspectValueList] (" +
			"[InspectValueListID], " + 
			"[InspectValueTypeID], " + 
			"[InspectValueListName]			" + 
			") VALUES (" +
			CreateSqlParameterName("InspectValueListID") + ", " +
			CreateSqlParameterName("InspectValueTypeID") + ", " +
			CreateSqlParameterName("InspectValueListName") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "InspectValueListID", value.InspectValueListID);
			AddParameter(cmd, "InspectValueTypeID", value.IsInspectValueTypeIDNull ? DBNull.Value : (object)value.InspectValueTypeID);
			AddParameter(cmd, "InspectValueListName", value.InspectValueListName);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(InspectValueListRow value)		{
			string sqlStr = "INSERT INTO [dbo].[InspectValueList] (" +
			"[InspectValueListID], " + 
			"[InspectValueTypeID], " + 
			"[InspectValueListName]			" + 
			") VALUES (" +
			CreateSqlParameterName("InspectValueListID") + ", " +
			CreateSqlParameterName("InspectValueTypeID") + ", " +
			CreateSqlParameterName("InspectValueListName") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "InspectValueListID", value.InspectValueListID);
			AddParameter(cmd, "InspectValueTypeID", value.IsInspectValueTypeIDNull ? DBNull.Value : (object)value.InspectValueTypeID);
			AddParameter(cmd, "InspectValueListName", Sanitizer.GetSafeHtmlFragment(value.InspectValueListName));
			cmd.ExecuteNonQuery();
		}
		public bool Update(InspectValueListRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetInspectValueListID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetInspectValueTypeID)
				{
					strUpdate += "[InspectValueTypeID]=" + CreateSqlParameterName("InspectValueTypeID") + ",";
				}
				if (value._IsSetInspectValueListName)
				{
					strUpdate += "[InspectValueListName]=" + CreateSqlParameterName("InspectValueListName") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[InspectValueList] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[InspectValueListID]=" + CreateSqlParameterName("InspectValueListID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "InspectValueListID", value.InspectValueListID);
					AddParameter(cmd, "InspectValueTypeID", value.IsInspectValueTypeIDNull ? DBNull.Value : (object)value.InspectValueTypeID);
					AddParameter(cmd, "InspectValueListName", value.InspectValueListName);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(InspectValueListID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(InspectValueListRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetInspectValueListID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetInspectValueTypeID)
				{
					strUpdate += "[InspectValueTypeID]=" + CreateSqlParameterName("InspectValueTypeID") + ",";
				}
				if (value._IsSetInspectValueListName)
				{
					strUpdate += "[InspectValueListName]=" + CreateSqlParameterName("InspectValueListName") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[InspectValueList] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[InspectValueListID]=" + CreateSqlParameterName("InspectValueListID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "InspectValueListID", value.InspectValueListID);
					AddParameter(cmd, "InspectValueTypeID", value.IsInspectValueTypeIDNull ? DBNull.Value : (object)value.InspectValueTypeID);
					AddParameter(cmd, "InspectValueListName", Sanitizer.GetSafeHtmlFragment(value.InspectValueListName));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(InspectValueListID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int inspectValueListiD)
		{
			string whereSql = "[InspectValueListID]=" + CreateSqlParameterName("InspectValueListID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "InspectValueListID", inspectValueListiD);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByInspectValueTypeID(int inspectValueTypeiD)
		{
			return DeleteByInspectValueTypeID(inspectValueTypeiD, false);
		}
		public int DeleteByInspectValueTypeID(int inspectValueTypeiD, bool inspectValueTypeiDNull)
		{
			return CreateDeleteByInspectValueTypeIDCommand(inspectValueTypeiD, inspectValueTypeiDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByInspectValueTypeIDCommand(int inspectValueTypeiD, bool inspectValueTypeiDNull)
		{
			string whereSql = "";
			if (inspectValueTypeiDNull)
				whereSql += "[InspectValueTypeID] IS NULL";
			else
				whereSql += "[InspectValueTypeID]=" + CreateSqlParameterName("InspectValueTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!inspectValueTypeiDNull)
				AddParameter(cmd, "InspectValueTypeID", inspectValueTypeiD);
			return cmd;
		}
		protected InspectValueListRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected InspectValueListRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected InspectValueListRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int inspectValueListiDColumnIndex = reader.GetOrdinal("InspectValueListID");
			int inspectValueTypeiDColumnIndex = reader.GetOrdinal("InspectValueTypeID");
			int inspectValueListNameColumnIndex = reader.GetOrdinal("InspectValueListName");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					InspectValueListRow record = new InspectValueListRow();
					recordList.Add(record);
					record.InspectValueListID =  Convert.ToInt32(reader.GetValue(inspectValueListiDColumnIndex));
					if (!reader.IsDBNull(inspectValueTypeiDColumnIndex)) record.InspectValueTypeID =  Convert.ToInt32(reader.GetValue(inspectValueTypeiDColumnIndex));

					if (!reader.IsDBNull(inspectValueListNameColumnIndex)) record.InspectValueListName =  Convert.ToString(reader.GetValue(inspectValueListNameColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (InspectValueListRow[])(recordList.ToArray(typeof(InspectValueListRow)));
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
				case "InspectValueListID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "InspectValueTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "InspectValueListName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

