using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class UserMapRoleRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private int _roleID;
		private bool _isSetRoleID = false;
		private int _assignID;
		private bool _isSetAssignID = false;
		private bool _assignIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int UserID
		{
			get { return _userID; }
			set { _userID = value;
			      _isSetUserID = true; }
		}
		public bool _IsSetUserID
		{
			get { return _isSetUserID; }
		}
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
		public int AssignID
		{
			get
			{
				return _assignID;
			}
			set
			{
				_assignIDNull = false;
				_isSetAssignID = true;
				_assignID = value;
			}
		}
		public bool IsAssignIDNull
		{
			get {
				 return _assignIDNull; }
			set { _assignIDNull = value; }
		}
		public bool _IsSetAssignID
		{
			get { return _isSetAssignID; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class UserMapRoleData
	{
		private int _userID;
		private int _roleID;
		private int _assignID;
		private DateTime _modifiedDate;
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public int RoleID
		{
			get{ return _roleID; }
			set{ _roleID = value; }
		}
		public int AssignID
		{
			get{ return _assignID; }
			set{ _assignID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class UserMapRolePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public UserMapRoleRow[] userMapRoleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส UserMapRoleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class UserMapRoleItems : UserMapRoleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class UserMapRoleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public UserMapRoleItems[] userMapRoleItems { get; set; }
	}
}

