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
	public partial class CaseExpenseExtensionCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string ExpenseIDColumnName = "ExpenseID";
		public const string PriceThresholdColumnName = "PriceThreshold";
		public const string UnitColumnName = "Unit";
		public const string AmountColumnName = "Amount";
		public const string RemarkColumnName = "Remark";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseExpenseExtensionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseExpenseExtensionRow[] GetAll()
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
			"[CaseID],"+
			"[ApplicantID],"+
			"[ExpenseID],"+
			"[PriceThreshold],"+
			"[Unit],"+
			"[Amount],"+
			"[Remark],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseExpenseExtension]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseExpenseExtension]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseExpenseExtension"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ExpenseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PriceThreshold",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Unit",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Amount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseExpenseExtensionRow[] GetByCaseID(int caseID)
		{
			return MapRecords(CreateGetByCaseIDCommand(caseID));
		}
		public virtual DataTable GetByCaseIDAsDataTable(int caseID)
		{
			return MapRecordsToDataTable(CreateGetByCaseIDCommand(caseID));
		}
		protected virtual IDbCommand CreateGetByCaseIDCommand(int caseID)
		{
			string whereSql = "";
			whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public virtual CaseExpenseExtensionRow[] GetByApplicantID(int applicantID)
		{
			return MapRecords(CreateGetByApplicantIDCommand(applicantID));
		}
		public virtual DataTable GetByApplicantIDAsDataTable(int applicantID)
		{
			return MapRecordsToDataTable(CreateGetByApplicantIDCommand(applicantID));
		}
		protected virtual IDbCommand CreateGetByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public virtual CaseExpenseExtensionRow[] GetByExpenseID(int expenseID)
		{
			return MapRecords(CreateGetByExpenseIDCommand(expenseID));
		}
		public virtual DataTable GetByExpenseIDAsDataTable(int expenseID)
		{
			return MapRecordsToDataTable(CreateGetByExpenseIDCommand(expenseID));
		}
		protected virtual IDbCommand CreateGetByExpenseIDCommand(int expenseID)
		{
			string whereSql = "";
			whereSql += "[ExpenseID]=" + CreateSqlParameterName("ExpenseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ExpenseID", expenseID);
			return cmd;
		}
		public CaseExpenseExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseExpenseExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseExpenseExtensionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseExpenseExtensionRow"/> objects.</returns>
		public virtual CaseExpenseExtensionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseExpenseExtension]", top);
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
		public CaseExpenseExtensionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseExpenseExtensionRow[] rows = null;
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
		public DataTable GetCaseExpenseExtensionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[CaseExpenseExtension] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,ApplicantID,ExpenseID,PriceThreshold,Unit,Amount,Remark,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseExpenseExtension] " + whereSql +
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
		public CaseExpenseExtensionItemsPaging GetCaseExpenseExtensionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseExpenseExtensionItemsPaging obj = new CaseExpenseExtensionItemsPaging();
		DataTable dt = GetCaseExpenseExtensionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseExpenseExtensionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseExpenseExtensionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.ExpenseID = Convert.ToInt32(dt.Rows[i]["ExpenseID"]);
			if (dt.Rows[i]["PriceThreshold"] != DBNull.Value)
			record.PriceThreshold = Convert.ToInt32(dt.Rows[i]["PriceThreshold"]);
			if (dt.Rows[i]["Unit"] != DBNull.Value)
			record.Unit = Convert.ToInt32(dt.Rows[i]["Unit"]);
			if (dt.Rows[i]["Amount"] != DBNull.Value)
			record.Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
			record.Remark = dt.Rows[i]["Remark"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseExpenseExtensionItems = (CaseExpenseExtensionItems[])(recordList.ToArray(typeof(CaseExpenseExtensionItems)));
		return obj;
		}
		public CaseExpenseExtensionRow GetByPrimaryKey(int caseID, int applicantID, int expenseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [ExpenseID]=" + CreateSqlParameterName("ExpenseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "ExpenseID", expenseID);
			CaseExpenseExtensionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseExpenseExtensionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseExpenseExtension] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[ExpenseID], " + 
			"[PriceThreshold], " + 
			"[Unit], " + 
			"[Amount], " + 
			"[Remark], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("ExpenseID") + ", " +
			CreateSqlParameterName("PriceThreshold") + ", " +
			CreateSqlParameterName("Unit") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "ExpenseID", value.ExpenseID);
			AddParameter(cmd, "PriceThreshold", value.IsPriceThresholdNull ? DBNull.Value : (object)value.PriceThreshold);
			AddParameter(cmd, "Unit", value.IsUnitNull ? DBNull.Value : (object)value.Unit);
			AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
			AddParameter(cmd, "Remark", value.IsRemarkNull ? DBNull.Value : (object)value.Remark);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseExpenseExtensionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseExpenseExtension] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[ExpenseID], " + 
			"[PriceThreshold], " + 
			"[Unit], " + 
			"[Amount], " + 
			"[Remark], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("ExpenseID") + ", " +
			CreateSqlParameterName("PriceThreshold") + ", " +
			CreateSqlParameterName("Unit") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "ExpenseID", value.ExpenseID);
			AddParameter(cmd, "PriceThreshold", value.IsPriceThresholdNull ? DBNull.Value : (object)value.PriceThreshold);
			AddParameter(cmd, "Unit", value.IsUnitNull ? DBNull.Value : (object)value.Unit);
			AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
			AddParameter(cmd, "Remark", value.IsRemarkNull ? DBNull.Value : (object)value.Remark);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseExpenseExtensionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetApplicantID == true && value._IsSetExpenseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPriceThreshold)
				{
					strUpdate += "[PriceThreshold]=" + CreateSqlParameterName("PriceThreshold") + ",";
				}
				if (value._IsSetUnit)
				{
					strUpdate += "[Unit]=" + CreateSqlParameterName("Unit") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseExpenseExtension] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [ExpenseID]=" + CreateSqlParameterName("ExpenseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "ExpenseID", value.ExpenseID);
				if (value._IsSetPriceThreshold)
				{
					AddParameter(cmd, "PriceThreshold", value.IsPriceThresholdNull ? DBNull.Value : (object)value.PriceThreshold);
				}
				if (value._IsSetUnit)
				{
					AddParameter(cmd, "Unit", value.IsUnitNull ? DBNull.Value : (object)value.Unit);
				}
				if (value._IsSetAmount)
				{
					AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
				}
					AddParameter(cmd, "Remark", value.Remark);
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,ApplicantID,ExpenseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseExpenseExtensionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetApplicantID == true && value._IsSetExpenseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPriceThreshold)
				{
					strUpdate += "[PriceThreshold]=" + CreateSqlParameterName("PriceThreshold") + ",";
				}
				if (value._IsSetUnit)
				{
					strUpdate += "[Unit]=" + CreateSqlParameterName("Unit") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseExpenseExtension] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [ExpenseID]=" + CreateSqlParameterName("ExpenseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "ExpenseID", value.ExpenseID);
				if (value._IsSetPriceThreshold)
				{
					AddParameter(cmd, "PriceThreshold", value.IsPriceThresholdNull ? DBNull.Value : (object)value.PriceThreshold);
				}
				if (value._IsSetUnit)
				{
					AddParameter(cmd, "Unit", value.IsUnitNull ? DBNull.Value : (object)value.Unit);
				}
				if (value._IsSetAmount)
				{
					AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
				}
					AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,ApplicantID,ExpenseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID, int applicantID, int expenseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [ExpenseID]=" + CreateSqlParameterName("ExpenseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "ExpenseID", expenseID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByCaseID(int caseID)
		{
			return CreateDeleteByCaseIDCommand(caseID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseIDCommand(int caseID)
		{
			string whereSql = "";
			whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return CreateDeleteByApplicantIDCommand(applicantID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public int DeleteByExpenseID(int expenseID)
		{
			return CreateDeleteByExpenseIDCommand(expenseID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByExpenseIDCommand(int expenseID)
		{
			string whereSql = "";
			whereSql += "[ExpenseID]=" + CreateSqlParameterName("ExpenseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ExpenseID", expenseID);
			return cmd;
		}
		protected CaseExpenseExtensionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseExpenseExtensionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseExpenseExtensionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int expenseIDColumnIndex = reader.GetOrdinal("ExpenseID");
			int priceThresholdColumnIndex = reader.GetOrdinal("PriceThreshold");
			int unitColumnIndex = reader.GetOrdinal("Unit");
			int amountColumnIndex = reader.GetOrdinal("Amount");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
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
					CaseExpenseExtensionRow record = new CaseExpenseExtensionRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.ExpenseID =  Convert.ToInt32(reader.GetValue(expenseIDColumnIndex));
					if (!reader.IsDBNull(priceThresholdColumnIndex)) record.PriceThreshold =  Convert.ToInt32(reader.GetValue(priceThresholdColumnIndex));

					if (!reader.IsDBNull(unitColumnIndex)) record.Unit =  Convert.ToInt32(reader.GetValue(unitColumnIndex));

					if (!reader.IsDBNull(amountColumnIndex)) record.Amount =  Convert.ToDouble(reader.GetValue(amountColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

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
			return (CaseExpenseExtensionRow[])(recordList.ToArray(typeof(CaseExpenseExtensionRow)));
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
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ExpenseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PriceThreshold":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Unit":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Amount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

