using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ChequeStatusRow
	{
		private string _chequeStatuscode;
		private bool _isSetChequeStatusCode = false;
		private string _chequeStatusName;
		private bool _isSetChequeStatusName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		[Required]
		public string ChequeStatusCode
		{
			get { return _chequeStatuscode; }
			set { _chequeStatuscode = value;
			      _isSetChequeStatusCode = true; }
		}
		public bool _IsSetChequeStatusCode
		{
			get { return _isSetChequeStatusCode; }
		}
		public string ChequeStatusName
		{
			get { return _chequeStatusName; }
			set { _chequeStatusName = value;
			      _isSetChequeStatusName = true; }
		}
		public bool _IsSetChequeStatusName
		{
			get { return _isSetChequeStatusName; }
		}
		/// <summary>
		/// การเรียงลำดับ
		/// </summary>
		public int SortOrder
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				_sortOrderNull = false;
				_isSetSortOrder = true;
				_sortOrder = value;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
		}
	}
	[Serializable]
	public class ChequeStatusData
	{
		private string _chequeStatuscode;
		private string _chequeStatusName;
		private int _sortOrder;
		public string ChequeStatusCode
		{
			get{ return _chequeStatuscode; }
			set{ _chequeStatuscode = value; }
		}
		public string ChequeStatusName
		{
			get{ return _chequeStatusName; }
			set{ _chequeStatusName = value; }
		}
		/// <summary>
		/// การเรียงลำดับ
		/// </summary>
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
	}
	[Serializable]
	public class ChequeStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ChequeStatusRow[] chequeStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ChequeStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ChequeStatusItems : ChequeStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ChequeStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ChequeStatusItems[] chequeStatusItems { get; set; }
	}
}

