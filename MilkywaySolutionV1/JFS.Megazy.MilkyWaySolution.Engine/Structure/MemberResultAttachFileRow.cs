using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MemberResultAttachFileRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private string _lableFile;
		private bool _isSetLableFile = false;
		private bool _lableFileNull = true;
		private string _description;
		private bool _isSetDescription = false;
		private bool _descriptionNull = true;
		private bool _isimage;
		private bool _isSetIsImage = false;
		private bool _isimageNull = true;
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
				_isMapRecord = false;
			}
		}
		public bool IsIsImageNull
		{
			get {
				 return _isimageNull; }
			set { _isimageNull = value; }
		}
		public Boolean _IsSetIsImage
		{
			get { return _isSetIsImage; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isMapRecord = false;
			      _isSetModifiedDate = true; }
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
	public class MemberResultAttachFileData
	{
		private int _caseID;
		private int _applicantID;
		private int _attachFileID;
		private string _lableFile;
		private string _description;
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
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class MemberResultAttachFilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MemberResultAttachFileRow[] memberResultAttachFileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MemberResultAttachFileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MemberResultAttachFileItems : MemberResultAttachFileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MemberResultAttachFileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MemberResultAttachFileItems[] memberResultAttachFileItems { get; set; }
	}
}

