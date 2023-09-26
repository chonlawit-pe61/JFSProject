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
	public partial class CaseApplicantCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string CaseIDColumnName = "CaseID";
		public const string GenderColumnName = "Gender";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string RequestAmountColumnName = "RequestAmount";
		public const string ScoreColumnName = "Score";
		public const string HasProxyColumnName = "HasProxy";
		public const string DeletedFlagColumnName = "DeletedFlag";
		public const string UserCreateCaseIDColumnName = "UserCreateCaseID";
		public const string CreateDateColumnName = "CreateDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseApplicantCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseApplicantRow[] GetAll()
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
			"[ApplicantID],"+
			"[CaseID],"+
			"[Gender],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[RequestAmount],"+
			"[Score],"+
			"[HasProxy],"+
			"[DeletedFlag],"+
			"[UserCreateCaseID],"+
			"[CreateDate],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseApplicant]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseApplicant]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseApplicant"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("RequestAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Score",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("HasProxy",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("DeletedFlag",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("UserCreateCaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseApplicantRow[] GetByCaseID(int caseID)
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
		public CaseApplicantRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseApplicantRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseApplicantRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseApplicantRow"/> objects.</returns>
		public virtual CaseApplicantRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseApplicant]", top);
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
		public CaseApplicantRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseApplicantRow[] rows = null;
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
		public DataTable GetCaseApplicantPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ApplicantID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ApplicantID) AS TotalRow FROM [dbo].[CaseApplicant] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,CaseID,Gender,Title,FirstName,LastName,RequestAmount,Score,HasProxy,DeletedFlag,UserCreateCaseID,CreateDate,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseApplicant] " + whereSql +
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
		public CaseApplicantItemsPaging GetCaseApplicantPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		CaseApplicantItemsPaging obj = new CaseApplicantItemsPaging();
		DataTable dt = GetCaseApplicantPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseApplicantItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseApplicantItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			if (dt.Rows[i]["RequestAmount"] != DBNull.Value)
			record.RequestAmount = Convert.ToDouble(dt.Rows[i]["RequestAmount"]);
			if (dt.Rows[i]["Score"] != DBNull.Value)
			record.Score = Convert.ToInt32(dt.Rows[i]["Score"]);
			if (dt.Rows[i]["HasProxy"] != DBNull.Value)
			record.HasProxy = Convert.ToBoolean(dt.Rows[i]["HasProxy"]);
			if (dt.Rows[i]["DeletedFlag"] != DBNull.Value)
			record.DeletedFlag = Convert.ToBoolean(dt.Rows[i]["DeletedFlag"]);
			if (dt.Rows[i]["UserCreateCaseID"] != DBNull.Value)
			record.UserCreateCaseID = Convert.ToInt32(dt.Rows[i]["UserCreateCaseID"]);
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseApplicantItems = (CaseApplicantItems[])(recordList.ToArray(typeof(CaseApplicantItems)));
		return obj;
		}
		public CaseApplicantRow GetByPrimaryKey(int applicantID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			CaseApplicantRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseApplicantRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicant] (" +
			"[ApplicantID], " + 
			"[CaseID], " + 
			"[Gender], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[RequestAmount], " + 
			"[Score], " + 
			"[HasProxy], " + 
			"[DeletedFlag], " + 
			"[UserCreateCaseID], " + 
			"[CreateDate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("RequestAmount") + ", " +
			CreateSqlParameterName("Score") + ", " +
			CreateSqlParameterName("HasProxy") + ", " +
			CreateSqlParameterName("DeletedFlag") + ", " +
			CreateSqlParameterName("UserCreateCaseID") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "Gender", value.IsGenderNull ? DBNull.Value : (object)value.Gender);
			AddParameter(cmd, "Title", value.IsTitleNull ? DBNull.Value : (object)value.Title);
			AddParameter(cmd, "FirstName", value.IsFirstNameNull ? DBNull.Value : (object)value.FirstName);
			AddParameter(cmd, "LastName", value.IsLastNameNull ? DBNull.Value : (object)value.LastName);
			AddParameter(cmd, "RequestAmount", value.IsRequestAmountNull ? DBNull.Value : (object)value.RequestAmount);
			AddParameter(cmd, "Score", value.IsScoreNull ? DBNull.Value : (object)value.Score);
			AddParameter(cmd, "HasProxy", value.IsHasProxyNull ? DBNull.Value : (object)value.HasProxy);
			AddParameter(cmd, "DeletedFlag", value.IsDeletedFlagNull ? DBNull.Value : (object)value.DeletedFlag);
			AddParameter(cmd, "UserCreateCaseID", value.IsUserCreateCaseIDNull ? DBNull.Value : (object)value.UserCreateCaseID);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseApplicantRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicant] (" +
			"[ApplicantID], " + 
			"[CaseID], " + 
			"[Gender], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[RequestAmount], " + 
			"[Score], " + 
			"[HasProxy], " + 
			"[DeletedFlag], " + 
			"[UserCreateCaseID], " + 
			"[CreateDate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("RequestAmount") + ", " +
			CreateSqlParameterName("Score") + ", " +
			CreateSqlParameterName("HasProxy") + ", " +
			CreateSqlParameterName("DeletedFlag") + ", " +
			CreateSqlParameterName("UserCreateCaseID") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "Gender", value.IsGenderNull ? DBNull.Value : (object)value.Gender);
			AddParameter(cmd, "Title", value.IsTitleNull ? DBNull.Value : (object)value.Title);
			AddParameter(cmd, "FirstName", value.IsFirstNameNull ? DBNull.Value : (object)value.FirstName);
			AddParameter(cmd, "LastName", value.IsLastNameNull ? DBNull.Value : (object)value.LastName);
			AddParameter(cmd, "RequestAmount", value.IsRequestAmountNull ? DBNull.Value : (object)value.RequestAmount);
			AddParameter(cmd, "Score", value.IsScoreNull ? DBNull.Value : (object)value.Score);
			AddParameter(cmd, "HasProxy", value.IsHasProxyNull ? DBNull.Value : (object)value.HasProxy);
			AddParameter(cmd, "DeletedFlag", value.IsDeletedFlagNull ? DBNull.Value : (object)value.DeletedFlag);
			AddParameter(cmd, "UserCreateCaseID", value.IsUserCreateCaseIDNull ? DBNull.Value : (object)value.UserCreateCaseID);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseApplicantRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
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
				if (value._IsSetRequestAmount)
				{
					strUpdate += "[RequestAmount]=" + CreateSqlParameterName("RequestAmount") + ",";
				}
				if (value._IsSetScore)
				{
					strUpdate += "[Score]=" + CreateSqlParameterName("Score") + ",";
				}
				if (value._IsSetHasProxy)
				{
					strUpdate += "[HasProxy]=" + CreateSqlParameterName("HasProxy") + ",";
				}
				if (value._IsSetDeletedFlag)
				{
					strUpdate += "[DeletedFlag]=" + CreateSqlParameterName("DeletedFlag") + ",";
				}
				if (value._IsSetUserCreateCaseID)
				{
					strUpdate += "[UserCreateCaseID]=" + CreateSqlParameterName("UserCreateCaseID") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicant] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
				if (value._IsSetCaseID)
				{
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
				}
					AddParameter(cmd, "Gender", value.Gender);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
				if (value._IsSetRequestAmount)
				{
					AddParameter(cmd, "RequestAmount", value.IsRequestAmountNull ? DBNull.Value : (object)value.RequestAmount);
				}
				if (value._IsSetScore)
				{
					AddParameter(cmd, "Score", value.IsScoreNull ? DBNull.Value : (object)value.Score);
				}
				if (value._IsSetHasProxy)
				{
					AddParameter(cmd, "HasProxy", value.IsHasProxyNull ? DBNull.Value : (object)value.HasProxy);
				}
				if (value._IsSetDeletedFlag)
				{
					AddParameter(cmd, "DeletedFlag", value.IsDeletedFlagNull ? DBNull.Value : (object)value.DeletedFlag);
				}
				if (value._IsSetUserCreateCaseID)
				{
					AddParameter(cmd, "UserCreateCaseID", value.IsUserCreateCaseIDNull ? DBNull.Value : (object)value.UserCreateCaseID);
				}
				if (value._IsSetCreateDate)
				{
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
				}
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseApplicantRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
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
				if (value._IsSetRequestAmount)
				{
					strUpdate += "[RequestAmount]=" + CreateSqlParameterName("RequestAmount") + ",";
				}
				if (value._IsSetScore)
				{
					strUpdate += "[Score]=" + CreateSqlParameterName("Score") + ",";
				}
				if (value._IsSetHasProxy)
				{
					strUpdate += "[HasProxy]=" + CreateSqlParameterName("HasProxy") + ",";
				}
				if (value._IsSetDeletedFlag)
				{
					strUpdate += "[DeletedFlag]=" + CreateSqlParameterName("DeletedFlag") + ",";
				}
				if (value._IsSetUserCreateCaseID)
				{
					strUpdate += "[UserCreateCaseID]=" + CreateSqlParameterName("UserCreateCaseID") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicant] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
				if (value._IsSetCaseID)
				{
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
				}
					AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
				if (value._IsSetRequestAmount)
				{
					AddParameter(cmd, "RequestAmount", value.IsRequestAmountNull ? DBNull.Value : (object)value.RequestAmount);
				}
				if (value._IsSetScore)
				{
					AddParameter(cmd, "Score", value.IsScoreNull ? DBNull.Value : (object)value.Score);
				}
				if (value._IsSetHasProxy)
				{
					AddParameter(cmd, "HasProxy", value.IsHasProxyNull ? DBNull.Value : (object)value.HasProxy);
				}
				if (value._IsSetDeletedFlag)
				{
					AddParameter(cmd, "DeletedFlag", value.IsDeletedFlagNull ? DBNull.Value : (object)value.DeletedFlag);
				}
				if (value._IsSetUserCreateCaseID)
				{
					AddParameter(cmd, "UserCreateCaseID", value.IsUserCreateCaseIDNull ? DBNull.Value : (object)value.UserCreateCaseID);
				}
				if (value._IsSetCreateDate)
				{
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
				}
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int applicantID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
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
		protected CaseApplicantRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseApplicantRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseApplicantRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int requestAmountColumnIndex = reader.GetOrdinal("RequestAmount");
			int scoreColumnIndex = reader.GetOrdinal("Score");
			int hasProxyColumnIndex = reader.GetOrdinal("HasProxy");
			int deletedFlagColumnIndex = reader.GetOrdinal("DeletedFlag");
			int userCreateCaseIDColumnIndex = reader.GetOrdinal("UserCreateCaseID");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
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
					CaseApplicantRow record = new CaseApplicantRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(requestAmountColumnIndex)) record.RequestAmount =  Convert.ToDouble(reader.GetValue(requestAmountColumnIndex));

					if (!reader.IsDBNull(scoreColumnIndex)) record.Score =  Convert.ToInt32(reader.GetValue(scoreColumnIndex));

					if (!reader.IsDBNull(hasProxyColumnIndex)) record.HasProxy =  Convert.ToBoolean(reader.GetValue(hasProxyColumnIndex));

					if (!reader.IsDBNull(deletedFlagColumnIndex)) record.DeletedFlag =  Convert.ToBoolean(reader.GetValue(deletedFlagColumnIndex));

					if (!reader.IsDBNull(userCreateCaseIDColumnIndex)) record.UserCreateCaseID =  Convert.ToInt32(reader.GetValue(userCreateCaseIDColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

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
			return (CaseApplicantRow[])(recordList.ToArray(typeof(CaseApplicantRow)));
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
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RequestAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Score":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "HasProxy":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "DeletedFlag":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "UserCreateCaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
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

