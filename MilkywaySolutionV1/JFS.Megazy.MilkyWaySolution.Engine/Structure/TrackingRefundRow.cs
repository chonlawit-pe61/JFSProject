using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TrackingRefundRow
	{
		private int _trakingRefundID;
		private bool _isSetTrakingRefundID = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private bool _transactionIDNull = true;
		private int _contractID;
		private bool _isSetContractID = false;
		private string _description;
		private bool _isSetDescription = false;
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
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int TrakingRefundID
		{
			get { return _trakingRefundID; }
			set { _trakingRefundID = value;
			      _isSetTrakingRefundID = true; }
		}
		public bool _IsSetTrakingRefundID
		{
			get { return _isSetTrakingRefundID; }
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
			}
		}
		public bool IsTransactionIDNull
		{
			get {
				 return _transactionIDNull; }
			set { _transactionIDNull = value; }
		}
		public bool _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
		[Required]
		public int ContractID
		{
			get { return _contractID; }
			set { _contractID = value;
			      _isSetContractID = true; }
		}
		public bool _IsSetContractID
		{
			get { return _isSetContractID; }
		}
		public string Description
		{
			get { return _description; }
			set { _description = value;
			      _isSetDescription = true; }
		}
		public bool _IsSetDescription
		{
			get { return _isSetDescription; }
		}
		[Required]
		public double Amount
		{
			get { return _amount; }
			set { _amount = value;
			      _isSetAmount = true; }
		}
		public bool _IsSetAmount
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
			}
		}
		public bool IsRequestDateNull
		{
			get {
				 return _requestDateNull; }
			set { _requestDateNull = value; }
		}
		public bool _IsSetRequestDate
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
			}
		}
		public bool IsReceivedAmountNull
		{
			get {
				 return _receivedAmountNull; }
			set { _receivedAmountNull = value; }
		}
		public bool _IsSetReceivedAmount
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
			}
		}
		public bool IsReceivedDateNull
		{
			get {
				 return _receivedDateNull; }
			set { _receivedDateNull = value; }
		}
		public bool _IsSetReceivedDate
		{
			get { return _isSetReceivedDate; }
		}
		[Required]
		public int RefundStatusID
		{
			get { return _refundStatusID; }
			set { _refundStatusID = value;
			      _isSetRefundStatusID = true; }
		}
		public bool _IsSetRefundStatusID
		{
			get { return _isSetRefundStatusID; }
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
			}
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
	public class TrackingRefundData
	{
		private int _trakingRefundID;
		private int _transactionID;
		private int _contractID;
		private string _description;
		private double _amount;
		private DateTime _requestDate;
		private double _receivedAmount;
		private DateTime _receivedDate;
		private int _refundStatusID;
		private string _note;
		private DateTime _modifiedDate;
		public int TrakingRefundID
		{
			get{ return _trakingRefundID; }
			set{ _trakingRefundID = value; }
		}
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
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
	}
	[Serializable]
	public class TrackingRefundPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TrackingRefundRow[] trackingRefundRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TrackingRefundItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TrackingRefundItems : TrackingRefundData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TrackingRefundItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TrackingRefundItems[] trackingRefundItems { get; set; }
	}
}

