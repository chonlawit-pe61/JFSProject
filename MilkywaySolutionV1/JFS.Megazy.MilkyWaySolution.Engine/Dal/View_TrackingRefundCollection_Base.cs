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
	public partial class View_TrackingRefundCollection_Base : MarshalByRefObject
	{
		public const string TrakingRefundIDColumnName = "TrakingRefundID";
		public const string ContractIDColumnName = "ContractID";
		public const string DescriptionColumnName = "Description";
		public const string AmountColumnName = "Amount";
		public const string RequestDateColumnName = "RequestDate";
		public const string ReceivedAmountColumnName = "ReceivedAmount";
		public const string ReceivedDateColumnName = "ReceivedDate";
		public const string RefundStatusIDColumnName = "RefundStatusID";
		public const string NoteColumnName = "Note";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string RefundStatusNameColumnName = "RefundStatusName";
		public const string TransactionIDColumnName = "TransactionID";
		public const string TransactionNoColumnName = "TransactionNo";
		public const string TransactionTypeColumnName = "TransactionType";
		public const string TransactionStatusIDColumnName = "TransactionStatusID";
		public const string TrasactionTypeDescColumnName = "TrasactionTypeDesc";
		public const string JFPortalReceiveDateColumnName = "JFPortalReceiveDate";
		private int _processID;
		public SqlCommand cmd = null;
		public View_TrackingRefundCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_TrackingRefundRow[] GetAll()
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
			"[TrakingRefundID],"+
			"[ContractID],"+
			"[Description],"+
			"[Amount],"+
			"[RequestDate],"+
			"[ReceivedAmount],"+
			"[ReceivedDate],"+
			"[RefundStatusID],"+
			"[Note],"+
			"[ModifiedDate],"+
			"[RefundStatusName],"+
			"[TransactionID],"+
			"[TransactionNo],"+
			"[TransactionType],"+
			"[TransactionStatusID],"+
			"[TrasactionTypeDesc],"+
			"[JFPortalReceiveDate]"+
			" FROM [dbo].[View_TrackingRefund]";
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
				TableName = "View_TrackingRefund"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TrakingRefundID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ContractID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Description",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("Amount",Type.GetType("System.Double"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RequestDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ReceivedAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("ReceivedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RefundStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RefundStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("TransactionType",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TransactionStatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("TrasactionTypeDesc",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("JFPortalReceiveDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public View_TrackingRefundRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_TrackingRefundRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_TrackingRefundRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_TrackingRefundRow"/> objects.</returns>
		public virtual View_TrackingRefundRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_TrackingRefund]", top);
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
		public View_TrackingRefundRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_TrackingRefundRow[] rows = null;
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
		public DataTable GetView_TrackingRefundPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TrakingRefundID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TrakingRefundID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TrakingRefundID) AS TotalRow FROM [dbo].[View_TrackingRefund] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TrakingRefundID,ContractID,Description,Amount,RequestDate,ReceivedAmount,ReceivedDate,RefundStatusID,Note,ModifiedDate,RefundStatusName,TransactionID,TransactionNo,TransactionType,TransactionStatusID,TrasactionTypeDesc,JFPortalReceiveDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_TrackingRefund] " + whereSql +
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
		public View_TrackingRefundItemsPaging GetView_TrackingRefundPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TrakingRefundID")
		{
		View_TrackingRefundItemsPaging obj = new View_TrackingRefundItemsPaging();
		DataTable dt = GetView_TrackingRefundPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_TrackingRefundItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_TrackingRefundItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TrakingRefundID = Convert.ToInt32(dt.Rows[i]["TrakingRefundID"]);
			record.ContractID = Convert.ToInt32(dt.Rows[i]["ContractID"]);
			record.Description = dt.Rows[i]["Description"].ToString();
			record.Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
			if (dt.Rows[i]["RequestDate"] != DBNull.Value)
			record.RequestDate = Convert.ToDateTime(dt.Rows[i]["RequestDate"]);
			if (dt.Rows[i]["ReceivedAmount"] != DBNull.Value)
			record.ReceivedAmount = Convert.ToDouble(dt.Rows[i]["ReceivedAmount"]);
			if (dt.Rows[i]["ReceivedDate"] != DBNull.Value)
			record.ReceivedDate = Convert.ToDateTime(dt.Rows[i]["ReceivedDate"]);
			record.RefundStatusID = Convert.ToInt32(dt.Rows[i]["RefundStatusID"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.RefundStatusName = dt.Rows[i]["RefundStatusName"].ToString();
			record.TransactionID = Convert.ToInt32(dt.Rows[i]["TransactionID"]);
			record.TransactionNo = dt.Rows[i]["TransactionNo"].ToString();
			record.TransactionType = Convert.ToInt32(dt.Rows[i]["TransactionType"]);
			if (dt.Rows[i]["TransactionStatusID"] != DBNull.Value)
			record.TransactionStatusID = Convert.ToInt32(dt.Rows[i]["TransactionStatusID"]);
			record.TrasactionTypeDesc = dt.Rows[i]["TrasactionTypeDesc"].ToString();
			if (dt.Rows[i]["JFPortalReceiveDate"] != DBNull.Value)
			record.JFPortalReceiveDate = Convert.ToDateTime(dt.Rows[i]["JFPortalReceiveDate"]);
			recordList.Add(record);
		}
		obj.view_TrackingRefundItems = (View_TrackingRefundItems[])(recordList.ToArray(typeof(View_TrackingRefundItems)));
		return obj;
		}
		protected View_TrackingRefundRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_TrackingRefundRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_TrackingRefundRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int trakingRefundIDColumnIndex = reader.GetOrdinal("TrakingRefundID");
			int contractIDColumnIndex = reader.GetOrdinal("ContractID");
			int descriptionColumnIndex = reader.GetOrdinal("Description");
			int amountColumnIndex = reader.GetOrdinal("Amount");
			int requestDateColumnIndex = reader.GetOrdinal("RequestDate");
			int receivedAmountColumnIndex = reader.GetOrdinal("ReceivedAmount");
			int receivedDateColumnIndex = reader.GetOrdinal("ReceivedDate");
			int refundStatusIDColumnIndex = reader.GetOrdinal("RefundStatusID");
			int noteColumnIndex = reader.GetOrdinal("Note");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int refundStatusNameColumnIndex = reader.GetOrdinal("RefundStatusName");
			int transactionIDColumnIndex = reader.GetOrdinal("TransactionID");
			int transactionNoColumnIndex = reader.GetOrdinal("TransactionNo");
			int transactiontypeColumnIndex = reader.GetOrdinal("TransactionType");
			int transactionStatusIDColumnIndex = reader.GetOrdinal("TransactionStatusID");
			int trasactiontypeDescColumnIndex = reader.GetOrdinal("TrasactionTypeDesc");
			int jFPortalReceiveDateColumnIndex = reader.GetOrdinal("JFPortalReceiveDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_TrackingRefundRow record = new View_TrackingRefundRow();
					recordList.Add(record);
					record.TrakingRefundID =  Convert.ToInt32(reader.GetValue(trakingRefundIDColumnIndex));
					record.ContractID =  Convert.ToInt32(reader.GetValue(contractIDColumnIndex));
					if (!reader.IsDBNull(descriptionColumnIndex)) record.Description =  Convert.ToString(reader.GetValue(descriptionColumnIndex));

					record.Amount =  Convert.ToDouble(reader.GetValue(amountColumnIndex));
					if (!reader.IsDBNull(requestDateColumnIndex)) record.RequestDate =  Convert.ToDateTime(reader.GetValue(requestDateColumnIndex));

					if (!reader.IsDBNull(receivedAmountColumnIndex)) record.ReceivedAmount =  Convert.ToDouble(reader.GetValue(receivedAmountColumnIndex));

					if (!reader.IsDBNull(receivedDateColumnIndex)) record.ReceivedDate =  Convert.ToDateTime(reader.GetValue(receivedDateColumnIndex));

					record.RefundStatusID =  Convert.ToInt32(reader.GetValue(refundStatusIDColumnIndex));
					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					record.RefundStatusName =  Convert.ToString(reader.GetValue(refundStatusNameColumnIndex));
					record.TransactionID =  Convert.ToInt32(reader.GetValue(transactionIDColumnIndex));
					if (!reader.IsDBNull(transactionNoColumnIndex)) record.TransactionNo =  Convert.ToString(reader.GetValue(transactionNoColumnIndex));

					record.TransactionType =  Convert.ToInt32(reader.GetValue(transactiontypeColumnIndex));
					if (!reader.IsDBNull(transactionStatusIDColumnIndex)) record.TransactionStatusID =  Convert.ToInt32(reader.GetValue(transactionStatusIDColumnIndex));

					record.TrasactionTypeDesc =  Convert.ToString(reader.GetValue(trasactiontypeDescColumnIndex));
					if (!reader.IsDBNull(jFPortalReceiveDateColumnIndex)) record.JFPortalReceiveDate =  Convert.ToDateTime(reader.GetValue(jFPortalReceiveDateColumnIndex));

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
			return (View_TrackingRefundRow[])(recordList.ToArray(typeof(View_TrackingRefundRow)));
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
				case "TrakingRefundID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ContractID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Description":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Amount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "RequestDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ReceivedAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ReceivedDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "RefundStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Note":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "RefundStatusName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "TransactionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TransactionType":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TransactionStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TrasactionTypeDesc":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "JFPortalReceiveDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
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

