using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_CaseChangeRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _caseApplicationStatusID;
		private bool _isSetCaseApplicationStatusID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private DateTime _changeDate;
		private bool _isSetChangeDate = false;
		private bool _changeDateNull = true;
		private string _comment;
		private bool _isSetComment = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _caseApplicationStatusName;
		private bool _isSetCaseApplicationStatusName = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
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
		public int CaseApplicationStatusID
		{
			get { return _caseApplicationStatusID; }
			set { _caseApplicationStatusID = value;
			      _isSetCaseApplicationStatusID = true; }
		}
		public bool _IsSetCaseApplicationStatusID
		{
			get { return _isSetCaseApplicationStatusID; }
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
		public string CaseApplicationStatusName
		{
			get { return _caseApplicationStatusName; }
			set { _caseApplicationStatusName = value;
			      _isSetCaseApplicationStatusName = true; }
		}
		public bool _IsSetCaseApplicationStatusName
		{
			get { return _isSetCaseApplicationStatusName; }
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
	}
	[Serializable]
	public class View_CaseChangeData
	{
		private int _caseID;
		private int _caseApplicationStatusID;
		private int _userID;
		private DateTime _changeDate;
		private string _comment;
		private string _firstName;
		private string _lastName;
		private string _caseApplicationStatusName;
		private int _departmentId;
		private string _departmentName;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int CaseApplicationStatusID
		{
			get{ return _caseApplicationStatusID; }
			set{ _caseApplicationStatusID = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
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
		public string CaseApplicationStatusName
		{
			get{ return _caseApplicationStatusName; }
			set{ _caseApplicationStatusName = value; }
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
	}
	[Serializable]
	public class View_CaseChangePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseChangeRow[] view_CaseChangeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseChangeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseChangeItems : View_CaseChangeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseChangeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseChangeItems[] view_CaseChangeItems { get; set; }
	}
}

