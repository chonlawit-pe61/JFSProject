using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantOpinionRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private bool _isAppeal;
		private bool _isSetIsAppeal = false;
		private int _termID;
		private bool _isSetTermID = false;
		private bool _termIDNull = true;
		private bool _isFinalApproved;
		private bool _isSetIsFinalApproved = false;
		private bool _isFinalApprovedNull = true;
		private int _opinionID;
		private bool _isSetOpinionID = false;
		private bool _opinionIDNull = true;
		private string _additionalOpinion;
		private bool _isSetAdditionalOpinion = false;
		private string _comment;
		private bool _isSetComment = false;
		private string _shortComment;
		private bool _isSetShortComment = false;
		private string _remark;
		private bool _isSetRemark = false;
		private DateTime _issueDate;
		private bool _isSetIssueDate = false;
		private bool _issueDateNull = true;
		private DateTime _completeDate;
		private bool _isSetCompleteDate = false;
		private bool _completeDateNull = true;
		private bool _isAgree;
		private bool _isSetIsAgree = false;
		private bool _isAgreeNull = true;
		private int _followAsOfficerRoleID;
		private bool _isSetFollowAsOfficerRoleID = false;
		private bool _followAsOfficerRoleIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public int OfficerRoleID
		{
			get { return _officerRoleID; }
			set { _officerRoleID = value;
			      _isSetOfficerRoleID = true; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
		}
		[Required]
		public bool IsAppeal
		{
			get { return _isAppeal; }
			set { _isAppeal = value;
			      _isSetIsAppeal = true; }
		}
		public bool _IsSetIsAppeal
		{
			get { return _isSetIsAppeal; }
		}
		public int TermID
		{
			get
			{
				return _termID;
			}
			set
			{
				_termIDNull = false;
				_isSetTermID = true;
				_termID = value;
			}
		}
		public bool IsTermIDNull
		{
			get {
				 return _termIDNull; }
			set { _termIDNull = value; }
		}
		public bool _IsSetTermID
		{
			get { return _isSetTermID; }
		}
		public bool IsFinalApproved
		{
			get
			{
				return _isFinalApproved;
			}
			set
			{
				_isFinalApprovedNull = false;
				_isSetIsFinalApproved = true;
				_isFinalApproved = value;
			}
		}
		public bool IsIsFinalApprovedNull
		{
			get {
				 return _isFinalApprovedNull; }
			set { _isFinalApprovedNull = value; }
		}
		public bool _IsSetIsFinalApproved
		{
			get { return _isSetIsFinalApproved; }
		}
		public int OpinionID
		{
			get
			{
				return _opinionID;
			}
			set
			{
				_opinionIDNull = false;
				_isSetOpinionID = true;
				_opinionID = value;
			}
		}
		public bool IsOpinionIDNull
		{
			get {
				 return _opinionIDNull; }
			set { _opinionIDNull = value; }
		}
		public bool _IsSetOpinionID
		{
			get { return _isSetOpinionID; }
		}
		public string AdditionalOpinion
		{
			get { return _additionalOpinion; }
			set { _additionalOpinion = value;
			      _isSetAdditionalOpinion = true; }
		}
		public bool _IsSetAdditionalOpinion
		{
			get { return _isSetAdditionalOpinion; }
		}
		public string Comment
		{
			get { return _comment; }
			set { _comment = value;
			      _isSetComment = true; }
		}
		public bool _IsSetComment
		{
			get { return _isSetComment; }
		}
		public string ShortComment
		{
			get { return _shortComment; }
			set { _shortComment = value;
			      _isSetShortComment = true; }
		}
		public bool _IsSetShortComment
		{
			get { return _isSetShortComment; }
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
		public DateTime IssueDate
		{
			get
			{
				return _issueDate;
			}
			set
			{
				_issueDateNull = false;
				_isSetIssueDate = true;
				_issueDate = value;
			}
		}
		public bool IsIssueDateNull
		{
			get {
				 return _issueDateNull; }
			set { _issueDateNull = value; }
		}
		public bool _IsSetIssueDate
		{
			get { return _isSetIssueDate; }
		}
		public DateTime CompleteDate
		{
			get
			{
				return _completeDate;
			}
			set
			{
				_completeDateNull = false;
				_isSetCompleteDate = true;
				_completeDate = value;
			}
		}
		public bool IsCompleteDateNull
		{
			get {
				 return _completeDateNull; }
			set { _completeDateNull = value; }
		}
		public bool _IsSetCompleteDate
		{
			get { return _isSetCompleteDate; }
		}
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
		public int FollowAsOfficerRoleID
		{
			get
			{
				return _followAsOfficerRoleID;
			}
			set
			{
				_followAsOfficerRoleIDNull = false;
				_isSetFollowAsOfficerRoleID = true;
				_followAsOfficerRoleID = value;
			}
		}
		public bool IsFollowAsOfficerRoleIDNull
		{
			get {
				 return _followAsOfficerRoleIDNull; }
			set { _followAsOfficerRoleIDNull = value; }
		}
		public bool _IsSetFollowAsOfficerRoleID
		{
			get { return _isSetFollowAsOfficerRoleID; }
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
	public class CaseApplicantOpinionData
	{
		private int _applicantID;
		private int _officerRoleID;
		private bool _isAppeal;
		private int _termID;
		private bool _isFinalApproved;
		private int _opinionID;
		private string _additionalOpinion;
		private string _comment;
		private string _shortComment;
		private string _remark;
		private DateTime _issueDate;
		private DateTime _completeDate;
		private bool _isAgree;
		private int _followAsOfficerRoleID;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public bool IsAppeal
		{
			get{ return _isAppeal; }
			set{ _isAppeal = value; }
		}
		public int TermID
		{
			get{ return _termID; }
			set{ _termID = value; }
		}
		public bool IsFinalApproved
		{
			get{ return _isFinalApproved; }
			set{ _isFinalApproved = value; }
		}
		public int OpinionID
		{
			get{ return _opinionID; }
			set{ _opinionID = value; }
		}
		public string AdditionalOpinion
		{
			get{ return _additionalOpinion; }
			set{ _additionalOpinion = value; }
		}
		public string Comment
		{
			get{ return _comment; }
			set{ _comment = value; }
		}
		public string ShortComment
		{
			get{ return _shortComment; }
			set{ _shortComment = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
		public DateTime IssueDate
		{
			get{ return _issueDate; }
			set{ _issueDate = value; }
		}
		public string IssueDateStr { get; set; }
		public DateTime CompleteDate
		{
			get{ return _completeDate; }
			set{ _completeDate = value; }
		}
		public string CompleteDateStr { get; set; }
		public bool IsAgree
		{
			get{ return _isAgree; }
			set{ _isAgree = value; }
		}
		public int FollowAsOfficerRoleID
		{
			get{ return _followAsOfficerRoleID; }
			set{ _followAsOfficerRoleID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApplicantOpinionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantOpinionRow[] caseApplicantOpinionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantOpinionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantOpinionItems : CaseApplicantOpinionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantOpinionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantOpinionItems[] caseApplicantOpinionItems { get; set; }
	}
}

