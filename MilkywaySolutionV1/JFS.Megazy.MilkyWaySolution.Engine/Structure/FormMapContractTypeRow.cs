using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FormMapContractTypeRow
	{
		private int _contractTypeID;
		private bool _isSetContractTypeID = false;
		private int _formID;
		private bool _isSetFormID = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
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
		public int FormID
		{
			get { return _formID; }
			set { _formID = value;
			      _isSetFormID = true; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
		[Required]
		public int SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value;
			      _isSetSortOrder = true; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
		}
	}
	[Serializable]
	public class FormMapContractTypeData
	{
		private int _contractTypeID;
		private int _formID;
		private int _sortOrder;
		public int ContractTypeID
		{
			get{ return _contractTypeID; }
			set{ _contractTypeID = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
	}
	[Serializable]
	public class FormMapContractTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FormMapContractTypeRow[] formMapContractTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FormMapContractTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FormMapContractTypeItems : FormMapContractTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FormMapContractTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FormMapContractTypeItems[] formMapContractTypeItems { get; set; }
	}
}

