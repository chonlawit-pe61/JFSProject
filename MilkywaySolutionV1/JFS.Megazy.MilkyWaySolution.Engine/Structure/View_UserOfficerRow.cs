using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_UserOfficerRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private int _userStatusID;
		private bool _isSetUserStatusID = false;
		private string _description;
		private bool _isSetDescription = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private int _officeRoleID;
		private bool _isSetOfficeRoleID = false;
		private bool _officeRoleIDNull = true;
		private string _officerRoleName;
		private bool _isSetOfficerRoleName = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private string _departmentNameAbbr;
		private bool _isSetDepartmentNameAbbr = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _phoneNumber;
		private bool _isSetPhoneNumber = false;
		private string _email;
		private bool _isSetEmail = false;
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
		public int OfficeRoleID
		{
			get
			{
				return _officeRoleID;
			}
			set
			{
				_officeRoleIDNull = false;
				_isSetOfficeRoleID = true;
				_officeRoleID = value;
			}
		}
		public bool IsOfficeRoleIDNull
		{
			get {
				 return _officeRoleIDNull; }
			set { _officeRoleIDNull = value; }
		}
		public bool _IsSetOfficeRoleID
		{
			get { return _isSetOfficeRoleID; }
		}
		public string OfficerRoleName
		{
			get { return _officerRoleName; }
			set { _officerRoleName = value;
			      _isSetOfficerRoleName = true; }
		}
		public bool _IsSetOfficerRoleName
		{
			get { return _isSetOfficerRoleName; }
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
	}
	[Serializable]
	public class View_UserOfficerData
	{
		private int _userID;
		private int _userStatusID;
		private string _description;
		private string _title;
		private string _firstName;
		private string _lastName;
		private int _officeRoleID;
		private string _officerRoleName;
		private int _departmentId;
		private string _departmentNameAbbr;
		private string _departmentName;
		private int _provinceID;
		private string _provinceName;
		private string _phoneNumber;
		private string _email;
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public int UserStatusID
		{
			get{ return _userStatusID; }
			set{ _userStatusID = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
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
		public int OfficeRoleID
		{
			get{ return _officeRoleID; }
			set{ _officeRoleID = value; }
		}
		public string OfficerRoleName
		{
			get{ return _officerRoleName; }
			set{ _officerRoleName = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public string DepartmentNameAbbr
		{
			get{ return _departmentNameAbbr; }
			set{ _departmentNameAbbr = value; }
		}
		public string DepartmentName
		{
			get{ return _departmentName; }
			set{ _departmentName = value; }
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
	}
	[Serializable]
	public class View_UserOfficerPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_UserOfficerRow[] view_UserOfficerRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_UserOfficerItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_UserOfficerItems : View_UserOfficerData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_UserOfficerItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_UserOfficerItems[] view_UserOfficerItems { get; set; }
	}
}

