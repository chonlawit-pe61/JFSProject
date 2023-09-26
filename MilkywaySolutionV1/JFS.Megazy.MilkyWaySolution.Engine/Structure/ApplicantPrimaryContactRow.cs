using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantPrimaryContactRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
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
		public DateTime CreateDate
		{
			get { return _createDate; }
			set { _createDate = value;
			      _createDateNull = false;
			      _isMapRecord = false;
			      _isSetCreateDate = true; }
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public Boolean _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
	}
	[Serializable]
	public class ApplicantPrimaryContactData
	{
		private int _applicantID;
		private int _caseID;
		private DateTime _createDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantPrimaryContactPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantPrimaryContactRow[] applicantPrimaryContactRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantPrimaryContactItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantPrimaryContactItems : ApplicantPrimaryContactData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantPrimaryContactItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantPrimaryContactItems[] applicantPrimaryContactItems { get; set; }
	}
}

