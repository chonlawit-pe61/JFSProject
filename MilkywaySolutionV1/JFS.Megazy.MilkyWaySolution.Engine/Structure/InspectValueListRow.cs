using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class InspectValueListRow
	{
		private int _inspectValueListiD;
		private bool _isSetInspectValueListID = false;
		private int _inspectValueTypeiD;
		private bool _isSetInspectValueTypeID = false;
		private bool _inspectValueTypeiDNull = true;
		private string _inspectValueListName;
		private bool _isSetInspectValueListName = false;
		[Required]
		public int InspectValueListID
		{
			get { return _inspectValueListiD; }
			set { _inspectValueListiD = value;
			      _isSetInspectValueListID = true; }
		}
		public bool _IsSetInspectValueListID
		{
			get { return _isSetInspectValueListID; }
		}
		public int InspectValueTypeID
		{
			get
			{
				return _inspectValueTypeiD;
			}
			set
			{
				_inspectValueTypeiDNull = false;
				_isSetInspectValueTypeID = true;
				_inspectValueTypeiD = value;
			}
		}
		public bool IsInspectValueTypeIDNull
		{
			get {
				 return _inspectValueTypeiDNull; }
			set { _inspectValueTypeiDNull = value; }
		}
		public bool _IsSetInspectValueTypeID
		{
			get { return _isSetInspectValueTypeID; }
		}
		public string InspectValueListName
		{
			get { return _inspectValueListName; }
			set { _inspectValueListName = value;
			      _isSetInspectValueListName = true; }
		}
		public bool _IsSetInspectValueListName
		{
			get { return _isSetInspectValueListName; }
		}
	}
	[Serializable]
	public class InspectValueListData
	{
		private int _inspectValueListiD;
		private int _inspectValueTypeiD;
		private string _inspectValueListName;
		public int InspectValueListID
		{
			get{ return _inspectValueListiD; }
			set{ _inspectValueListiD = value; }
		}
		public int InspectValueTypeID
		{
			get{ return _inspectValueTypeiD; }
			set{ _inspectValueTypeiD = value; }
		}
		public string InspectValueListName
		{
			get{ return _inspectValueListName; }
			set{ _inspectValueListName = value; }
		}
	}
	[Serializable]
	public class InspectValueListPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public InspectValueListRow[] inspectValueListRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส InspectValueListItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class InspectValueListItems : InspectValueListData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class InspectValueListItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public InspectValueListItems[] inspectValueListItems { get; set; }
	}
}

