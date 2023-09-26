using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class View_DuplicateCaseWorkStepRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private DateTime _startDate;
		private bool _isSetStartDate = false;
		private bool _startDateNull = true;
		private DateTime _endDate;
		private bool _isSetEndDate = false;
		private bool _endDateNull = true;
		private string _kPIStatus;
		private bool _isSetKPIStatus = false;
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
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
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
				_isMapRecord = false;
			}
		}
		public bool IsDepartmentIDNull
		{
			get {
				 return _departmentIdNull; }
			set { _departmentIdNull = value; }
		}
		public Boolean _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				_startDateNull = false;
				_isSetStartDate = true;
				_startDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsStartDateNull
		{
			get {
				 return _startDateNull; }
			set { _startDateNull = value; }
		}
		public Boolean _IsSetStartDate
		{
			get { return _isSetStartDate; }
		}
		public DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				_endDateNull = false;
				_isSetEndDate = true;
				_endDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsEndDateNull
		{
			get {
				 return _endDateNull; }
			set { _endDateNull = value; }
		}
		public Boolean _IsSetEndDate
		{
			get { return _isSetEndDate; }
		}
		[Required]
		public string KPIStatus
		{
			get { return _kPIStatus; }
			set { _kPIStatus = value;
			      _isMapRecord = false;
			      _isSetKPIStatus = true; }
		}
		public Boolean _IsSetKPIStatus
		{
			get { return _isSetKPIStatus; }
		}
	}
	[Serializable]
	public class View_DuplicateCaseWorkStepData
	{
		private int _caseID;
		private int _departmentId;
		private DateTime _startDate;
		private DateTime _endDate;
		private string _kPIStatus;
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
		public DateTime StartDate
		{
			get{ return _startDate; }
			set{ _startDate = value; }
		}
		public string StartDateStr { get; set; }
		public DateTime EndDate
		{
			get{ return _endDate; }
			set{ _endDate = value; }
		}
		public string EndDateStr { get; set; }
		public string KPIStatus
		{
			get{ return _kPIStatus; }
			set{ _kPIStatus = value; }
		}
	}
	[Serializable]
	public class View_DuplicateCaseWorkStepPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_DuplicateCaseWorkStepRow[] view_DuplicateCaseWorkStepRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_DuplicateCaseWorkStepItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_DuplicateCaseWorkStepItems : View_DuplicateCaseWorkStepData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_DuplicateCaseWorkStepItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_DuplicateCaseWorkStepItems[] view_DuplicateCaseWorkStepItems { get; set; }
	}
}

