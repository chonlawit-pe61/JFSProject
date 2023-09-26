using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TransactionRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _transactionNo;
		private bool _isSetTransactionNo = false;
		private bool _transactionNoNull = true;
		private int _transactiontype;
		private bool _isSetTransactionType = false;
		private int _refApplicantID;
		private bool _isSetRefApplicantID = false;
		private bool _refApplicantIDNull = true;
		private int _refCaseID;
		private bool _isSetRefCaseID = false;
		private bool _refCaseIDNull = true;
		private int _refContractID;
		private bool _isSetRefContractID = false;
		private bool _refContractIDNull = true;
		private double _totalAmount;
		private bool _isSetTotalAmount = false;
		private bool _totalAmountNull = true;
		private double _totalAmountPaid;
		private bool _isSetTotalAmountPaid = false;
		private bool _totalAmountPaidNull = true;
		private string _note;
		private bool _isSetNote = false;
		private bool _noteNull = true;
		private string _financialOfficerNote;
		private bool _isSetFinancialOfficerNote = false;
		private bool _financialOfficerNoteNull = true;
		private DateTime _tranferDate;
		private bool _isSetTranferDate = false;
		private bool _tranferDateNull = true;
		private DateTime _paidDate;
		private bool _isSetPaidDate = false;
		private bool _paidDateNull = true;
		private int _transactionStatusID;
		private bool _isSetTransactionStatusID = false;
		private bool _transactionStatusIDNull = true;
		private bool _deleteFlag;
		private bool _isSetDeleteFlag = false;
		private bool _deleteFlagNull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private DateTime _transactionDate;
		private bool _isSetTransactionDate = false;
		private bool _transactionDateNull = true;
		private string _paymentListJson;
		private bool _isSetPaymentListJson = false;
		private bool _paymentListJsonNull = true;
		private DateTime _receiveDate;
		private bool _isSetReceiveDate = false;
		private bool _receiveDateNull = true;
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
		public int RefApplicantID
		{
			get
			{
				return _refApplicantID;
			}
			set
			{
				_refApplicantIDNull = false;
				_isSetRefApplicantID = true;
				_refApplicantID = value;
				_isMapRecord = false;
			}
		}
		public bool IsRefApplicantIDNull
		{
			get {
				 return _refApplicantIDNull; }
			set { _refApplicantIDNull = value; }
		}
		public Boolean _IsSetRefApplicantID
		{
			get { return _isSetRefApplicantID; }
		}
		public int RefCaseID
		{
			get
			{
				return _refCaseID;
			}
			set
			{
				_refCaseIDNull = false;
				_isSetRefCaseID = true;
				_refCaseID = value;
				_isMapRecord = false;
			}
		}
		public bool IsRefCaseIDNull
		{
			get {
				 return _refCaseIDNull; }
			set { _refCaseIDNull = value; }
		}
		public Boolean _IsSetRefCaseID
		{
			get { return _isSetRefCaseID; }
		}
		public int RefContractID
		{
			get
			{
				return _refContractID;
			}
			set
			{
				_refContractIDNull = false;
				_isSetRefContractID = true;
				_refContractID = value;
				_isMapRecord = false;
			}
		}
		public bool IsRefContractIDNull
		{
			get {
				 return _refContractIDNull; }
			set { _refContractIDNull = value; }
		}
		public Boolean _IsSetRefContractID
		{
			get { return _isSetRefContractID; }
		}
		public double TotalAmount
		{
			get
			{
				return _totalAmount;
			}
			set
			{
				_totalAmountNull = false;
				_isSetTotalAmount = true;
				_totalAmount = value;
				_isMapRecord = false;
			}
		}
		public bool IsTotalAmountNull
		{
			get {
				 return _totalAmountNull; }
			set { _totalAmountNull = value; }
		}
		public Boolean _IsSetTotalAmount
		{
			get { return _isSetTotalAmount; }
		}
		public double TotalAmountPaid
		{
			get
			{
				return _totalAmountPaid;
			}
			set
			{
				_totalAmountPaidNull = false;
				_isSetTotalAmountPaid = true;
				_totalAmountPaid = value;
				_isMapRecord = false;
			}
		}
		public bool IsTotalAmountPaidNull
		{
			get {
				 return _totalAmountPaidNull; }
			set { _totalAmountPaidNull = value; }
		}
		public Boolean _IsSetTotalAmountPaid
		{
			get { return _isSetTotalAmountPaid; }
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
		public string FinancialOfficerNote
		{
			get
			{
				return _financialOfficerNote;
			}
			set
			{
				_financialOfficerNoteNull = false;
				_isSetFinancialOfficerNote = true;
				_financialOfficerNote = value;
				_isMapRecord = false;
			}
		}
		public bool IsFinancialOfficerNoteNull
		{
			get {
				 return _financialOfficerNoteNull; }
			set { _financialOfficerNoteNull = value; }
		}
		public Boolean _IsSetFinancialOfficerNote
		{
			get { return _isSetFinancialOfficerNote; }
		}
		public DateTime TranferDate
		{
			get
			{
				return _tranferDate;
			}
			set
			{
				_tranferDateNull = false;
				_isSetTranferDate = true;
				_tranferDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsTranferDateNull
		{
			get {
				 return _tranferDateNull; }
			set { _tranferDateNull = value; }
		}
		public Boolean _IsSetTranferDate
		{
			get { return _isSetTranferDate; }
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
				_isMapRecord = false;
			}
		}
		public bool IsPaidDateNull
		{
			get {
				 return _paidDateNull; }
			set { _paidDateNull = value; }
		}
		public Boolean _IsSetPaidDate
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
		public bool DeleteFlag
		{
			get
			{
				return _deleteFlag;
			}
			set
			{
				_deleteFlagNull = false;
				_isSetDeleteFlag = true;
				_deleteFlag = value;
				_isMapRecord = false;
			}
		}
		public bool IsDeleteFlagNull
		{
			get {
				 return _deleteFlagNull; }
			set { _deleteFlagNull = value; }
		}
		public Boolean _IsSetDeleteFlag
		{
			get { return _isSetDeleteFlag; }
		}
		public DateTime CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				_createDateNull = false;
				_isSetCreateDate = true;
				_createDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public Boolean _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
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
		public string PaymentListJson
		{
			get
			{
				return _paymentListJson;
			}
			set
			{
				_paymentListJsonNull = false;
				_isSetPaymentListJson = true;
				_paymentListJson = value;
				_isMapRecord = false;
			}
		}
		public bool IsPaymentListJsonNull
		{
			get {
				 return _paymentListJsonNull; }
			set { _paymentListJsonNull = value; }
		}
		public Boolean _IsSetPaymentListJson
		{
			get { return _isSetPaymentListJson; }
		}
		public DateTime ReceiveDate
		{
			get
			{
				return _receiveDate;
			}
			set
			{
				_receiveDateNull = false;
				_isSetReceiveDate = true;
				_receiveDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsReceiveDateNull
		{
			get {
				 return _receiveDateNull; }
			set { _receiveDateNull = value; }
		}
		public Boolean _IsSetReceiveDate
		{
			get { return _isSetReceiveDate; }
		}
	}
	[Serializable]
	public class TransactionData
	{
		private int _transactionID;
		private string _transactionNo;
		private int _transactiontype;
		private int _refApplicantID;
		private int _refCaseID;
		private int _refContractID;
		private double _totalAmount;
		private double _totalAmountPaid;
		private string _note;
		private string _financialOfficerNote;
		private DateTime _tranferDate;
		private DateTime _paidDate;
		private int _transactionStatusID;
		private bool _deleteFlag;
		private DateTime _createDate;
		private DateTime _modifiedDate;
		private DateTime _transactionDate;
		private string _paymentListJson;
		private DateTime _receiveDate;
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
		public int RefApplicantID
		{
			get{ return _refApplicantID; }
			set{ _refApplicantID = value; }
		}
		public int RefCaseID
		{
			get{ return _refCaseID; }
			set{ _refCaseID = value; }
		}
		public int RefContractID
		{
			get{ return _refContractID; }
			set{ _refContractID = value; }
		}
		public double TotalAmount
		{
			get{ return _totalAmount; }
			set{ _totalAmount = value; }
		}
		public double TotalAmountPaid
		{
			get{ return _totalAmountPaid; }
			set{ _totalAmountPaid = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public string FinancialOfficerNote
		{
			get{ return _financialOfficerNote; }
			set{ _financialOfficerNote = value; }
		}
		public DateTime TranferDate
		{
			get{ return _tranferDate; }
			set{ _tranferDate = value; }
		}
		public string TranferDateStr { get; set; }
		public DateTime PaidDate
		{
			get{ return _paidDate; }
			set{ _paidDate = value; }
		}
		public string PaidDateStr { get; set; }
		public int TransactionStatusID
		{
			get{ return _transactionStatusID; }
			set{ _transactionStatusID = value; }
		}
		public bool DeleteFlag
		{
			get{ return _deleteFlag; }
			set{ _deleteFlag = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public DateTime TransactionDate
		{
			get{ return _transactionDate; }
			set{ _transactionDate = value; }
		}
		public string TransactionDateStr { get; set; }
		public string PaymentListJson
		{
			get{ return _paymentListJson; }
			set{ _paymentListJson = value; }
		}
		public DateTime ReceiveDate
		{
			get{ return _receiveDate; }
			set{ _receiveDate = value; }
		}
		public string ReceiveDateStr { get; set; }
	}
	[Serializable]
	public class TransactionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionRow[] transactionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionItems : TransactionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionItems[] transactionItems { get; set; }
	}
}

