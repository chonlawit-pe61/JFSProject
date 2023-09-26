using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class InboxDetailRow
	{
		private int _detailId;
		private bool _isSetDetailID = false;
		private int _inboxiD;
		private bool _isSetInboxID = false;
		private string _keyName;
		private bool _isSetKeyName = false;
		private string _value;
		private bool _isSetValue = false;
		private string _caption;
		private bool _isSetCaption = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isShow;
		private bool _isSetIsShow = false;
		private bool _isShowNull = true;
		[Required]
		public int DetailID
		{
			get { return _detailId; }
			set { _detailId = value;
			      _isSetDetailID = true; }
		}
		public bool _IsSetDetailID
		{
			get { return _isSetDetailID; }
		}
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
		public string KeyName
		{
			get { return _keyName; }
			set { _keyName = value;
			      _isSetKeyName = true; }
		}
		public bool _IsSetKeyName
		{
			get { return _isSetKeyName; }
		}
		[Required]
		public string Value
		{
			get { return _value; }
			set { _value = value;
			      _isSetValue = true; }
		}
		public bool _IsSetValue
		{
			get { return _isSetValue; }
		}
		public string Caption
		{
			get { return _caption; }
			set { _caption = value;
			      _isSetCaption = true; }
		}
		public bool _IsSetCaption
		{
			get { return _isSetCaption; }
		}
		[Required]
		public int SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value;
			      _isSetSortOrder = true; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
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
		public bool IsShow
		{
			get
			{
				return _isShow;
			}
			set
			{
				_isShowNull = false;
				_isSetIsShow = true;
				_isShow = value;
			}
		}
		public bool IsIsShowNull
		{
			get {
				 return _isShowNull; }
			set { _isShowNull = value; }
		}
		public bool _IsSetIsShow
		{
			get { return _isSetIsShow; }
		}
	}
	[Serializable]
	public class InboxDetailData
	{
		private int _detailId;
		private int _inboxiD;
		private string _keyName;
		private string _value;
		private string _caption;
		private int _sortOrder;
		private bool _isActive;
		private bool _isShow;
		public int DetailID
		{
			get{ return _detailId; }
			set{ _detailId = value; }
		}
		public int InboxID
		{
			get{ return _inboxiD; }
			set{ _inboxiD = value; }
		}
		public string KeyName
		{
			get{ return _keyName; }
			set{ _keyName = value; }
		}
		public string Value
		{
			get{ return _value; }
			set{ _value = value; }
		}
		public string Caption
		{
			get{ return _caption; }
			set{ _caption = value; }
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
		public bool IsShow
		{
			get{ return _isShow; }
			set{ _isShow = value; }
		}
	}
	[Serializable]
	public class InboxDetailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public InboxDetailRow[] inboxDetailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส InboxDetailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class InboxDetailItems : InboxDetailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class InboxDetailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public InboxDetailItems[] inboxDetailItems { get; set; }
	}
}

