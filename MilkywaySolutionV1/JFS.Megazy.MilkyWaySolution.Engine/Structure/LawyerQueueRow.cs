using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerQueueRow
	{
		private int _queueID;
		private bool _isSetQueueID = false;
		private int _queueVersionID;
		private bool _isSetQueueVersionID = false;
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private string _queueRunningCode;
		private bool _isSetQueueRunningCode = false;
		private string _queueNote;
		private bool _isSetQueueNote = false;
		private int _priority;
		private bool _isSetPriority = false;
		private int _queueStatusID;
		private bool _isSetQueueStatusID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int QueueID
		{
			get { return _queueID; }
			set { _queueID = value;
			      _isSetQueueID = true; }
		}
		public bool _IsSetQueueID
		{
			get { return _isSetQueueID; }
		}
		[Required]
		public int QueueVersionID
		{
			get { return _queueVersionID; }
			set { _queueVersionID = value;
			      _isSetQueueVersionID = true; }
		}
		public bool _IsSetQueueVersionID
		{
			get { return _isSetQueueVersionID; }
		}
		[Required]
		public int LawyerID
		{
			get { return _lawyerID; }
			set { _lawyerID = value;
			      _isSetLawyerID = true; }
		}
		public bool _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
		}
		public string QueueRunningCode
		{
			get { return _queueRunningCode; }
			set { _queueRunningCode = value;
			      _isSetQueueRunningCode = true; }
		}
		public bool _IsSetQueueRunningCode
		{
			get { return _isSetQueueRunningCode; }
		}
		public string QueueNote
		{
			get { return _queueNote; }
			set { _queueNote = value;
			      _isSetQueueNote = true; }
		}
		public bool _IsSetQueueNote
		{
			get { return _isSetQueueNote; }
		}
		[Required]
		public int Priority
		{
			get { return _priority; }
			set { _priority = value;
			      _isSetPriority = true; }
		}
		public bool _IsSetPriority
		{
			get { return _isSetPriority; }
		}
		[Required]
		public int QueueStatusID
		{
			get { return _queueStatusID; }
			set { _queueStatusID = value;
			      _isSetQueueStatusID = true; }
		}
		public bool _IsSetQueueStatusID
		{
			get { return _isSetQueueStatusID; }
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
	public class LawyerQueueData
	{
		private int _queueID;
		private int _queueVersionID;
		private int _lawyerID;
		private string _queueRunningCode;
		private string _queueNote;
		private int _priority;
		private int _queueStatusID;
		private DateTime _modifiedDate;
		public int QueueID
		{
			get{ return _queueID; }
			set{ _queueID = value; }
		}
		public int QueueVersionID
		{
			get{ return _queueVersionID; }
			set{ _queueVersionID = value; }
		}
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public string QueueRunningCode
		{
			get{ return _queueRunningCode; }
			set{ _queueRunningCode = value; }
		}
		public string QueueNote
		{
			get{ return _queueNote; }
			set{ _queueNote = value; }
		}
		public int Priority
		{
			get{ return _priority; }
			set{ _priority = value; }
		}
		public int QueueStatusID
		{
			get{ return _queueStatusID; }
			set{ _queueStatusID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class LawyerQueuePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerQueueRow[] lawyerQueueRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerQueueItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerQueueItems : LawyerQueueData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerQueueItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerQueueItems[] lawyerQueueItems { get; set; }
	}
}

