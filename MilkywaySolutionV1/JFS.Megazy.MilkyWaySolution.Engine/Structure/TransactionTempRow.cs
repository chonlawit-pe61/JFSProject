using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TransactionTempRow
	{
		private int _transactiontempID;
		private bool _isSetTransactionTempID = false;
		private string _transactionNo;
		private bool _isSetTransactionNo = false;
		private string _financialOfficerNote;
		private bool _isSetFinancialOfficerNote = false;
		private DateTime _paidDate;
		private bool _isSetPaidDate = false;
		private bool _paidDateNull = true;
		private int _transactionStatusID;
		private bool _isSetTransactionStatusID = false;
		private bool _transactionStatusIDNull = true;
		private string _paymentListJson;
		private bool _isSetPaymentListJson = false;
		[Required]
		public int TransactionTempID
		{
			get { return _transactiontempID; }
			set { _transactiontempID = value;
			      _isSetTransactionTempID = true; }
		}
		public bool _IsSetTransactionTempID
		{
			get { return _isSetTransactionTempID; }
		}
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
		public string FinancialOfficerNote
		{
			get { return _financialOfficerNote; }
			set { _financialOfficerNote = value;
			      _isSetFinancialOfficerNote = true; }
		}
		public bool _IsSetFinancialOfficerNote
		{
			get { return _isSetFinancialOfficerNote; }
		}
		public DateTime PaidDate
		{
			get
			{
				return _paidDate;
			}
			set
			{
				_paidDateNull = false;
				_isSetPaidDate = true;
				_paidDate = value;
			}
		}
		public bool IsPaidDateNull
		{
			get {
				 return _paidDateNull; }
			set { _paidDateNull = value; }
		}
		public bool _IsSetPaidDate
		{
			get { return _isSetPaidDate; }
		}
		public int TransactionStatusID
		{
			get
			{
				return _transactionStatusID;
			}
			set
			{
				_transactionStatusIDNull = false;
				_isSetTransactionStatusID = true;
				_transactionStatusID = value;
			}
		}
		public bool IsTransactionStatusIDNull
		{
			get {
				 return _transactionStatusIDNull; }
			set { _transactionStatusIDNull = value; }
		}
		public bool _IsSetTransactionStatusID
		{
			get { return _isSetTransactionStatusID; }
		}
		public string PaymentListJson
		{
			get { return _paymentListJson; }
			set { _paymentListJson = value;
			      _isSetPaymentListJson = true; }
		}
		public bool _IsSetPaymentListJson
		{
			get { return _isSetPaymentListJson; }
		}
	}
	[Serializable]
	public class TransactionTempData
	{
		private int _transactiontempID;
		private string _transactionNo;
		private string _financialOfficerNote;
		private DateTime _paidDate;
		private int _transactionStatusID;
		private string _paymentListJson;
		public int TransactionTempID
		{
			get{ return _transactiontempID; }
			set{ _transactiontempID = value; }
		}
		public string TransactionNo
		{
			get{ return _transactionNo; }
			set{ _transactionNo = value; }
		}
		public string FinancialOfficerNote
		{
			get{ return _financialOfficerNote; }
			set{ _financialOfficerNote = value; }
		}
		public DateTime PaidDate
		{
			get{ return _paidDate; }
			set{ _paidDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string PaidDateStr { get; set; }
		public int TransactionStatusID
		{
			get{ return _transactionStatusID; }
			set{ _transactionStatusID = value; }
		}
		public string PaymentListJson
		{
			get{ return _paymentListJson; }
			set{ _paymentListJson = value; }
		}
	}
	[Serializable]
	public class TransactionTempPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionTempRow[] transactiontempRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionTempItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionTempItems : TransactionTempData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionTempItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionTempItems[] transactiontempItems { get; set; }
	}
}

