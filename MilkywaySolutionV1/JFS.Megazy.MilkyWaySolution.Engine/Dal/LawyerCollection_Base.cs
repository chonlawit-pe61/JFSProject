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
	public partial class LawyerCollection_Base : MarshalByRefObject
	{
		public const string LawyerIDColumnName = "LawyerID";
		public const string LawyerTypeIDColumnName = "LawyerTypeID";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string CardIDColumnName = "CardID";
        public const string GenderColumnName = "Gender";
		public const string LicenseNoColumnName = "LicenseNo";
		public const string LicenseTypeColumnName = "LicenseType";
		public const string IssueDateColumnName = "IssueDate";
		public const string ExprieDateColumnName = "ExprieDate";
		public const string EmailColumnName = "Email";
		public const string MobileNoColumnName = "MobileNo";
		public const string EducationColumnName = "Education";
		public const string RemarkColumnName = "Remark";
		public const string NumberOfConductCaseColumnName = "NumberOfConductCase";
		public const string YearsExperienceColumnName = "YearsExperience";
		public const string RegisterDateColumnName = "RegisterDate";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string LawyerStatusIDColumnName = "LawyerStatusID";
		private int _processID;
		public SqlCommand cmd = null;
		public LawyerCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual LawyerRow[] GetAll()
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
			"[LawyerID],"+
			"[LawyerTypeID],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[CardID],"+
			"[Gender],"+
			"[LicenseNo],"+
			"[LicenseType],"+
			"[IssueDate],"+
			"[ExprieDate],"+
			"[Email],"+
			"[MobileNo],"+
			"[Education],"+
			"[Remark],"+
			"[NumberOfConductCase],"+
			"[YearsExperience],"+
			"[RegisterDate],"+
			"[DateOfBirth],"+
			"[ModifiedDate],"+
			"[LawyerStatusID]"+
			" FROM [dbo].[Lawyer]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Lawyer]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Lawyer"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("LawyerID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LawyerTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("LicenseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LicenseType",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("IssueDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ExprieDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("MobileNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Education",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("NumberOfConductCase",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("YearsExperience",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RegisterDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("LawyerStatusID",Type.GetType("System.Int32"));
			return dataTable;
		}
		public virtual LawyerRow[] GetByLawyerTypeID(int lawyerTypeID)
		{
			return MapRecords(CreateGetByLawyerTypeIDCommand(lawyerTypeID));
		}
		public virtual DataTable GetByLawyerTypeIDAsDataTable(int lawyerTypeID)
		{
			return MapRecordsToDataTable(CreateGetByLawyerTypeIDCommand(lawyerTypeID));
		}
		protected virtual IDbCommand CreateGetByLawyerTypeIDCommand(int lawyerTypeID)
		{
			string whereSql = "";
			whereSql += "[LawyerTypeID]=" + CreateSqlParameterName("LawyerTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LawyerTypeID", lawyerTypeID);
			return cmd;
		}
		public virtual LawyerRow[] GetByLawyerStatusID(int lawyerStatusID)
		{
			return MapRecords(CreateGetByLawyerStatusIDCommand(lawyerStatusID));
		}
		public virtual DataTable GetByLawyerStatusIDAsDataTable(int lawyerStatusID)
		{
			return MapRecordsToDataTable(CreateGetByLawyerStatusIDCommand(lawyerStatusID));
		}
		protected virtual IDbCommand CreateGetByLawyerStatusIDCommand(int lawyerStatusID)
		{
			string whereSql = "";
			whereSql += "[LawyerStatusID]=" + CreateSqlParameterName("LawyerStatusID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LawyerStatusID", lawyerStatusID);
			return cmd;
		}
		public LawyerRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual LawyerRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="LawyerRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LawyerRow"/> objects.</returns>
		public virtual LawyerRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Lawyer]", top);
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
		public LawyerRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			LawyerRow[] rows = null;
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
		public DataTable GetLawyerPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LawyerID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "LawyerID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(LawyerID) AS TotalRow FROM [dbo].[Lawyer] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,LawyerID,LawyerTypeID,Title,FirstName,LastName,CardID,Gender,LicenseNo,LicenseType,IssueDate,ExprieDate,Email,MobileNo,Education,Remark,NumberOfConductCase,YearsExperience,RegisterDate,DateOfBirth,ModifiedDate,LawyerStatusID," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Lawyer] " + whereSql +
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
		public LawyerItemsPaging GetLawyerPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LawyerID")
		{
		LawyerItemsPaging obj = new LawyerItemsPaging();
		DataTable dt = GetLawyerPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		LawyerItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new LawyerItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.LawyerID = Convert.ToInt32(dt.Rows[i]["LawyerID"]);
			if (dt.Rows[i]["LawyerTypeID"] != DBNull.Value)
			record.LawyerTypeID = Convert.ToInt32(dt.Rows[i]["LawyerTypeID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.LicenseNo = dt.Rows[i]["LicenseNo"].ToString();
			record.LicenseType = dt.Rows[i]["LicenseType"].ToString();
			if (dt.Rows[i]["IssueDate"] != DBNull.Value)
			record.IssueDate = Convert.ToDateTime(dt.Rows[i]["IssueDate"]);
			if (dt.Rows[i]["ExprieDate"] != DBNull.Value)
			record.ExprieDate = Convert.ToDateTime(dt.Rows[i]["ExprieDate"]);
			record.Email = dt.Rows[i]["Email"].ToString();
			record.MobileNo = dt.Rows[i]["MobileNo"].ToString();
			record.Education = dt.Rows[i]["Education"].ToString();
			record.Remark = dt.Rows[i]["Remark"].ToString();
			if (dt.Rows[i]["NumberOfConductCase"] != DBNull.Value)
			record.NumberOfConductCase = Convert.ToInt32(dt.Rows[i]["NumberOfConductCase"]);
			if (dt.Rows[i]["YearsExperience"] != DBNull.Value)
			record.YearsExperience = Convert.ToInt32(dt.Rows[i]["YearsExperience"]);
			if (dt.Rows[i]["RegisterDate"] != DBNull.Value)
			record.RegisterDate = Convert.ToDateTime(dt.Rows[i]["RegisterDate"]);
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["LawyerStatusID"] != DBNull.Value)
			record.LawyerStatusID = Convert.ToInt32(dt.Rows[i]["LawyerStatusID"]);
			recordList.Add(record);
		}
		obj.lawyerItems = (LawyerItems[])(recordList.ToArray(typeof(LawyerItems)));
		return obj;
		}
		public LawyerRow GetByPrimaryKey(int lawyerID)
		{
			string whereSql = "[LawyerID]=" + CreateSqlParameterName("LawyerID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LawyerID", lawyerID);
			LawyerRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(LawyerRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Lawyer] (" +
			"[LawyerID], " + 
			"[LawyerTypeID], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[CardID], " + 
			"[Gender], " + 
			"[LicenseNo], " + 
			"[LicenseType], " + 
			"[IssueDate], " + 
			"[ExprieDate], " + 
			"[Email], " + 
			"[MobileNo], " + 
			"[Education], " + 
			"[Remark], " + 
			"[NumberOfConductCase], " + 
			"[YearsExperience], " + 
			"[RegisterDate], " + 
			"[DateOfBirth], " + 
			"[ModifiedDate], " + 
			"[LawyerStatusID]			" + 
			") VALUES (" +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("LawyerTypeID") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("LicenseNo") + ", " +
			CreateSqlParameterName("LicenseType") + ", " +
			CreateSqlParameterName("IssueDate") + ", " +
			CreateSqlParameterName("ExprieDate") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("MobileNo") + ", " +
			CreateSqlParameterName("Education") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("NumberOfConductCase") + ", " +
			CreateSqlParameterName("YearsExperience") + ", " +
			CreateSqlParameterName("RegisterDate") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("LawyerStatusID") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "LawyerID", value.LawyerID);
			AddParameter(cmd, "LawyerTypeID", value.IsLawyerTypeIDNull ? DBNull.Value : (object)value.LawyerTypeID);
			AddParameter(cmd, "Title", value.Title);
			AddParameter(cmd, "FirstName", value.FirstName);
			AddParameter(cmd, "LastName", value.LastName);
			AddParameter(cmd, "CardID", value.CardID);
			AddParameter(cmd, "Gender", value.Gender);
			AddParameter(cmd, "LicenseNo", value.LicenseNo);
			AddParameter(cmd, "LicenseType", value.LicenseType);
			AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
			AddParameter(cmd, "ExprieDate", value.IsExprieDateNull ? DBNull.Value : (object)value.ExprieDate);
			AddParameter(cmd, "Email", value.Email);
			AddParameter(cmd, "MobileNo", value.MobileNo);
			AddParameter(cmd, "Education", value.Education);
			AddParameter(cmd, "Remark", value.Remark);
			AddParameter(cmd, "NumberOfConductCase", value.IsNumberOfConductCaseNull ? DBNull.Value : (object)value.NumberOfConductCase);
			AddParameter(cmd, "YearsExperience", value.IsYearsExperienceNull ? DBNull.Value : (object)value.YearsExperience);
			AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "LawyerStatusID", value.IsLawyerStatusIDNull ? DBNull.Value : (object)value.LawyerStatusID);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(LawyerRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Lawyer] (" +
			"[LawyerID], " + 
			"[LawyerTypeID], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[CardID], " + 
			"[Gender], " + 
			"[LicenseNo], " + 
			"[LicenseType], " + 
			"[IssueDate], " + 
			"[ExprieDate], " + 
			"[Email], " + 
			"[MobileNo], " + 
			"[Education], " + 
			"[Remark], " + 
			"[NumberOfConductCase], " + 
			"[YearsExperience], " + 
			"[RegisterDate], " + 
			"[DateOfBirth], " + 
			"[ModifiedDate], " + 
			"[LawyerStatusID]			" + 
			") VALUES (" +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("LawyerTypeID") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("LicenseNo") + ", " +
			CreateSqlParameterName("LicenseType") + ", " +
			CreateSqlParameterName("IssueDate") + ", " +
			CreateSqlParameterName("ExprieDate") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("MobileNo") + ", " +
			CreateSqlParameterName("Education") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("NumberOfConductCase") + ", " +
			CreateSqlParameterName("YearsExperience") + ", " +
			CreateSqlParameterName("RegisterDate") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("LawyerStatusID") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "LawyerID", value.LawyerID);
			AddParameter(cmd, "LawyerTypeID", value.IsLawyerTypeIDNull ? DBNull.Value : (object)value.LawyerTypeID);
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
			AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
			AddParameter(cmd, "LicenseNo", Sanitizer.GetSafeHtmlFragment(value.LicenseNo));
			AddParameter(cmd, "LicenseType", Sanitizer.GetSafeHtmlFragment(value.LicenseType));
			AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
			AddParameter(cmd, "ExprieDate", value.IsExprieDateNull ? DBNull.Value : (object)value.ExprieDate);
			AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
			AddParameter(cmd, "MobileNo", Sanitizer.GetSafeHtmlFragment(value.MobileNo));
			AddParameter(cmd, "Education", Sanitizer.GetSafeHtmlFragment(value.Education));
			AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
			AddParameter(cmd, "NumberOfConductCase", value.IsNumberOfConductCaseNull ? DBNull.Value : (object)value.NumberOfConductCase);
			AddParameter(cmd, "YearsExperience", value.IsYearsExperienceNull ? DBNull.Value : (object)value.YearsExperience);
			AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "LawyerStatusID", value.IsLawyerStatusIDNull ? DBNull.Value : (object)value.LawyerStatusID);
			cmd.ExecuteNonQuery();
		}
		public bool Update(LawyerRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetLawyerID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetLawyerTypeID)
				{
					strUpdate += "[LawyerTypeID]=" + CreateSqlParameterName("LawyerTypeID") + ",";
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
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetLicenseNo)
				{
					strUpdate += "[LicenseNo]=" + CreateSqlParameterName("LicenseNo") + ",";
				}
				if (value._IsSetLicenseType)
				{
					strUpdate += "[LicenseType]=" + CreateSqlParameterName("LicenseType") + ",";
				}
				if (value._IsSetIssueDate)
				{
					strUpdate += "[IssueDate]=" + CreateSqlParameterName("IssueDate") + ",";
				}
				if (value._IsSetExprieDate)
				{
					strUpdate += "[ExprieDate]=" + CreateSqlParameterName("ExprieDate") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetMobileNo)
				{
					strUpdate += "[MobileNo]=" + CreateSqlParameterName("MobileNo") + ",";
				}
				if (value._IsSetEducation)
				{
					strUpdate += "[Education]=" + CreateSqlParameterName("Education") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetNumberOfConductCase)
				{
					strUpdate += "[NumberOfConductCase]=" + CreateSqlParameterName("NumberOfConductCase") + ",";
				}
				if (value._IsSetYearsExperience)
				{
					strUpdate += "[YearsExperience]=" + CreateSqlParameterName("YearsExperience") + ",";
				}
				if (value._IsSetRegisterDate)
				{
					strUpdate += "[RegisterDate]=" + CreateSqlParameterName("RegisterDate") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetLawyerStatusID)
				{
					strUpdate += "[LawyerStatusID]=" + CreateSqlParameterName("LawyerStatusID") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Lawyer] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "LawyerID", value.LawyerID);
					AddParameter(cmd, "LawyerTypeID", value.IsLawyerTypeIDNull ? DBNull.Value : (object)value.LawyerTypeID);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
					AddParameter(cmd, "CardID", value.CardID);
					AddParameter(cmd, "Gender", value.Gender);
					AddParameter(cmd, "LicenseNo", value.LicenseNo);
					AddParameter(cmd, "LicenseType", value.LicenseType);
					AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
					AddParameter(cmd, "ExprieDate", value.IsExprieDateNull ? DBNull.Value : (object)value.ExprieDate);
					AddParameter(cmd, "Email", value.Email);
					AddParameter(cmd, "MobileNo", value.MobileNo);
					AddParameter(cmd, "Education", value.Education);
					AddParameter(cmd, "Remark", value.Remark);
					AddParameter(cmd, "NumberOfConductCase", value.IsNumberOfConductCaseNull ? DBNull.Value : (object)value.NumberOfConductCase);
					AddParameter(cmd, "YearsExperience", value.IsYearsExperienceNull ? DBNull.Value : (object)value.YearsExperience);
					AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "LawyerStatusID", value.IsLawyerStatusIDNull ? DBNull.Value : (object)value.LawyerStatusID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(LawyerID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(LawyerRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetLawyerID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetLawyerTypeID)
				{
					strUpdate += "[LawyerTypeID]=" + CreateSqlParameterName("LawyerTypeID") + ",";
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
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetLicenseNo)
				{
					strUpdate += "[LicenseNo]=" + CreateSqlParameterName("LicenseNo") + ",";
				}
				if (value._IsSetLicenseType)
				{
					strUpdate += "[LicenseType]=" + CreateSqlParameterName("LicenseType") + ",";
				}
				if (value._IsSetIssueDate)
				{
					strUpdate += "[IssueDate]=" + CreateSqlParameterName("IssueDate") + ",";
				}
				if (value._IsSetExprieDate)
				{
					strUpdate += "[ExprieDate]=" + CreateSqlParameterName("ExprieDate") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetMobileNo)
				{
					strUpdate += "[MobileNo]=" + CreateSqlParameterName("MobileNo") + ",";
				}
				if (value._IsSetEducation)
				{
					strUpdate += "[Education]=" + CreateSqlParameterName("Education") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetNumberOfConductCase)
				{
					strUpdate += "[NumberOfConductCase]=" + CreateSqlParameterName("NumberOfConductCase") + ",";
				}
				if (value._IsSetYearsExperience)
				{
					strUpdate += "[YearsExperience]=" + CreateSqlParameterName("YearsExperience") + ",";
				}
				if (value._IsSetRegisterDate)
				{
					strUpdate += "[RegisterDate]=" + CreateSqlParameterName("RegisterDate") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetLawyerStatusID)
				{
					strUpdate += "[LawyerStatusID]=" + CreateSqlParameterName("LawyerStatusID") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Lawyer] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "LawyerID", value.LawyerID);
					AddParameter(cmd, "LawyerTypeID", value.IsLawyerTypeIDNull ? DBNull.Value : (object)value.LawyerTypeID);
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
					AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
					AddParameter(cmd, "LicenseNo", Sanitizer.GetSafeHtmlFragment(value.LicenseNo));
					AddParameter(cmd, "LicenseType", Sanitizer.GetSafeHtmlFragment(value.LicenseType));
					AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DBNull.Value : (object)value.IssueDate);
					AddParameter(cmd, "ExprieDate", value.IsExprieDateNull ? DBNull.Value : (object)value.ExprieDate);
					AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
					AddParameter(cmd, "MobileNo", Sanitizer.GetSafeHtmlFragment(value.MobileNo));
					AddParameter(cmd, "Education", Sanitizer.GetSafeHtmlFragment(value.Education));
					AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
					AddParameter(cmd, "NumberOfConductCase", value.IsNumberOfConductCaseNull ? DBNull.Value : (object)value.NumberOfConductCase);
					AddParameter(cmd, "YearsExperience", value.IsYearsExperienceNull ? DBNull.Value : (object)value.YearsExperience);
					AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "LawyerStatusID", value.IsLawyerStatusIDNull ? DBNull.Value : (object)value.LawyerStatusID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(LawyerID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int lawyerID)
		{
			string whereSql = "[LawyerID]=" + CreateSqlParameterName("LawyerID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LawyerID", lawyerID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByLawyerTypeID(int lawyerTypeID)
		{
			return DeleteByLawyerTypeID(lawyerTypeID, false);
		}
		public int DeleteByLawyerTypeID(int lawyerTypeID, bool lawyerTypeIDNull)
		{
			return CreateDeleteByLawyerTypeIDCommand(lawyerTypeID, lawyerTypeIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByLawyerTypeIDCommand(int lawyerTypeID, bool lawyerTypeIDNull)
		{
			string whereSql = "";
			if (lawyerTypeIDNull)
				whereSql += "[LawyerTypeID] IS NULL";
			else
				whereSql += "[LawyerTypeID]=" + CreateSqlParameterName("LawyerTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!lawyerTypeIDNull)
				AddParameter(cmd, "LawyerTypeID", lawyerTypeID);
			return cmd;
		}
		public int DeleteByLawyerStatusID(int lawyerStatusID)
		{
			return DeleteByLawyerStatusID(lawyerStatusID, false);
		}
		public int DeleteByLawyerStatusID(int lawyerStatusID, bool lawyerStatusIDNull)
		{
			return CreateDeleteByLawyerStatusIDCommand(lawyerStatusID, lawyerStatusIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByLawyerStatusIDCommand(int lawyerStatusID, bool lawyerStatusIDNull)
		{
			string whereSql = "";
			if (lawyerStatusIDNull)
				whereSql += "[LawyerStatusID] IS NULL";
			else
				whereSql += "[LawyerStatusID]=" + CreateSqlParameterName("LawyerStatusID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!lawyerStatusIDNull)
				AddParameter(cmd, "LawyerStatusID", lawyerStatusID);
			return cmd;
		}
		protected LawyerRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected LawyerRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected LawyerRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int lawyerIDColumnIndex = reader.GetOrdinal("LawyerID");
			int lawyerTypeIDColumnIndex = reader.GetOrdinal("LawyerTypeID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int licenseNoColumnIndex = reader.GetOrdinal("LicenseNo");
			int licenseTypeColumnIndex = reader.GetOrdinal("LicenseType");
			int issueDateColumnIndex = reader.GetOrdinal("IssueDate");
			int exprieDateColumnIndex = reader.GetOrdinal("ExprieDate");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int mobileNoColumnIndex = reader.GetOrdinal("MobileNo");
			int educationColumnIndex = reader.GetOrdinal("Education");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
			int numberOfConductCaseColumnIndex = reader.GetOrdinal("NumberOfConductCase");
			int yearsExperienceColumnIndex = reader.GetOrdinal("YearsExperience");
			int registerDateColumnIndex = reader.GetOrdinal("RegisterDate");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int lawyerStatusIDColumnIndex = reader.GetOrdinal("LawyerStatusID");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					LawyerRow record = new LawyerRow();
					recordList.Add(record);
					record.LawyerID =  Convert.ToInt32(reader.GetValue(lawyerIDColumnIndex));
					if (!reader.IsDBNull(lawyerTypeIDColumnIndex)) record.LawyerTypeID =  Convert.ToInt32(reader.GetValue(lawyerTypeIDColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(licenseNoColumnIndex)) record.LicenseNo =  Convert.ToString(reader.GetValue(licenseNoColumnIndex));

					if (!reader.IsDBNull(licenseTypeColumnIndex)) record.LicenseType =  Convert.ToString(reader.GetValue(licenseTypeColumnIndex));

					if (!reader.IsDBNull(issueDateColumnIndex)) record.IssueDate =  Convert.ToDateTime(reader.GetValue(issueDateColumnIndex));

					if (!reader.IsDBNull(exprieDateColumnIndex)) record.ExprieDate =  Convert.ToDateTime(reader.GetValue(exprieDateColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(mobileNoColumnIndex)) record.MobileNo =  Convert.ToString(reader.GetValue(mobileNoColumnIndex));

					if (!reader.IsDBNull(educationColumnIndex)) record.Education =  Convert.ToString(reader.GetValue(educationColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					if (!reader.IsDBNull(numberOfConductCaseColumnIndex)) record.NumberOfConductCase =  Convert.ToInt32(reader.GetValue(numberOfConductCaseColumnIndex));

					if (!reader.IsDBNull(yearsExperienceColumnIndex)) record.YearsExperience =  Convert.ToInt32(reader.GetValue(yearsExperienceColumnIndex));

					if (!reader.IsDBNull(registerDateColumnIndex)) record.RegisterDate =  Convert.ToDateTime(reader.GetValue(registerDateColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(lawyerStatusIDColumnIndex)) record.LawyerStatusID =  Convert.ToInt32(reader.GetValue(lawyerStatusIDColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LawyerRow[])(recordList.ToArray(typeof(LawyerRow)));
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
				case "LawyerID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LawyerTypeID":
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
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LicenseNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LicenseType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IssueDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ExprieDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MobileNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Education":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "NumberOfConductCase":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "YearsExperience":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RegisterDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "LawyerStatusID":
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

