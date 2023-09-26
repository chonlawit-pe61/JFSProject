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
	public partial class ProxyCollection_Base : MarshalByRefObject
	{
		public const string ProxyIDColumnName = "ProxyID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string CardIDColumnName = "CardID";
		public const string GenderColumnName = "Gender";
		public const string ReligionIDColumnName = "ReligionID";
		public const string NationalityIDColumnName = "NationalityID";
		public const string RaceIDColumnName = "RaceID";
		public const string RelatedAsColumnName = "RelatedAs";
		public const string IsAppealColumnName = "IsAppeal";
		private int _processID;
		public SqlCommand cmd = null;
		public ProxyCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ProxyRow[] GetAll()
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
			"[ProxyID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[DateOfBirth],"+
			"[CardID],"+
			"[Gender],"+
			"[ReligionID],"+
			"[NationalityID],"+
			"[RaceID],"+
			"[RelatedAs],"+
			"[IsAppeal]"+
			" FROM [dbo].[Proxy]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Proxy]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Proxy"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ProxyID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RelatedAs",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsAppeal",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public virtual ProxyRow[] GetByCaseID(int caseID)
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
		public virtual ProxyRow[] GetByApplicantID(int applicantID)
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
		public ProxyRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ProxyRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ProxyRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ProxyRow"/> objects.</returns>
		public virtual ProxyRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Proxy]", top);
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
		public ProxyRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ProxyRow[] rows = null;
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
		public DataTable GetProxyPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProxyID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ProxyID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ProxyID) AS TotalRow FROM [dbo].[Proxy] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ProxyID,CaseID,ApplicantID,Title,FirstName,LastName,DateOfBirth,CardID,Gender,ReligionID,NationalityID,RaceID,RelatedAs,IsAppeal," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Proxy] " + whereSql +
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
		public ProxyItemsPaging GetProxyPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProxyID")
		{
		ProxyItemsPaging obj = new ProxyItemsPaging();
		DataTable dt = GetProxyPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ProxyItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ProxyItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ProxyID = Convert.ToInt32(dt.Rows[i]["ProxyID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			if (dt.Rows[i]["ReligionID"] != DBNull.Value)
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			record.RelatedAs = dt.Rows[i]["RelatedAs"].ToString();
			if (dt.Rows[i]["IsAppeal"] != DBNull.Value)
			record.IsAppeal = Convert.ToBoolean(dt.Rows[i]["IsAppeal"]);
			recordList.Add(record);
		}
		obj.proxyItems = (ProxyItems[])(recordList.ToArray(typeof(ProxyItems)));
		return obj;
		}
		public ProxyRow GetByPrimaryKey(int proxyID)
		{
			string whereSql = "[ProxyID]=" + CreateSqlParameterName("ProxyID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProxyID", proxyID);
			ProxyRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ProxyRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Proxy] (" +
			"[ProxyID], " + 
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[DateOfBirth], " + 
			"[CardID], " + 
			"[Gender], " + 
			"[ReligionID], " + 
			"[NationalityID], " + 
			"[RaceID], " + 
			"[RelatedAs], " + 
			"[IsAppeal]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProxyID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("ReligionID") + ", " +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("RaceID") + ", " +
			CreateSqlParameterName("RelatedAs") + ", " +
			CreateSqlParameterName("IsAppeal") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProxyID", value.ProxyID);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "Title", value.Title);
			AddParameter(cmd, "FirstName", value.FirstName);
			AddParameter(cmd, "LastName", value.LastName);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "CardID", value.CardID);
			AddParameter(cmd, "Gender", value.Gender);
			AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
			AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
			AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
			AddParameter(cmd, "RelatedAs", value.RelatedAs);
			AddParameter(cmd, "IsAppeal", value.IsIsAppealNull ? DBNull.Value : (object)value.IsAppeal);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ProxyRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Proxy] (" +
			"[ProxyID], " + 
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[DateOfBirth], " + 
			"[CardID], " + 
			"[Gender], " + 
			"[ReligionID], " + 
			"[NationalityID], " + 
			"[RaceID], " + 
			"[RelatedAs], " + 
			"[IsAppeal]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProxyID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("ReligionID") + ", " +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("RaceID") + ", " +
			CreateSqlParameterName("RelatedAs") + ", " +
			CreateSqlParameterName("IsAppeal") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProxyID", value.ProxyID);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
			AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
			AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
			AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
			AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
			AddParameter(cmd, "RelatedAs", Sanitizer.GetSafeHtmlFragment(value.RelatedAs));
			AddParameter(cmd, "IsAppeal", value.IsIsAppealNull ? DBNull.Value : (object)value.IsAppeal);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ProxyRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProxyID == true )
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
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetReligionID)
				{
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID") + ",";
				}
				if (value._IsSetNationalityID)
				{
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID") + ",";
				}
				if (value._IsSetRaceID)
				{
					strUpdate += "[RaceID]=" + CreateSqlParameterName("RaceID") + ",";
				}
				if (value._IsSetRelatedAs)
				{
					strUpdate += "[RelatedAs]=" + CreateSqlParameterName("RelatedAs") + ",";
				}
				if (value._IsSetIsAppeal)
				{
					strUpdate += "[IsAppeal]=" + CreateSqlParameterName("IsAppeal") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Proxy] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProxyID]=" + CreateSqlParameterName("ProxyID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProxyID", value.ProxyID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "CardID", value.CardID);
					AddParameter(cmd, "Gender", value.Gender);
					AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
					AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
					AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
					AddParameter(cmd, "RelatedAs", value.RelatedAs);
					AddParameter(cmd, "IsAppeal", value.IsIsAppealNull ? DBNull.Value : (object)value.IsAppeal);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ProxyID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ProxyRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProxyID == true )
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
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetReligionID)
				{
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID") + ",";
				}
				if (value._IsSetNationalityID)
				{
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID") + ",";
				}
				if (value._IsSetRaceID)
				{
					strUpdate += "[RaceID]=" + CreateSqlParameterName("RaceID") + ",";
				}
				if (value._IsSetRelatedAs)
				{
					strUpdate += "[RelatedAs]=" + CreateSqlParameterName("RelatedAs") + ",";
				}
				if (value._IsSetIsAppeal)
				{
					strUpdate += "[IsAppeal]=" + CreateSqlParameterName("IsAppeal") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Proxy] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProxyID]=" + CreateSqlParameterName("ProxyID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProxyID", value.ProxyID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
					AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
					AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
					AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
					AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
					AddParameter(cmd, "RelatedAs", Sanitizer.GetSafeHtmlFragment(value.RelatedAs));
					AddParameter(cmd, "IsAppeal", value.IsIsAppealNull ? DBNull.Value : (object)value.IsAppeal);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ProxyID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int proxyID)
		{
			string whereSql = "[ProxyID]=" + CreateSqlParameterName("ProxyID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProxyID", proxyID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByCaseID(int caseID)
		{
			return DeleteByCaseID(caseID, false);
		}
		public int DeleteByCaseID(int caseID, bool caseIDNull)
		{
			return CreateDeleteByCaseIDCommand(caseID, caseIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseIDCommand(int caseID, bool caseIDNull)
		{
			string whereSql = "";
			if (caseIDNull)
				whereSql += "[CaseID] IS NULL";
			else
				whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!caseIDNull)
				AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return DeleteByApplicantID(applicantID, false);
		}
		public int DeleteByApplicantID(int applicantID, bool applicantIDNull)
		{
			return CreateDeleteByApplicantIDCommand(applicantID, applicantIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID, bool applicantIDNull)
		{
			string whereSql = "";
			if (applicantIDNull)
				whereSql += "[ApplicantID] IS NULL";
			else
				whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!applicantIDNull)
				AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		protected ProxyRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ProxyRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ProxyRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int proxyIDColumnIndex = reader.GetOrdinal("ProxyID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int relatedAsColumnIndex = reader.GetOrdinal("RelatedAs");
			int isAppealColumnIndex = reader.GetOrdinal("IsAppeal");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ProxyRow record = new ProxyRow();
					recordList.Add(record);
					record.ProxyID =  Convert.ToInt32(reader.GetValue(proxyIDColumnIndex));
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(religionIDColumnIndex)) record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(relatedAsColumnIndex)) record.RelatedAs =  Convert.ToString(reader.GetValue(relatedAsColumnIndex));

					if (!reader.IsDBNull(isAppealColumnIndex)) record.IsAppeal =  Convert.ToBoolean(reader.GetValue(isAppealColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ProxyRow[])(recordList.ToArray(typeof(ProxyRow)));
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
				case "ProxyID":
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
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RelatedAs":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsAppeal":
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

