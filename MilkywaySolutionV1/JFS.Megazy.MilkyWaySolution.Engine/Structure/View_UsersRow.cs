using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_UsersRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private string _userName;
		private bool _isSetUserName = false;
		private string _aliasName;
		private bool _isSetAliasName = false;
		private string _title;
		private bool _isSetTitle = false;
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
		private DateTime _registDate;
		private bool _isSetRegistDate = false;
		private bool _registDateNull = true;
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
		private int _renewTicketID;
		private bool _isSetRenewTicketID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private string _signature;
		private bool _isSetSignature = false;
		private bool _isAdministrator;
		private bool _isSetIsAdministrator = false;
		private bool _isAdministratorNull = true;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private string _departmentNameAbbr;
		private bool _isSetDepartmentNameAbbr = false;
		private int _roleID;
		private bool _isSetRoleID = false;
		private bool _roleIDNull = true;
		private string _roleName;
		private bool _isSetRoleName = false;
		private string _description;
		private bool _isSetDescription = false;
		private string _cardID;
		private bool _isSetCardID = false;
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
		public string Signature
		{
			get { return _signature; }
			set { _signature = value;
			      _isSetSignature = true; }
		}
		public bool _IsSetSignature
		{
			get { return _isSetSignature; }
		}
		public bool IsAdministrator
		{
			get
			{
				return _isAdministrator;
			}
			set
			{
				_isAdministratorNull = false;
				_isSetIsAdministrator = true;
				_isAdministrator = value;
			}
		}
		public bool IsIsAdministratorNull
		{
			get {
				 return _isAdministratorNull; }
			set { _isAdministratorNull = value; }
		}
		public bool _IsSetIsAdministrator
		{
			get { return _isSetIsAdministrator; }
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
		public string DepartmentNameAbbr
		{
			get { return _departmentNameAbbr; }
			set { _departmentNameAbbr = value;
			      _isSetDepartmentNameAbbr = true; }
		}
		public bool _IsSetDepartmentNameAbbr
		{
			get { return _isSetDepartmentNameAbbr; }
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
		public string Description
		{
			get { return _description; }
			set { _description = value;
			      _isSetDescription = true; }
		}
		public bool _IsSetDescription
		{
			get { return _isSetDescription; }
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
	}
	[Serializable]
	public class View_UsersData
	{
		private int _userID;
		private string _userName;
		private string _aliasName;
		private string _title;
		private string _firstName;
		private string _lastName;
		private int _gender;
		private string _phoneNumber;
		private string _email;
		private DateTime _registDate;
		private bool _isVerifyByEmail;
		private bool _isRenewAccount;
		private int _userStatusID;
		private DateTime _lastloginDate;
		private string _userTypeID;
		private int _renewTicketID;
		private int _departmentId;
		private string _signature;
		private bool _isAdministrator;
		private int _provinceID;
		private string _departmentName;
		private string _departmentNameAbbr;
		private int _roleID;
		private string _roleName;
		private string _description;
		private string _cardID;
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
		public DateTime RegistDate
		{
			get{ return _registDate; }
			set{ _registDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string RegistDateStr { get; set; }
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
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string LastLoginDateStr { get; set; }
		public string UserTypeID
		{
			get{ return _userTypeID; }
			set{ _userTypeID = value; }
		}
		public int RenewTicketID
		{
			get{ return _renewTicketID; }
			set{ _renewTicketID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public string Signature
		{
			get{ return _signature; }
			set{ _signature = value; }
		}
		public bool IsAdministrator
		{
			get{ return _isAdministrator; }
			set{ _isAdministrator = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string DepartmentName
		{
			get{ return _departmentName; }
			set{ _departmentName = value; }
		}
		public string DepartmentNameAbbr
		{
			get{ return _departmentNameAbbr; }
			set{ _departmentNameAbbr = value; }
		}
		public int RoleID
		{
			get{ return _roleID; }
			set{ _roleID = value; }
		}
		public string RoleName
		{
			get{ return _roleName; }
			set{ _roleName = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
	}
	[Serializable]
	public class View_UsersPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_UsersRow[] view_UsersRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_UsersItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_UsersItems : View_UsersData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_UsersItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_UsersItems[] view_UsersItems { get; set; }
	}
}

