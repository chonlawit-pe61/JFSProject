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
	public partial class FormCollection_Base : MarshalByRefObject
	{
		public const string FormIDColumnName = "FormID";
		public const string FormTypeIDColumnName = "FormTypeID";
		public const string FormNameColumnName = "FormName";
		public const string SortOrderColumnName = "SortOrder";
		public const string IsReviewColumnName = "IsReview";
		public const string IsActiveColumnName = "IsActive";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public FormCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual FormRow[] GetAll()
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
			"[FormID],"+
			"[FormTypeID],"+
			"[FormName],"+
			"[SortOrder],"+
			"[IsReview],"+
			"[IsActive],"+
			"[ModifiedDate]"+
			" FROM [dbo].[Form]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Form]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Form"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FormTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FormName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsReview",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual FormRow[] GetByFormTypeID(int formTypeID)
		{
			return MapRecords(CreateGetByFormTypeIDCommand(formTypeID));
		}
		public virtual DataTable GetByFormTypeIDAsDataTable(int formTypeID)
		{
			return MapRecordsToDataTable(CreateGetByFormTypeIDCommand(formTypeID));
		}
		protected virtual IDbCommand CreateGetByFormTypeIDCommand(int formTypeID)
		{
			string whereSql = "";
			whereSql += "[FormTypeID]=" + CreateSqlParameterName("FormTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FormTypeID", formTypeID);
			return cmd;
		}
		public FormRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual FormRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="FormRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FormRow"/> objects.</returns>
		public virtual FormRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Form]", top);
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
		public FormRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			FormRow[] rows = null;
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
		public DataTable GetFormPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FormID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "FormID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(FormID) AS TotalRow FROM [dbo].[Form] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,FormID,FormTypeID,FormName,SortOrder,IsReview,IsActive,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Form] " + whereSql +
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
		public FormItemsPaging GetFormPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FormID")
		{
		FormItemsPaging obj = new FormItemsPaging();
		DataTable dt = GetFormPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		FormItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new FormItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			if (dt.Rows[i]["FormTypeID"] != DBNull.Value)
			record.FormTypeID = Convert.ToInt32(dt.Rows[i]["FormTypeID"]);
			record.FormName = dt.Rows[i]["FormName"].ToString();
			record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
			if (dt.Rows[i]["IsReview"] != DBNull.Value)
			record.IsReview = Convert.ToBoolean(dt.Rows[i]["IsReview"]);
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.formItems = (FormItems[])(recordList.ToArray(typeof(FormItems)));
		return obj;
		}
		public FormRow GetByPrimaryKey(int formID)
		{
			string whereSql = "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FormID", formID);
			FormRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(FormRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Form] (" +
			"[FormID], " + 
			"[FormTypeID], " + 
			"[FormName], " + 
			"[SortOrder], " + 
			"[IsReview], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("FormTypeID") + ", " +
			CreateSqlParameterName("FormName") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsReview") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "FormID", value.FormID);
			AddParameter(cmd, "FormTypeID", value.IsFormTypeIDNull ? DBNull.Value : (object)value.FormTypeID);
			AddParameter(cmd, "FormName",value.FormName);
			AddParameter(cmd, "SortOrder", value.SortOrder);
			AddParameter(cmd, "IsReview", value.IsIsReviewNull ? DBNull.Value : (object)value.IsReview);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(FormRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Form] (" +
			"[FormID], " + 
			"[FormTypeID], " + 
			"[FormName], " + 
			"[SortOrder], " + 
			"[IsReview], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("FormTypeID") + ", " +
			CreateSqlParameterName("FormName") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsReview") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "FormID", value.FormID);
			AddParameter(cmd, "FormTypeID", value.IsFormTypeIDNull ? DBNull.Value : (object)value.FormTypeID);
			AddParameter(cmd, "FormName", Sanitizer.GetSafeHtmlFragment(value.FormName));
			AddParameter(cmd, "SortOrder", value.SortOrder);
			AddParameter(cmd, "IsReview", value.IsIsReviewNull ? DBNull.Value : (object)value.IsReview);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(FormRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFormID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetFormTypeID)
				{
					strUpdate += "[FormTypeID]=" + CreateSqlParameterName("FormTypeID") + ",";
				}
				if (value._IsSetFormName)
				{
					strUpdate += "[FormName]=" + CreateSqlParameterName("FormName") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsReview)
				{
					strUpdate += "[IsReview]=" + CreateSqlParameterName("IsReview") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Form] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FormID", value.FormID);
					AddParameter(cmd, "FormTypeID", value.IsFormTypeIDNull ? DBNull.Value : (object)value.FormTypeID);
					AddParameter(cmd, "FormName",value.FormName);
					AddParameter(cmd, "SortOrder", value.SortOrder);
					AddParameter(cmd, "IsReview", value.IsIsReviewNull ? DBNull.Value : (object)value.IsReview);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
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
				Exception ex = new Exception("Set incorrect primarykey PK(FormID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(FormRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFormID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetFormTypeID)
				{
					strUpdate += "[FormTypeID]=" + CreateSqlParameterName("FormTypeID") + ",";
				}
				if (value._IsSetFormName)
				{
					strUpdate += "[FormName]=" + CreateSqlParameterName("FormName") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsReview)
				{
					strUpdate += "[IsReview]=" + CreateSqlParameterName("IsReview") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Form] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FormID", value.FormID);
					AddParameter(cmd, "FormTypeID", value.IsFormTypeIDNull ? DBNull.Value : (object)value.FormTypeID);
					AddParameter(cmd, "FormName", Sanitizer.GetSafeHtmlFragment(value.FormName));
					AddParameter(cmd, "SortOrder", value.SortOrder);
					AddParameter(cmd, "IsReview", value.IsIsReviewNull ? DBNull.Value : (object)value.IsReview);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
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
				Exception ex = new Exception("Set incorrect primarykey PK(FormID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int formID)
		{
			string whereSql = "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FormID", formID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public FormRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			FormRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByFormTypeID(int formTypeID)
		{
			return DeleteByFormTypeID(formTypeID, false);
		}
		public int DeleteByFormTypeID(int formTypeID, bool formTypeIDNull)
		{
			return CreateDeleteByFormTypeIDCommand(formTypeID, formTypeIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFormTypeIDCommand(int formTypeID, bool formTypeIDNull)
		{
			string whereSql = "";
			if (formTypeIDNull)
				whereSql += "[FormTypeID] IS NULL";
			else
				whereSql += "[FormTypeID]=" + CreateSqlParameterName("FormTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!formTypeIDNull)
				AddParameter(cmd, "FormTypeID", formTypeID);
			return cmd;
		}
		protected FormRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected FormRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected FormRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int formTypeIDColumnIndex = reader.GetOrdinal("FormTypeID");
			int formNameColumnIndex = reader.GetOrdinal("FormName");
			int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
			int isReviewColumnIndex = reader.GetOrdinal("IsReview");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
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
					FormRow record = new FormRow();
					recordList.Add(record);
					record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));
					if (!reader.IsDBNull(formTypeIDColumnIndex)) record.FormTypeID =  Convert.ToInt32(reader.GetValue(formTypeIDColumnIndex));

					record.FormName =  Convert.ToString(reader.GetValue(formNameColumnIndex));
					record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));
					if (!reader.IsDBNull(isReviewColumnIndex)) record.IsReview =  Convert.ToBoolean(reader.GetValue(isReviewColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FormRow[])(recordList.ToArray(typeof(FormRow)));
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
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SortOrder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsReview":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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
