using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ChequeAttachFileRow
	{
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private string _attachFileTypeCode;
		private bool _isSetAttachFileTypeCode = false;
		private int _chequeLogID;
		private bool _isSetChequeLogID = false;
		private bool _chequeLogIDNull = true;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private bool _transactionIDNull = true;
		private string _lableFile;
		private bool _isSetLableFile = false;
		private string _description;
		private bool _isSetDescription = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสไฟล์แนบ อ้างอิงตาราง AttachFile
		/// </summary>
		[Required]
		public int AttachFileID
		{
			get { return _attachFileID; }
			set { _attachFileID = value;
			      _isSetAttachFileID = true; }
		}
		public bool _IsSetAttachFileID
		{
			get { return _isSetAttachFileID; }
		}
		/// <summary>
		/// รหัสประเภทไฟล์ใช้ในการอ้างอิง เช่น   CHEQUE_REPORT,COURT_RECEIPT
		/// </summary>
		public string AttachFileTypeCode
		{
			get { return _attachFileTypeCode; }
			set { _attachFileTypeCode = value;
			      _isSetAttachFileTypeCode = true; }
		}
		public bool _IsSetAttachFileTypeCode
		{
			get { return _isSetAttachFileTypeCode; }
		}
		/// <summary>
		/// รหัสเช็ค อ้างอิงตาราง ChequeLog
		/// </summary>
		public int ChequeLogID
		{
			get
			{
				return _chequeLogID;
			}
			set
			{
				_chequeLogIDNull = false;
				_isSetChequeLogID = true;
				_chequeLogID = value;
			}
		}
		public bool IsChequeLogIDNull
		{
			get {
				 return _chequeLogIDNull; }
			set { _chequeLogIDNull = value; }
		}
		public bool _IsSetChequeLogID
		{
			get { return _isSetChequeLogID; }
		}
		/// <summary>
		/// รหัสรายการ
		/// </summary>
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
		/// <summary>
		/// ชื่อไฟล์
		/// </summary>
		public string LableFile
		{
			get { return _lableFile; }
			set { _lableFile = value;
			      _isSetLableFile = true; }
		}
		public bool _IsSetLableFile
		{
			get { return _isSetLableFile; }
		}
		/// <summary>
		/// คำอธิบาย
		/// </summary>
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
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
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
	public class ChequeAttachFileData
	{
		private int _attachFileID;
		private string _attachFileTypeCode;
		private int _chequeLogID;
		private int _transactionID;
		private string _lableFile;
		private string _description;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสไฟล์แนบ อ้างอิงตาราง AttachFile
		/// </summary>
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		/// <summary>
		/// รหัสประเภทไฟล์ใช้ในการอ้างอิง เช่น   CHEQUE_REPORT,COURT_RECEIPT
		/// </summary>
		public string AttachFileTypeCode
		{
			get{ return _attachFileTypeCode; }
			set{ _attachFileTypeCode = value; }
		}
		/// <summary>
		/// รหัสเช็ค อ้างอิงตาราง ChequeLog
		/// </summary>
		public int ChequeLogID
		{
			get{ return _chequeLogID; }
			set{ _chequeLogID = value; }
		}
		/// <summary>
		/// รหัสรายการ
		/// </summary>
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		/// <summary>
		/// ชื่อไฟล์
		/// </summary>
		public string LableFile
		{
			get{ return _lableFile; }
			set{ _lableFile = value; }
		}
		/// <summary>
		/// คำอธิบาย
		/// </summary>
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
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
	public class ChequeAttachFilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ChequeAttachFileRow[] chequeAttachFileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ChequeAttachFileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ChequeAttachFileItems : ChequeAttachFileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ChequeAttachFileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ChequeAttachFileItems[] chequeAttachFileItems { get; set; }
	}
}

