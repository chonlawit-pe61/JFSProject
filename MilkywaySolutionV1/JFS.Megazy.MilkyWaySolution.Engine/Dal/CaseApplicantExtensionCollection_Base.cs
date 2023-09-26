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
	public partial class CaseApplicantExtensionCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string CardIDColumnName = "CardID";
		public const string CardTypeColumnName = "CardType";
		public const string GenderColumnName = "Gender";
		public const string AgeColumnName = "Age";
		public const string IssuedAtColumnName = "IssuedAt";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string RaceIDColumnName = "RaceID";
		public const string ReligionIDColumnName = "ReligionID";
		public const string NationalityIDColumnName = "NationalityID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseApplicantExtensionCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseApplicantExtensionRow[] GetAll()
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
			"[CardID],"+
			"[CardType],"+
			"[Gender],"+
			"[Age],"+
			"[IssuedAt],"+
			"[DateOfBirth],"+
			"[RaceID],"+
			"[ReligionID],"+
			"[NationalityID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseApplicantExtension]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseApplicantExtension]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseApplicantExtension"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CardType",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("Age",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IssuedAt",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseApplicantExtensionRow[] GetByApplicantID(int applicantID)
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
		public virtual CaseApplicantExtensionRow[] GetByCardType(int cardType)
		{
			return MapRecords(CreateGetByCardTypeCommand(cardType));
		}
		public virtual DataTable GetByCardTypeAsDataTable(int cardType)
		{
			return MapRecordsToDataTable(CreateGetByCardTypeCommand(cardType));
		}
		protected virtual IDbCommand CreateGetByCardTypeCommand(int cardType)
		{
			string whereSql = "";
			whereSql += "[CardType]=" + CreateSqlParameterName("CardType");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CardType", cardType);
			return cmd;
		}
		public virtual CaseApplicantExtensionRow[] GetByGender(string gender)
		{
			return MapRecords(CreateGetByGenderCommand(gender));
		}
		public virtual DataTable GetByGenderAsDataTable(string gender)
		{
			return MapRecordsToDataTable(CreateGetByGenderCommand(gender));
		}
		protected virtual IDbCommand CreateGetByGenderCommand(string gender)
		{
			string whereSql = "";
			whereSql += "[Gender]=" + CreateSqlParameterName("Gender");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "Gender", gender);
			return cmd;
		}
		public virtual CaseApplicantExtensionRow[] GetByRaceID(int raceID)
		{
			return MapRecords(CreateGetByRaceIDCommand(raceID));
		}
		public virtual DataTable GetByRaceIDAsDataTable(int raceID)
		{
			return MapRecordsToDataTable(CreateGetByRaceIDCommand(raceID));
		}
		protected virtual IDbCommand CreateGetByRaceIDCommand(int raceID)
		{
			string whereSql = "";
			whereSql += "[RaceID]=" + CreateSqlParameterName("RaceID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RaceID", raceID);
			return cmd;
		}
		public virtual CaseApplicantExtensionRow[] GetByReligionID(int religionID)
		{
			return MapRecords(CreateGetByReligionIDCommand(religionID));
		}
		public virtual DataTable GetByReligionIDAsDataTable(int religionID)
		{
			return MapRecordsToDataTable(CreateGetByReligionIDCommand(religionID));
		}
		protected virtual IDbCommand CreateGetByReligionIDCommand(int religionID)
		{
			string whereSql = "";
			whereSql += "[ReligionID]=" + CreateSqlParameterName("ReligionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ReligionID", religionID);
			return cmd;
		}
		public virtual CaseApplicantExtensionRow[] GetByNationalityID(int nationalityID)
		{
			return MapRecords(CreateGetByNationalityIDCommand(nationalityID));
		}
		public virtual DataTable GetByNationalityIDAsDataTable(int nationalityID)
		{
			return MapRecordsToDataTable(CreateGetByNationalityIDCommand(nationalityID));
		}
		protected virtual IDbCommand CreateGetByNationalityIDCommand(int nationalityID)
		{
			string whereSql = "";
			whereSql += "[NationalityID]=" + CreateSqlParameterName("NationalityID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "NationalityID", nationalityID);
			return cmd;
		}
		public CaseApplicantExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseApplicantExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseApplicantExtensionRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseApplicantExtensionRow"/> objects.</returns>
		public virtual CaseApplicantExtensionRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseApplicantExtension]", top);
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
		public CaseApplicantExtensionRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseApplicantExtensionRow[] rows = null;
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
		public DataTable GetCaseApplicantExtensionPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
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
		string sql = "SELECT COUNT(ApplicantID) AS TotalRow FROM [dbo].[CaseApplicantExtension] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,CardID,CardType,Gender,Age,IssuedAt,DateOfBirth,RaceID,ReligionID,NationalityID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseApplicantExtension] " + whereSql +
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
		public CaseApplicantExtensionItemsPaging GetCaseApplicantExtensionPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		CaseApplicantExtensionItemsPaging obj = new CaseApplicantExtensionItemsPaging();
		DataTable dt = GetCaseApplicantExtensionPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseApplicantExtensionItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseApplicantExtensionItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.CardID = dt.Rows[i]["CardID"].ToString();
			if (dt.Rows[i]["CardType"] != DBNull.Value)
			record.CardType = Convert.ToInt32(dt.Rows[i]["CardType"]);
			record.Gender = dt.Rows[i]["Gender"].ToString();
			if (dt.Rows[i]["Age"] != DBNull.Value)
			record.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
			record.IssuedAt = dt.Rows[i]["IssuedAt"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			if (dt.Rows[i]["ReligionID"] != DBNull.Value)
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseApplicantExtensionItems = (CaseApplicantExtensionItems[])(recordList.ToArray(typeof(CaseApplicantExtensionItems)));
		return obj;
		}
		public CaseApplicantExtensionRow GetByPrimaryKey(int applicantID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			CaseApplicantExtensionRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseApplicantExtensionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantExtension] (" +
			"[ApplicantID], " + 
			"[CardID], " + 
			"[CardType], " + 
			"[Gender], " + 
			"[Age], " + 
			"[IssuedAt], " + 
			"[DateOfBirth], " + 
			"[RaceID], " + 
			"[ReligionID], " + 
			"[NationalityID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("CardType") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("Age") + ", " +
			CreateSqlParameterName("IssuedAt") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("RaceID") + ", " +
			CreateSqlParameterName("ReligionID") + ", " +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "CardID", value.IsCardIDNull ? DBNull.Value : (object)value.CardID);
			AddParameter(cmd, "CardType", value.IsCardTypeNull ? DBNull.Value : (object)value.CardType);
			AddParameter(cmd, "Gender", value.IsGenderNull ? DBNull.Value : (object)value.Gender);
			AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
			AddParameter(cmd, "IssuedAt", value.IsIssuedAtNull ? DBNull.Value : (object)value.IssuedAt);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
			AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
			AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseApplicantExtensionRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantExtension] (" +
			"[ApplicantID], " + 
			"[CardID], " + 
			"[CardType], " + 
			"[Gender], " + 
			"[Age], " + 
			"[IssuedAt], " + 
			"[DateOfBirth], " + 
			"[RaceID], " + 
			"[ReligionID], " + 
			"[NationalityID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("CardType") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("Age") + ", " +
			CreateSqlParameterName("IssuedAt") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("RaceID") + ", " +
			CreateSqlParameterName("ReligionID") + ", " +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "CardID", value.IsCardIDNull ? DBNull.Value : (object)value.CardID);
			AddParameter(cmd, "CardType", value.IsCardTypeNull ? DBNull.Value : (object)value.CardType);
			AddParameter(cmd, "Gender", value.IsGenderNull ? DBNull.Value : (object)value.Gender);
			AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
			AddParameter(cmd, "IssuedAt", value.IsIssuedAtNull ? DBNull.Value : (object)value.IssuedAt);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
			AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
			AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseApplicantExtensionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetCardType)
				{
					strUpdate += "[CardType]=" + CreateSqlParameterName("CardType") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetAge)
				{
					strUpdate += "[Age]=" + CreateSqlParameterName("Age") + ",";
				}
				if (value._IsSetIssuedAt)
				{
					strUpdate += "[IssuedAt]=" + CreateSqlParameterName("IssuedAt") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetRaceID)
				{
					strUpdate += "[RaceID]=" + CreateSqlParameterName("RaceID") + ",";
				}
				if (value._IsSetReligionID)
				{
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID") + ",";
				}
				if (value._IsSetNationalityID)
				{
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantExtension] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "CardID", value.CardID);
				if (value._IsSetCardType)
				{
					AddParameter(cmd, "CardType", value.IsCardTypeNull ? DBNull.Value : (object)value.CardType);
				}
					AddParameter(cmd, "Gender", value.Gender);
				if (value._IsSetAge)
				{
					AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
				}
					AddParameter(cmd, "IssuedAt", value.IssuedAt);
				if (value._IsSetDateOfBirth)
				{
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
				}
				if (value._IsSetRaceID)
				{
					AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
				}
				if (value._IsSetReligionID)
				{
					AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
				}
				if (value._IsSetNationalityID)
				{
					AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
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
		public bool UpdateOnlyPlainText(CaseApplicantExtensionRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetCardType)
				{
					strUpdate += "[CardType]=" + CreateSqlParameterName("CardType") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetAge)
				{
					strUpdate += "[Age]=" + CreateSqlParameterName("Age") + ",";
				}
				if (value._IsSetIssuedAt)
				{
					strUpdate += "[IssuedAt]=" + CreateSqlParameterName("IssuedAt") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetRaceID)
				{
					strUpdate += "[RaceID]=" + CreateSqlParameterName("RaceID") + ",";
				}
				if (value._IsSetReligionID)
				{
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID") + ",";
				}
				if (value._IsSetNationalityID)
				{
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantExtension] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
				if (value._IsSetCardType)
				{
					AddParameter(cmd, "CardType", value.IsCardTypeNull ? DBNull.Value : (object)value.CardType);
				}
					AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
				if (value._IsSetAge)
				{
					AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
				}
					AddParameter(cmd, "IssuedAt", Sanitizer.GetSafeHtmlFragment(value.IssuedAt));
				if (value._IsSetDateOfBirth)
				{
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
				}
				if (value._IsSetRaceID)
				{
					AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
				}
				if (value._IsSetReligionID)
				{
					AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
				}
				if (value._IsSetNationalityID)
				{
					AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
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
		public int DeleteByCardType(int cardType)
		{
			return DeleteByCardType(cardType, false);
		}
		public int DeleteByCardType(int cardType, bool cardTypeNull)
		{
			return CreateDeleteByCardTypeCommand(cardType, cardTypeNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCardTypeCommand(int cardType, bool cardTypeNull)
		{
			string whereSql = "";
			if (cardTypeNull)
				whereSql += "[CardType] IS NULL";
			else
				whereSql += "[CardType]=" + CreateSqlParameterName("CardType");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!cardTypeNull)
				AddParameter(cmd, "CardType", cardType);
			return cmd;
		}
		public int DeleteByGender(string gender)
		{
			return DeleteByGender(gender, false);
		}
		public int DeleteByGender(string gender, bool genderNull)
		{
			return CreateDeleteByGenderCommand(gender, genderNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByGenderCommand(string gender, bool genderNull)
		{
			string whereSql = "";
			if (genderNull)
				whereSql += "[Gender] IS NULL";
			else
				whereSql += "[Gender]=" + CreateSqlParameterName("Gender");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!genderNull)
				AddParameter(cmd, "Gender", gender);
			return cmd;
		}
		public int DeleteByRaceID(int raceID)
		{
			return DeleteByRaceID(raceID, false);
		}
		public int DeleteByRaceID(int raceID, bool raceIDNull)
		{
			return CreateDeleteByRaceIDCommand(raceID, raceIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByRaceIDCommand(int raceID, bool raceIDNull)
		{
			string whereSql = "";
			if (raceIDNull)
				whereSql += "[RaceID] IS NULL";
			else
				whereSql += "[RaceID]=" + CreateSqlParameterName("RaceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!raceIDNull)
				AddParameter(cmd, "RaceID", raceID);
			return cmd;
		}
		public int DeleteByReligionID(int religionID)
		{
			return DeleteByReligionID(religionID, false);
		}
		public int DeleteByReligionID(int religionID, bool religionIDNull)
		{
			return CreateDeleteByReligionIDCommand(religionID, religionIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByReligionIDCommand(int religionID, bool religionIDNull)
		{
			string whereSql = "";
			if (religionIDNull)
				whereSql += "[ReligionID] IS NULL";
			else
				whereSql += "[ReligionID]=" + CreateSqlParameterName("ReligionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!religionIDNull)
				AddParameter(cmd, "ReligionID", religionID);
			return cmd;
		}
		public int DeleteByNationalityID(int nationalityID)
		{
			return DeleteByNationalityID(nationalityID, false);
		}
		public int DeleteByNationalityID(int nationalityID, bool nationalityIDNull)
		{
			return CreateDeleteByNationalityIDCommand(nationalityID, nationalityIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByNationalityIDCommand(int nationalityID, bool nationalityIDNull)
		{
			string whereSql = "";
			if (nationalityIDNull)
				whereSql += "[NationalityID] IS NULL";
			else
				whereSql += "[NationalityID]=" + CreateSqlParameterName("NationalityID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!nationalityIDNull)
				AddParameter(cmd, "NationalityID", nationalityID);
			return cmd;
		}
		protected CaseApplicantExtensionRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseApplicantExtensionRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseApplicantExtensionRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int cardTypeColumnIndex = reader.GetOrdinal("CardType");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int ageColumnIndex = reader.GetOrdinal("Age");
			int issuedAtColumnIndex = reader.GetOrdinal("IssuedAt");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
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
					CaseApplicantExtensionRow record = new CaseApplicantExtensionRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(cardTypeColumnIndex)) record.CardType =  Convert.ToInt32(reader.GetValue(cardTypeColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(ageColumnIndex)) record.Age =  Convert.ToInt32(reader.GetValue(ageColumnIndex));

					if (!reader.IsDBNull(issuedAtColumnIndex)) record.IssuedAt =  Convert.ToString(reader.GetValue(issuedAtColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(religionIDColumnIndex)) record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

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
			return (CaseApplicantExtensionRow[])(recordList.ToArray(typeof(CaseApplicantExtensionRow)));
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
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CardType":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Age":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IssuedAt":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityID":
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

