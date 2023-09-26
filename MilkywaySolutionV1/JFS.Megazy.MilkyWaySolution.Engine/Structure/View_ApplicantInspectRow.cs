using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ApplicantInspectRow
	{
		private int _inspectiD;
		private bool _isSetInspectID = false;
		private string _inspectName;
		private bool _isSetInspectName = false;
		private bool _isThaiCitizen;
		private bool _isSetIsThaiCitizen = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private int _inspectValueType;
		private bool _isSetInspectValueType = false;
		private bool _inspectValueTypeNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _result;
		private bool _isSetResult = false;
		private bool _status;
		private bool _isSetStatus = false;
		private bool _statusNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private int _inspectValueListiD;
		private bool _isSetInspectValueListID = false;
		private bool _inspectValueListiDNull = true;
		private int _inspectValueTypeiD;
		private bool _isSetInspectValueTypeID = false;
		private bool _inspectValueTypeiDNull = true;
		private string _inspectValueListName;
		private bool _isSetInspectValueListName = false;
		private string _serviceCode;
		private bool _isSetServiceCode = false;
		[Required]
		public int InspectID
		{
			get { return _inspectiD; }
			set { _inspectiD = value;
			      _isSetInspectID = true; }
		}
		public bool _IsSetInspectID
		{
			get { return _isSetInspectID; }
		}
		[Required]
		public string InspectName
		{
			get { return _inspectName; }
			set { _inspectName = value;
			      _isSetInspectName = true; }
		}
		public bool _IsSetInspectName
		{
			get { return _isSetInspectName; }
		}
		[Required]
		public bool IsThaiCitizen
		{
			get { return _isThaiCitizen; }
			set { _isThaiCitizen = value;
			      _isSetIsThaiCitizen = true; }
		}
		public bool _IsSetIsThaiCitizen
		{
			get { return _isSetIsThaiCitizen; }
		}
		[Required]
		public int SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value;
			      _isSetSortOrder = true; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
		}
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public int InspectValueType
		{
			get
			{
				return _inspectValueType;
			}
			set
			{
				_inspectValueTypeNull = false;
				_isSetInspectValueType = true;
				_inspectValueType = value;
			}
		}
		public bool IsInspectValueTypeNull
		{
			get {
				 return _inspectValueTypeNull; }
			set { _inspectValueTypeNull = value; }
		}
		public bool _IsSetInspectValueType
		{
			get { return _isSetInspectValueType; }
		}
		[Required]
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isSetApplicantID = true; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public string Result
		{
			get { return _result; }
			set { _result = value;
			      _isSetResult = true; }
		}
		public bool _IsSetResult
		{
			get { return _isSetResult; }
		}
		public bool Status
		{
			get
			{
				return _status;
			}
			set
			{
				_statusNull = false;
				_isSetStatus = true;
				_status = value;
			}
		}
		public bool IsStatusNull
		{
			get {
				 return _statusNull; }
			set { _statusNull = value; }
		}
		public bool _IsSetStatus
		{
			get { return _isSetStatus; }
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
		public int InspectValueListID
		{
			get
			{
				return _inspectValueListiD;
			}
			set
			{
				_inspectValueListiDNull = false;
				_isSetInspectValueListID = true;
				_inspectValueListiD = value;
			}
		}
		public bool IsInspectValueListIDNull
		{
			get {
				 return _inspectValueListiDNull; }
			set { _inspectValueListiDNull = value; }
		}
		public bool _IsSetInspectValueListID
		{
			get { return _isSetInspectValueListID; }
		}
		public int InspectValueTypeID
		{
			get
			{
				return _inspectValueTypeiD;
			}
			set
			{
				_inspectValueTypeiDNull = false;
				_isSetInspectValueTypeID = true;
				_inspectValueTypeiD = value;
			}
		}
		public bool IsInspectValueTypeIDNull
		{
			get {
				 return _inspectValueTypeiDNull; }
			set { _inspectValueTypeiDNull = value; }
		}
		public bool _IsSetInspectValueTypeID
		{
			get { return _isSetInspectValueTypeID; }
		}
		public string InspectValueListName
		{
			get { return _inspectValueListName; }
			set { _inspectValueListName = value;
			      _isSetInspectValueListName = true; }
		}
		public bool _IsSetInspectValueListName
		{
			get { return _isSetInspectValueListName; }
		}
		public string ServiceCode
		{
			get { return _serviceCode; }
			set { _serviceCode = value;
			      _isSetServiceCode = true; }
		}
		public bool _IsSetServiceCode
		{
			get { return _isSetServiceCode; }
		}
	}
	[Serializable]
	public class View_ApplicantInspectData
	{
		private int _inspectiD;
		private string _inspectName;
		private bool _isThaiCitizen;
		private int _sortOrder;
		private bool _isActive;
		private int _inspectValueType;
		private int _applicantID;
		private string _result;
		private bool _status;
		private DateTime _modifiedDate;
		private int _inspectValueListiD;
		private int _inspectValueTypeiD;
		private string _inspectValueListName;
		private string _serviceCode;
		public int InspectID
		{
			get{ return _inspectiD; }
			set{ _inspectiD = value; }
		}
		public string InspectName
		{
			get{ return _inspectName; }
			set{ _inspectName = value; }
		}
		public bool IsThaiCitizen
		{
			get{ return _isThaiCitizen; }
			set{ _isThaiCitizen = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public int InspectValueType
		{
			get{ return _inspectValueType; }
			set{ _inspectValueType = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string Result
		{
			get{ return _result; }
			set{ _result = value; }
		}
		public bool Status
		{
			get{ return _status; }
			set{ _status = value; }
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
		public int InspectValueListID
		{
			get{ return _inspectValueListiD; }
			set{ _inspectValueListiD = value; }
		}
		public int InspectValueTypeID
		{
			get{ return _inspectValueTypeiD; }
			set{ _inspectValueTypeiD = value; }
		}
		public string InspectValueListName
		{
			get{ return _inspectValueListName; }
			set{ _inspectValueListName = value; }
		}
		public string ServiceCode
		{
			get{ return _serviceCode; }
			set{ _serviceCode = value; }
		}
	}
	[Serializable]
	public class View_ApplicantInspectPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ApplicantInspectRow[] view_ApplicantInspectRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ApplicantInspectItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ApplicantInspectItems : View_ApplicantInspectData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ApplicantInspectItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ApplicantInspectItems[] view_ApplicantInspectItems { get; set; }
	}
}

