using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantTempRow
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
		private int _status;
		private bool _isSetStatus = false;
		private bool _statusNull = true;
		private string _central;
		private bool _isSetCentral = false;
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
		public int Status
		{
			get
			{
				return _status;
			}
			set
			{
				_statusNull = false;
				_isSetStatus = true;
				_status = value;
			}
		}
		public bool IsStatusNull
		{
			get {
				 return _statusNull; }
			set { _statusNull = value; }
		}
		public bool _IsSetStatus
		{
			get { return _isSetStatus; }
		}
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
	}
	[Serializable]
	public class CaseApplicantTempData
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
		private int _status;
		private string _central;
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public int ReferenceMSCID
		{
			get{ return _referenceMSCID; }
			set{ _referenceMSCID = value; }
		}
		public string ReferenceMSCCode
		{
			get{ return _referenceMSCCode; }
			set{ _referenceMSCCode = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
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
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		public string PostCode
		{
			get{ return _postCode; }
			set{ _postCode = value; }
		}
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public bool Defactive
		{
			get{ return _defactive; }
			set{ _defactive = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public int Status
		{
			get{ return _status; }
			set{ _status = value; }
		}
		public string Central
		{
			get{ return _central; }
			set{ _central = value; }
		}
	}
	[Serializable]
	public class CaseApplicantTempPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantTempRow[] caseApplicantTempRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantTempItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantTempItems : CaseApplicantTempData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantTempItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantTempItems[] caseApplicantTempItems { get; set; }
	}
}

