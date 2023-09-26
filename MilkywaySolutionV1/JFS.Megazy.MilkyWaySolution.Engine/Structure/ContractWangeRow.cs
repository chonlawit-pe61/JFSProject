using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ContractWangeRow
	{
		private int _contractID;
		private bool _isSetContractID = false;
		private int _wangeID;
		private bool _isSetWangeID = false;
		private double _amount;
		private bool _isSetAmount = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ContractID
		{
			get { return _contractID; }
			set { _contractID = value;
			      _isSetContractID = true; }
		}
		public bool _IsSetContractID
		{
			get { return _isSetContractID; }
		}
		[Required]
		public int WangeID
		{
			get { return _wangeID; }
			set { _wangeID = value;
			      _isSetWangeID = true; }
		}
		public bool _IsSetWangeID
		{
			get { return _isSetWangeID; }
		}
		[Required]
		public double Amount
		{
			get { return _amount; }
			set { _amount = value;
			      _isSetAmount = true; }
		}
		public bool _IsSetAmount
		{
			get { return _isSetAmount; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class ContractWangeData
	{
		private int _contractID;
		private int _wangeID;
		private double _amount;
		private DateTime _modifiedDate;
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public int WangeID
		{
			get{ return _wangeID; }
			set{ _wangeID = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ContractWangePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ContractWangeRow[] contractWangeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ContractWangeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ContractWangeItems : ContractWangeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ContractWangeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ContractWangeItems[] contractWangeItems { get; set; }
	}
}

