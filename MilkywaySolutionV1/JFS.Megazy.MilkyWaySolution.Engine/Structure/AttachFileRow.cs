using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class AttachFileRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private string _fileName;
		private bool _isSetFileName = false;
		private bool _fileNameNull = true;
		private string _fileType;
		private bool _isSetFileType = false;
		private bool _fileTypeNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
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
				_isMapRecord = false;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public Boolean _IsSetSortOrder
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
	public class AttachFileData
	{
		private int _attachFileID;
		private string _fileName;
		private string _fileType;
		private int _sortOrder;
		private DateTime _modifiedDate;
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
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
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class AttachFilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public AttachFileRow[] attachFileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส AttachFileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class AttachFileItems : AttachFileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class AttachFileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public AttachFileItems[] attachFileItems { get; set; }
	}
}

