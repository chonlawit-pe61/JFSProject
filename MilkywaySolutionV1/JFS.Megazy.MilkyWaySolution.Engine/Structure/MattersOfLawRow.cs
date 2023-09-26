using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MattersOfLawRow
	{
		private int _lawID;
		private bool _isSetLawID = false;
		private string _law;
		private bool _isSetLaw = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int LawID
		{
			get { return _lawID; }
			set { _lawID = value;
			      _isSetLawID = true; }
		}
		public bool _IsSetLawID
		{
			get { return _isSetLawID; }
		}
		public string Law
		{
			get { return _law; }
			set { _law = value;
			      _isSetLaw = true; }
		}
		public bool _IsSetLaw
		{
			get { return _isSetLaw; }
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
	public class MattersOfLawData
	{
		private int _lawID;
		private string _law;
		private int _sortOrder;
		private bool _isActive;
		public int LawID
		{
			get{ return _lawID; }
			set{ _lawID = value; }
		}
		public string Law
		{
			get{ return _law; }
			set{ _law = value; }
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
	public class MattersOfLawPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MattersOfLawRow[] mattersOfLawRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MattersOfLawItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MattersOfLawItems : MattersOfLawData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MattersOfLawItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MattersOfLawItems[] mattersOfLawItems { get; set; }
	}
}

