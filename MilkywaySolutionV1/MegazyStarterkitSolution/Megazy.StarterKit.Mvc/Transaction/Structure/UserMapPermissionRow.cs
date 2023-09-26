using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class UserMapPermissionRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private int _permissionID;
		private bool _isSetPermissionID = false;
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
	public class UserMapPermissionData
	{
		private int _userID;
		private int _permissionID;
		private DateTime _modifiedDate;
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public int PermissionID
		{
			get{ return _permissionID; }
			set{ _permissionID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class UserMapPermissionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public UserMapPermissionRow[] userMapPermissionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส UserMapPermissionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class UserMapPermissionItems : UserMapPermissionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class UserMapPermissionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public UserMapPermissionItems[] userMapPermissionItems { get; set; }
	}
}

