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
	public partial class CaseApplicantRequestExtensionCollection_Base : MarshalByRefObject
	{
		public const string TransactionIDColumnName = "TransactionID";
		public const string AdditionalDataJsonColumnName = "AdditionalDataJson";
		public const string RemarkColumnName = "Remark";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseApplicantRequestExtensionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseApplicantRequestExtensionRow[] GetAll()
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
			"[TransactionID],"+
			"[AdditionalDataJson],"+
			"[Remark]"+
			" FROM [dbo].[CaseApplicantRequestExtension]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseApplicantRequestExtension]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseApplicantRequestExtension"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AdditionalDataJson",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			return dataTable;
		}
		public virtual CaseApplicantRequestExtensionRow[] GetByTransactionID(int transactionID)
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
		public CaseApplicantRequestExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseApplicantRequestExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseApplicantRequestExtensionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseApplicantRequestExtensionRow"/> objects.</returns>
		public virtual CaseApplicantRequestExtensionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseApplicantRequestExtension]", top);
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
		public CaseApplicantRequestExtensionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseApplicantRequestExtensionRow[] rows = null;
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
		public DataTable GetCaseApplicantRequestExtensionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TransactionID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TransactionID) AS TotalRow FROM [dbo].[CaseApplicantRequestExtension] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionID,AdditionalDataJson,Remark," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseApplicantRequestExtension] " + whereSql +
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
		public CaseApplicantRequestExtensionItemsPaging GetCaseApplicantRequestExtensionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
		CaseApplicantRequestExtensionItemsPaging obj = new CaseApplicantRequestExtensionItemsPaging();
		DataTable dt = GetCaseApplicantRequestExtensionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseApplicantRequestExtensionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseApplicantRequestExtensionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.AdditionalDataJson = dt.Rows[i]["AdditionalDataJson"].ToString();
			record.Remark = dt.Rows[i]["Remark"].ToString();
			recordList.Add(record);
		}
		obj.caseApplicantRequestExtensionItems = (CaseApplicantRequestExtensionItems[])(recordList.ToArray(typeof(CaseApplicantRequestExtensionItems)));
		return obj;
		}
		public CaseApplicantRequestExtensionRow GetByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionID", transactionID);
			CaseApplicantRequestExtensionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseApplicantRequestExtensionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantRequestExtension] (" +
			"[TransactionID], " + 
			"[AdditionalDataJson], " + 
			"[Remark]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("AdditionalDataJson") + ", " +
			CreateSqlParameterName("Remark") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "AdditionalDataJson", value.IsAdditionalDataJsonNull ? DBNull.Value : (object)value.AdditionalDataJson);
			AddParameter(cmd, "Remark", value.IsRemarkNull ? DBNull.Value : (object)value.Remark);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseApplicantRequestExtensionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantRequestExtension] (" +
			"[TransactionID], " + 
			"[AdditionalDataJson], " + 
			"[Remark]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("AdditionalDataJson") + ", " +
			CreateSqlParameterName("Remark") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "AdditionalDataJson", value.IsAdditionalDataJsonNull ? DBNull.Value : (object)value.AdditionalDataJson);
			AddParameter(cmd, "Remark", value.IsRemarkNull ? DBNull.Value : (object)value.Remark);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseApplicantRequestExtensionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAdditionalDataJson)
				{
					strUpdate += "[AdditionalDataJson]=" + CreateSqlParameterName("AdditionalDataJson") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantRequestExtension] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "AdditionalDataJson", value.AdditionalDataJson);
					AddParameter(cmd, "Remark", value.Remark);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseApplicantRequestExtensionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAdditionalDataJson)
				{
					strUpdate += "[AdditionalDataJson]=" + CreateSqlParameterName("AdditionalDataJson") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantRequestExtension] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "AdditionalDataJson", Sanitizer.GetSafeHtmlFragment(value.AdditionalDataJson));
					AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionID", transactionID);
			return 0 < cmd.ExecuteNonQuery();
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
		protected CaseApplicantRequestExtensionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseApplicantRequestExtensionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseApplicantRequestExtensionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int additionalDataJsonColumnIndex = reader.GetOrdinal("AdditionalDataJson");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					CaseApplicantRequestExtensionRow record = new CaseApplicantRequestExtensionRow();
					recordList.Add(record);
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(additionalDataJsonColumnIndex)) record.AdditionalDataJson =  Convert.ToString(reader.GetValue(additionalDataJsonColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

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
			return (CaseApplicantRequestExtensionRow[])(recordList.ToArray(typeof(CaseApplicantRequestExtensionRow)));
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
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AdditionalDataJson":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

