using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class QueueStatusRow
	{
		private int _queueStatusID;
		private bool _isSetQueueStatusID = false;
		private string _queueStatusText;
		private bool _isSetQueueStatusText = false;
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
		public string QueueStatusText
		{
			get { return _queueStatusText; }
			set { _queueStatusText = value;
			      _isSetQueueStatusText = true; }
		}
		public bool _IsSetQueueStatusText
		{
			get { return _isSetQueueStatusText; }
		}
	}
	[Serializable]
	public class QueueStatusData
	{
		private int _queueStatusID;
		private string _queueStatusText;
		public int QueueStatusID
		{
			get{ return _queueStatusID; }
			set{ _queueStatusID = value; }
		}
		public string QueueStatusText
		{
			get{ return _queueStatusText; }
			set{ _queueStatusText = value; }
		}
	}
	[Serializable]
	public class QueueStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public QueueStatusRow[] queueStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส QueueStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class QueueStatusItems : QueueStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class QueueStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public QueueStatusItems[] queueStatusItems { get; set; }
	}
}

