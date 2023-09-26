using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseAppealRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private string _appealName;
		private bool _isSetAppealName = false;
		private DateTime _appealDate;
		private bool _isSetAppealDate = false;
		private bool _appealDateNull = true;
		private string _additionalIssue;
		private bool _isSetAdditionalIssue = false;
		private string _additionalFactsInIssue;
		private bool _isSetAdditionalFactsInIssue = false;
		private string _additionalOfficerOpinion;
		private bool _isSetAdditionalOfficerOpinion = false;
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
		public string AppealName
		{
			get { return _appealName; }
			set { _appealName = value;
			      _isSetAppealName = true; }
		}
		public bool _IsSetAppealName
		{
			get { return _isSetAppealName; }
		}
		public DateTime AppealDate
		{
			get
			{
				return _appealDate;
			}
			set
			{
				_appealDateNull = false;
				_isSetAppealDate = true;
				_appealDate = value;
			}
		}
		public bool IsAppealDateNull
		{
			get {
				 return _appealDateNull; }
			set { _appealDateNull = value; }
		}
		public bool _IsSetAppealDate
		{
			get { return _isSetAppealDate; }
		}
		public string AdditionalIssue
		{
			get { return _additionalIssue; }
			set { _additionalIssue = value;
			      _isSetAdditionalIssue = true; }
		}
		public bool _IsSetAdditionalIssue
		{
			get { return _isSetAdditionalIssue; }
		}
		public string AdditionalFactsInIssue
		{
			get { return _additionalFactsInIssue; }
			set { _additionalFactsInIssue = value;
			      _isSetAdditionalFactsInIssue = true; }
		}
		public bool _IsSetAdditionalFactsInIssue
		{
			get { return _isSetAdditionalFactsInIssue; }
		}
		public string AdditionalOfficerOpinion
		{
			get { return _additionalOfficerOpinion; }
			set { _additionalOfficerOpinion = value;
			      _isSetAdditionalOfficerOpinion = true; }
		}
		public bool _IsSetAdditionalOfficerOpinion
		{
			get { return _isSetAdditionalOfficerOpinion; }
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
	public class CaseAppealData
	{
		private int _caseID;
		private int _applicantID;
		private int _departmentId;
		private string _appealName;
		private DateTime _appealDate;
		private string _additionalIssue;
		private string _additionalFactsInIssue;
		private string _additionalOfficerOpinion;
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
		public string AppealName
		{
			get{ return _appealName; }
			set{ _appealName = value; }
		}
		public DateTime AppealDate
		{
			get{ return _appealDate; }
			set{ _appealDate = value; }
		}
		public string AppealDateStr { get; set; }
		public string AdditionalIssue
		{
			get{ return _additionalIssue; }
			set{ _additionalIssue = value; }
		}
		public string AdditionalFactsInIssue
		{
			get{ return _additionalFactsInIssue; }
			set{ _additionalFactsInIssue = value; }
		}
		public string AdditionalOfficerOpinion
		{
			get{ return _additionalOfficerOpinion; }
			set{ _additionalOfficerOpinion = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseAppealPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseAppealRow[] caseAppealRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseAppealItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseAppealItems : CaseAppealData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseAppealItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseAppealItems[] caseAppealItems { get; set; }
	}
}

