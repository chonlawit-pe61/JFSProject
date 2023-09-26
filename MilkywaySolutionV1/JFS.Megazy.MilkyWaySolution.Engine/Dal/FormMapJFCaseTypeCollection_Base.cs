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
	public partial class FormMapJFCaseTypeCollection_Base : MarshalByRefObject
	{
		public const string JFCaseTypeIDColumnName = "JFCaseTypeID";
		public const string FormIDColumnName = "FormID";
		public const string SortOrderColumnName = "SortOrder";
		private int _processID;
		public SqlCommand cmd = null;
		public FormMapJFCaseTypeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual FormMapJFCaseTypeRow[] GetAll()
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
			"[JFCaseTypeID],"+
			"[FormID],"+
			"[SortOrder]"+
			" FROM [dbo].[FormMapJFCaseType]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[FormMapJFCaseType]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "FormMapJFCaseType"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("JFCaseTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual FormMapJFCaseTypeRow[] GetByJFCaseTypeID(int jFCaseTypeID)
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
		public virtual FormMapJFCaseTypeRow[] GetByFormID(int formID)
		{
			return MapRecords(CreateGetByFormIDCommand(formID));
		}
		public virtual DataTable GetByFormIDAsDataTable(int formID)
		{
			return MapRecordsToDataTable(CreateGetByFormIDCommand(formID));
		}
		protected virtual IDbCommand CreateGetByFormIDCommand(int formID)
		{
			string whereSql = "";
			whereSql += "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FormID", formID);
			return cmd;
		}
		public FormMapJFCaseTypeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual FormMapJFCaseTypeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="FormMapJFCaseTypeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FormMapJFCaseTypeRow"/> objects.</returns>
		public virtual FormMapJFCaseTypeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[FormMapJFCaseType]", top);
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
		public FormMapJFCaseTypeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			FormMapJFCaseTypeRow[] rows = null;
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
		public DataTable GetFormMapJFCaseTypePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "JFCaseTypeID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "JFCaseTypeID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(JFCaseTypeID) AS TotalRow FROM [dbo].[FormMapJFCaseType] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,JFCaseTypeID,FormID,SortOrder," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[FormMapJFCaseType] " + whereSql +
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
		public FormMapJFCaseTypeItemsPaging GetFormMapJFCaseTypePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "JFCaseTypeID")
		{
		FormMapJFCaseTypeItemsPaging obj = new FormMapJFCaseTypeItemsPaging();
		DataTable dt = GetFormMapJFCaseTypePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		FormMapJFCaseTypeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new FormMapJFCaseTypeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.JFCaseTypeID = Convert.ToInt32(dt.Rows[i]["JFCaseTypeID"]);
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
			recordList.Add(record);
		}
		obj.formMapJfCaseTypeItems = (FormMapJFCaseTypeItems[])(recordList.ToArray(typeof(FormMapJFCaseTypeItems)));
		return obj;
		}
		public FormMapJFCaseTypeRow GetByPrimaryKey(int jFCaseTypeID, int formID)
		{
			string whereSql = "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID") + " AND [FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "JFCaseTypeID", jFCaseTypeID);
			AddParameter(cmd, "FormID", formID);
			FormMapJFCaseTypeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(FormMapJFCaseTypeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[FormMapJFCaseType] (" +
			"[JFCaseTypeID], " + 
			"[FormID], " + 
			"[SortOrder]			" + 
			") VALUES (" +
			CreateSqlParameterName("JFCaseTypeID") + ", " +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("SortOrder") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
			AddParameter(cmd, "FormID", value.FormID);
			AddParameter(cmd, "SortOrder", value.SortOrder);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(FormMapJFCaseTypeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[FormMapJFCaseType] (" +
			"[JFCaseTypeID], " + 
			"[FormID], " + 
			"[SortOrder]			" + 
			") VALUES (" +
			CreateSqlParameterName("JFCaseTypeID") + ", " +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("SortOrder") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
			AddParameter(cmd, "FormID", value.FormID);
			AddParameter(cmd, "SortOrder", value.SortOrder);
			cmd.ExecuteNonQuery();
		}
		public bool Update(FormMapJFCaseTypeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetJFCaseTypeID == true && value._IsSetFormID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[FormMapJFCaseType] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID")+ " AND [FormID]=" + CreateSqlParameterName("FormID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
					AddParameter(cmd, "FormID", value.FormID);
					AddParameter(cmd, "SortOrder", value.SortOrder);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(JFCaseTypeID,FormID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(FormMapJFCaseTypeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetJFCaseTypeID == true && value._IsSetFormID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[FormMapJFCaseType] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID")+ " AND [FormID]=" + CreateSqlParameterName("FormID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
					AddParameter(cmd, "FormID", value.FormID);
					AddParameter(cmd, "SortOrder", value.SortOrder);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(JFCaseTypeID,FormID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int jFCaseTypeID, int formID)
		{
			string whereSql = "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID") + " AND [FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "JFCaseTypeID", jFCaseTypeID);
			AddParameter(cmd, "FormID", formID);
			return 0 < cmd.ExecuteNonQuery();
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
		public int DeleteByFormID(int formID)
		{
			return CreateDeleteByFormIDCommand(formID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFormIDCommand(int formID)
		{
			string whereSql = "";
			whereSql += "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FormID", formID);
			return cmd;
		}
		protected FormMapJFCaseTypeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected FormMapJFCaseTypeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected FormMapJFCaseTypeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int jFCaseTypeIDColumnIndex = reader.GetOrdinal("JFCaseTypeID");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					FormMapJFCaseTypeRow record = new FormMapJFCaseTypeRow();
					recordList.Add(record);
					record.JFCaseTypeID =  Convert.ToInt32(reader.GetValue(jFCaseTypeIDColumnIndex));
					record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));
					record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FormMapJFCaseTypeRow[])(recordList.ToArray(typeof(FormMapJFCaseTypeRow)));
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
				case "JFCaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SortOrder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

