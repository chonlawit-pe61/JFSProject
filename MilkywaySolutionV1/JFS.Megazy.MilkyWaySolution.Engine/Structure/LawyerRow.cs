using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerRow
	{
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _lawyerTypeID;
		private bool _isSetLawyerTypeID = false;
		private bool _lawyerTypeIDNull = true;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _cardID;
		private bool _isSetCardID = false;
		private string _gender;
		private bool _isSetGender = false;
		private string _licenseNo;
		private bool _isSetLicenseNo = false;
		private string _licenseType;
		private bool _isSetLicenseType = false;
		private DateTime _issueDate;
		private bool _isSetIssueDate = false;
		private bool _issueDateNull = true;
		private DateTime _exprieDate;
		private bool _isSetExprieDate = false;
		private bool _exprieDateNull = true;
		private string _email;
		private bool _isSetEmail = false;
		private string _mobileNo;
		private bool _isSetMobileNo = false;
		private string _education;
		private bool _isSetEducation = false;
		private string _remark;
		private bool _isSetRemark = false;
		private int _numberOfConductCase;
		private bool _isSetNumberOfConductCase = false;
		private bool _numberOfConductCaseNull = true;
		private int _yearsExperience;
		private bool _isSetYearsExperience = false;
		private bool _yearsExperienceNull = true;
		private DateTime _registerDate;
		private bool _isSetRegisterDate = false;
		private bool _registerDateNull = true;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private int _lawyerStatusID;
		private bool _isSetLawyerStatusID = false;
		private bool _lawyerStatusIDNull = true;
		[Required]
		public int LawyerID
		{
			get { return _lawyerID; }
			set { _lawyerID = value;
			      _isSetLawyerID = true; }
		}
		public bool _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
		}
		public int LawyerTypeID
		{
			get
			{
				return _lawyerTypeID;
			}
			set
			{
				_lawyerTypeIDNull = false;
				_isSetLawyerTypeID = true;
				_lawyerTypeID = value;
			}
		}
		public bool IsLawyerTypeIDNull
		{
			get {
				 return _lawyerTypeIDNull; }
			set { _lawyerTypeIDNull = value; }
		}
		public bool _IsSetLawyerTypeID
		{
			get { return _isSetLawyerTypeID; }
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
		public string LicenseNo
		{
			get { return _licenseNo; }
			set { _licenseNo = value;
			      _isSetLicenseNo = true; }
		}
		public bool _IsSetLicenseNo
		{
			get { return _isSetLicenseNo; }
		}
		public string LicenseType
		{
			get { return _licenseType; }
			set { _licenseType = value;
			      _isSetLicenseType = true; }
		}
		public bool _IsSetLicenseType
		{
			get { return _isSetLicenseType; }
		}
		public DateTime IssueDate
		{
			get
			{
				return _issueDate;
			}
			set
			{
				_issueDateNull = false;
				_isSetIssueDate = true;
				_issueDate = value;
			}
		}
		public bool IsIssueDateNull
		{
			get {
				 return _issueDateNull; }
			set { _issueDateNull = value; }
		}
		public bool _IsSetIssueDate
		{
			get { return _isSetIssueDate; }
		}
		public DateTime ExprieDate
		{
			get
			{
				return _exprieDate;
			}
			set
			{
				_exprieDateNull = false;
				_isSetExprieDate = true;
				_exprieDate = value;
			}
		}
		public bool IsExprieDateNull
		{
			get {
				 return _exprieDateNull; }
			set { _exprieDateNull = value; }
		}
		public bool _IsSetExprieDate
		{
			get { return _isSetExprieDate; }
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
		public string MobileNo
		{
			get { return _mobileNo; }
			set { _mobileNo = value;
			      _isSetMobileNo = true; }
		}
		public bool _IsSetMobileNo
		{
			get { return _isSetMobileNo; }
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
		public int NumberOfConductCase
		{
			get
			{
				return _numberOfConductCase;
			}
			set
			{
				_numberOfConductCaseNull = false;
				_isSetNumberOfConductCase = true;
				_numberOfConductCase = value;
			}
		}
		public bool IsNumberOfConductCaseNull
		{
			get {
				 return _numberOfConductCaseNull; }
			set { _numberOfConductCaseNull = value; }
		}
		public bool _IsSetNumberOfConductCase
		{
			get { return _isSetNumberOfConductCase; }
		}
		public int YearsExperience
		{
			get
			{
				return _yearsExperience;
			}
			set
			{
				_yearsExperienceNull = false;
				_isSetYearsExperience = true;
				_yearsExperience = value;
			}
		}
		public bool IsYearsExperienceNull
		{
			get {
				 return _yearsExperienceNull; }
			set { _yearsExperienceNull = value; }
		}
		public bool _IsSetYearsExperience
		{
			get { return _isSetYearsExperience; }
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
			}
		}
		public bool IsRegisterDateNull
		{
			get {
				 return _registerDateNull; }
			set { _registerDateNull = value; }
		}
		public bool _IsSetRegisterDate
		{
			get { return _isSetRegisterDate; }
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
		public int LawyerStatusID
		{
			get
			{
				return _lawyerStatusID;
			}
			set
			{
				_lawyerStatusIDNull = false;
				_isSetLawyerStatusID = true;
				_lawyerStatusID = value;
			}
		}
		public bool IsLawyerStatusIDNull
		{
			get {
				 return _lawyerStatusIDNull; }
			set { _lawyerStatusIDNull = value; }
		}
		public bool _IsSetLawyerStatusID
		{
			get { return _isSetLawyerStatusID; }
		}
	}
	[Serializable]
	public class LawyerData
	{
		private int _lawyerID;
		private int _lawyerTypeID;
		private string _title;
		private string _firstName;
		private string _lastName;
		private string _cardID;
		private string _gender;
		private string _licenseNo;
		private string _licenseType;
		private DateTime _issueDate;
		private DateTime _exprieDate;
		private string _email;
		private string _mobileNo;
		private string _education;
		private string _remark;
		private int _numberOfConductCase;
		private int _yearsExperience;
		private DateTime _registerDate;
		private DateTime _dateOfBirth;
		private DateTime _modifiedDate;
		private int _lawyerStatusID;
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public int LawyerTypeID
		{
			get{ return _lawyerTypeID; }
			set{ _lawyerTypeID = value; }
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
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		public string LicenseNo
		{
			get{ return _licenseNo; }
			set{ _licenseNo = value; }
		}
		public string LicenseType
		{
			get{ return _licenseType; }
			set{ _licenseType = value; }
		}
		public DateTime IssueDate
		{
			get{ return _issueDate; }
			set{ _issueDate = value; }
		}
		public string IssueDateStr { get; set; }
		public DateTime ExprieDate
		{
			get{ return _exprieDate; }
			set{ _exprieDate = value; }
		}
		public string ExprieDateStr { get; set; }
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public string MobileNo
		{
			get{ return _mobileNo; }
			set{ _mobileNo = value; }
		}
		public string Education
		{
			get{ return _education; }
			set{ _education = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
		public int NumberOfConductCase
		{
			get{ return _numberOfConductCase; }
			set{ _numberOfConductCase = value; }
		}
		public int YearsExperience
		{
			get{ return _yearsExperience; }
			set{ _yearsExperience = value; }
		}
		public DateTime RegisterDate
		{
			get{ return _registerDate; }
			set{ _registerDate = value; }
		}
		public string RegisterDateStr { get; set; }
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		public string DateOfBirthStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public int LawyerStatusID
		{
			get{ return _lawyerStatusID; }
			set{ _lawyerStatusID = value; }
		}
	}
	[Serializable]
	public class LawyerPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerRow[] lawyerRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerItems : LawyerData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerItems[] lawyerItems { get; set; }
	}
}

