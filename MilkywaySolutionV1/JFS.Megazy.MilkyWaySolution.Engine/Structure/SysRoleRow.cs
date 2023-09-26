using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class SysRoleRow
	{
		private int _roleID;
		private bool _isSetRoleID = false;
		private string _roleName;
		private bool _isSetRoleName = false;
		private bool _isShow;
		private bool _isSetIsShow = false;
		private bool _isShowNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int RoleID
		{
			get { return _roleID; }
			set { _roleID = value;
			      _isSetRoleID = true; }
		}
		public bool _IsSetRoleID
		{
			get { return _isSetRoleID; }
		}
		public string RoleName
		{
			get { return _roleName; }
			set { _roleName = value;
			      _isSetRoleName = true; }
		}
		public bool _IsSetRoleName
		{
			get { return _isSetRoleName; }
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
	public class SysRoleData
	{
		private int _roleID;
		private string _roleName;
		private bool _isShow;
		private bool _isActive;
		private int _sortOrder;
		private DateTime _modifiedDate;
		public int RoleID
		{
			get{ return _roleID; }
			set{ _roleID = value; }
		}
		public string RoleName
		{
			get{ return _roleName; }
			set{ _roleName = value; }
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
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class SysRolePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SysRoleRow[] sysRoleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SysRoleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SysRoleItems : SysRoleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SysRoleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SysRoleItems[] sysRoleItems { get; set; }
	}
}

