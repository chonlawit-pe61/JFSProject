using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class RefundStatusRow
	{
		private int _refundStatusID;
		private bool _isSetRefundStatusID = false;
		private string _refundStatusName;
		private bool _isSetRefundStatusName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		[Required]
		public int RefundStatusID
		{
			get { return _refundStatusID; }
			set { _refundStatusID = value;
			      _isSetRefundStatusID = true; }
		}
		public bool _IsSetRefundStatusID
		{
			get { return _isSetRefundStatusID; }
		}
		[Required]
		public string RefundStatusName
		{
			get { return _refundStatusName; }
			set { _refundStatusName = value;
			      _isSetRefundStatusName = true; }
		}
		public bool _IsSetRefundStatusName
		{
			get { return _isSetRefundStatusName; }
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
	}
	[Serializable]
	public class RefundStatusData
	{
		private int _refundStatusID;
		private string _refundStatusName;
		private int _sortOrder;
		public int RefundStatusID
		{
			get{ return _refundStatusID; }
			set{ _refundStatusID = value; }
		}
		public string RefundStatusName
		{
			get{ return _refundStatusName; }
			set{ _refundStatusName = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
	}
	[Serializable]
	public class RefundStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public RefundStatusRow[] refundStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส RefundStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class RefundStatusItems : RefundStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class RefundStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public RefundStatusItems[] refundStatusItems { get; set; }
	}
}

