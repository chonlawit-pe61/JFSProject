using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ContractChangeHistoryRow
	{
		private int _contractID;
		private bool _isSetContractID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private bool _isCreate;
		private bool _isSetIsCreate = false;
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
		public int UserID
		{
			get { return _userID; }
			set { _userID = value;
			      _isSetUserID = true; }
		}
		public bool _IsSetUserID
		{
			get { return _isSetUserID; }
		}
		[Required]
		public bool IsCreate
		{
			get { return _isCreate; }
			set { _isCreate = value;
			      _isSetIsCreate = true; }
		}
		public bool _IsSetIsCreate
		{
			get { return _isSetIsCreate; }
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
	public class ContractChangeHistoryData
	{
		private int _contractID;
		private int _userID;
		private bool _isCreate;
		private DateTime _modifiedDate;
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public bool IsCreate
		{
			get{ return _isCreate; }
			set{ _isCreate = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ContractChangeHistoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ContractChangeHistoryRow[] contractchangeHistoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ContractChangeHistoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ContractChangeHistoryItems : ContractChangeHistoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ContractChangeHistoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ContractChangeHistoryItems[] contractchangeHistoryItems { get; set; }
	}
}

