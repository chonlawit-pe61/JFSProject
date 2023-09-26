using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class NationalityRow
	{
		private int _nationalityID;
		private bool _isSetNationalityID = false;
		private string _nationalityCode;
		private bool _isSetNationalityCode = false;
		private string _nationalityname;
		private bool _isSetNationalityName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int NationalityID
		{
			get { return _nationalityID; }
			set { _nationalityID = value;
			      _isSetNationalityID = true; }
		}
		public bool _IsSetNationalityID
		{
			get { return _isSetNationalityID; }
		}
		public string NationalityCode
		{
			get { return _nationalityCode; }
			set { _nationalityCode = value;
			      _isSetNationalityCode = true; }
		}
		public bool _IsSetNationalityCode
		{
			get { return _isSetNationalityCode; }
		}
		public string NationalityName
		{
			get { return _nationalityname; }
			set { _nationalityname = value;
			      _isSetNationalityName = true; }
		}
		public bool _IsSetNationalityName
		{
			get { return _isSetNationalityName; }
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
	public class NationalityData
	{
		private int _nationalityID;
		private string _nationalityCode;
		private string _nationalityname;
		private int _sortOrder;
		private bool _isActive;
		public int NationalityID
		{
			get{ return _nationalityID; }
			set{ _nationalityID = value; }
		}
		public string NationalityCode
		{
			get{ return _nationalityCode; }
			set{ _nationalityCode = value; }
		}
		public string NationalityName
		{
			get{ return _nationalityname; }
			set{ _nationalityname = value; }
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
	public class NationalityPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public NationalityRow[] nationalityRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส NationalityItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class NationalityItems : NationalityData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class NationalityItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public NationalityItems[] nationalityItems { get; set; }
	}
}

