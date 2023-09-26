using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CareerRow
	{
		private int _careerID;
		private bool _isSetCareerID = false;
		private string _careerName;
		private bool _isSetCareerName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		[Required]
		public int CareerID
		{
			get { return _careerID; }
			set { _careerID = value;
			      _isSetCareerID = true; }
		}
		public bool _IsSetCareerID
		{
			get { return _isSetCareerID; }
		}
		public string CareerName
		{
			get { return _careerName; }
			set { _careerName = value;
			      _isSetCareerName = true; }
		}
		public bool _IsSetCareerName
		{
			get { return _isSetCareerName; }
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
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
	}
	[Serializable]
	public class CareerData
	{
		private int _careerID;
		private string _careerName;
		private DateTime _modifiedDate;
		private bool _isActive;
		private int _sortOrder;
		public int CareerID
		{
			get{ return _careerID; }
			set{ _careerID = value; }
		}
		public string CareerName
		{
			get{ return _careerName; }
			set{ _careerName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
	}
	[Serializable]
	public class CareerPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CareerRow[] careerRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CareerItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CareerItems : CareerData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CareerItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CareerItems[] careerItems { get; set; }
	}
}

