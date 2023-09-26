using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TransactionAdditionalRow
	{
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _payer;
		private bool _isSetPayer = false;
		private string _payee;
		private bool _isSetPayee = false;
		private string _courtName;
		private bool _isSetCourtName = false;
		private string _courtLevel;
		private bool _isSetCourtLevel = false;
		private string _lawyerAddressline;
		private bool _isSetLawyerAddressLine = false;
		private string _bankAccountName;
		private bool _isSetBankAccountName = false;
		private string _bankAccountNo;
		private bool _isSetBankAccountNo = false;
		private string _bankName;
		private bool _isSetBankName = false;
		private string _bankbranch;
		private bool _isSetBankBranch = false;
		private string _bankAccountType;
		private bool _isSetBankAccountType = false;
		private string _paymentListJson;
		private bool _isSetPaymentListJson = false;
		private int? _refTransactionID;
		private bool _isSetRefTransactionID = false;
		private bool _refTransactionIDNull = true;
		private bool _isRequestRefund;
		private bool _isSetIsRequestRefund = false;
		private bool _isRequestRefundNull = true;
		/// <summary>
		/// รหัสรายการธุรกรรม อ้างอิงตาราง Transaction
		/// </summary>
		[Required]
		public int TransactionID
		{
			get { return _transactionID; }
			set { _transactionID = value;
			      _isSetTransactionID = true; }
		}
		public bool _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
		/// <summary>
		/// ผู้ชำระเงิน
		/// </summary>
		public string Payer
		{
			get { return _payer; }
			set { _payer = value;
			      _isSetPayer = true; }
		}
		public bool _IsSetPayer
		{
			get { return _isSetPayer; }
		}
		/// <summary>
		/// ผู้รับเงิน
		/// </summary>
		public string Payee
		{
			get { return _payee; }
			set { _payee = value;
			      _isSetPayee = true; }
		}
		public bool _IsSetPayee
		{
			get { return _isSetPayee; }
		}
		/// <summary>
		/// ชื่อศาล
		/// </summary>
		public string CourtName
		{
			get { return _courtName; }
			set { _courtName = value;
			      _isSetCourtName = true; }
		}
		public bool _IsSetCourtName
		{
			get { return _isSetCourtName; }
		}
		/// <summary>
		/// ชั้นศาล
		/// </summary>
		public string CourtLevel
		{
			get { return _courtLevel; }
			set { _courtLevel = value;
			      _isSetCourtLevel = true; }
		}
		public bool _IsSetCourtLevel
		{
			get { return _isSetCourtLevel; }
		}
		/// <summary>
		/// ที่อยู่ทนาย
		/// </summary>
		public string LawyerAddressLine
		{
			get { return _lawyerAddressline; }
			set { _lawyerAddressline = value;
			      _isSetLawyerAddressLine = true; }
		}
		public bool _IsSetLawyerAddressLine
		{
			get { return _isSetLawyerAddressLine; }
		}
		/// <summary>
		/// ชื่อบัญชี
		/// </summary>
		public string BankAccountName
		{
			get { return _bankAccountName; }
			set { _bankAccountName = value;
			      _isSetBankAccountName = true; }
		}
		public bool _IsSetBankAccountName
		{
			get { return _isSetBankAccountName; }
		}
		/// <summary>
		/// เลขที่บัญชี
		/// </summary>
		public string BankAccountNo
		{
			get { return _bankAccountNo; }
			set { _bankAccountNo = value;
			      _isSetBankAccountNo = true; }
		}
		public bool _IsSetBankAccountNo
		{
			get { return _isSetBankAccountNo; }
		}
		/// <summary>
		/// ชื่อธนาคาร
		/// </summary>
		public string BankName
		{
			get { return _bankName; }
			set { _bankName = value;
			      _isSetBankName = true; }
		}
		public bool _IsSetBankName
		{
			get { return _isSetBankName; }
		}
		/// <summary>
		/// สาขาธนาคาร
		/// </summary>
		public string BankBranch
		{
			get { return _bankbranch; }
			set { _bankbranch = value;
			      _isSetBankBranch = true; }
		}
		public bool _IsSetBankBranch
		{
			get { return _isSetBankBranch; }
		}
		/// <summary>
		/// ประเภทบัญชี ออมทรัพย์,ฝากประจำ
		/// </summary>
		public string BankAccountType
		{
			get { return _bankAccountType; }
			set { _bankAccountType = value;
			      _isSetBankAccountType = true; }
		}
		public bool _IsSetBankAccountType
		{
			get { return _isSetBankAccountType; }
		}
		/// <summary>
		/// รายการจ่าย เช่น เช็ค โอน
		/// </summary>
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
		/// <summary>
		/// Ref. TransactionID กรณียกเลิกใบเบิกจ่ายที่จ่ายเงินเกิน
		/// </summary>
		public int? RefTransactionID
		{
			get
			{
				return _refTransactionID;
			}
			set
			{
				_refTransactionIDNull = false;
				_isSetRefTransactionID = true;
				_refTransactionID = value;
			}
		}
		public bool IsRefTransactionIDNull
		{
			get {
				 return _refTransactionIDNull; }
			set { _refTransactionIDNull = value; }
		}
		public bool _IsSetRefTransactionID
		{
			get { return _isSetRefTransactionID; }
		}
		/// <summary>
		/// ร้องขอให้เรียกคืนเงิน
		/// </summary>
		public bool IsRequestRefund
		{
			get
			{
				return _isRequestRefund;
			}
			set
			{
				_isRequestRefundNull = false;
				_isSetIsRequestRefund = true;
				_isRequestRefund = value;
			}
		}
		public bool IsIsRequestRefundNull
		{
			get {
				 return _isRequestRefundNull; }
			set { _isRequestRefundNull = value; }
		}
		public bool _IsSetIsRequestRefund
		{
			get { return _isSetIsRequestRefund; }
		}
	}
	[Serializable]
	public class TransactionAdditionalData
	{
		private int _transactionID;
		private string _payer;
		private string _payee;
		private string _courtName;
		private string _courtLevel;
		private string _lawyerAddressline;
		private string _bankAccountName;
		private string _bankAccountNo;
		private string _bankName;
		private string _bankbranch;
		private string _bankAccountType;
		private string _paymentListJson;
		private int? _refTransactionID;
		private bool _isRequestRefund;
		/// <summary>
		/// รหัสรายการธุรกรรม อ้างอิงตาราง Transaction
		/// </summary>
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		/// <summary>
		/// ผู้ชำระเงิน
		/// </summary>
		public string Payer
		{
			get{ return _payer; }
			set{ _payer = value; }
		}
		/// <summary>
		/// ผู้รับเงิน
		/// </summary>
		public string Payee
		{
			get{ return _payee; }
			set{ _payee = value; }
		}
		/// <summary>
		/// ชื่อศาล
		/// </summary>
		public string CourtName
		{
			get{ return _courtName; }
			set{ _courtName = value; }
		}
		/// <summary>
		/// ชั้นศาล
		/// </summary>
		public string CourtLevel
		{
			get{ return _courtLevel; }
			set{ _courtLevel = value; }
		}
		/// <summary>
		/// ที่อยู่ทนาย
		/// </summary>
		public string LawyerAddressLine
		{
			get{ return _lawyerAddressline; }
			set{ _lawyerAddressline = value; }
		}
		/// <summary>
		/// ชื่อบัญชี
		/// </summary>
		public string BankAccountName
		{
			get{ return _bankAccountName; }
			set{ _bankAccountName = value; }
		}
		/// <summary>
		/// เลขที่บัญชี
		/// </summary>
		public string BankAccountNo
		{
			get{ return _bankAccountNo; }
			set{ _bankAccountNo = value; }
		}
		/// <summary>
		/// ชื่อธนาคาร
		/// </summary>
		public string BankName
		{
			get{ return _bankName; }
			set{ _bankName = value; }
		}
		/// <summary>
		/// สาขาธนาคาร
		/// </summary>
		public string BankBranch
		{
			get{ return _bankbranch; }
			set{ _bankbranch = value; }
		}
		/// <summary>
		/// ประเภทบัญชี ออมทรัพย์,ฝากประจำ
		/// </summary>
		public string BankAccountType
		{
			get{ return _bankAccountType; }
			set{ _bankAccountType = value; }
		}
		/// <summary>
		/// รายการจ่าย เช่น เช็ค โอน
		/// </summary>
		public string PaymentListJson
		{
			get{ return _paymentListJson; }
			set{ _paymentListJson = value; }
		}
		/// <summary>
		/// Ref. TransactionID กรณียกเลิกใบเบิกจ่ายที่จ่ายเงินเกิน
		/// </summary>
		public int? RefTransactionID
		{
			get{ return _refTransactionID; }
			set{ _refTransactionID = value; }
		}
		/// <summary>
		/// ร้องขอให้เรียกคืนเงิน
		/// </summary>
		public bool IsRequestRefund
		{
			get{ return _isRequestRefund; }
			set{ _isRequestRefund = value; }
		}
	}
	[Serializable]
	public class TransactionAdditionalPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionAdditionalRow[] transactionAdditionalRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionAdditionalItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionAdditionalItems : TransactionAdditionalData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionAdditionalItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionAdditionalItems[] transactionAdditionalItems { get; set; }
	}
}

