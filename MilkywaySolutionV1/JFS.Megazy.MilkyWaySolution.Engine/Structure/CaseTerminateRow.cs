using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseTerminateRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _terminateID;
		private bool _isSetTerminateID = false;
		private DateTime _terminateDate;
		private bool _isSetTerminateDate = false;
		private bool _terminateDateNull = true;
		private string _causesOther;
		private bool _isSetCausesOther = false;
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
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isSetDepartmentID = true; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		[Required]
		public int TerminateID
		{
			get { return _terminateID; }
			set { _terminateID = value;
			      _isSetTerminateID = true; }
		}
		public bool _IsSetTerminateID
		{
			get { return _isSetTerminateID; }
		}
		public DateTime TerminateDate
		{
			get
			{
				return _terminateDate;
			}
			set
			{
				_terminateDateNull = false;
				_isSetTerminateDate = true;
				_terminateDate = value;
			}
		}
		public bool IsTerminateDateNull
		{
			get {
				 return _terminateDateNull; }
			set { _terminateDateNull = value; }
		}
		public bool _IsSetTerminateDate
		{
			get { return _isSetTerminateDate; }
		}
		public string CausesOther
		{
			get { return _causesOther; }
			set { _causesOther = value;
			      _isSetCausesOther = true; }
		}
		public bool _IsSetCausesOther
		{
			get { return _isSetCausesOther; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class CaseTerminateData
	{
		private int _caseID;
		private int _applicantID;
		private int _departmentId;
		private int _terminateID;
		private DateTime _terminateDate;
		private string _causesOther;
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
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int TerminateID
		{
			get{ return _terminateID; }
			set{ _terminateID = value; }
		}
		public DateTime TerminateDate
		{
			get{ return _terminateDate; }
			set{ _terminateDate = value; }
		}
		public string TerminateDateStr { get; set; }
		public string CausesOther
		{
			get{ return _causesOther; }
			set{ _causesOther = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseTerminatePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseTerminateRow[] caseTerminateRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseTerminateItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseTerminateItems : CaseTerminateData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseTerminateItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseTerminateItems[] caseTerminateItems { get; set; }
	}
}

