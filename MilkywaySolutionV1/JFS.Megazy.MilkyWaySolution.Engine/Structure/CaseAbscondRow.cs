using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseAbscondRow
	{
		private int _abscondID;
		private bool _isSetAbscondID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int AbscondID
		{
			get { return _abscondID; }
			set { _abscondID = value;
			      _isSetAbscondID = true; }
		}
		public bool _IsSetAbscondID
		{
			get { return _isSetAbscondID; }
		}
		public int CaseID
		{
			get
			{
				return _caseID;
			}
			set
			{
				_caseIDNull = false;
				_isSetCaseID = true;
				_caseID = value;
			}
		}
		public bool IsCaseIDNull
		{
			get {
				 return _caseIDNull; }
			set { _caseIDNull = value; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public int ApplicantID
		{
			get
			{
				return _applicantID;
			}
			set
			{
				_applicantIDNull = false;
				_isSetApplicantID = true;
				_applicantID = value;
			}
		}
		public bool IsApplicantIDNull
		{
			get {
				 return _applicantIDNull; }
			set { _applicantIDNull = value; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
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
	public class CaseAbscondData
	{
		private int _abscondID;
		private int _caseID;
		private int _applicantID;
		private DateTime _modifiedDate;
		public int AbscondID
		{
			get{ return _abscondID; }
			set{ _abscondID = value; }
		}
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseAbscondPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseAbscondRow[] caseAbscondRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseAbscondItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseAbscondItems : CaseAbscondData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseAbscondItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseAbscondItems[] caseAbscondItems { get; set; }
	}
}

