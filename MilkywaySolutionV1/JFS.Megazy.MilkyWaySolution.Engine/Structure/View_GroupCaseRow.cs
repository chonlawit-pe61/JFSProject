using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_GroupCaseRow
	{
		private int _groupID;
		private bool _isSetGroupID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private string _groupName;
		private bool _isSetGroupName = false;
		private bool _deleteFlag;
		private bool _isSetDeleteFlag = false;
		private int _userCreateID;
		private bool _isSetUserCreateID = false;
		private string _aliasName;
		private bool _isSetAliasName = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
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
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
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
		public bool DeleteFlag
		{
			get { return _deleteFlag; }
			set { _deleteFlag = value;
			      _isSetDeleteFlag = true; }
		}
		public bool _IsSetDeleteFlag
		{
			get { return _isSetDeleteFlag; }
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
	}
	[Serializable]
	public class View_GroupCaseData
	{
		private int _groupID;
		private int _caseID;
		private DateTime _createDate;
		private string _groupName;
		private bool _deleteFlag;
		private int _userCreateID;
		private string _aliasName;
		private int _departmentId;
		public int GroupID
		{
			get{ return _groupID; }
			set{ _groupID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
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
		public string GroupName
		{
			get{ return _groupName; }
			set{ _groupName = value; }
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
		public string AliasName
		{
			get{ return _aliasName; }
			set{ _aliasName = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
	}
	[Serializable]
	public class View_GroupCasePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_GroupCaseRow[] view_GroupCaseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_GroupCaseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_GroupCaseItems : View_GroupCaseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_GroupCaseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_GroupCaseItems[] view_GroupCaseItems { get; set; }
	}
}

