using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_InboxUserRow
	{
		private int _inboxiD;
		private bool _isSetInboxID = false;
		private string _messageType;
		private bool _isSetMessageType = false;
		private string _subject;
		private bool _isSetSubject = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _publishDate;
		private bool _isSetPublishDate = false;
		private bool _publishDateNull = true;
		private string _externalLink;
		private bool _isSetExternalLink = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private int _userID;
		private bool _isSetUserID = false;
		private bool _isRead;
		private bool _isSetIsRead = false;
		private bool _isReadNull = true;
		private bool _isSync;
		private bool _isSetIsSync = false;
		private bool _isSyncNull = true;
		[Required]
		public int InboxID
		{
			get { return _inboxiD; }
			set { _inboxiD = value;
			      _isSetInboxID = true; }
		}
		public bool _IsSetInboxID
		{
			get { return _isSetInboxID; }
		}
		[Required]
		public string MessageType
		{
			get { return _messageType; }
			set { _messageType = value;
			      _isSetMessageType = true; }
		}
		public bool _IsSetMessageType
		{
			get { return _isSetMessageType; }
		}
		[Required]
		public string Subject
		{
			get { return _subject; }
			set { _subject = value;
			      _isSetSubject = true; }
		}
		public bool _IsSetSubject
		{
			get { return _isSetSubject; }
		}
		[Required]
		public DateTime CreateDate
		{
			get { return _createDate; }
			set { _createDate = value;
			      _createDateNull = false;
			      _isSetCreateDate = true; }
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
		public DateTime PublishDate
		{
			get
			{
				return _publishDate;
			}
			set
			{
				_publishDateNull = false;
				_isSetPublishDate = true;
				_publishDate = value;
			}
		}
		public bool IsPublishDateNull
		{
			get {
				 return _publishDateNull; }
			set { _publishDateNull = value; }
		}
		public bool _IsSetPublishDate
		{
			get { return _isSetPublishDate; }
		}
		public string ExternalLink
		{
			get { return _externalLink; }
			set { _externalLink = value;
			      _isSetExternalLink = true; }
		}
		public bool _IsSetExternalLink
		{
			get { return _isSetExternalLink; }
		}
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
		public bool IsRead
		{
			get
			{
				return _isRead;
			}
			set
			{
				_isReadNull = false;
				_isSetIsRead = true;
				_isRead = value;
			}
		}
		public bool IsIsReadNull
		{
			get {
				 return _isReadNull; }
			set { _isReadNull = value; }
		}
		public bool _IsSetIsRead
		{
			get { return _isSetIsRead; }
		}
		public bool IsSync
		{
			get
			{
				return _isSync;
			}
			set
			{
				_isSyncNull = false;
				_isSetIsSync = true;
				_isSync = value;
			}
		}
		public bool IsIsSyncNull
		{
			get {
				 return _isSyncNull; }
			set { _isSyncNull = value; }
		}
		public bool _IsSetIsSync
		{
			get { return _isSetIsSync; }
		}
	}
	[Serializable]
	public class View_InboxUserData
	{
		private int _inboxiD;
		private string _messageType;
		private string _subject;
		private DateTime _createDate;
		private DateTime _publishDate;
		private string _externalLink;
		private bool _isActive;
		private int _userID;
		private bool _isRead;
		private bool _isSync;
		public int InboxID
		{
			get{ return _inboxiD; }
			set{ _inboxiD = value; }
		}
		public string MessageType
		{
			get{ return _messageType; }
			set{ _messageType = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string CreateDateStr { get; set; }
		public DateTime PublishDate
		{
			get{ return _publishDate; }
			set{ _publishDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string PublishDateStr { get; set; }
		public string ExternalLink
		{
			get{ return _externalLink; }
			set{ _externalLink = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public bool IsRead
		{
			get{ return _isRead; }
			set{ _isRead = value; }
		}
		public bool IsSync
		{
			get{ return _isSync; }
			set{ _isSync = value; }
		}
	}
	[Serializable]
	public class View_InboxUserPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_InboxUserRow[] view_InboxUserRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_InboxUserItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_InboxUserItems : View_InboxUserData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_InboxUserItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_InboxUserItems[] view_InboxUserItems { get; set; }
	}
}

