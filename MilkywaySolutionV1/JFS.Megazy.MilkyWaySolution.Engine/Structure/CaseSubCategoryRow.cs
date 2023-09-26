using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseSubCategoryRow
	{
		private int _caseSubcategoryID;
		private bool _isSetCaseSubCategoryID = false;
		private int _casecategoryID;
		private bool _isSetCaseCategoryID = false;
		private string _caseSubcategoryName;
		private bool _isSetCaseSubCategoryName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isActvie;
		private bool _isSetIsActvie = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CaseSubCategoryID
		{
			get { return _caseSubcategoryID; }
			set { _caseSubcategoryID = value;
			      _isSetCaseSubCategoryID = true; }
		}
		public bool _IsSetCaseSubCategoryID
		{
			get { return _isSetCaseSubCategoryID; }
		}
		[Required]
		public int CaseCategoryID
		{
			get { return _casecategoryID; }
			set { _casecategoryID = value;
			      _isSetCaseCategoryID = true; }
		}
		public bool _IsSetCaseCategoryID
		{
			get { return _isSetCaseCategoryID; }
		}
		[Required]
		public string CaseSubCategoryName
		{
			get { return _caseSubcategoryName; }
			set { _caseSubcategoryName = value;
			      _isSetCaseSubCategoryName = true; }
		}
		public bool _IsSetCaseSubCategoryName
		{
			get { return _isSetCaseSubCategoryName; }
		}
		public int SortOrder
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				_sortOrderNull = false;
				_isSetSortOrder = true;
				_sortOrder = value;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
		}
		[Required]
		public bool IsActvie
		{
			get { return _isActvie; }
			set { _isActvie = value;
			      _isSetIsActvie = true; }
		}
		public bool _IsSetIsActvie
		{
			get { return _isSetIsActvie; }
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
	public class CaseSubCategoryData
	{
		private int _caseSubcategoryID;
		private int _casecategoryID;
		private string _caseSubcategoryName;
		private int _sortOrder;
		private bool _isActvie;
		private DateTime _modifiedDate;
		public int CaseSubCategoryID
		{
			get{ return _caseSubcategoryID; }
			set{ _caseSubcategoryID = value; }
		}
		public int CaseCategoryID
		{
			get{ return _casecategoryID; }
			set{ _casecategoryID = value; }
		}
		public string CaseSubCategoryName
		{
			get{ return _caseSubcategoryName; }
			set{ _caseSubcategoryName = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsActvie
		{
			get{ return _isActvie; }
			set{ _isActvie = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseSubCategoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseSubCategoryRow[] caseSubcategoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseSubCategoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseSubCategoryItems : CaseSubCategoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseSubCategoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseSubCategoryItems[] caseSubcategoryItems { get; set; }
	}
}

