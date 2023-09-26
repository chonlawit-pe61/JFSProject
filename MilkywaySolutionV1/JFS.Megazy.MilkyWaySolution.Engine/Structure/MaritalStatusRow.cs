using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MaritalStatusRow
	{
		private int _maritalStatusID;
		private bool _isSetMaritalStatusID = false;
		private string _maritalStatusName;
		private bool _isSetMaritalStatusName = false;
		private int _parentID;
		private bool _isSetParentID = false;
		private bool _parentIDNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int MaritalStatusID
		{
			get { return _maritalStatusID; }
			set { _maritalStatusID = value;
			      _isSetMaritalStatusID = true; }
		}
		public bool _IsSetMaritalStatusID
		{
			get { return _isSetMaritalStatusID; }
		}
		public string MaritalStatusName
		{
			get { return _maritalStatusName; }
			set { _maritalStatusName = value;
			      _isSetMaritalStatusName = true; }
		}
		public bool _IsSetMaritalStatusName
		{
			get { return _isSetMaritalStatusName; }
		}
		public int ParentID
		{
			get
			{
				return _parentID;
			}
			set
			{
				_parentIDNull = false;
				_isSetParentID = true;
				_parentID = value;
			}
		}
		public bool IsParentIDNull
		{
			get {
				 return _parentIDNull; }
			set { _parentIDNull = value; }
		}
		public bool _IsSetParentID
		{
			get { return _isSetParentID; }
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
	}
	[Serializable]
	public class MaritalStatusData
	{
		private int _maritalStatusID;
		private string _maritalStatusName;
		private int _parentID;
		private int _sortOrder;
		private bool _isActive;
		public int MaritalStatusID
		{
			get{ return _maritalStatusID; }
			set{ _maritalStatusID = value; }
		}
		public string MaritalStatusName
		{
			get{ return _maritalStatusName; }
			set{ _maritalStatusName = value; }
		}
		public int ParentID
		{
			get{ return _parentID; }
			set{ _parentID = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class MaritalStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MaritalStatusRow[] maritalStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MaritalStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MaritalStatusItems : MaritalStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MaritalStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MaritalStatusItems[] maritalStatusItems { get; set; }
	}
}

