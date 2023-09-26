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
	public partial class LawyerAttachFileCollection_Base : MarshalByRefObject
	{
		public const string LawyerIDColumnName = "LawyerID";
		public const string AttachFileIDColumnName = "AttachFileID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string TitleColumnName = "Title";
		private int _processID;
		public SqlCommand cmd = null;
		public LawyerAttachFileCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual LawyerAttachFileRow[] GetAll()
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
			"[LawyerID],"+
			"[AttachFileID],"+
			"[ModifiedDate],"+
			"[Title]"+
			" FROM [dbo].[LawyerAttachFile]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[LawyerAttachFile]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "LawyerAttachFile"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("LawyerID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AttachFileID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			return dataTable;
		}
		public virtual LawyerAttachFileRow[] GetByLawyerID(int lawyerID)
		{
			return MapRecords(CreateGetByLawyerIDCommand(lawyerID));
		}
		public virtual DataTable GetByLawyerIDAsDataTable(int lawyerID)
		{
			return MapRecordsToDataTable(CreateGetByLawyerIDCommand(lawyerID));
		}
		protected virtual IDbCommand CreateGetByLawyerIDCommand(int lawyerID)
		{
			string whereSql = "";
			whereSql += "[LawyerID]=" + CreateSqlParameterName("LawyerID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LawyerID", lawyerID);
			return cmd;
		}
		public virtual LawyerAttachFileRow[] GetByAttachFileID(int attachFileID)
		{
			return MapRecords(CreateGetByAttachFileIDCommand(attachFileID));
		}
		public virtual DataTable GetByAttachFileIDAsDataTable(int attachFileID)
		{
			return MapRecordsToDataTable(CreateGetByAttachFileIDCommand(attachFileID));
		}
		protected virtual IDbCommand CreateGetByAttachFileIDCommand(int attachFileID)
		{
			string whereSql = "";
			whereSql += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AttachFileID", attachFileID);
			return cmd;
		}
		public LawyerAttachFileRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual LawyerAttachFileRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="LawyerAttachFileRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LawyerAttachFileRow"/> objects.</returns>
		public virtual LawyerAttachFileRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[LawyerAttachFile]", top);
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
		public LawyerAttachFileRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			LawyerAttachFileRow[] rows = null;
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
		public DataTable GetLawyerAttachFilePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LawyerID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "LawyerID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(LawyerID) AS TotalRow FROM [dbo].[LawyerAttachFile] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,LawyerID,AttachFileID,ModifiedDate,Title," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[LawyerAttachFile] " + whereSql +
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
		public LawyerAttachFileItemsPaging GetLawyerAttachFilePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LawyerID")
		{
		LawyerAttachFileItemsPaging obj = new LawyerAttachFileItemsPaging();
		DataTable dt = GetLawyerAttachFilePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		LawyerAttachFileItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new LawyerAttachFileItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.LawyerID = Convert.ToInt32(dt.Rows[i]["LawyerID"]);
			record.AttachFileID = Convert.ToInt32(dt.Rows[i]["AttachFileID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			recordList.Add(record);
		}
		obj.lawyerAttachFileItems = (LawyerAttachFileItems[])(recordList.ToArray(typeof(LawyerAttachFileItems)));
		return obj;
		}
		public LawyerAttachFileRow GetByPrimaryKey(int lawyerID, int attachFileID)
		{
			string whereSql = "[LawyerID]=" + CreateSqlParameterName("LawyerID") + " AND [AttachFileID]=" + CreateSqlParameterName("AttachFileID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LawyerID", lawyerID);
			AddParameter(cmd, "AttachFileID", attachFileID);
			LawyerAttachFileRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(LawyerAttachFileRow value)		{
			string sqlStr = "INSERT INTO [dbo].[LawyerAttachFile] (" +
			"[LawyerID], " + 
			"[AttachFileID], " + 
			"[ModifiedDate], " + 
			"[Title]			" + 
			") VALUES (" +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("AttachFileID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("Title") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "LawyerID", value.LawyerID);
			AddParameter(cmd, "AttachFileID", value.AttachFileID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "Title", value.Title);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(LawyerAttachFileRow value)		{
			string sqlStr = "INSERT INTO [dbo].[LawyerAttachFile] (" +
			"[LawyerID], " + 
			"[AttachFileID], " + 
			"[ModifiedDate], " + 
			"[Title]			" + 
			") VALUES (" +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("AttachFileID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("Title") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "LawyerID", value.LawyerID);
			AddParameter(cmd, "AttachFileID", value.AttachFileID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			cmd.ExecuteNonQuery();
		}
		public bool Update(LawyerAttachFileRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetLawyerID == true && value._IsSetAttachFileID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[LawyerAttachFile] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID")+ " AND [AttachFileID]=" + CreateSqlParameterName("AttachFileID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "LawyerID", value.LawyerID);
					AddParameter(cmd, "AttachFileID", value.AttachFileID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "Title", value.Title);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(LawyerID,AttachFileID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(LawyerAttachFileRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetLawyerID == true && value._IsSetAttachFileID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[LawyerAttachFile] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID")+ " AND [AttachFileID]=" + CreateSqlParameterName("AttachFileID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "LawyerID", value.LawyerID);
					AddParameter(cmd, "AttachFileID", value.AttachFileID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(LawyerID,AttachFileID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int lawyerID, int attachFileID)
		{
			string whereSql = "[LawyerID]=" + CreateSqlParameterName("LawyerID") + " AND [AttachFileID]=" + CreateSqlParameterName("AttachFileID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LawyerID", lawyerID);
			AddParameter(cmd, "AttachFileID", attachFileID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByLawyerID(int lawyerID)
		{
			return CreateDeleteByLawyerIDCommand(lawyerID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByLawyerIDCommand(int lawyerID)
		{
			string whereSql = "";
			whereSql += "[LawyerID]=" + CreateSqlParameterName("LawyerID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LawyerID", lawyerID);
			return cmd;
		}
		public int DeleteByAttachFileID(int attachFileID)
		{
			return CreateDeleteByAttachFileIDCommand(attachFileID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAttachFileIDCommand(int attachFileID)
		{
			string whereSql = "";
			whereSql += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AttachFileID", attachFileID);
			return cmd;
		}
		protected LawyerAttachFileRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected LawyerAttachFileRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected LawyerAttachFileRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int lawyerIDColumnIndex = reader.GetOrdinal("LawyerID");
			int attachFileIDColumnIndex = reader.GetOrdinal("AttachFileID");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int titleColumnIndex = reader.GetOrdinal("Title");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					LawyerAttachFileRow record = new LawyerAttachFileRow();
					recordList.Add(record);
					record.LawyerID =  Convert.ToInt32(reader.GetValue(lawyerIDColumnIndex));
					record.AttachFileID =  Convert.ToInt32(reader.GetValue(attachFileIDColumnIndex));
					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LawyerAttachFileRow[])(recordList.ToArray(typeof(LawyerAttachFileRow)));
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
				case "LawyerID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AttachFileID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Title":
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

