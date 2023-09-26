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
	public partial class ScoreChoiceCollection_Base : MarshalByRefObject
	{
		public const string ChoiceIDColumnName = "ChoiceID";
		public const string TopicIDColumnName = "TopicID";
		public const string ChoiceColumnName = "Choice";
		public const string ScoreColumnName = "Score";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string IsActiveColumnName = "IsActive";
		private int _processID;
		public SqlCommand cmd = null;
		public ScoreChoiceCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ScoreChoiceRow[] GetAll()
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
			"[ChoiceID],"+
			"[TopicID],"+
			"[Choice],"+
			"[Score],"+
			"[ModifiedDate],"+
			"[IsActive]"+
			" FROM [dbo].[ScoreChoice]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ScoreChoice]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ScoreChoice"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ChoiceID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TopicID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Choice",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("Score",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public virtual ScoreChoiceRow[] GetByTopicID(int topicID)
		{
			return MapRecords(CreateGetByTopicIDCommand(topicID));
		}
		public virtual DataTable GetByTopicIDAsDataTable(int topicID)
		{
			return MapRecordsToDataTable(CreateGetByTopicIDCommand(topicID));
		}
		protected virtual IDbCommand CreateGetByTopicIDCommand(int topicID)
		{
			string whereSql = "";
			whereSql += "[TopicID]=" + CreateSqlParameterName("TopicID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TopicID", topicID);
			return cmd;
		}
		public ScoreChoiceRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ScoreChoiceRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ScoreChoiceRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ScoreChoiceRow"/> objects.</returns>
		public virtual ScoreChoiceRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ScoreChoice]", top);
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
		public ScoreChoiceRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ScoreChoiceRow[] rows = null;
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
		public DataTable GetScoreChoicePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ChoiceID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ChoiceID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ChoiceID) AS TotalRow FROM [dbo].[ScoreChoice] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ChoiceID,TopicID,Choice,Score,ModifiedDate,IsActive," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ScoreChoice] " + whereSql +
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
		public ScoreChoiceItemsPaging GetScoreChoicePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ChoiceID")
		{
		ScoreChoiceItemsPaging obj = new ScoreChoiceItemsPaging();
		DataTable dt = GetScoreChoicePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ScoreChoiceItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ScoreChoiceItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ChoiceID = Convert.ToInt32(dt.Rows[i]["ChoiceID"]);
			if (dt.Rows[i]["TopicID"] != DBNull.Value)
			record.TopicID = Convert.ToInt32(dt.Rows[i]["TopicID"]);
			record.Choice = dt.Rows[i]["Choice"].ToString();
			if (dt.Rows[i]["Score"] != DBNull.Value)
			record.Score = Convert.ToDouble(dt.Rows[i]["Score"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			recordList.Add(record);
		}
		obj.scoreChoiceItems = (ScoreChoiceItems[])(recordList.ToArray(typeof(ScoreChoiceItems)));
		return obj;
		}
		public ScoreChoiceRow GetByPrimaryKey(int choiceID)
		{
			string whereSql = "[ChoiceID]=" + CreateSqlParameterName("ChoiceID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ChoiceID", choiceID);
			ScoreChoiceRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ScoreChoiceRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ScoreChoice] (" +
			"[ChoiceID], " + 
			"[TopicID], " + 
			"[Choice], " + 
			"[Score], " + 
			"[ModifiedDate], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("ChoiceID") + ", " +
			CreateSqlParameterName("TopicID") + ", " +
			CreateSqlParameterName("Choice") + ", " +
			CreateSqlParameterName("Score") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("IsActive") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ChoiceID", value.ChoiceID);
			AddParameter(cmd, "TopicID", value.IsTopicIDNull ? DBNull.Value : (object)value.TopicID);
			AddParameter(cmd, "Choice", value.Choice);
			AddParameter(cmd, "Score", value.IsScoreNull ? DBNull.Value : (object)value.Score);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ScoreChoiceRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ScoreChoice] (" +
			"[ChoiceID], " + 
			"[TopicID], " + 
			"[Choice], " + 
			"[Score], " + 
			"[ModifiedDate], " + 
			"[IsActive]			" + 
			") VALUES (" +
			CreateSqlParameterName("ChoiceID") + ", " +
			CreateSqlParameterName("TopicID") + ", " +
			CreateSqlParameterName("Choice") + ", " +
			CreateSqlParameterName("Score") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("IsActive") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ChoiceID", value.ChoiceID);
			AddParameter(cmd, "TopicID", value.IsTopicIDNull ? DBNull.Value : (object)value.TopicID);
			AddParameter(cmd, "Choice", Sanitizer.GetSafeHtmlFragment(value.Choice));
			AddParameter(cmd, "Score", value.IsScoreNull ? DBNull.Value : (object)value.Score);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ScoreChoiceRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetChoiceID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTopicID)
				{
					strUpdate += "[TopicID]=" + CreateSqlParameterName("TopicID") + ",";
				}
				if (value._IsSetChoice)
				{
					strUpdate += "[Choice]=" + CreateSqlParameterName("Choice") + ",";
				}
				if (value._IsSetScore)
				{
					strUpdate += "[Score]=" + CreateSqlParameterName("Score") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ScoreChoice] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ChoiceID]=" + CreateSqlParameterName("ChoiceID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ChoiceID", value.ChoiceID);
					AddParameter(cmd, "TopicID", value.IsTopicIDNull ? DBNull.Value : (object)value.TopicID);
					AddParameter(cmd, "Choice", value.Choice);
					AddParameter(cmd, "Score", value.IsScoreNull ? DBNull.Value : (object)value.Score);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ChoiceID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ScoreChoiceRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetChoiceID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTopicID)
				{
					strUpdate += "[TopicID]=" + CreateSqlParameterName("TopicID") + ",";
				}
				if (value._IsSetChoice)
				{
					strUpdate += "[Choice]=" + CreateSqlParameterName("Choice") + ",";
				}
				if (value._IsSetScore)
				{
					strUpdate += "[Score]=" + CreateSqlParameterName("Score") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ScoreChoice] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ChoiceID]=" + CreateSqlParameterName("ChoiceID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ChoiceID", value.ChoiceID);
					AddParameter(cmd, "TopicID", value.IsTopicIDNull ? DBNull.Value : (object)value.TopicID);
					AddParameter(cmd, "Choice", Sanitizer.GetSafeHtmlFragment(value.Choice));
					AddParameter(cmd, "Score", value.IsScoreNull ? DBNull.Value : (object)value.Score);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ChoiceID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int choiceID)
		{
			string whereSql = "[ChoiceID]=" + CreateSqlParameterName("ChoiceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ChoiceID", choiceID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public ScoreChoiceRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			ScoreChoiceRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByTopicID(int topicID)
		{
			return DeleteByTopicID(topicID, false);
		}
		public int DeleteByTopicID(int topicID, bool topicIDNull)
		{
			return CreateDeleteByTopicIDCommand(topicID, topicIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTopicIDCommand(int topicID, bool topicIDNull)
		{
			string whereSql = "";
			if (topicIDNull)
				whereSql += "[TopicID] IS NULL";
			else
				whereSql += "[TopicID]=" + CreateSqlParameterName("TopicID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!topicIDNull)
				AddParameter(cmd, "TopicID", topicID);
			return cmd;
		}
		protected ScoreChoiceRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ScoreChoiceRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ScoreChoiceRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int choiceIDColumnIndex = reader.GetOrdinal("ChoiceID");
			int topicIDColumnIndex = reader.GetOrdinal("TopicID");
			int choiceColumnIndex = reader.GetOrdinal("Choice");
			int scoreColumnIndex = reader.GetOrdinal("Score");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ScoreChoiceRow record = new ScoreChoiceRow();
					recordList.Add(record);
					record.ChoiceID =  Convert.ToInt32(reader.GetValue(choiceIDColumnIndex));
					if (!reader.IsDBNull(topicIDColumnIndex)) record.TopicID =  Convert.ToInt32(reader.GetValue(topicIDColumnIndex));

					if (!reader.IsDBNull(choiceColumnIndex)) record.Choice =  Convert.ToString(reader.GetValue(choiceColumnIndex));

					if (!reader.IsDBNull(scoreColumnIndex)) record.Score =  Convert.ToDouble(reader.GetValue(scoreColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ScoreChoiceRow[])(recordList.ToArray(typeof(ScoreChoiceRow)));
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
				case "ChoiceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TopicID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Choice":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Score":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "IsActive":
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

