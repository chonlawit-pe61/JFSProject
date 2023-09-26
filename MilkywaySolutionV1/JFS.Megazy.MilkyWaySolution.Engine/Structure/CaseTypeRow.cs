using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseTypeRow
	{
		private int _caseTypeID;
		private bool _isSetCaseTypeID = false;
		private string _caseTypeName;
		private bool _isSetCaseTypeName = false;
		private bool _isOtherCaseType;
		private bool _isSetIsOtherCaseType = false;
		[Required]
		public int CaseTypeID
		{
			get { return _caseTypeID; }
			set { _caseTypeID = value;
			      _isSetCaseTypeID = true; }
		}
		public bool _IsSetCaseTypeID
		{
			get { return _isSetCaseTypeID; }
		}
		[Required]
		public string CaseTypeName
		{
			get { return _caseTypeName; }
			set { _caseTypeName = value;
			      _isSetCaseTypeName = true; }
		}
		public bool _IsSetCaseTypeName
		{
			get { return _isSetCaseTypeName; }
		}
		[Required]
		public bool IsOtherCaseType
		{
			get { return _isOtherCaseType; }
			set { _isOtherCaseType = value;
			      _isSetIsOtherCaseType = true; }
		}
		public bool _IsSetIsOtherCaseType
		{
			get { return _isSetIsOtherCaseType; }
		}
	}
	[Serializable]
	public class CaseTypeData
	{
		private int _caseTypeID;
		private string _caseTypeName;
		private bool _isOtherCaseType;
		public int CaseTypeID
		{
			get{ return _caseTypeID; }
			set{ _caseTypeID = value; }
		}
		public string CaseTypeName
		{
			get{ return _caseTypeName; }
			set{ _caseTypeName = value; }
		}
		public bool IsOtherCaseType
		{
			get{ return _isOtherCaseType; }
			set{ _isOtherCaseType = value; }
		}
	}
	[Serializable]
	public class CaseTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseTypeRow[] caseTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseTypeItems : CaseTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseTypeItems[] caseTypeItems { get; set; }
	}
}

