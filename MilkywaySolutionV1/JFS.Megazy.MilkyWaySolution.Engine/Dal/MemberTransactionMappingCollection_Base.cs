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
	public partial class MemberTransactionMappingCollection_Base : MarshalByRefObject
	{
		public const string RowIDColumnName = "RowID";
		public const string MemberIDColumnName = "MemberID";
		public const string TransactionIDColumnName = "TransactionID";
		private int _processID;
		public SqlCommand cmd = null;
		public MemberTransactionMappingCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual MemberTransactionMappingRow[] GetAll()
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
			"[RowID],"+
			"[MemberID],"+
			"[TransactionID]"+
			" FROM [dbo].[MemberTransactionMapping]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[MemberTransactionMapping]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "MemberTransactionMapping"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("RowID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MemberID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual MemberTransactionMappingRow[] GetByMemberID(int memberID)
		{
			return MapRecords(CreateGetByMemberIDCommand(memberID));
		}
		public virtual DataTable GetByMemberIDAsDataTable(int memberID)
		{
			return MapRecordsToDataTable(CreateGetByMemberIDCommand(memberID));
		}
		protected virtual IDbCommand CreateGetByMemberIDCommand(int memberID)
		{
			string whereSql = "";
			whereSql += "[MemberID]=" + CreateSqlParameterName("MemberID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MemberID", memberID);
			return cmd;
		}
		public virtual MemberTransactionMappingRow[] GetByTransactionID(int transactionID)
		{
			return MapRecords(CreateGetByTransactionIDCommand(transactionID));
		}
		public virtual DataTable GetByTransactionIDAsDataTable(int transactionID)
		{
			return MapRecordsToDataTable(CreateGetByTransactionIDCommand(transactionID));
		}
		protected virtual IDbCommand CreateGetByTransactionIDCommand(int transactionID)
		{
			string whereSql = "";
			whereSql += "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionID", transactionID);
			return cmd;
		}
		public MemberTransactionMappingRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual MemberTransactionMappingRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="MemberTransactionMappingRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MemberTransactionMappingRow"/> objects.</returns>
		public virtual MemberTransactionMappingRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[MemberTransactionMapping]", top);
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
		public MemberTransactionMappingRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			MemberTransactionMappingRow[] rows = null;
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
		public DataTable GetMemberTransactionMappingPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "RowID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "RowID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(RowID) AS TotalRow FROM [dbo].[MemberTransactionMapping] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,RowID,MemberID,TransactionID," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[MemberTransactionMapping] " + whereSql +
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
		public MemberTransactionMappingItemsPaging GetMemberTransactionMappingPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "RowID")
		{
		MemberTransactionMappingItemsPaging obj = new MemberTransactionMappingItemsPaging();
		DataTable dt = GetMemberTransactionMappingPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		MemberTransactionMappingItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new MemberTransactionMappingItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.RowID = Convert.ToInt32(dt.Rows[i]["RowID"]);
			record.MemberID = Convert.ToInt32(dt.Rows[i]["MemberID"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			recordList.Add(record);
		}
		obj.memberTransactionmappingItems = (MemberTransactionMappingItems[])(recordList.ToArray(typeof(MemberTransactionMappingItems)));
		return obj;
		}
		public MemberTransactionMappingRow GetByPrimaryKey(int memberID, int transactionID)
		{
			string whereSql = "[MemberID]=" + CreateSqlParameterName("MemberID") + " AND [TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MemberID", memberID);
			AddParameter(cmd, "TransactionID", transactionID);
			MemberTransactionMappingRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(MemberTransactionMappingRow value)		{
			string sqlStr = "INSERT INTO [dbo].[MemberTransactionMapping] (" +
			"[MemberID], " + 
			"[TransactionID]			" + 
			") VALUES (" +
			CreateSqlParameterName("MemberID") + ", " +
			CreateSqlParameterName("TransactionID") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MemberID", value.MemberID);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(MemberTransactionMappingRow value)		{
			string sqlStr = "INSERT INTO [dbo].[MemberTransactionMapping] (" +
			"[MemberID], " + 
			"[TransactionID]			" + 
			") VALUES (" +
			CreateSqlParameterName("MemberID") + ", " +
			CreateSqlParameterName("TransactionID") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MemberID", value.MemberID);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			cmd.ExecuteNonQuery();
		}
		public bool Update(MemberTransactionMappingRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMemberID == true && value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetRowID)
				{
					strUpdate += "[RowID]=" + CreateSqlParameterName("RowID") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[MemberTransactionMapping] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MemberID]=" + CreateSqlParameterName("MemberID")+ " AND [TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "RowID", value.RowID);
					AddParameter(cmd, "MemberID", value.MemberID);
					AddParameter(cmd, "TransactionID", value.TransactionID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MemberID,TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(MemberTransactionMappingRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMemberID == true && value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetRowID)
				{
					strUpdate += "[RowID]=" + CreateSqlParameterName("RowID") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[MemberTransactionMapping] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MemberID]=" + CreateSqlParameterName("MemberID")+ " AND [TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "RowID", value.RowID);
					AddParameter(cmd, "MemberID", value.MemberID);
					AddParameter(cmd, "TransactionID", value.TransactionID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MemberID,TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int memberID, int transactionID)
		{
			string whereSql = "[MemberID]=" + CreateSqlParameterName("MemberID") + " AND [TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MemberID", memberID);
			AddParameter(cmd, "TransactionID", transactionID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByMemberID(int memberID)
		{
			return CreateDeleteByMemberIDCommand(memberID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByMemberIDCommand(int memberID)
		{
			string whereSql = "";
			whereSql += "[MemberID]=" + CreateSqlParameterName("MemberID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MemberID", memberID);
			return cmd;
		}
		public int DeleteByTransactionID(int transactionID)
		{
			return CreateDeleteByTransactionIDCommand(transactionID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTransactionIDCommand(int transactionID)
		{
			string whereSql = "";
			whereSql += "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionID", transactionID);
			return cmd;
		}
		protected MemberTransactionMappingRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected MemberTransactionMappingRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected MemberTransactionMappingRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int rowIDColumnIndex = reader.GetOrdinal("RowID");
			int memberIDColumnIndex = reader.GetOrdinal("MemberID");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					MemberTransactionMappingRow record = new MemberTransactionMappingRow();
					recordList.Add(record);
					record.RowID =  Convert.ToInt32(reader.GetValue(rowIDColumnIndex));
					record.MemberID =  Convert.ToInt32(reader.GetValue(memberIDColumnIndex));
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
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
			return (MemberTransactionMappingRow[])(recordList.ToArray(typeof(MemberTransactionMappingRow)));
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
				case "RowID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MemberID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionID":
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

