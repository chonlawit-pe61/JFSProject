using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MessagesRow
	{
		private int _messageID;
		private bool _isSetMessageID = false;
		private string _subject;
		private bool _isSetSubject = false;
		private string _body;
		private bool _isSetBody = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private int _authorID;
		private bool _isSetAuthorID = false;
		private bool _authorIDNull = true;
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
		public string Body
		{
			get { return _body; }
			set { _body = value;
			      _isSetBody = true; }
		}
		public bool _IsSetBody
		{
			get { return _isSetBody; }
		}
		public DateTime CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				_createDateNull = false;
				_isSetCreateDate = true;
				_createDate = value;
			}
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
		public int AuthorID
		{
			get
			{
				return _authorID;
			}
			set
			{
				_authorIDNull = false;
				_isSetAuthorID = true;
				_authorID = value;
			}
		}
		public bool IsAuthorIDNull
		{
			get {
				 return _authorIDNull; }
			set { _authorIDNull = value; }
		}
		public bool _IsSetAuthorID
		{
			get { return _isSetAuthorID; }
		}
	}
	[Serializable]
	public class MessagesData
	{
		private int _messageID;
		private string _subject;
		private string _body;
		private DateTime _createDate;
		private int _authorID;
		public int MessageID
		{
			get{ return _messageID; }
			set{ _messageID = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public string Body
		{
			get{ return _body; }
			set{ _body = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public int AuthorID
		{
			get{ return _authorID; }
			set{ _authorID = value; }
		}
	}
	[Serializable]
	public class MessagesPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MessagesRow[] messagesRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MessagesItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MessagesItems : MessagesData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MessagesItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MessagesItems[] messagesItems { get; set; }
	}
}

