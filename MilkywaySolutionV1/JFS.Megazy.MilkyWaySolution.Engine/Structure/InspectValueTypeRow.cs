using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class InspectValueTypeRow
	{
		private int _inspectValueTypeiD;
		private bool _isSetInspectValueTypeID = false;
		private string _inspectValueTypeName;
		private bool _isSetInspectValueTypeName = false;
		[Required]
		public int InspectValueTypeID
		{
			get { return _inspectValueTypeiD; }
			set { _inspectValueTypeiD = value;
			      _isSetInspectValueTypeID = true; }
		}
		public bool _IsSetInspectValueTypeID
		{
			get { return _isSetInspectValueTypeID; }
		}
		[Required]
		public string InspectValueTypeName
		{
			get { return _inspectValueTypeName; }
			set { _inspectValueTypeName = value;
			      _isSetInspectValueTypeName = true; }
		}
		public bool _IsSetInspectValueTypeName
		{
			get { return _isSetInspectValueTypeName; }
		}
	}
	[Serializable]
	public class InspectValueTypeData
	{
		private int _inspectValueTypeiD;
		private string _inspectValueTypeName;
		public int InspectValueTypeID
		{
			get{ return _inspectValueTypeiD; }
			set{ _inspectValueTypeiD = value; }
		}
		public string InspectValueTypeName
		{
			get{ return _inspectValueTypeName; }
			set{ _inspectValueTypeName = value; }
		}
	}
	[Serializable]
	public class InspectValueTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public InspectValueTypeRow[] inspectValueTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส InspectValueTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class InspectValueTypeItems : InspectValueTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class InspectValueTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public InspectValueTypeItems[] inspectValueTypeItems { get; set; }
	}
}

