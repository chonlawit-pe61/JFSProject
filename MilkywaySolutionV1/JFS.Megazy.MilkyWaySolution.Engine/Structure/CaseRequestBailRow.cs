using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseRequestBailRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _numberOfRequest;
		private bool _isSetNumberOfRequest = false;
		private bool _numberOfRequestNull = true;
		private bool _requestStatus;
		private bool _isSetRequestStatus = false;
		private bool _requestStatusNull = true;
		private string _courtDecree;
		private bool _isSetCourtDecree = false;
		private string _cause;
		private bool _isSetCause = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
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
		public int NumberOfRequest
		{
			get
			{
				return _numberOfRequest;
			}
			set
			{
				_numberOfRequestNull = false;
				_isSetNumberOfRequest = true;
				_numberOfRequest = value;
			}
		}
		public bool IsNumberOfRequestNull
		{
			get {
				 return _numberOfRequestNull; }
			set { _numberOfRequestNull = value; }
		}
		public bool _IsSetNumberOfRequest
		{
			get { return _isSetNumberOfRequest; }
		}
		public bool RequestStatus
		{
			get
			{
				return _requestStatus;
			}
			set
			{
				_requestStatusNull = false;
				_isSetRequestStatus = true;
				_requestStatus = value;
			}
		}
		public bool IsRequestStatusNull
		{
			get {
				 return _requestStatusNull; }
			set { _requestStatusNull = value; }
		}
		public bool _IsSetRequestStatus
		{
			get { return _isSetRequestStatus; }
		}
		public string CourtDecree
		{
			get { return _courtDecree; }
			set { _courtDecree = value;
			      _isSetCourtDecree = true; }
		}
		public bool _IsSetCourtDecree
		{
			get { return _isSetCourtDecree; }
		}
		public string Cause
		{
			get { return _cause; }
			set { _cause = value;
			      _isSetCause = true; }
		}
		public bool _IsSetCause
		{
			get { return _isSetCause; }
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
	public class CaseRequestBailData
	{
		private int _caseID;
		private int _applicantID;
		private int _numberOfRequest;
		private bool _requestStatus;
		private string _courtDecree;
		private string _cause;
		private DateTime _modifiedDate;
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
		public int NumberOfRequest
		{
			get{ return _numberOfRequest; }
			set{ _numberOfRequest = value; }
		}
		public bool RequestStatus
		{
			get{ return _requestStatus; }
			set{ _requestStatus = value; }
		}
		public string CourtDecree
		{
			get{ return _courtDecree; }
			set{ _courtDecree = value; }
		}
		public string Cause
		{
			get{ return _cause; }
			set{ _cause = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseRequestBailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseRequestBailRow[] caseRequestBailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseRequestBailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseRequestBailItems : CaseRequestBailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseRequestBailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseRequestBailItems[] caseRequestBailItems { get; set; }
	}
}

