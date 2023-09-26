using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class View_TransectionAttachfileRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _lableFile;
		private bool _isSetLableFile = false;
		private bool _lableFileNull = true;
		private string _description;
		private bool _isSetDescription = false;
		private bool _descriptionNull = true;
		private string _fileName;
		private bool _isSetFileName = false;
		private bool _fileNameNull = true;
		private string _fileType;
		private bool _isSetFileType = false;
		private bool _fileTypeNull = true;
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
		public int AttachFileID
		{
			get { return _attachFileID; }
			set { _attachFileID = value;
			      _isMapRecord = false;
			      _isSetAttachFileID = true; }
		}
		public Boolean _IsSetAttachFileID
		{
			get { return _isSetAttachFileID; }
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
		public string LableFile
		{
			get
			{
				return _lableFile;
			}
			set
			{
				_lableFileNull = false;
				_isSetLableFile = true;
				_lableFile = value;
				_isMapRecord = false;
			}
		}
		public bool IsLableFileNull
		{
			get {
				 return _lableFileNull; }
			set { _lableFileNull = value; }
		}
		public Boolean _IsSetLableFile
		{
			get { return _isSetLableFile; }
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
		public string FileName
		{
			get
			{
				return _fileName;
			}
			set
			{
				_fileNameNull = false;
				_isSetFileName = true;
				_fileName = value;
				_isMapRecord = false;
			}
		}
		public bool IsFileNameNull
		{
			get {
				 return _fileNameNull; }
			set { _fileNameNull = value; }
		}
		public Boolean _IsSetFileName
		{
			get { return _isSetFileName; }
		}
		public string FileType
		{
			get
			{
				return _fileType;
			}
			set
			{
				_fileTypeNull = false;
				_isSetFileType = true;
				_fileType = value;
				_isMapRecord = false;
			}
		}
		public bool IsFileTypeNull
		{
			get {
				 return _fileTypeNull; }
			set { _fileTypeNull = value; }
		}
		public Boolean _IsSetFileType
		{
			get { return _isSetFileType; }
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
	public class View_TransectionAttachfileData
	{
		private int _attachFileID;
		private int _transactionID;
		private string _lableFile;
		private string _description;
		private string _fileName;
		private string _fileType;
		private DateTime _modifiedDate;
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class View_TransectionAttachfilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_TransectionAttachfileRow[] view_TransectionAttachfileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_TransectionAttachfileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_TransectionAttachfileItems : View_TransectionAttachfileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_TransectionAttachfileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_TransectionAttachfileItems[] view_TransectionAttachfileItems { get; set; }
	}
}

