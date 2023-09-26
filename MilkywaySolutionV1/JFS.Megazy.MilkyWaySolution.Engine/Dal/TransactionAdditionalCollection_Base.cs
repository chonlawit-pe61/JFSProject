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
	public partial class TransactionAdditionalCollection_Base : MarshalByRefObject
	{
		public const string TransactionIDColumnName = "TransactionID";
		public const string PayerColumnName = "Payer";
		public const string PayeeColumnName = "Payee";
		public const string CourtNameColumnName = "CourtName";
		public const string CourtLevelColumnName = "CourtLevel";
		public const string LawyerAddressLineColumnName = "LawyerAddressLine";
		public const string BankAccountNameColumnName = "BankAccountName";
		public const string BankAccountNoColumnName = "BankAccountNo";
		public const string BankNameColumnName = "BankName";
		public const string BankBranchColumnName = "BankBranch";
		public const string BankAccountTypeColumnName = "BankAccountType";
		public const string PaymentListJsonColumnName = "PaymentListJson";
		public const string RefTransactionIDColumnName = "RefTransactionID";
		public const string IsRequestRefundColumnName = "IsRequestRefund";
		private int _processID;
		public SqlCommand cmd = null;
		public TransactionAdditionalCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual TransactionAdditionalRow[] GetAll()
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
			"[Payer],"+
			"[Payee],"+
			"[CourtName],"+
			"[CourtLevel],"+
			"[LawyerAddressLine],"+
			"[BankAccountName],"+
			"[BankAccountNo],"+
			"[BankName],"+
			"[BankBranch],"+
			"[BankAccountType],"+
			"[PaymentListJson],"+
			"[RefTransactionID],"+
			"[IsRequestRefund]"+
			" FROM [dbo].[TransactionAdditional]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[TransactionAdditional]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "TransactionAdditional"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Payer",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("Payee",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("CourtName",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("CourtLevel",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LawyerAddressLine",Type.GetType("System.String"));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("BankAccountName",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("BankAccountNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("BankName",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("BankBranch",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("BankAccountType",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("PaymentListJson",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("RefTransactionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsRequestRefund",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public TransactionAdditionalRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual TransactionAdditionalRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="TransactionAdditionalRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TransactionAdditionalRow"/> objects.</returns>
		public virtual TransactionAdditionalRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[TransactionAdditional]", top);
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
		public TransactionAdditionalRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			TransactionAdditionalRow[] rows = null;
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
		public DataTable GetTransactionAdditionalPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[TransactionAdditional] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionID,Payer,Payee,CourtName,CourtLevel,LawyerAddressLine,BankAccountName,BankAccountNo,BankName,BankBranch,BankAccountType,PaymentListJson,RefTransactionID,IsRequestRefund," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [TransactionAdditional].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[TransactionAdditional] " + whereSql +
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
		public TransactionAdditionalItemsPaging GetTransactionAdditionalPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
		TransactionAdditionalItemsPaging obj = new TransactionAdditionalItemsPaging();
		DataTable dt = GetTransactionAdditionalPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		TransactionAdditionalItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new TransactionAdditionalItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.Payer = dt.Rows[i]["Payer"].ToString();
			record.Payee = dt.Rows[i]["Payee"].ToString();
			record.CourtName = dt.Rows[i]["CourtName"].ToString();
			record.CourtLevel = dt.Rows[i]["CourtLevel"].ToString();
			record.LawyerAddressLine = dt.Rows[i]["LawyerAddressLine"].ToString();
			record.BankAccountName = dt.Rows[i]["BankAccountName"].ToString();
			record.BankAccountNo = dt.Rows[i]["BankAccountNo"].ToString();
			record.BankName = dt.Rows[i]["BankName"].ToString();
			record.BankBranch = dt.Rows[i]["BankBranch"].ToString();
			record.BankAccountType = dt.Rows[i]["BankAccountType"].ToString();
			record.PaymentListJson = dt.Rows[i]["PaymentListJson"].ToString();
			if (dt.Rows[i]["RefTransactionID"] != DBNull.Value)
			record.RefTransactionID = Convert.ToInt32(dt.Rows[i]["RefTransactionID"]);
			if (dt.Rows[i]["IsRequestRefund"] != DBNull.Value)
			record.IsRequestRefund = Convert.ToBoolean(dt.Rows[i]["IsRequestRefund"]);
			recordList.Add(record);
		}
		obj.transactionAdditionalItems = (TransactionAdditionalItems[])(recordList.ToArray(typeof(TransactionAdditionalItems)));
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
			" FROM [dbo].[TransactionAdditional]"; 
			if (null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql; 
			 return CreateCommand(sql); 
		}
		public TransactionAdditionalRow GetByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionID", transactionID);
			TransactionAdditionalRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(TransactionAdditionalRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TransactionAdditional] (" +
			"[TransactionID], " + 
			"[Payer], " + 
			"[Payee], " + 
			"[CourtName], " + 
			"[CourtLevel], " + 
			"[LawyerAddressLine], " + 
			"[BankAccountName], " + 
			"[BankAccountNo], " + 
			"[BankName], " + 
			"[BankBranch], " + 
			"[BankAccountType], " + 
			"[PaymentListJson], " + 
			"[RefTransactionID], " + 
			"[IsRequestRefund]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("Payer") + ", " +
			CreateSqlParameterName("Payee") + ", " +
			CreateSqlParameterName("CourtName") + ", " +
			CreateSqlParameterName("CourtLevel") + ", " +
			CreateSqlParameterName("LawyerAddressLine") + ", " +
			CreateSqlParameterName("BankAccountName") + ", " +
			CreateSqlParameterName("BankAccountNo") + ", " +
			CreateSqlParameterName("BankName") + ", " +
			CreateSqlParameterName("BankBranch") + ", " +
			CreateSqlParameterName("BankAccountType") + ", " +
			CreateSqlParameterName("PaymentListJson") + ", " +
			CreateSqlParameterName("RefTransactionID") + ", " +
			CreateSqlParameterName("IsRequestRefund") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "Payer", value.Payer);
			AddParameter(cmd, "Payee", value.Payee);
			AddParameter(cmd, "CourtName", value.CourtName);
			AddParameter(cmd, "CourtLevel", value.CourtLevel);
			AddParameter(cmd, "LawyerAddressLine", value.LawyerAddressLine);
			AddParameter(cmd, "BankAccountName", value.BankAccountName);
			AddParameter(cmd, "BankAccountNo", value.BankAccountNo);
			AddParameter(cmd, "BankName", value.BankName);
			AddParameter(cmd, "BankBranch", value.BankBranch);
			AddParameter(cmd, "BankAccountType", value.BankAccountType);
			AddParameter(cmd, "PaymentListJson", value.PaymentListJson);
			AddParameter(cmd, "RefTransactionID", value.IsRefTransactionIDNull ? DBNull.Value : (object)value.RefTransactionID);
			AddParameter(cmd, "IsRequestRefund", value.IsIsRequestRefundNull ? DBNull.Value : (object)value.IsRequestRefund);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(TransactionAdditionalRow value)		{
			string sqlStr = "INSERT INTO [dbo].[TransactionAdditional] (" +
			"[TransactionID], " + 
			"[Payer], " + 
			"[Payee], " + 
			"[CourtName], " + 
			"[CourtLevel], " + 
			"[LawyerAddressLine], " + 
			"[BankAccountName], " + 
			"[BankAccountNo], " + 
			"[BankName], " + 
			"[BankBranch], " + 
			"[BankAccountType], " + 
			"[PaymentListJson], " + 
			"[RefTransactionID], " + 
			"[IsRequestRefund]			" + 
			") VALUES (" +
			CreateSqlParameterName("TransactionID") + ", " +
			CreateSqlParameterName("Payer") + ", " +
			CreateSqlParameterName("Payee") + ", " +
			CreateSqlParameterName("CourtName") + ", " +
			CreateSqlParameterName("CourtLevel") + ", " +
			CreateSqlParameterName("LawyerAddressLine") + ", " +
			CreateSqlParameterName("BankAccountName") + ", " +
			CreateSqlParameterName("BankAccountNo") + ", " +
			CreateSqlParameterName("BankName") + ", " +
			CreateSqlParameterName("BankBranch") + ", " +
			CreateSqlParameterName("BankAccountType") + ", " +
			CreateSqlParameterName("PaymentListJson") + ", " +
			CreateSqlParameterName("RefTransactionID") + ", " +
			CreateSqlParameterName("IsRequestRefund") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "TransactionID", value.TransactionID);
			AddParameter(cmd, "Payer", Sanitizer.GetSafeHtmlFragment(value.Payer));
			AddParameter(cmd, "Payee", Sanitizer.GetSafeHtmlFragment(value.Payee));
			AddParameter(cmd, "CourtName", Sanitizer.GetSafeHtmlFragment(value.CourtName));
			AddParameter(cmd, "CourtLevel", Sanitizer.GetSafeHtmlFragment(value.CourtLevel));
			AddParameter(cmd, "LawyerAddressLine", Sanitizer.GetSafeHtmlFragment(value.LawyerAddressLine));
			AddParameter(cmd, "BankAccountName", Sanitizer.GetSafeHtmlFragment(value.BankAccountName));
			AddParameter(cmd, "BankAccountNo", Sanitizer.GetSafeHtmlFragment(value.BankAccountNo));
			AddParameter(cmd, "BankName", Sanitizer.GetSafeHtmlFragment(value.BankName));
			AddParameter(cmd, "BankBranch", Sanitizer.GetSafeHtmlFragment(value.BankBranch));
			AddParameter(cmd, "BankAccountType", Sanitizer.GetSafeHtmlFragment(value.BankAccountType));
			AddParameter(cmd, "PaymentListJson", Sanitizer.GetSafeHtmlFragment(value.PaymentListJson));
			AddParameter(cmd, "RefTransactionID", value.IsRefTransactionIDNull ? DBNull.Value : (object)value.RefTransactionID);
			AddParameter(cmd, "IsRequestRefund", value.IsIsRequestRefundNull ? DBNull.Value : (object)value.IsRequestRefund);
			cmd.ExecuteNonQuery();
		}
		public bool Update(TransactionAdditionalRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPayer)
				{
					strUpdate += "[Payer]=" + CreateSqlParameterName("Payer") + ",";
				}
				if (value._IsSetPayee)
				{
					strUpdate += "[Payee]=" + CreateSqlParameterName("Payee") + ",";
				}
				if (value._IsSetCourtName)
				{
					strUpdate += "[CourtName]=" + CreateSqlParameterName("CourtName") + ",";
				}
				if (value._IsSetCourtLevel)
				{
					strUpdate += "[CourtLevel]=" + CreateSqlParameterName("CourtLevel") + ",";
				}
				if (value._IsSetLawyerAddressLine)
				{
					strUpdate += "[LawyerAddressLine]=" + CreateSqlParameterName("LawyerAddressLine") + ",";
				}
				if (value._IsSetBankAccountName)
				{
					strUpdate += "[BankAccountName]=" + CreateSqlParameterName("BankAccountName") + ",";
				}
				if (value._IsSetBankAccountNo)
				{
					strUpdate += "[BankAccountNo]=" + CreateSqlParameterName("BankAccountNo") + ",";
				}
				if (value._IsSetBankName)
				{
					strUpdate += "[BankName]=" + CreateSqlParameterName("BankName") + ",";
				}
				if (value._IsSetBankBranch)
				{
					strUpdate += "[BankBranch]=" + CreateSqlParameterName("BankBranch") + ",";
				}
				if (value._IsSetBankAccountType)
				{
					strUpdate += "[BankAccountType]=" + CreateSqlParameterName("BankAccountType") + ",";
				}
				if (value._IsSetPaymentListJson)
				{
					strUpdate += "[PaymentListJson]=" + CreateSqlParameterName("PaymentListJson") + ",";
				}
				if (value._IsSetRefTransactionID)
				{
					strUpdate += "[RefTransactionID]=" + CreateSqlParameterName("RefTransactionID") + ",";
				}
				if (value._IsSetIsRequestRefund)
				{
					strUpdate += "[IsRequestRefund]=" + CreateSqlParameterName("IsRequestRefund") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TransactionAdditional] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "Payer", value.Payer);
					AddParameter(cmd, "Payee", value.Payee);
					AddParameter(cmd, "CourtName", value.CourtName);
					AddParameter(cmd, "CourtLevel", value.CourtLevel);
					AddParameter(cmd, "LawyerAddressLine", value.LawyerAddressLine);
					AddParameter(cmd, "BankAccountName", value.BankAccountName);
					AddParameter(cmd, "BankAccountNo", value.BankAccountNo);
					AddParameter(cmd, "BankName", value.BankName);
					AddParameter(cmd, "BankBranch", value.BankBranch);
					AddParameter(cmd, "BankAccountType", value.BankAccountType);
					AddParameter(cmd, "PaymentListJson", value.PaymentListJson);
					AddParameter(cmd, "RefTransactionID", value.IsRefTransactionIDNull ? DBNull.Value : (object)value.RefTransactionID);
					AddParameter(cmd, "IsRequestRefund", value.IsIsRequestRefundNull ? DBNull.Value : (object)value.IsRequestRefund);
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
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(TransactionAdditionalRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPayer)
				{
					strUpdate += "[Payer]=" + CreateSqlParameterName("Payer") + ",";
				}
				if (value._IsSetPayee)
				{
					strUpdate += "[Payee]=" + CreateSqlParameterName("Payee") + ",";
				}
				if (value._IsSetCourtName)
				{
					strUpdate += "[CourtName]=" + CreateSqlParameterName("CourtName") + ",";
				}
				if (value._IsSetCourtLevel)
				{
					strUpdate += "[CourtLevel]=" + CreateSqlParameterName("CourtLevel") + ",";
				}
				if (value._IsSetLawyerAddressLine)
				{
					strUpdate += "[LawyerAddressLine]=" + CreateSqlParameterName("LawyerAddressLine") + ",";
				}
				if (value._IsSetBankAccountName)
				{
					strUpdate += "[BankAccountName]=" + CreateSqlParameterName("BankAccountName") + ",";
				}
				if (value._IsSetBankAccountNo)
				{
					strUpdate += "[BankAccountNo]=" + CreateSqlParameterName("BankAccountNo") + ",";
				}
				if (value._IsSetBankName)
				{
					strUpdate += "[BankName]=" + CreateSqlParameterName("BankName") + ",";
				}
				if (value._IsSetBankBranch)
				{
					strUpdate += "[BankBranch]=" + CreateSqlParameterName("BankBranch") + ",";
				}
				if (value._IsSetBankAccountType)
				{
					strUpdate += "[BankAccountType]=" + CreateSqlParameterName("BankAccountType") + ",";
				}
				if (value._IsSetPaymentListJson)
				{
					strUpdate += "[PaymentListJson]=" + CreateSqlParameterName("PaymentListJson") + ",";
				}
				if (value._IsSetRefTransactionID)
				{
					strUpdate += "[RefTransactionID]=" + CreateSqlParameterName("RefTransactionID") + ",";
				}
				if (value._IsSetIsRequestRefund)
				{
					strUpdate += "[IsRequestRefund]=" + CreateSqlParameterName("IsRequestRefund") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[TransactionAdditional] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "Payer", Sanitizer.GetSafeHtmlFragment(value.Payer));
					AddParameter(cmd, "Payee", Sanitizer.GetSafeHtmlFragment(value.Payee));
					AddParameter(cmd, "CourtName", Sanitizer.GetSafeHtmlFragment(value.CourtName));
					AddParameter(cmd, "CourtLevel", Sanitizer.GetSafeHtmlFragment(value.CourtLevel));
					AddParameter(cmd, "LawyerAddressLine", Sanitizer.GetSafeHtmlFragment(value.LawyerAddressLine));
					AddParameter(cmd, "BankAccountName", Sanitizer.GetSafeHtmlFragment(value.BankAccountName));
					AddParameter(cmd, "BankAccountNo", Sanitizer.GetSafeHtmlFragment(value.BankAccountNo));
					AddParameter(cmd, "BankName", Sanitizer.GetSafeHtmlFragment(value.BankName));
					AddParameter(cmd, "BankBranch", Sanitizer.GetSafeHtmlFragment(value.BankBranch));
					AddParameter(cmd, "BankAccountType", Sanitizer.GetSafeHtmlFragment(value.BankAccountType));
					AddParameter(cmd, "PaymentListJson", Sanitizer.GetSafeHtmlFragment(value.PaymentListJson));
					AddParameter(cmd, "RefTransactionID", value.IsRefTransactionIDNull ? DBNull.Value : (object)value.RefTransactionID);
					AddParameter(cmd, "IsRequestRefund", value.IsIsRequestRefundNull ? DBNull.Value : (object)value.IsRequestRefund);
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
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionID", transactionID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected TransactionAdditionalRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected TransactionAdditionalRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected TransactionAdditionalRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int payerColumnIndex = reader.GetOrdinal("Payer");
			int payeeColumnIndex = reader.GetOrdinal("Payee");
			int courtNameColumnIndex = reader.GetOrdinal("CourtName");
			int courtLevelColumnIndex = reader.GetOrdinal("CourtLevel");
			int lawyerAddresslineColumnIndex = reader.GetOrdinal("LawyerAddressLine");
			int bankAccountNameColumnIndex = reader.GetOrdinal("BankAccountName");
			int bankAccountNoColumnIndex = reader.GetOrdinal("BankAccountNo");
			int bankNameColumnIndex = reader.GetOrdinal("BankName");
			int bankbranchColumnIndex = reader.GetOrdinal("BankBranch");
			int bankAccountTypeColumnIndex = reader.GetOrdinal("BankAccountType");
			int paymentListJsonColumnIndex = reader.GetOrdinal("PaymentListJson");
			int refTransactionIDColumnIndex = reader.GetOrdinal("RefTransactionID");
			int isRequestRefundColumnIndex = reader.GetOrdinal("IsRequestRefund");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					TransactionAdditionalRow record = new TransactionAdditionalRow();
					recordList.Add(record);
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(payerColumnIndex)) record.Payer =  Convert.ToString(reader.GetValue(payerColumnIndex));

					if (!reader.IsDBNull(payeeColumnIndex)) record.Payee =  Convert.ToString(reader.GetValue(payeeColumnIndex));

					if (!reader.IsDBNull(courtNameColumnIndex)) record.CourtName =  Convert.ToString(reader.GetValue(courtNameColumnIndex));

					if (!reader.IsDBNull(courtLevelColumnIndex)) record.CourtLevel =  Convert.ToString(reader.GetValue(courtLevelColumnIndex));

					if (!reader.IsDBNull(lawyerAddresslineColumnIndex)) record.LawyerAddressLine =  Convert.ToString(reader.GetValue(lawyerAddresslineColumnIndex));

					if (!reader.IsDBNull(bankAccountNameColumnIndex)) record.BankAccountName =  Convert.ToString(reader.GetValue(bankAccountNameColumnIndex));

					if (!reader.IsDBNull(bankAccountNoColumnIndex)) record.BankAccountNo =  Convert.ToString(reader.GetValue(bankAccountNoColumnIndex));

					if (!reader.IsDBNull(bankNameColumnIndex)) record.BankName =  Convert.ToString(reader.GetValue(bankNameColumnIndex));

					if (!reader.IsDBNull(bankbranchColumnIndex)) record.BankBranch =  Convert.ToString(reader.GetValue(bankbranchColumnIndex));

					if (!reader.IsDBNull(bankAccountTypeColumnIndex)) record.BankAccountType =  Convert.ToString(reader.GetValue(bankAccountTypeColumnIndex));

					if (!reader.IsDBNull(paymentListJsonColumnIndex)) record.PaymentListJson =  Convert.ToString(reader.GetValue(paymentListJsonColumnIndex));

					if (!reader.IsDBNull(refTransactionIDColumnIndex)) record.RefTransactionID =  Convert.ToInt32(reader.GetValue(refTransactionIDColumnIndex));

					if (!reader.IsDBNull(isRequestRefundColumnIndex)) record.IsRequestRefund =  Convert.ToBoolean(reader.GetValue(isRequestRefundColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TransactionAdditionalRow[])(recordList.ToArray(typeof(TransactionAdditionalRow)));
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
				case "Payer":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Payee":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CourtName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CourtLevel":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LawyerAddressLine":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankAccountName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankAccountNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankBranch":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "BankAccountType":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "PaymentListJson":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RefTransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsRequestRefund":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

