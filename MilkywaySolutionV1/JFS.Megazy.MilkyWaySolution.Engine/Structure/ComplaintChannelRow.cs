using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ComplaintChannelRow
	{
		private int _channelID;
		private bool _isSetChannelID = false;
		private string _channelName;
		private bool _isSetChannelName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ChannelID
		{
			get { return _channelID; }
			set { _channelID = value;
			      _isSetChannelID = true; }
		}
		public bool _IsSetChannelID
		{
			get { return _isSetChannelID; }
		}
		public string ChannelName
		{
			get { return _channelName; }
			set { _channelName = value;
			      _isSetChannelName = true; }
		}
		public bool _IsSetChannelName
		{
			get { return _isSetChannelName; }
		}
		public int SortOrder
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				_sortOrderNull = false;
				_isSetSortOrder = true;
				_sortOrder = value;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
		}
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
	public class ComplaintChannelData
	{
		private int _channelID;
		private string _channelName;
		private int _sortOrder;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int ChannelID
		{
			get{ return _channelID; }
			set{ _channelID = value; }
		}
		public string ChannelName
		{
			get{ return _channelName; }
			set{ _channelName = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ComplaintChannelPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ComplaintChannelRow[] complaintchannelRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ComplaintChannelItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ComplaintChannelItems : ComplaintChannelData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ComplaintChannelItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ComplaintChannelItems[] complaintchannelItems { get; set; }
	}
}

