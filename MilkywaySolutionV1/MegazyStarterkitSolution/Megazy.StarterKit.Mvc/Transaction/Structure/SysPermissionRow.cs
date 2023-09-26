using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class SysPermissionRow
	{
		private int _permissionID;
		private bool _isSetPermissionID = false;
		private int _moduleID;
		private bool _isSetModuleID = false;
		private bool _moduleIDNull = true;
		private int _operationID;
		private bool _isSetOperationID = false;
		private bool _operationIDNull = true;
		private string _permissionName;
		private bool _isSetPermissionName = false;
		[Required]
		public int PermissionID
		{
			get { return _permissionID; }
			set { _permissionID = value;
			      _isSetPermissionID = true; }
		}
		public bool _IsSetPermissionID
		{
			get { return _isSetPermissionID; }
		}
		public int ModuleID
		{
			get
			{
				return _moduleID;
			}
			set
			{
				_moduleIDNull = false;
				_isSetModuleID = true;
				_moduleID = value;
			}
		}
		public bool IsModuleIDNull
		{
			get {
				 return _moduleIDNull; }
			set { _moduleIDNull = value; }
		}
		public bool _IsSetModuleID
		{
			get { return _isSetModuleID; }
		}
		public int OperationID
		{
			get
			{
				return _operationID;
			}
			set
			{
				_operationIDNull = false;
				_isSetOperationID = true;
				_operationID = value;
			}
		}
		public bool IsOperationIDNull
		{
			get {
				 return _operationIDNull; }
			set { _operationIDNull = value; }
		}
		public bool _IsSetOperationID
		{
			get { return _isSetOperationID; }
		}
		public string PermissionName
		{
			get { return _permissionName; }
			set { _permissionName = value;
			      _isSetPermissionName = true; }
		}
		public bool _IsSetPermissionName
		{
			get { return _isSetPermissionName; }
		}
	}
	[Serializable]
	public class SysPermissionData
	{
		private int _permissionID;
		private int _moduleID;
		private int _operationID;
		private string _permissionName;
		public int PermissionID
		{
			get{ return _permissionID; }
			set{ _permissionID = value; }
		}
		public int ModuleID
		{
			get{ return _moduleID; }
			set{ _moduleID = value; }
		}
		public int OperationID
		{
			get{ return _operationID; }
			set{ _operationID = value; }
		}
		public string PermissionName
		{
			get{ return _permissionName; }
			set{ _permissionName = value; }
		}
	}
	[Serializable]
	public class SysPermissionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SysPermissionRow[] sysPermissionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SysPermissionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SysPermissionItems : SysPermissionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SysPermissionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SysPermissionItems[] sysPermissionItems { get; set; }
	}
}

