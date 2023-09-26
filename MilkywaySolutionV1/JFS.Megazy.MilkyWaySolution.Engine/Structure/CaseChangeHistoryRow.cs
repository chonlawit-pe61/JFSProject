using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseChangeHistoryRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _caseApplicationStatusID;
		private bool _isSetCaseApplicationStatusID = false;
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
	}
	[Serializable]
	public class CaseChangeHistoryData
	{
		private int _caseID;
		private int _caseApplicationStatusID;
		private int _userID;
		private int _departmentId;
		private DateTime _changeDate;
		private string _comment;
		private DateTime _modifiedDate;
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
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseChangeHistoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseChangeHistoryRow[] casechangeHistoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseChangeHistoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseChangeHistoryItems : CaseChangeHistoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseChangeHistoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseChangeHistoryItems[] casechangeHistoryItems { get; set; }
	}
}

