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
	public partial class CaseApplicantRequestCollection_Base : MarshalByRefObject
	{
		public const string TransactionIDColumnName = "TransactionID";
		public const string ReferenceMSCIDColumnName = "ReferenceMSCID";
		public const string ReferenceMSCCodeColumnName = "ReferenceMSCCode";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string SubjectColumnName = "Subject";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string GenderColumnName = "Gender";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string ProvinceNameColumnName = "ProvinceName";
		public const string PostCodeColumnName = "PostCode";
		public const string CardIDColumnName = "CardID";
		public const string DefactiveColumnName = "Defactive";
		public const string RemarkColumnName = "Remark";
		public const string CreateDateColumnName = "CreateDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string StatusIDColumnName = "StatusID";
		public const string CentralColumnName = "Central";
		public const string ChannelIDColumnName = "ChannelID";
		public const string EmailColumnName = "Email";
		public const string AttachFileIDColumnName = "AttachFileID";
		public const string AddressIDColumnName = "AddressID";
		public const string RaceIDColumnName = "RaceID";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string EducationLevelColumnName = "EducationLevel";
		public const string ReligionIDColumnName = "ReligionID";
		public const string NationalityIDColumnName = "NationalityID";
		public const string IsAgreeColumnName = "IsAgree";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseApplicantRequestCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseApplicantRequestRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual CaseApplicantRequestPaging GetPagingRelyOnTransactionIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseApplicantRequestPaging caseApplicantRequestPaging = new CaseApplicantRequestPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionID) as TotalRow from [dbo].[CaseApplicantRequest]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseApplicantRequestPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseApplicantRequestPaging.totalPage = (int)Math.Ceiling((double) caseApplicantRequestPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseApplicantRequestPaging.caseApplicantRequestRow = MapRecords(command);
			return caseApplicantRequestPaging;
		}
		public virtual CaseApplicantRequestPaging GetPagingRelyOnTransactionIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseApplicantRequestPaging caseApplicantRequestPaging = new CaseApplicantRequestPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionID) as TotalRow from [dbo].[CaseApplicantRequest]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseApplicantRequestPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseApplicantRequestPaging.totalPage = (int)Math.Ceiling((double)caseApplicantRequestPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseApplicantRequestPaging.caseApplicantRequestRow = MapRecords(command);
			return caseApplicantRequestPaging;
		}
		public virtual CaseApplicantRequestRow[] GetPagingRelyOnTransactionIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID < " + minTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID < " + minTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseApplicantRequestRow[] GetPagingRelyOnTransactionIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID > " + minTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID > " + minTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseApplicantRequestRow[] GetPagingRelyOnTransactionIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID < " + maxTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID < " + maxTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseApplicantRequestRow[] GetPagingRelyOnTransactionIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionID > " + maxTransactionID.ToString();
			}
			else
			{
				whereSql = "TransactionID > " + maxTransactionID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, "TransactionID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseApplicantRequestRow[] GetPagingRelyOnTransactionIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			CaseApplicantRequestRow[] caseApplicantRequestRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseApplicantRequestRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseApplicantRequestRow = MapRecords(command);
			}
			return caseApplicantRequestRow;
		}
		public virtual CaseApplicantRequestRow[] GetPagingRelyOnTransactionIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			CaseApplicantRequestRow[] caseApplicantRequestRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseApplicantRequestRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseApplicantRequestRow = MapRecords(command);
			}
			return caseApplicantRequestRow;
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
			"[ReferenceMSCID],"+
			"[ReferenceMSCCode],"+
			"[ProvinceID],"+
			"[DepartmentID],"+
			"[Subject],"+
			"[TelephoneNo],"+
			"[Gender],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[ProvinceName],"+
			"[PostCode],"+
			"[CardID],"+
			"[Defactive],"+
			"[Remark],"+
			"[CreateDate],"+
			"[ModifiedDate],"+
			"[StatusID],"+
			"[Central],"+
			"[ChannelID],"+
			"[Email],"+
			"[AttachFileID],"+
			"[AddressID],"+
			"[RaceID],"+
			"[DateOfBirth],"+
			"[EducationLevel],"+
			"[ReligionID],"+
			"[NationalityID],"+
			"[IsAgree]"+
			" FROM [dbo].[CaseApplicantRequest]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseApplicantRequest]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionID Desc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseApplicantRequest] where TransactionID < (select min(minTransactionID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionID as minTransactionID from [dbo].[CaseApplicantRequest]" + subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseApplicantRequest]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionID Asc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseApplicantRequest] where TransactionID > (select max(maxTransactionID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionID as maxTransactionID from [dbo].[CaseApplicantRequest]" +  subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CaseApplicantRequest]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseApplicantRequest]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseApplicantRequest"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ReferenceMSCID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("ProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("PostCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("Defactive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("StatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Central",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("ChannelID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("AttachFileID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("EducationLevel",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsAgree",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public virtual CaseApplicantRequestRow[] GetByStatusID(int statusID)
		{
			return MapRecords(CreateGetByStatusIDCommand(statusID));
		}
		public virtual DataTable GetByStatusIDAsDataTable(int statusID)
		{
			return MapRecordsToDataTable(CreateGetByStatusIDCommand(statusID));
		}
		protected virtual IDbCommand CreateGetByStatusIDCommand(int statusID)
		{
			string whereSql = "";
			whereSql += "[StatusID]=" + CreateSqlParameterName("StatusID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "StatusID", statusID);
			return cmd;
		}
		public virtual CaseApplicantRequestRow[] GetByChannelID(int channelID)
		{
			return MapRecords(CreateGetByChannelIDCommand(channelID));
		}
		public virtual DataTable GetByChannelIDAsDataTable(int channelID)
		{
			return MapRecordsToDataTable(CreateGetByChannelIDCommand(channelID));
		}
		protected virtual IDbCommand CreateGetByChannelIDCommand(int channelID)
		{
			string whereSql = "";
			whereSql += "[ChannelID]=" + CreateSqlParameterName("ChannelID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ChannelID", channelID);
			return cmd;
		}
		public virtual CaseApplicantRequestRow[] GetByAttachFileID(int attachFileID)
		{
			return MapRecords(CreateGetByAttachFileIDCommand(attachFileID));
		}
		public virtual DataTable GetByAttachFileIDAsDataTable(int attachFileID)
		{
			return MapRecordsToDataTable(CreateGetByAttachFileIDCommand(attachFileID));
		}
		protected virtual IDbCommand CreateGetByAttachFileIDCommand(int attachFileID)
		{
			string whereSql = "";
			whereSql += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AttachFileID", attachFileID);
			return cmd;
		}
		public virtual CaseApplicantRequestRow[] GetByAddressID(int addressID)
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
		public CaseApplicantRequestRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseApplicantRequestRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseApplicantRequestRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseApplicantRequestRow"/> objects.</returns>
		public virtual CaseApplicantRequestRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseApplicantRequest]", top);
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
		public CaseApplicantRequestRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseApplicantRequestRow[] rows = null;
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
		public DataTable GetCaseApplicantRequestPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[CaseApplicantRequest] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionID,ReferenceMSCID,ReferenceMSCCode,ProvinceID,DepartmentID,Subject,TelephoneNo,Gender,Title,FirstName,LastName,ProvinceName,PostCode,CardID,Defactive,Remark,CreateDate,ModifiedDate,StatusID,Central,ChannelID,Email,AttachFileID,AddressID,RaceID,DateOfBirth,EducationLevel,ReligionID,NationalityID,IsAgree," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [CaseApplicantRequest].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseApplicantRequest] " + whereSql +
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
		public CaseApplicantRequestItemsPaging GetCaseApplicantRequestPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionID")
		{
		CaseApplicantRequestItemsPaging obj = new CaseApplicantRequestItemsPaging();
		DataTable dt = GetCaseApplicantRequestPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseApplicantRequestItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseApplicantRequestItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			if (dt.Rows[i]["ReferenceMSCID"] != DBNull.Value)
			record.ReferenceMSCID = Convert.ToInt32(dt.Rows[i]["ReferenceMSCID"]);
			record.ReferenceMSCCode = dt.Rows[i]["ReferenceMSCCode"].ToString();
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.Gender = dt.Rows[i]["Gender"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
			record.PostCode = dt.Rows[i]["PostCode"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			if (dt.Rows[i]["Defactive"] != DBNull.Value)
			record.Defactive = Convert.ToBoolean(dt.Rows[i]["Defactive"]);
			record.Remark = dt.Rows[i]["Remark"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["StatusID"] != DBNull.Value)
			record.StatusID = Convert.ToInt32(dt.Rows[i]["StatusID"]);
			record.Central = dt.Rows[i]["Central"].ToString();
			if (dt.Rows[i]["ChannelID"] != DBNull.Value)
			record.ChannelID = Convert.ToInt32(dt.Rows[i]["ChannelID"]);
			record.Email = dt.Rows[i]["Email"].ToString();
			if (dt.Rows[i]["AttachFileID"] != DBNull.Value)
			record.AttachFileID = Convert.ToInt32(dt.Rows[i]["AttachFileID"]);
			if (dt.Rows[i]["AddressID"] != DBNull.Value)
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["EducationLevel"] != DBNull.Value)
			record.EducationLevel = Convert.ToInt32(dt.Rows[i]["EducationLevel"]);
			if (dt.Rows[i]["ReligionID"] != DBNull.Value)
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			if (dt.Rows[i]["IsAgree"] != DBNull.Value)
			record.IsAgree = Convert.ToBoolean(dt.Rows[i]["IsAgree"]);
			recordList.Add(record);
		}
		obj.caseApplicantRequestItems = (CaseApplicantRequestItems[])(recordList.ToArray(typeof(CaseApplicantRequestItems)));
		return obj;
		}
		public CaseApplicantRequestRow GetByPrimaryKey(int transactionID)
		{
			string whereSql = "[TransactionID]=" + CreateSqlParameterName("TransactionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionID", transactionID);
			CaseApplicantRequestRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(CaseApplicantRequestRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantRequest] (" +
			"[ReferenceMSCID], " + 
			"[ReferenceMSCCode], " + 
			"[ProvinceID], " + 
			"[DepartmentID], " + 
			"[Subject], " + 
			"[TelephoneNo], " + 
			"[Gender], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[ProvinceName], " + 
			"[PostCode], " + 
			"[CardID], " + 
			"[Defactive], " + 
			"[Remark], " + 
			"[CreateDate], " + 
			"[ModifiedDate], " + 
			"[StatusID], " + 
			"[Central], " + 
			"[ChannelID], " + 
			"[Email], " + 
			"[AttachFileID], " + 
			"[AddressID], " + 
			"[RaceID], " + 
			"[DateOfBirth], " + 
			"[EducationLevel], " + 
			"[ReligionID], " + 
			"[NationalityID], " + 
			"[IsAgree]			" + 
			") VALUES (" +
			CreateSqlParameterName("ReferenceMSCID") + ", " +
			CreateSqlParameterName("ReferenceMSCCode") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("ProvinceName") + ", " +
			CreateSqlParameterName("PostCode") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Defactive") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("StatusID") + ", " +
			CreateSqlParameterName("Central") + ", " +
			CreateSqlParameterName("ChannelID") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("AttachFileID") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("RaceID") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("EducationLevel") + ", " +
			CreateSqlParameterName("ReligionID") + ", " +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("IsAgree") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
			AddParameter(cmd, "ReferenceMSCCode", value.ReferenceMSCCode);
			AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
			AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
			AddParameter(cmd, "Subject", value.Subject);
			AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
			AddParameter(cmd, "Gender", value.Gender);
			AddParameter(cmd, "Title", value.Title);
			AddParameter(cmd, "FirstName", value.FirstName);
			AddParameter(cmd, "LastName", value.LastName);
			AddParameter(cmd, "ProvinceName", value.ProvinceName);
			AddParameter(cmd, "PostCode", value.PostCode);
			AddParameter(cmd, "CardID", value.CardID);
			AddParameter(cmd, "Defactive", value.IsDefactiveNull ? DBNull.Value : (object)value.Defactive);
			AddParameter(cmd, "Remark", value.Remark);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "StatusID", value.IsStatusIDNull ? DBNull.Value : (object)value.StatusID);
			AddParameter(cmd, "Central", value.Central);
			AddParameter(cmd, "ChannelID", value.IsChannelIDNull ? DBNull.Value : (object)value.ChannelID);
			AddParameter(cmd, "Email", value.Email);
			AddParameter(cmd, "AttachFileID", value.IsAttachFileIDNull ? DBNull.Value : (object)value.AttachFileID);
			AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
			AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "EducationLevel", value.IsEducationLevelNull ? DBNull.Value : (object)value.EducationLevel);
			AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
			AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
			AddParameter(cmd, "IsAgree", value.IsIsAgreeNull ? DBNull.Value : (object)value.IsAgree);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(CaseApplicantRequestRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantRequest] (" +
			"[ReferenceMSCID], " + 
			"[ReferenceMSCCode], " + 
			"[ProvinceID], " + 
			"[DepartmentID], " + 
			"[Subject], " + 
			"[TelephoneNo], " + 
			"[Gender], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[ProvinceName], " + 
			"[PostCode], " + 
			"[CardID], " + 
			"[Defactive], " + 
			"[Remark], " + 
			"[CreateDate], " + 
			"[ModifiedDate], " + 
			"[StatusID], " + 
			"[Central], " + 
			"[ChannelID], " + 
			"[Email], " + 
			"[AttachFileID], " + 
			"[AddressID], " + 
			"[RaceID], " + 
			"[DateOfBirth], " + 
			"[EducationLevel], " + 
			"[ReligionID], " + 
			"[NationalityID], " + 
			"[IsAgree]			" + 
			") VALUES (" +
			CreateSqlParameterName("ReferenceMSCID") + ", " +
			CreateSqlParameterName("ReferenceMSCCode") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("ProvinceName") + ", " +
			CreateSqlParameterName("PostCode") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Defactive") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("StatusID") + ", " +
			CreateSqlParameterName("Central") + ", " +
			CreateSqlParameterName("ChannelID") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("AttachFileID") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("RaceID") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("EducationLevel") + ", " +
			CreateSqlParameterName("ReligionID") + ", " +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("IsAgree") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
			AddParameter(cmd, "ReferenceMSCCode", Sanitizer.GetSafeHtmlFragment(value.ReferenceMSCCode));
			AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
			AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
			AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
			AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
			AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "ProvinceName", Sanitizer.GetSafeHtmlFragment(value.ProvinceName));
			AddParameter(cmd, "PostCode", Sanitizer.GetSafeHtmlFragment(value.PostCode));
			AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
			AddParameter(cmd, "Defactive", value.IsDefactiveNull ? DBNull.Value : (object)value.Defactive);
			AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "StatusID", value.IsStatusIDNull ? DBNull.Value : (object)value.StatusID);
			AddParameter(cmd, "Central", Sanitizer.GetSafeHtmlFragment(value.Central));
			AddParameter(cmd, "ChannelID", value.IsChannelIDNull ? DBNull.Value : (object)value.ChannelID);
			AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
			AddParameter(cmd, "AttachFileID", value.IsAttachFileIDNull ? DBNull.Value : (object)value.AttachFileID);
			AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
			AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "EducationLevel", value.IsEducationLevelNull ? DBNull.Value : (object)value.EducationLevel);
			AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
			AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
			AddParameter(cmd, "IsAgree", value.IsIsAgreeNull ? DBNull.Value : (object)value.IsAgree);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(CaseApplicantRequestRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetReferenceMSCID)
				{
					strUpdate += "[ReferenceMSCID]=" + CreateSqlParameterName("ReferenceMSCID") + ",";
				}
				if (value._IsSetReferenceMSCCode)
				{
					strUpdate += "[ReferenceMSCCode]=" + CreateSqlParameterName("ReferenceMSCCode") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
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
				if (value._IsSetProvinceName)
				{
					strUpdate += "[ProvinceName]=" + CreateSqlParameterName("ProvinceName") + ",";
				}
				if (value._IsSetPostCode)
				{
					strUpdate += "[PostCode]=" + CreateSqlParameterName("PostCode") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetDefactive)
				{
					strUpdate += "[Defactive]=" + CreateSqlParameterName("Defactive") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetStatusID)
				{
					strUpdate += "[StatusID]=" + CreateSqlParameterName("StatusID") + ",";
				}
				if (value._IsSetCentral)
				{
					strUpdate += "[Central]=" + CreateSqlParameterName("Central") + ",";
				}
				if (value._IsSetChannelID)
				{
					strUpdate += "[ChannelID]=" + CreateSqlParameterName("ChannelID") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetAttachFileID)
				{
					strUpdate += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID") + ",";
				}
				if (value._IsSetAddressID)
				{
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID") + ",";
				}
				if (value._IsSetRaceID)
				{
					strUpdate += "[RaceID]=" + CreateSqlParameterName("RaceID") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetEducationLevel)
				{
					strUpdate += "[EducationLevel]=" + CreateSqlParameterName("EducationLevel") + ",";
				}
				if (value._IsSetReligionID)
				{
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID") + ",";
				}
				if (value._IsSetNationalityID)
				{
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID") + ",";
				}
				if (value._IsSetIsAgree)
				{
					strUpdate += "[IsAgree]=" + CreateSqlParameterName("IsAgree") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantRequest] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
					AddParameter(cmd, "ReferenceMSCCode", value.ReferenceMSCCode);
					AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
					AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
					AddParameter(cmd, "Subject", value.Subject);
					AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
					AddParameter(cmd, "Gender", value.Gender);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
					AddParameter(cmd, "ProvinceName", value.ProvinceName);
					AddParameter(cmd, "PostCode", value.PostCode);
					AddParameter(cmd, "CardID", value.CardID);
					AddParameter(cmd, "Defactive", value.IsDefactiveNull ? DBNull.Value : (object)value.Defactive);
					AddParameter(cmd, "Remark", value.Remark);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "StatusID", value.IsStatusIDNull ? DBNull.Value : (object)value.StatusID);
					AddParameter(cmd, "Central", value.Central);
					AddParameter(cmd, "ChannelID", value.IsChannelIDNull ? DBNull.Value : (object)value.ChannelID);
					AddParameter(cmd, "Email", value.Email);
					AddParameter(cmd, "AttachFileID", value.IsAttachFileIDNull ? DBNull.Value : (object)value.AttachFileID);
					AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
					AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "EducationLevel", value.IsEducationLevelNull ? DBNull.Value : (object)value.EducationLevel);
					AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
					AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
					AddParameter(cmd, "IsAgree", value.IsIsAgreeNull ? DBNull.Value : (object)value.IsAgree);
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
		public bool UpdateOnlyPlainText(CaseApplicantRequestRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetReferenceMSCID)
				{
					strUpdate += "[ReferenceMSCID]=" + CreateSqlParameterName("ReferenceMSCID") + ",";
				}
				if (value._IsSetReferenceMSCCode)
				{
					strUpdate += "[ReferenceMSCCode]=" + CreateSqlParameterName("ReferenceMSCCode") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
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
				if (value._IsSetProvinceName)
				{
					strUpdate += "[ProvinceName]=" + CreateSqlParameterName("ProvinceName") + ",";
				}
				if (value._IsSetPostCode)
				{
					strUpdate += "[PostCode]=" + CreateSqlParameterName("PostCode") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetDefactive)
				{
					strUpdate += "[Defactive]=" + CreateSqlParameterName("Defactive") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetStatusID)
				{
					strUpdate += "[StatusID]=" + CreateSqlParameterName("StatusID") + ",";
				}
				if (value._IsSetCentral)
				{
					strUpdate += "[Central]=" + CreateSqlParameterName("Central") + ",";
				}
				if (value._IsSetChannelID)
				{
					strUpdate += "[ChannelID]=" + CreateSqlParameterName("ChannelID") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetAttachFileID)
				{
					strUpdate += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID") + ",";
				}
				if (value._IsSetAddressID)
				{
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID") + ",";
				}
				if (value._IsSetRaceID)
				{
					strUpdate += "[RaceID]=" + CreateSqlParameterName("RaceID") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetEducationLevel)
				{
					strUpdate += "[EducationLevel]=" + CreateSqlParameterName("EducationLevel") + ",";
				}
				if (value._IsSetReligionID)
				{
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID") + ",";
				}
				if (value._IsSetNationalityID)
				{
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID") + ",";
				}
				if (value._IsSetIsAgree)
				{
					strUpdate += "[IsAgree]=" + CreateSqlParameterName("IsAgree") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantRequest] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionID]=" + CreateSqlParameterName("TransactionID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionID", value.TransactionID);
					AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
					AddParameter(cmd, "ReferenceMSCCode", Sanitizer.GetSafeHtmlFragment(value.ReferenceMSCCode));
					AddParameter(cmd, "ProvinceID", value.IsProvinceIDNull ? DBNull.Value : (object)value.ProvinceID);
					AddParameter(cmd, "DepartmentID", value.IsDepartmentIDNull ? DBNull.Value : (object)value.DepartmentID);
					AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
					AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
					AddParameter(cmd, "Gender", Sanitizer.GetSafeHtmlFragment(value.Gender));
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "ProvinceName", Sanitizer.GetSafeHtmlFragment(value.ProvinceName));
					AddParameter(cmd, "PostCode", Sanitizer.GetSafeHtmlFragment(value.PostCode));
					AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
					AddParameter(cmd, "Defactive", value.IsDefactiveNull ? DBNull.Value : (object)value.Defactive);
					AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "StatusID", value.IsStatusIDNull ? DBNull.Value : (object)value.StatusID);
					AddParameter(cmd, "Central", Sanitizer.GetSafeHtmlFragment(value.Central));
					AddParameter(cmd, "ChannelID", value.IsChannelIDNull ? DBNull.Value : (object)value.ChannelID);
					AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
					AddParameter(cmd, "AttachFileID", value.IsAttachFileIDNull ? DBNull.Value : (object)value.AttachFileID);
					AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
					AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "EducationLevel", value.IsEducationLevelNull ? DBNull.Value : (object)value.EducationLevel);
					AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
					AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
					AddParameter(cmd, "IsAgree", value.IsIsAgreeNull ? DBNull.Value : (object)value.IsAgree);
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
		public int DeleteByStatusID(int statusID)
		{
			return DeleteByStatusID(statusID, false);
		}
		public int DeleteByStatusID(int statusID, bool statusIDNull)
		{
			return CreateDeleteByStatusIDCommand(statusID, statusIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByStatusIDCommand(int statusID, bool statusIDNull)
		{
			string whereSql = "";
			if (statusIDNull)
				whereSql += "[StatusID] IS NULL";
			else
				whereSql += "[StatusID]=" + CreateSqlParameterName("StatusID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!statusIDNull)
				AddParameter(cmd, "StatusID", statusID);
			return cmd;
		}
		public int DeleteByChannelID(int channelID)
		{
			return DeleteByChannelID(channelID, false);
		}
		public int DeleteByChannelID(int channelID, bool channelIDNull)
		{
			return CreateDeleteByChannelIDCommand(channelID, channelIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByChannelIDCommand(int channelID, bool channelIDNull)
		{
			string whereSql = "";
			if (channelIDNull)
				whereSql += "[ChannelID] IS NULL";
			else
				whereSql += "[ChannelID]=" + CreateSqlParameterName("ChannelID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!channelIDNull)
				AddParameter(cmd, "ChannelID", channelID);
			return cmd;
		}
		public int DeleteByAttachFileID(int attachFileID)
		{
			return DeleteByAttachFileID(attachFileID, false);
		}
		public int DeleteByAttachFileID(int attachFileID, bool attachFileIDNull)
		{
			return CreateDeleteByAttachFileIDCommand(attachFileID, attachFileIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAttachFileIDCommand(int attachFileID, bool attachFileIDNull)
		{
			string whereSql = "";
			if (attachFileIDNull)
				whereSql += "[AttachFileID] IS NULL";
			else
				whereSql += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!attachFileIDNull)
				AddParameter(cmd, "AttachFileID", attachFileID);
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
		protected CaseApplicantRequestRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseApplicantRequestRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseApplicantRequestRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int referenceMSCIDColumnIndex = reader.GetOrdinal("ReferenceMSCID");
			int referenceMSCCodeColumnIndex = reader.GetOrdinal("ReferenceMSCCode");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int provinceNameColumnIndex = reader.GetOrdinal("ProvinceName");
			int postCodeColumnIndex = reader.GetOrdinal("PostCode");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int defactiveColumnIndex = reader.GetOrdinal("Defactive");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int statusIDColumnIndex = reader.GetOrdinal("StatusID");
			int centralColumnIndex = reader.GetOrdinal("Central");
			int channelIDColumnIndex = reader.GetOrdinal("ChannelID");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int attachFileIDColumnIndex = reader.GetOrdinal("AttachFileID");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int educationLevelColumnIndex = reader.GetOrdinal("EducationLevel");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int isAgreeColumnIndex = reader.GetOrdinal("IsAgree");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					CaseApplicantRequestRow record = new CaseApplicantRequestRow();
					recordList.Add(record);
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(referenceMSCIDColumnIndex)) record.ReferenceMSCID =  Convert.ToInt32(reader.GetValue(referenceMSCIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCCodeColumnIndex)) record.ReferenceMSCCode =  Convert.ToString(reader.GetValue(referenceMSCCodeColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(provinceNameColumnIndex)) record.ProvinceName =  Convert.ToString(reader.GetValue(provinceNameColumnIndex));

					if (!reader.IsDBNull(postCodeColumnIndex)) record.PostCode =  Convert.ToString(reader.GetValue(postCodeColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(defactiveColumnIndex)) record.Defactive =  Convert.ToBoolean(reader.GetValue(defactiveColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(statusIDColumnIndex)) record.StatusID =  Convert.ToInt32(reader.GetValue(statusIDColumnIndex));

					if (!reader.IsDBNull(centralColumnIndex)) record.Central =  Convert.ToString(reader.GetValue(centralColumnIndex));

					if (!reader.IsDBNull(channelIDColumnIndex)) record.ChannelID =  Convert.ToInt32(reader.GetValue(channelIDColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(attachFileIDColumnIndex)) record.AttachFileID =  Convert.ToInt32(reader.GetValue(attachFileIDColumnIndex));

					if (!reader.IsDBNull(addressIDColumnIndex)) record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(educationLevelColumnIndex)) record.EducationLevel =  Convert.ToInt32(reader.GetValue(educationLevelColumnIndex));

					if (!reader.IsDBNull(religionIDColumnIndex)) record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

					if (!reader.IsDBNull(isAgreeColumnIndex)) record.IsAgree =  Convert.ToBoolean(reader.GetValue(isAgreeColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseApplicantRequestRow[])(recordList.ToArray(typeof(CaseApplicantRequestRow)));
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
				case "ReferenceMSCID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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
				case "ProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "PostCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Defactive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "StatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Central":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ChannelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AttachFileID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "EducationLevel":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsAgree":
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

