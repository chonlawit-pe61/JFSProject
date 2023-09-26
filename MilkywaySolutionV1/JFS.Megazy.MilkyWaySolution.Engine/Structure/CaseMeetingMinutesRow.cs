using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseMeetingMinutesRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _isReview;
		private bool _isSetIsReview = false;
		private bool _isAdditional;
		private bool _isSetIsAdditional = false;
		private DateTime _meetingDate;
		private bool _isSetMeetingDate = false;
		private bool _meetingDateNull = true;
		private string _meetingResults;
		private bool _isSetMeetingResults = false;
		private string _times;
		private bool _isSetTimes = false;
		private string _meetingPlace;
		private bool _isSetMeetingPlace = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _note;
		private bool _isSetNote = false;
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
		public bool IsReview
		{
			get { return _isReview; }
			set { _isReview = value;
			      _isSetIsReview = true; }
		}
		public bool _IsSetIsReview
		{
			get { return _isSetIsReview; }
		}
		[Required]
		public bool IsAdditional
		{
			get { return _isAdditional; }
			set { _isAdditional = value;
			      _isSetIsAdditional = true; }
		}
		public bool _IsSetIsAdditional
		{
			get { return _isSetIsAdditional; }
		}
		public DateTime MeetingDate
		{
			get
			{
				return _meetingDate;
			}
			set
			{
				_meetingDateNull = false;
				_isSetMeetingDate = true;
				_meetingDate = value;
			}
		}
		public bool IsMeetingDateNull
		{
			get {
				 return _meetingDateNull; }
			set { _meetingDateNull = value; }
		}
		public bool _IsSetMeetingDate
		{
			get { return _isSetMeetingDate; }
		}
		public string MeetingResults
		{
			get { return _meetingResults; }
			set { _meetingResults = value;
			      _isSetMeetingResults = true; }
		}
		public bool _IsSetMeetingResults
		{
			get { return _isSetMeetingResults; }
		}
		public string Times
		{
			get { return _times; }
			set { _times = value;
			      _isSetTimes = true; }
		}
		public bool _IsSetTimes
		{
			get { return _isSetTimes; }
		}
		public string MeetingPlace
		{
			get { return _meetingPlace; }
			set { _meetingPlace = value;
			      _isSetMeetingPlace = true; }
		}
		public bool _IsSetMeetingPlace
		{
			get { return _isSetMeetingPlace; }
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
	}
	[Serializable]
	public class CaseMeetingMinutesData
	{
		private int _caseID;
		private int _applicantID;
		private bool _isReview;
		private bool _isAdditional;
		private DateTime _meetingDate;
		private string _meetingResults;
		private string _times;
		private string _meetingPlace;
		private DateTime _modifiedDate;
		private string _note;
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
		public bool IsReview
		{
			get{ return _isReview; }
			set{ _isReview = value; }
		}
		public bool IsAdditional
		{
			get{ return _isAdditional; }
			set{ _isAdditional = value; }
		}
		public DateTime MeetingDate
		{
			get{ return _meetingDate; }
			set{ _meetingDate = value; }
		}
		public string MeetingDateStr { get; set; }
		public string MeetingResults
		{
			get{ return _meetingResults; }
			set{ _meetingResults = value; }
		}
		public string Times
		{
			get{ return _times; }
			set{ _times = value; }
		}
		public string MeetingPlace
		{
			get{ return _meetingPlace; }
			set{ _meetingPlace = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
	}
	[Serializable]
	public class CaseMeetingMinutesPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseMeetingMinutesRow[] caseMeetingMinutesRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseMeetingMinutesItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseMeetingMinutesItems : CaseMeetingMinutesData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseMeetingMinutesItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseMeetingMinutesItems[] caseMeetingMinutesItems { get; set; }
	}
}

