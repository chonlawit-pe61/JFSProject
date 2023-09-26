using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class CaseApplicantReqCertificateRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _requestCertificateCode;
		private bool _isSetRequestCertificateCode = false;
		private bool _requestCertificateCodeNull = true;
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
		public string RequestCertificateCode
		{
			get
			{
				return _requestCertificateCode;
			}
			set
			{
				_requestCertificateCodeNull = false;
				_isSetRequestCertificateCode = true;
				_requestCertificateCode = value;
				_isMapRecord = false;
			}
		}
		public bool IsRequestCertificateCodeNull
		{
			get {
				 return _requestCertificateCodeNull; }
			set { _requestCertificateCodeNull = value; }
		}
		public Boolean _IsSetRequestCertificateCode
		{
			get { return _isSetRequestCertificateCode; }
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
	public class CaseApplicantReqCertificateData
	{
		private int _caseID;
		private int _applicantID;
		private string _requestCertificateCode;
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
		public string RequestCertificateCode
		{
			get{ return _requestCertificateCode; }
			set{ _requestCertificateCode = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApplicantReqCertificatePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantReqCertificateRow[] caseApplicantReqcertificateRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantReqCertificateItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantReqCertificateItems : CaseApplicantReqCertificateData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantReqCertificateItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantReqCertificateItems[] caseApplicantReqcertificateItems { get; set; }
	}
}

