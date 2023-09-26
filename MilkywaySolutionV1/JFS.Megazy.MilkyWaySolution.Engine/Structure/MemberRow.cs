using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MemberRow
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
		private bool _isVerifyPhone;
		private bool _isSetIsVerifyPhone = false;
		private bool _isVerifyPhoneNull = true;
		private string _secretKey;
		private bool _isSetSecretKey = false;
		private string _sessionID;
		private bool _isSetSessionID = false;
		private string _key;
		private bool _isSetKey = false;
		private int _memberStatusID;
		private bool _isSetMemberStatusID = false;
		private string _tokenDeviceID;
		private bool _isSetTokenDeviceID = false;
		private string _deviceType;
		private bool _isSetDeviceType = false;
		private DateTime _lastloginDate;
		private bool _isSetLastLoginDate = false;
		private bool _lastloginDateNull = true;
		private string _socialID;
		private bool _isSetSocialID = false;
		private string _socialName;
		private bool _isSetSocialName = false;
		private string _phoneNumber;
		private bool _isSetPhoneNumber = false;
		private string _memberTypeID;
		private bool _isSetMemberTypeID = false;
		private string _memberToken;
		private bool _isSetMemberToken = false;
		private DateTime _memberTokenExpire;
		private bool _isSetMemberTokenExpire = false;
		private bool _memberTokenExpireNull = true;
		private string _shortDesc;
		private bool _isSetShortDesc = false;
		/// <summary>
		/// รหัสสมาชิกผู้ใช้งาน
		/// </summary>
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
		/// <summary>
		/// ชื่อสมาชิกผู้ใช้งาน
		/// </summary>
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
		/// <summary>
		/// ชื่อองค์กร
		/// </summary>
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
		/// <summary>
		/// รหัสผ่าน
		/// </summary>
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
		/// <summary>
		/// ชื่อ
		/// </summary>
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
		/// <summary>
		/// นามสกุล
		/// </summary>
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
		/// <summary>
		/// เพศ
		/// </summary>
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
		/// <summary>
		/// วันที่แก้ไข
		/// </summary>
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
		/// <summary>
		/// วันที่ลงทะเบียน
		/// </summary>
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
		/// <summary>
		/// วันเกิด
		/// </summary>
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
		/// <summary>
		/// อีเมล
		/// </summary>
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
		/// <summary>
		/// ตรวจสอบอีเมลแล้วหรือไม่
		/// </summary>
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
		/// <summary>
		/// รหัสยื่นยันตรวจสอบอีเมล
		/// </summary>
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
		/// <summary>
		/// ได้ยืนยันเบอร์โทรศัพท์แล้วหรือไม่ 1=ยืนยัน 0=ยังไม่ยืนยัน
		/// </summary>
		public bool IsVerifyPhone
		{
			get
			{
				return _isVerifyPhone;
			}
			set
			{
				_isVerifyPhoneNull = false;
				_isSetIsVerifyPhone = true;
				_isVerifyPhone = value;
			}
		}
		public bool IsIsVerifyPhoneNull
		{
			get {
				 return _isVerifyPhoneNull; }
			set { _isVerifyPhoneNull = value; }
		}
		public bool _IsSetIsVerifyPhone
		{
			get { return _isSetIsVerifyPhone; }
		}
		/// <summary>
		/// คีย์ส่วนตัว
		/// </summary>
		public string SecretKey
		{
			get { return _secretKey; }
			set { _secretKey = value;
			      _isSetSecretKey = true; }
		}
		public bool _IsSetSecretKey
		{
			get { return _isSetSecretKey; }
		}
		/// <summary>
		/// เซสชั่น
		/// </summary>
		public string SessionID
		{
			get { return _sessionID; }
			set { _sessionID = value;
			      _isSetSessionID = true; }
		}
		public bool _IsSetSessionID
		{
			get { return _isSetSessionID; }
		}
		/// <summary>
		/// คีย์
		/// </summary>
		public string Key
		{
			get { return _key; }
			set { _key = value;
			      _isSetKey = true; }
		}
		public bool _IsSetKey
		{
			get { return _isSetKey; }
		}
		/// <summary>
		/// รหัสสถานะสมาชิกผู้ใช้งาน
		/// </summary>
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
		public string TokenDeviceID
		{
			get { return _tokenDeviceID; }
			set { _tokenDeviceID = value;
			      _isSetTokenDeviceID = true; }
		}
		public bool _IsSetTokenDeviceID
		{
			get { return _isSetTokenDeviceID; }
		}
		/// <summary>
		/// ประเภทเครื่องที่ใช้งาน
		/// </summary>
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
		/// <summary>
		/// วันที่เข้าใช้งานล่าสุด
		/// </summary>
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
		/// <summary>
		/// รหัสโซเชียล
		/// </summary>
		public string SocialID
		{
			get { return _socialID; }
			set { _socialID = value;
			      _isSetSocialID = true; }
		}
		public bool _IsSetSocialID
		{
			get { return _isSetSocialID; }
		}
		/// <summary>
		/// ชื่อโซเชียล
		/// </summary>
		public string SocialName
		{
			get { return _socialName; }
			set { _socialName = value;
			      _isSetSocialName = true; }
		}
		public bool _IsSetSocialName
		{
			get { return _isSetSocialName; }
		}
		/// <summary>
		/// เบอร์ติดต่อ
		/// </summary>
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
		/// <summary>
		/// ประเภทสมาชิก อ้างอิงตาราง MemberType (Personal,Organize)
		/// </summary>
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
		public string MemberToken
		{
			get { return _memberToken; }
			set { _memberToken = value;
			      _isSetMemberToken = true; }
		}
		public bool _IsSetMemberToken
		{
			get { return _isSetMemberToken; }
		}
		public DateTime MemberTokenExpire
		{
			get
			{
				return _memberTokenExpire;
			}
			set
			{
				_memberTokenExpireNull = false;
				_isSetMemberTokenExpire = true;
				_memberTokenExpire = value;
			}
		}
		public bool IsMemberTokenExpireNull
		{
			get {
				 return _memberTokenExpireNull; }
			set { _memberTokenExpireNull = value; }
		}
		public bool _IsSetMemberTokenExpire
		{
			get { return _isSetMemberTokenExpire; }
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
	}
	[Serializable]
	public class MemberData
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
		private bool _isVerifyPhone;
		private string _secretKey;
		private string _sessionID;
		private string _key;
		private int _memberStatusID;
		private string _tokenDeviceID;
		private string _deviceType;
		private DateTime _lastloginDate;
		private string _socialID;
		private string _socialName;
		private string _phoneNumber;
		private string _memberTypeID;
		private string _memberToken;
		private DateTime _memberTokenExpire;
		private string _shortDesc;
		/// <summary>
		/// รหัสสมาชิกผู้ใช้งาน
		/// </summary>
		public int MemberID
		{
			get{ return _memberID; }
			set{ _memberID = value; }
		}
		/// <summary>
		/// ชื่อสมาชิกผู้ใช้งาน
		/// </summary>
		public string MemberName
		{
			get{ return _memberName; }
			set{ _memberName = value; }
		}
		/// <summary>
		/// ชื่อองค์กร
		/// </summary>
		public string OrgName
		{
			get{ return _orgName; }
			set{ _orgName = value; }
		}
		/// <summary>
		/// รหัสผ่าน
		/// </summary>
		public string Password
		{
			get{ return _password; }
			set{ _password = value; }
		}
		/// <summary>
		/// ชื่อ
		/// </summary>
		public string FirstName
		{
			get{ return _firstName; }
			set{ _firstName = value; }
		}
		/// <summary>
		/// นามสกุล
		/// </summary>
		public string LastName
		{
			get{ return _lastName; }
			set{ _lastName = value; }
		}
		/// <summary>
		/// เพศ
		/// </summary>
		public int Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		/// <summary>
		/// วันที่แก้ไข
		/// </summary>
		public DateTime UpdateDate
		{
			get{ return _updateDate; }
			set{ _updateDate = value; }
		}
		/// <summary>
		/// วันที่แก้ไข เก็บวันที่แบบ String
		/// </summary>
		public string UpdateDateStr { get; set; }
		/// <summary>
		/// วันที่ลงทะเบียน
		/// </summary>
		public DateTime RegistDate
		{
			get{ return _registDate; }
			set{ _registDate = value; }
		}
		/// <summary>
		/// วันที่ลงทะเบียน เก็บวันที่แบบ String
		/// </summary>
		public string RegistDateStr { get; set; }
		/// <summary>
		/// วันเกิด
		/// </summary>
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		/// <summary>
		/// วันเกิด เก็บวันที่แบบ String
		/// </summary>
		public string DateOfBirthStr { get; set; }
		/// <summary>
		/// อีเมล
		/// </summary>
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		/// <summary>
		/// ตรวจสอบอีเมลแล้วหรือไม่
		/// </summary>
		public bool IsVerifyByEmail
		{
			get{ return _isVerifyByEmail; }
			set{ _isVerifyByEmail = value; }
		}
		/// <summary>
		/// รหัสยื่นยันตรวจสอบอีเมล
		/// </summary>
		public string VerifyEmailCode
		{
			get{ return _verifyEmailCode; }
			set{ _verifyEmailCode = value; }
		}
		/// <summary>
		/// ได้ยืนยันเบอร์โทรศัพท์แล้วหรือไม่ 1=ยืนยัน 0=ยังไม่ยืนยัน
		/// </summary>
		public bool IsVerifyPhone
		{
			get{ return _isVerifyPhone; }
			set{ _isVerifyPhone = value; }
		}
		/// <summary>
		/// คีย์ส่วนตัว
		/// </summary>
		public string SecretKey
		{
			get{ return _secretKey; }
			set{ _secretKey = value; }
		}
		/// <summary>
		/// เซสชั่น
		/// </summary>
		public string SessionID
		{
			get{ return _sessionID; }
			set{ _sessionID = value; }
		}
		/// <summary>
		/// คีย์
		/// </summary>
		public string Key
		{
			get{ return _key; }
			set{ _key = value; }
		}
		/// <summary>
		/// รหัสสถานะสมาชิกผู้ใช้งาน
		/// </summary>
		public int MemberStatusID
		{
			get{ return _memberStatusID; }
			set{ _memberStatusID = value; }
		}
		public string TokenDeviceID
		{
			get{ return _tokenDeviceID; }
			set{ _tokenDeviceID = value; }
		}
		/// <summary>
		/// ประเภทเครื่องที่ใช้งาน
		/// </summary>
		public string DeviceType
		{
			get{ return _deviceType; }
			set{ _deviceType = value; }
		}
		/// <summary>
		/// วันที่เข้าใช้งานล่าสุด
		/// </summary>
		public DateTime LastLoginDate
		{
			get{ return _lastloginDate; }
			set{ _lastloginDate = value; }
		}
		/// <summary>
		/// วันที่เข้าใช้งานล่าสุด เก็บวันที่แบบ String
		/// </summary>
		public string LastLoginDateStr { get; set; }
		/// <summary>
		/// รหัสโซเชียล
		/// </summary>
		public string SocialID
		{
			get{ return _socialID; }
			set{ _socialID = value; }
		}
		/// <summary>
		/// ชื่อโซเชียล
		/// </summary>
		public string SocialName
		{
			get{ return _socialName; }
			set{ _socialName = value; }
		}
		/// <summary>
		/// เบอร์ติดต่อ
		/// </summary>
		public string PhoneNumber
		{
			get{ return _phoneNumber; }
			set{ _phoneNumber = value; }
		}
		/// <summary>
		/// ประเภทสมาชิก อ้างอิงตาราง MemberType (Personal,Organize)
		/// </summary>
		public string MemberTypeID
		{
			get{ return _memberTypeID; }
			set{ _memberTypeID = value; }
		}
		public string MemberToken
		{
			get{ return _memberToken; }
			set{ _memberToken = value; }
		}
		public DateTime MemberTokenExpire
		{
			get{ return _memberTokenExpire; }
			set{ _memberTokenExpire = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string MemberTokenExpireStr { get; set; }
		public string ShortDesc
		{
			get{ return _shortDesc; }
			set{ _shortDesc = value; }
		}
	}
	[Serializable]
	public class MemberPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MemberRow[] memberRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MemberItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MemberItems : MemberData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MemberItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MemberItems[] memberItems { get; set; }
	}
}

