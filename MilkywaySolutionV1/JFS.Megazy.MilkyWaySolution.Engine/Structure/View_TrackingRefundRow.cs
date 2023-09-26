using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_TrackingRefundRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _trakingRefundID;
		private bool _isSetTrakingRefundID = false;
		private int _contractID;
		private bool _isSetContractID = false;
		private string _description;
		private bool _isSetDescription = false;
		private bool _descriptionNull = true;
		private double _amount;
		private bool _isSetAmount = false;
		private DateTime _requestDate;
		private bool _isSetRequestDate = false;
		private bool _requestDateNull = true;
		private double _receivedAmount;
		private bool _isSetReceivedAmount = false;
		private bool _receivedAmountNull = true;
		private DateTime _receivedDate;
		private bool _isSetReceivedDate = false;
		private bool _receivedDateNull = true;
		private int _refundStatusID;
		private bool _isSetRefundStatusID = false;
		private string _note;
		private bool _isSetNote = false;
		private bool _noteNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _refundStatusName;
		private bool _isSetRefundStatusName = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _transactionNo;
		private bool _isSetTransactionNo = false;
		private bool _transactionNoNull = true;
		private int _transactiontype;
		private bool _isSetTransactionType = false;
		private int _transactionStatusID;
		private bool _isSetTransactionStatusID = false;
		private bool _transactionStatusIDNull = true;
		private string _trasactiontypeDesc;
		private bool _isSetTrasactionTypeDesc = false;
		private DateTime _jFPortalReceiveDate;
		private bool _isSetJFPortalReceiveDate = false;
		private bool _jFPortalReceiveDateNull = true;
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
		public int TrakingRefundID
		{
			get { return _trakingRefundID; }
			set { _trakingRefundID = value;
			      _isMapRecord = false;
			      _isSetTrakingRefundID = true; }
		}
		public Boolean _IsSetTrakingRefundID
		{
			get { return _isSetTrakingRefundID; }
		}
		[Required]
		public int ContractID
		{
			get { return _contractID; }
			set { _contractID = value;
			      _isMapRecord = false;
			      _isSetContractID = true; }
		}
		public Boolean _IsSetContractID
		{
			get { return _isSetContractID; }
		}
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_descriptionNull = false;
				_isSetDescription = true;
				_description = value;
				_isMapRecord = false;
			}
		}
		public bool IsDescriptionNull
		{
			get {
				 return _descriptionNull; }
			set { _descriptionNull = value; }
		}
		public Boolean _IsSetDescription
		{
			get { return _isSetDescription; }
		}
		[Required]
		public double Amount
		{
			get { return _amount; }
			set { _amount = value;
			      _isMapRecord = false;
			      _isSetAmount = true; }
		}
		public Boolean _IsSetAmount
		{
			get { return _isSetAmount; }
		}
		public DateTime RequestDate
		{
			get
			{
				return _requestDate;
			}
			set
			{
				_requestDateNull = false;
				_isSetRequestDate = true;
				_requestDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsRequestDateNull
		{
			get {
				 return _requestDateNull; }
			set { _requestDateNull = value; }
		}
		public Boolean _IsSetRequestDate
		{
			get { return _isSetRequestDate; }
		}
		public double ReceivedAmount
		{
			get
			{
				return _receivedAmount;
			}
			set
			{
				_receivedAmountNull = false;
				_isSetReceivedAmount = true;
				_receivedAmount = value;
				_isMapRecord = false;
			}
		}
		public bool IsReceivedAmountNull
		{
			get {
				 return _receivedAmountNull; }
			set { _receivedAmountNull = value; }
		}
		public Boolean _IsSetReceivedAmount
		{
			get { return _isSetReceivedAmount; }
		}
		public DateTime ReceivedDate
		{
			get
			{
				return _receivedDate;
			}
			set
			{
				_receivedDateNull = false;
				_isSetReceivedDate = true;
				_receivedDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsReceivedDateNull
		{
			get {
				 return _receivedDateNull; }
			set { _receivedDateNull = value; }
		}
		public Boolean _IsSetReceivedDate
		{
			get { return _isSetReceivedDate; }
		}
		[Required]
		public int RefundStatusID
		{
			get { return _refundStatusID; }
			set { _refundStatusID = value;
			      _isMapRecord = false;
			      _isSetRefundStatusID = true; }
		}
		public Boolean _IsSetRefundStatusID
		{
			get { return _isSetRefundStatusID; }
		}
		public string Note
		{
			get
			{
				return _note;
			}
			set
			{
				_noteNull = false;
				_isSetNote = true;
				_note = value;
				_isMapRecord = false;
			}
		}
		public bool IsNoteNull
		{
			get {
				 return _noteNull; }
			set { _noteNull = value; }
		}
		public Boolean _IsSetNote
		{
			get { return _isSetNote; }
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
		[Required]
		public string RefundStatusName
		{
			get { return _refundStatusName; }
			set { _refundStatusName = value;
			      _isMapRecord = false;
			      _isSetRefundStatusName = true; }
		}
		public Boolean _IsSetRefundStatusName
		{
			get { return _isSetRefundStatusName; }
		}
		[Required]
		public int TransactionID
		{
			get { return _transactionID; }
			set { _transactionID = value;
			      _isMapRecord = false;
			      _isSetTransactionID = true; }
		}
		public Boolean _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
		public string TransactionNo
		{
			get
			{
				return _transactionNo;
			}
			set
			{
				_transactionNoNull = false;
				_isSetTransactionNo = true;
				_transactionNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionNoNull
		{
			get {
				 return _transactionNoNull; }
			set { _transactionNoNull = value; }
		}
		public Boolean _IsSetTransactionNo
		{
			get { return _isSetTransactionNo; }
		}
		[Required]
		public int TransactionType
		{
			get { return _transactiontype; }
			set { _transactiontype = value;
			      _isMapRecord = false;
			      _isSetTransactionType = true; }
		}
		public Boolean _IsSetTransactionType
		{
			get { return _isSetTransactionType; }
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
				_isMapRecord = false;
			}
		}
		public bool IsTransactionStatusIDNull
		{
			get {
				 return _transactionStatusIDNull; }
			set { _transactionStatusIDNull = value; }
		}
		public Boolean _IsSetTransactionStatusID
		{
			get { return _isSetTransactionStatusID; }
		}
		[Required]
		public string TrasactionTypeDesc
		{
			get { return _trasactiontypeDesc; }
			set { _trasactiontypeDesc = value;
			      _isMapRecord = false;
			      _isSetTrasactionTypeDesc = true; }
		}
		public Boolean _IsSetTrasactionTypeDesc
		{
			get { return _isSetTrasactionTypeDesc; }
		}
		public DateTime JFPortalReceiveDate
		{
			get
			{
				return _jFPortalReceiveDate;
			}
			set
			{
				_jFPortalReceiveDateNull = false;
				_isSetJFPortalReceiveDate = true;
				_jFPortalReceiveDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsJFPortalReceiveDateNull
		{
			get {
				 return _jFPortalReceiveDateNull; }
			set { _jFPortalReceiveDateNull = value; }
		}
		public Boolean _IsSetJFPortalReceiveDate
		{
			get { return _isSetJFPortalReceiveDate; }
		}
	}
	[Serializable]
	public class View_TrackingRefundData
	{
		private int _trakingRefundID;
		private int _contractID;
		private string _description;
		private double _amount;
		private DateTime _requestDate;
		private double _receivedAmount;
		private DateTime _receivedDate;
		private int _refundStatusID;
		private string _note;
		private DateTime _modifiedDate;
		private string _refundStatusName;
		private int _transactionID;
		private string _transactionNo;
		private int _transactiontype;
		private int _transactionStatusID;
		private string _trasactiontypeDesc;
		private DateTime _jFPortalReceiveDate;
		public int TrakingRefundID
		{
			get{ return _trakingRefundID; }
			set{ _trakingRefundID = value; }
		}
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public DateTime RequestDate
		{
			get{ return _requestDate; }
			set{ _requestDate = value; }
		}
		public string RequestDateStr { get; set; }
		public double ReceivedAmount
		{
			get{ return _receivedAmount; }
			set{ _receivedAmount = value; }
		}
		public DateTime ReceivedDate
		{
			get{ return _receivedDate; }
			set{ _receivedDate = value; }
		}
		public string ReceivedDateStr { get; set; }
		public int RefundStatusID
		{
			get{ return _refundStatusID; }
			set{ _refundStatusID = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public string RefundStatusName
		{
			get{ return _refundStatusName; }
			set{ _refundStatusName = value; }
		}
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public string TransactionNo
		{
			get{ return _transactionNo; }
			set{ _transactionNo = value; }
		}
		public int TransactionType
		{
			get{ return _transactiontype; }
			set{ _transactiontype = value; }
		}
		public int TransactionStatusID
		{
			get{ return _transactionStatusID; }
			set{ _transactionStatusID = value; }
		}
		public string TrasactionTypeDesc
		{
			get{ return _trasactiontypeDesc; }
			set{ _trasactiontypeDesc = value; }
		}
		public DateTime JFPortalReceiveDate
		{
			get{ return _jFPortalReceiveDate; }
			set{ _jFPortalReceiveDate = value; }
		}
		public string JFPortalReceiveDateStr { get; set; }
	}
	[Serializable]
	public class View_TrackingRefundPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_TrackingRefundRow[] view_TrackingRefundRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_TrackingRefundItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_TrackingRefundItems : View_TrackingRefundData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_TrackingRefundItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_TrackingRefundItems[] view_TrackingRefundItems { get; set; }
	}
}

