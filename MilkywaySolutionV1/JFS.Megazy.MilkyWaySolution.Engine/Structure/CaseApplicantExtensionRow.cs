using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantExtensionRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _cardID;
		private bool _isSetCardID = false;
		private bool _cardIDNull = true;
		private int _cardType;
		private bool _isSetCardType = false;
		private bool _cardTypeNull = true;
		private string _gender;
		private bool _isSetGender = false;
		private bool _genderNull = true;
		private int _age;
		private bool _isSetAge = false;
		private bool _ageNull = true;
		private string _issuedAt;
		private bool _isSetIssuedAt = false;
		private bool _issuedAtNull = true;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private int _raceID;
		private bool _isSetRaceID = false;
		private bool _raceIDNull = true;
		private int _religionID;
		private bool _isSetReligionID = false;
		private bool _religionIDNull = true;
		private int _nationalityID;
		private bool _isSetNationalityID = false;
		private bool _nationalityIDNull = true;
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
		public string CardID
		{
			get
			{
				return _cardID;
			}
			set
			{
				_cardIDNull = false;
				_isSetCardID = true;
				_cardID = value;
				_isMapRecord = false;
			}
		}
		public bool IsCardIDNull
		{
			get {
				 return _cardIDNull; }
			set { _cardIDNull = value; }
		}
		public Boolean _IsSetCardID
		{
			get { return _isSetCardID; }
		}
		public int CardType
		{
			get
			{
				return _cardType;
			}
			set
			{
				_cardTypeNull = false;
				_isSetCardType = true;
				_cardType = value;
				_isMapRecord = false;
			}
		}
		public bool IsCardTypeNull
		{
			get {
				 return _cardTypeNull; }
			set { _cardTypeNull = value; }
		}
		public Boolean _IsSetCardType
		{
			get { return _isSetCardType; }
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
				_isMapRecord = false;
			}
		}
		public bool IsAgeNull
		{
			get {
				 return _ageNull; }
			set { _ageNull = value; }
		}
		public Boolean _IsSetAge
		{
			get { return _isSetAge; }
		}
		public string IssuedAt
		{
			get
			{
				return _issuedAt;
			}
			set
			{
				_issuedAtNull = false;
				_isSetIssuedAt = true;
				_issuedAt = value;
				_isMapRecord = false;
			}
		}
		public bool IsIssuedAtNull
		{
			get {
				 return _issuedAtNull; }
			set { _issuedAtNull = value; }
		}
		public Boolean _IsSetIssuedAt
		{
			get { return _isSetIssuedAt; }
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
				_isMapRecord = false;
			}
		}
		public bool IsDateOfBirthNull
		{
			get {
				 return _dateOfBirthNull; }
			set { _dateOfBirthNull = value; }
		}
		public Boolean _IsSetDateOfBirth
		{
			get { return _isSetDateOfBirth; }
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
				_isMapRecord = false;
			}
		}
		public bool IsRaceIDNull
		{
			get {
				 return _raceIDNull; }
			set { _raceIDNull = value; }
		}
		public Boolean _IsSetRaceID
		{
			get { return _isSetRaceID; }
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
				_isMapRecord = false;
			}
		}
		public bool IsReligionIDNull
		{
			get {
				 return _religionIDNull; }
			set { _religionIDNull = value; }
		}
		public Boolean _IsSetReligionID
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
				_isMapRecord = false;
			}
		}
		public bool IsNationalityIDNull
		{
			get {
				 return _nationalityIDNull; }
			set { _nationalityIDNull = value; }
		}
		public Boolean _IsSetNationalityID
		{
			get { return _isSetNationalityID; }
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
	public class CaseApplicantExtensionData
	{
		private int _applicantID;
		private string _cardID;
		private int _cardType;
		private string _gender;
		private int _age;
		private string _issuedAt;
		private DateTime _dateOfBirth;
		private int _raceID;
		private int _religionID;
		private int _nationalityID;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public int CardType
		{
			get{ return _cardType; }
			set{ _cardType = value; }
		}
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		public int Age
		{
			get{ return _age; }
			set{ _age = value; }
		}
		public string IssuedAt
		{
			get{ return _issuedAt; }
			set{ _issuedAt = value; }
		}
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		public string DateOfBirthStr { get; set; }
		public int RaceID
		{
			get{ return _raceID; }
			set{ _raceID = value; }
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApplicantExtensionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantExtensionRow[] caseApplicantExtensionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantExtensionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantExtensionItems : CaseApplicantExtensionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantExtensionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantExtensionItems[] caseApplicantExtensionItems { get; set; }
	}
}

