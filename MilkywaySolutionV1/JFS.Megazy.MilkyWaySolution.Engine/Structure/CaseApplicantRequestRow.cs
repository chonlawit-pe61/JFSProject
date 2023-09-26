using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantRequestRow
	{
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private int _referenceMSCID;
		private bool _isSetReferenceMSCID = false;
		private bool _referenceMSCIDNull = true;
		private string _referenceMSCCode;
		private bool _isSetReferenceMSCCode = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private string _subject;
		private bool _isSetSubject = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _gender;
		private bool _isSetGender = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _postCode;
		private bool _isSetPostCode = false;
		private string _cardID;
		private bool _isSetCardID = false;
		private bool _defactive;
		private bool _isSetDefactive = false;
		private bool _defactiveNull = true;
		private string _remark;
		private bool _isSetRemark = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private int _statusID;
		private bool _isSetStatusID = false;
		private bool _statusIDNull = true;
		private string _central;
		private bool _isSetCentral = false;
		private int _channelID;
		private bool _isSetChannelID = false;
		private bool _channelIDNull = true;
		private string _email;
		private bool _isSetEmail = false;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private bool _attachFileIDNull = true;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private int _raceID;
		private bool _isSetRaceID = false;
		private bool _raceIDNull = true;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private int _educationLevel;
		private bool _isSetEducationLevel = false;
		private bool _educationLevelNull = true;
		private int _religionID;
		private bool _isSetReligionID = false;
		private bool _religionIDNull = true;
		private int _nationalityID;
		private bool _isSetNationalityID = false;
		private bool _nationalityIDNull = true;
		private bool _isAgree;
		private bool _isSetIsAgree = false;
		private bool _isAgreeNull = true;
		/// <summary>
		/// รหัสรายการ
		/// </summary>
		[Required]
		public int TransactionID
		{
			get { return _transactionID; }
			set { _transactionID = value;
			      _isSetTransactionID = true; }
		}
		public bool _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
		/// <summary>
		/// รหัสอ้างอิงจากระบบ MSC
		/// </summary>
		public int ReferenceMSCID
		{
			get
			{
				return _referenceMSCID;
			}
			set
			{
				_referenceMSCIDNull = false;
				_isSetReferenceMSCID = true;
				_referenceMSCID = value;
			}
		}
		public bool IsReferenceMSCIDNull
		{
			get {
				 return _referenceMSCIDNull; }
			set { _referenceMSCIDNull = value; }
		}
		public bool _IsSetReferenceMSCID
		{
			get { return _isSetReferenceMSCID; }
		}
		/// <summary>
		/// เลขทีรับเรื่องจาก MSC
		/// </summary>
		public string ReferenceMSCCode
		{
			get { return _referenceMSCCode; }
			set { _referenceMSCCode = value;
			      _isSetReferenceMSCCode = true; }
		}
		public bool _IsSetReferenceMSCCode
		{
			get { return _isSetReferenceMSCCode; }
		}
		/// <summary>
		/// รหัสจังหวัด อ้างอิงตาราง Province
		/// </summary>
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
		/// <summary>
		/// รหัสหน่วยงาน อ้างอิงตาราง Department
		/// </summary>
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
		/// <summary>
		/// เรื่องที่ขอรับความช่วยเหลือ
		/// </summary>
		public string Subject
		{
			get { return _subject; }
			set { _subject = value;
			      _isSetSubject = true; }
		}
		public bool _IsSetSubject
		{
			get { return _isSetSubject; }
		}
		/// <summary>
		/// เบอร์ติดต่อ
		/// </summary>
		public string TelephoneNo
		{
			get { return _telephoneNo; }
			set { _telephoneNo = value;
			      _isSetTelephoneNo = true; }
		}
		public bool _IsSetTelephoneNo
		{
			get { return _isSetTelephoneNo; }
		}
		/// <summary>
		/// เพศ
		/// </summary>
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
		/// <summary>
		/// คำนำหน้าชื่อ
		/// </summary>
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
		/// สกุล
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
		/// ชื่อจังหวัด
		/// </summary>
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
		/// <summary>
		/// รหัสไปรษณีย์
		/// </summary>
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
		/// <summary>
		/// เลขที่บัตรประจำตัวประชาชน
		/// </summary>
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
		/// <summary>
		/// มีความพิการหรือไม่ 1=ใช่  0= ไม่ใช่
		/// </summary>
		public bool Defactive
		{
			get
			{
				return _defactive;
			}
			set
			{
				_defactiveNull = false;
				_isSetDefactive = true;
				_defactive = value;
			}
		}
		public bool IsDefactiveNull
		{
			get {
				 return _defactiveNull; }
			set { _defactiveNull = value; }
		}
		public bool _IsSetDefactive
		{
			get { return _isSetDefactive; }
		}
		/// <summary>
		/// หมายเหตุ
		/// </summary>
		public string Remark
		{
			get { return _remark; }
			set { _remark = value;
			      _isSetRemark = true; }
		}
		public bool _IsSetRemark
		{
			get { return _isSetRemark; }
		}
		/// <summary>
		/// วันที่สร้างรายการ
		/// </summary>
		public DateTime CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				_createDateNull = false;
				_isSetCreateDate = true;
				_createDate = value;
			}
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
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
		/// <summary>
		/// อ้างอิงจาก Table RequsetStatus สถานะการดำเนินงาน 1=รับเรื่อง 2=ยื่นเรื่องต่อกองทุนยุติธรรม 3  ปฏิเสธคำขอ
		/// </summary>
		public int StatusID
		{
			get
			{
				return _statusID;
			}
			set
			{
				_statusIDNull = false;
				_isSetStatusID = true;
				_statusID = value;
			}
		}
		public bool IsStatusIDNull
		{
			get {
				 return _statusIDNull; }
			set { _statusIDNull = value; }
		}
		public bool _IsSetStatusID
		{
			get { return _isSetStatusID; }
		}
		/// <summary>
		/// ข้อมูลจากส่วนกลางใช่หรือไม่ 1=ใช่ 0=ไม่ใช่
		/// </summary>
		public string Central
		{
			get { return _central; }
			set { _central = value;
			      _isSetCentral = true; }
		}
		public bool _IsSetCentral
		{
			get { return _isSetCentral; }
		}
		/// <summary>
		/// รหัสอ้างอิงแหล่งข้อมูล อ้างอิงตาราง ComplaintChannel
		/// </summary>
		public int ChannelID
		{
			get
			{
				return _channelID;
			}
			set
			{
				_channelIDNull = false;
				_isSetChannelID = true;
				_channelID = value;
			}
		}
		public bool IsChannelIDNull
		{
			get {
				 return _channelIDNull; }
			set { _channelIDNull = value; }
		}
		public bool _IsSetChannelID
		{
			get { return _isSetChannelID; }
		}
		/// <summary>
		/// อีเมล
		/// </summary>
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
		/// รหัสไฟล์แนบ
		/// </summary>
		public int AttachFileID
		{
			get
			{
				return _attachFileID;
			}
			set
			{
				_attachFileIDNull = false;
				_isSetAttachFileID = true;
				_attachFileID = value;
			}
		}
		public bool IsAttachFileIDNull
		{
			get {
				 return _attachFileIDNull; }
			set { _attachFileIDNull = value; }
		}
		public bool _IsSetAttachFileID
		{
			get { return _isSetAttachFileID; }
		}
		/// <summary>
		/// รหัสที่อยู่
		/// </summary>
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
		/// <summary>
		/// รหัสเชื้อชาติ อ้างอิงตาราง Race
		/// </summary>
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
		/// <summary>
		/// วันเดือนปีเกิด
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
		/// ระดับการศึกษา
		/// </summary>
		public int EducationLevel
		{
			get
			{
				return _educationLevel;
			}
			set
			{
				_educationLevelNull = false;
				_isSetEducationLevel = true;
				_educationLevel = value;
			}
		}
		public bool IsEducationLevelNull
		{
			get {
				 return _educationLevelNull; }
			set { _educationLevelNull = value; }
		}
		public bool _IsSetEducationLevel
		{
			get { return _isSetEducationLevel; }
		}
		/// <summary>
		/// รหัสศาสนาที่นับถือ
		/// </summary>
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
		/// <summary>
		/// รหัสสัญชาติ
		/// </summary>
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
		/// <summary>
		/// สถานะการยอมรับเงื่อนไข/ยืนยัน 1=ยอมรับเงื่อนไข/ยืนยัน 0=ไม่ยอมรับเงื่อนไข/ยืนยัน
		/// </summary>
		public bool IsAgree
		{
			get
			{
				return _isAgree;
			}
			set
			{
				_isAgreeNull = false;
				_isSetIsAgree = true;
				_isAgree = value;
			}
		}
		public bool IsIsAgreeNull
		{
			get {
				 return _isAgreeNull; }
			set { _isAgreeNull = value; }
		}
		public bool _IsSetIsAgree
		{
			get { return _isSetIsAgree; }
		}
	}
	[Serializable]
	public class CaseApplicantRequestData
	{
		private int _transactionID;
		private int _referenceMSCID;
		private string _referenceMSCCode;
		private int _provinceID;
		private int _departmentId;
		private string _subject;
		private string _telephoneNo;
		private string _gender;
		private string _title;
		private string _firstName;
		private string _lastName;
		private string _provinceName;
		private string _postCode;
		private string _cardID;
		private bool _defactive;
		private string _remark;
		private DateTime _createDate;
		private DateTime _modifiedDate;
		private int _statusID;
		private string _central;
		private int _channelID;
		private string _email;
		private int _attachFileID;
		private int _addressID;
		private int _raceID;
		private DateTime _dateOfBirth;
		private int _educationLevel;
		private int _religionID;
		private int _nationalityID;
		private bool _isAgree;
		/// <summary>
		/// รหัสรายการ
		/// </summary>
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		/// <summary>
		/// รหัสอ้างอิงจากระบบ MSC
		/// </summary>
		public int ReferenceMSCID
		{
			get{ return _referenceMSCID; }
			set{ _referenceMSCID = value; }
		}
		/// <summary>
		/// เลขทีรับเรื่องจาก MSC
		/// </summary>
		public string ReferenceMSCCode
		{
			get{ return _referenceMSCCode; }
			set{ _referenceMSCCode = value; }
		}
		/// <summary>
		/// รหัสจังหวัด อ้างอิงตาราง Province
		/// </summary>
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		/// <summary>
		/// รหัสหน่วยงาน อ้างอิงตาราง Department
		/// </summary>
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		/// <summary>
		/// เรื่องที่ขอรับความช่วยเหลือ
		/// </summary>
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		/// <summary>
		/// เบอร์ติดต่อ
		/// </summary>
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		/// <summary>
		/// เพศ
		/// </summary>
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		/// <summary>
		/// คำนำหน้าชื่อ
		/// </summary>
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
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
		/// สกุล
		/// </summary>
		public string LastName
		{
			get{ return _lastName; }
			set{ _lastName = value; }
		}
		/// <summary>
		/// ชื่อจังหวัด
		/// </summary>
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		/// <summary>
		/// รหัสไปรษณีย์
		/// </summary>
		public string PostCode
		{
			get{ return _postCode; }
			set{ _postCode = value; }
		}
		/// <summary>
		/// เลขที่บัตรประจำตัวประชาชน
		/// </summary>
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		/// <summary>
		/// มีความพิการหรือไม่ 1=ใช่  0= ไม่ใช่
		/// </summary>
		public bool Defactive
		{
			get{ return _defactive; }
			set{ _defactive = value; }
		}
		/// <summary>
		/// หมายเหตุ
		/// </summary>
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
		/// <summary>
		/// วันที่สร้างรายการ
		/// </summary>
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		/// <summary>
		/// วันที่สร้างรายการ เก็บวันที่แบบ String
		/// </summary>
		public string CreateDateStr { get; set; }
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
		/// <summary>
		/// อ้างอิงจาก Table RequsetStatus สถานะการดำเนินงาน 1=รับเรื่อง 2=ยื่นเรื่องต่อกองทุนยุติธรรม 3  ปฏิเสธคำขอ
		/// </summary>
		public int StatusID
		{
			get{ return _statusID; }
			set{ _statusID = value; }
		}
		/// <summary>
		/// ข้อมูลจากส่วนกลางใช่หรือไม่ 1=ใช่ 0=ไม่ใช่
		/// </summary>
		public string Central
		{
			get{ return _central; }
			set{ _central = value; }
		}
		/// <summary>
		/// รหัสอ้างอิงแหล่งข้อมูล อ้างอิงตาราง ComplaintChannel
		/// </summary>
		public int ChannelID
		{
			get{ return _channelID; }
			set{ _channelID = value; }
		}
		/// <summary>
		/// อีเมล
		/// </summary>
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		/// <summary>
		/// รหัสไฟล์แนบ
		/// </summary>
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		/// <summary>
		/// รหัสที่อยู่
		/// </summary>
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		/// <summary>
		/// รหัสเชื้อชาติ อ้างอิงตาราง Race
		/// </summary>
		public int RaceID
		{
			get{ return _raceID; }
			set{ _raceID = value; }
		}
		/// <summary>
		/// วันเดือนปีเกิด
		/// </summary>
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		/// <summary>
		/// วันเดือนปีเกิด เก็บวันที่แบบ String
		/// </summary>
		public string DateOfBirthStr { get; set; }
		/// <summary>
		/// ระดับการศึกษา
		/// </summary>
		public int EducationLevel
		{
			get{ return _educationLevel; }
			set{ _educationLevel = value; }
		}
		/// <summary>
		/// รหัสศาสนาที่นับถือ
		/// </summary>
		public int ReligionID
		{
			get{ return _religionID; }
			set{ _religionID = value; }
		}
		/// <summary>
		/// รหัสสัญชาติ
		/// </summary>
		public int NationalityID
		{
			get{ return _nationalityID; }
			set{ _nationalityID = value; }
		}
		/// <summary>
		/// สถานะการยอมรับเงื่อนไข/ยืนยัน 1=ยอมรับเงื่อนไข/ยืนยัน 0=ไม่ยอมรับเงื่อนไข/ยืนยัน
		/// </summary>
		public bool IsAgree
		{
			get{ return _isAgree; }
			set{ _isAgree = value; }
		}
	}
	[Serializable]
	public class CaseApplicantRequestPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantRequestRow[] caseApplicantRequestRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantRequestItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantRequestItems : CaseApplicantRequestData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantRequestItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantRequestItems[] caseApplicantRequestItems { get; set; }
	}
}

