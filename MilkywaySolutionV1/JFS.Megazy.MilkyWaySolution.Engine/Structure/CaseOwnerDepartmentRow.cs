using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseOwnerDepartmentRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private int _statusID;
		private bool _isSetStatusID = false;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private int _referenceDepartmentID;
		private bool _isSetReferenceDepartmentID = false;
		private bool _referenceDepartmentIDNull = true;
		private bool _isAppeal;
		private bool _isSetIsAppeal = false;
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
		public int ProvinceID
		{
			get { return _provinceID; }
			set { _provinceID = value;
			      _isSetProvinceID = true; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		[Required]
		public int StatusID
		{
			get { return _statusID; }
			set { _statusID = value;
			      _isSetStatusID = true; }
		}
		public bool _IsSetStatusID
		{
			get { return _isSetStatusID; }
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
		public int ReferenceDepartmentID
		{
			get
			{
				return _referenceDepartmentID;
			}
			set
			{
				_referenceDepartmentIDNull = false;
				_isSetReferenceDepartmentID = true;
				_referenceDepartmentID = value;
			}
		}
		public bool IsReferenceDepartmentIDNull
		{
			get {
				 return _referenceDepartmentIDNull; }
			set { _referenceDepartmentIDNull = value; }
		}
		public bool _IsSetReferenceDepartmentID
		{
			get { return _isSetReferenceDepartmentID; }
		}
		[Required]
		public bool IsAppeal
		{
			get { return _isAppeal; }
			set { _isAppeal = value;
			      _isSetIsAppeal = true; }
		}
		public bool _IsSetIsAppeal
		{
			get { return _isSetIsAppeal; }
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
	public class CaseOwnerDepartmentData
	{
		private int _caseID;
		private int _departmentId;
		private int _provinceID;
		private int _statusID;
		private int _workStepID;
		private int _referenceDepartmentID;
		private bool _isAppeal;
		private DateTime _modifiedDate;
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
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public int StatusID
		{
			get{ return _statusID; }
			set{ _statusID = value; }
		}
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		public int ReferenceDepartmentID
		{
			get{ return _referenceDepartmentID; }
			set{ _referenceDepartmentID = value; }
		}
		public bool IsAppeal
		{
			get{ return _isAppeal; }
			set{ _isAppeal = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseOwnerDepartmentPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseOwnerDepartmentRow[] caseOwnerDepartmentRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseOwnerDepartmentItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseOwnerDepartmentItems : CaseOwnerDepartmentData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseOwnerDepartmentItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseOwnerDepartmentItems[] caseOwnerDepartmentItems { get; set; }
	}
}

