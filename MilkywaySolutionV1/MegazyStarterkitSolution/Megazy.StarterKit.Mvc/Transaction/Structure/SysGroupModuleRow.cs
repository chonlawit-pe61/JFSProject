using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class SysGroupModuleRow
	{
		private int _groupID;
		private bool _isSetGroupID = false;
		private string _groupName;
		private bool _isSetGroupName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isShow;
		private bool _isSetIsShow = false;
		private bool _isShowNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int GroupID
		{
			get { return _groupID; }
			set { _groupID = value;
			      _isSetGroupID = true; }
		}
		public bool _IsSetGroupID
		{
			get { return _isSetGroupID; }
		}
		public string GroupName
		{
			get { return _groupName; }
			set { _groupName = value;
			      _isSetGroupName = true; }
		}
		public bool _IsSetGroupName
		{
			get { return _isSetGroupName; }
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
	}
	[Serializable]
	public class SysGroupModuleData
	{
		private int _groupID;
		private string _groupName;
		private int _sortOrder;
		private bool _isShow;
		private bool _isActive;
		public int GroupID
		{
			get{ return _groupID; }
			set{ _groupID = value; }
		}
		public string GroupName
		{
			get{ return _groupName; }
			set{ _groupName = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsShow
		{
			get{ return _isShow; }
			set{ _isShow = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class SysGroupModulePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SysGroupModuleRow[] sysGroupModuleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SysGroupModuleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SysGroupModuleItems : SysGroupModuleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SysGroupModuleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SysGroupModuleItems[] sysGroupModuleItems { get; set; }
	}
}

