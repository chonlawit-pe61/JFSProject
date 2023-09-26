using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantPDPARow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _isPDPA;
		private bool _isSetIsPDPA = false;
		private bool _isPDPANull = true;
		private DateTime _acceptDate;
		private bool _isSetAcceptDate = false;
		private bool _acceptDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		[Required]
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isMapRecord = false;
			      _isSetApplicantID = true; }
		}
		public Boolean _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public bool IsPDPA
		{
			get
			{
				return _isPDPA;
			}
			set
			{
				_isPDPANull = false;
				_isSetIsPDPA = true;
				_isPDPA = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsPDPANull
		{
			get {
				 return _isPDPANull; }
			set { _isPDPANull = value; }
		}
		public Boolean _IsSetIsPDPA
		{
			get { return _isSetIsPDPA; }
		}
		public DateTime AcceptDate
		{
			get
			{
				return _acceptDate;
			}
			set
			{
				_acceptDateNull = false;
				_isSetAcceptDate = true;
				_acceptDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsAcceptDateNull
		{
			get {
				 return _acceptDateNull; }
			set { _acceptDateNull = value; }
		}
		public Boolean _IsSetAcceptDate
		{
			get { return _isSetAcceptDate; }
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class CaseApplicantPDPAData
	{
		private int _caseID;
		private int _applicantID;
		private bool _isPDPA;
		private DateTime _acceptDate;
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
		public bool IsPDPA
		{
			get{ return _isPDPA; }
			set{ _isPDPA = value; }
		}
		public DateTime AcceptDate
		{
			get{ return _acceptDate; }
			set{ _acceptDate = value; }
		}
		public string AcceptDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApplicantPDPAPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantPDPARow[] caseApplicantPDPARow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantPDPAItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantPDPAItems : CaseApplicantPDPAData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantPDPAItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantPDPAItems[] caseApplicantPDPAItems { get; set; }
	}
}

