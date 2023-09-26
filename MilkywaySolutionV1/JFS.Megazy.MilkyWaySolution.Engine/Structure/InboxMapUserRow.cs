using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class InboxMapUserRow
	{
		private int _inboxiD;
		private bool _isSetInboxID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private bool _isRead;
		private bool _isSetIsRead = false;
		private bool _isReadNull = true;
		private bool _isSync;
		private bool _isSetIsSync = false;
		private bool _isSyncNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	public class InboxMapUserData
	{
		private int _inboxiD;
		private int _userID;
		private bool _isRead;
		private bool _isSync;
		private DateTime _modifiedDate;
		public int InboxID
		{
			get{ return _inboxiD; }
			set{ _inboxiD = value; }
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class InboxMapUserPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public InboxMapUserRow[] inboxMapUserRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส InboxMapUserItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class InboxMapUserItems : InboxMapUserData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class InboxMapUserItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public InboxMapUserItems[] inboxMapUserItems { get; set; }
	}
}

