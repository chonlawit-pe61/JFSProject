using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_GroupCaseListRow
	{
		private int _groupID;
		private bool _isSetGroupID = false;
		private string _groupName;
		private bool _isSetGroupName = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private int _userCreateID;
		private bool _isSetUserCreateID = false;
		private string _aliasName;
		private bool _isSetAliasName = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private int _numberOfCase;
		private bool _isSetNumberOfCase = false;
		[Required]
		public int GroupID
		{
			get { return _groupID; }
			set { _groupID = value;
			      _isSetGroupID = true; }
		}
		public bool _IsSetGroupID
		{
			get { return _isSetGroupID; }
		}
		public string GroupName
		{
			get { return _groupName; }
			set { _groupName = value;
			      _isSetGroupName = true; }
		}
		public bool _IsSetGroupName
		{
			get { return _isSetGroupName; }
		}
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isSetDepartmentID = true; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		[Required]
		public string DepartmentName
		{
			get { return _departmentName; }
			set { _departmentName = value;
			      _isSetDepartmentName = true; }
		}
		public bool _IsSetDepartmentName
		{
			get { return _isSetDepartmentName; }
		}
		[Required]
		public int UserCreateID
		{
			get { return _userCreateID; }
			set { _userCreateID = value;
			      _isSetUserCreateID = true; }
		}
		public bool _IsSetUserCreateID
		{
			get { return _isSetUserCreateID; }
		}
		[Required]
		public string AliasName
		{
			get { return _aliasName; }
			set { _aliasName = value;
			      _isSetAliasName = true; }
		}
		public bool _IsSetAliasName
		{
			get { return _isSetAliasName; }
		}
		[Required]
		public DateTime CreateDate
		{
			get { return _createDate; }
			set { _createDate = value;
			      _createDateNull = false;
			      _isSetCreateDate = true; }
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
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
		[Required]
		public int NumberOfCase
		{
			get { return _numberOfCase; }
			set { _numberOfCase = value;
			      _isSetNumberOfCase = true; }
		}
		public bool _IsSetNumberOfCase
		{
			get { return _isSetNumberOfCase; }
		}
	}
	[Serializable]
	public class View_GroupCaseListData
	{
		private int _groupID;
		private string _groupName;
		private int _departmentId;
		private string _departmentName;
		private int _userCreateID;
		private string _aliasName;
		private DateTime _createDate;
		private DateTime _modifiedDate;
		private int _numberOfCase;
		public int GroupID
		{
			get{ return _groupID; }
			set{ _groupID = value; }
		}
		public string GroupName
		{
			get{ return _groupName; }
			set{ _groupName = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public string DepartmentName
		{
			get{ return _departmentName; }
			set{ _departmentName = value; }
		}
		public int UserCreateID
		{
			get{ return _userCreateID; }
			set{ _userCreateID = value; }
		}
		public string AliasName
		{
			get{ return _aliasName; }
			set{ _aliasName = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string CreateDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
		public int NumberOfCase
		{
			get{ return _numberOfCase; }
			set{ _numberOfCase = value; }
		}
	}
	[Serializable]
	public class View_GroupCaseListPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_GroupCaseListRow[] view_GroupCaseListRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_GroupCaseListItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_GroupCaseListItems : View_GroupCaseListData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_GroupCaseListItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_GroupCaseListItems[] view_GroupCaseListItems { get; set; }
	}
}

