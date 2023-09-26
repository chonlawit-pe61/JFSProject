using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ContractTypeRow
	{
		private int _contractTypeID;
		private bool _isSetContractTypeID = false;
		private string _contractTypeName;
		private bool _isSetContractTypeName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ContractTypeID
		{
			get { return _contractTypeID; }
			set { _contractTypeID = value;
			      _isSetContractTypeID = true; }
		}
		public bool _IsSetContractTypeID
		{
			get { return _isSetContractTypeID; }
		}
		[Required]
		public string ContractTypeName
		{
			get { return _contractTypeName; }
			set { _contractTypeName = value;
			      _isSetContractTypeName = true; }
		}
		public bool _IsSetContractTypeName
		{
			get { return _isSetContractTypeName; }
		}
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
	public class ContractTypeData
	{
		private int _contractTypeID;
		private string _contractTypeName;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int ContractTypeID
		{
			get{ return _contractTypeID; }
			set{ _contractTypeID = value; }
		}
		public string ContractTypeName
		{
			get{ return _contractTypeName; }
			set{ _contractTypeName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ContractTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ContractTypeRow[] contractTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ContractTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ContractTypeItems : ContractTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ContractTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ContractTypeItems[] contractTypeItems { get; set; }
	}
}

