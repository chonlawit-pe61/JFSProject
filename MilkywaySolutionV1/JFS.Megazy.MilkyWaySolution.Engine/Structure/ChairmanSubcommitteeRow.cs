using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ChairmanSubcommitteeRow
	{
		private int _chairmanSubcommitteeID;
		private bool _isSetChairmanSubcommitteeID = false;
		private int _subcommitteeID;
		private bool _isSetSubcommitteeID = false;
		private bool _subcommitteeIDNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _position;
		private bool _isSetPosition = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int ChairmanSubcommitteeID
		{
			get { return _chairmanSubcommitteeID; }
			set { _chairmanSubcommitteeID = value;
			      _isSetChairmanSubcommitteeID = true; }
		}
		public bool _IsSetChairmanSubcommitteeID
		{
			get { return _isSetChairmanSubcommitteeID; }
		}
		public int SubcommitteeID
		{
			get
			{
				return _subcommitteeID;
			}
			set
			{
				_subcommitteeIDNull = false;
				_isSetSubcommitteeID = true;
				_subcommitteeID = value;
			}
		}
		public bool IsSubcommitteeIDNull
		{
			get {
				 return _subcommitteeIDNull; }
			set { _subcommitteeIDNull = value; }
		}
		public bool _IsSetSubcommitteeID
		{
			get { return _isSetSubcommitteeID; }
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
		public string Title
		{
			get { return _title; }
			set { _title = value;
			      _isSetTitle = true; }
		}
		public bool _IsSetTitle
		{
			get { return _isSetTitle; }
		}
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value;
			      _isSetFirstName = true; }
		}
		public bool _IsSetFirstName
		{
			get { return _isSetFirstName; }
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value;
			      _isSetLastName = true; }
		}
		public bool _IsSetLastName
		{
			get { return _isSetLastName; }
		}
		public string Position
		{
			get { return _position; }
			set { _position = value;
			      _isSetPosition = true; }
		}
		public bool _IsSetPosition
		{
			get { return _isSetPosition; }
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
	public class ChairmanSubcommitteeData
	{
		private int _chairmanSubcommitteeID;
		private int _subcommitteeID;
		private int _departmentId;
		private string _title;
		private string _firstName;
		private string _lastName;
		private string _position;
		private DateTime _modifiedDate;
		private bool _isActive;
		public int ChairmanSubcommitteeID
		{
			get{ return _chairmanSubcommitteeID; }
			set{ _chairmanSubcommitteeID = value; }
		}
		public int SubcommitteeID
		{
			get{ return _subcommitteeID; }
			set{ _subcommitteeID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
		}
		public string FirstName
		{
			get{ return _firstName; }
			set{ _firstName = value; }
		}
		public string LastName
		{
			get{ return _lastName; }
			set{ _lastName = value; }
		}
		public string Position
		{
			get{ return _position; }
			set{ _position = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class ChairmanSubcommitteePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ChairmanSubcommitteeRow[] chairmanSubcommitteeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ChairmanSubcommitteeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ChairmanSubcommitteeItems : ChairmanSubcommitteeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ChairmanSubcommitteeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ChairmanSubcommitteeItems[] chairmanSubcommitteeItems { get; set; }
	}
}

