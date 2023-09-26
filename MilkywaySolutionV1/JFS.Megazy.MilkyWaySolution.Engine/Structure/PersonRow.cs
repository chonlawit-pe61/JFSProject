using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class PersonRow
	{
		private int _personID;
		private bool _isSetPersonID = false;
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
		private string _position;
		private bool _isSetPosition = false;
		private string _relate;
		private bool _isSetRelate = false;
		private int _religionID;
		private bool _isSetReligionID = false;
		private bool _religionIDNull = true;
		private int _nationalityID;
		private bool _isSetNationalityID = false;
		private bool _nationalityIDNull = true;
		private int _raceID;
		private bool _isSetRaceID = false;
		private bool _raceIDNull = true;
		private string _issuedAt;
		private bool _isSetIssuedAt = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	public class PersonData
	{
		private int _personID;
		private string _title;
		private string _firstName;
		private string _lastName;
		private DateTime _dateOfBirth;
		private int _age;
		private string _genderCode;
		private string _cardID;
		private string _position;
		private string _relate;
		private int _religionID;
		private int _nationalityID;
		private int _raceID;
		private string _issuedAt;
		private DateTime _modifiedDate;
		public int PersonID
		{
			get{ return _personID; }
			set{ _personID = value; }
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
		public string Position
		{
			get{ return _position; }
			set{ _position = value; }
		}
		public string Relate
		{
			get{ return _relate; }
			set{ _relate = value; }
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
		public string IssuedAt
		{
			get{ return _issuedAt; }
			set{ _issuedAt = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class PersonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public PersonRow[] personRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส PersonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class PersonItems : PersonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class PersonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public PersonItems[] personItems { get; set; }
	}
}

