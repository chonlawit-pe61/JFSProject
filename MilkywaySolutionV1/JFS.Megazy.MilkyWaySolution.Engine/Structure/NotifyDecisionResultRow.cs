using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class NotifyDecisionResultRow
	{
		private int _notifyID;
		private bool _isSetNotifyID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private DateTime _notifyDate;
		private bool _isSetNotifyDate = false;
		private bool _notifyDateNull = true;
		private bool _isSendSMS;
		private bool _isSetIsSendSMS = false;
		private bool _isSendSMSNull = true;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private bool _isSendEmail;
		private bool _isSetIsSendEmail = false;
		private bool _isSendEmailNull = true;
		private string _email;
		private bool _isSetEmail = false;
		private string _note;
		private bool _isSetNote = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int NotifyID
		{
			get { return _notifyID; }
			set { _notifyID = value;
			      _isSetNotifyID = true; }
		}
		public bool _IsSetNotifyID
		{
			get { return _isSetNotifyID; }
		}
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
		public DateTime NotifyDate
		{
			get
			{
				return _notifyDate;
			}
			set
			{
				_notifyDateNull = false;
				_isSetNotifyDate = true;
				_notifyDate = value;
			}
		}
		public bool IsNotifyDateNull
		{
			get {
				 return _notifyDateNull; }
			set { _notifyDateNull = value; }
		}
		public bool _IsSetNotifyDate
		{
			get { return _isSetNotifyDate; }
		}
		public bool IsSendSMS
		{
			get
			{
				return _isSendSMS;
			}
			set
			{
				_isSendSMSNull = false;
				_isSetIsSendSMS = true;
				_isSendSMS = value;
			}
		}
		public bool IsIsSendSMSNull
		{
			get {
				 return _isSendSMSNull; }
			set { _isSendSMSNull = value; }
		}
		public bool _IsSetIsSendSMS
		{
			get { return _isSetIsSendSMS; }
		}
		public string TelephoneNo
		{
			get { return _telephoneNo; }
			set { _telephoneNo = value;
			      _isSetTelephoneNo = true; }
		}
		public bool _IsSetTelephoneNo
		{
			get { return _isSetTelephoneNo; }
		}
		public bool IsSendEmail
		{
			get
			{
				return _isSendEmail;
			}
			set
			{
				_isSendEmailNull = false;
				_isSetIsSendEmail = true;
				_isSendEmail = value;
			}
		}
		public bool IsIsSendEmailNull
		{
			get {
				 return _isSendEmailNull; }
			set { _isSendEmailNull = value; }
		}
		public bool _IsSetIsSendEmail
		{
			get { return _isSetIsSendEmail; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value;
			      _isSetEmail = true; }
		}
		public bool _IsSetEmail
		{
			get { return _isSetEmail; }
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
	public class NotifyDecisionResultData
	{
		private int _notifyID;
		private int _caseID;
		private int _applicantID;
		private DateTime _notifyDate;
		private bool _isSendSMS;
		private string _telephoneNo;
		private bool _isSendEmail;
		private string _email;
		private string _note;
		private DateTime _modifiedDate;
		public int NotifyID
		{
			get{ return _notifyID; }
			set{ _notifyID = value; }
		}
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
		public DateTime NotifyDate
		{
			get{ return _notifyDate; }
			set{ _notifyDate = value; }
		}
		public string NotifyDateStr { get; set; }
		public bool IsSendSMS
		{
			get{ return _isSendSMS; }
			set{ _isSendSMS = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public bool IsSendEmail
		{
			get{ return _isSendEmail; }
			set{ _isSendEmail = value; }
		}
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class NotifyDecisionResultPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public NotifyDecisionResultRow[] notifyDecisionResultRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส NotifyDecisionResultItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class NotifyDecisionResultItems : NotifyDecisionResultData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class NotifyDecisionResultItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public NotifyDecisionResultItems[] notifyDecisionResultItems { get; set; }
	}
}

