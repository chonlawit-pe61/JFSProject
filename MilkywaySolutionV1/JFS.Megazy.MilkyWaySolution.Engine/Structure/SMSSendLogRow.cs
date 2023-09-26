using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class SMSSendLogRow
	{
		private string _messageID;
		private bool _isSetMessageID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private string _sendTo;
		private bool _isSetSendTo = false;
		private string _telephoneNumber;
		private bool _isSetTelephoneNumber = false;
		private bool _isOTP;
		private bool _isSetIsOTP = false;
		private bool _isOTPNull = true;
		private string _message;
		private bool _isSetMessage = false;
		private DateTime _sendDate;
		private bool _isSetSendDate = false;
		private bool _sendDateNull = true;
		private bool _sendstatus;
		private bool _isSetSendStatus = false;
		private bool _sendstatusNull = true;
		private string _sendType;
		private bool _isSetSendType = false;
		private string _sendNote;
		private bool _isSetSendNote = false;
		private string _sendstatusName;
		private bool _isSetSendStatusName = false;
		private int _usedCredit;
		private bool _isSetUsedCredit = false;
		private bool _usedCreditNull = true;
		private int _remainCredit;
		private bool _isSetRemainCredit = false;
		private bool _remainCreditNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public string MessageID
		{
			get { return _messageID; }
			set { _messageID = value;
			      _isSetMessageID = true; }
		}
		public bool _IsSetMessageID
		{
			get { return _isSetMessageID; }
		}
		public int ApplicantID
		{
			get
			{
				return _applicantID;
			}
			set
			{
				_applicantIDNull = false;
				_isSetApplicantID = true;
				_applicantID = value;
			}
		}
		public bool IsApplicantIDNull
		{
			get {
				 return _applicantIDNull; }
			set { _applicantIDNull = value; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public int CaseID
		{
			get
			{
				return _caseID;
			}
			set
			{
				_caseIDNull = false;
				_isSetCaseID = true;
				_caseID = value;
			}
		}
		public bool IsCaseIDNull
		{
			get {
				 return _caseIDNull; }
			set { _caseIDNull = value; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public string SendTo
		{
			get { return _sendTo; }
			set { _sendTo = value;
			      _isSetSendTo = true; }
		}
		public bool _IsSetSendTo
		{
			get { return _isSetSendTo; }
		}
		public string TelephoneNumber
		{
			get { return _telephoneNumber; }
			set { _telephoneNumber = value;
			      _isSetTelephoneNumber = true; }
		}
		public bool _IsSetTelephoneNumber
		{
			get { return _isSetTelephoneNumber; }
		}
		public bool IsOTP
		{
			get
			{
				return _isOTP;
			}
			set
			{
				_isOTPNull = false;
				_isSetIsOTP = true;
				_isOTP = value;
			}
		}
		public bool IsIsOTPNull
		{
			get {
				 return _isOTPNull; }
			set { _isOTPNull = value; }
		}
		public bool _IsSetIsOTP
		{
			get { return _isSetIsOTP; }
		}
		public string Message
		{
			get { return _message; }
			set { _message = value;
			      _isSetMessage = true; }
		}
		public bool _IsSetMessage
		{
			get { return _isSetMessage; }
		}
		public DateTime SendDate
		{
			get
			{
				return _sendDate;
			}
			set
			{
				_sendDateNull = false;
				_isSetSendDate = true;
				_sendDate = value;
			}
		}
		public bool IsSendDateNull
		{
			get {
				 return _sendDateNull; }
			set { _sendDateNull = value; }
		}
		public bool _IsSetSendDate
		{
			get { return _isSetSendDate; }
		}
		public bool SendStatus
		{
			get
			{
				return _sendstatus;
			}
			set
			{
				_sendstatusNull = false;
				_isSetSendStatus = true;
				_sendstatus = value;
			}
		}
		public bool IsSendStatusNull
		{
			get {
				 return _sendstatusNull; }
			set { _sendstatusNull = value; }
		}
		public bool _IsSetSendStatus
		{
			get { return _isSetSendStatus; }
		}
		public string SendType
		{
			get { return _sendType; }
			set { _sendType = value;
			      _isSetSendType = true; }
		}
		public bool _IsSetSendType
		{
			get { return _isSetSendType; }
		}
		public string SendNote
		{
			get { return _sendNote; }
			set { _sendNote = value;
			      _isSetSendNote = true; }
		}
		public bool _IsSetSendNote
		{
			get { return _isSetSendNote; }
		}
		public string SendStatusName
		{
			get { return _sendstatusName; }
			set { _sendstatusName = value;
			      _isSetSendStatusName = true; }
		}
		public bool _IsSetSendStatusName
		{
			get { return _isSetSendStatusName; }
		}
		public int UsedCredit
		{
			get
			{
				return _usedCredit;
			}
			set
			{
				_usedCreditNull = false;
				_isSetUsedCredit = true;
				_usedCredit = value;
			}
		}
		public bool IsUsedCreditNull
		{
			get {
				 return _usedCreditNull; }
			set { _usedCreditNull = value; }
		}
		public bool _IsSetUsedCredit
		{
			get { return _isSetUsedCredit; }
		}
		public int RemainCredit
		{
			get
			{
				return _remainCredit;
			}
			set
			{
				_remainCreditNull = false;
				_isSetRemainCredit = true;
				_remainCredit = value;
			}
		}
		public bool IsRemainCreditNull
		{
			get {
				 return _remainCreditNull; }
			set { _remainCreditNull = value; }
		}
		public bool _IsSetRemainCredit
		{
			get { return _isSetRemainCredit; }
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
	public class SMSSendLogData
	{
		private string _messageID;
		private int _applicantID;
		private int _caseID;
		private string _sendTo;
		private string _telephoneNumber;
		private bool _isOTP;
		private string _message;
		private DateTime _sendDate;
		private bool _sendstatus;
		private string _sendType;
		private string _sendNote;
		private string _sendstatusName;
		private int _usedCredit;
		private int _remainCredit;
		private DateTime _modifiedDate;
		public string MessageID
		{
			get{ return _messageID; }
			set{ _messageID = value; }
		}
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
		public string SendTo
		{
			get{ return _sendTo; }
			set{ _sendTo = value; }
		}
		public string TelephoneNumber
		{
			get{ return _telephoneNumber; }
			set{ _telephoneNumber = value; }
		}
		public bool IsOTP
		{
			get{ return _isOTP; }
			set{ _isOTP = value; }
		}
		public string Message
		{
			get{ return _message; }
			set{ _message = value; }
		}
		public DateTime SendDate
		{
			get{ return _sendDate; }
			set{ _sendDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string SendDateStr { get; set; }
		public bool SendStatus
		{
			get{ return _sendstatus; }
			set{ _sendstatus = value; }
		}
		public string SendType
		{
			get{ return _sendType; }
			set{ _sendType = value; }
		}
		public string SendNote
		{
			get{ return _sendNote; }
			set{ _sendNote = value; }
		}
		public string SendStatusName
		{
			get{ return _sendstatusName; }
			set{ _sendstatusName = value; }
		}
		public int UsedCredit
		{
			get{ return _usedCredit; }
			set{ _usedCredit = value; }
		}
		public int RemainCredit
		{
			get{ return _remainCredit; }
			set{ _remainCredit = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class SMSSendLogPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SMSSendLogRow[] sMssendLogRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SMSSendLogItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SMSSendLogItems : SMSSendLogData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SMSSendLogItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SMSSendLogItems[] sMssendLogItems { get; set; }
	}
}

