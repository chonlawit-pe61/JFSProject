using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseMapCaseCategoryRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _casecategoryID;
		private bool _isSetCaseCategoryID = false;
		private int _caseSubcategoryID;
		private bool _isSetCaseSubCategoryID = false;
		private bool _caseSubcategoryIDNull = true;
		private string _otherCategory;
		private bool _isSetOtherCategory = false;
		private bool _otherCategoryNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		[Required]
		public int CaseCategoryID
		{
			get { return _casecategoryID; }
			set { _casecategoryID = value;
			      _isMapRecord = false;
			      _isSetCaseCategoryID = true; }
		}
		public Boolean _IsSetCaseCategoryID
		{
			get { return _isSetCaseCategoryID; }
		}
		public int CaseSubCategoryID
		{
			get
			{
				return _caseSubcategoryID;
			}
			set
			{
				_caseSubcategoryIDNull = false;
				_isSetCaseSubCategoryID = true;
				_caseSubcategoryID = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseSubCategoryIDNull
		{
			get {
				 return _caseSubcategoryIDNull; }
			set { _caseSubcategoryIDNull = value; }
		}
		public Boolean _IsSetCaseSubCategoryID
		{
			get { return _isSetCaseSubCategoryID; }
		}
		public string OtherCategory
		{
			get
			{
				return _otherCategory;
			}
			set
			{
				_otherCategoryNull = false;
				_isSetOtherCategory = true;
				_otherCategory = value;
				_isMapRecord = false;
			}
		}
		public bool IsOtherCategoryNull
		{
			get {
				 return _otherCategoryNull; }
			set { _otherCategoryNull = value; }
		}
		public Boolean _IsSetOtherCategory
		{
			get { return _isSetOtherCategory; }
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class CaseMapCaseCategoryData
	{
		private int _caseID;
		private int _casecategoryID;
		private int _caseSubcategoryID;
		private string _otherCategory;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int CaseCategoryID
		{
			get{ return _casecategoryID; }
			set{ _casecategoryID = value; }
		}
		public int CaseSubCategoryID
		{
			get{ return _caseSubcategoryID; }
			set{ _caseSubcategoryID = value; }
		}
		public string OtherCategory
		{
			get{ return _otherCategory; }
			set{ _otherCategory = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseMapCaseCategoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseMapCaseCategoryRow[] caseMapcasecategoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseMapCaseCategoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseMapCaseCategoryItems : CaseMapCaseCategoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseMapCaseCategoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseMapCaseCategoryItems[] caseMapcasecategoryItems { get; set; }
	}
}

