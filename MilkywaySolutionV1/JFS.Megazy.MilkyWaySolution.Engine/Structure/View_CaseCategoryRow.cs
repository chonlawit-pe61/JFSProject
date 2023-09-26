using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_CaseCategoryRow
	{
		private int _casecategoryID;
		private bool _isSetCaseCategoryID = false;
		private string _categoryName;
		private bool _isSetCategoryName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private int _childcount;
		private bool _isSetChildCount = false;
		private string _lawType;
		private bool _isSetLawType = false;
		private bool _isActvie;
		private bool _isSetIsActvie = false;
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
		public string CategoryName
		{
			get { return _categoryName; }
			set { _categoryName = value;
			      _isSetCategoryName = true; }
		}
		public bool _IsSetCategoryName
		{
			get { return _isSetCategoryName; }
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
		[Required]
		public int ChildCount
		{
			get { return _childcount; }
			set { _childcount = value;
			      _isSetChildCount = true; }
		}
		public bool _IsSetChildCount
		{
			get { return _isSetChildCount; }
		}
		[Required]
		public string LawType
		{
			get { return _lawType; }
			set { _lawType = value;
			      _isSetLawType = true; }
		}
		public bool _IsSetLawType
		{
			get { return _isSetLawType; }
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
	}
	[Serializable]
	public class View_CaseCategoryData
	{
		private int _casecategoryID;
		private string _categoryName;
		private int _sortOrder;
		private DateTime _modifiedDate;
		private int _childcount;
		private string _lawType;
		private bool _isActvie;
		public int CaseCategoryID
		{
			get{ return _casecategoryID; }
			set{ _casecategoryID = value; }
		}
		public string CategoryName
		{
			get{ return _categoryName; }
			set{ _categoryName = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
		public int ChildCount
		{
			get{ return _childcount; }
			set{ _childcount = value; }
		}
		public string LawType
		{
			get{ return _lawType; }
			set{ _lawType = value; }
		}
		public bool IsActvie
		{
			get{ return _isActvie; }
			set{ _isActvie = value; }
		}
	}
	[Serializable]
	public class View_CaseCategoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseCategoryRow[] view_CaseCategoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseCategoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseCategoryItems : View_CaseCategoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseCategoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseCategoryItems[] view_CaseCategoryItems { get; set; }
	}
}

