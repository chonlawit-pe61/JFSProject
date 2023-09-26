using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicationRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _subject;
		private bool _isSetSubject = false;
		private bool _subjectNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private int _channelID;
		private bool _isSetChannelID = false;
		private int _referenceCaseID;
		private bool _isSetReferenceCaseID = false;
		private bool _referenceCaseIDNull = true;
		private int _referenceMSCID;
		private bool _isSetReferenceMSCID = false;
		private bool _referenceMSCIDNull = true;
		private string _referenceMSCCODE;
		private bool _isSetReferenceMSCCODE = false;
		private bool _referenceMSCCODENull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _registerDate;
		private bool _isSetRegisterDate = false;
		private bool _registerDateNull = true;
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
		public string Subject
		{
			get
			{
				return _subject;
			}
			set
			{
				_subjectNull = false;
				_isSetSubject = true;
				_subject = value;
				_isMapRecord = false;
			}
		}
		public bool IsSubjectNull
		{
			get {
				 return _subjectNull; }
			set { _subjectNull = value; }
		}
		public Boolean _IsSetSubject
		{
			get { return _isSetSubject; }
		}
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isMapRecord = false;
			      _isSetDepartmentID = true; }
		}
		public Boolean _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		[Required]
		public int ProvinceID
		{
			get { return _provinceID; }
			set { _provinceID = value;
			      _isMapRecord = false;
			      _isSetProvinceID = true; }
		}
		public Boolean _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isMapRecord = false;
			      _isSetJFCaseTypeID = true; }
		}
		public Boolean _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		[Required]
		public int ChannelID
		{
			get { return _channelID; }
			set { _channelID = value;
			      _isMapRecord = false;
			      _isSetChannelID = true; }
		}
		public Boolean _IsSetChannelID
		{
			get { return _isSetChannelID; }
		}
		public int ReferenceCaseID
		{
			get
			{
				return _referenceCaseID;
			}
			set
			{
				_referenceCaseIDNull = false;
				_isSetReferenceCaseID = true;
				_referenceCaseID = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceCaseIDNull
		{
			get {
				 return _referenceCaseIDNull; }
			set { _referenceCaseIDNull = value; }
		}
		public Boolean _IsSetReferenceCaseID
		{
			get { return _isSetReferenceCaseID; }
		}
		public int ReferenceMSCID
		{
			get
			{
				return _referenceMSCID;
			}
			set
			{
				_referenceMSCIDNull = false;
				_isSetReferenceMSCID = true;
				_referenceMSCID = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceMSCIDNull
		{
			get {
				 return _referenceMSCIDNull; }
			set { _referenceMSCIDNull = value; }
		}
		public Boolean _IsSetReferenceMSCID
		{
			get { return _isSetReferenceMSCID; }
		}
		public string ReferenceMSCCODE
		{
			get
			{
				return _referenceMSCCODE;
			}
			set
			{
				_referenceMSCCODENull = false;
				_isSetReferenceMSCCODE = true;
				_referenceMSCCODE = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceMSCCODENull
		{
			get {
				 return _referenceMSCCODENull; }
			set { _referenceMSCCODENull = value; }
		}
		public Boolean _IsSetReferenceMSCCODE
		{
			get { return _isSetReferenceMSCCODE; }
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
		public DateTime RegisterDate
		{
			get
			{
				return _registerDate;
			}
			set
			{
				_registerDateNull = false;
				_isSetRegisterDate = true;
				_registerDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsRegisterDateNull
		{
			get {
				 return _registerDateNull; }
			set { _registerDateNull = value; }
		}
		public Boolean _IsSetRegisterDate
		{
			get { return _isSetRegisterDate; }
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
	public class CaseApplicationData
	{
		private int _caseID;
		private string _subject;
		private int _departmentId;
		private int _provinceID;
		private int _jFCaseTypeID;
		private int _channelID;
		private int _referenceCaseID;
		private int _referenceMSCID;
		private string _referenceMSCCODE;
		private DateTime _createDate;
		private DateTime _registerDate;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public int ChannelID
		{
			get{ return _channelID; }
			set{ _channelID = value; }
		}
		public int ReferenceCaseID
		{
			get{ return _referenceCaseID; }
			set{ _referenceCaseID = value; }
		}
		public int ReferenceMSCID
		{
			get{ return _referenceMSCID; }
			set{ _referenceMSCID = value; }
		}
		public string ReferenceMSCCODE
		{
			get{ return _referenceMSCCODE; }
			set{ _referenceMSCCODE = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public DateTime RegisterDate
		{
			get{ return _registerDate; }
			set{ _registerDate = value; }
		}
		public string RegisterDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApplicationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicationRow[] caseApplicationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicationItems : CaseApplicationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicationItems[] caseApplicationItems { get; set; }
	}
}

