using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class SysRoleMapPermissionRow
	{
		private int _roleID;
		private bool _isSetRoleID = false;
		private int _permissionID;
		private bool _isSetPermissionID = false;
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
	}
	[Serializable]
	public class SysRoleMapPermissionData
	{
		private int _roleID;
		private int _permissionID;
		public int RoleID
		{
			get{ return _roleID; }
			set{ _roleID = value; }
		}
		public int PermissionID
		{
			get{ return _permissionID; }
			set{ _permissionID = value; }
		}
	}
	[Serializable]
	public class SysRoleMapPermissionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SysRoleMapPermissionRow[] sysRoleMapPermissionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SysRoleMapPermissionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SysRoleMapPermissionItems : SysRoleMapPermissionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SysRoleMapPermissionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SysRoleMapPermissionItems[] sysRoleMapPermissionItems { get; set; }
	}
}

