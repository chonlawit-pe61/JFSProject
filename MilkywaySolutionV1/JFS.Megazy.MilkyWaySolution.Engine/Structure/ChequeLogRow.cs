using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ChequeLogRow
	{
		private int _chequeLogID;
		private bool _isSetChequeLogID = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _chequeNo;
		private bool _isSetChequeNo = false;
		private double _amount;
		private bool _isSetAmount = false;
		private string _chequeStatus;
		private bool _isSetChequeStatus = false;
		private string _chequeNote;
		private bool _isSetChequeNote = false;
		private string _moneyOrderCertificateNumber;
		private bool _isSetMoneyOrderCertificateNumber = false;
		private DateTime _dateCreated;
		private bool _isSetDateCreated = false;
		private bool _dateCreatedNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _additionalDataJson;
		private bool _isSetAdditionalDataJson = false;
		private int _lastModifiedByUserID;
		private bool _isSetLastModifiedByUserID = false;
		private bool _lastModifiedByUserIDNull = true;
		private bool _flagDelete;
		private bool _isSetFlagDelete = false;
		[Required]
		public int ChequeLogID
		{
			get { return _chequeLogID; }
			set { _chequeLogID = value;
			      _isSetChequeLogID = true; }
		}
		public bool _IsSetChequeLogID
		{
			get { return _isSetChequeLogID; }
		}
		/// <summary>
		/// รหัสรายการ อ้างอิงตาราง Transaction:TransactionID
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
		[Required]
		public string ChequeNo
		{
			get { return _chequeNo; }
			set { _chequeNo = value;
			      _isSetChequeNo = true; }
		}
		public bool _IsSetChequeNo
		{
			get { return _isSetChequeNo; }
		}
		/// <summary>
		/// จำนวนเงิน
		/// </summary>
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
		/// <summary>
		/// สถานะเช็คหลังจากการเงินสั่งจ่ายมาแล้ว  ONHAND=อยู่กับนิติกรหรือ จนท.,PAID=จ่ายให้ผู้รับเงินแล้ว,RETURN=ไม่ได้ใช้เช็ค(ส่งกลับ)
		/// </summary>
		[Required]
		public string ChequeStatus
		{
			get { return _chequeStatus; }
			set { _chequeStatus = value;
			      _isSetChequeStatus = true; }
		}
		public bool _IsSetChequeStatus
		{
			get { return _isSetChequeStatus; }
		}
		/// <summary>
		/// หมายเหตุ
		/// </summary>
		public string ChequeNote
		{
			get { return _chequeNote; }
			set { _chequeNote = value;
			      _isSetChequeNote = true; }
		}
		public bool _IsSetChequeNote
		{
			get { return _isSetChequeNote; }
		}
		/// <summary>
		/// เลขที่หนังสือรับรอง จะบันทึก กรณีที่  ChequeStatus = CHANG   ที่จะเปลี่ยนไปเป็นหนังสือรับรอง
		/// </summary>
		public string MoneyOrderCertificateNumber
		{
			get { return _moneyOrderCertificateNumber; }
			set { _moneyOrderCertificateNumber = value;
			      _isSetMoneyOrderCertificateNumber = true; }
		}
		public bool _IsSetMoneyOrderCertificateNumber
		{
			get { return _isSetMoneyOrderCertificateNumber; }
		}
		/// <summary>
		/// วันเวลาที่สร้างรายการ
		/// </summary>
		[Required]
		public DateTime DateCreated
		{
			get { return _dateCreated; }
			set { _dateCreated = value;
			      _dateCreatedNull = false;
			      _isSetDateCreated = true; }
		}
		public bool IsDateCreatedNull
		{
			get {
				 return _dateCreatedNull; }
			set { _dateCreatedNull = value; }
		}
		public bool _IsSetDateCreated
		{
			get { return _isSetDateCreated; }
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
		/// <summary>
		/// ข้อมูลเพิ่มเติมเก็บในรูปแบบ Json
		/// </summary>
		public string AdditionalDataJson
		{
			get { return _additionalDataJson; }
			set { _additionalDataJson = value;
			      _isSetAdditionalDataJson = true; }
		}
		public bool _IsSetAdditionalDataJson
		{
			get { return _isSetAdditionalDataJson; }
		}
		public int LastModifiedByUserID
		{
			get
			{
				return _lastModifiedByUserID;
			}
			set
			{
				_lastModifiedByUserIDNull = false;
				_isSetLastModifiedByUserID = true;
				_lastModifiedByUserID = value;
			}
		}
		public bool IsLastModifiedByUserIDNull
		{
			get {
				 return _lastModifiedByUserIDNull; }
			set { _lastModifiedByUserIDNull = value; }
		}
		public bool _IsSetLastModifiedByUserID
		{
			get { return _isSetLastModifiedByUserID; }
		}
		/// <summary>
		/// สถานะการลบข้อมูลเช็ค 0=ปกติ 1=ลบรายการ
		/// </summary>
		[Required]
		public bool FlagDelete
		{
			get { return _flagDelete; }
			set { _flagDelete = value;
			      _isSetFlagDelete = true; }
		}
		public bool _IsSetFlagDelete
		{
			get { return _isSetFlagDelete; }
		}
	}
	[Serializable]
	public class ChequeLogData
	{
		private int _chequeLogID;
		private int _transactionID;
		private string _chequeNo;
		private double _amount;
		private string _chequeStatus;
		private string _chequeNote;
		private string _moneyOrderCertificateNumber;
		private DateTime _dateCreated;
		private DateTime _modifiedDate;
		private string _additionalDataJson;
		private int _lastModifiedByUserID;
		private bool _flagDelete;
		public int ChequeLogID
		{
			get{ return _chequeLogID; }
			set{ _chequeLogID = value; }
		}
		/// <summary>
		/// รหัสรายการ อ้างอิงตาราง Transaction:TransactionID
		/// </summary>
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public string ChequeNo
		{
			get{ return _chequeNo; }
			set{ _chequeNo = value; }
		}
		/// <summary>
		/// จำนวนเงิน
		/// </summary>
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		/// <summary>
		/// สถานะเช็คหลังจากการเงินสั่งจ่ายมาแล้ว  ONHAND=อยู่กับนิติกรหรือ จนท.,PAID=จ่ายให้ผู้รับเงินแล้ว,RETURN=ไม่ได้ใช้เช็ค(ส่งกลับ)
		/// </summary>
		public string ChequeStatus
		{
			get{ return _chequeStatus; }
			set{ _chequeStatus = value; }
		}
		/// <summary>
		/// หมายเหตุ
		/// </summary>
		public string ChequeNote
		{
			get{ return _chequeNote; }
			set{ _chequeNote = value; }
		}
		/// <summary>
		/// เลขที่หนังสือรับรอง จะบันทึก กรณีที่  ChequeStatus = CHANG   ที่จะเปลี่ยนไปเป็นหนังสือรับรอง
		/// </summary>
		public string MoneyOrderCertificateNumber
		{
			get{ return _moneyOrderCertificateNumber; }
			set{ _moneyOrderCertificateNumber = value; }
		}
		/// <summary>
		/// วันเวลาที่สร้างรายการ
		/// </summary>
		public DateTime DateCreated
		{
			get{ return _dateCreated; }
			set{ _dateCreated = value; }
		}
		/// <summary>
		/// วันเวลาที่สร้างรายการ เก็บวันที่แบบ String
		/// </summary>
		public string DateCreatedStr { get; set; }
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
		/// <summary>
		/// ข้อมูลเพิ่มเติมเก็บในรูปแบบ Json
		/// </summary>
		public string AdditionalDataJson
		{
			get{ return _additionalDataJson; }
			set{ _additionalDataJson = value; }
		}
		public int LastModifiedByUserID
		{
			get{ return _lastModifiedByUserID; }
			set{ _lastModifiedByUserID = value; }
		}
		/// <summary>
		/// สถานะการลบข้อมูลเช็ค 0=ปกติ 1=ลบรายการ
		/// </summary>
		public bool FlagDelete
		{
			get{ return _flagDelete; }
			set{ _flagDelete = value; }
		}
	}
	[Serializable]
	public class ChequeLogPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ChequeLogRow[] chequeLogRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ChequeLogItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ChequeLogItems : ChequeLogData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ChequeLogItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ChequeLogItems[] chequeLogItems { get; set; }
	}
}

