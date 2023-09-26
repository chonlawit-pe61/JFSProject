using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Engine.Dal;
namespace Megazy.StarterKit.Engine.Structure
{
	[Serializable]
	public class UserAdditionalRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private bool _isAdministrator;
		private bool _isSetIsAdministrator = false;
		private bool _isAdministratorNull = true;
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
		public int DepartmentID
		{
			get
			{
				return _departmentId;
			}
			set
			{
				_departmentIdNull = false;
				_isSetDepartmentID = true;
				_departmentId = value;
			}
		}
		public bool IsDepartmentIDNull
		{
			get {
				 return _departmentIdNull; }
			set { _departmentIdNull = value; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		public bool IsAdministrator
		{
			get
			{
				return _isAdministrator;
			}
			set
			{
				_isAdministratorNull = false;
				_isSetIsAdministrator = true;
				_isAdministrator = value;
			}
		}
		public bool IsIsAdministratorNull
		{
			get {
				 return _isAdministratorNull; }
			set { _isAdministratorNull = value; }
		}
		public bool _IsSetIsAdministrator
		{
			get { return _isSetIsAdministrator; }
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
	public class UserAdditionalData
	{
		private int _userID;
		private int _departmentId;
		private bool _isAdministrator;
		private DateTime _modifiedDate;
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public bool IsAdministrator
		{
			get{ return _isAdministrator; }
			set{ _isAdministrator = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class UserAdditionalPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public UserAdditionalRow[] userAdditionalRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส UserAdditionalItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class UserAdditionalItems : UserAdditionalData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class UserAdditionalItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public UserAdditionalItems[] userAdditionalItems { get; set; }
	}
}

