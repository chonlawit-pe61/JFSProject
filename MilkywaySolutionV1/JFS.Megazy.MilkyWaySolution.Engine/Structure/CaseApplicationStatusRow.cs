using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicationStatusRow
	{
		private int _caseApplicationStatusID;
		private bool _isSetCaseApplicationStatusID = false;
		private string _caseApplicationStatusName;
		private bool _isSetCaseApplicationStatusName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CaseApplicationStatusID
		{
			get { return _caseApplicationStatusID; }
			set { _caseApplicationStatusID = value;
			      _isSetCaseApplicationStatusID = true; }
		}
		public bool _IsSetCaseApplicationStatusID
		{
			get { return _isSetCaseApplicationStatusID; }
		}
		[Required]
		public string CaseApplicationStatusName
		{
			get { return _caseApplicationStatusName; }
			set { _caseApplicationStatusName = value;
			      _isSetCaseApplicationStatusName = true; }
		}
		public bool _IsSetCaseApplicationStatusName
		{
			get { return _isSetCaseApplicationStatusName; }
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
	public class CaseApplicationStatusData
	{
		private int _caseApplicationStatusID;
		private string _caseApplicationStatusName;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int CaseApplicationStatusID
		{
			get{ return _caseApplicationStatusID; }
			set{ _caseApplicationStatusID = value; }
		}
		public string CaseApplicationStatusName
		{
			get{ return _caseApplicationStatusName; }
			set{ _caseApplicationStatusName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApplicationStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicationStatusRow[] caseApplicationStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicationStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicationStatusItems : CaseApplicationStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicationStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicationStatusItems[] caseApplicationStatusItems { get; set; }
	}
}

