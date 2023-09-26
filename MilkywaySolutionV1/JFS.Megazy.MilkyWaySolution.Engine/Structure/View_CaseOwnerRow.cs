using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_CaseOwnerRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private bool _officerRoleIDNull = true;
		private string _officerRoleName;
		private bool _isSetOfficerRoleName = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private DateTime _changeDate;
		private bool _isSetChangeDate = false;
		private bool _changeDateNull = true;
		private string _comment;
		private bool _isSetComment = false;
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
		[Required]
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
		public int OfficerRoleID
		{
			get
			{
				return _officerRoleID;
			}
			set
			{
				_officerRoleIDNull = false;
				_isSetOfficerRoleID = true;
				_officerRoleID = value;
			}
		}
		public bool IsOfficerRoleIDNull
		{
			get {
				 return _officerRoleIDNull; }
			set { _officerRoleIDNull = value; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
		}
		public string OfficerRoleName
		{
			get { return _officerRoleName; }
			set { _officerRoleName = value;
			      _isSetOfficerRoleName = true; }
		}
		public bool _IsSetOfficerRoleName
		{
			get { return _isSetOfficerRoleName; }
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
		public DateTime ChangeDate
		{
			get { return _changeDate; }
			set { _changeDate = value;
			      _changeDateNull = false;
			      _isSetChangeDate = true; }
		}
		public bool IsChangeDateNull
		{
			get {
				 return _changeDateNull; }
			set { _changeDateNull = value; }
		}
		public bool _IsSetChangeDate
		{
			get { return _isSetChangeDate; }
		}
		public string Comment
		{
			get { return _comment; }
			set { _comment = value;
			      _isSetComment = true; }
		}
		public bool _IsSetComment
		{
			get { return _isSetComment; }
		}
	}
	[Serializable]
	public class View_CaseOwnerData
	{
		private int _caseID;
		private int _departmentId;
		private int _userID;
		private string _firstName;
		private string _lastName;
		private int _officerRoleID;
		private string _officerRoleName;
		private string _departmentName;
		private DateTime _changeDate;
		private string _comment;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
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
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public string OfficerRoleName
		{
			get{ return _officerRoleName; }
			set{ _officerRoleName = value; }
		}
		public string DepartmentName
		{
			get{ return _departmentName; }
			set{ _departmentName = value; }
		}
		public DateTime ChangeDate
		{
			get{ return _changeDate; }
			set{ _changeDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ChangeDateStr { get; set; }
		public string Comment
		{
			get{ return _comment; }
			set{ _comment = value; }
		}
	}
	[Serializable]
	public class View_CaseOwnerPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseOwnerRow[] view_CaseOwnerRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseOwnerItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseOwnerItems : View_CaseOwnerData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseOwnerItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseOwnerItems[] view_CaseOwnerItems { get; set; }
	}
}

