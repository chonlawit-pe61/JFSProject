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
	public partial class CaseDisputeCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string CourtLevelIDColumnName = "CourtLevelID";
		public const string NotCommunicatedColumnName = "NotCommunicated";
		public const string VerdictOrCauseColumnName = "VerdictOrCause";
		public const string HasMediateColumnName = "HasMediate";
		public const string WantMediateColumnName = "WantMediate";
		public const string MediatedByColumnName = "MediatedBy";
		public const string DescriptionColumnName = "Description";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseDisputeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseDisputeRow[] GetAll()
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
			"[CourtLevelID],"+
			"[NotCommunicated],"+
			"[VerdictOrCause],"+
			"[HasMediate],"+
			"[WantMediate],"+
			"[MediatedBy],"+
			"[Description],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseDispute]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseDispute]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseDispute"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CourtLevelID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NotCommunicated",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("VerdictOrCause",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("HasMediate",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("WantMediate",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("MediatedBy",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Description",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseDisputeRow[] GetByCaseID(int caseID)
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
		public virtual CaseDisputeRow[] GetByCourtLevelID(int courtLevelID)
		{
			return MapRecords(CreateGetByCourtLevelIDCommand(courtLevelID));
		}
		public virtual DataTable GetByCourtLevelIDAsDataTable(int courtLevelID)
		{
			return MapRecordsToDataTable(CreateGetByCourtLevelIDCommand(courtLevelID));
		}
		protected virtual IDbCommand CreateGetByCourtLevelIDCommand(int courtLevelID)
		{
			string whereSql = "";
			whereSql += "[CourtLevelID]=" + CreateSqlParameterName("CourtLevelID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CourtLevelID", courtLevelID);
			return cmd;
		}
		public CaseDisputeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseDisputeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseDisputeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseDisputeRow"/> objects.</returns>
		public virtual CaseDisputeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseDispute]", top);
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
		public CaseDisputeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseDisputeRow[] rows = null;
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
		public DataTable GetCaseDisputePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
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
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[CaseDispute] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,CourtLevelID,NotCommunicated,VerdictOrCause,HasMediate,WantMediate,MediatedBy,Description,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseDispute] " + whereSql +
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
		public CaseDisputeItemsPaging GetCaseDisputePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseDisputeItemsPaging obj = new CaseDisputeItemsPaging();
		DataTable dt = GetCaseDisputePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseDisputeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseDisputeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["CourtLevelID"] != DBNull.Value)
			record.CourtLevelID = Convert.ToInt32(dt.Rows[i]["CourtLevelID"]);
			if (dt.Rows[i]["NotCommunicated"] != DBNull.Value)
			record.NotCommunicated = Convert.ToBoolean(dt.Rows[i]["NotCommunicated"]);
			record.VerdictOrCause = dt.Rows[i]["VerdictOrCause"].ToString();
			if (dt.Rows[i]["HasMediate"] != DBNull.Value)
			record.HasMediate = Convert.ToBoolean(dt.Rows[i]["HasMediate"]);
			if (dt.Rows[i]["WantMediate"] != DBNull.Value)
			record.WantMediate = Convert.ToBoolean(dt.Rows[i]["WantMediate"]);
			record.MediatedBy = dt.Rows[i]["MediatedBy"].ToString();
			record.Description = dt.Rows[i]["Description"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseDisputeItems = (CaseDisputeItems[])(recordList.ToArray(typeof(CaseDisputeItems)));
		return obj;
		}
		public CaseDisputeRow GetByPrimaryKey(int caseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			CaseDisputeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseDisputeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseDispute] (" +
			"[CaseID], " + 
			"[CourtLevelID], " + 
			"[NotCommunicated], " + 
			"[VerdictOrCause], " + 
			"[HasMediate], " + 
			"[WantMediate], " + 
			"[MediatedBy], " + 
			"[Description], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("CourtLevelID") + ", " +
			CreateSqlParameterName("NotCommunicated") + ", " +
			CreateSqlParameterName("VerdictOrCause") + ", " +
			CreateSqlParameterName("HasMediate") + ", " +
			CreateSqlParameterName("WantMediate") + ", " +
			CreateSqlParameterName("MediatedBy") + ", " +
			CreateSqlParameterName("Description") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "CourtLevelID", value.IsCourtLevelIDNull ? DBNull.Value : (object)value.CourtLevelID);
			AddParameter(cmd, "NotCommunicated", value.IsNotCommunicatedNull ? DBNull.Value : (object)value.NotCommunicated);
			AddParameter(cmd, "VerdictOrCause", value.VerdictOrCause);
			AddParameter(cmd, "HasMediate", value.IsHasMediateNull ? DBNull.Value : (object)value.HasMediate);
			AddParameter(cmd, "WantMediate", value.IsWantMediateNull ? DBNull.Value : (object)value.WantMediate);
			AddParameter(cmd, "MediatedBy", value.MediatedBy);
			AddParameter(cmd, "Description", value.Description);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseDisputeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseDispute] (" +
			"[CaseID], " + 
			"[CourtLevelID], " + 
			"[NotCommunicated], " + 
			"[VerdictOrCause], " + 
			"[HasMediate], " + 
			"[WantMediate], " + 
			"[MediatedBy], " + 
			"[Description], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("CourtLevelID") + ", " +
			CreateSqlParameterName("NotCommunicated") + ", " +
			CreateSqlParameterName("VerdictOrCause") + ", " +
			CreateSqlParameterName("HasMediate") + ", " +
			CreateSqlParameterName("WantMediate") + ", " +
			CreateSqlParameterName("MediatedBy") + ", " +
			CreateSqlParameterName("Description") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "CourtLevelID", value.IsCourtLevelIDNull ? DBNull.Value : (object)value.CourtLevelID);
			AddParameter(cmd, "NotCommunicated", value.IsNotCommunicatedNull ? DBNull.Value : (object)value.NotCommunicated);
			AddParameter(cmd, "VerdictOrCause", Sanitizer.GetSafeHtmlFragment(value.VerdictOrCause));
			AddParameter(cmd, "HasMediate", value.IsHasMediateNull ? DBNull.Value : (object)value.HasMediate);
			AddParameter(cmd, "WantMediate", value.IsWantMediateNull ? DBNull.Value : (object)value.WantMediate);
			AddParameter(cmd, "MediatedBy", Sanitizer.GetSafeHtmlFragment(value.MediatedBy));
			AddParameter(cmd, "Description", Sanitizer.GetSafeHtmlFragment(value.Description));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseDisputeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCourtLevelID)
				{
					strUpdate += "[CourtLevelID]=" + CreateSqlParameterName("CourtLevelID") + ",";
				}
				if (value._IsSetNotCommunicated)
				{
					strUpdate += "[NotCommunicated]=" + CreateSqlParameterName("NotCommunicated") + ",";
				}
				if (value._IsSetVerdictOrCause)
				{
					strUpdate += "[VerdictOrCause]=" + CreateSqlParameterName("VerdictOrCause") + ",";
				}
				if (value._IsSetHasMediate)
				{
					strUpdate += "[HasMediate]=" + CreateSqlParameterName("HasMediate") + ",";
				}
				if (value._IsSetWantMediate)
				{
					strUpdate += "[WantMediate]=" + CreateSqlParameterName("WantMediate") + ",";
				}
				if (value._IsSetMediatedBy)
				{
					strUpdate += "[MediatedBy]=" + CreateSqlParameterName("MediatedBy") + ",";
				}
				if (value._IsSetDescription)
				{
					strUpdate += "[Description]=" + CreateSqlParameterName("Description") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseDispute] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "CourtLevelID", value.IsCourtLevelIDNull ? DBNull.Value : (object)value.CourtLevelID);
					AddParameter(cmd, "NotCommunicated", value.IsNotCommunicatedNull ? DBNull.Value : (object)value.NotCommunicated);
					AddParameter(cmd, "VerdictOrCause", value.VerdictOrCause);
					AddParameter(cmd, "HasMediate", value.IsHasMediateNull ? DBNull.Value : (object)value.HasMediate);
					AddParameter(cmd, "WantMediate", value.IsWantMediateNull ? DBNull.Value : (object)value.WantMediate);
					AddParameter(cmd, "MediatedBy", value.MediatedBy);
					AddParameter(cmd, "Description", value.Description);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseDisputeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCourtLevelID)
				{
					strUpdate += "[CourtLevelID]=" + CreateSqlParameterName("CourtLevelID") + ",";
				}
				if (value._IsSetNotCommunicated)
				{
					strUpdate += "[NotCommunicated]=" + CreateSqlParameterName("NotCommunicated") + ",";
				}
				if (value._IsSetVerdictOrCause)
				{
					strUpdate += "[VerdictOrCause]=" + CreateSqlParameterName("VerdictOrCause") + ",";
				}
				if (value._IsSetHasMediate)
				{
					strUpdate += "[HasMediate]=" + CreateSqlParameterName("HasMediate") + ",";
				}
				if (value._IsSetWantMediate)
				{
					strUpdate += "[WantMediate]=" + CreateSqlParameterName("WantMediate") + ",";
				}
				if (value._IsSetMediatedBy)
				{
					strUpdate += "[MediatedBy]=" + CreateSqlParameterName("MediatedBy") + ",";
				}
				if (value._IsSetDescription)
				{
					strUpdate += "[Description]=" + CreateSqlParameterName("Description") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseDispute] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "CourtLevelID", value.IsCourtLevelIDNull ? DBNull.Value : (object)value.CourtLevelID);
					AddParameter(cmd, "NotCommunicated", value.IsNotCommunicatedNull ? DBNull.Value : (object)value.NotCommunicated);
					AddParameter(cmd, "VerdictOrCause", Sanitizer.GetSafeHtmlFragment(value.VerdictOrCause));
					AddParameter(cmd, "HasMediate", value.IsHasMediateNull ? DBNull.Value : (object)value.HasMediate);
					AddParameter(cmd, "WantMediate", value.IsWantMediateNull ? DBNull.Value : (object)value.WantMediate);
					AddParameter(cmd, "MediatedBy", Sanitizer.GetSafeHtmlFragment(value.MediatedBy));
					AddParameter(cmd, "Description", Sanitizer.GetSafeHtmlFragment(value.Description));
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
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
		public int DeleteByCourtLevelID(int courtLevelID)
		{
			return DeleteByCourtLevelID(courtLevelID, false);
		}
		public int DeleteByCourtLevelID(int courtLevelID, bool courtLevelIDNull)
		{
			return CreateDeleteByCourtLevelIDCommand(courtLevelID, courtLevelIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCourtLevelIDCommand(int courtLevelID, bool courtLevelIDNull)
		{
			string whereSql = "";
			if (courtLevelIDNull)
				whereSql += "[CourtLevelID] IS NULL";
			else
				whereSql += "[CourtLevelID]=" + CreateSqlParameterName("CourtLevelID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!courtLevelIDNull)
				AddParameter(cmd, "CourtLevelID", courtLevelID);
			return cmd;
		}
		protected CaseDisputeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseDisputeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseDisputeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int courtLevelIDColumnIndex = reader.GetOrdinal("CourtLevelID");
			int notCommunicatedColumnIndex = reader.GetOrdinal("NotCommunicated");
			int verdictOrCauseColumnIndex = reader.GetOrdinal("VerdictOrCause");
			int hasMediateColumnIndex = reader.GetOrdinal("HasMediate");
			int wantMediateColumnIndex = reader.GetOrdinal("WantMediate");
			int mediatedByColumnIndex = reader.GetOrdinal("MediatedBy");
			int descriptionColumnIndex = reader.GetOrdinal("Description");
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
					CaseDisputeRow record = new CaseDisputeRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					if (!reader.IsDBNull(courtLevelIDColumnIndex)) record.CourtLevelID =  Convert.ToInt32(reader.GetValue(courtLevelIDColumnIndex));

					if (!reader.IsDBNull(notCommunicatedColumnIndex)) record.NotCommunicated =  Convert.ToBoolean(reader.GetValue(notCommunicatedColumnIndex));

					if (!reader.IsDBNull(verdictOrCauseColumnIndex)) record.VerdictOrCause =  Convert.ToString(reader.GetValue(verdictOrCauseColumnIndex));

					if (!reader.IsDBNull(hasMediateColumnIndex)) record.HasMediate =  Convert.ToBoolean(reader.GetValue(hasMediateColumnIndex));

					if (!reader.IsDBNull(wantMediateColumnIndex)) record.WantMediate =  Convert.ToBoolean(reader.GetValue(wantMediateColumnIndex));

					if (!reader.IsDBNull(mediatedByColumnIndex)) record.MediatedBy =  Convert.ToString(reader.GetValue(mediatedByColumnIndex));

					if (!reader.IsDBNull(descriptionColumnIndex)) record.Description =  Convert.ToString(reader.GetValue(descriptionColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseDisputeRow[])(recordList.ToArray(typeof(CaseDisputeRow)));
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
				case "CourtLevelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NotCommunicated":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "VerdictOrCause":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "HasMediate":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "WantMediate":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "MediatedBy":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Description":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

