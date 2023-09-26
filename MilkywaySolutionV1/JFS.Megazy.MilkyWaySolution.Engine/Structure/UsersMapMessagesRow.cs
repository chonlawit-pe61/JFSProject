using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class UsersMapMessagesRow
	{
		private int _messageID;
		private bool _isSetMessageID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private int _placeHolderID;
		private bool _isSetPlaceHolderID = false;
		private bool _placeHolderIDNull = true;
		private bool _isRead;
		private bool _isSetIsRead = false;
		private bool _isSync;
		private bool _isSetIsSync = false;
		[Required]
		public int MessageID
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
		public int PlaceHolderID
		{
			get
			{
				return _placeHolderID;
			}
			set
			{
				_placeHolderIDNull = false;
				_isSetPlaceHolderID = true;
				_placeHolderID = value;
			}
		}
		public bool IsPlaceHolderIDNull
		{
			get {
				 return _placeHolderIDNull; }
			set { _placeHolderIDNull = value; }
		}
		public bool _IsSetPlaceHolderID
		{
			get { return _isSetPlaceHolderID; }
		}
		[Required]
		public bool IsRead
		{
			get { return _isRead; }
			set { _isRead = value;
			      _isSetIsRead = true; }
		}
		public bool _IsSetIsRead
		{
			get { return _isSetIsRead; }
		}
		[Required]
		public bool IsSync
		{
			get { return _isSync; }
			set { _isSync = value;
			      _isSetIsSync = true; }
		}
		public bool _IsSetIsSync
		{
			get { return _isSetIsSync; }
		}
	}
	[Serializable]
	public class UsersMapMessagesData
	{
		private int _messageID;
		private int _userID;
		private int _placeHolderID;
		private bool _isRead;
		private bool _isSync;
		public int MessageID
		{
			get{ return _messageID; }
			set{ _messageID = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public int PlaceHolderID
		{
			get{ return _placeHolderID; }
			set{ _placeHolderID = value; }
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
	public class UsersMapMessagesPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public UsersMapMessagesRow[] usersMapMessagesRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส UsersMapMessagesItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class UsersMapMessagesItems : UsersMapMessagesData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class UsersMapMessagesItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public UsersMapMessagesItems[] usersMapMessagesItems { get; set; }
	}
}

