using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class GroupCaseRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _groupID;
		private bool _isSetGroupID = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private string _groupName;
		private bool _isSetGroupName = false;
		private bool _groupNameNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _deleteFlag;
		private bool _isSetDeleteFlag = false;
		private int _userCreateID;
		private bool _isSetUserCreateID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int GroupID
		{
			get { return _groupID; }
			set { _groupID = value;
			      _isMapRecord = false;
			      _isSetGroupID = true; }
		}
		public Boolean _IsSetGroupID
		{
			get { return _isSetGroupID; }
		}
		[Required]
		public DateTime CreateDate
		{
			get { return _createDate; }
			set { _createDate = value;
			      _createDateNull = false;
			      _isMapRecord = false;
			      _isSetCreateDate = true; }
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public Boolean _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
		public string GroupName
		{
			get
			{
				return _groupName;
			}
			set
			{
				_groupNameNull = false;
				_isSetGroupName = true;
				_groupName = value;
				_isMapRecord = false;
			}
		}
		public bool IsGroupNameNull
		{
			get {
				 return _groupNameNull; }
			set { _groupNameNull = value; }
		}
		public Boolean _IsSetGroupName
		{
			get { return _isSetGroupName; }
		}
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isMapRecord = false;
			      _isSetDepartmentID = true; }
		}
		public Boolean _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		[Required]
		public bool DeleteFlag
		{
			get { return _deleteFlag; }
			set { _deleteFlag = value;
			      _isMapRecord = false;
			      _isSetDeleteFlag = true; }
		}
		public Boolean _IsSetDeleteFlag
		{
			get { return _isSetDeleteFlag; }
		}
		[Required]
		public int UserCreateID
		{
			get { return _userCreateID; }
			set { _userCreateID = value;
			      _isMapRecord = false;
			      _isSetUserCreateID = true; }
		}
		public Boolean _IsSetUserCreateID
		{
			get { return _isSetUserCreateID; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isMapRecord = false;
			      _isSetModifiedDate = true; }
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class GroupCaseData
	{
		private int _groupID;
		private DateTime _createDate;
		private string _groupName;
		private int _departmentId;
		private bool _deleteFlag;
		private int _userCreateID;
		private DateTime _modifiedDate;
		public int GroupID
		{
			get{ return _groupID; }
			set{ _groupID = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
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
		public bool DeleteFlag
		{
			get{ return _deleteFlag; }
			set{ _deleteFlag = value; }
		}
		public int UserCreateID
		{
			get{ return _userCreateID; }
			set{ _userCreateID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class GroupCasePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public GroupCaseRow[] groupCaseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส GroupCaseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class GroupCaseItems : GroupCaseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class GroupCaseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public GroupCaseItems[] groupCaseItems { get; set; }
	}
}

