using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TransactionStatusRow
	{
		private int _transactionStatusID;
		private bool _isSetTransactionStatusID = false;
		private string _transactionStatusName;
		private bool _isSetTransactionStatusName = false;
		[Required]
		public int TransactionStatusID
		{
			get { return _transactionStatusID; }
			set { _transactionStatusID = value;
			      _isSetTransactionStatusID = true; }
		}
		public bool _IsSetTransactionStatusID
		{
			get { return _isSetTransactionStatusID; }
		}
		public string TransactionStatusName
		{
			get { return _transactionStatusName; }
			set { _transactionStatusName = value;
			      _isSetTransactionStatusName = true; }
		}
		public bool _IsSetTransactionStatusName
		{
			get { return _isSetTransactionStatusName; }
		}
	}
	[Serializable]
	public class TransactionStatusData
	{
		private int _transactionStatusID;
		private string _transactionStatusName;
		public int TransactionStatusID
		{
			get{ return _transactionStatusID; }
			set{ _transactionStatusID = value; }
		}
		public string TransactionStatusName
		{
			get{ return _transactionStatusName; }
			set{ _transactionStatusName = value; }
		}
	}
	[Serializable]
	public class TransactionStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionStatusRow[] transactionStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionStatusItems : TransactionStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionStatusItems[] transactionStatusItems { get; set; }
	}
}

