using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class InspectRow
	{
		private int _inspectiD;
		private bool _isSetInspectID = false;
		private string _inspectName;
		private bool _isSetInspectName = false;
		private string _serviceCode;
		private bool _isSetServiceCode = false;
		private bool _isThaiCitizen;
		private bool _isSetIsThaiCitizen = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private int _inspectValueType;
		private bool _isSetInspectValueType = false;
		private bool _inspectValueTypeNull = true;
		[Required]
		public int InspectID
		{
			get { return _inspectiD; }
			set { _inspectiD = value;
			      _isSetInspectID = true; }
		}
		public bool _IsSetInspectID
		{
			get { return _isSetInspectID; }
		}
		[Required]
		public string InspectName
		{
			get { return _inspectName; }
			set { _inspectName = value;
			      _isSetInspectName = true; }
		}
		public bool _IsSetInspectName
		{
			get { return _isSetInspectName; }
		}
		public string ServiceCode
		{
			get { return _serviceCode; }
			set { _serviceCode = value;
			      _isSetServiceCode = true; }
		}
		public bool _IsSetServiceCode
		{
			get { return _isSetServiceCode; }
		}
		[Required]
		public bool IsThaiCitizen
		{
			get { return _isThaiCitizen; }
			set { _isThaiCitizen = value;
			      _isSetIsThaiCitizen = true; }
		}
		public bool _IsSetIsThaiCitizen
		{
			get { return _isSetIsThaiCitizen; }
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
		public int InspectValueType
		{
			get
			{
				return _inspectValueType;
			}
			set
			{
				_inspectValueTypeNull = false;
				_isSetInspectValueType = true;
				_inspectValueType = value;
			}
		}
		public bool IsInspectValueTypeNull
		{
			get {
				 return _inspectValueTypeNull; }
			set { _inspectValueTypeNull = value; }
		}
		public bool _IsSetInspectValueType
		{
			get { return _isSetInspectValueType; }
		}
	}
	[Serializable]
	public class InspectData
	{
		private int _inspectiD;
		private string _inspectName;
		private string _serviceCode;
		private bool _isThaiCitizen;
		private int _sortOrder;
		private bool _isActive;
		private int _inspectValueType;
		public int InspectID
		{
			get{ return _inspectiD; }
			set{ _inspectiD = value; }
		}
		public string InspectName
		{
			get{ return _inspectName; }
			set{ _inspectName = value; }
		}
		public string ServiceCode
		{
			get{ return _serviceCode; }
			set{ _serviceCode = value; }
		}
		public bool IsThaiCitizen
		{
			get{ return _isThaiCitizen; }
			set{ _isThaiCitizen = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public int InspectValueType
		{
			get{ return _inspectValueType; }
			set{ _inspectValueType = value; }
		}
	}
	[Serializable]
	public class InspectPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public InspectRow[] inspectRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส InspectItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class InspectItems : InspectData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class InspectItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public InspectItems[] inspectItems { get; set; }
	}
}

