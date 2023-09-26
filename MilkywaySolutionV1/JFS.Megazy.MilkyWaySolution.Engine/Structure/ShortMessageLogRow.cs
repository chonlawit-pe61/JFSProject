using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ShortMessageLogRow
	{
		private string _messageID;
		private bool _isSetMessageID = false;
		private string _phonenumber;
		private bool _isSetPhonenumber = false;
		private string _shortMessage;
		private bool _isSetShortMessage = false;
		private string _senderName;
		private bool _isSetSenderName = false;
		private string _sendstatus;
		private bool _isSetSendStatus = false;
		private int _usedCredit;
		private bool _isSetUsedCredit = false;
		private bool _usedCreditNull = true;
		private int _remainCredit;
		private bool _isSetRemainCredit = false;
		private bool _remainCreditNull = true;
		private DateTime _dateCreated;
		private bool _isSetDateCreated = false;
		private bool _dateCreatedNull = true;
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
		[Required]
		public string Phonenumber
		{
			get { return _phonenumber; }
			set { _phonenumber = value;
			      _isSetPhonenumber = true; }
		}
		public bool _IsSetPhonenumber
		{
			get { return _isSetPhonenumber; }
		}
		public string ShortMessage
		{
			get { return _shortMessage; }
			set { _shortMessage = value;
			      _isSetShortMessage = true; }
		}
		public bool _IsSetShortMessage
		{
			get { return _isSetShortMessage; }
		}
		public string SenderName
		{
			get { return _senderName; }
			set { _senderName = value;
			      _isSetSenderName = true; }
		}
		public bool _IsSetSenderName
		{
			get { return _isSetSenderName; }
		}
		public string SendStatus
		{
			get { return _sendstatus; }
			set { _sendstatus = value;
			      _isSetSendStatus = true; }
		}
		public bool _IsSetSendStatus
		{
			get { return _isSetSendStatus; }
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
		[Required]
		public DateTime DateCreated
		{
			get { return _dateCreated; }
			set { _dateCreated = value;
			      _dateCreatedNull = false;
			      _isSetDateCreated = true; }
		}
		public bool IsDateCreatedNull
		{
			get {
				 return _dateCreatedNull; }
			set { _dateCreatedNull = value; }
		}
		public bool _IsSetDateCreated
		{
			get { return _isSetDateCreated; }
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
	public class ShortMessageLogData
	{
		private string _messageID;
		private string _phonenumber;
		private string _shortMessage;
		private string _senderName;
		private string _sendstatus;
		private int _usedCredit;
		private int _remainCredit;
		private DateTime _dateCreated;
		private DateTime _modifiedDate;
		public string MessageID
		{
			get{ return _messageID; }
			set{ _messageID = value; }
		}
		public string Phonenumber
		{
			get{ return _phonenumber; }
			set{ _phonenumber = value; }
		}
		public string ShortMessage
		{
			get{ return _shortMessage; }
			set{ _shortMessage = value; }
		}
		public string SenderName
		{
			get{ return _senderName; }
			set{ _senderName = value; }
		}
		public string SendStatus
		{
			get{ return _sendstatus; }
			set{ _sendstatus = value; }
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
		public DateTime DateCreated
		{
			get{ return _dateCreated; }
			set{ _dateCreated = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string DateCreatedStr { get; set; }
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
	public class ShortMessageLogPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ShortMessageLogRow[] shortMessageLogRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ShortMessageLogItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ShortMessageLogItems : ShortMessageLogData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ShortMessageLogItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ShortMessageLogItems[] shortMessageLogItems { get; set; }
	}
}

