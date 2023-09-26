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
	public partial class View_FormSetMapAttributeCollection_Base : MarshalByRefObject
	{
		public const string FormMapAttrIDColumnName = "FormMapAttrID";
		public const string SortIDColumnName = "SortID";
		public const string FormAttrIDColumnName = "FormAttrID";
		public const string DataTypeColumnName = "DataType";
		public const string FormAttrAliasColumnName = "FormAttrAlias";
		public const string DefaultValColumnName = "DefaultVal";
		public const string FormAttrNameColumnName = "FormAttrName";
		public const string IsRequireColumnName = "IsRequire";
		public const string UnitColumnName = "Unit";
		public const string IsActiveColumnName = "IsActive";
		public const string IsReviewColumnName = "IsReview";
		public const string FormIDColumnName = "FormID";
		public const string ColumnsColumnName = "Columns";
		private int _processID;
		public SqlCommand cmd = null;
		public View_FormSetMapAttributeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_FormSetMapAttributeRow[] GetAll()
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
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[FormMapAttrID],"+
			"[SortID],"+
			"[FormAttrID],"+
			"[DataType],"+
			"[FormAttrAlias],"+
			"[DefaultVal],"+
			"[FormAttrName],"+
			"[IsRequire],"+
			"[Unit],"+
			"[IsActive],"+
			"[IsReview],"+
			"[FormID],"+
			"[Columns]"+
			" FROM [dbo].[View_FormSetMapAttribute]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "View_FormSetMapAttribute"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FormMapAttrID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SortID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FormAttrID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DataType",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FormAttrAlias",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("DefaultVal",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("FormAttrName",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("IsRequire",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Unit",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsReview",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Columns",Type.GetType("System.Int32"));
			return dataTable;
		}
		public View_FormSetMapAttributeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_FormSetMapAttributeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_FormSetMapAttributeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_FormSetMapAttributeRow"/> objects.</returns>
		public virtual View_FormSetMapAttributeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_FormSetMapAttribute]", top);
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
		public View_FormSetMapAttributeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_FormSetMapAttributeRow[] rows = null;
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
		public DataTable GetView_FormSetMapAttributePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FormMapAttrID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "FormMapAttrID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_FormSetMapAttribute] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,FormMapAttrID,SortID,FormAttrID,DataType,FormAttrAlias,DefaultVal,FormAttrName,IsRequire,Unit,IsActive,IsReview,FormID,Columns," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_FormSetMapAttribute].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_FormSetMapAttribute] " + whereSql +
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
		public View_FormSetMapAttributeItemsPaging GetView_FormSetMapAttributePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FormMapAttrID")
		{
		View_FormSetMapAttributeItemsPaging obj = new View_FormSetMapAttributeItemsPaging();
		DataTable dt = GetView_FormSetMapAttributePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_FormSetMapAttributeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_FormSetMapAttributeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.FormMapAttrID = Convert.ToInt32(dt.Rows[i]["FormMapAttrID"]);
			if (dt.Rows[i]["SortID"] != DBNull.Value)
			record.SortID = Convert.ToInt32(dt.Rows[i]["SortID"]);
			if (dt.Rows[i]["FormAttrID"] != DBNull.Value)
			record.FormAttrID = Convert.ToInt32(dt.Rows[i]["FormAttrID"]);
			record.DataType = dt.Rows[i]["DataType"].ToString();
			record.FormAttrAlias = dt.Rows[i]["FormAttrAlias"].ToString();
			record.DefaultVal = dt.Rows[i]["DefaultVal"].ToString();
			record.FormAttrName = dt.Rows[i]["FormAttrName"].ToString();
			if (dt.Rows[i]["IsRequire"] != DBNull.Value)
			record.IsRequire = Convert.ToBoolean(dt.Rows[i]["IsRequire"]);
			record.Unit = dt.Rows[i]["Unit"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["IsReview"] != DBNull.Value)
			record.IsReview = Convert.ToBoolean(dt.Rows[i]["IsReview"]);
			if (dt.Rows[i]["FormID"] != DBNull.Value)
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			if (dt.Rows[i]["Columns"] != DBNull.Value)
			record.Columns = Convert.ToInt32(dt.Rows[i]["Columns"]);
			recordList.Add(record);
		}
		obj.view_FormSetMapAttributeItems = (View_FormSetMapAttributeItems[])(recordList.ToArray(typeof(View_FormSetMapAttributeItems)));
		return obj;
		}
		public View_FormSetMapAttributeRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			View_FormSetMapAttributeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected View_FormSetMapAttributeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_FormSetMapAttributeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_FormSetMapAttributeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int formMapAttrIDColumnIndex = reader.GetOrdinal("FormMapAttrID");
			int sortIDColumnIndex = reader.GetOrdinal("SortID");
			int formAttrIDColumnIndex = reader.GetOrdinal("FormAttrID");
			int dataTypeColumnIndex = reader.GetOrdinal("DataType");
			int formAttrAliasColumnIndex = reader.GetOrdinal("FormAttrAlias");
			int defaultValColumnIndex = reader.GetOrdinal("DefaultVal");
			int formAttrNameColumnIndex = reader.GetOrdinal("FormAttrName");
			int isRequireColumnIndex = reader.GetOrdinal("IsRequire");
			int unitColumnIndex = reader.GetOrdinal("Unit");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int isReviewColumnIndex = reader.GetOrdinal("IsReview");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int columnsColumnIndex = reader.GetOrdinal("Columns");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_FormSetMapAttributeRow record = new View_FormSetMapAttributeRow();
					recordList.Add(record);
					record.FormMapAttrID =  Convert.ToInt32(reader.GetValue(formMapAttrIDColumnIndex));
					if (!reader.IsDBNull(sortIDColumnIndex)) record.SortID =  Convert.ToInt32(reader.GetValue(sortIDColumnIndex));

					if (!reader.IsDBNull(formAttrIDColumnIndex)) record.FormAttrID =  Convert.ToInt32(reader.GetValue(formAttrIDColumnIndex));

					if (!reader.IsDBNull(dataTypeColumnIndex)) record.DataType =  Convert.ToString(reader.GetValue(dataTypeColumnIndex));

					if (!reader.IsDBNull(formAttrAliasColumnIndex)) record.FormAttrAlias =  Convert.ToString(reader.GetValue(formAttrAliasColumnIndex));

					if (!reader.IsDBNull(defaultValColumnIndex)) record.DefaultVal =  Convert.ToString(reader.GetValue(defaultValColumnIndex));

					if (!reader.IsDBNull(formAttrNameColumnIndex)) record.FormAttrName =  Convert.ToString(reader.GetValue(formAttrNameColumnIndex));

					if (!reader.IsDBNull(isRequireColumnIndex)) record.IsRequire =  Convert.ToBoolean(reader.GetValue(isRequireColumnIndex));

					if (!reader.IsDBNull(unitColumnIndex)) record.Unit =  Convert.ToString(reader.GetValue(unitColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(isReviewColumnIndex)) record.IsReview =  Convert.ToBoolean(reader.GetValue(isReviewColumnIndex));

					if (!reader.IsDBNull(formIDColumnIndex)) record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));

					if (!reader.IsDBNull(columnsColumnIndex)) record.Columns =  Convert.ToInt32(reader.GetValue(columnsColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_FormSetMapAttributeRow[])(recordList.ToArray(typeof(View_FormSetMapAttributeRow)));
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
				case "FormMapAttrID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SortID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormAttrID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DataType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FormAttrAlias":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DefaultVal":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FormAttrName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsRequire":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Unit":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsReview":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Columns":
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
