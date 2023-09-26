using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseMattersOfLawRow
	{
		private int _mattersOfLawID;
		private bool _isSetMattersOfLawID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _appicantID;
		private bool _isSetAppicantID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int MattersOfLawID
		{
			get { return _mattersOfLawID; }
			set { _mattersOfLawID = value;
			      _isSetMattersOfLawID = true; }
		}
		public bool _IsSetMattersOfLawID
		{
			get { return _isSetMattersOfLawID; }
		}
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
	public class CaseMattersOfLawData
	{
		private int _mattersOfLawID;
		private int _caseID;
		private int _appicantID;
		private DateTime _modifiedDate;
		public int MattersOfLawID
		{
			get{ return _mattersOfLawID; }
			set{ _mattersOfLawID = value; }
		}
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseMattersOfLawPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseMattersOfLawRow[] caseMattersOfLawRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseMattersOfLawItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseMattersOfLawItems : CaseMattersOfLawData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseMattersOfLawItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseMattersOfLawItems[] caseMattersOfLawItems { get; set; }
	}
}

