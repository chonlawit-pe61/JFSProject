using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseOpposeBailAgencyRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _bailStatus;
		private bool _isSetBailStatus = false;
		private bool _bailStatusNull = true;
		private string _description;
		private bool _isSetDescription = false;
		private string _opposeBy;
		private bool _isSetOpposeBy = false;
		private DateTime _modified;
		private bool _isSetModified = false;
		private bool _modifiedNull = true;
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
		public bool BailStatus
		{
			get
			{
				return _bailStatus;
			}
			set
			{
				_bailStatusNull = false;
				_isSetBailStatus = true;
				_bailStatus = value;
			}
		}
		public bool IsBailStatusNull
		{
			get {
				 return _bailStatusNull; }
			set { _bailStatusNull = value; }
		}
		public bool _IsSetBailStatus
		{
			get { return _isSetBailStatus; }
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
		public string OpposeBy
		{
			get { return _opposeBy; }
			set { _opposeBy = value;
			      _isSetOpposeBy = true; }
		}
		public bool _IsSetOpposeBy
		{
			get { return _isSetOpposeBy; }
		}
		[Required]
		public DateTime Modified
		{
			get { return _modified; }
			set { _modified = value;
			      _modifiedNull = false;
			      _isSetModified = true; }
		}
		public bool IsModifiedNull
		{
			get {
				 return _modifiedNull; }
			set { _modifiedNull = value; }
		}
		public bool _IsSetModified
		{
			get { return _isSetModified; }
		}
	}
	[Serializable]
	public class CaseOpposeBailAgencyData
	{
		private int _caseID;
		private int _applicantID;
		private bool _bailStatus;
		private string _description;
		private string _opposeBy;
		private DateTime _modified;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public bool BailStatus
		{
			get{ return _bailStatus; }
			set{ _bailStatus = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public string OpposeBy
		{
			get{ return _opposeBy; }
			set{ _opposeBy = value; }
		}
		public DateTime Modified
		{
			get{ return _modified; }
			set{ _modified = value; }
		}
		public string ModifiedStr { get; set; }
	}
	[Serializable]
	public class CaseOpposeBailAgencyPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseOpposeBailAgencyRow[] caseOpposeBailAgencyRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseOpposeBailAgencyItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseOpposeBailAgencyItems : CaseOpposeBailAgencyData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseOpposeBailAgencyItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseOpposeBailAgencyItems[] caseOpposeBailAgencyItems { get; set; }
	}
}

