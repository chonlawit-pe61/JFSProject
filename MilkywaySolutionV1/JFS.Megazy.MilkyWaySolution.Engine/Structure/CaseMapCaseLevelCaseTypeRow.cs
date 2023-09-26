using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseMapCaseLevelCaseTypeRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _helpCaseLevelID;
		private bool _isSetHelpCaseLevelID = false;
		private bool _helpCaseLevelIDNull = true;
		private string _helpCaseLevelOther;
		private bool _isSetHelpCaseLevelOther = false;
		private int _caseTypeID;
		private bool _isSetCaseTypeID = false;
		private bool _caseTypeIDNull = true;
		private string _caseTypeOther;
		private bool _isSetCaseTypeOther = false;
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
		public int HelpCaseLevelID
		{
			get
			{
				return _helpCaseLevelID;
			}
			set
			{
				_helpCaseLevelIDNull = false;
				_isSetHelpCaseLevelID = true;
				_helpCaseLevelID = value;
			}
		}
		public bool IsHelpCaseLevelIDNull
		{
			get {
				 return _helpCaseLevelIDNull; }
			set { _helpCaseLevelIDNull = value; }
		}
		public bool _IsSetHelpCaseLevelID
		{
			get { return _isSetHelpCaseLevelID; }
		}
		public string HelpCaseLevelOther
		{
			get { return _helpCaseLevelOther; }
			set { _helpCaseLevelOther = value;
			      _isSetHelpCaseLevelOther = true; }
		}
		public bool _IsSetHelpCaseLevelOther
		{
			get { return _isSetHelpCaseLevelOther; }
		}
		public int CaseTypeID
		{
			get
			{
				return _caseTypeID;
			}
			set
			{
				_caseTypeIDNull = false;
				_isSetCaseTypeID = true;
				_caseTypeID = value;
			}
		}
		public bool IsCaseTypeIDNull
		{
			get {
				 return _caseTypeIDNull; }
			set { _caseTypeIDNull = value; }
		}
		public bool _IsSetCaseTypeID
		{
			get { return _isSetCaseTypeID; }
		}
		public string CaseTypeOther
		{
			get { return _caseTypeOther; }
			set { _caseTypeOther = value;
			      _isSetCaseTypeOther = true; }
		}
		public bool _IsSetCaseTypeOther
		{
			get { return _isSetCaseTypeOther; }
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
	public class CaseMapCaseLevelCaseTypeData
	{
		private int _caseID;
		private int _helpCaseLevelID;
		private string _helpCaseLevelOther;
		private int _caseTypeID;
		private string _caseTypeOther;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int HelpCaseLevelID
		{
			get{ return _helpCaseLevelID; }
			set{ _helpCaseLevelID = value; }
		}
		public string HelpCaseLevelOther
		{
			get{ return _helpCaseLevelOther; }
			set{ _helpCaseLevelOther = value; }
		}
		public int CaseTypeID
		{
			get{ return _caseTypeID; }
			set{ _caseTypeID = value; }
		}
		public string CaseTypeOther
		{
			get{ return _caseTypeOther; }
			set{ _caseTypeOther = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseMapCaseLevelCaseTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseMapCaseLevelCaseTypeRow[] caseMapcaseLevelcaseTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseMapCaseLevelCaseTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseMapCaseLevelCaseTypeItems : CaseMapCaseLevelCaseTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseMapCaseLevelCaseTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseMapCaseLevelCaseTypeItems[] caseMapcaseLevelcaseTypeItems { get; set; }
	}
}

