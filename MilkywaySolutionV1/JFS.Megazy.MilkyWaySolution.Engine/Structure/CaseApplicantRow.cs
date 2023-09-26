using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private string _gender;
		private bool _isSetGender = false;
		private bool _genderNull = true;
		private string _title;
		private bool _isSetTitle = false;
		private bool _titleNull = true;
		private string _firstName;
		private bool _isSetFirstName = false;
		private bool _firstNameNull = true;
		private string _lastName;
		private bool _isSetLastName = false;
		private bool _lastNameNull = true;
		private double _requestAmount;
		private bool _isSetRequestAmount = false;
		private bool _requestAmountNull = true;
		private int _score;
		private bool _isSetScore = false;
		private bool _scoreNull = true;
		private bool _hasProxy;
		private bool _isSetHasProxy = false;
		private bool _hasProxyNull = true;
		private bool _deletedFlag;
		private bool _isSetDeletedFlag = false;
		private bool _deletedFlagNull = true;
		private int _userCreateCaseID;
		private bool _isSetUserCreateCaseID = false;
		private bool _userCreateCaseIDNull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
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
		public int CaseID
		{
			get
			{
				return _caseID;
			}
			set
			{
				_caseIDNull = false;
				_isSetCaseID = true;
				_caseID = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseIDNull
		{
			get {
				 return _caseIDNull; }
			set { _caseIDNull = value; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public string Gender
		{
			get
			{
				return _gender;
			}
			set
			{
				_genderNull = false;
				_isSetGender = true;
				_gender = value;
				_isMapRecord = false;
			}
		}
		public bool IsGenderNull
		{
			get {
				 return _genderNull; }
			set { _genderNull = value; }
		}
		public Boolean _IsSetGender
		{
			get { return _isSetGender; }
		}
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_titleNull = false;
				_isSetTitle = true;
				_title = value;
				_isMapRecord = false;
			}
		}
		public bool IsTitleNull
		{
			get {
				 return _titleNull; }
			set { _titleNull = value; }
		}
		public Boolean _IsSetTitle
		{
			get { return _isSetTitle; }
		}
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				_firstNameNull = false;
				_isSetFirstName = true;
				_firstName = value;
				_isMapRecord = false;
			}
		}
		public bool IsFirstNameNull
		{
			get {
				 return _firstNameNull; }
			set { _firstNameNull = value; }
		}
		public Boolean _IsSetFirstName
		{
			get { return _isSetFirstName; }
		}
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastNameNull = false;
				_isSetLastName = true;
				_lastName = value;
				_isMapRecord = false;
			}
		}
		public bool IsLastNameNull
		{
			get {
				 return _lastNameNull; }
			set { _lastNameNull = value; }
		}
		public Boolean _IsSetLastName
		{
			get { return _isSetLastName; }
		}
		public double RequestAmount
		{
			get
			{
				return _requestAmount;
			}
			set
			{
				_requestAmountNull = false;
				_isSetRequestAmount = true;
				_requestAmount = value;
				_isMapRecord = false;
			}
		}
		public bool IsRequestAmountNull
		{
			get {
				 return _requestAmountNull; }
			set { _requestAmountNull = value; }
		}
		public Boolean _IsSetRequestAmount
		{
			get { return _isSetRequestAmount; }
		}
		public int Score
		{
			get
			{
				return _score;
			}
			set
			{
				_scoreNull = false;
				_isSetScore = true;
				_score = value;
				_isMapRecord = false;
			}
		}
		public bool IsScoreNull
		{
			get {
				 return _scoreNull; }
			set { _scoreNull = value; }
		}
		public Boolean _IsSetScore
		{
			get { return _isSetScore; }
		}
		public bool HasProxy
		{
			get
			{
				return _hasProxy;
			}
			set
			{
				_hasProxyNull = false;
				_isSetHasProxy = true;
				_hasProxy = value;
				_isMapRecord = false;
			}
		}
		public bool IsHasProxyNull
		{
			get {
				 return _hasProxyNull; }
			set { _hasProxyNull = value; }
		}
		public Boolean _IsSetHasProxy
		{
			get { return _isSetHasProxy; }
		}
		public bool DeletedFlag
		{
			get
			{
				return _deletedFlag;
			}
			set
			{
				_deletedFlagNull = false;
				_isSetDeletedFlag = true;
				_deletedFlag = value;
				_isMapRecord = false;
			}
		}
		public bool IsDeletedFlagNull
		{
			get {
				 return _deletedFlagNull; }
			set { _deletedFlagNull = value; }
		}
		public Boolean _IsSetDeletedFlag
		{
			get { return _isSetDeletedFlag; }
		}
		public int UserCreateCaseID
		{
			get
			{
				return _userCreateCaseID;
			}
			set
			{
				_userCreateCaseIDNull = false;
				_isSetUserCreateCaseID = true;
				_userCreateCaseID = value;
				_isMapRecord = false;
			}
		}
		public bool IsUserCreateCaseIDNull
		{
			get {
				 return _userCreateCaseIDNull; }
			set { _userCreateCaseIDNull = value; }
		}
		public Boolean _IsSetUserCreateCaseID
		{
			get { return _isSetUserCreateCaseID; }
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
	public class CaseApplicantData
	{
		private int _applicantID;
		private int _caseID;
		private string _gender;
		private string _title;
		private string _firstName;
		private string _lastName;
		private double _requestAmount;
		private int _score;
		private bool _hasProxy;
		private bool _deletedFlag;
		private int _userCreateCaseID;
		private DateTime _createDate;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
		}
		public string FirstName
		{
			get{ return _firstName; }
			set{ _firstName = value; }
		}
		public string LastName
		{
			get{ return _lastName; }
			set{ _lastName = value; }
		}
		public double RequestAmount
		{
			get{ return _requestAmount; }
			set{ _requestAmount = value; }
		}
		public int Score
		{
			get{ return _score; }
			set{ _score = value; }
		}
		public bool HasProxy
		{
			get{ return _hasProxy; }
			set{ _hasProxy = value; }
		}
		public bool DeletedFlag
		{
			get{ return _deletedFlag; }
			set{ _deletedFlag = value; }
		}
		public int UserCreateCaseID
		{
			get{ return _userCreateCaseID; }
			set{ _userCreateCaseID = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApplicantPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantRow[] caseApplicantRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantItems : CaseApplicantData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantItems[] caseApplicantItems { get; set; }
	}
}

