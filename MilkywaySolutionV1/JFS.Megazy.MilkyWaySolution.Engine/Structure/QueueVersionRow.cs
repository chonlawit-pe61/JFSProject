using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class QueueVersionRow
	{
		private int _queueVersionID;
		private bool _isSetQueueVersionID = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private string _queueName;
		private bool _isSetQueueName = false;
		private int _queueYear;
		private bool _isSetQueueYear = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
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
		public int ProvinceID
		{
			get { return _provinceID; }
			set { _provinceID = value;
			      _isSetProvinceID = true; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		public string QueueName
		{
			get { return _queueName; }
			set { _queueName = value;
			      _isSetQueueName = true; }
		}
		public bool _IsSetQueueName
		{
			get { return _isSetQueueName; }
		}
		[Required]
		public int QueueYear
		{
			get { return _queueYear; }
			set { _queueYear = value;
			      _isSetQueueYear = true; }
		}
		public bool _IsSetQueueYear
		{
			get { return _isSetQueueYear; }
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
	}
	[Serializable]
	public class QueueVersionData
	{
		private int _queueVersionID;
		private int _provinceID;
		private string _queueName;
		private int _queueYear;
		private bool _isActive;
		private DateTime _createDate;
		public int QueueVersionID
		{
			get{ return _queueVersionID; }
			set{ _queueVersionID = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string QueueName
		{
			get{ return _queueName; }
			set{ _queueName = value; }
		}
		public int QueueYear
		{
			get{ return _queueYear; }
			set{ _queueYear = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
	}
	[Serializable]
	public class QueueVersionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public QueueVersionRow[] queueVersionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส QueueVersionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class QueueVersionItems : QueueVersionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class QueueVersionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public QueueVersionItems[] queueVersionItems { get; set; }
	}
}

