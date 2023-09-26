using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseArrestWithRow
	{
		private int _arrestWithID;
		private bool _isSetArrestWithID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _arrestWith;
		private bool _isSetArrestWith = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ArrestWithID
		{
			get { return _arrestWithID; }
			set { _arrestWithID = value;
			      _isSetArrestWithID = true; }
		}
		public bool _IsSetArrestWithID
		{
			get { return _isSetArrestWithID; }
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
		public string ArrestWith
		{
			get { return _arrestWith; }
			set { _arrestWith = value;
			      _isSetArrestWith = true; }
		}
		public bool _IsSetArrestWith
		{
			get { return _isSetArrestWith; }
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
	public class CaseArrestWithData
	{
		private int _arrestWithID;
		private int _applicantID;
		private string _arrestWith;
		private DateTime _modifiedDate;
		public int ArrestWithID
		{
			get{ return _arrestWithID; }
			set{ _arrestWithID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string ArrestWith
		{
			get{ return _arrestWith; }
			set{ _arrestWith = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseArrestWithPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseArrestWithRow[] caseArrestWithRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseArrestWithItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseArrestWithItems : CaseArrestWithData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseArrestWithItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseArrestWithItems[] caseArrestWithItems { get; set; }
	}
}

