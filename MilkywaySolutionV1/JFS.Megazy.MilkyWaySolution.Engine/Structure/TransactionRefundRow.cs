using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TransactionRefundRow
	{
		private int _transactionRefundID;
		private bool _isSetTransactionRefundID = false;
		private string _transactionNo;
		private bool _isSetTransactionNo = false;
		private double _refundAmount;
		private bool _isSetRefundAmount = false;
		private bool _refundAmountNull = true;
		private string _note;
		private bool _isSetNote = false;
		private int? _refCostID;
		private bool _isSetRefCostID = false;
		private bool _refCostIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสรายการคืนเงิน
		/// </summary>
		[Required]
		public int TransactionRefundID
		{
			get { return _transactionRefundID; }
			set { _transactionRefundID = value;
			      _isSetTransactionRefundID = true; }
		}
		public bool _IsSetTransactionRefundID
		{
			get { return _isSetTransactionRefundID; }
		}
		/// <summary>
		/// เลขที่รายการ
		/// </summary>
		[Required]
		public string TransactionNo
		{
			get { return _transactionNo; }
			set { _transactionNo = value;
			      _isSetTransactionNo = true; }
		}
		public bool _IsSetTransactionNo
		{
			get { return _isSetTransactionNo; }
		}
		/// <summary>
		/// ยอดเงินคืน
		/// </summary>
		public double RefundAmount
		{
			get
			{
				return _refundAmount;
			}
			set
			{
				_refundAmountNull = false;
				_isSetRefundAmount = true;
				_refundAmount = value;
			}
		}
		public bool IsRefundAmountNull
		{
			get {
				 return _refundAmountNull; }
			set { _refundAmountNull = value; }
		}
		public bool _IsSetRefundAmount
		{
			get { return _isSetRefundAmount; }
		}
		public string Note
		{
			get { return _note; }
			set { _note = value;
			      _isSetNote = true; }
		}
		public bool _IsSetNote
		{
			get { return _isSetNote; }
		}
		/// <summary>
		/// รหัสอ้างอิงจากระบบการเงิน
		/// </summary>
		public int? RefCostID
		{
			get
			{
				return _refCostID;
			}
			set
			{
				_refCostIDNull = false;
				_isSetRefCostID = true;
				_refCostID = value;
			}
		}
		public bool IsRefCostIDNull
		{
			get {
				 return _refCostIDNull; }
			set { _refCostIDNull = value; }
		}
		public bool _IsSetRefCostID
		{
			get { return _isSetRefCostID; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public bool _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class TransactionRefundData
	{
		private int _transactionRefundID;
		private string _transactionNo;
		private double _refundAmount;
		private string _note;
		private int? _refCostID;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสรายการคืนเงิน
		/// </summary>
		public int TransactionRefundID
		{
			get{ return _transactionRefundID; }
			set{ _transactionRefundID = value; }
		}
		/// <summary>
		/// เลขที่รายการ
		/// </summary>
		public string TransactionNo
		{
			get{ return _transactionNo; }
			set{ _transactionNo = value; }
		}
		/// <summary>
		/// ยอดเงินคืน
		/// </summary>
		public double RefundAmount
		{
			get{ return _refundAmount; }
			set{ _refundAmount = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		/// <summary>
		/// รหัสอ้างอิงจากระบบการเงิน
		/// </summary>
		public int? RefCostID
		{
			get{ return _refCostID; }
			set{ _refCostID = value; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class TransactionRefundPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionRefundRow[] transactionRefundRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionRefundItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionRefundItems : TransactionRefundData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionRefundItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionRefundItems[] transactionRefundItems { get; set; }
	}
}

