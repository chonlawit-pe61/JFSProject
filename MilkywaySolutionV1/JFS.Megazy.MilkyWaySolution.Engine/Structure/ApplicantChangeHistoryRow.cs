using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantChangeHistoryRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private DateTime _changeDate;
		private bool _isSetChangeDate = false;
		private bool _changeDateNull = true;
		private string _comment;
		private bool _isSetComment = false;
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
		public int UserID
		{
			get { return _userID; }
			set { _userID = value;
			      _isSetUserID = true; }
		}
		public bool _IsSetUserID
		{
			get { return _isSetUserID; }
		}
		[Required]
		public DateTime ChangeDate
		{
			get { return _changeDate; }
			set { _changeDate = value;
			      _changeDateNull = false;
			      _isSetChangeDate = true; }
		}
		public bool IsChangeDateNull
		{
			get {
				 return _changeDateNull; }
			set { _changeDateNull = value; }
		}
		public bool _IsSetChangeDate
		{
			get { return _isSetChangeDate; }
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
	public class ApplicantChangeHistoryData
	{
		private int _applicantID;
		private int _userID;
		private DateTime _changeDate;
		private string _comment;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public DateTime ChangeDate
		{
			get{ return _changeDate; }
			set{ _changeDate = value; }
		}
		public string ChangeDateStr { get; set; }
		public string Comment
		{
			get{ return _comment; }
			set{ _comment = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantChangeHistoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantChangeHistoryRow[] applicantChangeHistoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantChangeHistoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantChangeHistoryItems : ApplicantChangeHistoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantChangeHistoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantChangeHistoryItems[] applicantChangeHistoryItems { get; set; }
	}
}

