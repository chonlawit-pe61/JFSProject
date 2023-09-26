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
	public partial class CaseEscapeSupportCollection_Base : MarshalByRefObject
	{
		public const string EscapeSupportIDColumnName = "EscapeSupportID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string TitleColumnName = "Title";
		public const string NameColumnName = "Name";
		public const string PositionColumnName = "Position";
		public const string RelationColumnName = "Relation";
		public const string CardIDColumnName = "CardID";
		public const string SubjectionColumnName = "Subjection";
		public const string AddressIDColumnName = "AddressID";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string ModifiedColumnName = "Modified";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseEscapeSupportCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseEscapeSupportRow[] GetAll()
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
			"[EscapeSupportID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[Title],"+
			"[Name],"+
			"[Position],"+
			"[Relation],"+
			"[CardID],"+
			"[Subjection],"+
			"[AddressID],"+
			"[TelephoneNo],"+
			"[Modified]"+
			" FROM [dbo].[CaseEscapeSupport]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseEscapeSupport]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseEscapeSupport"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("EscapeSupportID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Name",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Position",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Relation",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Subjection",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Modified",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual CaseEscapeSupportRow[] GetByCaseID(int caseID)
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
		public virtual CaseEscapeSupportRow[] GetByApplicantID(int applicantID)
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
		public virtual CaseEscapeSupportRow[] GetByAddressID(int addressID)
		{
			return MapRecords(CreateGetByAddressIDCommand(addressID));
		}
		public virtual DataTable GetByAddressIDAsDataTable(int addressID)
		{
			return MapRecordsToDataTable(CreateGetByAddressIDCommand(addressID));
		}
		protected virtual IDbCommand CreateGetByAddressIDCommand(int addressID)
		{
			string whereSql = "";
			whereSql += "[AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AddressID", addressID);
			return cmd;
		}
		public CaseEscapeSupportRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseEscapeSupportRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseEscapeSupportRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseEscapeSupportRow"/> objects.</returns>
		public virtual CaseEscapeSupportRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseEscapeSupport]", top);
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
		public CaseEscapeSupportRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseEscapeSupportRow[] rows = null;
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
		public DataTable GetCaseEscapeSupportPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "EscapeSupportID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "EscapeSupportID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(EscapeSupportID) AS TotalRow FROM [dbo].[CaseEscapeSupport] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,EscapeSupportID,CaseID,ApplicantID,Title,Name,Position,Relation,CardID,Subjection,AddressID,TelephoneNo,Modified," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseEscapeSupport] " + whereSql +
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
		public CaseEscapeSupportItemsPaging GetCaseEscapeSupportPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "EscapeSupportID")
		{
		CaseEscapeSupportItemsPaging obj = new CaseEscapeSupportItemsPaging();
		DataTable dt = GetCaseEscapeSupportPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseEscapeSupportItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseEscapeSupportItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.EscapeSupportID = Convert.ToInt32(dt.Rows[i]["EscapeSupportID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.Name = dt.Rows[i]["Name"].ToString();
			record.Position = dt.Rows[i]["Position"].ToString();
			record.Relation = dt.Rows[i]["Relation"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.Subjection = dt.Rows[i]["Subjection"].ToString();
			if (dt.Rows[i]["AddressID"] != DBNull.Value)
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.Modified = Convert.ToDateTime(dt.Rows[i]["Modified"]);
			recordList.Add(record);
		}
		obj.caseEscapeSupportItems = (CaseEscapeSupportItems[])(recordList.ToArray(typeof(CaseEscapeSupportItems)));
		return obj;
		}
		public CaseEscapeSupportRow GetByPrimaryKey(int escapeSupportID)
		{
			string whereSql = "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "EscapeSupportID", escapeSupportID);
			CaseEscapeSupportRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseEscapeSupportRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseEscapeSupport] (" +
			"[EscapeSupportID], " + 
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[Title], " + 
			"[Name], " + 
			"[Position], " + 
			"[Relation], " + 
			"[CardID], " + 
			"[Subjection], " + 
			"[AddressID], " + 
			"[TelephoneNo], " + 
			"[Modified]			" + 
			") VALUES (" +
			CreateSqlParameterName("EscapeSupportID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("Name") + ", " +
			CreateSqlParameterName("Position") + ", " +
			CreateSqlParameterName("Relation") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Subjection") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("Modified") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "EscapeSupportID", value.EscapeSupportID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "Title", value.Title);
			AddParameter(cmd, "Name", value.Name);
			AddParameter(cmd, "Position", value.Position);
			AddParameter(cmd, "Relation", value.Relation);
			AddParameter(cmd, "CardID", value.CardID);
			AddParameter(cmd, "Subjection", value.Subjection);
			AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
			AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
			AddParameter(cmd, "Modified", value.IsModifiedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.Modified);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseEscapeSupportRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseEscapeSupport] (" +
			"[EscapeSupportID], " + 
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[Title], " + 
			"[Name], " + 
			"[Position], " + 
			"[Relation], " + 
			"[CardID], " + 
			"[Subjection], " + 
			"[AddressID], " + 
			"[TelephoneNo], " + 
			"[Modified]			" + 
			") VALUES (" +
			CreateSqlParameterName("EscapeSupportID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("Name") + ", " +
			CreateSqlParameterName("Position") + ", " +
			CreateSqlParameterName("Relation") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Subjection") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("Modified") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "EscapeSupportID", value.EscapeSupportID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "Name", Sanitizer.GetSafeHtmlFragment(value.Name));
			AddParameter(cmd, "Position", Sanitizer.GetSafeHtmlFragment(value.Position));
			AddParameter(cmd, "Relation", Sanitizer.GetSafeHtmlFragment(value.Relation));
			AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
			AddParameter(cmd, "Subjection", Sanitizer.GetSafeHtmlFragment(value.Subjection));
			AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
			AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
			AddParameter(cmd, "Modified", value.IsModifiedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.Modified);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseEscapeSupportRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetEscapeSupportID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetName)
				{
					strUpdate += "[Name]=" + CreateSqlParameterName("Name") + ",";
				}
				if (value._IsSetPosition)
				{
					strUpdate += "[Position]=" + CreateSqlParameterName("Position") + ",";
				}
				if (value._IsSetRelation)
				{
					strUpdate += "[Relation]=" + CreateSqlParameterName("Relation") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetSubjection)
				{
					strUpdate += "[Subjection]=" + CreateSqlParameterName("Subjection") + ",";
				}
				if (value._IsSetAddressID)
				{
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetModified)
				{
					strUpdate += "[Modified]=" + CreateSqlParameterName("Modified") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseEscapeSupport] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "EscapeSupportID", value.EscapeSupportID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "Name", value.Name);
					AddParameter(cmd, "Position", value.Position);
					AddParameter(cmd, "Relation", value.Relation);
					AddParameter(cmd, "CardID", value.CardID);
					AddParameter(cmd, "Subjection", value.Subjection);
					AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
					AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
					AddParameter(cmd, "Modified", value.IsModifiedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.Modified);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(EscapeSupportID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseEscapeSupportRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetEscapeSupportID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetName)
				{
					strUpdate += "[Name]=" + CreateSqlParameterName("Name") + ",";
				}
				if (value._IsSetPosition)
				{
					strUpdate += "[Position]=" + CreateSqlParameterName("Position") + ",";
				}
				if (value._IsSetRelation)
				{
					strUpdate += "[Relation]=" + CreateSqlParameterName("Relation") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetSubjection)
				{
					strUpdate += "[Subjection]=" + CreateSqlParameterName("Subjection") + ",";
				}
				if (value._IsSetAddressID)
				{
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetModified)
				{
					strUpdate += "[Modified]=" + CreateSqlParameterName("Modified") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseEscapeSupport] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "EscapeSupportID", value.EscapeSupportID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "Name", Sanitizer.GetSafeHtmlFragment(value.Name));
					AddParameter(cmd, "Position", Sanitizer.GetSafeHtmlFragment(value.Position));
					AddParameter(cmd, "Relation", Sanitizer.GetSafeHtmlFragment(value.Relation));
					AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
					AddParameter(cmd, "Subjection", Sanitizer.GetSafeHtmlFragment(value.Subjection));
					AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
					AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
					AddParameter(cmd, "Modified", value.IsModifiedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.Modified);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(EscapeSupportID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int escapeSupportID)
		{
			string whereSql = "[EscapeSupportID]=" + CreateSqlParameterName("EscapeSupportID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "EscapeSupportID", escapeSupportID);
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
		public int DeleteByAddressID(int addressID)
		{
			return DeleteByAddressID(addressID, false);
		}
		public int DeleteByAddressID(int addressID, bool addressIDNull)
		{
			return CreateDeleteByAddressIDCommand(addressID, addressIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAddressIDCommand(int addressID, bool addressIDNull)
		{
			string whereSql = "";
			if (addressIDNull)
				whereSql += "[AddressID] IS NULL";
			else
				whereSql += "[AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!addressIDNull)
				AddParameter(cmd, "AddressID", addressID);
			return cmd;
		}
		protected CaseEscapeSupportRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseEscapeSupportRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseEscapeSupportRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int escapeSupportIDColumnIndex = reader.GetOrdinal("EscapeSupportID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int nameColumnIndex = reader.GetOrdinal("Name");
			int positionColumnIndex = reader.GetOrdinal("Position");
			int relationColumnIndex = reader.GetOrdinal("Relation");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int subjectionColumnIndex = reader.GetOrdinal("Subjection");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int modifiedColumnIndex = reader.GetOrdinal("Modified");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					CaseEscapeSupportRow record = new CaseEscapeSupportRow();
					recordList.Add(record);
					record.EscapeSupportID =  Convert.ToInt32(reader.GetValue(escapeSupportIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(nameColumnIndex)) record.Name =  Convert.ToString(reader.GetValue(nameColumnIndex));

					if (!reader.IsDBNull(positionColumnIndex)) record.Position =  Convert.ToString(reader.GetValue(positionColumnIndex));

					if (!reader.IsDBNull(relationColumnIndex)) record.Relation =  Convert.ToString(reader.GetValue(relationColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(subjectionColumnIndex)) record.Subjection =  Convert.ToString(reader.GetValue(subjectionColumnIndex));

					if (!reader.IsDBNull(addressIDColumnIndex)) record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					record.Modified =  Convert.ToDateTime(reader.GetValue(modifiedColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseEscapeSupportRow[])(recordList.ToArray(typeof(CaseEscapeSupportRow)));
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
				case "EscapeSupportID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Name":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Position":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Relation":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Subjection":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Modified":
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

