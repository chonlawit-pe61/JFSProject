using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ApplicantRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private double _requestAmount;
		private bool _isSetRequestAmount = false;
		private bool _requestAmountNull = true;
		private bool _hasProxy;
		private bool _isSetHasProxy = false;
		private bool _hasProxyNull = true;
		private string _gender;
		private bool _isSetGender = false;
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
		private string _cardID;
		private bool _isSetCardID = false;
		private int _cardType;
		private bool _isSetCardType = false;
		private bool _cardTypeNull = true;
		private int _score;
		private bool _isSetScore = false;
		private int _age;
		private bool _isSetAge = false;
		private bool _ageNull = true;
		private bool _deletedFlag;
		private bool _isSetDeletedFlag = false;
		private bool _deletedFlagNull = true;
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
			}
		}
		public bool IsRequestAmountNull
		{
			get {
				 return _requestAmountNull; }
			set { _requestAmountNull = value; }
		}
		public bool _IsSetRequestAmount
		{
			get { return _isSetRequestAmount; }
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
			}
		}
		public bool IsHasProxyNull
		{
			get {
				 return _hasProxyNull; }
			set { _hasProxyNull = value; }
		}
		public bool _IsSetHasProxy
		{
			get { return _isSetHasProxy; }
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
			}
		}
		public bool IsCardTypeNull
		{
			get {
				 return _cardTypeNull; }
			set { _cardTypeNull = value; }
		}
		public bool _IsSetCardType
		{
			get { return _isSetCardType; }
		}
		[Required]
		public int Score
		{
			get { return _score; }
			set { _score = value;
			      _isSetScore = true; }
		}
		public bool _IsSetScore
		{
			get { return _isSetScore; }
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
			}
		}
		public bool IsDeletedFlagNull
		{
			get {
				 return _deletedFlagNull; }
			set { _deletedFlagNull = value; }
		}
		public bool _IsSetDeletedFlag
		{
			get { return _isSetDeletedFlag; }
		}
	}
	[Serializable]
	public class View_ApplicantData
	{
		private int _applicantID;
		private int _caseID;
		private string _title;
		private string _firstName;
		private string _lastName;
		private double _requestAmount;
		private bool _hasProxy;
		private string _gender;
		private DateTime _dateOfBirth;
		private int _raceID;
		private int _religionID;
		private int _nationalityID;
		private string _cardID;
		private int _cardType;
		private int _score;
		private int _age;
		private bool _deletedFlag;
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
		public bool HasProxy
		{
			get{ return _hasProxy; }
			set{ _hasProxy = value; }
		}
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
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
		public int Score
		{
			get{ return _score; }
			set{ _score = value; }
		}
		public int Age
		{
			get{ return _age; }
			set{ _age = value; }
		}
		public bool DeletedFlag
		{
			get{ return _deletedFlag; }
			set{ _deletedFlag = value; }
		}
	}
	[Serializable]
	public class View_ApplicantPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ApplicantRow[] view_ApplicantRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ApplicantItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ApplicantItems : View_ApplicantData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ApplicantItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ApplicantItems[] view_ApplicantItems { get; set; }
	}
}

