using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class View_ModuleRow
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
		private string _screen;
		private bool _isSetScreen = false;
		private string _permission;
		private bool _isSetPermission = false;
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
		public string Screen
		{
			get { return _screen; }
			set { _screen = value;
			      _isSetScreen = true; }
		}
		public bool _IsSetScreen
		{
			get { return _isSetScreen; }
		}
		public string Permission
		{
			get { return _permission; }
			set { _permission = value;
			      _isSetPermission = true; }
		}
		public bool _IsSetPermission
		{
			get { return _isSetPermission; }
		}
	}
	[Serializable]
	public class View_ModuleData
	{
		private int _moduleID;
		private string _moduleName;
		private string _moduleTitle;
		private string _moduleIcon;
		private int _sortOrder;
		private bool _isActive;
		private string _screen;
		private string _permission;
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
		public string Screen
		{
			get{ return _screen; }
			set{ _screen = value; }
		}
		public string Permission
		{
			get{ return _permission; }
			set{ _permission = value; }
		}
	}
	[Serializable]
	public class View_ModulePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ModuleRow[] view_ModuleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ModuleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ModuleItems : View_ModuleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ModuleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ModuleItems[] view_ModuleItems { get; set; }
	}
}

