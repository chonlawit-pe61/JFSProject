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
	public partial class BracketCollection_Base : MarshalByRefObject
	{
		public const string BracketIDColumnName = "BracketID";
		public const string MatterIDColumnName = "MatterID";
		public const string BracketNameColumnName = "BracketName";
		public const string BracketDescriptionColumnName = "BracketDescription";
		private int _processID;
		public SqlCommand cmd = null;
		public BracketCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual BracketRow[] GetAll()
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
			"[BracketID],"+
			"[MatterID],"+
			"[BracketName],"+
			"[BracketDescription]"+
			" FROM [dbo].[Bracket]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Bracket]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Bracket"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("BracketID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MatterID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("BracketName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("BracketDescription",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			return dataTable;
		}
		public virtual BracketRow[] GetByMatterID(int matterID)
		{
			return MapRecords(CreateGetByMatterIDCommand(matterID));
		}
		public virtual DataTable GetByMatterIDAsDataTable(int matterID)
		{
			return MapRecordsToDataTable(CreateGetByMatterIDCommand(matterID));
		}
		protected virtual IDbCommand CreateGetByMatterIDCommand(int matterID)
		{
			string whereSql = "";
			whereSql += "[MatterID]=" + CreateSqlParameterName("MatterID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MatterID", matterID);
			return cmd;
		}
		public BracketRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual BracketRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="BracketRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="BracketRow"/> objects.</returns>
		public virtual BracketRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Bracket]", top);
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
		public BracketRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			BracketRow[] rows = null;
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
		public DataTable GetBracketPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "BracketID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "BracketID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(BracketID) AS TotalRow FROM [dbo].[Bracket] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,BracketID,MatterID,BracketName,BracketDescription," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [Bracket].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Bracket] " + whereSql +
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
		public BracketItemsPaging GetBracketPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "BracketID")
		{
		BracketItemsPaging obj = new BracketItemsPaging();
		DataTable dt = GetBracketPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		BracketItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new BracketItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.BracketID = Convert.ToInt32(dt.Rows[i]["BracketID"]);
			if (dt.Rows[i]["MatterID"] != DBNull.Value)
			record.MatterID = Convert.ToInt32(dt.Rows[i]["MatterID"]);
			record.BracketName = dt.Rows[i]["BracketName"].ToString();
			record.BracketDescription = dt.Rows[i]["BracketDescription"].ToString();
			recordList.Add(record);
		}
		obj.bracketItems = (BracketItems[])(recordList.ToArray(typeof(BracketItems)));
		return obj;
		}
		public BracketRow GetByPrimaryKey(int bracketID)
		{
			string whereSql = "[BracketID]=" + CreateSqlParameterName("BracketID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "BracketID", bracketID);
			BracketRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(BracketRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Bracket] (" +
			"[BracketID], " + 
			"[MatterID], " + 
			"[BracketName], " + 
			"[BracketDescription]			" + 
			") VALUES (" +
			CreateSqlParameterName("BracketID") + ", " +
			CreateSqlParameterName("MatterID") + ", " +
			CreateSqlParameterName("BracketName") + ", " +
			CreateSqlParameterName("BracketDescription") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "BracketID", value.BracketID);
			AddParameter(cmd, "MatterID", value.IsMatterIDNull ? DBNull.Value : (object)value.MatterID);
			AddParameter(cmd, "BracketName", value.BracketName);
			AddParameter(cmd, "BracketDescription", value.BracketDescription);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(BracketRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Bracket] (" +
			"[BracketID], " + 
			"[MatterID], " + 
			"[BracketName], " + 
			"[BracketDescription]			" + 
			") VALUES (" +
			CreateSqlParameterName("BracketID") + ", " +
			CreateSqlParameterName("MatterID") + ", " +
			CreateSqlParameterName("BracketName") + ", " +
			CreateSqlParameterName("BracketDescription") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "BracketID", value.BracketID);
			AddParameter(cmd, "MatterID", value.IsMatterIDNull ? DBNull.Value : (object)value.MatterID);
			AddParameter(cmd, "BracketName", Sanitizer.GetSafeHtmlFragment(value.BracketName));
			AddParameter(cmd, "BracketDescription", Sanitizer.GetSafeHtmlFragment(value.BracketDescription));
			cmd.ExecuteNonQuery();
		}
		public bool Update(BracketRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetBracketID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMatterID)
				{
					strUpdate += "[MatterID]=" + CreateSqlParameterName("MatterID") + ",";
				}
				if (value._IsSetBracketName)
				{
					strUpdate += "[BracketName]=" + CreateSqlParameterName("BracketName") + ",";
				}
				if (value._IsSetBracketDescription)
				{
					strUpdate += "[BracketDescription]=" + CreateSqlParameterName("BracketDescription") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Bracket] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[BracketID]=" + CreateSqlParameterName("BracketID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "BracketID", value.BracketID);
					AddParameter(cmd, "MatterID", value.IsMatterIDNull ? DBNull.Value : (object)value.MatterID);
					AddParameter(cmd, "BracketName", value.BracketName);
					AddParameter(cmd, "BracketDescription", value.BracketDescription);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(BracketID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(BracketRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetBracketID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMatterID)
				{
					strUpdate += "[MatterID]=" + CreateSqlParameterName("MatterID") + ",";
				}
				if (value._IsSetBracketName)
				{
					strUpdate += "[BracketName]=" + CreateSqlParameterName("BracketName") + ",";
				}
				if (value._IsSetBracketDescription)
				{
					strUpdate += "[BracketDescription]=" + CreateSqlParameterName("BracketDescription") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Bracket] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[BracketID]=" + CreateSqlParameterName("BracketID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "BracketID", value.BracketID);
					AddParameter(cmd, "MatterID", value.IsMatterIDNull ? DBNull.Value : (object)value.MatterID);
					AddParameter(cmd, "BracketName", Sanitizer.GetSafeHtmlFragment(value.BracketName));
					AddParameter(cmd, "BracketDescription", Sanitizer.GetSafeHtmlFragment(value.BracketDescription));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(BracketID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int bracketID)
		{
			string whereSql = "[BracketID]=" + CreateSqlParameterName("BracketID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "BracketID", bracketID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByMatterID(int matterID)
		{
			return DeleteByMatterID(matterID, false);
		}
		public int DeleteByMatterID(int matterID, bool matterIDNull)
		{
			return CreateDeleteByMatterIDCommand(matterID, matterIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByMatterIDCommand(int matterID, bool matterIDNull)
		{
			string whereSql = "";
			if (matterIDNull)
				whereSql += "[MatterID] IS NULL";
			else
				whereSql += "[MatterID]=" + CreateSqlParameterName("MatterID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!matterIDNull)
				AddParameter(cmd, "MatterID", matterID);
			return cmd;
		}
		protected BracketRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected BracketRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected BracketRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int bracketIDColumnIndex = reader.GetOrdinal("BracketID");
			int matterIDColumnIndex = reader.GetOrdinal("MatterID");
			int bracketNameColumnIndex = reader.GetOrdinal("BracketName");
			int bracketDescriptionColumnIndex = reader.GetOrdinal("BracketDescription");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					BracketRow record = new BracketRow();
					recordList.Add(record);
					record.BracketID =  Convert.ToInt32(reader.GetValue(bracketIDColumnIndex));
					if (!reader.IsDBNull(matterIDColumnIndex)) record.MatterID =  Convert.ToInt32(reader.GetValue(matterIDColumnIndex));

					if (!reader.IsDBNull(bracketNameColumnIndex)) record.BracketName =  Convert.ToString(reader.GetValue(bracketNameColumnIndex));

					if (!reader.IsDBNull(bracketDescriptionColumnIndex)) record.BracketDescription =  Convert.ToString(reader.GetValue(bracketDescriptionColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (BracketRow[])(recordList.ToArray(typeof(BracketRow)));
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
				case "BracketID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MatterID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "BracketName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "BracketDescription":
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

