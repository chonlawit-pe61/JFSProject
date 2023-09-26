using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class SysModuleRow
	{
		private int _moduleID;
		private bool _isSetModuleID = false;
		private string _moduleName;
		private bool _isSetModuleName = false;
		private string _moduleTitle;
		private bool _isSetModuleTitle = false;
		private string _moduleIcon;
		private bool _isSetModuleIcon = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ModuleID
		{
			get { return _moduleID; }
			set { _moduleID = value;
			      _isSetModuleID = true; }
		}
		public bool _IsSetModuleID
		{
			get { return _isSetModuleID; }
		}
		[Required]
		public string ModuleName
		{
			get { return _moduleName; }
			set { _moduleName = value;
			      _isSetModuleName = true; }
		}
		public bool _IsSetModuleName
		{
			get { return _isSetModuleName; }
		}
		[Required]
		public string ModuleTitle
		{
			get { return _moduleTitle; }
			set { _moduleTitle = value;
			      _isSetModuleTitle = true; }
		}
		public bool _IsSetModuleTitle
		{
			get { return _isSetModuleTitle; }
		}
		public string ModuleIcon
		{
			get { return _moduleIcon; }
			set { _moduleIcon = value;
			      _isSetModuleIcon = true; }
		}
		public bool _IsSetModuleIcon
		{
			get { return _isSetModuleIcon; }
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
	public class SysModuleData
	{
		private int _moduleID;
		private string _moduleName;
		private string _moduleTitle;
		private string _moduleIcon;
		private int _sortOrder;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int ModuleID
		{
			get{ return _moduleID; }
			set{ _moduleID = value; }
		}
		public string ModuleName
		{
			get{ return _moduleName; }
			set{ _moduleName = value; }
		}
		public string ModuleTitle
		{
			get{ return _moduleTitle; }
			set{ _moduleTitle = value; }
		}
		public string ModuleIcon
		{
			get{ return _moduleIcon; }
			set{ _moduleIcon = value; }
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
	public class SysModulePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SysModuleRow[] sysModuleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SysModuleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SysModuleItems : SysModuleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SysModuleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SysModuleItems[] sysModuleItems { get; set; }
	}
}

