using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class UserRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private string _userName;
		private bool _isSetUserName = false;
		private string _aliasName;
		private bool _isSetAliasName = false;
		private string _password;
		private bool _isSetPassword = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private int _gender;
		private bool _isSetGender = false;
		private string _phoneNumber;
		private bool _isSetPhoneNumber = false;
		private string _email;
		private bool _isSetEmail = false;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private DateTime _registDate;
		private bool _isSetRegistDate = false;
		private bool _registDateNull = true;
		private DateTime _updateDate;
		private bool _isSetUpdateDate = false;
		private bool _updateDateNull = true;
		private bool _isVerifyByEmail;
		private bool _isSetIsVerifyByEmail = false;
		private bool _isRenewAccount;
		private bool _isSetIsRenewAccount = false;
		private int _userStatusID;
		private bool _isSetUserStatusID = false;
		private DateTime _lastloginDate;
		private bool _isSetLastLoginDate = false;
		private bool _lastloginDateNull = true;
		private string _userTypeID;
		private bool _isSetUserTypeID = false;
		private int _updateBy;
		private bool _isSetUpdateBy = false;
		private int _renewTicketID;
		private bool _isSetRenewTicketID = false;
		[Required]
		public int UserID
		{
			get { return _userID; }
			set { _userID = value;
			      _isSetUserID = true; }
		}
		public bool _IsSetUserID
		{
			get { return _isSetUserID; }
		}
		[Required]
		public string UserName
		{
			get { return _userName; }
			set { _userName = value;
			      _isSetUserName = true; }
		}
		public bool _IsSetUserName
		{
			get { return _isSetUserName; }
		}
		[Required]
		public string AliasName
		{
			get { return _aliasName; }
			set { _aliasName = value;
			      _isSetAliasName = true; }
		}
		public bool _IsSetAliasName
		{
			get { return _isSetAliasName; }
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
		[Required]
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
		[Required]
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
		[Required]
		public int Gender
		{
			get { return _gender; }
			set { _gender = value;
			      _isSetGender = true; }
		}
		public bool _IsSetGender
		{
			get { return _isSetGender; }
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
		[Required]
		public bool IsRenewAccount
		{
			get { return _isRenewAccount; }
			set { _isRenewAccount = value;
			      _isSetIsRenewAccount = true; }
		}
		public bool _IsSetIsRenewAccount
		{
			get { return _isSetIsRenewAccount; }
		}
		[Required]
		public int UserStatusID
		{
			get { return _userStatusID; }
			set { _userStatusID = value;
			      _isSetUserStatusID = true; }
		}
		public bool _IsSetUserStatusID
		{
			get { return _isSetUserStatusID; }
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
		[Required]
		public string UserTypeID
		{
			get { return _userTypeID; }
			set { _userTypeID = value;
			      _isSetUserTypeID = true; }
		}
		public bool _IsSetUserTypeID
		{
			get { return _isSetUserTypeID; }
		}
		[Required]
		public int UpdateBy
		{
			get { return _updateBy; }
			set { _updateBy = value;
			      _isSetUpdateBy = true; }
		}
		public bool _IsSetUpdateBy
		{
			get { return _isSetUpdateBy; }
		}
		[Required]
		public int RenewTicketID
		{
			get { return _renewTicketID; }
			set { _renewTicketID = value;
			      _isSetRenewTicketID = true; }
		}
		public bool _IsSetRenewTicketID
		{
			get { return _isSetRenewTicketID; }
		}
	}
	[Serializable]
	public class UserData
	{
		private int _userID;
		private string _userName;
		private string _aliasName;
		private string _password;
		private string _firstName;
		private string _lastName;
		private int _gender;
		private string _phoneNumber;
		private string _email;
		private DateTime _dateOfBirth;
		private DateTime _registDate;
		private DateTime _updateDate;
		private bool _isVerifyByEmail;
		private bool _isRenewAccount;
		private int _userStatusID;
		private DateTime _lastloginDate;
		private string _userTypeID;
		private int _updateBy;
		private int _renewTicketID;
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public string UserName
		{
			get{ return _userName; }
			set{ _userName = value; }
		}
		public string AliasName
		{
			get{ return _aliasName; }
			set{ _aliasName = value; }
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
		public string PhoneNumber
		{
			get{ return _phoneNumber; }
			set{ _phoneNumber = value; }
		}
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		public string DateOfBirthStr { get; set; }
		public DateTime RegistDate
		{
			get{ return _registDate; }
			set{ _registDate = value; }
		}
		public string RegistDateStr { get; set; }
		public DateTime UpdateDate
		{
			get{ return _updateDate; }
			set{ _updateDate = value; }
		}
		public string UpdateDateStr { get; set; }
		public bool IsVerifyByEmail
		{
			get{ return _isVerifyByEmail; }
			set{ _isVerifyByEmail = value; }
		}
		public bool IsRenewAccount
		{
			get{ return _isRenewAccount; }
			set{ _isRenewAccount = value; }
		}
		public int UserStatusID
		{
			get{ return _userStatusID; }
			set{ _userStatusID = value; }
		}
		public DateTime LastLoginDate
		{
			get{ return _lastloginDate; }
			set{ _lastloginDate = value; }
		}
		public string LastLoginDateStr { get; set; }
		public string UserTypeID
		{
			get{ return _userTypeID; }
			set{ _userTypeID = value; }
		}
		public int UpdateBy
		{
			get{ return _updateBy; }
			set{ _updateBy = value; }
		}
		public int RenewTicketID
		{
			get{ return _renewTicketID; }
			set{ _renewTicketID = value; }
		}
	}
	[Serializable]
	public class UserPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public UserRow[] userRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส UserItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class UserItems : UserData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class UserItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public UserItems[] userItems { get; set; }
	}
}

