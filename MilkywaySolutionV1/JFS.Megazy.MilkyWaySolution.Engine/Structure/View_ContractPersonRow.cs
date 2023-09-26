using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ContractPersonRow
	{
		private int _contractID;
		private bool _isSetContractID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private string _contractNo;
		private bool _isSetContractNo = false;
		private DateTime _contractDate;
		private bool _isSetContractDate = false;
		private bool _contractDateNull = true;
		private string _contractNote;
		private bool _isSetContractNote = false;
		private int _personID;
		private bool _isSetPersonID = false;
		private int _roleID;
		private bool _isSetRoleID = false;
		private bool _roleIDNull = true;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private string _address1;
		private bool _isSetAddress1 = false;
		private string _houseNo;
		private bool _isSetHouseNo = false;
		private string _villageNo;
		private bool _isSetVillageNo = false;
		private string _soi;
		private bool _isSetSoi = false;
		private string _street;
		private bool _isSetStreet = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private string _provinceName;
		private bool _isSetProvinceName = false;
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
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _roleName;
		private bool _isSetRoleName = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private int _age;
		private bool _isSetAge = false;
		private bool _ageNull = true;
		private string _genderCode;
		private bool _isSetGenderCode = false;
		private string _cardID;
		private bool _isSetCardID = false;
		private string _relate;
		private bool _isSetRelate = false;
		private string _position;
		private bool _isSetPosition = false;
		private int _formID;
		private bool _isSetFormID = false;
		private string _issuedAt;
		private bool _isSetIssuedAt = false;
		private int _raceID;
		private bool _isSetRaceID = false;
		private bool _raceIDNull = true;
		private int _nationalityID;
		private bool _isSetNationalityID = false;
		private bool _nationalityIDNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		[Required]
		public int ContractID
		{
			get { return _contractID; }
			set { _contractID = value;
			      _isSetContractID = true; }
		}
		public bool _IsSetContractID
		{
			get { return _isSetContractID; }
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
			}
		}
		public bool IsCaseIDNull
		{
			get {
				 return _caseIDNull; }
			set { _caseIDNull = value; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public int ApplicantID
		{
			get
			{
				return _applicantID;
			}
			set
			{
				_applicantIDNull = false;
				_isSetApplicantID = true;
				_applicantID = value;
			}
		}
		public bool IsApplicantIDNull
		{
			get {
				 return _applicantIDNull; }
			set { _applicantIDNull = value; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public string ContractNo
		{
			get { return _contractNo; }
			set { _contractNo = value;
			      _isSetContractNo = true; }
		}
		public bool _IsSetContractNo
		{
			get { return _isSetContractNo; }
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
		public string ContractNote
		{
			get { return _contractNote; }
			set { _contractNote = value;
			      _isSetContractNote = true; }
		}
		public bool _IsSetContractNote
		{
			get { return _isSetContractNote; }
		}
		[Required]
		public int PersonID
		{
			get { return _personID; }
			set { _personID = value;
			      _isSetPersonID = true; }
		}
		public bool _IsSetPersonID
		{
			get { return _isSetPersonID; }
		}
		public int RoleID
		{
			get
			{
				return _roleID;
			}
			set
			{
				_roleIDNull = false;
				_isSetRoleID = true;
				_roleID = value;
			}
		}
		public bool IsRoleIDNull
		{
			get {
				 return _roleIDNull; }
			set { _roleIDNull = value; }
		}
		public bool _IsSetRoleID
		{
			get { return _isSetRoleID; }
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
		public string Soi
		{
			get { return _soi; }
			set { _soi = value;
			      _isSetSoi = true; }
		}
		public bool _IsSetSoi
		{
			get { return _isSetSoi; }
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
		public string RoleName
		{
			get { return _roleName; }
			set { _roleName = value;
			      _isSetRoleName = true; }
		}
		public bool _IsSetRoleName
		{
			get { return _isSetRoleName; }
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
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_ageNull = false;
				_isSetAge = true;
				_age = value;
			}
		}
		public bool IsAgeNull
		{
			get {
				 return _ageNull; }
			set { _ageNull = value; }
		}
		public bool _IsSetAge
		{
			get { return _isSetAge; }
		}
		public string GenderCode
		{
			get { return _genderCode; }
			set { _genderCode = value;
			      _isSetGenderCode = true; }
		}
		public bool _IsSetGenderCode
		{
			get { return _isSetGenderCode; }
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
		public string Relate
		{
			get { return _relate; }
			set { _relate = value;
			      _isSetRelate = true; }
		}
		public bool _IsSetRelate
		{
			get { return _isSetRelate; }
		}
		public string Position
		{
			get { return _position; }
			set { _position = value;
			      _isSetPosition = true; }
		}
		public bool _IsSetPosition
		{
			get { return _isSetPosition; }
		}
		[Required]
		public int FormID
		{
			get { return _formID; }
			set { _formID = value;
			      _isSetFormID = true; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
		public string IssuedAt
		{
			get { return _issuedAt; }
			set { _issuedAt = value;
			      _isSetIssuedAt = true; }
		}
		public bool _IsSetIssuedAt
		{
			get { return _isSetIssuedAt; }
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
	}
	[Serializable]
	public class View_ContractPersonData
	{
		private int _contractID;
		private int _caseID;
		private int _applicantID;
		private string _contractNo;
		private DateTime _contractDate;
		private string _contractNote;
		private int _personID;
		private int _roleID;
		private int _addressID;
		private string _address1;
		private string _houseNo;
		private string _villageNo;
		private string _soi;
		private string _street;
		private int _provinceID;
		private string _provinceName;
		private int _disctrictId;
		private string _districtName;
		private int _subdistrictID;
		private string _subdistrictName;
		private string _postCode;
		private string _telephoneNo;
		private string _roleName;
		private string _title;
		private string _firstName;
		private string _lastName;
		private DateTime _dateOfBirth;
		private int _age;
		private string _genderCode;
		private string _cardID;
		private string _relate;
		private string _position;
		private int _formID;
		private string _issuedAt;
		private int _raceID;
		private int _nationalityID;
		private int _departmentId;
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
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
		public string ContractNo
		{
			get{ return _contractNo; }
			set{ _contractNo = value; }
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
		public string ContractNote
		{
			get{ return _contractNote; }
			set{ _contractNote = value; }
		}
		public int PersonID
		{
			get{ return _personID; }
			set{ _personID = value; }
		}
		public int RoleID
		{
			get{ return _roleID; }
			set{ _roleID = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
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
		public string Soi
		{
			get{ return _soi; }
			set{ _soi = value; }
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
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public string RoleName
		{
			get{ return _roleName; }
			set{ _roleName = value; }
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
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string DateOfBirthStr { get; set; }
		public int Age
		{
			get{ return _age; }
			set{ _age = value; }
		}
		public string GenderCode
		{
			get{ return _genderCode; }
			set{ _genderCode = value; }
		}
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public string Relate
		{
			get{ return _relate; }
			set{ _relate = value; }
		}
		public string Position
		{
			get{ return _position; }
			set{ _position = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public string IssuedAt
		{
			get{ return _issuedAt; }
			set{ _issuedAt = value; }
		}
		public int RaceID
		{
			get{ return _raceID; }
			set{ _raceID = value; }
		}
		public int NationalityID
		{
			get{ return _nationalityID; }
			set{ _nationalityID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
	}
	[Serializable]
	public class View_ContractPersonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ContractPersonRow[] view_ContractPersonRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ContractPersonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ContractPersonItems : View_ContractPersonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ContractPersonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ContractPersonItems[] view_ContractPersonItems { get; set; }
	}
}

