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
	public partial class ApplicantRelatedPersonCollection_Base : MarshalByRefObject
	{
		public const string ContactPersonIDColumnName = "ContactPersonID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string PersonRoleIDColumnName = "PersonRoleID";
		public const string TelephoneNumberColumnName = "TelephoneNumber";
		public const string EmailColumnName = "Email";
		public const string RelatedAsColumnName = "RelatedAs";
		public const string AddressIDColumnName = "AddressID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantRelatedPersonCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantRelatedPersonRow[] GetAll()
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
			"[ContactPersonID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[PersonRoleID],"+
			"[TelephoneNumber],"+
			"[Email],"+
			"[RelatedAs],"+
			"[AddressID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantRelatedPerson]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantRelatedPerson]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantRelatedPerson"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ContactPersonID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PersonRoleID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("TelephoneNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("RelatedAs",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ApplicantRelatedPersonRow[] GetByContactPersonID(int contactPersonID)
		{
			return MapRecords(CreateGetByContactPersonIDCommand(contactPersonID));
		}
		public virtual DataTable GetByContactPersonIDAsDataTable(int contactPersonID)
		{
			return MapRecordsToDataTable(CreateGetByContactPersonIDCommand(contactPersonID));
		}
		protected virtual IDbCommand CreateGetByContactPersonIDCommand(int contactPersonID)
		{
			string whereSql = "";
			whereSql += "[ContactPersonID]=" + CreateSqlParameterName("ContactPersonID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ContactPersonID", contactPersonID);
			return cmd;
		}
		public virtual ApplicantRelatedPersonRow[] GetByApplicantID(int applicantID)
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
		public virtual ApplicantRelatedPersonRow[] GetByPersonRoleID(int personRoleID)
		{
			return MapRecords(CreateGetByPersonRoleIDCommand(personRoleID));
		}
		public virtual DataTable GetByPersonRoleIDAsDataTable(int personRoleID)
		{
			return MapRecordsToDataTable(CreateGetByPersonRoleIDCommand(personRoleID));
		}
		protected virtual IDbCommand CreateGetByPersonRoleIDCommand(int personRoleID)
		{
			string whereSql = "";
			whereSql += "[PersonRoleID]=" + CreateSqlParameterName("PersonRoleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PersonRoleID", personRoleID);
			return cmd;
		}
		public virtual ApplicantRelatedPersonRow[] GetByAddressID(int addressID)
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
		public ApplicantRelatedPersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantRelatedPersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantRelatedPersonRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantRelatedPersonRow"/> objects.</returns>
		public virtual ApplicantRelatedPersonRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantRelatedPerson]", top);
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
		public ApplicantRelatedPersonRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantRelatedPersonRow[] rows = null;
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
		public DataTable GetApplicantRelatedPersonPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContactPersonID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ContactPersonID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ContactPersonID) AS TotalRow FROM [dbo].[ApplicantRelatedPerson] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ContactPersonID,CaseID,ApplicantID,PersonRoleID,TelephoneNumber,Email,RelatedAs,AddressID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantRelatedPerson] " + whereSql +
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
		public ApplicantRelatedPersonItemsPaging GetApplicantRelatedPersonPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContactPersonID")
		{
		ApplicantRelatedPersonItemsPaging obj = new ApplicantRelatedPersonItemsPaging();
		DataTable dt = GetApplicantRelatedPersonPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantRelatedPersonItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantRelatedPersonItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ContactPersonID = Convert.ToInt32(dt.Rows[i]["ContactPersonID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["PersonRoleID"] != DBNull.Value)
			record.PersonRoleID = Convert.ToInt32(dt.Rows[i]["PersonRoleID"]);
			record.TelephoneNumber = dt.Rows[i]["TelephoneNumber"].ToString();
			record.Email = dt.Rows[i]["Email"].ToString();
			record.RelatedAs = dt.Rows[i]["RelatedAs"].ToString();
			if (dt.Rows[i]["AddressID"] != DBNull.Value)
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantRelatedPersonItems = (ApplicantRelatedPersonItems[])(recordList.ToArray(typeof(ApplicantRelatedPersonItems)));
		return obj;
		}
		public ApplicantRelatedPersonRow GetByPrimaryKey(int contactPersonID, int caseID, int applicantID)
		{
			string whereSql = "[ContactPersonID]=" + CreateSqlParameterName("ContactPersonID") + " AND [CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ContactPersonID", contactPersonID);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			ApplicantRelatedPersonRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ApplicantRelatedPersonRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantRelatedPerson] (" +
			"[ContactPersonID], " + 
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[PersonRoleID], " + 
			"[TelephoneNumber], " + 
			"[Email], " + 
			"[RelatedAs], " + 
			"[AddressID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ContactPersonID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("PersonRoleID") + ", " +
			CreateSqlParameterName("TelephoneNumber") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("RelatedAs") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ContactPersonID", value.ContactPersonID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "PersonRoleID", value.IsPersonRoleIDNull ? DBNull.Value : (object)value.PersonRoleID);
			AddParameter(cmd, "TelephoneNumber", value.TelephoneNumber);
			AddParameter(cmd, "Email", value.Email);
			AddParameter(cmd, "RelatedAs", value.RelatedAs);
			AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ApplicantRelatedPersonRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantRelatedPerson] (" +
			"[ContactPersonID], " + 
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[PersonRoleID], " + 
			"[TelephoneNumber], " + 
			"[Email], " + 
			"[RelatedAs], " + 
			"[AddressID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ContactPersonID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("PersonRoleID") + ", " +
			CreateSqlParameterName("TelephoneNumber") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("RelatedAs") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ContactPersonID", value.ContactPersonID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "PersonRoleID", value.IsPersonRoleIDNull ? DBNull.Value : (object)value.PersonRoleID);
			AddParameter(cmd, "TelephoneNumber", Sanitizer.GetSafeHtmlFragment(value.TelephoneNumber));
			AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
			AddParameter(cmd, "RelatedAs", Sanitizer.GetSafeHtmlFragment(value.RelatedAs));
			AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ApplicantRelatedPersonRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetContactPersonID == true && value._IsSetCaseID == true && value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPersonRoleID)
				{
					strUpdate += "[PersonRoleID]=" + CreateSqlParameterName("PersonRoleID") + ",";
				}
				if (value._IsSetTelephoneNumber)
				{
					strUpdate += "[TelephoneNumber]=" + CreateSqlParameterName("TelephoneNumber") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetRelatedAs)
				{
					strUpdate += "[RelatedAs]=" + CreateSqlParameterName("RelatedAs") + ",";
				}
				if (value._IsSetAddressID)
				{
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantRelatedPerson] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ContactPersonID]=" + CreateSqlParameterName("ContactPersonID")+ " AND [CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ContactPersonID", value.ContactPersonID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "PersonRoleID", value.IsPersonRoleIDNull ? DBNull.Value : (object)value.PersonRoleID);
					AddParameter(cmd, "TelephoneNumber", value.TelephoneNumber);
					AddParameter(cmd, "Email", value.Email);
					AddParameter(cmd, "RelatedAs", value.RelatedAs);
					AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ContactPersonID,CaseID,ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantRelatedPersonRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetContactPersonID == true && value._IsSetCaseID == true && value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPersonRoleID)
				{
					strUpdate += "[PersonRoleID]=" + CreateSqlParameterName("PersonRoleID") + ",";
				}
				if (value._IsSetTelephoneNumber)
				{
					strUpdate += "[TelephoneNumber]=" + CreateSqlParameterName("TelephoneNumber") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetRelatedAs)
				{
					strUpdate += "[RelatedAs]=" + CreateSqlParameterName("RelatedAs") + ",";
				}
				if (value._IsSetAddressID)
				{
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantRelatedPerson] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ContactPersonID]=" + CreateSqlParameterName("ContactPersonID")+ " AND [CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ContactPersonID", value.ContactPersonID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "PersonRoleID", value.IsPersonRoleIDNull ? DBNull.Value : (object)value.PersonRoleID);
					AddParameter(cmd, "TelephoneNumber", Sanitizer.GetSafeHtmlFragment(value.TelephoneNumber));
					AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
					AddParameter(cmd, "RelatedAs", Sanitizer.GetSafeHtmlFragment(value.RelatedAs));
					AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ContactPersonID,CaseID,ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int contactPersonID, int caseID, int applicantID)
		{
			string whereSql = "[ContactPersonID]=" + CreateSqlParameterName("ContactPersonID") + " AND [CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ContactPersonID", contactPersonID);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByContactPersonID(int contactPersonID)
		{
			return CreateDeleteByContactPersonIDCommand(contactPersonID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByContactPersonIDCommand(int contactPersonID)
		{
			string whereSql = "";
			whereSql += "[ContactPersonID]=" + CreateSqlParameterName("ContactPersonID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ContactPersonID", contactPersonID);
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
		public int DeleteByPersonRoleID(int personRoleID)
		{
			return DeleteByPersonRoleID(personRoleID, false);
		}
		public int DeleteByPersonRoleID(int personRoleID, bool personRoleIDNull)
		{
			return CreateDeleteByPersonRoleIDCommand(personRoleID, personRoleIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByPersonRoleIDCommand(int personRoleID, bool personRoleIDNull)
		{
			string whereSql = "";
			if (personRoleIDNull)
				whereSql += "[PersonRoleID] IS NULL";
			else
				whereSql += "[PersonRoleID]=" + CreateSqlParameterName("PersonRoleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!personRoleIDNull)
				AddParameter(cmd, "PersonRoleID", personRoleID);
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
		protected ApplicantRelatedPersonRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantRelatedPersonRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantRelatedPersonRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int contactPersonIDColumnIndex = reader.GetOrdinal("ContactPersonID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int personRoleIDColumnIndex = reader.GetOrdinal("PersonRoleID");
			int telephoneNumberColumnIndex = reader.GetOrdinal("TelephoneNumber");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int relatedAsColumnIndex = reader.GetOrdinal("RelatedAs");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
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
					ApplicantRelatedPersonRow record = new ApplicantRelatedPersonRow();
					recordList.Add(record);
					record.ContactPersonID =  Convert.ToInt32(reader.GetValue(contactPersonIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(personRoleIDColumnIndex)) record.PersonRoleID =  Convert.ToInt32(reader.GetValue(personRoleIDColumnIndex));

					if (!reader.IsDBNull(telephoneNumberColumnIndex)) record.TelephoneNumber =  Convert.ToString(reader.GetValue(telephoneNumberColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(relatedAsColumnIndex)) record.RelatedAs =  Convert.ToString(reader.GetValue(relatedAsColumnIndex));

					if (!reader.IsDBNull(addressIDColumnIndex)) record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantRelatedPersonRow[])(recordList.ToArray(typeof(ApplicantRelatedPersonRow)));
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
				case "ContactPersonID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PersonRoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TelephoneNumber":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RelatedAs":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

