using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class RegionRow
	{
		private int _regionID;
		private bool _isSetRegionID = false;
		private string _regionName;
		private bool _isSetRegionName = false;
		[Required]
		public int RegionID
		{
			get { return _regionID; }
			set { _regionID = value;
			      _isSetRegionID = true; }
		}
		public bool _IsSetRegionID
		{
			get { return _isSetRegionID; }
		}
		public string RegionName
		{
			get { return _regionName; }
			set { _regionName = value;
			      _isSetRegionName = true; }
		}
		public bool _IsSetRegionName
		{
			get { return _isSetRegionName; }
		}
	}
	[Serializable]
	public class RegionData
	{
		private int _regionID;
		private string _regionName;
		public int RegionID
		{
			get{ return _regionID; }
			set{ _regionID = value; }
		}
		public string RegionName
		{
			get{ return _regionName; }
			set{ _regionName = value; }
		}
	}
	[Serializable]
	public class RegionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public RegionRow[] regionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส RegionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class RegionItems : RegionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class RegionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public RegionItems[] regionItems { get; set; }
	}
}

