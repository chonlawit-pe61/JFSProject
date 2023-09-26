using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_WorkStepChangeHistoryRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private DateTime _changeDate;
		private bool _isSetChangeDate = false;
		private bool _changeDateNull = true;
		private string _comment;
		private bool _isSetComment = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _workStepName;
		private bool _isSetWorkStepName = false;
		private string _userName;
		private bool _isSetUserName = false;
		private string _aliasName;
		private bool _isSetAliasName = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private string _departmentNameAbbr;
		private bool _isSetDepartmentNameAbbr = false;
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
		public int WorkStepID
		{
			get { return _workStepID; }
			set { _workStepID = value;
			      _isSetWorkStepID = true; }
		}
		public bool _IsSetWorkStepID
		{
			get { return _isSetWorkStepID; }
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
		[Required]
		public string WorkStepName
		{
			get { return _workStepName; }
			set { _workStepName = value;
			      _isSetWorkStepName = true; }
		}
		public bool _IsSetWorkStepName
		{
			get { return _isSetWorkStepName; }
		}
		[Required]
		public string UserName
		{
			get { return _userName; }
			set { _userName = value;
			      _isSetUserName = true; }
		}
		public bool _IsSetUserName
		{
			get { return _isSetUserName; }
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
		public string DepartmentNameAbbr
		{
			get { return _departmentNameAbbr; }
			set { _departmentNameAbbr = value;
			      _isSetDepartmentNameAbbr = true; }
		}
		public bool _IsSetDepartmentNameAbbr
		{
			get { return _isSetDepartmentNameAbbr; }
		}
	}
	[Serializable]
	public class View_WorkStepChangeHistoryData
	{
		private int _caseID;
		private int _workStepID;
		private int _userID;
		private int _departmentId;
		private DateTime _changeDate;
		private string _comment;
		private DateTime _modifiedDate;
		private string _workStepName;
		private string _userName;
		private string _aliasName;
		private string _firstName;
		private string _lastName;
		private string _departmentName;
		private string _departmentNameAbbr;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
		public string WorkStepName
		{
			get{ return _workStepName; }
			set{ _workStepName = value; }
		}
		public string UserName
		{
			get{ return _userName; }
			set{ _userName = value; }
		}
		public string AliasName
		{
			get{ return _aliasName; }
			set{ _aliasName = value; }
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
		public string DepartmentName
		{
			get{ return _departmentName; }
			set{ _departmentName = value; }
		}
		public string DepartmentNameAbbr
		{
			get{ return _departmentNameAbbr; }
			set{ _departmentNameAbbr = value; }
		}
	}
	[Serializable]
	public class View_WorkStepChangeHistoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_WorkStepChangeHistoryRow[] view_WorkStepChangeHistoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_WorkStepChangeHistoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_WorkStepChangeHistoryItems : View_WorkStepChangeHistoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_WorkStepChangeHistoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_WorkStepChangeHistoryItems[] view_WorkStepChangeHistoryItems { get; set; }
	}
}

