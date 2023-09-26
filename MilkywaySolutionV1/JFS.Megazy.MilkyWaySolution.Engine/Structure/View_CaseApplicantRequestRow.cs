using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_CaseApplicantRequestRow
	{
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private int _referenceMSCID;
		private bool _isSetReferenceMSCID = false;
		private bool _referenceMSCIDNull = true;
		private string _referenceMSCCode;
		private bool _isSetReferenceMSCCode = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private string _subject;
		private bool _isSetSubject = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _gender;
		private bool _isSetGender = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _postCode;
		private bool _isSetPostCode = false;
		private string _cardID;
		private bool _isSetCardID = false;
		private bool _defactive;
		private bool _isSetDefactive = false;
		private bool _defactiveNull = true;
		private string _remark;
		private bool _isSetRemark = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private string _central;
		private bool _isSetCentral = false;
		private string _email;
		private bool _isSetEmail = false;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private bool _attachFileIDNull = true;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private int _channelID;
		private bool _isSetChannelID = false;
		private bool _channelIDNull = true;
		private string _channelName;
		private bool _isSetChannelName = false;
		private int _statusID;
		private bool _isSetStatusID = false;
		private bool _statusIDNull = true;
		private string _raceName;
		private bool _isSetRaceName = false;
		private string _religionName;
		private bool _isSetReligionName = false;
		private string _nationalityCode;
		private bool _isSetNationalityCode = false;
		private string _education;
		private bool _isSetEducation = false;
		private int _raceID;
		private bool _isSetRaceID = false;
		private bool _raceIDNull = true;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private int _educationLevel;
		private bool _isSetEducationLevel = false;
		private bool _educationLevelNull = true;
		private int _religionID;
		private bool _isSetReligionID = false;
		private bool _religionIDNull = true;
		private int _nationalityID;
		private bool _isSetNationalityID = false;
		private bool _nationalityIDNull = true;
		private bool _isAgree;
		private bool _isSetIsAgree = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _orgName;
		private bool _isSetOrgName = false;
		private int _memberID;
		private bool _isSetMemberID = false;
		private bool _memberIDNull = true;
		private string _memberFirstName;
		private bool _isSetMemberFirstName = false;
		private string _memberLastName;
		private bool _isSetMemberLastName = false;
		private string _fileGallery;
		private bool _isSetFileGallery = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
			}
		}
		public bool IsReferenceMSCIDNull
		{
			get {
				 return _referenceMSCIDNull; }
			set { _referenceMSCIDNull = value; }
		}
		public bool _IsSetReferenceMSCID
		{
			get { return _isSetReferenceMSCID; }
		}
		public string ReferenceMSCCode
		{
			get { return _referenceMSCCode; }
			set { _referenceMSCCode = value;
			      _isSetReferenceMSCCode = true; }
		}
		public bool _IsSetReferenceMSCCode
		{
			get { return _isSetReferenceMSCCode; }
		}
		public int DepartmentID
		{
			get
			{
				return _departmentId;
			}
			set
			{
				_departmentIdNull = false;
				_isSetDepartmentID = true;
				_departmentId = value;
			}
		}
		public bool IsDepartmentIDNull
		{
			get {
				 return _departmentIdNull; }
			set { _departmentIdNull = value; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		public string Subject
		{
			get { return _subject; }
			set { _subject = value;
			      _isSetSubject = true; }
		}
		public bool _IsSetSubject
		{
			get { return _isSetSubject; }
		}
		public string TelephoneNo
		{
			get { return _telephoneNo; }
			set { _telephoneNo = value;
			      _isSetTelephoneNo = true; }
		}
		public bool _IsSetTelephoneNo
		{
			get { return _isSetTelephoneNo; }
		}
		public string Gender
		{
			get { return _gender; }
			set { _gender = value;
			      _isSetGender = true; }
		}
		public bool _IsSetGender
		{
			get { return _isSetGender; }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value;
			      _isSetTitle = true; }
		}
		public bool _IsSetTitle
		{
			get { return _isSetTitle; }
		}
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value;
			      _isSetFirstName = true; }
		}
		public bool _IsSetFirstName
		{
			get { return _isSetFirstName; }
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value;
			      _isSetLastName = true; }
		}
		public bool _IsSetLastName
		{
			get { return _isSetLastName; }
		}
		public string PostCode
		{
			get { return _postCode; }
			set { _postCode = value;
			      _isSetPostCode = true; }
		}
		public bool _IsSetPostCode
		{
			get { return _isSetPostCode; }
		}
		public string CardID
		{
			get { return _cardID; }
			set { _cardID = value;
			      _isSetCardID = true; }
		}
		public bool _IsSetCardID
		{
			get { return _isSetCardID; }
		}
		public bool Defactive
		{
			get
			{
				return _defactive;
			}
			set
			{
				_defactiveNull = false;
				_isSetDefactive = true;
				_defactive = value;
			}
		}
		public bool IsDefactiveNull
		{
			get {
				 return _defactiveNull; }
			set { _defactiveNull = value; }
		}
		public bool _IsSetDefactive
		{
			get { return _isSetDefactive; }
		}
		public string Remark
		{
			get { return _remark; }
			set { _remark = value;
			      _isSetRemark = true; }
		}
		public bool _IsSetRemark
		{
			get { return _isSetRemark; }
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
			}
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
		public string Central
		{
			get { return _central; }
			set { _central = value;
			      _isSetCentral = true; }
		}
		public bool _IsSetCentral
		{
			get { return _isSetCentral; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value;
			      _isSetEmail = true; }
		}
		public bool _IsSetEmail
		{
			get { return _isSetEmail; }
		}
		public int AttachFileID
		{
			get
			{
				return _attachFileID;
			}
			set
			{
				_attachFileIDNull = false;
				_isSetAttachFileID = true;
				_attachFileID = value;
			}
		}
		public bool IsAttachFileIDNull
		{
			get {
				 return _attachFileIDNull; }
			set { _attachFileIDNull = value; }
		}
		public bool _IsSetAttachFileID
		{
			get { return _isSetAttachFileID; }
		}
		public int AddressID
		{
			get
			{
				return _addressID;
			}
			set
			{
				_addressIDNull = false;
				_isSetAddressID = true;
				_addressID = value;
			}
		}
		public bool IsAddressIDNull
		{
			get {
				 return _addressIDNull; }
			set { _addressIDNull = value; }
		}
		public bool _IsSetAddressID
		{
			get { return _isSetAddressID; }
		}
		public int ChannelID
		{
			get
			{
				return _channelID;
			}
			set
			{
				_channelIDNull = false;
				_isSetChannelID = true;
				_channelID = value;
			}
		}
		public bool IsChannelIDNull
		{
			get {
				 return _channelIDNull; }
			set { _channelIDNull = value; }
		}
		public bool _IsSetChannelID
		{
			get { return _isSetChannelID; }
		}
		public string ChannelName
		{
			get { return _channelName; }
			set { _channelName = value;
			      _isSetChannelName = true; }
		}
		public bool _IsSetChannelName
		{
			get { return _isSetChannelName; }
		}
		public int StatusID
		{
			get
			{
				return _statusID;
			}
			set
			{
				_statusIDNull = false;
				_isSetStatusID = true;
				_statusID = value;
			}
		}
		public bool IsStatusIDNull
		{
			get {
				 return _statusIDNull; }
			set { _statusIDNull = value; }
		}
		public bool _IsSetStatusID
		{
			get { return _isSetStatusID; }
		}
		public string RaceName
		{
			get { return _raceName; }
			set { _raceName = value;
			      _isSetRaceName = true; }
		}
		public bool _IsSetRaceName
		{
			get { return _isSetRaceName; }
		}
		public string ReligionName
		{
			get { return _religionName; }
			set { _religionName = value;
			      _isSetReligionName = true; }
		}
		public bool _IsSetReligionName
		{
			get { return _isSetReligionName; }
		}
		public string NationalityCode
		{
			get { return _nationalityCode; }
			set { _nationalityCode = value;
			      _isSetNationalityCode = true; }
		}
		public bool _IsSetNationalityCode
		{
			get { return _isSetNationalityCode; }
		}
		public string Education
		{
			get { return _education; }
			set { _education = value;
			      _isSetEducation = true; }
		}
		public bool _IsSetEducation
		{
			get { return _isSetEducation; }
		}
		public int RaceID
		{
			get
			{
				return _raceID;
			}
			set
			{
				_raceIDNull = false;
				_isSetRaceID = true;
				_raceID = value;
			}
		}
		public bool IsRaceIDNull
		{
			get {
				 return _raceIDNull; }
			set { _raceIDNull = value; }
		}
		public bool _IsSetRaceID
		{
			get { return _isSetRaceID; }
		}
		public DateTime DateOfBirth
		{
			get
			{
				return _dateOfBirth;
			}
			set
			{
				_dateOfBirthNull = false;
				_isSetDateOfBirth = true;
				_dateOfBirth = value;
			}
		}
		public bool IsDateOfBirthNull
		{
			get {
				 return _dateOfBirthNull; }
			set { _dateOfBirthNull = value; }
		}
		public bool _IsSetDateOfBirth
		{
			get { return _isSetDateOfBirth; }
		}
		public int EducationLevel
		{
			get
			{
				return _educationLevel;
			}
			set
			{
				_educationLevelNull = false;
				_isSetEducationLevel = true;
				_educationLevel = value;
			}
		}
		public bool IsEducationLevelNull
		{
			get {
				 return _educationLevelNull; }
			set { _educationLevelNull = value; }
		}
		public bool _IsSetEducationLevel
		{
			get { return _isSetEducationLevel; }
		}
		public int ReligionID
		{
			get
			{
				return _religionID;
			}
			set
			{
				_religionIDNull = false;
				_isSetReligionID = true;
				_religionID = value;
			}
		}
		public bool IsReligionIDNull
		{
			get {
				 return _religionIDNull; }
			set { _religionIDNull = value; }
		}
		public bool _IsSetReligionID
		{
			get { return _isSetReligionID; }
		}
		public int NationalityID
		{
			get
			{
				return _nationalityID;
			}
			set
			{
				_nationalityIDNull = false;
				_isSetNationalityID = true;
				_nationalityID = value;
			}
		}
		public bool IsNationalityIDNull
		{
			get {
				 return _nationalityIDNull; }
			set { _nationalityIDNull = value; }
		}
		public bool _IsSetNationalityID
		{
			get { return _isSetNationalityID; }
		}
		[Required]
		public bool IsAgree
		{
			get { return _isAgree; }
			set { _isAgree = value;
			      _isSetIsAgree = true; }
		}
		public bool _IsSetIsAgree
		{
			get { return _isSetIsAgree; }
		}
		public string DepartmentName
		{
			get { return _departmentName; }
			set { _departmentName = value;
			      _isSetDepartmentName = true; }
		}
		public bool _IsSetDepartmentName
		{
			get { return _isSetDepartmentName; }
		}
		public int ProvinceID
		{
			get
			{
				return _provinceID;
			}
			set
			{
				_provinceIDNull = false;
				_isSetProvinceID = true;
				_provinceID = value;
			}
		}
		public bool IsProvinceIDNull
		{
			get {
				 return _provinceIDNull; }
			set { _provinceIDNull = value; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		public string ProvinceName
		{
			get { return _provinceName; }
			set { _provinceName = value;
			      _isSetProvinceName = true; }
		}
		public bool _IsSetProvinceName
		{
			get { return _isSetProvinceName; }
		}
		public string OrgName
		{
			get { return _orgName; }
			set { _orgName = value;
			      _isSetOrgName = true; }
		}
		public bool _IsSetOrgName
		{
			get { return _isSetOrgName; }
		}
		public int MemberID
		{
			get
			{
				return _memberID;
			}
			set
			{
				_memberIDNull = false;
				_isSetMemberID = true;
				_memberID = value;
			}
		}
		public bool IsMemberIDNull
		{
			get {
				 return _memberIDNull; }
			set { _memberIDNull = value; }
		}
		public bool _IsSetMemberID
		{
			get { return _isSetMemberID; }
		}
		public string MemberFirstName
		{
			get { return _memberFirstName; }
			set { _memberFirstName = value;
			      _isSetMemberFirstName = true; }
		}
		public bool _IsSetMemberFirstName
		{
			get { return _isSetMemberFirstName; }
		}
		public string MemberLastName
		{
			get { return _memberLastName; }
			set { _memberLastName = value;
			      _isSetMemberLastName = true; }
		}
		public bool _IsSetMemberLastName
		{
			get { return _isSetMemberLastName; }
		}
		public string FileGallery
		{
			get { return _fileGallery; }
			set { _fileGallery = value;
			      _isSetFileGallery = true; }
		}
		public bool _IsSetFileGallery
		{
			get { return _isSetFileGallery; }
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
	public class View_CaseApplicantRequestData
	{
		private int _transactionID;
		private int _referenceMSCID;
		private string _referenceMSCCode;
		private int _departmentId;
		private string _subject;
		private string _telephoneNo;
		private string _gender;
		private string _title;
		private string _firstName;
		private string _lastName;
		private string _postCode;
		private string _cardID;
		private bool _defactive;
		private string _remark;
		private DateTime _createDate;
		private string _central;
		private string _email;
		private int _attachFileID;
		private int _addressID;
		private int _channelID;
		private string _channelName;
		private int _statusID;
		private string _raceName;
		private string _religionName;
		private string _nationalityCode;
		private string _education;
		private int _raceID;
		private DateTime _dateOfBirth;
		private int _educationLevel;
		private int _religionID;
		private int _nationalityID;
		private bool _isAgree;
		private string _departmentName;
		private int _provinceID;
		private string _provinceName;
		private string _orgName;
		private int _memberID;
		private string _memberFirstName;
		private string _memberLastName;
		private string _fileGallery;
		private DateTime _modifiedDate;
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public int ReferenceMSCID
		{
			get{ return _referenceMSCID; }
			set{ _referenceMSCID = value; }
		}
		public string ReferenceMSCCode
		{
			get{ return _referenceMSCCode; }
			set{ _referenceMSCCode = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
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
		public string PostCode
		{
			get{ return _postCode; }
			set{ _postCode = value; }
		}
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public bool Defactive
		{
			get{ return _defactive; }
			set{ _defactive = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string CreateDateStr { get; set; }
		public string Central
		{
			get{ return _central; }
			set{ _central = value; }
		}
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public int ChannelID
		{
			get{ return _channelID; }
			set{ _channelID = value; }
		}
		public string ChannelName
		{
			get{ return _channelName; }
			set{ _channelName = value; }
		}
		public int StatusID
		{
			get{ return _statusID; }
			set{ _statusID = value; }
		}
		public string RaceName
		{
			get{ return _raceName; }
			set{ _raceName = value; }
		}
		public string ReligionName
		{
			get{ return _religionName; }
			set{ _religionName = value; }
		}
		public string NationalityCode
		{
			get{ return _nationalityCode; }
			set{ _nationalityCode = value; }
		}
		public string Education
		{
			get{ return _education; }
			set{ _education = value; }
		}
		public int RaceID
		{
			get{ return _raceID; }
			set{ _raceID = value; }
		}
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string DateOfBirthStr { get; set; }
		public int EducationLevel
		{
			get{ return _educationLevel; }
			set{ _educationLevel = value; }
		}
		public int ReligionID
		{
			get{ return _religionID; }
			set{ _religionID = value; }
		}
		public int NationalityID
		{
			get{ return _nationalityID; }
			set{ _nationalityID = value; }
		}
		public bool IsAgree
		{
			get{ return _isAgree; }
			set{ _isAgree = value; }
		}
		public string DepartmentName
		{
			get{ return _departmentName; }
			set{ _departmentName = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		public string OrgName
		{
			get{ return _orgName; }
			set{ _orgName = value; }
		}
		public int MemberID
		{
			get{ return _memberID; }
			set{ _memberID = value; }
		}
		public string MemberFirstName
		{
			get{ return _memberFirstName; }
			set{ _memberFirstName = value; }
		}
		public string MemberLastName
		{
			get{ return _memberLastName; }
			set{ _memberLastName = value; }
		}
		public string FileGallery
		{
			get{ return _fileGallery; }
			set{ _fileGallery = value; }
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
	public class View_CaseApplicantRequestPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseApplicantRequestRow[] view_CaseApplicantRequestRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseApplicantRequestItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseApplicantRequestItems : View_CaseApplicantRequestData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseApplicantRequestItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseApplicantRequestItems[] view_CaseApplicantRequestItems { get; set; }
	}
}

