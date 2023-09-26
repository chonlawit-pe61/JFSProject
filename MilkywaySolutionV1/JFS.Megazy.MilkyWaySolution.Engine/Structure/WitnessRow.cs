using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class WitnessRow
	{
		private int _witnessID;
		private bool _isSetWitnessID = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _witnessName;
		private bool _isSetWitnessName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int WitnessID
		{
			get { return _witnessID; }
			set { _witnessID = value;
			      _isSetWitnessID = true; }
		}
		public bool _IsSetWitnessID
		{
			get { return _isSetWitnessID; }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value;
			      _isSetTitle = true; }
		}
		public bool _IsSetTitle
		{
			get { return _isSetTitle; }
		}
		public string WitnessName
		{
			get { return _witnessName; }
			set { _witnessName = value;
			      _isSetWitnessName = true; }
		}
		public bool _IsSetWitnessName
		{
			get { return _isSetWitnessName; }
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
	}
	[Serializable]
	public class WitnessData
	{
		private int _witnessID;
		private string _title;
		private string _witnessName;
		private DateTime _modifiedDate;
		public int WitnessID
		{
			get{ return _witnessID; }
			set{ _witnessID = value; }
		}
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
		}
		public string WitnessName
		{
			get{ return _witnessName; }
			set{ _witnessName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class WitnessPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public WitnessRow[] witnessRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส WitnessItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class WitnessItems : WitnessData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class WitnessItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public WitnessItems[] witnessItems { get; set; }
	}
}

