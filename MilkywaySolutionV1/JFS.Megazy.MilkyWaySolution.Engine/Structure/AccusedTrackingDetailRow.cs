using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class AccusedTrackingDetailRow
	{
		private int _trackingID;
		private bool _isSetTrackingID = false;
		private int _accusedTrackingID;
		private bool _isSetAccusedTrackingID = false;
		private string _trackingCode;
		private bool _isSetTrackingCode = false;
		private DateTime _duedate;
		private bool _isSetDueDate = false;
		private bool _duedateNull = true;
		private DateTime _reportDate;
		private bool _isSetReportDate = false;
		private bool _reportDateNull = true;
		private string _reportToOfficerName;
		private bool _isSetReportToOfficerName = false;
		private string _reportAtCode;
		private bool _isSetReportAtCode = false;
		private string _locationName;
		private bool _isSetLocationName = false;
		private string _note;
		private bool _isSetNote = false;
		private int _userID;
		private bool _isSetUserID = false;
		private bool _userIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int TrackingID
		{
			get { return _trackingID; }
			set { _trackingID = value;
			      _isSetTrackingID = true; }
		}
		public bool _IsSetTrackingID
		{
			get { return _isSetTrackingID; }
		}
		[Required]
		public int AccusedTrackingID
		{
			get { return _accusedTrackingID; }
			set { _accusedTrackingID = value;
			      _isSetAccusedTrackingID = true; }
		}
		public bool _IsSetAccusedTrackingID
		{
			get { return _isSetAccusedTrackingID; }
		}
		public string TrackingCode
		{
			get { return _trackingCode; }
			set { _trackingCode = value;
			      _isSetTrackingCode = true; }
		}
		public bool _IsSetTrackingCode
		{
			get { return _isSetTrackingCode; }
		}
		[Required]
		public DateTime DueDate
		{
			get { return _duedate; }
			set { _duedate = value;
			      _duedateNull = false;
			      _isSetDueDate = true; }
		}
		public bool IsDueDateNull
		{
			get {
				 return _duedateNull; }
			set { _duedateNull = value; }
		}
		public bool _IsSetDueDate
		{
			get { return _isSetDueDate; }
		}
		public DateTime ReportDate
		{
			get
			{
				return _reportDate;
			}
			set
			{
				_reportDateNull = false;
				_isSetReportDate = true;
				_reportDate = value;
			}
		}
		public bool IsReportDateNull
		{
			get {
				 return _reportDateNull; }
			set { _reportDateNull = value; }
		}
		public bool _IsSetReportDate
		{
			get { return _isSetReportDate; }
		}
		public string ReportToOfficerName
		{
			get { return _reportToOfficerName; }
			set { _reportToOfficerName = value;
			      _isSetReportToOfficerName = true; }
		}
		public bool _IsSetReportToOfficerName
		{
			get { return _isSetReportToOfficerName; }
		}
		public string ReportAtCode
		{
			get { return _reportAtCode; }
			set { _reportAtCode = value;
			      _isSetReportAtCode = true; }
		}
		public bool _IsSetReportAtCode
		{
			get { return _isSetReportAtCode; }
		}
		public string LocationName
		{
			get { return _locationName; }
			set { _locationName = value;
			      _isSetLocationName = true; }
		}
		public bool _IsSetLocationName
		{
			get { return _isSetLocationName; }
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
		public int UserID
		{
			get
			{
				return _userID;
			}
			set
			{
				_userIDNull = false;
				_isSetUserID = true;
				_userID = value;
			}
		}
		public bool IsUserIDNull
		{
			get {
				 return _userIDNull; }
			set { _userIDNull = value; }
		}
		public bool _IsSetUserID
		{
			get { return _isSetUserID; }
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
	public class AccusedTrackingDetailData
	{
		private int _trackingID;
		private int _accusedTrackingID;
		private string _trackingCode;
		private DateTime _duedate;
		private DateTime _reportDate;
		private string _reportToOfficerName;
		private string _reportAtCode;
		private string _locationName;
		private string _note;
		private int _userID;
		private DateTime _modifiedDate;
		public int TrackingID
		{
			get{ return _trackingID; }
			set{ _trackingID = value; }
		}
		public int AccusedTrackingID
		{
			get{ return _accusedTrackingID; }
			set{ _accusedTrackingID = value; }
		}
		public string TrackingCode
		{
			get{ return _trackingCode; }
			set{ _trackingCode = value; }
		}
		public DateTime DueDate
		{
			get{ return _duedate; }
			set{ _duedate = value; }
		}
		public string DueDateStr { get; set; }
		public DateTime ReportDate
		{
			get{ return _reportDate; }
			set{ _reportDate = value; }
		}
		public string ReportDateStr { get; set; }
		public string ReportToOfficerName
		{
			get{ return _reportToOfficerName; }
			set{ _reportToOfficerName = value; }
		}
		public string ReportAtCode
		{
			get{ return _reportAtCode; }
			set{ _reportAtCode = value; }
		}
		public string LocationName
		{
			get{ return _locationName; }
			set{ _locationName = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class AccusedTrackingDetailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public AccusedTrackingDetailRow[] accusedTrackingDetailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส AccusedTrackingDetailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class AccusedTrackingDetailItems : AccusedTrackingDetailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class AccusedTrackingDetailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public AccusedTrackingDetailItems[] accusedTrackingDetailItems { get; set; }
	}
}

