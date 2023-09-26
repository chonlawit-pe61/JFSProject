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
	public partial class MemberRenewCollection_Base : MarshalByRefObject
	{
		public const string TokenColumnName = "Token";
		public const string MemberIDColumnName = "MemberID";
		public const string VerificationTypeColumnName = "VerificationType";
		public const string ExpireDateColumnName = "ExpireDate";
		private int _processID;
		public SqlCommand cmd = null;
		public MemberRenewCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual MemberRenewRow[] GetAll()
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
			"[Token],"+
			"[MemberID],"+
			"[VerificationType],"+
			"[ExpireDate]"+
			" FROM [dbo].[MemberRenew]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[MemberRenew]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "MemberRenew"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("Token",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MemberID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VerificationType",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ExpireDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual MemberRenewRow[] GetByMemberID(int memberID)
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
		public MemberRenewRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual MemberRenewRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="MemberRenewRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MemberRenewRow"/> objects.</returns>
		public virtual MemberRenewRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[MemberRenew]", top);
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
		public MemberRenewRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			MemberRenewRow[] rows = null;
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
		public DataTable GetMemberRenewPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "Token")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "Token";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[MemberRenew] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,Token,MemberID,VerificationType,ExpireDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [MemberRenew].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[MemberRenew] " + whereSql +
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
		public MemberRenewItemsPaging GetMemberRenewPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "Token")
		{
		MemberRenewItemsPaging obj = new MemberRenewItemsPaging();
		DataTable dt = GetMemberRenewPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		MemberRenewItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new MemberRenewItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.Token = dt.Rows[i]["Token"].ToString();
			record.MemberID = Convert.ToInt32(dt.Rows[i]["MemberID"]);
			record.VerificationType = dt.Rows[i]["VerificationType"].ToString();
			record.ExpireDate = Convert.ToDateTime(dt.Rows[i]["ExpireDate"]);
			recordList.Add(record);
		}
		obj.memberRenewItems = (MemberRenewItems[])(recordList.ToArray(typeof(MemberRenewItems)));
		return obj;
		}
		public MemberRenewRow GetByPrimaryKey(string token)
		{
			string whereSql = "[Token]=" + CreateSqlParameterName("Token");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "Token", token);
			MemberRenewRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(MemberRenewRow value)		{
			string sqlStr = "INSERT INTO [dbo].[MemberRenew] (" +
			"[Token], " + 
			"[MemberID], " + 
			"[VerificationType], " + 
			"[ExpireDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("Token") + ", " +
			CreateSqlParameterName("MemberID") + ", " +
			CreateSqlParameterName("VerificationType") + ", " +
			CreateSqlParameterName("ExpireDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Token",value.Token);
			AddParameter(cmd, "MemberID", value.MemberID);
			AddParameter(cmd, "VerificationType",value.VerificationType);
			AddParameter(cmd, "ExpireDate", value.IsExpireDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ExpireDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(MemberRenewRow value)		{
			string sqlStr = "INSERT INTO [dbo].[MemberRenew] (" +
			"[Token], " + 
			"[MemberID], " + 
			"[VerificationType], " + 
			"[ExpireDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("Token") + ", " +
			CreateSqlParameterName("MemberID") + ", " +
			CreateSqlParameterName("VerificationType") + ", " +
			CreateSqlParameterName("ExpireDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Token", Sanitizer.GetSafeHtmlFragment(value.Token));
			AddParameter(cmd, "MemberID", value.MemberID);
			AddParameter(cmd, "VerificationType", Sanitizer.GetSafeHtmlFragment(value.VerificationType));
			AddParameter(cmd, "ExpireDate", value.IsExpireDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ExpireDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(MemberRenewRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetToken == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMemberID)
				{
					strUpdate += "[MemberID]=" + CreateSqlParameterName("MemberID") + ",";
				}
				if (value._IsSetVerificationType)
				{
					strUpdate += "[VerificationType]=" + CreateSqlParameterName("VerificationType") + ",";
				}
				if (value._IsSetExpireDate)
				{
					strUpdate += "[ExpireDate]=" + CreateSqlParameterName("ExpireDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[MemberRenew] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[Token]=" + CreateSqlParameterName("Token");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "Token",value.Token);
					AddParameter(cmd, "MemberID", value.MemberID);
					AddParameter(cmd, "VerificationType",value.VerificationType);
					AddParameter(cmd, "ExpireDate", value.IsExpireDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ExpireDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(Token)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(MemberRenewRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetToken == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMemberID)
				{
					strUpdate += "[MemberID]=" + CreateSqlParameterName("MemberID") + ",";
				}
				if (value._IsSetVerificationType)
				{
					strUpdate += "[VerificationType]=" + CreateSqlParameterName("VerificationType") + ",";
				}
				if (value._IsSetExpireDate)
				{
					strUpdate += "[ExpireDate]=" + CreateSqlParameterName("ExpireDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[MemberRenew] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[Token]=" + CreateSqlParameterName("Token");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "Token", Sanitizer.GetSafeHtmlFragment(value.Token));
					AddParameter(cmd, "MemberID", value.MemberID);
					AddParameter(cmd, "VerificationType", Sanitizer.GetSafeHtmlFragment(value.VerificationType));
					AddParameter(cmd, "ExpireDate", value.IsExpireDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ExpireDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(Token)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(string token)
		{
			string whereSql = "[Token]=" + CreateSqlParameterName("Token");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "Token", token);
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
		protected MemberRenewRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected MemberRenewRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected MemberRenewRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int tokenColumnIndex = reader.GetOrdinal("Token");
			int memberIDColumnIndex = reader.GetOrdinal("MemberID");
			int verificationTypeColumnIndex = reader.GetOrdinal("VerificationType");
			int expireDateColumnIndex = reader.GetOrdinal("ExpireDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					MemberRenewRow record = new MemberRenewRow();
					recordList.Add(record);
					record.Token =  Convert.ToString(reader.GetValue(tokenColumnIndex));
					record.MemberID =  Convert.ToInt32(reader.GetValue(memberIDColumnIndex));
					record.VerificationType =  Convert.ToString(reader.GetValue(verificationTypeColumnIndex));
					record.ExpireDate =  Convert.ToDateTime(reader.GetValue(expireDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MemberRenewRow[])(recordList.ToArray(typeof(MemberRenewRow)));
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
				case "Token":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MemberID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "VerificationType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ExpireDate":
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

