using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseInterviewLitigationRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
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
	public class CaseInterviewLitigationData
	{
		private int _caseID;
		private string _description;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
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
	public class CaseInterviewLitigationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseInterviewLitigationRow[] caseInterviewLitigationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseInterviewLitigationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseInterviewLitigationItems : CaseInterviewLitigationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseInterviewLitigationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseInterviewLitigationItems[] caseInterviewLitigationItems { get; set; }
	}
}

