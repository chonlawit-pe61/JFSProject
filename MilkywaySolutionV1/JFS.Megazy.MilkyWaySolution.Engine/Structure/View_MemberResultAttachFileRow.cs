using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_MemberResultAttachFileRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private string _lableFile;
		private bool _isSetLableFile = false;
		private string _description;
		private bool _isSetDescription = false;
		private string _fileName;
		private bool _isSetFileName = false;
		private string _fileType;
		private bool _isSetFileType = false;
		private bool _isimage;
		private bool _isSetIsImage = false;
		private bool _isimageNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		[Required]
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isSetApplicantID = true; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
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
		public bool IsImage
		{
			get
			{
				return _isimage;
			}
			set
			{
				_isimageNull = false;
				_isSetIsImage = true;
				_isimage = value;
			}
		}
		public bool IsIsImageNull
		{
			get {
				 return _isimageNull; }
			set { _isimageNull = value; }
		}
		public bool _IsSetIsImage
		{
			get { return _isSetIsImage; }
		}
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
	}
	[Serializable]
	public class View_MemberResultAttachFileData
	{
		private int _caseID;
		private int _applicantID;
		private int _attachFileID;
		private string _lableFile;
		private string _description;
		private string _fileName;
		private string _fileType;
		private bool _isimage;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
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
		public bool IsImage
		{
			get{ return _isimage; }
			set{ _isimage = value; }
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
	public class View_MemberResultAttachFilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_MemberResultAttachFileRow[] view_MemberResultAttachFileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_MemberResultAttachFileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_MemberResultAttachFileItems : View_MemberResultAttachFileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_MemberResultAttachFileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_MemberResultAttachFileItems[] view_MemberResultAttachFileItems { get; set; }
	}
}

