using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantInspectRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _inspectiD;
		private bool _isSetInspectID = false;
		private int _inspectValueListiD;
		private bool _isSetInspectValueListID = false;
		private bool _inspectValueListiDNull = true;
		private string _result;
		private bool _isSetResult = false;
		private bool _status;
		private bool _isSetStatus = false;
		private bool _statusNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	}
	[Serializable]
	public class ApplicantInspectData
	{
		private int _applicantID;
		private int _inspectiD;
		private int _inspectValueListiD;
		private string _result;
		private bool _status;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int InspectID
		{
			get{ return _inspectiD; }
			set{ _inspectiD = value; }
		}
		public int InspectValueListID
		{
			get{ return _inspectValueListiD; }
			set{ _inspectValueListiD = value; }
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
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantInspectPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantInspectRow[] applicantInspectRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantInspectItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantInspectItems : ApplicantInspectData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantInspectItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantInspectItems[] applicantInspectItems { get; set; }
	}
}

