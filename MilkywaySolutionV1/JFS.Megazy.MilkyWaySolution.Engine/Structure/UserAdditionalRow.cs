using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
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
		private string _signature;
		private bool _isSetSignature = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสผู้ใช้งาน อ้างอิงตาราง User
		/// </summary>
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
		/// <summary>
		/// รหัสหน่วยงานหลัก อ้างอิงตาราง Department
		/// </summary>
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
		/// <summary>
		/// เป็นผู้ดูแลระบบหรือไม่
		/// </summary>
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
		/// <summary>
		/// ลายเซ็นต์เจ้าหน้าที่เก็บไว้ในรูปแบบ Base64
		/// </summary>
		public string Signature
		{
			get { return _signature; }
			set { _signature = value;
			      _isSetSignature = true; }
		}
		public bool _IsSetSignature
		{
			get { return _isSetSignature; }
		}
		/// <summary>
		/// วันทีแก้ไข
		/// </summary>
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
		private string _signature;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสผู้ใช้งาน อ้างอิงตาราง User
		/// </summary>
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		/// <summary>
		/// รหัสหน่วยงานหลัก อ้างอิงตาราง Department
		/// </summary>
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		/// <summary>
		/// เป็นผู้ดูแลระบบหรือไม่
		/// </summary>
		public bool IsAdministrator
		{
			get{ return _isAdministrator; }
			set{ _isAdministrator = value; }
		}
		/// <summary>
		/// ลายเซ็นต์เจ้าหน้าที่เก็บไว้ในรูปแบบ Base64
		/// </summary>
		public string Signature
		{
			get{ return _signature; }
			set{ _signature = value; }
		}
		/// <summary>
		/// วันทีแก้ไข
		/// </summary>
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		/// วันทีแก้ไข เก็บวันที่แบบ String
		/// </summary>
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

