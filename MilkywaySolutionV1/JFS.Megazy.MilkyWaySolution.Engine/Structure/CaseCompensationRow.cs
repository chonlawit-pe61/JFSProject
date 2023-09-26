using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseCompensationRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _compensationID;
		private bool _isSetCompensationID = false;
		private string _compensationOtherNote;
		private bool _isSetCompensationOtherNote = false;
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
		public int CompensationID
		{
			get { return _compensationID; }
			set { _compensationID = value;
			      _isSetCompensationID = true; }
		}
		public bool _IsSetCompensationID
		{
			get { return _isSetCompensationID; }
		}
		public string CompensationOtherNote
		{
			get { return _compensationOtherNote; }
			set { _compensationOtherNote = value;
			      _isSetCompensationOtherNote = true; }
		}
		public bool _IsSetCompensationOtherNote
		{
			get { return _isSetCompensationOtherNote; }
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
	public class CaseCompensationData
	{
		private int _applicantID;
		private int _compensationID;
		private string _compensationOtherNote;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int CompensationID
		{
			get{ return _compensationID; }
			set{ _compensationID = value; }
		}
		public string CompensationOtherNote
		{
			get{ return _compensationOtherNote; }
			set{ _compensationOtherNote = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseCompensationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseCompensationRow[] casecompensationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseCompensationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseCompensationItems : CaseCompensationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseCompensationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseCompensationItems[] casecompensationItems { get; set; }
	}
}

