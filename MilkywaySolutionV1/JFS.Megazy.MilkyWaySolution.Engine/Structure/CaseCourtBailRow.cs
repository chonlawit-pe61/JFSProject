using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseCourtBailRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _bailStatusID;
		private bool _isSetBailStatusID = false;
		private DateTime _courtReleaseDate;
		private bool _isSetCourtReleaseDate = false;
		private bool _courtReleaseDateNull = true;
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
		[Required]
		public int BailStatusID
		{
			get { return _bailStatusID; }
			set { _bailStatusID = value;
			      _isSetBailStatusID = true; }
		}
		public bool _IsSetBailStatusID
		{
			get { return _isSetBailStatusID; }
		}
		public DateTime CourtReleaseDate
		{
			get
			{
				return _courtReleaseDate;
			}
			set
			{
				_courtReleaseDateNull = false;
				_isSetCourtReleaseDate = true;
				_courtReleaseDate = value;
			}
		}
		public bool IsCourtReleaseDateNull
		{
			get {
				 return _courtReleaseDateNull; }
			set { _courtReleaseDateNull = value; }
		}
		public bool _IsSetCourtReleaseDate
		{
			get { return _isSetCourtReleaseDate; }
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
	public class CaseCourtBailData
	{
		private int _caseID;
		private int _applicantID;
		private int _bailStatusID;
		private DateTime _courtReleaseDate;
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
		public int BailStatusID
		{
			get{ return _bailStatusID; }
			set{ _bailStatusID = value; }
		}
		public DateTime CourtReleaseDate
		{
			get{ return _courtReleaseDate; }
			set{ _courtReleaseDate = value; }
		}
		public string CourtReleaseDateStr { get; set; }
		public DateTime Modified
		{
			get{ return _modified; }
			set{ _modified = value; }
		}
		public string ModifiedStr { get; set; }
	}
	[Serializable]
	public class CaseCourtBailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseCourtBailRow[] casecourtBailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseCourtBailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseCourtBailItems : CaseCourtBailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseCourtBailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseCourtBailItems[] casecourtBailItems { get; set; }
	}
}

