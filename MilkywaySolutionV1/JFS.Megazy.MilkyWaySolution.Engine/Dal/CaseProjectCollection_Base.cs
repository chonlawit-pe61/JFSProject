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
	public partial class CaseProjectCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string ProposerTypeIDColumnName = "ProposerTypeID";
		public const string ProposerTypeOtherColumnName = "ProposerTypeOther";
		public const string ProjectNameLocationColumnName = "ProjectNameLocation";
		public const string ProjectTitleColumnName = "ProjectTitle";
		public const string ProposerENColumnName = "ProposerEN";
		public const string ObjectiveToHelpColumnName = "ObjectiveToHelp";
		public const string ProjectInActionColumnName = "ProjectInAction";
		public const string PortfolioColumnName = "Portfolio";
		public const string ProjectObjectiveColumnName = "ProjectObjective";
		public const string ProjectResultColumnName = "ProjectResult";
		public const string ProjectTargetColumnName = "ProjectTarget";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseProjectCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseProjectRow[] GetAll()
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
			"[ProposerTypeID],"+
			"[ProposerTypeOther],"+
			"[ProjectNameLocation],"+
			"[ProjectTitle],"+
			"[ProposerEN],"+
			"[ObjectiveToHelp],"+
			"[ProjectInAction],"+
			"[Portfolio],"+
			"[ProjectObjective],"+
			"[ProjectResult],"+
			"[ProjectTarget],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseProject]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseProject]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseProject"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProposerTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ProposerTypeOther",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ProjectNameLocation",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ProjectTitle",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("ProposerEN",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ObjectiveToHelp",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ProjectInAction",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Portfolio",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ProjectObjective",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ProjectResult",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ProjectTarget",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseProjectRow[] GetByCaseID(int caseID)
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
		public virtual CaseProjectRow[] GetByProposerTypeID(int proposerTypeID)
		{
			return MapRecords(CreateGetByProposerTypeIDCommand(proposerTypeID));
		}
		public virtual DataTable GetByProposerTypeIDAsDataTable(int proposerTypeID)
		{
			return MapRecordsToDataTable(CreateGetByProposerTypeIDCommand(proposerTypeID));
		}
		protected virtual IDbCommand CreateGetByProposerTypeIDCommand(int proposerTypeID)
		{
			string whereSql = "";
			whereSql += "[ProposerTypeID]=" + CreateSqlParameterName("ProposerTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProposerTypeID", proposerTypeID);
			return cmd;
		}
		public CaseProjectRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseProjectRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseProjectRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseProjectRow"/> objects.</returns>
		public virtual CaseProjectRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseProject]", top);
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
		public CaseProjectRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseProjectRow[] rows = null;
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
		public DataTable GetCaseProjectPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
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
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[CaseProject] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,ProposerTypeID,ProposerTypeOther,ProjectNameLocation,ProjectTitle,ProposerEN,ObjectiveToHelp,ProjectInAction,Portfolio,ProjectObjective,ProjectResult,ProjectTarget,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseProject] " + whereSql +
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
		public CaseProjectItemsPaging GetCaseProjectPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseProjectItemsPaging obj = new CaseProjectItemsPaging();
		DataTable dt = GetCaseProjectPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseProjectItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseProjectItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["ProposerTypeID"] != DBNull.Value)
			record.ProposerTypeID = Convert.ToInt32(dt.Rows[i]["ProposerTypeID"]);
			record.ProposerTypeOther = dt.Rows[i]["ProposerTypeOther"].ToString();
			record.ProjectNameLocation = dt.Rows[i]["ProjectNameLocation"].ToString();
			record.ProjectTitle = dt.Rows[i]["ProjectTitle"].ToString();
			record.ProposerEN = dt.Rows[i]["ProposerEN"].ToString();
			record.ObjectiveToHelp = dt.Rows[i]["ObjectiveToHelp"].ToString();
			record.ProjectInAction = dt.Rows[i]["ProjectInAction"].ToString();
			record.Portfolio = dt.Rows[i]["Portfolio"].ToString();
			record.ProjectObjective = dt.Rows[i]["ProjectObjective"].ToString();
			record.ProjectResult = dt.Rows[i]["ProjectResult"].ToString();
			record.ProjectTarget = dt.Rows[i]["ProjectTarget"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseProjectItems = (CaseProjectItems[])(recordList.ToArray(typeof(CaseProjectItems)));
		return obj;
		}
		public CaseProjectRow GetByPrimaryKey(int caseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			CaseProjectRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseProjectRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseProject] (" +
			"[CaseID], " + 
			"[ProposerTypeID], " + 
			"[ProposerTypeOther], " + 
			"[ProjectNameLocation], " + 
			"[ProjectTitle], " + 
			"[ProposerEN], " + 
			"[ObjectiveToHelp], " + 
			"[ProjectInAction], " + 
			"[Portfolio], " + 
			"[ProjectObjective], " + 
			"[ProjectResult], " + 
			"[ProjectTarget], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ProposerTypeID") + ", " +
			CreateSqlParameterName("ProposerTypeOther") + ", " +
			CreateSqlParameterName("ProjectNameLocation") + ", " +
			CreateSqlParameterName("ProjectTitle") + ", " +
			CreateSqlParameterName("ProposerEN") + ", " +
			CreateSqlParameterName("ObjectiveToHelp") + ", " +
			CreateSqlParameterName("ProjectInAction") + ", " +
			CreateSqlParameterName("Portfolio") + ", " +
			CreateSqlParameterName("ProjectObjective") + ", " +
			CreateSqlParameterName("ProjectResult") + ", " +
			CreateSqlParameterName("ProjectTarget") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ProposerTypeID", value.IsProposerTypeIDNull ? DBNull.Value : (object)value.ProposerTypeID);
			AddParameter(cmd, "ProposerTypeOther", value.IsProposerTypeOtherNull ? DBNull.Value : (object)value.ProposerTypeOther);
			AddParameter(cmd, "ProjectNameLocation", value.IsProjectNameLocationNull ? DBNull.Value : (object)value.ProjectNameLocation);
			AddParameter(cmd, "ProjectTitle", value.IsProjectTitleNull ? DBNull.Value : (object)value.ProjectTitle);
			AddParameter(cmd, "ProposerEN", value.IsProposerENNull ? DBNull.Value : (object)value.ProposerEN);
			AddParameter(cmd, "ObjectiveToHelp", value.IsObjectiveToHelpNull ? DBNull.Value : (object)value.ObjectiveToHelp);
			AddParameter(cmd, "ProjectInAction", value.IsProjectInActionNull ? DBNull.Value : (object)value.ProjectInAction);
			AddParameter(cmd, "Portfolio", value.IsPortfolioNull ? DBNull.Value : (object)value.Portfolio);
			AddParameter(cmd, "ProjectObjective", value.IsProjectObjectiveNull ? DBNull.Value : (object)value.ProjectObjective);
			AddParameter(cmd, "ProjectResult", value.IsProjectResultNull ? DBNull.Value : (object)value.ProjectResult);
			AddParameter(cmd, "ProjectTarget", value.IsProjectTargetNull ? DBNull.Value : (object)value.ProjectTarget);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseProjectRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseProject] (" +
			"[CaseID], " + 
			"[ProposerTypeID], " + 
			"[ProposerTypeOther], " + 
			"[ProjectNameLocation], " + 
			"[ProjectTitle], " + 
			"[ProposerEN], " + 
			"[ObjectiveToHelp], " + 
			"[ProjectInAction], " + 
			"[Portfolio], " + 
			"[ProjectObjective], " + 
			"[ProjectResult], " + 
			"[ProjectTarget], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ProposerTypeID") + ", " +
			CreateSqlParameterName("ProposerTypeOther") + ", " +
			CreateSqlParameterName("ProjectNameLocation") + ", " +
			CreateSqlParameterName("ProjectTitle") + ", " +
			CreateSqlParameterName("ProposerEN") + ", " +
			CreateSqlParameterName("ObjectiveToHelp") + ", " +
			CreateSqlParameterName("ProjectInAction") + ", " +
			CreateSqlParameterName("Portfolio") + ", " +
			CreateSqlParameterName("ProjectObjective") + ", " +
			CreateSqlParameterName("ProjectResult") + ", " +
			CreateSqlParameterName("ProjectTarget") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ProposerTypeID", value.IsProposerTypeIDNull ? DBNull.Value : (object)value.ProposerTypeID);
			AddParameter(cmd, "ProposerTypeOther", value.IsProposerTypeOtherNull ? DBNull.Value : (object)value.ProposerTypeOther);
			AddParameter(cmd, "ProjectNameLocation", value.IsProjectNameLocationNull ? DBNull.Value : (object)value.ProjectNameLocation);
			AddParameter(cmd, "ProjectTitle", value.IsProjectTitleNull ? DBNull.Value : (object)value.ProjectTitle);
			AddParameter(cmd, "ProposerEN", value.IsProposerENNull ? DBNull.Value : (object)value.ProposerEN);
			AddParameter(cmd, "ObjectiveToHelp", value.IsObjectiveToHelpNull ? DBNull.Value : (object)value.ObjectiveToHelp);
			AddParameter(cmd, "ProjectInAction", value.IsProjectInActionNull ? DBNull.Value : (object)value.ProjectInAction);
			AddParameter(cmd, "Portfolio", value.IsPortfolioNull ? DBNull.Value : (object)value.Portfolio);
			AddParameter(cmd, "ProjectObjective", value.IsProjectObjectiveNull ? DBNull.Value : (object)value.ProjectObjective);
			AddParameter(cmd, "ProjectResult", value.IsProjectResultNull ? DBNull.Value : (object)value.ProjectResult);
			AddParameter(cmd, "ProjectTarget", value.IsProjectTargetNull ? DBNull.Value : (object)value.ProjectTarget);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseProjectRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProposerTypeID)
				{
					strUpdate += "[ProposerTypeID]=" + CreateSqlParameterName("ProposerTypeID") + ",";
				}
				if (value._IsSetProposerTypeOther)
				{
					strUpdate += "[ProposerTypeOther]=" + CreateSqlParameterName("ProposerTypeOther") + ",";
				}
				if (value._IsSetProjectNameLocation)
				{
					strUpdate += "[ProjectNameLocation]=" + CreateSqlParameterName("ProjectNameLocation") + ",";
				}
				if (value._IsSetProjectTitle)
				{
					strUpdate += "[ProjectTitle]=" + CreateSqlParameterName("ProjectTitle") + ",";
				}
				if (value._IsSetProposerEN)
				{
					strUpdate += "[ProposerEN]=" + CreateSqlParameterName("ProposerEN") + ",";
				}
				if (value._IsSetObjectiveToHelp)
				{
					strUpdate += "[ObjectiveToHelp]=" + CreateSqlParameterName("ObjectiveToHelp") + ",";
				}
				if (value._IsSetProjectInAction)
				{
					strUpdate += "[ProjectInAction]=" + CreateSqlParameterName("ProjectInAction") + ",";
				}
				if (value._IsSetPortfolio)
				{
					strUpdate += "[Portfolio]=" + CreateSqlParameterName("Portfolio") + ",";
				}
				if (value._IsSetProjectObjective)
				{
					strUpdate += "[ProjectObjective]=" + CreateSqlParameterName("ProjectObjective") + ",";
				}
				if (value._IsSetProjectResult)
				{
					strUpdate += "[ProjectResult]=" + CreateSqlParameterName("ProjectResult") + ",";
				}
				if (value._IsSetProjectTarget)
				{
					strUpdate += "[ProjectTarget]=" + CreateSqlParameterName("ProjectTarget") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseProject] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
				if (value._IsSetProposerTypeID)
				{
					AddParameter(cmd, "ProposerTypeID", value.IsProposerTypeIDNull ? DBNull.Value : (object)value.ProposerTypeID);
				}
					AddParameter(cmd, "ProposerTypeOther", value.ProposerTypeOther);
					AddParameter(cmd, "ProjectNameLocation", value.ProjectNameLocation);
					AddParameter(cmd, "ProjectTitle", value.ProjectTitle);
					AddParameter(cmd, "ProposerEN", value.ProposerEN);
					AddParameter(cmd, "ObjectiveToHelp", value.ObjectiveToHelp);
					AddParameter(cmd, "ProjectInAction", value.ProjectInAction);
					AddParameter(cmd, "Portfolio", value.Portfolio);
					AddParameter(cmd, "ProjectObjective", value.ProjectObjective);
					AddParameter(cmd, "ProjectResult", value.ProjectResult);
					AddParameter(cmd, "ProjectTarget", value.ProjectTarget);
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
		public bool UpdateOnlyPlainText(CaseProjectRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProposerTypeID)
				{
					strUpdate += "[ProposerTypeID]=" + CreateSqlParameterName("ProposerTypeID") + ",";
				}
				if (value._IsSetProposerTypeOther)
				{
					strUpdate += "[ProposerTypeOther]=" + CreateSqlParameterName("ProposerTypeOther") + ",";
				}
				if (value._IsSetProjectNameLocation)
				{
					strUpdate += "[ProjectNameLocation]=" + CreateSqlParameterName("ProjectNameLocation") + ",";
				}
				if (value._IsSetProjectTitle)
				{
					strUpdate += "[ProjectTitle]=" + CreateSqlParameterName("ProjectTitle") + ",";
				}
				if (value._IsSetProposerEN)
				{
					strUpdate += "[ProposerEN]=" + CreateSqlParameterName("ProposerEN") + ",";
				}
				if (value._IsSetObjectiveToHelp)
				{
					strUpdate += "[ObjectiveToHelp]=" + CreateSqlParameterName("ObjectiveToHelp") + ",";
				}
				if (value._IsSetProjectInAction)
				{
					strUpdate += "[ProjectInAction]=" + CreateSqlParameterName("ProjectInAction") + ",";
				}
				if (value._IsSetPortfolio)
				{
					strUpdate += "[Portfolio]=" + CreateSqlParameterName("Portfolio") + ",";
				}
				if (value._IsSetProjectObjective)
				{
					strUpdate += "[ProjectObjective]=" + CreateSqlParameterName("ProjectObjective") + ",";
				}
				if (value._IsSetProjectResult)
				{
					strUpdate += "[ProjectResult]=" + CreateSqlParameterName("ProjectResult") + ",";
				}
				if (value._IsSetProjectTarget)
				{
					strUpdate += "[ProjectTarget]=" + CreateSqlParameterName("ProjectTarget") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseProject] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
				if (value._IsSetProposerTypeID)
				{
					AddParameter(cmd, "ProposerTypeID", value.IsProposerTypeIDNull ? DBNull.Value : (object)value.ProposerTypeID);
				}
					AddParameter(cmd, "ProposerTypeOther", Sanitizer.GetSafeHtmlFragment(value.ProposerTypeOther));
					AddParameter(cmd, "ProjectNameLocation", Sanitizer.GetSafeHtmlFragment(value.ProjectNameLocation));
					AddParameter(cmd, "ProjectTitle", Sanitizer.GetSafeHtmlFragment(value.ProjectTitle));
					AddParameter(cmd, "ProposerEN", Sanitizer.GetSafeHtmlFragment(value.ProposerEN));
					AddParameter(cmd, "ObjectiveToHelp", Sanitizer.GetSafeHtmlFragment(value.ObjectiveToHelp));
					AddParameter(cmd, "ProjectInAction", Sanitizer.GetSafeHtmlFragment(value.ProjectInAction));
					AddParameter(cmd, "Portfolio", Sanitizer.GetSafeHtmlFragment(value.Portfolio));
					AddParameter(cmd, "ProjectObjective", Sanitizer.GetSafeHtmlFragment(value.ProjectObjective));
					AddParameter(cmd, "ProjectResult", Sanitizer.GetSafeHtmlFragment(value.ProjectResult));
					AddParameter(cmd, "ProjectTarget", Sanitizer.GetSafeHtmlFragment(value.ProjectTarget));
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
		public int DeleteByProposerTypeID(int proposerTypeID)
		{
			return DeleteByProposerTypeID(proposerTypeID, false);
		}
		public int DeleteByProposerTypeID(int proposerTypeID, bool proposerTypeIDNull)
		{
			return CreateDeleteByProposerTypeIDCommand(proposerTypeID, proposerTypeIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByProposerTypeIDCommand(int proposerTypeID, bool proposerTypeIDNull)
		{
			string whereSql = "";
			if (proposerTypeIDNull)
				whereSql += "[ProposerTypeID] IS NULL";
			else
				whereSql += "[ProposerTypeID]=" + CreateSqlParameterName("ProposerTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!proposerTypeIDNull)
				AddParameter(cmd, "ProposerTypeID", proposerTypeID);
			return cmd;
		}
		protected CaseProjectRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseProjectRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseProjectRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int proposerTypeIDColumnIndex = reader.GetOrdinal("ProposerTypeID");
			int proposerTypeOtherColumnIndex = reader.GetOrdinal("ProposerTypeOther");
			int projectNameLocationColumnIndex = reader.GetOrdinal("ProjectNameLocation");
			int projectTitleColumnIndex = reader.GetOrdinal("ProjectTitle");
			int proposerENColumnIndex = reader.GetOrdinal("ProposerEN");
			int objectiveToHelpColumnIndex = reader.GetOrdinal("ObjectiveToHelp");
			int projectInActionColumnIndex = reader.GetOrdinal("ProjectInAction");
			int portfolioColumnIndex = reader.GetOrdinal("Portfolio");
			int projectObjectiveColumnIndex = reader.GetOrdinal("ProjectObjective");
			int projectResultColumnIndex = reader.GetOrdinal("ProjectResult");
			int projectTargetColumnIndex = reader.GetOrdinal("ProjectTarget");
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
					CaseProjectRow record = new CaseProjectRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					if (!reader.IsDBNull(proposerTypeIDColumnIndex)) record.ProposerTypeID =  Convert.ToInt32(reader.GetValue(proposerTypeIDColumnIndex));

					if (!reader.IsDBNull(proposerTypeOtherColumnIndex)) record.ProposerTypeOther =  Convert.ToString(reader.GetValue(proposerTypeOtherColumnIndex));

					if (!reader.IsDBNull(projectNameLocationColumnIndex)) record.ProjectNameLocation =  Convert.ToString(reader.GetValue(projectNameLocationColumnIndex));

					if (!reader.IsDBNull(projectTitleColumnIndex)) record.ProjectTitle =  Convert.ToString(reader.GetValue(projectTitleColumnIndex));

					if (!reader.IsDBNull(proposerENColumnIndex)) record.ProposerEN =  Convert.ToString(reader.GetValue(proposerENColumnIndex));

					if (!reader.IsDBNull(objectiveToHelpColumnIndex)) record.ObjectiveToHelp =  Convert.ToString(reader.GetValue(objectiveToHelpColumnIndex));

					if (!reader.IsDBNull(projectInActionColumnIndex)) record.ProjectInAction =  Convert.ToString(reader.GetValue(projectInActionColumnIndex));

					if (!reader.IsDBNull(portfolioColumnIndex)) record.Portfolio =  Convert.ToString(reader.GetValue(portfolioColumnIndex));

					if (!reader.IsDBNull(projectObjectiveColumnIndex)) record.ProjectObjective =  Convert.ToString(reader.GetValue(projectObjectiveColumnIndex));

					if (!reader.IsDBNull(projectResultColumnIndex)) record.ProjectResult =  Convert.ToString(reader.GetValue(projectResultColumnIndex));

					if (!reader.IsDBNull(projectTargetColumnIndex)) record.ProjectTarget =  Convert.ToString(reader.GetValue(projectTargetColumnIndex));

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
			return (CaseProjectRow[])(recordList.ToArray(typeof(CaseProjectRow)));
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
				case "ProposerTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProposerTypeOther":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProjectNameLocation":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProjectTitle":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProposerEN":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ObjectiveToHelp":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProjectInAction":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Portfolio":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProjectObjective":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProjectResult":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProjectTarget":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

