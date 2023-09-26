using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ChequeAttachFileRow
	{
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private bool _transactionIDNull = true;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private string _attachFileTypeCode;
		private bool _isSetAttachFileTypeCode = false;
		private int _chequeLogID;
		private bool _isSetChequeLogID = false;
		private bool _chequeLogIDNull = true;
		private string _lableFile;
		private bool _isSetLableFile = false;
		private string _description;
		private bool _isSetDescription = false;
		private string _fileName;
		private bool _isSetFileName = false;
		private string _fileType;
		private bool _isSetFileType = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value;
			      _isSetFileName = true; }
		}
		public bool _IsSetFileName
		{
			get { return _isSetFileName; }
		}
		public string FileType
		{
			get { return _fileType; }
			set { _fileType = value;
			      _isSetFileType = true; }
		}
		public bool _IsSetFileType
		{
			get { return _isSetFileType; }
		}
		public int SortOrder
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				_sortOrderNull = false;
				_isSetSortOrder = true;
				_sortOrder = value;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
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
	public class View_ChequeAttachFileData
	{
		private int _transactionID;
		private int _attachFileID;
		private string _attachFileTypeCode;
		private int _chequeLogID;
		private string _lableFile;
		private string _description;
		private string _fileName;
		private string _fileType;
		private int _sortOrder;
		private DateTime _modifiedDate;
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		public string AttachFileTypeCode
		{
			get{ return _attachFileTypeCode; }
			set{ _attachFileTypeCode = value; }
		}
		public int ChequeLogID
		{
			get{ return _chequeLogID; }
			set{ _chequeLogID = value; }
		}
		public string LableFile
		{
			get{ return _lableFile; }
			set{ _lableFile = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public string FileName
		{
			get{ return _fileName; }
			set{ _fileName = value; }
		}
		public string FileType
		{
			get{ return _fileType; }
			set{ _fileType = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class View_ChequeAttachFilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ChequeAttachFileRow[] view_ChequeAttachFileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ChequeAttachFileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ChequeAttachFileItems : View_ChequeAttachFileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ChequeAttachFileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ChequeAttachFileItems[] view_ChequeAttachFileItems { get; set; }
	}
}

