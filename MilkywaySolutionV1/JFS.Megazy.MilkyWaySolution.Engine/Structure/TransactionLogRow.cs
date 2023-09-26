using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class TransactionLogRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _transactionLog;
		private bool _isSetTransactionLog = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private bool _transactionIDNull = true;
		private string _referenceFinanceID;
		private bool _isSetReferenceFinanceID = false;
		private bool _referenceFinanceIDNull = true;
		private DateTime _transactionDate;
		private bool _isSetTransactionDate = false;
		private bool _transactionDateNull = true;
		private string _paymentStatus;
		private bool _isSetPaymentStatus = false;
		private bool _paymentStatusNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int TransactionLog
		{
			get { return _transactionLog; }
			set { _transactionLog = value;
			      _isMapRecord = false;
			      _isSetTransactionLog = true; }
		}
		public Boolean _IsSetTransactionLog
		{
			get { return _isSetTransactionLog; }
		}
		public int TransactionID
		{
			get
			{
				return _transactionID;
			}
			set
			{
				_transactionIDNull = false;
				_isSetTransactionID = true;
				_transactionID = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionIDNull
		{
			get {
				 return _transactionIDNull; }
			set { _transactionIDNull = value; }
		}
		public Boolean _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
		public string ReferenceFinanceID
		{
			get
			{
				return _referenceFinanceID;
			}
			set
			{
				_referenceFinanceIDNull = false;
				_isSetReferenceFinanceID = true;
				_referenceFinanceID = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceFinanceIDNull
		{
			get {
				 return _referenceFinanceIDNull; }
			set { _referenceFinanceIDNull = value; }
		}
		public Boolean _IsSetReferenceFinanceID
		{
			get { return _isSetReferenceFinanceID; }
		}
		public DateTime TransactionDate
		{
			get
			{
				return _transactionDate;
			}
			set
			{
				_transactionDateNull = false;
				_isSetTransactionDate = true;
				_transactionDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionDateNull
		{
			get {
				 return _transactionDateNull; }
			set { _transactionDateNull = value; }
		}
		public Boolean _IsSetTransactionDate
		{
			get { return _isSetTransactionDate; }
		}
		public string PaymentStatus
		{
			get
			{
				return _paymentStatus;
			}
			set
			{
				_paymentStatusNull = false;
				_isSetPaymentStatus = true;
				_paymentStatus = value;
				_isMapRecord = false;
			}
		}
		public bool IsPaymentStatusNull
		{
			get {
				 return _paymentStatusNull; }
			set { _paymentStatusNull = value; }
		}
		public Boolean _IsSetPaymentStatus
		{
			get { return _isSetPaymentStatus; }
		}
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				_modifiedDateNull = false;
				_isSetModifiedDate = true;
				_modifiedDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class TransactionLogData
	{
		private int _transactionLog;
		private int _transactionID;
		private string _referenceFinanceID;
		private DateTime _transactionDate;
		private string _paymentStatus;
		private DateTime _modifiedDate;
		public int TransactionLog
		{
			get{ return _transactionLog; }
			set{ _transactionLog = value; }
		}
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public string ReferenceFinanceID
		{
			get{ return _referenceFinanceID; }
			set{ _referenceFinanceID = value; }
		}
		public DateTime TransactionDate
		{
			get{ return _transactionDate; }
			set{ _transactionDate = value; }
		}
		public string TransactionDateStr { get; set; }
		public string PaymentStatus
		{
			get{ return _paymentStatus; }
			set{ _paymentStatus = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class TransactionLogPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionLogRow[] transactionLogRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionLogItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionLogItems : TransactionLogData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionLogItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionLogItems[] transactionLogItems { get; set; }
	}
}

