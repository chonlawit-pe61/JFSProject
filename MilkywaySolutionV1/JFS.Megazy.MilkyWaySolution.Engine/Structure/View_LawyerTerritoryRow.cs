using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_LawyerTerritoryRow
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
		private string _lawyerStatusName;
		private bool _isSetLawyerStatusName = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private int _addressTypeID;
		private bool _isSetAddressTypeID = false;
		private bool _addressTypeIDNull = true;
		private string _faxNo;
		private bool _isSetFaxNo = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private bool _isPrimary;
		private bool _isSetIsPrimary = false;
		private bool _isPrimaryNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private string _address1;
		private bool _isSetAddress1 = false;
		private string _houseNo;
		private bool _isSetHouseNo = false;
		private string _villageNo;
		private bool _isSetVillageNo = false;
		private string _street;
		private bool _isSetStreet = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _lawyerProvinceName;
		private bool _isSetLawyerProvinceName = false;
		private int _disctrictId;
		private bool _isSetDisctrictID = false;
		private bool _disctrictIdNull = true;
		private string _districtName;
		private bool _isSetDistrictName = false;
		private int _subdistrictID;
		private bool _isSetSubdistrictID = false;
		private bool _subdistrictIDNull = true;
		private string _subdistrictName;
		private bool _isSetSubdistrictName = false;
		private string _postCode;
		private bool _isSetPostCode = false;
		private int _lawyerOfficeID;
		private bool _isSetLawyerOfficeID = false;
		private bool _lawyerOfficeIDNull = true;
		private string _lawyerFirmName;
		private bool _isSetLawyerFirmName = false;
		private string _firmelephoneNo;
		private bool _isSetFirmelephoneNo = false;
		private string _firmfaxNo;
		private bool _isSetFirmFaxNo = false;
		private string _firmEmail;
		private bool _isSetFirmEmail = false;
		private bool _firmIsActive;
		private bool _isSetFirmIsActive = false;
		private bool _firmIsActiveNull = true;
		private string _lawyerTypeName;
		private bool _isSetLawyerTypeName = false;
		private int _numberOfContract;
		private bool _isSetNumberOfContract = false;
		private int _territoryProvinceID;
		private bool _isSetTerritoryProvinceID = false;
		private string _teritoryProvinceName;
		private bool _isSetTeritoryProvinceName = false;
		private DateTime _contractDate;
		private bool _isSetContractDate = false;
		private bool _contractDateNull = true;
		private string _caseType;
		private bool _isSetCaseType = false;
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
		public string LawyerStatusName
		{
			get { return _lawyerStatusName; }
			set { _lawyerStatusName = value;
			      _isSetLawyerStatusName = true; }
		}
		public bool _IsSetLawyerStatusName
		{
			get { return _isSetLawyerStatusName; }
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
		public int AddressTypeID
		{
			get
			{
				return _addressTypeID;
			}
			set
			{
				_addressTypeIDNull = false;
				_isSetAddressTypeID = true;
				_addressTypeID = value;
			}
		}
		public bool IsAddressTypeIDNull
		{
			get {
				 return _addressTypeIDNull; }
			set { _addressTypeIDNull = value; }
		}
		public bool _IsSetAddressTypeID
		{
			get { return _isSetAddressTypeID; }
		}
		public string FaxNo
		{
			get { return _faxNo; }
			set { _faxNo = value;
			      _isSetFaxNo = true; }
		}
		public bool _IsSetFaxNo
		{
			get { return _isSetFaxNo; }
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
		public bool IsPrimary
		{
			get
			{
				return _isPrimary;
			}
			set
			{
				_isPrimaryNull = false;
				_isSetIsPrimary = true;
				_isPrimary = value;
			}
		}
		public bool IsIsPrimaryNull
		{
			get {
				 return _isPrimaryNull; }
			set { _isPrimaryNull = value; }
		}
		public bool _IsSetIsPrimary
		{
			get { return _isSetIsPrimary; }
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
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public string Address1
		{
			get { return _address1; }
			set { _address1 = value;
			      _isSetAddress1 = true; }
		}
		public bool _IsSetAddress1
		{
			get { return _isSetAddress1; }
		}
		public string HouseNo
		{
			get { return _houseNo; }
			set { _houseNo = value;
			      _isSetHouseNo = true; }
		}
		public bool _IsSetHouseNo
		{
			get { return _isSetHouseNo; }
		}
		public string VillageNo
		{
			get { return _villageNo; }
			set { _villageNo = value;
			      _isSetVillageNo = true; }
		}
		public bool _IsSetVillageNo
		{
			get { return _isSetVillageNo; }
		}
		public string Street
		{
			get { return _street; }
			set { _street = value;
			      _isSetStreet = true; }
		}
		public bool _IsSetStreet
		{
			get { return _isSetStreet; }
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
		public string LawyerProvinceName
		{
			get { return _lawyerProvinceName; }
			set { _lawyerProvinceName = value;
			      _isSetLawyerProvinceName = true; }
		}
		public bool _IsSetLawyerProvinceName
		{
			get { return _isSetLawyerProvinceName; }
		}
		public int DisctrictID
		{
			get
			{
				return _disctrictId;
			}
			set
			{
				_disctrictIdNull = false;
				_isSetDisctrictID = true;
				_disctrictId = value;
			}
		}
		public bool IsDisctrictIDNull
		{
			get {
				 return _disctrictIdNull; }
			set { _disctrictIdNull = value; }
		}
		public bool _IsSetDisctrictID
		{
			get { return _isSetDisctrictID; }
		}
		public string DistrictName
		{
			get { return _districtName; }
			set { _districtName = value;
			      _isSetDistrictName = true; }
		}
		public bool _IsSetDistrictName
		{
			get { return _isSetDistrictName; }
		}
		public int SubdistrictID
		{
			get
			{
				return _subdistrictID;
			}
			set
			{
				_subdistrictIDNull = false;
				_isSetSubdistrictID = true;
				_subdistrictID = value;
			}
		}
		public bool IsSubdistrictIDNull
		{
			get {
				 return _subdistrictIDNull; }
			set { _subdistrictIDNull = value; }
		}
		public bool _IsSetSubdistrictID
		{
			get { return _isSetSubdistrictID; }
		}
		public string SubdistrictName
		{
			get { return _subdistrictName; }
			set { _subdistrictName = value;
			      _isSetSubdistrictName = true; }
		}
		public bool _IsSetSubdistrictName
		{
			get { return _isSetSubdistrictName; }
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
		public int LawyerOfficeID
		{
			get
			{
				return _lawyerOfficeID;
			}
			set
			{
				_lawyerOfficeIDNull = false;
				_isSetLawyerOfficeID = true;
				_lawyerOfficeID = value;
			}
		}
		public bool IsLawyerOfficeIDNull
		{
			get {
				 return _lawyerOfficeIDNull; }
			set { _lawyerOfficeIDNull = value; }
		}
		public bool _IsSetLawyerOfficeID
		{
			get { return _isSetLawyerOfficeID; }
		}
		public string LawyerFirmName
		{
			get { return _lawyerFirmName; }
			set { _lawyerFirmName = value;
			      _isSetLawyerFirmName = true; }
		}
		public bool _IsSetLawyerFirmName
		{
			get { return _isSetLawyerFirmName; }
		}
		public string FirmelephoneNo
		{
			get { return _firmelephoneNo; }
			set { _firmelephoneNo = value;
			      _isSetFirmelephoneNo = true; }
		}
		public bool _IsSetFirmelephoneNo
		{
			get { return _isSetFirmelephoneNo; }
		}
		public string FirmFaxNo
		{
			get { return _firmfaxNo; }
			set { _firmfaxNo = value;
			      _isSetFirmFaxNo = true; }
		}
		public bool _IsSetFirmFaxNo
		{
			get { return _isSetFirmFaxNo; }
		}
		public string FirmEmail
		{
			get { return _firmEmail; }
			set { _firmEmail = value;
			      _isSetFirmEmail = true; }
		}
		public bool _IsSetFirmEmail
		{
			get { return _isSetFirmEmail; }
		}
		public bool FirmIsActive
		{
			get
			{
				return _firmIsActive;
			}
			set
			{
				_firmIsActiveNull = false;
				_isSetFirmIsActive = true;
				_firmIsActive = value;
			}
		}
		public bool IsFirmIsActiveNull
		{
			get {
				 return _firmIsActiveNull; }
			set { _firmIsActiveNull = value; }
		}
		public bool _IsSetFirmIsActive
		{
			get { return _isSetFirmIsActive; }
		}
		[Required]
		public string LawyerTypeName
		{
			get { return _lawyerTypeName; }
			set { _lawyerTypeName = value;
			      _isSetLawyerTypeName = true; }
		}
		public bool _IsSetLawyerTypeName
		{
			get { return _isSetLawyerTypeName; }
		}
		[Required]
		public int NumberOfContract
		{
			get { return _numberOfContract; }
			set { _numberOfContract = value;
			      _isSetNumberOfContract = true; }
		}
		public bool _IsSetNumberOfContract
		{
			get { return _isSetNumberOfContract; }
		}
		[Required]
		public int TerritoryProvinceID
		{
			get { return _territoryProvinceID; }
			set { _territoryProvinceID = value;
			      _isSetTerritoryProvinceID = true; }
		}
		public bool _IsSetTerritoryProvinceID
		{
			get { return _isSetTerritoryProvinceID; }
		}
		public string TeritoryProvinceName
		{
			get { return _teritoryProvinceName; }
			set { _teritoryProvinceName = value;
			      _isSetTeritoryProvinceName = true; }
		}
		public bool _IsSetTeritoryProvinceName
		{
			get { return _isSetTeritoryProvinceName; }
		}
		public DateTime ContractDate
		{
			get
			{
				return _contractDate;
			}
			set
			{
				_contractDateNull = false;
				_isSetContractDate = true;
				_contractDate = value;
			}
		}
		public bool IsContractDateNull
		{
			get {
				 return _contractDateNull; }
			set { _contractDateNull = value; }
		}
		public bool _IsSetContractDate
		{
			get { return _isSetContractDate; }
		}
		public string CaseType
		{
			get { return _caseType; }
			set { _caseType = value;
			      _isSetCaseType = true; }
		}
		public bool _IsSetCaseType
		{
			get { return _isSetCaseType; }
		}
	}
	[Serializable]
	public class View_LawyerTerritoryData
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
		private string _lawyerStatusName;
		private int _addressID;
		private int _addressTypeID;
		private string _faxNo;
		private string _telephoneNo;
		private bool _isPrimary;
		private bool _isActive;
		private string _address1;
		private string _houseNo;
		private string _villageNo;
		private string _street;
		private int _provinceID;
		private string _provinceName;
		private string _lawyerProvinceName;
		private int _disctrictId;
		private string _districtName;
		private int _subdistrictID;
		private string _subdistrictName;
		private string _postCode;
		private int _lawyerOfficeID;
		private string _lawyerFirmName;
		private string _firmelephoneNo;
		private string _firmfaxNo;
		private string _firmEmail;
		private bool _firmIsActive;
		private string _lawyerTypeName;
		private int _numberOfContract;
		private int _territoryProvinceID;
		private string _teritoryProvinceName;
		private DateTime _contractDate;
		private string _caseType;
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
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string IssueDateStr { get; set; }
		public DateTime ExprieDate
		{
			get{ return _exprieDate; }
			set{ _exprieDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
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
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string RegisterDateStr { get; set; }
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string DateOfBirthStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
		public int LawyerStatusID
		{
			get{ return _lawyerStatusID; }
			set{ _lawyerStatusID = value; }
		}
		public string LawyerStatusName
		{
			get{ return _lawyerStatusName; }
			set{ _lawyerStatusName = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public int AddressTypeID
		{
			get{ return _addressTypeID; }
			set{ _addressTypeID = value; }
		}
		public string FaxNo
		{
			get{ return _faxNo; }
			set{ _faxNo = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public bool IsPrimary
		{
			get{ return _isPrimary; }
			set{ _isPrimary = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public string Address1
		{
			get{ return _address1; }
			set{ _address1 = value; }
		}
		public string HouseNo
		{
			get{ return _houseNo; }
			set{ _houseNo = value; }
		}
		public string VillageNo
		{
			get{ return _villageNo; }
			set{ _villageNo = value; }
		}
		public string Street
		{
			get{ return _street; }
			set{ _street = value; }
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
		public string LawyerProvinceName
		{
			get{ return _lawyerProvinceName; }
			set{ _lawyerProvinceName = value; }
		}
		public int DisctrictID
		{
			get{ return _disctrictId; }
			set{ _disctrictId = value; }
		}
		public string DistrictName
		{
			get{ return _districtName; }
			set{ _districtName = value; }
		}
		public int SubdistrictID
		{
			get{ return _subdistrictID; }
			set{ _subdistrictID = value; }
		}
		public string SubdistrictName
		{
			get{ return _subdistrictName; }
			set{ _subdistrictName = value; }
		}
		public string PostCode
		{
			get{ return _postCode; }
			set{ _postCode = value; }
		}
		public int LawyerOfficeID
		{
			get{ return _lawyerOfficeID; }
			set{ _lawyerOfficeID = value; }
		}
		public string LawyerFirmName
		{
			get{ return _lawyerFirmName; }
			set{ _lawyerFirmName = value; }
		}
		public string FirmelephoneNo
		{
			get{ return _firmelephoneNo; }
			set{ _firmelephoneNo = value; }
		}
		public string FirmFaxNo
		{
			get{ return _firmfaxNo; }
			set{ _firmfaxNo = value; }
		}
		public string FirmEmail
		{
			get{ return _firmEmail; }
			set{ _firmEmail = value; }
		}
		public bool FirmIsActive
		{
			get{ return _firmIsActive; }
			set{ _firmIsActive = value; }
		}
		public string LawyerTypeName
		{
			get{ return _lawyerTypeName; }
			set{ _lawyerTypeName = value; }
		}
		public int NumberOfContract
		{
			get{ return _numberOfContract; }
			set{ _numberOfContract = value; }
		}
		public int TerritoryProvinceID
		{
			get{ return _territoryProvinceID; }
			set{ _territoryProvinceID = value; }
		}
		public string TeritoryProvinceName
		{
			get{ return _teritoryProvinceName; }
			set{ _teritoryProvinceName = value; }
		}
		public DateTime ContractDate
		{
			get{ return _contractDate; }
			set{ _contractDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ContractDateStr { get; set; }
		public string CaseType
		{
			get{ return _caseType; }
			set{ _caseType = value; }
		}
	}
	[Serializable]
	public class View_LawyerTerritoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_LawyerTerritoryRow[] view_LawyerTerritoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_LawyerTerritoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_LawyerTerritoryItems : View_LawyerTerritoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_LawyerTerritoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_LawyerTerritoryItems[] view_LawyerTerritoryItems { get; set; }
	}
}

