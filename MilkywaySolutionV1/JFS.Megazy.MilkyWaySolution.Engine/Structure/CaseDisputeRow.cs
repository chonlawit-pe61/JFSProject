using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseDisputeRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _courtLevelID;
		private bool _isSetCourtLevelID = false;
		private bool _courtLevelIDNull = true;
		private bool _notCommunicated;
		private bool _isSetNotCommunicated = false;
		private bool _notCommunicatedNull = true;
		private string _verdictOrCause;
		private bool _isSetVerdictOrCause = false;
		private bool _hasMediate;
		private bool _isSetHasMediate = false;
		private bool _hasMediateNull = true;
		private bool _wantMediate;
		private bool _isSetWantMediate = false;
		private bool _wantMediateNull = true;
		private string _mediatedBy;
		private bool _isSetMediatedBy = false;
		private string _description;
		private bool _isSetDescription = false;
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
		public int CourtLevelID
		{
			get
			{
				return _courtLevelID;
			}
			set
			{
				_courtLevelIDNull = false;
				_isSetCourtLevelID = true;
				_courtLevelID = value;
			}
		}
		public bool IsCourtLevelIDNull
		{
			get {
				 return _courtLevelIDNull; }
			set { _courtLevelIDNull = value; }
		}
		public bool _IsSetCourtLevelID
		{
			get { return _isSetCourtLevelID; }
		}
		public bool NotCommunicated
		{
			get
			{
				return _notCommunicated;
			}
			set
			{
				_notCommunicatedNull = false;
				_isSetNotCommunicated = true;
				_notCommunicated = value;
			}
		}
		public bool IsNotCommunicatedNull
		{
			get {
				 return _notCommunicatedNull; }
			set { _notCommunicatedNull = value; }
		}
		public bool _IsSetNotCommunicated
		{
			get { return _isSetNotCommunicated; }
		}
		public string VerdictOrCause
		{
			get { return _verdictOrCause; }
			set { _verdictOrCause = value;
			      _isSetVerdictOrCause = true; }
		}
		public bool _IsSetVerdictOrCause
		{
			get { return _isSetVerdictOrCause; }
		}
		public bool HasMediate
		{
			get
			{
				return _hasMediate;
			}
			set
			{
				_hasMediateNull = false;
				_isSetHasMediate = true;
				_hasMediate = value;
			}
		}
		public bool IsHasMediateNull
		{
			get {
				 return _hasMediateNull; }
			set { _hasMediateNull = value; }
		}
		public bool _IsSetHasMediate
		{
			get { return _isSetHasMediate; }
		}
		public bool WantMediate
		{
			get
			{
				return _wantMediate;
			}
			set
			{
				_wantMediateNull = false;
				_isSetWantMediate = true;
				_wantMediate = value;
			}
		}
		public bool IsWantMediateNull
		{
			get {
				 return _wantMediateNull; }
			set { _wantMediateNull = value; }
		}
		public bool _IsSetWantMediate
		{
			get { return _isSetWantMediate; }
		}
		public string MediatedBy
		{
			get { return _mediatedBy; }
			set { _mediatedBy = value;
			      _isSetMediatedBy = true; }
		}
		public bool _IsSetMediatedBy
		{
			get { return _isSetMediatedBy; }
		}
		public string Description
		{
			get { return _description; }
			set { _description = value;
			      _isSetDescription = true; }
		}
		public bool _IsSetDescription
		{
			get { return _isSetDescription; }
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
	public class CaseDisputeData
	{
		private int _caseID;
		private int _courtLevelID;
		private bool _notCommunicated;
		private string _verdictOrCause;
		private bool _hasMediate;
		private bool _wantMediate;
		private string _mediatedBy;
		private string _description;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int CourtLevelID
		{
			get{ return _courtLevelID; }
			set{ _courtLevelID = value; }
		}
		public bool NotCommunicated
		{
			get{ return _notCommunicated; }
			set{ _notCommunicated = value; }
		}
		public string VerdictOrCause
		{
			get{ return _verdictOrCause; }
			set{ _verdictOrCause = value; }
		}
		public bool HasMediate
		{
			get{ return _hasMediate; }
			set{ _hasMediate = value; }
		}
		public bool WantMediate
		{
			get{ return _wantMediate; }
			set{ _wantMediate = value; }
		}
		public string MediatedBy
		{
			get{ return _mediatedBy; }
			set{ _mediatedBy = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseDisputePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseDisputeRow[] caseDisputeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseDisputeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseDisputeItems : CaseDisputeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseDisputeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseDisputeItems[] caseDisputeItems { get; set; }
	}
}

