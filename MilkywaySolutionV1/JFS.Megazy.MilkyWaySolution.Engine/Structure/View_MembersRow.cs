using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_MembersRow
	{
		private int _memberID;
		private bool _isSetMemberID = false;
		private string _memberName;
		private bool _isSetMemberName = false;
		private string _orgName;
		private bool _isSetOrgName = false;
		private string _password;
		private bool _isSetPassword = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private int _gender;
		private bool _isSetGender = false;
		private bool _genderNull = true;
		private DateTime _updateDate;
		private bool _isSetUpdateDate = false;
		private bool _updateDateNull = true;
		private DateTime _registDate;
		private bool _isSetRegistDate = false;
		private bool _registDateNull = true;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private string _email;
		private bool _isSetEmail = false;
		private bool _isVerifyByEmail;
		private bool _isSetIsVerifyByEmail = false;
		private string _verifyEmailCode;
		private bool _isSetVerifyEmailCode = false;
		private int _memberStatusID;
		private bool _isSetMemberStatusID = false;
		private DateTime _lastloginDate;
		private bool _isSetLastLoginDate = false;
		private bool _lastloginDateNull = true;
		private string _phoneNumber;
		private bool _isSetPhoneNumber = false;
		private string _memberTypeID;
		private bool _isSetMemberTypeID = false;
		private string _memberTypeName;
		private bool _isSetMemberTypeName = false;
		private string _shortDesc;
		private bool _isSetShortDesc = false;
		private string _memberStatusName;
		private bool _isSetMemberStatusName = false;
		[Required]
		public int MemberID
		{
			get { return _memberID; }
			set { _memberID = value;
			      _isSetMemberID = true; }
		}
		public bool _IsSetMemberID
		{
			get { return _isSetMemberID; }
		}
		[Required]
		public string MemberName
		{
			get { return _memberName; }
			set { _memberName = value;
			      _isSetMemberName = true; }
		}
		public bool _IsSetMemberName
		{
			get { return _isSetMemberName; }
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
		[Required]
		public string Password
		{
			get { return _password; }
			set { _password = value;
			      _isSetPassword = true; }
		}
		public bool _IsSetPassword
		{
			get { return _isSetPassword; }
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
		public int Gender
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
			}
		}
		public bool IsGenderNull
		{
			get {
				 return _genderNull; }
			set { _genderNull = value; }
		}
		public bool _IsSetGender
		{
			get { return _isSetGender; }
		}
		public DateTime UpdateDate
		{
			get
			{
				return _updateDate;
			}
			set
			{
				_updateDateNull = false;
				_isSetUpdateDate = true;
				_updateDate = value;
			}
		}
		public bool IsUpdateDateNull
		{
			get {
				 return _updateDateNull; }
			set { _updateDateNull = value; }
		}
		public bool _IsSetUpdateDate
		{
			get { return _isSetUpdateDate; }
		}
		[Required]
		public DateTime RegistDate
		{
			get { return _registDate; }
			set { _registDate = value;
			      _registDateNull = false;
			      _isSetRegistDate = true; }
		}
		public bool IsRegistDateNull
		{
			get {
				 return _registDateNull; }
			set { _registDateNull = value; }
		}
		public bool _IsSetRegistDate
		{
			get { return _isSetRegistDate; }
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
		[Required]
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
		[Required]
		public bool IsVerifyByEmail
		{
			get { return _isVerifyByEmail; }
			set { _isVerifyByEmail = value;
			      _isSetIsVerifyByEmail = true; }
		}
		public bool _IsSetIsVerifyByEmail
		{
			get { return _isSetIsVerifyByEmail; }
		}
		public string VerifyEmailCode
		{
			get { return _verifyEmailCode; }
			set { _verifyEmailCode = value;
			      _isSetVerifyEmailCode = true; }
		}
		public bool _IsSetVerifyEmailCode
		{
			get { return _isSetVerifyEmailCode; }
		}
		[Required]
		public int MemberStatusID
		{
			get { return _memberStatusID; }
			set { _memberStatusID = value;
			      _isSetMemberStatusID = true; }
		}
		public bool _IsSetMemberStatusID
		{
			get { return _isSetMemberStatusID; }
		}
		public DateTime LastLoginDate
		{
			get
			{
				return _lastloginDate;
			}
			set
			{
				_lastloginDateNull = false;
				_isSetLastLoginDate = true;
				_lastloginDate = value;
			}
		}
		public bool IsLastLoginDateNull
		{
			get {
				 return _lastloginDateNull; }
			set { _lastloginDateNull = value; }
		}
		public bool _IsSetLastLoginDate
		{
			get { return _isSetLastLoginDate; }
		}
		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value;
			      _isSetPhoneNumber = true; }
		}
		public bool _IsSetPhoneNumber
		{
			get { return _isSetPhoneNumber; }
		}
		[Required]
		public string MemberTypeID
		{
			get { return _memberTypeID; }
			set { _memberTypeID = value;
			      _isSetMemberTypeID = true; }
		}
		public bool _IsSetMemberTypeID
		{
			get { return _isSetMemberTypeID; }
		}
		public string MemberTypeName
		{
			get { return _memberTypeName; }
			set { _memberTypeName = value;
			      _isSetMemberTypeName = true; }
		}
		public bool _IsSetMemberTypeName
		{
			get { return _isSetMemberTypeName; }
		}
		public string ShortDesc
		{
			get { return _shortDesc; }
			set { _shortDesc = value;
			      _isSetShortDesc = true; }
		}
		public bool _IsSetShortDesc
		{
			get { return _isSetShortDesc; }
		}
		public string MemberStatusName
		{
			get { return _memberStatusName; }
			set { _memberStatusName = value;
			      _isSetMemberStatusName = true; }
		}
		public bool _IsSetMemberStatusName
		{
			get { return _isSetMemberStatusName; }
		}
	}
	[Serializable]
	public class View_MembersData
	{
		private int _memberID;
		private string _memberName;
		private string _orgName;
		private string _password;
		private string _firstName;
		private string _lastName;
		private int _gender;
		private DateTime _updateDate;
		private DateTime _registDate;
		private DateTime _dateOfBirth;
		private string _email;
		private bool _isVerifyByEmail;
		private string _verifyEmailCode;
		private int _memberStatusID;
		private DateTime _lastloginDate;
		private string _phoneNumber;
		private string _memberTypeID;
		private string _memberTypeName;
		private string _shortDesc;
		private string _memberStatusName;
		public int MemberID
		{
			get{ return _memberID; }
			set{ _memberID = value; }
		}
		public string MemberName
		{
			get{ return _memberName; }
			set{ _memberName = value; }
		}
		public string OrgName
		{
			get{ return _orgName; }
			set{ _orgName = value; }
		}
		public string Password
		{
			get{ return _password; }
			set{ _password = value; }
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
		public int Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		public DateTime UpdateDate
		{
			get{ return _updateDate; }
			set{ _updateDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string UpdateDateStr { get; set; }
		public DateTime RegistDate
		{
			get{ return _registDate; }
			set{ _registDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string RegistDateStr { get; set; }
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string DateOfBirthStr { get; set; }
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public bool IsVerifyByEmail
		{
			get{ return _isVerifyByEmail; }
			set{ _isVerifyByEmail = value; }
		}
		public string VerifyEmailCode
		{
			get{ return _verifyEmailCode; }
			set{ _verifyEmailCode = value; }
		}
		public int MemberStatusID
		{
			get{ return _memberStatusID; }
			set{ _memberStatusID = value; }
		}
		public DateTime LastLoginDate
		{
			get{ return _lastloginDate; }
			set{ _lastloginDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string LastLoginDateStr { get; set; }
		public string PhoneNumber
		{
			get{ return _phoneNumber; }
			set{ _phoneNumber = value; }
		}
		public string MemberTypeID
		{
			get{ return _memberTypeID; }
			set{ _memberTypeID = value; }
		}
		public string MemberTypeName
		{
			get{ return _memberTypeName; }
			set{ _memberTypeName = value; }
		}
		public string ShortDesc
		{
			get{ return _shortDesc; }
			set{ _shortDesc = value; }
		}
		public string MemberStatusName
		{
			get{ return _memberStatusName; }
			set{ _memberStatusName = value; }
		}
	}
	[Serializable]
	public class View_MembersPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_MembersRow[] view_MembersRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_MembersItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_MembersItems : View_MembersData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_MembersItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_MembersItems[] view_MembersItems { get; set; }
	}
}

