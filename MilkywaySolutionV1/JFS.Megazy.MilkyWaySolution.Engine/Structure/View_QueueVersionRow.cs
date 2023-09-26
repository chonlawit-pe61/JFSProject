using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_QueueVersionRow
	{
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private int _regionID;
		private bool _isSetRegionID = false;
		private bool _regionIDNull = true;
		private int _numberOfActive;
		private bool _isSetNumberOfActive = false;
		private bool _numberOfActiveNull = true;
		[Required]
		public int ProvinceID
		{
			get { return _provinceID; }
			set { _provinceID = value;
			      _isSetProvinceID = true; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		public string ProvinceName
		{
			get { return _provinceName; }
			set { _provinceName = value;
			      _isSetProvinceName = true; }
		}
		public bool _IsSetProvinceName
		{
			get { return _isSetProvinceName; }
		}
		public int RegionID
		{
			get
			{
				return _regionID;
			}
			set
			{
				_regionIDNull = false;
				_isSetRegionID = true;
				_regionID = value;
			}
		}
		public bool IsRegionIDNull
		{
			get {
				 return _regionIDNull; }
			set { _regionIDNull = value; }
		}
		public bool _IsSetRegionID
		{
			get { return _isSetRegionID; }
		}
		public int NumberOfActive
		{
			get
			{
				return _numberOfActive;
			}
			set
			{
				_numberOfActiveNull = false;
				_isSetNumberOfActive = true;
				_numberOfActive = value;
			}
		}
		public bool IsNumberOfActiveNull
		{
			get {
				 return _numberOfActiveNull; }
			set { _numberOfActiveNull = value; }
		}
		public bool _IsSetNumberOfActive
		{
			get { return _isSetNumberOfActive; }
		}
	}
	[Serializable]
	public class View_QueueVersionData
	{
		private int _provinceID;
		private string _provinceName;
		private int _regionID;
		private int _numberOfActive;
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		public int RegionID
		{
			get{ return _regionID; }
			set{ _regionID = value; }
		}
		public int NumberOfActive
		{
			get{ return _numberOfActive; }
			set{ _numberOfActive = value; }
		}
	}
	[Serializable]
	public class View_QueueVersionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_QueueVersionRow[] view_QueueversionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_QueueVersionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_QueueVersionItems : View_QueueVersionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_QueueVersionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_QueueVersionItems[] view_QueueversionItems { get; set; }
	}
}

