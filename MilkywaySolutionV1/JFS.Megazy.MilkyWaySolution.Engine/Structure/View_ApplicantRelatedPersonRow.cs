using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ApplicantRelatedPersonRow
	{
		private int _contactPersonID;
		private bool _isSetContactPersonID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _personRoleID;
		private bool _isSetPersonRoleID = false;
		private bool _personRoleIDNull = true;
		private string _telephoneNumber;
		private bool _isSetTelephoneNumber = false;
		private string _email;
		private bool _isSetEmail = false;
		private string _relatedAs;
		private bool _isSetRelatedAs = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private string _personRoleName;
		private bool _isSetPersonRoleName = false;
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
		private int _religionID;
		private bool _isSetReligionID = false;
		private bool _religionIDNull = true;
		private int _nationalityID;
		private bool _isSetNationalityID = false;
		private bool _nationalityIDNull = true;
		private int _raceID;
		private bool _isSetRaceID = false;
		private bool _raceIDNull = true;
		private string _genderName;
		private bool _isSetGenderName = false;
		private string _nationalityname;
		private bool _isSetNationalityName = false;
		private string _raceName;
		private bool _isSetRaceName = false;
		private string _religionName;
		private bool _isSetReligionName = false;
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
		[Required]
		public int ContactPersonID
		{
			get { return _contactPersonID; }
			set { _contactPersonID = value;
			      _isSetContactPersonID = true; }
		}
		public bool _IsSetContactPersonID
		{
			get { return _isSetContactPersonID; }
		}
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
		public int PersonRoleID
		{
			get
			{
				return _personRoleID;
			}
			set
			{
				_personRoleIDNull = false;
				_isSetPersonRoleID = true;
				_personRoleID = value;
			}
		}
		public bool IsPersonRoleIDNull
		{
			get {
				 return _personRoleIDNull; }
			set { _personRoleIDNull = value; }
		}
		public bool _IsSetPersonRoleID
		{
			get { return _isSetPersonRoleID; }
		}
		public string TelephoneNumber
		{
			get { return _telephoneNumber; }
			set { _telephoneNumber = value;
			      _isSetTelephoneNumber = true; }
		}
		public bool _IsSetTelephoneNumber
		{
			get { return _isSetTelephoneNumber; }
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
		public string RelatedAs
		{
			get { return _relatedAs; }
			set { _relatedAs = value;
			      _isSetRelatedAs = true; }
		}
		public bool _IsSetRelatedAs
		{
			get { return _isSetRelatedAs; }
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
		public string PersonRoleName
		{
			get { return _personRoleName; }
			set { _personRoleName = value;
			      _isSetPersonRoleName = true; }
		}
		public bool _IsSetPersonRoleName
		{
			get { return _isSetPersonRoleName; }
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
		public string GenderName
		{
			get { return _genderName; }
			set { _genderName = value;
			      _isSetGenderName = true; }
		}
		public bool _IsSetGenderName
		{
			get { return _isSetGenderName; }
		}
		public string NationalityName
		{
			get { return _nationalityname; }
			set { _nationalityname = value;
			      _isSetNationalityName = true; }
		}
		public bool _IsSetNationalityName
		{
			get { return _isSetNationalityName; }
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
	}
	[Serializable]
	public class View_ApplicantRelatedPersonData
	{
		private int _contactPersonID;
		private int _caseID;
		private int _applicantID;
		private int _personRoleID;
		private string _telephoneNumber;
		private string _email;
		private string _relatedAs;
		private int _addressID;
		private string _personRoleName;
		private string _title;
		private string _firstName;
		private string _lastName;
		private DateTime _dateOfBirth;
		private int _age;
		private string _genderCode;
		private string _cardID;
		private int _religionID;
		private int _nationalityID;
		private int _raceID;
		private string _genderName;
		private string _nationalityname;
		private string _raceName;
		private string _religionName;
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
		public int ContactPersonID
		{
			get{ return _contactPersonID; }
			set{ _contactPersonID = value; }
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
		public int PersonRoleID
		{
			get{ return _personRoleID; }
			set{ _personRoleID = value; }
		}
		public string TelephoneNumber
		{
			get{ return _telephoneNumber; }
			set{ _telephoneNumber = value; }
		}
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public string RelatedAs
		{
			get{ return _relatedAs; }
			set{ _relatedAs = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public string PersonRoleName
		{
			get{ return _personRoleName; }
			set{ _personRoleName = value; }
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
		public int RaceID
		{
			get{ return _raceID; }
			set{ _raceID = value; }
		}
		public string GenderName
		{
			get{ return _genderName; }
			set{ _genderName = value; }
		}
		public string NationalityName
		{
			get{ return _nationalityname; }
			set{ _nationalityname = value; }
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
	}
	[Serializable]
	public class View_ApplicantRelatedPersonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ApplicantRelatedPersonRow[] view_ApplicantRelatedPersonRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ApplicantRelatedPersonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ApplicantRelatedPersonItems : View_ApplicantRelatedPersonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ApplicantRelatedPersonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ApplicantRelatedPersonItems[] view_ApplicantRelatedPersonItems { get; set; }
	}
}

