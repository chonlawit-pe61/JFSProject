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
	public partial class CaseVictimCollection_Base : MarshalByRefObject
	{
		public const string VictimIDColumnName = "VictimID";
		public const string CaseIDColumnName = "CaseID";
		public const string HasContactColumnName = "HasContact";
		public const string AdditionalContactInfoColumnName = "AdditionalContactInfo";
		public const string HasMitigateColumnName = "HasMitigate";
		public const string AdditionalMitigateInfoColumnName = "AdditionalMitigateInfo";
		public const string AddressIDColumnName = "AddressID";
		public const string VictimDisputantNameColumnName = "VictimDisputantName";
		public const string VictimDisputantTelNoColumnName = "VictimDisputantTelNo";
		public const string VictimDisputantAgeColumnName = "VictimDisputantAge";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseVictimCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseVictimRow[] GetAll()
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
			"[VictimID],"+
			"[CaseID],"+
			"[HasContact],"+
			"[AdditionalContactInfo],"+
			"[HasMitigate],"+
			"[AdditionalMitigateInfo],"+
			"[AddressID],"+
			"[VictimDisputantName],"+
			"[VictimDisputantTelNo],"+
			"[VictimDisputantAge],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseVictim]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseVictim]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseVictim"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("VictimID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("HasContact",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("AdditionalContactInfo",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("HasMitigate",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("AdditionalMitigateInfo",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("VictimDisputantName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("VictimDisputantTelNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("VictimDisputantAge",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseVictimRow[] GetByCaseID(int caseID)
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
		public virtual CaseVictimRow[] GetByAddressID(int addressID)
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
		public CaseVictimRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseVictimRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseVictimRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseVictimRow"/> objects.</returns>
		public virtual CaseVictimRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseVictim]", top);
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
		public CaseVictimRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseVictimRow[] rows = null;
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
		public DataTable GetCaseVictimPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "VictimID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "VictimID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(VictimID) AS TotalRow FROM [dbo].[CaseVictim] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,VictimID,CaseID,HasContact,AdditionalContactInfo,HasMitigate,AdditionalMitigateInfo,AddressID,VictimDisputantName,VictimDisputantTelNo,VictimDisputantAge,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseVictim] " + whereSql +
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
		public CaseVictimItemsPaging GetCaseVictimPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "VictimID")
		{
		CaseVictimItemsPaging obj = new CaseVictimItemsPaging();
		DataTable dt = GetCaseVictimPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseVictimItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseVictimItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.VictimID = Convert.ToInt32(dt.Rows[i]["VictimID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["HasContact"] != DBNull.Value)
			record.HasContact = Convert.ToBoolean(dt.Rows[i]["HasContact"]);
			record.AdditionalContactInfo = dt.Rows[i]["AdditionalContactInfo"].ToString();
			if (dt.Rows[i]["HasMitigate"] != DBNull.Value)
			record.HasMitigate = Convert.ToBoolean(dt.Rows[i]["HasMitigate"]);
			record.AdditionalMitigateInfo = dt.Rows[i]["AdditionalMitigateInfo"].ToString();
			if (dt.Rows[i]["AddressID"] != DBNull.Value)
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			record.VictimDisputantName = dt.Rows[i]["VictimDisputantName"].ToString();
			record.VictimDisputantTelNo = dt.Rows[i]["VictimDisputantTelNo"].ToString();
			if (dt.Rows[i]["VictimDisputantAge"] != DBNull.Value)
			record.VictimDisputantAge = Convert.ToInt32(dt.Rows[i]["VictimDisputantAge"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseVictimItems = (CaseVictimItems[])(recordList.ToArray(typeof(CaseVictimItems)));
		return obj;
		}
		public CaseVictimRow GetByPrimaryKey(int victimID)
		{
			string whereSql = "[VictimID]=" + CreateSqlParameterName("VictimID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "VictimID", victimID);
			CaseVictimRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseVictimRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseVictim] (" +
			"[VictimID], " + 
			"[CaseID], " + 
			"[HasContact], " + 
			"[AdditionalContactInfo], " + 
			"[HasMitigate], " + 
			"[AdditionalMitigateInfo], " + 
			"[AddressID], " + 
			"[VictimDisputantName], " + 
			"[VictimDisputantTelNo], " + 
			"[VictimDisputantAge], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("VictimID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("HasContact") + ", " +
			CreateSqlParameterName("AdditionalContactInfo") + ", " +
			CreateSqlParameterName("HasMitigate") + ", " +
			CreateSqlParameterName("AdditionalMitigateInfo") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("VictimDisputantName") + ", " +
			CreateSqlParameterName("VictimDisputantTelNo") + ", " +
			CreateSqlParameterName("VictimDisputantAge") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "VictimID", value.VictimID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "HasContact", value.IsHasContactNull ? DBNull.Value : (object)value.HasContact);
			AddParameter(cmd, "AdditionalContactInfo", value.AdditionalContactInfo);
			AddParameter(cmd, "HasMitigate", value.IsHasMitigateNull ? DBNull.Value : (object)value.HasMitigate);
			AddParameter(cmd, "AdditionalMitigateInfo", value.AdditionalMitigateInfo);
			AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
			AddParameter(cmd, "VictimDisputantName", value.VictimDisputantName);
			AddParameter(cmd, "VictimDisputantTelNo", value.VictimDisputantTelNo);
			AddParameter(cmd, "VictimDisputantAge", value.IsVictimDisputantAgeNull ? DBNull.Value : (object)value.VictimDisputantAge);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseVictimRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseVictim] (" +
			"[VictimID], " + 
			"[CaseID], " + 
			"[HasContact], " + 
			"[AdditionalContactInfo], " + 
			"[HasMitigate], " + 
			"[AdditionalMitigateInfo], " + 
			"[AddressID], " + 
			"[VictimDisputantName], " + 
			"[VictimDisputantTelNo], " + 
			"[VictimDisputantAge], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("VictimID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("HasContact") + ", " +
			CreateSqlParameterName("AdditionalContactInfo") + ", " +
			CreateSqlParameterName("HasMitigate") + ", " +
			CreateSqlParameterName("AdditionalMitigateInfo") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("VictimDisputantName") + ", " +
			CreateSqlParameterName("VictimDisputantTelNo") + ", " +
			CreateSqlParameterName("VictimDisputantAge") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "VictimID", value.VictimID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "HasContact", value.IsHasContactNull ? DBNull.Value : (object)value.HasContact);
			AddParameter(cmd, "AdditionalContactInfo", Sanitizer.GetSafeHtmlFragment(value.AdditionalContactInfo));
			AddParameter(cmd, "HasMitigate", value.IsHasMitigateNull ? DBNull.Value : (object)value.HasMitigate);
			AddParameter(cmd, "AdditionalMitigateInfo", Sanitizer.GetSafeHtmlFragment(value.AdditionalMitigateInfo));
			AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
			AddParameter(cmd, "VictimDisputantName", Sanitizer.GetSafeHtmlFragment(value.VictimDisputantName));
			AddParameter(cmd, "VictimDisputantTelNo", Sanitizer.GetSafeHtmlFragment(value.VictimDisputantTelNo));
			AddParameter(cmd, "VictimDisputantAge", value.IsVictimDisputantAgeNull ? DBNull.Value : (object)value.VictimDisputantAge);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseVictimRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetVictimID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetHasContact)
				{
					strUpdate += "[HasContact]=" + CreateSqlParameterName("HasContact") + ",";
				}
				if (value._IsSetAdditionalContactInfo)
				{
					strUpdate += "[AdditionalContactInfo]=" + CreateSqlParameterName("AdditionalContactInfo") + ",";
				}
				if (value._IsSetHasMitigate)
				{
					strUpdate += "[HasMitigate]=" + CreateSqlParameterName("HasMitigate") + ",";
				}
				if (value._IsSetAdditionalMitigateInfo)
				{
					strUpdate += "[AdditionalMitigateInfo]=" + CreateSqlParameterName("AdditionalMitigateInfo") + ",";
				}
				if (value._IsSetAddressID)
				{
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID") + ",";
				}
				if (value._IsSetVictimDisputantName)
				{
					strUpdate += "[VictimDisputantName]=" + CreateSqlParameterName("VictimDisputantName") + ",";
				}
				if (value._IsSetVictimDisputantTelNo)
				{
					strUpdate += "[VictimDisputantTelNo]=" + CreateSqlParameterName("VictimDisputantTelNo") + ",";
				}
				if (value._IsSetVictimDisputantAge)
				{
					strUpdate += "[VictimDisputantAge]=" + CreateSqlParameterName("VictimDisputantAge") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseVictim] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[VictimID]=" + CreateSqlParameterName("VictimID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "VictimID", value.VictimID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "HasContact", value.IsHasContactNull ? DBNull.Value : (object)value.HasContact);
					AddParameter(cmd, "AdditionalContactInfo", value.AdditionalContactInfo);
					AddParameter(cmd, "HasMitigate", value.IsHasMitigateNull ? DBNull.Value : (object)value.HasMitigate);
					AddParameter(cmd, "AdditionalMitigateInfo", value.AdditionalMitigateInfo);
					AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
					AddParameter(cmd, "VictimDisputantName", value.VictimDisputantName);
					AddParameter(cmd, "VictimDisputantTelNo", value.VictimDisputantTelNo);
					AddParameter(cmd, "VictimDisputantAge", value.IsVictimDisputantAgeNull ? DBNull.Value : (object)value.VictimDisputantAge);
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
				Exception ex = new Exception("Set incorrect primarykey PK(VictimID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseVictimRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetVictimID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetHasContact)
				{
					strUpdate += "[HasContact]=" + CreateSqlParameterName("HasContact") + ",";
				}
				if (value._IsSetAdditionalContactInfo)
				{
					strUpdate += "[AdditionalContactInfo]=" + CreateSqlParameterName("AdditionalContactInfo") + ",";
				}
				if (value._IsSetHasMitigate)
				{
					strUpdate += "[HasMitigate]=" + CreateSqlParameterName("HasMitigate") + ",";
				}
				if (value._IsSetAdditionalMitigateInfo)
				{
					strUpdate += "[AdditionalMitigateInfo]=" + CreateSqlParameterName("AdditionalMitigateInfo") + ",";
				}
				if (value._IsSetAddressID)
				{
					strUpdate += "[AddressID]=" + CreateSqlParameterName("AddressID") + ",";
				}
				if (value._IsSetVictimDisputantName)
				{
					strUpdate += "[VictimDisputantName]=" + CreateSqlParameterName("VictimDisputantName") + ",";
				}
				if (value._IsSetVictimDisputantTelNo)
				{
					strUpdate += "[VictimDisputantTelNo]=" + CreateSqlParameterName("VictimDisputantTelNo") + ",";
				}
				if (value._IsSetVictimDisputantAge)
				{
					strUpdate += "[VictimDisputantAge]=" + CreateSqlParameterName("VictimDisputantAge") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseVictim] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[VictimID]=" + CreateSqlParameterName("VictimID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "VictimID", value.VictimID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "HasContact", value.IsHasContactNull ? DBNull.Value : (object)value.HasContact);
					AddParameter(cmd, "AdditionalContactInfo", Sanitizer.GetSafeHtmlFragment(value.AdditionalContactInfo));
					AddParameter(cmd, "HasMitigate", value.IsHasMitigateNull ? DBNull.Value : (object)value.HasMitigate);
					AddParameter(cmd, "AdditionalMitigateInfo", Sanitizer.GetSafeHtmlFragment(value.AdditionalMitigateInfo));
					AddParameter(cmd, "AddressID", value.IsAddressIDNull ? DBNull.Value : (object)value.AddressID);
					AddParameter(cmd, "VictimDisputantName", Sanitizer.GetSafeHtmlFragment(value.VictimDisputantName));
					AddParameter(cmd, "VictimDisputantTelNo", Sanitizer.GetSafeHtmlFragment(value.VictimDisputantTelNo));
					AddParameter(cmd, "VictimDisputantAge", value.IsVictimDisputantAgeNull ? DBNull.Value : (object)value.VictimDisputantAge);
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
				Exception ex = new Exception("Set incorrect primarykey PK(VictimID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int victimID)
		{
			string whereSql = "[VictimID]=" + CreateSqlParameterName("VictimID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "VictimID", victimID);
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
		protected CaseVictimRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseVictimRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseVictimRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int victimIDColumnIndex = reader.GetOrdinal("VictimID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int hasContactColumnIndex = reader.GetOrdinal("HasContact");
			int additionalContactInfoColumnIndex = reader.GetOrdinal("AdditionalContactInfo");
			int hasMitigateColumnIndex = reader.GetOrdinal("HasMitigate");
			int additionalMitigateInfoColumnIndex = reader.GetOrdinal("AdditionalMitigateInfo");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int victimDisputantNameColumnIndex = reader.GetOrdinal("VictimDisputantName");
			int victimDisputantTelNoColumnIndex = reader.GetOrdinal("VictimDisputantTelNo");
			int victimDisputantAgeColumnIndex = reader.GetOrdinal("VictimDisputantAge");
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
					CaseVictimRow record = new CaseVictimRow();
					recordList.Add(record);
					record.VictimID =  Convert.ToInt32(reader.GetValue(victimIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					if (!reader.IsDBNull(hasContactColumnIndex)) record.HasContact =  Convert.ToBoolean(reader.GetValue(hasContactColumnIndex));

					if (!reader.IsDBNull(additionalContactInfoColumnIndex)) record.AdditionalContactInfo =  Convert.ToString(reader.GetValue(additionalContactInfoColumnIndex));

					if (!reader.IsDBNull(hasMitigateColumnIndex)) record.HasMitigate =  Convert.ToBoolean(reader.GetValue(hasMitigateColumnIndex));

					if (!reader.IsDBNull(additionalMitigateInfoColumnIndex)) record.AdditionalMitigateInfo =  Convert.ToString(reader.GetValue(additionalMitigateInfoColumnIndex));

					if (!reader.IsDBNull(addressIDColumnIndex)) record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));

					if (!reader.IsDBNull(victimDisputantNameColumnIndex)) record.VictimDisputantName =  Convert.ToString(reader.GetValue(victimDisputantNameColumnIndex));

					if (!reader.IsDBNull(victimDisputantTelNoColumnIndex)) record.VictimDisputantTelNo =  Convert.ToString(reader.GetValue(victimDisputantTelNoColumnIndex));

					if (!reader.IsDBNull(victimDisputantAgeColumnIndex)) record.VictimDisputantAge =  Convert.ToInt32(reader.GetValue(victimDisputantAgeColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseVictimRow[])(recordList.ToArray(typeof(CaseVictimRow)));
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
				case "VictimID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "HasContact":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "AdditionalContactInfo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "HasMitigate":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "AdditionalMitigateInfo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "VictimDisputantName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "VictimDisputantTelNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "VictimDisputantAge":
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

