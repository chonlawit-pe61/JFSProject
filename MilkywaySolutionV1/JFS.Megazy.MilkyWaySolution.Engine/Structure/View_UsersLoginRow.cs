using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_UsersLoginRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private string _userName;
		private bool _isSetUserName = false;
		private string _aliasName;
		private bool _isSetAliasName = false;
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
		private bool _isRenewAccount;
		private bool _isSetIsRenewAccount = false;
		private int _userStatusID;
		private bool _isSetUserStatusID = false;
		private string _userTypeID;
		private bool _isSetUserTypeID = false;
		private int _renewTicketID;
		private bool _isSetRenewTicketID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
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
		private string _iP;
		private bool _isSetIP = false;
		private string _deviceType;
		private bool _isSetDeviceType = false;
		private DateTime _loginDate;
		private bool _isSetLoginDate = false;
		private bool _loginDateNull = true;
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
		public string IP
		{
			get { return _iP; }
			set { _iP = value;
			      _isSetIP = true; }
		}
		public bool _IsSetIP
		{
			get { return _isSetIP; }
		}
		public string DeviceType
		{
			get { return _deviceType; }
			set { _deviceType = value;
			      _isSetDeviceType = true; }
		}
		public bool _IsSetDeviceType
		{
			get { return _isSetDeviceType; }
		}
		public DateTime LoginDate
		{
			get
			{
				return _loginDate;
			}
			set
			{
				_loginDateNull = false;
				_isSetLoginDate = true;
				_loginDate = value;
			}
		}
		public bool IsLoginDateNull
		{
			get {
				 return _loginDateNull; }
			set { _loginDateNull = value; }
		}
		public bool _IsSetLoginDate
		{
			get { return _isSetLoginDate; }
		}
	}
	[Serializable]
	public class View_UsersLoginData
	{
		private int _userID;
		private string _userName;
		private string _aliasName;
		private string _firstName;
		private string _lastName;
		private int _gender;
		private string _phoneNumber;
		private string _email;
		private bool _isRenewAccount;
		private int _userStatusID;
		private string _userTypeID;
		private int _renewTicketID;
		private int _departmentId;
		private bool _isAdministrator;
		private int _provinceID;
		private string _departmentName;
		private string _departmentNameAbbr;
		private int _roleID;
		private string _roleName;
		private string _description;
		private string _iP;
		private string _deviceType;
		private DateTime _loginDate;
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
		public string IP
		{
			get{ return _iP; }
			set{ _iP = value; }
		}
		public string DeviceType
		{
			get{ return _deviceType; }
			set{ _deviceType = value; }
		}
		public DateTime LoginDate
		{
			get{ return _loginDate; }
			set{ _loginDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string LoginDateStr { get; set; }
	}
	[Serializable]
	public class View_UsersLoginPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_UsersLoginRow[] view_UsersLoginRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_UsersLoginItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_UsersLoginItems : View_UsersLoginData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_UsersLoginItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_UsersLoginItems[] view_UsersLoginItems { get; set; }
	}
}

