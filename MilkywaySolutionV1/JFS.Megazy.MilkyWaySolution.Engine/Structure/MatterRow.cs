using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MatterRow
	{
		private int _matterID;
		private bool _isSetMatterID = false;
		private string _matterCode;
		private bool _isSetMatterCode = false;
		private string _matterName;
		private bool _isSetMatterName = false;
		private string _matterDescription;
		private bool _isSetMatterDescription = false;
		[Required]
		public int MatterID
		{
			get { return _matterID; }
			set { _matterID = value;
			      _isSetMatterID = true; }
		}
		public bool _IsSetMatterID
		{
			get { return _isSetMatterID; }
		}
		public string MatterCode
		{
			get { return _matterCode; }
			set { _matterCode = value;
			      _isSetMatterCode = true; }
		}
		public bool _IsSetMatterCode
		{
			get { return _isSetMatterCode; }
		}
		public string MatterName
		{
			get { return _matterName; }
			set { _matterName = value;
			      _isSetMatterName = true; }
		}
		public bool _IsSetMatterName
		{
			get { return _isSetMatterName; }
		}
		public string MatterDescription
		{
			get { return _matterDescription; }
			set { _matterDescription = value;
			      _isSetMatterDescription = true; }
		}
		public bool _IsSetMatterDescription
		{
			get { return _isSetMatterDescription; }
		}
	}
	[Serializable]
	public class MatterData
	{
		private int _matterID;
		private string _matterCode;
		private string _matterName;
		private string _matterDescription;
		public int MatterID
		{
			get{ return _matterID; }
			set{ _matterID = value; }
		}
		public string MatterCode
		{
			get{ return _matterCode; }
			set{ _matterCode = value; }
		}
		public string MatterName
		{
			get{ return _matterName; }
			set{ _matterName = value; }
		}
		public string MatterDescription
		{
			get{ return _matterDescription; }
			set{ _matterDescription = value; }
		}
	}
	[Serializable]
	public class MatterPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MatterRow[] matterRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MatterItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MatterItems : MatterData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MatterItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MatterItems[] matterItems { get; set; }
	}
}

