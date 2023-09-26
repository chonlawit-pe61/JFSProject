using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseCategoryRow
	{
		private int _casecategoryID;
		private bool _isSetCaseCategoryID = false;
		private string _categoryName;
		private bool _isSetCategoryName = false;
		private string _lawType;
		private bool _isSetLawType = false;
		private bool _isActvie;
		private bool _isSetIsActvie = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	}
	[Serializable]
	public class CaseCategoryData
	{
		private int _casecategoryID;
		private string _categoryName;
		private string _lawType;
		private bool _isActvie;
		private int _sortOrder;
		private DateTime _modifiedDate;
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
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseCategoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseCategoryRow[] casecategoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseCategoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseCategoryItems : CaseCategoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseCategoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseCategoryItems[] casecategoryItems { get; set; }
	}
}

