using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseCreditScoringRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _topicID;
		private bool _isSetTopicID = false;
		private int _choiceID;
		private bool _isSetChoiceID = false;
		private string _other;
		private bool _isSetOther = false;
		private bool _otherNull = true;
		private int _totalScoretopic;
		private bool _isSetTotalScoreTopic = false;
		private bool _totalScoretopicNull = true;
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
		[Required]
		public int TopicID
		{
			get { return _topicID; }
			set { _topicID = value;
			      _isMapRecord = false;
			      _isSetTopicID = true; }
		}
		public Boolean _IsSetTopicID
		{
			get { return _isSetTopicID; }
		}
		[Required]
		public int ChoiceID
		{
			get { return _choiceID; }
			set { _choiceID = value;
			      _isMapRecord = false;
			      _isSetChoiceID = true; }
		}
		public Boolean _IsSetChoiceID
		{
			get { return _isSetChoiceID; }
		}
		public string Other
		{
			get
			{
				return _other;
			}
			set
			{
				_otherNull = false;
				_isSetOther = true;
				_other = value;
				_isMapRecord = false;
			}
		}
		public bool IsOtherNull
		{
			get {
				 return _otherNull; }
			set { _otherNull = value; }
		}
		public Boolean _IsSetOther
		{
			get { return _isSetOther; }
		}
		public int TotalScoreTopic
		{
			get
			{
				return _totalScoretopic;
			}
			set
			{
				_totalScoretopicNull = false;
				_isSetTotalScoreTopic = true;
				_totalScoretopic = value;
				_isMapRecord = false;
			}
		}
		public bool IsTotalScoreTopicNull
		{
			get {
				 return _totalScoretopicNull; }
			set { _totalScoretopicNull = value; }
		}
		public Boolean _IsSetTotalScoreTopic
		{
			get { return _isSetTotalScoreTopic; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isMapRecord = false;
			      _isSetModifiedDate = true; }
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
	public class CaseCreditScoringData
	{
		private int _caseID;
		private int _applicantID;
		private int _topicID;
		private int _choiceID;
		private string _other;
		private int _totalScoretopic;
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
		public int TopicID
		{
			get{ return _topicID; }
			set{ _topicID = value; }
		}
		public int ChoiceID
		{
			get{ return _choiceID; }
			set{ _choiceID = value; }
		}
		public string Other
		{
			get{ return _other; }
			set{ _other = value; }
		}
		public int TotalScoreTopic
		{
			get{ return _totalScoretopic; }
			set{ _totalScoretopic = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
	}
	[Serializable]
	public class CaseCreditScoringPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseCreditScoringRow[] casecreditScoringRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseCreditScoringItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseCreditScoringItems : CaseCreditScoringData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseCreditScoringItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseCreditScoringItems[] casecreditScoringItems { get; set; }
	}
}

