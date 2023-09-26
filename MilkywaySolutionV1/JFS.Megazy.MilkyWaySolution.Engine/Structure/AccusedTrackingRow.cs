using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class AccusedTrackingRow
	{
		private int _accusedTrackingID;
		private bool _isSetAccusedTrackingID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private int _contractID;
		private bool _isSetContractID = false;
		private bool _contractIDNull = true;
		private DateTime _startDate;
		private bool _isSetStartDate = false;
		private bool _startDateNull = true;
		private DateTime _endDate;
		private bool _isSetEndDate = false;
		private bool _endDateNull = true;
		private string _note;
		private bool _isSetNote = false;
		private string _suretyFirstName;
		private bool _isSetSuretyFirstName = false;
		private string _suretyLastName;
		private bool _isSetSuretyLastName = false;
		private string _suretyTelephoneNo;
		private bool _isSetSuretyTelephoneNo = false;
		private string _suretyAddress;
		private bool _isSetSuretyAddress = false;
		private bool _isComplete;
		private bool _isSetIsComplete = false;
		private bool _isCompleteNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int AccusedTrackingID
		{
			get { return _accusedTrackingID; }
			set { _accusedTrackingID = value;
			      _isSetAccusedTrackingID = true; }
		}
		public bool _IsSetAccusedTrackingID
		{
			get { return _isSetAccusedTrackingID; }
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
		public int ApplicantID
		{
			get
			{
				return _applicantID;
			}
			set
			{
				_applicantIDNull = false;
				_isSetApplicantID = true;
				_applicantID = value;
			}
		}
		public bool IsApplicantIDNull
		{
			get {
				 return _applicantIDNull; }
			set { _applicantIDNull = value; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
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
		public int ContractID
		{
			get
			{
				return _contractID;
			}
			set
			{
				_contractIDNull = false;
				_isSetContractID = true;
				_contractID = value;
			}
		}
		public bool IsContractIDNull
		{
			get {
				 return _contractIDNull; }
			set { _contractIDNull = value; }
		}
		public bool _IsSetContractID
		{
			get { return _isSetContractID; }
		}
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				_startDateNull = false;
				_isSetStartDate = true;
				_startDate = value;
			}
		}
		public bool IsStartDateNull
		{
			get {
				 return _startDateNull; }
			set { _startDateNull = value; }
		}
		public bool _IsSetStartDate
		{
			get { return _isSetStartDate; }
		}
		public DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				_endDateNull = false;
				_isSetEndDate = true;
				_endDate = value;
			}
		}
		public bool IsEndDateNull
		{
			get {
				 return _endDateNull; }
			set { _endDateNull = value; }
		}
		public bool _IsSetEndDate
		{
			get { return _isSetEndDate; }
		}
		public string Note
		{
			get { return _note; }
			set { _note = value;
			      _isSetNote = true; }
		}
		public bool _IsSetNote
		{
			get { return _isSetNote; }
		}
		public string SuretyFirstName
		{
			get { return _suretyFirstName; }
			set { _suretyFirstName = value;
			      _isSetSuretyFirstName = true; }
		}
		public bool _IsSetSuretyFirstName
		{
			get { return _isSetSuretyFirstName; }
		}
		public string SuretyLastName
		{
			get { return _suretyLastName; }
			set { _suretyLastName = value;
			      _isSetSuretyLastName = true; }
		}
		public bool _IsSetSuretyLastName
		{
			get { return _isSetSuretyLastName; }
		}
		public string SuretyTelephoneNo
		{
			get { return _suretyTelephoneNo; }
			set { _suretyTelephoneNo = value;
			      _isSetSuretyTelephoneNo = true; }
		}
		public bool _IsSetSuretyTelephoneNo
		{
			get { return _isSetSuretyTelephoneNo; }
		}
		public string SuretyAddress
		{
			get { return _suretyAddress; }
			set { _suretyAddress = value;
			      _isSetSuretyAddress = true; }
		}
		public bool _IsSetSuretyAddress
		{
			get { return _isSetSuretyAddress; }
		}
		public bool IsComplete
		{
			get
			{
				return _isComplete;
			}
			set
			{
				_isCompleteNull = false;
				_isSetIsComplete = true;
				_isComplete = value;
			}
		}
		public bool IsIsCompleteNull
		{
			get {
				 return _isCompleteNull; }
			set { _isCompleteNull = value; }
		}
		public bool _IsSetIsComplete
		{
			get { return _isSetIsComplete; }
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
	public class AccusedTrackingData
	{
		private int _accusedTrackingID;
		private int _caseID;
		private int _applicantID;
		private int _departmentId;
		private int _contractID;
		private DateTime _startDate;
		private DateTime _endDate;
		private string _note;
		private string _suretyFirstName;
		private string _suretyLastName;
		private string _suretyTelephoneNo;
		private string _suretyAddress;
		private bool _isComplete;
		private DateTime _modifiedDate;
		public int AccusedTrackingID
		{
			get{ return _accusedTrackingID; }
			set{ _accusedTrackingID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public DateTime StartDate
		{
			get{ return _startDate; }
			set{ _startDate = value; }
		}
		public string StartDateStr { get; set; }
		public DateTime EndDate
		{
			get{ return _endDate; }
			set{ _endDate = value; }
		}
		public string EndDateStr { get; set; }
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public string SuretyFirstName
		{
			get{ return _suretyFirstName; }
			set{ _suretyFirstName = value; }
		}
		public string SuretyLastName
		{
			get{ return _suretyLastName; }
			set{ _suretyLastName = value; }
		}
		public string SuretyTelephoneNo
		{
			get{ return _suretyTelephoneNo; }
			set{ _suretyTelephoneNo = value; }
		}
		public string SuretyAddress
		{
			get{ return _suretyAddress; }
			set{ _suretyAddress = value; }
		}
		public bool IsComplete
		{
			get{ return _isComplete; }
			set{ _isComplete = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class AccusedTrackingPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public AccusedTrackingRow[] accusedTrackingRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส AccusedTrackingItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class AccusedTrackingItems : AccusedTrackingData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class AccusedTrackingItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public AccusedTrackingItems[] accusedTrackingItems { get; set; }
	}
}

