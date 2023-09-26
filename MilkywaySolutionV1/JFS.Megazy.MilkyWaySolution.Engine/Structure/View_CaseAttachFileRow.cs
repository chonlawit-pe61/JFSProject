using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_CaseAttachFileRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private bool _workStepIDNull = true;
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
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
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
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
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
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isMapRecord = false;
			      _isSetApplicantID = true; }
		}
		public Boolean _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public int WorkStepID
		{
			get
			{
				return _workStepID;
			}
			set
			{
				_workStepIDNull = false;
				_isSetWorkStepID = true;
				_workStepID = value;
				_isMapRecord = false;
			}
		}
		public bool IsWorkStepIDNull
		{
			get {
				 return _workStepIDNull; }
			set { _workStepIDNull = value; }
		}
		public Boolean _IsSetWorkStepID
		{
			get { return _isSetWorkStepID; }
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
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public Boolean _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
	public class View_CaseAttachFileData
	{
		private int _caseID;
		private int _attachFileID;
		private int _applicantID;
		private int _workStepID;
		private string _lableFile;
		private string _description;
		private string _fileName;
		private string _fileType;
		private int _sortOrder;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
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
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class View_CaseAttachFilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseAttachFileRow[] view_CaseAttachFileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseAttachFileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseAttachFileItems : View_CaseAttachFileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseAttachFileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseAttachFileItems[] view_CaseAttachFileItems { get; set; }
	}
}

