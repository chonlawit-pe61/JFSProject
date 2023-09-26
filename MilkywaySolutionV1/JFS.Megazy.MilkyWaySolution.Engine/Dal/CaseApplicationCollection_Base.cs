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
	public partial class CaseApplicationCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string SubjectColumnName = "Subject";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string JFCaseTypeIDColumnName = "JFCaseTypeID";
		public const string ChannelIDColumnName = "ChannelID";
		public const string ReferenceCaseIDColumnName = "ReferenceCaseID";
		public const string ReferenceMSCIDColumnName = "ReferenceMSCID";
		public const string ReferenceMSCCODEColumnName = "ReferenceMSCCODE";
		public const string CreateDateColumnName = "CreateDate";
		public const string RegisterDateColumnName = "RegisterDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseApplicationCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseApplicationRow[] GetAll()
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
			"[Subject],"+
			"[DepartmentID],"+
			"[ProvinceID],"+
			"[JFCaseTypeID],"+
			"[ChannelID],"+
			"[ReferenceCaseID],"+
			"[ReferenceMSCID],"+
			"[ReferenceMSCCODE],"+
			"[CreateDate],"+
			"[RegisterDate],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseApplication]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseApplication]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseApplication"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("JFCaseTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ChannelID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ReferenceCaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCCODE",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RegisterDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseApplicationRow[] GetByDepartmentID(int departmentId)
		{
			return MapRecords(CreateGetByDepartmentIDCommand(departmentId));
		}
		public virtual DataTable GetByDepartmentIDAsDataTable(int departmentId)
		{
			return MapRecordsToDataTable(CreateGetByDepartmentIDCommand(departmentId));
		}
		protected virtual IDbCommand CreateGetByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		public virtual CaseApplicationRow[] GetByProvinceID(int provinceID)
		{
			return MapRecords(CreateGetByProvinceIDCommand(provinceID));
		}
		public virtual DataTable GetByProvinceIDAsDataTable(int provinceID)
		{
			return MapRecordsToDataTable(CreateGetByProvinceIDCommand(provinceID));
		}
		protected virtual IDbCommand CreateGetByProvinceIDCommand(int provinceID)
		{
			string whereSql = "";
			whereSql += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProvinceID", provinceID);
			return cmd;
		}
		public virtual CaseApplicationRow[] GetByJFCaseTypeID(int jFCaseTypeID)
		{
			return MapRecords(CreateGetByJFCaseTypeIDCommand(jFCaseTypeID));
		}
		public virtual DataTable GetByJFCaseTypeIDAsDataTable(int jFCaseTypeID)
		{
			return MapRecordsToDataTable(CreateGetByJFCaseTypeIDCommand(jFCaseTypeID));
		}
		protected virtual IDbCommand CreateGetByJFCaseTypeIDCommand(int jFCaseTypeID)
		{
			string whereSql = "";
			whereSql += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "JFCaseTypeID", jFCaseTypeID);
			return cmd;
		}
		public virtual CaseApplicationRow[] GetByChannelID(int channelID)
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
		public CaseApplicationRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseApplicationRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseApplicationRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseApplicationRow"/> objects.</returns>
		public virtual CaseApplicationRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseApplication]", top);
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
		public CaseApplicationRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseApplicationRow[] rows = null;
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
		public DataTable GetCaseApplicationPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
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
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[CaseApplication] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,Subject,DepartmentID,ProvinceID,JFCaseTypeID,ChannelID,ReferenceCaseID,ReferenceMSCID,ReferenceMSCCODE,CreateDate,RegisterDate,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseApplication] " + whereSql +
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
		public CaseApplicationItemsPaging GetCaseApplicationPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseApplicationItemsPaging obj = new CaseApplicationItemsPaging();
		DataTable dt = GetCaseApplicationPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseApplicationItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseApplicationItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.JFCaseTypeID = Convert.ToInt32(dt.Rows[i]["JFCaseTypeID"]);
			record.ChannelID = Convert.ToInt32(dt.Rows[i]["ChannelID"]);
			if (dt.Rows[i]["ReferenceCaseID"] != DBNull.Value)
			record.ReferenceCaseID = Convert.ToInt32(dt.Rows[i]["ReferenceCaseID"]);
			if (dt.Rows[i]["ReferenceMSCID"] != DBNull.Value)
			record.ReferenceMSCID = Convert.ToInt32(dt.Rows[i]["ReferenceMSCID"]);
			record.ReferenceMSCCODE = dt.Rows[i]["ReferenceMSCCODE"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["RegisterDate"] != DBNull.Value)
			record.RegisterDate = Convert.ToDateTime(dt.Rows[i]["RegisterDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseApplicationItems = (CaseApplicationItems[])(recordList.ToArray(typeof(CaseApplicationItems)));
		return obj;
		}
		public CaseApplicationRow GetByPrimaryKey(int caseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			CaseApplicationRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseApplicationRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplication] (" +
			"[CaseID], " + 
			"[Subject], " + 
			"[DepartmentID], " + 
			"[ProvinceID], " + 
			"[JFCaseTypeID], " + 
			"[ChannelID], " + 
			"[ReferenceCaseID], " + 
			"[ReferenceMSCID], " + 
			"[ReferenceMSCCODE], " + 
			"[CreateDate], " + 
			"[RegisterDate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("JFCaseTypeID") + ", " +
			CreateSqlParameterName("ChannelID") + ", " +
			CreateSqlParameterName("ReferenceCaseID") + ", " +
			CreateSqlParameterName("ReferenceMSCID") + ", " +
			CreateSqlParameterName("ReferenceMSCCODE") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("RegisterDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "Subject", value.IsSubjectNull ? DBNull.Value : (object)value.Subject);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
			AddParameter(cmd, "ChannelID", value.ChannelID);
			AddParameter(cmd, "ReferenceCaseID", value.IsReferenceCaseIDNull ? DBNull.Value : (object)value.ReferenceCaseID);
			AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
			AddParameter(cmd, "ReferenceMSCCODE", value.IsReferenceMSCCODENull ? DBNull.Value : (object)value.ReferenceMSCCODE);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseApplicationRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplication] (" +
			"[CaseID], " + 
			"[Subject], " + 
			"[DepartmentID], " + 
			"[ProvinceID], " + 
			"[JFCaseTypeID], " + 
			"[ChannelID], " + 
			"[ReferenceCaseID], " + 
			"[ReferenceMSCID], " + 
			"[ReferenceMSCCODE], " + 
			"[CreateDate], " + 
			"[RegisterDate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("Subject") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ProvinceID") + ", " +
			CreateSqlParameterName("JFCaseTypeID") + ", " +
			CreateSqlParameterName("ChannelID") + ", " +
			CreateSqlParameterName("ReferenceCaseID") + ", " +
			CreateSqlParameterName("ReferenceMSCID") + ", " +
			CreateSqlParameterName("ReferenceMSCCODE") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("RegisterDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "Subject", value.IsSubjectNull ? DBNull.Value : (object)value.Subject);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "ProvinceID", value.ProvinceID);
			AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
			AddParameter(cmd, "ChannelID", value.ChannelID);
			AddParameter(cmd, "ReferenceCaseID", value.IsReferenceCaseIDNull ? DBNull.Value : (object)value.ReferenceCaseID);
			AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
			AddParameter(cmd, "ReferenceMSCCODE", value.IsReferenceMSCCODENull ? DBNull.Value : (object)value.ReferenceMSCCODE);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseApplicationRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetJFCaseTypeID)
				{
					strUpdate += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID") + ",";
				}
				if (value._IsSetChannelID)
				{
					strUpdate += "[ChannelID]=" + CreateSqlParameterName("ChannelID") + ",";
				}
				if (value._IsSetReferenceCaseID)
				{
					strUpdate += "[ReferenceCaseID]=" + CreateSqlParameterName("ReferenceCaseID") + ",";
				}
				if (value._IsSetReferenceMSCID)
				{
					strUpdate += "[ReferenceMSCID]=" + CreateSqlParameterName("ReferenceMSCID") + ",";
				}
				if (value._IsSetReferenceMSCCODE)
				{
					strUpdate += "[ReferenceMSCCODE]=" + CreateSqlParameterName("ReferenceMSCCODE") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetRegisterDate)
				{
					strUpdate += "[RegisterDate]=" + CreateSqlParameterName("RegisterDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplication] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "Subject", value.Subject);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
					AddParameter(cmd, "ChannelID", value.ChannelID);
				if (value._IsSetReferenceCaseID)
				{
					AddParameter(cmd, "ReferenceCaseID", value.IsReferenceCaseIDNull ? DBNull.Value : (object)value.ReferenceCaseID);
				}
				if (value._IsSetReferenceMSCID)
				{
					AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
				}
					AddParameter(cmd, "ReferenceMSCCODE", value.ReferenceMSCCODE);
				if (value._IsSetCreateDate)
				{
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
				}
				if (value._IsSetRegisterDate)
				{
					AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseApplicationRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSubject)
				{
					strUpdate += "[Subject]=" + CreateSqlParameterName("Subject") + ",";
				}
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetProvinceID)
				{
					strUpdate += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID") + ",";
				}
				if (value._IsSetJFCaseTypeID)
				{
					strUpdate += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID") + ",";
				}
				if (value._IsSetChannelID)
				{
					strUpdate += "[ChannelID]=" + CreateSqlParameterName("ChannelID") + ",";
				}
				if (value._IsSetReferenceCaseID)
				{
					strUpdate += "[ReferenceCaseID]=" + CreateSqlParameterName("ReferenceCaseID") + ",";
				}
				if (value._IsSetReferenceMSCID)
				{
					strUpdate += "[ReferenceMSCID]=" + CreateSqlParameterName("ReferenceMSCID") + ",";
				}
				if (value._IsSetReferenceMSCCODE)
				{
					strUpdate += "[ReferenceMSCCODE]=" + CreateSqlParameterName("ReferenceMSCCODE") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetRegisterDate)
				{
					strUpdate += "[RegisterDate]=" + CreateSqlParameterName("RegisterDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplication] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "Subject", Sanitizer.GetSafeHtmlFragment(value.Subject));
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ProvinceID", value.ProvinceID);
					AddParameter(cmd, "JFCaseTypeID", value.JFCaseTypeID);
					AddParameter(cmd, "ChannelID", value.ChannelID);
				if (value._IsSetReferenceCaseID)
				{
					AddParameter(cmd, "ReferenceCaseID", value.IsReferenceCaseIDNull ? DBNull.Value : (object)value.ReferenceCaseID);
				}
				if (value._IsSetReferenceMSCID)
				{
					AddParameter(cmd, "ReferenceMSCID", value.IsReferenceMSCIDNull ? DBNull.Value : (object)value.ReferenceMSCID);
				}
					AddParameter(cmd, "ReferenceMSCCODE", Sanitizer.GetSafeHtmlFragment(value.ReferenceMSCCODE));
				if (value._IsSetCreateDate)
				{
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
				}
				if (value._IsSetRegisterDate)
				{
					AddParameter(cmd, "RegisterDate", value.IsRegisterDateNull ? DBNull.Value : (object)value.RegisterDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByDepartmentID(int departmentId)
		{
			return CreateDeleteByDepartmentIDCommand(departmentId).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		public int DeleteByProvinceID(int provinceID)
		{
			return CreateDeleteByProvinceIDCommand(provinceID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByProvinceIDCommand(int provinceID)
		{
			string whereSql = "";
			whereSql += "[ProvinceID]=" + CreateSqlParameterName("ProvinceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProvinceID", provinceID);
			return cmd;
		}
		public int DeleteByJFCaseTypeID(int jFCaseTypeID)
		{
			return CreateDeleteByJFCaseTypeIDCommand(jFCaseTypeID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByJFCaseTypeIDCommand(int jFCaseTypeID)
		{
			string whereSql = "";
			whereSql += "[JFCaseTypeID]=" + CreateSqlParameterName("JFCaseTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "JFCaseTypeID", jFCaseTypeID);
			return cmd;
		}
		public int DeleteByChannelID(int channelID)
		{
			return CreateDeleteByChannelIDCommand(channelID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByChannelIDCommand(int channelID)
		{
			string whereSql = "";
			whereSql += "[ChannelID]=" + CreateSqlParameterName("ChannelID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ChannelID", channelID);
			return cmd;
		}
		protected CaseApplicationRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseApplicationRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseApplicationRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int jFCaseTypeIDColumnIndex = reader.GetOrdinal("JFCaseTypeID");
			int channelIDColumnIndex = reader.GetOrdinal("ChannelID");
			int referenceCaseIDColumnIndex = reader.GetOrdinal("ReferenceCaseID");
			int referenceMSCIDColumnIndex = reader.GetOrdinal("ReferenceMSCID");
			int referenceMSCCODEColumnIndex = reader.GetOrdinal("ReferenceMSCCODE");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int registerDateColumnIndex = reader.GetOrdinal("RegisterDate");
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
					CaseApplicationRow record = new CaseApplicationRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));
					record.JFCaseTypeID =  Convert.ToInt32(reader.GetValue(jFCaseTypeIDColumnIndex));
					record.ChannelID =  Convert.ToInt32(reader.GetValue(channelIDColumnIndex));
					if (!reader.IsDBNull(referenceCaseIDColumnIndex)) record.ReferenceCaseID =  Convert.ToInt32(reader.GetValue(referenceCaseIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCIDColumnIndex)) record.ReferenceMSCID =  Convert.ToInt32(reader.GetValue(referenceMSCIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCCODEColumnIndex)) record.ReferenceMSCCODE =  Convert.ToString(reader.GetValue(referenceMSCCODEColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(registerDateColumnIndex)) record.RegisterDate =  Convert.ToDateTime(reader.GetValue(registerDateColumnIndex));

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
			return (CaseApplicationRow[])(recordList.ToArray(typeof(CaseApplicationRow)));
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
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "JFCaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ChannelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceCaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCCODE":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "RegisterDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
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

