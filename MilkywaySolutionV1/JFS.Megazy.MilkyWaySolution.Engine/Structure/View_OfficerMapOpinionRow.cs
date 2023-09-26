using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_OfficerMapOpinionRow
	{
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private int _opinionID;
		private bool _isSetOpinionID = false;
		private string _opinionName;
		private bool _isSetOpinionName = false;
		private bool _isPay;
		private bool _isSetIsPay = false;
		private bool _isPayNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		[Required]
		public int OfficerRoleID
		{
			get { return _officerRoleID; }
			set { _officerRoleID = value;
			      _isSetOfficerRoleID = true; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
		}
		[Required]
		public int OpinionID
		{
			get { return _opinionID; }
			set { _opinionID = value;
			      _isSetOpinionID = true; }
		}
		public bool _IsSetOpinionID
		{
			get { return _isSetOpinionID; }
		}
		[Required]
		public string OpinionName
		{
			get { return _opinionName; }
			set { _opinionName = value;
			      _isSetOpinionName = true; }
		}
		public bool _IsSetOpinionName
		{
			get { return _isSetOpinionName; }
		}
		public bool IsPay
		{
			get
			{
				return _isPay;
			}
			set
			{
				_isPayNull = false;
				_isSetIsPay = true;
				_isPay = value;
			}
		}
		public bool IsIsPayNull
		{
			get {
				 return _isPayNull; }
			set { _isPayNull = value; }
		}
		public bool _IsSetIsPay
		{
			get { return _isSetIsPay; }
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
	public class View_OfficerMapOpinionData
	{
		private int _officerRoleID;
		private int _opinionID;
		private string _opinionName;
		private bool _isPay;
		private bool _isActive;
		private int _sortOrder;
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public int OpinionID
		{
			get{ return _opinionID; }
			set{ _opinionID = value; }
		}
		public string OpinionName
		{
			get{ return _opinionName; }
			set{ _opinionName = value; }
		}
		public bool IsPay
		{
			get{ return _isPay; }
			set{ _isPay = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
	}
	[Serializable]
	public class View_OfficerMapOpinionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_OfficerMapOpinionRow[] view_OfficerMapOpinionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_OfficerMapOpinionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_OfficerMapOpinionItems : View_OfficerMapOpinionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_OfficerMapOpinionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_OfficerMapOpinionItems[] view_OfficerMapOpinionItems { get; set; }
	}
}

