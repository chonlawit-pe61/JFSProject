using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantOfficerOpinionRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _applicantSummary;
		private bool _isSetApplicantSummary = false;
		private string _circumstance;
		private bool _isSetCircumstance = false;
		private string _consideration;
		private bool _isSetConsideration = false;
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
		public string ApplicantSummary
		{
			get { return _applicantSummary; }
			set { _applicantSummary = value;
			      _isSetApplicantSummary = true; }
		}
		public bool _IsSetApplicantSummary
		{
			get { return _isSetApplicantSummary; }
		}
		public string Circumstance
		{
			get { return _circumstance; }
			set { _circumstance = value;
			      _isSetCircumstance = true; }
		}
		public bool _IsSetCircumstance
		{
			get { return _isSetCircumstance; }
		}
		public string Consideration
		{
			get { return _consideration; }
			set { _consideration = value;
			      _isSetConsideration = true; }
		}
		public bool _IsSetConsideration
		{
			get { return _isSetConsideration; }
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
	public class CaseApplicantOfficerOpinionData
	{
		private int _applicantID;
		private string _applicantSummary;
		private string _circumstance;
		private string _consideration;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string ApplicantSummary
		{
			get{ return _applicantSummary; }
			set{ _applicantSummary = value; }
		}
		public string Circumstance
		{
			get{ return _circumstance; }
			set{ _circumstance = value; }
		}
		public string Consideration
		{
			get{ return _consideration; }
			set{ _consideration = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApplicantOfficerOpinionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantOfficerOpinionRow[] caseApplicantOfficerOpinionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantOfficerOpinionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantOfficerOpinionItems : CaseApplicantOfficerOpinionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantOfficerOpinionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantOfficerOpinionItems[] caseApplicantOfficerOpinionItems { get; set; }
	}
}

