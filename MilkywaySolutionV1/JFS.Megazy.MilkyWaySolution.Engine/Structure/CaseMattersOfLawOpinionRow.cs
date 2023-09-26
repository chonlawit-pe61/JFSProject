using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseMattersOfLawOpinionRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _appicantID;
		private bool _isSetAppicantID = false;
		private int _matterID;
		private bool _isSetMatterID = false;
		private int _bracketID;
		private bool _isSetBracketID = false;
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
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
		[Required]
		public int AppicantID
		{
			get { return _appicantID; }
			set { _appicantID = value;
			      _isSetAppicantID = true; }
		}
		public bool _IsSetAppicantID
		{
			get { return _isSetAppicantID; }
		}
		[Required]
		public int MatterID
		{
			get { return _matterID; }
			set { _matterID = value;
			      _isSetMatterID = true; }
		}
		public bool _IsSetMatterID
		{
			get { return _isSetMatterID; }
		}
		[Required]
		public int BracketID
		{
			get { return _bracketID; }
			set { _bracketID = value;
			      _isSetBracketID = true; }
		}
		public bool _IsSetBracketID
		{
			get { return _isSetBracketID; }
		}
		[Required]
		public int OfficerRoleID
		{
			get { return _officerRoleID; }
			set { _officerRoleID = value;
			      _isSetOfficerRoleID = true; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
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
	public class CaseMattersOfLawOpinionData
	{
		private int _caseID;
		private int _appicantID;
		private int _matterID;
		private int _bracketID;
		private int _officerRoleID;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int AppicantID
		{
			get{ return _appicantID; }
			set{ _appicantID = value; }
		}
		public int MatterID
		{
			get{ return _matterID; }
			set{ _matterID = value; }
		}
		public int BracketID
		{
			get{ return _bracketID; }
			set{ _bracketID = value; }
		}
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseMattersOfLawOpinionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseMattersOfLawOpinionRow[] caseMattersOfLawOpinionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseMattersOfLawOpinionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseMattersOfLawOpinionItems : CaseMattersOfLawOpinionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseMattersOfLawOpinionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseMattersOfLawOpinionItems[] caseMattersOfLawOpinionItems { get; set; }
	}
}

